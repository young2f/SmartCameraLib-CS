using NetSDKCS64;
using SmartCameraLib.core;
using SmartCameraLib.entity;
using SmartCameraLib.impl;
using SmartWatchLib.utils;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SmartCameraLib.capturer
{
    public class DHCapturerBase64 : DHBase64
    {
        private uint sercode = 0;
        private static object lockLoginIdObj = new object();
        private Dictionary<uint, CameraEntity> cameraData;
        private static object cameraDataObj = new object();
      
        public DHCapturerBase64()
        {
            cameraData = new Dictionary<uint, CameraEntity>();
            loginData = new Dictionary<string, IntPtr>();
        }
        public override LoginResult LoginSuccess(CameraEntity entity, LoginResult result)
        {
            Console.WriteLine(entity.Id + " LoginSuccess? " + result.isOk);
            if (!result.isOk) return result;
            IntPtr m_LoginID = result.loginId;
         
            #region remote async snapshot 远程异步抓图
       
            NET_SNAP_PARAMS asyncSnap = new NET_SNAP_PARAMS();
            asyncSnap.Channel = (uint)0;
            asyncSnap.Quality = 1;
            asyncSnap.ImageSize = 1;
            asyncSnap.mode = 0;
            asyncSnap.InterSnap = 0;
            asyncSnap.CmdSerial = sercode;
            bool ret = NETClient64.SnapPictureEx(m_LoginID, asyncSnap, IntPtr.Zero);
            if (!ret)
            {
                result.isOk = false;
                Logout(entity.IpAddress);
                result.message = "图像采集错误码：" + NETClient64.GetLastError();
                return result;
            }

            Set(sercode, entity);
            sercode++;
            if (sercode > 50000)
            {
                sercode = 1;
                LogHelper.WriteLog("have 50000");
            }
            #endregion

            return result;

        }
        public void SnapRevCallBack(IntPtr lLoginID, IntPtr pBuf, uint RevLen, uint EncodeType, uint CmdSerial, IntPtr dwUser)
        {
            if (EncodeType == 10) //.jpg
            {
                try
                {
                    CameraEntity entity = Get(CmdSerial);
                    if (entity == null)
                    {
                        Console.WriteLine("entity is null");
                        return;
                    }
                    string time = entity.Time;

                    byte[] data = new byte[RevLen];
                    Marshal.Copy(pBuf, data, 0, (int)RevLen);

                    CaptureCallback(lLoginID, entity, data);

                }
                catch (Exception e)
                {
                    LogHelper.WriteLog("SnapRevCallBack", e);
                }
            }
        }
        public virtual void CaptureCallback(IntPtr loginId, CameraEntity camera, byte[] img)
        {

        }
        private void Set(uint cmdSerial, CameraEntity entity)
        {
            lock (cameraDataObj)
            {
                if (!cameraData.ContainsKey(cmdSerial))
                {
                    cameraData.Add(cmdSerial, entity);
                }
                else
                {
                    cameraData[cmdSerial] = entity;
                }
            }
        }
        private CameraEntity Get(uint cmdSerial)
        {
            lock (cameraDataObj)
            {
                if (cameraData.ContainsKey(cmdSerial))
                {
                    return cameraData[cmdSerial];
                }
                else
                {
                    return null;
                }
            }
        }
        
    }
}
