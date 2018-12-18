using Newtonsoft.Json.Linq;
using SmartCameraLib.entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCameraLib.impl
{
    public struct LoginResult
    {
        public bool isOk;
        public string message;
        public IntPtr loginId;
        public IntPtr playId;
        public CameraEntity camera;

    }
    public delegate LoginResult AsyncPlayDelegate(CameraEntity camera);
    public interface ICameraPlay
    {
        /// <summary>
        /// 异步播放
        /// 返回：PlayResult
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="callback"></param>
        void AsyncPlay(CameraEntity camera, AsyncCallback callback);
        void AsyncCapture(CameraEntity camera, AsyncCallback callback);
        /// <summary>
        /// 停止播放
        /// </summary>
        void StopPlay();
        void Logout(string ip);
        /// <summary>
        /// capture时会保留login id 
        /// </summary>
     //   void LogoutAll();
        int GetOsBit();
        int GetCameraBrand();
    }
}
