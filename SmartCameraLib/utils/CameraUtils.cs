using LibCommon.entity;
using LibCommon.entity.zone;
using SmartCameraLib.entity;
using SmartWatcherConfig;
using SmartWatchLib.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartCameraLib.utils
{
    public class CameraUtils
    {
        public static CameraEntity GetCamera(ZoneEntity zone)
        {

            CameraEntity camera = new CameraEntity();

            camera.Time = CommonUtils.GetCurrentFileTimeStr();
            camera.Id = zone.ZoneId;
            camera.IpAddress = zone.IpcIp;
            camera.Name = zone.ZoneName;
            camera.Port = zone.IpcPort;
            camera.UserName = zone.IpcUser;
            camera.Password = zone.IpcPwd;

            camera.VideoId = zone.IpcId;

            return camera;
        }
        public static CameraEntity GetCamera(ZoneInfo zone, IntPtr handler)
        {

            CameraEntity camera = new CameraEntity();

            camera.Time = CommonUtils.GetCurrentFileTimeStr();
            camera.PicHandle = handler;
            camera.Id = zone.ZoneId;
            camera.IpAddress = zone.IpcIp;
            camera.Name = zone.ZoneName;
            camera.Port = zone.IpcPort;
            camera.UserName = zone.IpcUser;
            camera.Password = zone.IpcPwd;

            if (zone.IpcBrand.Equals("3"))
            {
                camera.VideoId = zone.IpcVideoId;
            }
            else
            {
                camera.VideoId = zone.IpcPipe + "";
            }
            return camera;
        }
        public static string GetCaptureFilePath(string ip,DateTime date)
        {
            StringBuilder sb = new StringBuilder();
        
            sb.Append(GetImgPath());
            sb.Append(ip+ @"\");
            sb.Append(date.Year + "-");
            sb.Append(date.Month + "-");
            sb.Append(date.Day + @"\");
            return sb.ToString();
        }
        public static string GetImgPath()
        {
         return ConfigUtils.GetInstance().GetConfig().DbDisk+ @":\SmartWatcher\capture\";

        }
    }
}
