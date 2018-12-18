using NetSDKCS32;
using SmartCameraLib.core;
using SmartCameraLib.entity;
using SmartCameraLib.impl;
using SmartWatchLib.utils;
using System;
using System.Diagnostics;

namespace SmartCameraLib.player
{
    public class DHPlayer32 : DHBase32, ICameraPlay
    {
        private static object instanceLock = new object();
        private static DHPlayer32 INSTANCE;
        public static DHPlayer32 GetInstance()
        {
            lock (instanceLock)
            {
                if (INSTANCE == null)
                {
                    lock (instanceLock)
                    {
                        INSTANCE = new DHPlayer32();
                    }
                }
            }
            return INSTANCE;
        }
        private DHPlayer32()
        {
            if (!NETClient32.IsInit())
            {
                Console.WriteLine("new dh player");
                m_DisConnectCallBack = new fDisConnectCallBack(DisConnectCallBack);
                m_ReConnectCallBack = new fHaveReConnectCallBack(ReConnectCallBack);
                m_RealDataCallBackEx2 = new fRealDataCallBackEx2(RealDataCallBackEx);

                try
                {

                    NETClient32.Init(m_DisConnectCallBack, IntPtr.Zero, null);
                    NETClient32.SetAutoReconnect(m_ReConnectCallBack, IntPtr.Zero);
                    NETClient32.SetSnapRevCallBack(m_SnapRevCallBack, IntPtr.Zero);
                    // InitOrLogoutUI();
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog("dhplayer32 init error", ex);
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
            IntPtr playId = NETClient32.RealPlay(result.loginId, 0, pHandle, type);

            if (IntPtr.Zero == playId)
            {
                result.message = "播放失败:" + NETClient32.GetLastError();
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
