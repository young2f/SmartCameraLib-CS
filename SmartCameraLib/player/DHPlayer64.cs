using NetSDKCS64;
using SmartCameraLib.core;
using SmartCameraLib.entity;
using SmartCameraLib.impl;
using SmartWatchLib.utils;
using System;
using System.Diagnostics;

namespace SmartCameraLib.player
{
    public class DHPlayer64 : DHBase64, ICameraPlay
    {
        private static object instanceLock = new object();
        private static DHPlayer64 INSTANCE;
        public static DHPlayer64 GetInstance()
        {
            lock (instanceLock)
            {
                if (INSTANCE == null)
                {
                    lock (instanceLock)
                    {
                        INSTANCE = new DHPlayer64();
                    }
                }
            }
            return INSTANCE;
        }
        private DHPlayer64()
        {
            if (!NETClient64.IsInit())
            {
                Console.WriteLine("new dh player");
                m_DisConnectCallBack = new fDisConnectCallBack(DisConnectCallBack);
                m_ReConnectCallBack = new fHaveReConnectCallBack(ReConnectCallBack);
                m_RealDataCallBackEx2 = new fRealDataCallBackEx2(RealDataCallBackEx);

                try
                {

                    NETClient64.Init(m_DisConnectCallBack, IntPtr.Zero, null);
                    NETClient64.SetAutoReconnect(m_ReConnectCallBack, IntPtr.Zero);
                    NETClient64.SetSnapRevCallBack(m_SnapRevCallBack, IntPtr.Zero);
                    // InitOrLogoutUI();
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog("dhplayer64 init error", ex);
                    Process.GetCurrentProcess().Kill();
                }
            }
        }

        public void AsyncCapture(CameraEntity camera, AsyncCallback callback)
        {
           
        }

        
        public void AsyncPlay(CameraEntity camera, AsyncCallback callback)
        {
            base.AsyncLogin(camera, callback);
        }

      

        public override LoginResult LoginSuccess(CameraEntity camera, LoginResult result)
        {
            if (!result.isOk)
            {
                result.message = camera.IpAddress+" 登录失败:" + result.message;
                return result;
            }
            IntPtr pHandle = camera.PicHandle;
            EM_RealPlayType type;
            type = EM_RealPlayType.Realplay;
            IntPtr playId = NETClient64.RealPlay(result.loginId, 0, pHandle, type);

            if (IntPtr.Zero == playId)
            {
                result.message = "播放失败:" + NETClient64.GetLastError();
                return result;
            }
            result.isOk = true;
            result.message = "ok";
            result.playId = playId;

            return result;

        }

        public void LogoutAll()
        {
            
        }
    }
}
