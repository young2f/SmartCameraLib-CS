using IpcLib;
using SmartCameraLib.entity;
using SmartCameraLib.impl;
using SmartWatchLib.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartCameraLib.core
{
    public class WiscomNVSBase
    {
        private static object lockObj = new object();
        public Dictionary<string, Int32> loginData;
        public Int32 playId = -1;
        int m_bInitSDK = -1;
        public WiscomNVSBase()
        {
            Console.WriteLine("WiscomNVSBase");
            loginData = new Dictionary<string, Int32>();

            m_bInitSDK = WiscomSDK.NVS_Init();
        }
        public void AsyncLogin(CameraEntity camera, AsyncCallback callback)
        {
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
                if (m_bInitSDK == -1)
                {
                    result.message = "SDK初始化失败";
                    return result;
                }
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
                    result.message = "IPC端口错误!";
                    return result;
                }

                //登录设备 Login the device

                Int32 m_lUserID = WiscomSDK.NVS_LogIn(camera.IpAddress, port, camera.UserName, camera.Password);
                result.loginId = (IntPtr)m_lUserID;
                if (m_lUserID < 0)
                {
                    result.message = camera.IpAddress + " 登录失败: " + m_lUserID;

                    Console.WriteLine(result.message);
                    return result;
                }
                //登录成功
                SetLoginId(camera.IpAddress, m_lUserID);

                result.isOk = true;

                return LoginSuccess(camera, result);
            }
        }
        private void SetLoginId(string ip, Int32 loginId)
        {
            if (loginData.ContainsKey(ip))
            {
                loginData[ip] = loginId;
            }
            else
            {
                loginData.Add(ip, loginId);
            }
        }
        public void RemoveLoginId(string ip)
        {
            lock (lockObj)
            {
                if (loginData.ContainsKey(ip))
                {
                    loginData.Remove(ip);
                }
            }
           
        }
        public virtual LoginResult LoginSuccess(CameraEntity camera, LoginResult result)
        {
            return result;
        }


        public void Logout(string ip)
        {
            // throw new NotImplementedException();
        }

        public void StopPlay()
        {
            try
            {
                WiscomSDK.NVS_CloseRealPlay(playId);
                playId = -1;
            }
            catch (Exception e)
            {
                LogHelper.WriteLog("stop play error", e);
            }

        }
        public int GetCameraBrand()
        {
            //  throw new NotImplementedException();
            return 3;
        }

        public int GetOsBit()
        {
            return DeviceUtils.GetAppBit();
        }
    }
}
