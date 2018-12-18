using SmartCameraLib.core;
using SmartCameraLib.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartCameraLib.entity;
using SmartWatchLib.utils;
using System.Windows.Forms;
using IpcLib;

namespace SmartCameraLib.player
{
    public class WiscomNVSPlayer : WiscomNVSBase, ICameraPlay
    {
        private static object obj = new object();
        private static WiscomNVSPlayer INSTANCE;
        private WiscomNVSPlayer()
        {
           
        }
        public static WiscomNVSPlayer GetInstance()
        {
            lock (obj)
            {
                if (INSTANCE == null)
                {
                    lock (obj)
                    {
                        INSTANCE = new WiscomNVSPlayer();
                    }
                }
            }
            return INSTANCE;
        }
        public void AsyncCapture(CameraEntity camera, AsyncCallback callback)
        {
            //  throw new NotImplementedException();
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
            Int32 loginId = result.loginId.ToInt32();
            string videoId = result.camera.VideoId;
            if (playId != -1)
            {
                StopPlay();
            }
             playId = WiscomSDK.NVS_RealPlay(loginId, videoId, result.camera.PicHandle);//预览窗口
            if (playId < 0)
            {
                result.isOk = false;
                result.message = "播放失败：" + result.camera.Name + ":" + result.camera.VideoId;
                return result;
            }
            result.isOk = true;
            result.message = "ok";
            result.playId = (IntPtr)playId;

            return result;

        }
       

    }
}
