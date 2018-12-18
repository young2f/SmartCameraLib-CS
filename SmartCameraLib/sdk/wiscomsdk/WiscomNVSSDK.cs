using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace IpcLib
{
   public class WiscomSDK
    {
        public const string dllPath = @"\.\wiscomsdk\NVSSDK.dll";
        //   public const string dllPath = @"G:\MyProject\SmartWatcher\code\NVSSDKDemo\NVSSDKDemo\bin\Debug\wiscom\NVSSDK.dll";


        int NVS_ERROR_SUCCESS = 0;           //成功
        int NVS_ERROR_CONNECT = -1;       //连接失败
        int NVS_ERROR_LOGIN = -2;      //登录失败
        int NVS_ERROR_GETCFG = -3;     //获取配置失败
        int NVS_ERROR_PARAM = -4;        //参数错误
        int NVS_ERROR_GETENC = -5;        //查询编码格式失败
        int NVS_ERROR_QUERYPROXY = -6;      //查询代理失败
        int NVS_ERROR_OPENVIDEO = -7;         //打开图像失败
        int NVS_ERROR_PLAYVIDEO = -8;      //播放图像失败
        int NVS_ERROR_FINDFILE = -9;        //查询录像失败
        int NVS_ERROR_LOADPRESET = -10;       //重新加载预置位失败
        int NVS_ERROR_CONSERVER = -11;       //连接共享磁阵失败
        int NVS_ERROR_GETRS = -12;       //查询录像服务信息失败
        int NVS_ERROR_INVALID = -10000;      //无效

        int NVS_VIDEOID_LEN = 32;      //视频ID长度
        int NVS_FILENAME_LEN = 128;     //文件名长度
        int NVS_PRESETNAME_LEN = 128;      //预置位名长度
        int NVS_IPADDRESS_LEN = 32;      //IP地址字符串长度
        int NVS_PROXYINFO_COUNT = 128;      //代理映射个数
        int NVS_DEVNAME_LEN = 64;       //监控对象名称   

        /********************************************************************
        功能:  初始化
        参数:  无
        返回:  0:成功   其他:失败
        备注:  
        *********************************************************************/
        [DllImport(dllPath)]
        public static extern Int32 NVS_Init();
        /********************************************************************
        功能:  登录服务器
        参数:  sServerIP                   Input                  服务器IP
        wServerPort                 Input                  服务器端口
        sUserName                   Input                  用户名
        sPassword                   Input                  用户密码
        返回:  登录句柄 lLogInHandle     >=0:成功    其他:失败
        备注:  可以登录多个服务器,同一个服务器只登录一次,即使用户不同也只登录一次
        *********************************************************************/
        [DllImport(dllPath)]
        public static extern Int32 NVS_LogIn(string sServerIP, UInt16 wServerPort, string sUserName, string sPassword);

        /********************************************************************
        功能:  登出指定服务器
        参数:  lLogInHandle                Input                  服务器IP
        返回:  无
        备注:  服务器IP为空则登出所有服务器
        *********************************************************************/
        [DllImport(dllPath)]
        public static extern void NVS_LogOut(Int32 lLogInHandle);


        /********************************************************************
        功能:  查询数据
        参数:  lLogInHandle                Input                  登录句柄
               eFindType    =1               Input                  查询类型
               lpFindData                  Input                  查询条件结构
        返回:  查询句柄           >=0:成功    其他:失败
        备注:  查询成功返回查询句柄
               当查询预置位时,lpFindData是LPNVS_FINDPRESET
               查询录像时,lpFindData是LPNVS_FINDFILE
               查询对象配置时,lpFindData是NULL,调用后将通过设备状态回调带出状态数据
        *********************************************************************/
        [DllImport(dllPath)]
        public static extern Int32 NVS_FindData(Int32 lLogInHandle, int eFindType, IntPtr lpFindData);

        /********************************************************************
        功能:  调看实时视频
        参数:  lLogInHandle         Input                  登录句柄
        sVideoID                    Input                  视频点位ID
        hPlayWnd                    Input                  播放窗口 
        返回:  lPlayHandle       >=0:成功    其他:失败
        备注:  
        *********************************************************************/
        [DllImport(dllPath)]
        public static extern Int32 NVS_RealPlay(Int32 lLogInHandle, string sVideoID, IntPtr hPlayWnd);


        /********************************************************************
        功能:  关闭实时视频
        参数:  lPlayHandle                 Input                  播放句柄
        返回:  无
        备注:  
        *********************************************************************/
        [DllImport(dllPath)]
        public static extern void NVS_CloseRealPlay(Int32 lPlayHandle);

        /********************************************************************
        功能:  抓图
        参数:  lPlayHandle                 Input                  播放句柄
               sFilePath                   Input                  文件完整路径
        返回:  0:成功    其他:失败
        备注:  如果目录不存在,模块会自动建立
               可以抓取jpg和bmp两种格式,模块自动根据后缀名识别
        *********************************************************************/
        [DllImport(dllPath)]
        public static extern Int32 NVS_CapPicture(Int32 lPlayHandle, string sSavePath);

    }
}
