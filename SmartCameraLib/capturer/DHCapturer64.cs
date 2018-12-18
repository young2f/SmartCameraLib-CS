using NetSDKCS64;
using SmartCameraLib.entity;
using SmartCameraLib.impl;
using SmartCameraLib.utils;
using SmartWatchLib.utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace SmartCameraLib.capturer
{
    public class DHCapturer64 : DHCapturerBase64, ICameraPlay
    {
        public static DHCapturer64 INSTANCE;
        private static object obj = new object();
        private IntPtr loginId = IntPtr.Zero;
        public static object processObj = new object();
        public List<string> processId;

        public static DHCapturer64 GetInstance()
        {
            lock (obj)
            {
                if (INSTANCE == null)
                {
                    lock (obj)
                    {
                        INSTANCE = new DHCapturer64();
                    }
                }
            }
            return INSTANCE;
        }
        public DHCapturer64()
        {
            processId = new List<string>();
            if (!NETClient64.IsInit())
            {

                m_SnapRevCallBack = new fSnapRevCallBack(SnapRevCallBack);
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
            // throw new NotImplementedException();
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
