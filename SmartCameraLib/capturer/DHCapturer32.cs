using NetSDKCS32;
using SmartCameraLib.entity;
using SmartCameraLib.impl;
using SmartCameraLib.utils;
using SmartWatchLib.utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SmartCameraLib.capturer
{
    public class DHCapturer32 : DHCapturerBase32, ICameraPlay
    {
        public static DHCapturer32 INSTANCE;
        private static object obj = new object();
        private IntPtr loginId = IntPtr.Zero;
        public static object processObj = new object();
        public List<string> processId;

        public static DHCapturer32 GetInstance()
        {
            lock (obj)
            {
                if (INSTANCE == null)
                {
                    lock (obj)
                    {
                        INSTANCE = new DHCapturer32();
                    }
                }
            }
            return INSTANCE;
        }
        public DHCapturer32()
        {
            processId = new List<string>();

            if (!NETClient32.IsInit())
            {
                m_DisConnectCallBack = new fDisConnectCallBack(DisConnectCallBack);
                m_ReConnectCallBack = new fHaveReConnectCallBack(ReConnectCallBack);
                m_RealDataCallBackEx2 = new fRealDataCallBackEx2(RealDataCallBackEx);
                m_SnapRevCallBack = new fSnapRevCallBack(SnapRevCallBack);
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
            string process = camera.IpAddress + camera.Time;
            lock (processObj)
            {
                if (processId.Contains(process)) return;
                processId.Add(process);
            }
            base.AsyncLogin(camera, callback);

        }

        public void AsyncPlay(CameraEntity camera, AsyncCallback callback)
        {

        }

        public override void CaptureCallback(IntPtr loginId, CameraEntity camera, byte[] buffer)
        {
            this.loginId = loginId;
         
            string path = CameraUtils.GetCaptureFilePath(camera.IpAddress, DateTime.Now);

            FileUtils.SaveImg(path, camera.Time + ".jpg", buffer);
            LogHelper.WriteLog("图像采集ok: " + camera.IpAddress + " --> " + buffer.Length + "kb --> " + camera.Time);
            lock (processObj)
            {
                processId.Remove(camera.IpAddress + camera.Time);
            }

        }

    }
}
