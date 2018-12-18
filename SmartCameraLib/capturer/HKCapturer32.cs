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
    public class HKCapturer32 : HKCapturerBase32
    {
        public static HKCapturer32 INSTANCE;
        private static object obj = new object();
    
        public static HKCapturer32 GetInstance()
        {
            lock (obj)
            {
                if (INSTANCE == null)
                {
                    lock (obj)
                    {
                        INSTANCE = new HKCapturer32();
                    }
                }
            }
            return INSTANCE;
        }
        public HKCapturer32()
        {
            m_bInitSDK = HKCHCNetSDK32.NET_DVR_Init();
            if (m_bInitSDK == false)
            {
                LogHelper.WriteErrorLog("hk32 NET_DVR_Init error!");
                return;
            }
            else
            {
                HKCHCNetSDK32.NET_DVR_SetLogToFile(3, System.Environment.CurrentDirectory + "\\HkIpcLog\\", true);
            }
            if (RealData32 == null)
            {
                RealData32 = new HKCHCNetSDK32.REALDATACALLBACK(RealDataCallBack);//预览实时流回调函数
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
