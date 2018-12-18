using NetSDKCS32;
using SmartCameraLib.entity;
using SmartCameraLib.impl;
using SmartWatchLib.utils;
using System;
using System.Collections.Generic;

namespace SmartCameraLib.core
{
    public class DHBase32
    {
        public static fDisConnectCallBack m_DisConnectCallBack;
        public static fHaveReConnectCallBack m_ReConnectCallBack;
        public static fRealDataCallBackEx2 m_RealDataCallBackEx2;
        public static fSnapRevCallBack m_SnapRevCallBack;

        private static object lockObj = new object();
        public IntPtr playId;
    
        public Dictionary<string, IntPtr> loginData;
        public void RealDataCallBackEx(IntPtr lRealHandle, uint dwDataType, IntPtr pBuffer, uint dwBufSize, IntPtr param, IntPtr dwUser)
        {
            // throw new NotImplementedException();
        }

        public void ReConnectCallBack(IntPtr lLoginID, IntPtr pchDVRIP, int nDVRPort, IntPtr dwUser)
        {
          
            string ip = CommonUtils.GetIpFromIntPtr(pchDVRIP);
            
            Console.WriteLine("ReConnectCallBack: " + lLoginID + "-->" + ip);
            if (String.IsNullOrEmpty(ip)) return;
            lock (lockObj)
            {
                if (loginData.ContainsKey(ip))
                {
                    loginData[ip] = lLoginID;
                }
                else
                {
                    loginData.Add(ip, lLoginID);
                }
            }
        }

        public void DisConnectCallBack(IntPtr lLoginID, IntPtr pchDVRIP, int nDVRPort, IntPtr dwUser)
        {
            lock (lockObj)
            {
                string ip = CommonUtils.GetIpFromIntPtr(pchDVRIP);
                Console.WriteLine("DisConnectCallBack: " + lLoginID + "-->" + ip);
                if (String.IsNullOrEmpty(ip)) return;
                if (loginData.ContainsKey(ip))
                {
                    loginData.Remove(ip);
                }         
            }           
           
        }

        public void AsyncLogin(CameraEntity camera, AsyncCallback callback)
        {
            if (loginData == null)
            {
                loginData = new Dictionary<string, IntPtr>();
            }

            AsyncPlayDelegate apd = Login;
            IAsyncResult asyncResult = apd.BeginInvoke(camera, callback, apd);
        }
        private LoginResult Login(CameraEntity camera)
        {
            lock (lockObj)
            {
                LoginResult result = new LoginResult();
                result.camera = camera;
                result.isOk = false;
                if (loginData.ContainsKey(camera.IpAddress))
                {
                    result.isOk = true;
                    result.loginId = loginData[camera.IpAddress];
                    return LoginSuccess(camera, result);
                }

                ushort port = 0;

                try
                {
                    port = Convert.ToUInt16(camera.Port);
                }
                catch
                {
                    result.message = "摄像机端口错误";
                    Console.WriteLine("摄像机端口错误");
                    return result;
                }

                //登录设备 Login the device

                NET_DEVICEINFO_Ex m_DeviceInfo = new NET_DEVICEINFO_Ex();
              IntPtr  loginId = NETClient32.Login(camera.IpAddress, port, camera.UserName, camera.Password, EM_LOGIN_SPAC_CAP_TYPE.TCP, IntPtr.Zero, ref m_DeviceInfo);

                if (IntPtr.Zero == loginId)
                {
                    result.message = camera.IpAddress + " 登录失败: " + NETClient32.GetLastError();

                    Console.WriteLine(result.message);
                    return result;
                }
                if (loginData.ContainsKey(camera.IpAddress))
                {
                    LogHelper.WriteLog(camera.IpAddress + " 已存在login id");
                    Logout(loginData[camera.IpAddress]);
                    loginData[camera.IpAddress] = loginId;
                }
                else
                {
                    loginData.Add(camera.IpAddress, loginId);
                }
                result.isOk = true;
                result.loginId = loginId;
                return LoginSuccess(camera, result);
            }
        }
        public virtual LoginResult LoginSuccess(CameraEntity camera, LoginResult result)
        {

            return result;
        }
        public void StopPlay()
        {
            LogHelper.WriteLog("stop: " + playId);
            if (IntPtr.Zero != playId)
            {
                if (!NETClient32.StopRealPlay(playId))
                {
                    LogHelper.WriteErrorLog("stop play fail,id: " + playId);
                }
                else
                {
                    LogHelper.WriteLog("stop: " + playId);
                    playId = IntPtr.Zero;
                }
            }


        }
        public void Logout(string ip)
        {
            if (!loginData.ContainsKey(ip)) return;
            IntPtr loginId = loginData[ip];
            if (IntPtr.Zero != loginId)
            {
                if (!NETClient32.Logout(loginId))
                {
                    LogHelper.WriteErrorLog("logout fail,id: " + loginId);
                }
                else
                {
                    LogHelper.WriteLog("logout: " + loginId);
                    loginData.Remove(ip);
                }
            }
        }
        public void Logout(IntPtr loginId)
        {

            if (IntPtr.Zero != loginId)
            {
                if (!NETClient32.Logout(loginId))
                {
                    LogHelper.WriteErrorLog("logout fail,id: " + loginId);
                }
                else
                {
                    LogHelper.WriteLog("logout: " + loginId);

                }
            }
        }
   
        public int GetOsBit()
        {
            return 32;
        }
        public int GetCameraBrand()
        {
            return 2;
        }
    }
}
