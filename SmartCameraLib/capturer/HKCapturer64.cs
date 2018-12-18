using IpcLib;
using SmartCameraLib.entity;
using SmartCameraLib.impl;
using SmartWatchLib.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartCameraLib.capturer
{
    public class HKCapturer64 : HKCapturerBase64
    {
        public static HKCapturer64 INSTANCE;
        private static object obj = new object();
        private string currentProcess = "";
        public static HKCapturer64 GetInstance()
        {
            lock (obj)
            {
                if (INSTANCE == null)
                {
                    lock (obj)
                    {
                        INSTANCE = new HKCapturer64();
                    }
                }
            }
            return INSTANCE;
        }
        public HKCapturer64()
        {
            m_bInitSDK = HKCHCNetSDK64.NET_DVR_Init();
            if (m_bInitSDK == false)
            {
                LogHelper.WriteErrorLog("hk64 NET_DVR_Init error!");
                return;
            }
            else
            {
                HKCHCNetSDK64.NET_DVR_SetLogToFile(3, System.Environment.CurrentDirectory + "\\HkIpcLog\\", true);
            }
            if (RealData64 == null)
            {
                RealData64 = new HKCHCNetSDK64.REALDATACALLBACK(RealDataCallBack);//预览实时流回调函数
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

    }
}
