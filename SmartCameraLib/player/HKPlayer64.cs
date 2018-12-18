using IpcLib;
using SmartCameraLib.core;
using SmartCameraLib.entity;
using SmartCameraLib.impl;
using SmartWatchLib.utils;
using System;

namespace SmartCameraLib.player
{
    public class HKPlayer64 : HKBase64, ICameraPlay
    {
        private static object instanceLock = new object();
        private static HKPlayer64 INSTANCE;
        public static HKPlayer64 GetInstance()
        {
            lock (instanceLock)
            {
                if (INSTANCE == null)
                {
                    lock (instanceLock)
                    {
                        INSTANCE = new HKPlayer64();
                    }
                }
            }
            return INSTANCE;
        }
        private HKPlayer64()
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
        public void AsyncPlay(CameraEntity camera, AsyncCallback callback)
        {
            base.AsyncLogin(camera, callback);
        }
        public override LoginResult LoginSuccess(CameraEntity camera, LoginResult result)
        {
            if (!result.isOk)
            {
                result.message = camera.IpAddress + " 登录失败:" + result.message;
                return result;
            }
            HKCHCNetSDK64.NET_DVR_PREVIEWINFO lpPreviewInfo = new HKCHCNetSDK64.NET_DVR_PREVIEWINFO();

            lpPreviewInfo.lChannel = CommonUtils.toInt( camera.VideoId,1); //预te览的设备通道
            lpPreviewInfo.dwStreamType = 0;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
            lpPreviewInfo.dwLinkMode = 0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
            lpPreviewInfo.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流
            lpPreviewInfo.dwDisplayBufNum = 15; //播放库播放缓冲区最大缓冲帧数
            lpPreviewInfo.hPlayWnd = camera.PicHandle;
            IntPtr pUser = new IntPtr();//用户数据

            //打开预览 Start live view 
            Int32 playId = HKCHCNetSDK64.NET_DVR_RealPlay_V40(result.loginId.ToInt32(), ref lpPreviewInfo, null/*RealData*/, pUser);
            if (playId < 0)
            {
                result.message = "播放失败:" + HKCHCNetSDK64.NET_DVR_GetLastError();
                return result;
            }
            result.isOk = true;
            result.message = "ok";
            result.playId = (IntPtr)playId;
            return result;
        }
       
        public void AsyncCapture(CameraEntity camera, AsyncCallback callback)
        {
          
        }

        public void LogoutAll()
        {
            
        }
    }
}
