using SmartCameraLib.impl;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using SmartCameraLib.entity;
using System.Threading;

namespace SmartCameraLib
{
    public class SmartCameraMgr : CameraPlayImpl
    {
        /// <summary>
        /// 初始化 
        /// </summary>
        /// <param name="cameraArray">
        /// Array Item: CameraBase to json
        /// </param>
        /// <returns>
        /// CameraBrand:bool
        /// true:初始化成功；false：初始化失败
        /// </returns>
        public void Init()
        {
            
        }
        /// <summary>
        /// 异步播放
        /// 返回：PlayResult
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="callback"></param>
        public void AsynPlay(CameraEntity cameraEntity, IntPtr playHandle, AsyncCallback callback)
        {
            AsyncPlayDelegate apd = Play;
            IAsyncResult asyncResult = apd.BeginInvoke(cameraEntity, callback, apd);
        }
        private PlayResult Play(CameraEntity camera)
        {
            PlayResult result = new PlayResult();
            result.isOk = true;
            result.StatusCode = 1;
            result.camera = camera;
            Thread.Sleep(1000);
            return result;
        }
    }
}
