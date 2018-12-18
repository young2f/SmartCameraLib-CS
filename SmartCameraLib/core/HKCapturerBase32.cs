using IpcLib;
using Newtonsoft.Json.Linq;
using SmartCameraLib.core;
using SmartCameraLib.entity;
using SmartCameraLib.impl;
using SmartCameraLib.utils;
using SmartWatchLib.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartCameraLib.capturer
{

    public class HKCapturerBase32 : HKBase32
    {
        public static object processObj = new object();
        public List<string> processId;
        public HKCapturerBase32()
        {
            loginData = new Dictionary<string, Int32>();
            processId = new List<string>();
        }
        public override LoginResult LoginSuccess(CameraEntity entity, LoginResult result)
        {
            if (!result.isOk) return result;
            Int32 m_LoginID = result.loginId.ToInt32();

            if (!(m_LoginID < 0))
            {
               

                int lChannel = CommonUtils.toInt(entity.VideoId, 1); //通道号 Channel number

                HKCHCNetSDK32.NET_DVR_JPEGPARA lpJpegPara = new HKCHCNetSDK32.NET_DVR_JPEGPARA();
                lpJpegPara.wPicQuality = 0; //图像质量 Image quality
                lpJpegPara.wPicSize = 0xff; //抓图分辨率 Picture size: 0xff-Auto(使用当前码流分辨率) 
                                            //抓图分辨率需要设备支持，更多取值请参考SDK文档

                //JPEG抓图保存成文件 Capture a JPEG picture
                string path = CameraUtils.GetCaptureFilePath(entity.IpAddress, DateTime.Now);


                FileUtils.CreateDirectory(path);
                string sJpegPicFileName = path +  entity.Time + ".jpg";

                if (!HKCHCNetSDK32.NET_DVR_CaptureJPEGPicture(m_LoginID, lChannel, ref lpJpegPara, sJpegPicFileName))
                {
                    string str = "NET_DVR_CaptureJPEGPicture failed, error code= " + HKCHCNetSDK32.NET_DVR_GetLastError();
                    LogHelper.WriteErrorLog(str);
                    Logout(entity.IpAddress);
                }
                else
                {
                    LogHelper.WriteLog("图像采集ok: " + entity.IpAddress + " --> " + entity.Time);
                }
                lock (processObj)
                {
                    processId.Remove(entity.IpAddress + entity.Time);
                }
            }

            return result;

        }
       
        public void LogoutAll()
        {
            
                try
                {
                    foreach (var v in loginData)
                    {

                        if ( v.Value>=0)
                        {
                            if (!HKCHCNetSDK32.NET_DVR_Logout(v.Value))
                            {
                                LogHelper.WriteErrorLog("logout all fail,id: " + v.Value);
                            }
                            else
                            {
                               
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    LogHelper.WriteLog("logout all fail,id: ", e);
                }

            
        }
    }
}
