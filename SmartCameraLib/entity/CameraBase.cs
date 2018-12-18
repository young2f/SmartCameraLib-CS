using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCameraLib.entity
{
  public  class CameraBase
    {
        /// <summary>
        /// camera品牌
        /// 1：海康
        /// 2、大华
        /// 3、wiscom NVS 金智NVS
        /// </summary>
        public int Brand { get; set; }
        /// <summary>
        /// camera类型
        /// 1、IPC
        /// </summary>
        public int Type { get; set; }
        public string IpAddress { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
      /// <summary>
      /// 通道或者Id
      /// </summary>
        public string VideoId { get; set; }
    }
}
