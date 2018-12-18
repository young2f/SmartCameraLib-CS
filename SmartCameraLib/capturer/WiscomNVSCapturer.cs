using SmartCameraLib.core;
using SmartCameraLib.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartCameraLib.entity;
using SmartCameraLib.utils;
using SmartWatchLib.utils;
using IpcLib;

namespace SmartCameraLib.capturer
{
    public class WiscomNVSCapturer : WiscomNVSBase, ICameraPlay
    {
        private static object obj = new object();
        private static WiscomNVSCapturer INSTANCE;
        private CameraEntity camera;
        private WiscomNVSCapturer()
        {

        }
        public static WiscomNVSCapturer GetInstance()
        {
            lock (obj)
            {
                if (INSTANCE == null)
                {
                    lock (obj)
                    {
                        INSTANCE = new WiscomNVSCapturer();
                    }
                }
            }
            return INSTANCE;
        }
        public void AsyncCapture(CameraEntity camera, AsyncCallback callback)
        {
            if (this.camera != null)
            {
                if (this.camera.VideoId.Equals(camera.VideoId) && playId != -1)
                {
                    CapturePic();
                    return;
                }
              
            }
            base.AsyncLogin(camera, callback);
        }
        private void CapturePic()
        {
            string path = CameraUtils.GetCaptureFilePath(camera.IpAddress, DateTime.Now);
            FileUtils.CreateDirectory(path);
            path = path + @"\" + camera.Time + ".jpg";
            Int32 result = WiscomSDK.NVS_CapPicture(playId, path);
            if (result != 0)
            {
                LogHelper.WriteErrorLog("capture error: " + camera.VideoId);
                playId = -1;
                
             //   base.AsyncLogin(camera, callback);
            }
        }
        public void AsyncPlay(CameraEntity camera, AsyncCallback callback)
        {

        }

        public override LoginResult LoginSuccess(CameraEntity camera, LoginResult result)
        {
            if (!result.isOk)
            {
                result.message = camera.IpAddress + " 登录失败:" + result.message;
                return result;
            }
            Int32 loginId = result.loginId.ToInt32();
            string videoId = result.camera.VideoId;
            if (playId != -1)
            {
                StopPlay();
            }
            playId = IpcLib.WiscomSDK.NVS_RealPlay(loginId, videoId, result.camera.PicHandle);//预览窗口
            if (playId < 0)
            {
                result.isOk = false;
                result.message = "播放失败：" + result.camera.Name + ":" + result.camera.VideoId;
                RemoveLoginId(result.camera.IpAddress);
                return result;
            }
            result.isOk = true;
            result.message = "ok";
            result.playId = (IntPtr)playId;
            CapturePic();
            return result;

        }

    }
}
