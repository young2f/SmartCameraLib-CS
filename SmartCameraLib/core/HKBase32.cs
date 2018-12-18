using IpcLib;
using SmartCameraLib.entity;
using SmartCameraLib.impl;

using SmartWatchLib.utils;
using System;
using System.Collections.Generic;

namespace SmartCameraLib.core
{
    public class HKBase32
    {
        public HKCHCNetSDK32.REALDATACALLBACK RealData32 = null;

        public bool m_bInitSDK = false;
        public Int32 playId;
        public Dictionary<string, Int32> loginData;
        private static object lockObj = new object();
        public void RealDataCallBack(Int32 lRealHandle, UInt32 dwDataType, IntPtr pBuffer, UInt32 dwBufSize, IntPtr pUser)
        {
            //if (dwBufSize > 0)
            //{
            //    byte[] sData = new byte[dwBufSize];
            //    Marshal.Copy(pBuffer, sData, 0, (Int32)dwBufSize);

            //    string str = "实时流数据.ps";
            //    FileStream fs = new FileStream(str, FileMode.Create);
            //    int iLen = (int)dwBufSize;
            //    fs.Write(sData, 0, iLen);
            //    fs.Close();
            //}
        }
        public void AsyncLogin(CameraEntity camera, AsyncCallback callback)
        {
            if (loginData == null)
            {
                loginData = new Dictionary<string, Int32>();
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
                    result.loginId = (IntPtr)loginData[camera.IpAddress];
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
                    return result;
                }

                HKCHCNetSDK32.NET_DVR_DEVICEINFO_V30 DeviceInfo = new HKCHCNetSDK32.NET_DVR_DEVICEINFO_V30();

                //登录设备 Login the device

          Int32      loginId = HKCHCNetSDK32.NET_DVR_Login_V30(camera.IpAddress, camera.Port, camera.UserName, camera.Password, ref DeviceInfo);

                if (loginId < 0)
                {
                    result.message = "登录失败:" + HKCHCNetSDK32.NET_DVR_GetLastError();
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
                result.loginId = (IntPtr)loginId;
                result.isOk = true;
                return LoginSuccess(camera, result);

            }
        }
        public virtual LoginResult LoginSuccess(CameraEntity camera, LoginResult result)
        {
            return result;
        }
        public void StopPlay()
        {

            if (playId >= 0)
            {
                if (!HKCHCNetSDK32.NET_DVR_StopRealPlay(playId))
                {
                    LogHelper.WriteErrorLog("stop play fail,id: " + playId);
                }
                else
                {
                    LogHelper.WriteLog("stop: " + playId);
                    playId = -1;
                }
            }

        }
        public void Logout(Int32 loginId)
        {
            if (loginId >= 0)
            {
                if (!HKCHCNetSDK32.NET_DVR_Logout(loginId))
                {
                    LogHelper.WriteErrorLog("logout fail,id: " + loginId);
                }
                else
                {
                    LogHelper.WriteLog("logout: " + loginId);
                    loginId = -1;
                }
            }
        }
        public void Logout(string ip)
        {
            if (!loginData.ContainsKey(ip)) return;
            Int32 loginId = loginData[ip];
            if (loginId >= 0)
            {
                if (!HKCHCNetSDK32.NET_DVR_Logout(loginId))
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
    
        public int GetOsBit()
        {
            return 32;
        }
        public int GetCameraBrand()
        {
            return 1;
        }
    }
}
