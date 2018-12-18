
//if the OS is linux 64bit open this define when compile the library.﻿ and open define LINUX in the OriginalSDK.cs file.
//如果系统是Linux 64位编译的时候请打下下面的宏,以及OriginalSDK.cs文件中的宏
//#define LINUX_X64   

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace NetSDKCS64
{
    /// <summary>
    /// initialization parameter structure
    /// 初始化接口参数结构体
    /// </summary>
    public struct NETSDK_INIT_PARAM
    {
        /// <summary>
        /// specify netsdk's normal network process thread number, zero means using default value
        /// 指定NetSDK常规网络处理线程数, 当值为0时, 使用内部默认值
        /// </summary>
        public int      nThreadNum;  
        /// <summary>
        /// reserved
        /// 保留字节
        /// </summary>                      
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
        public byte[]   bReserved;                                          
    }

    /// <summary>
    /// SDK error code number enumeration
    /// SDK错误码枚举
    /// </summary>
    public enum EM_ErrorCode : uint
    {
        /// <summary>
        /// No error
        /// 没有错误
        /// </summary>
        NET_NOERROR                                 = 0,		              
        /// <summary>
        /// Unknown error
        /// 未知错误
        /// </summary>
        NET_ERROR                                   = 0xFFFFFFFF,			 
        /// <summary>
        /// Windows system error
        /// Windows系统错误
        /// </summary>
        NET_SYSTEM_ERROR                            = 0x80000000 | 1,       
        /// <summary>
        /// Protocol error it may result from network timeout
        /// 网络错误,可能是因为网络超时
        /// </summary>
        NET_NETWORK_ERROR                           = 0x80000000 | 2,        
        /// <summary>
        /// Device protocol does not match
        /// 设备协议不匹配
        /// </summary>
        NET_DEV_VER_NOMATCH                         = 0x80000000 | 3,       
        /// <summary>
        /// Handle is invalid
        /// 句柄无效
        /// </summary>
        NET_INVALID_HANDLE                          = 0x80000000 | 4,       
        /// <summary>
        /// Failed to open channel
        /// 打开通道失败
        /// </summary>
        NET_OPEN_CHANNEL_ERROR                      = 0x80000000 | 5,         
        /// <summary>
        /// Failed to close channel
        /// 关闭通道失败
        /// </summary>
        NET_CLOSE_CHANNEL_ERROR		                = 0x80000000 | 6,		 
        /// <summary>
        /// User parameter is illegal
        /// 用户参数不合法
        /// </summary>
        NET_ILLEGAL_PARAM			                = 0x80000000 | 7,		
        /// <summary>
        /// SDK initialization error
        /// SDK初始化出错
        /// </summary>
        NET_SDK_INIT_ERROR			                = 0x80000000 | 8,		
        /// <summary>
        /// SDK clear error 
        /// SDK清理出错
        /// </summary>
        NET_SDK_UNINIT_ERROR		                = 0x80000000 | 9,		
        /// <summary>
        /// Error occurs when apply for render resources
        /// 申请render资源出错
        /// </summary>
        NET_RENDER_OPEN_ERROR		                = 0x80000000 | 10,		
        /// <summary>
        /// Error occurs when opening the decoder library
        /// 打开解码库出错
        /// </summary>
        NET_DEC_OPEN_ERROR			                = 0x80000000 | 11,		
        /// <summary>
        /// Error occurs when closing the decoder library
        /// 关闭解码库出错
        /// </summary>
        NET_DEC_CLOSE_ERROR			                = 0x80000000 | 12,		 
        /// <summary>
        /// The detected channel number is 0 in multiple-channel preview
        /// 多画面预览中检测到通道数为0
        /// </summary>
        NET_MULTIPLAY_NOCHANNEL		                = 0x80000000 | 13,		
        /// <summary>
        /// Failed to initialize record library
        /// 录音库初始化失败
        /// </summary>
        NET_TALK_INIT_ERROR			                = 0x80000000 | 14,		
        /// <summary>
        /// The record library has not been initialized
        /// 录音库未经初始化
        /// </summary>
        NET_TALK_NOT_INIT			                = 0x80000000 | 15,		
        /// <summary>
        /// Error occurs when sending out audio data
        /// 发送音频数据出错
        /// </summary>
	    NET_TALK_SENDDATA_ERROR		                = 0x80000000 | 16,		
        /// <summary>
        /// The real-time has been protected
        /// 实时数据已经处于保存状态
        /// </summary>
        NET_REAL_ALREADY_SAVING		                = 0x80000000 | 17,		
        /// <summary>
        /// The real-time data has not been save
        /// 未保存实时数据
        /// </summary>
        NET_NOT_SAVING				                = 0x80000000 | 18,		
        /// <summary>
        /// Error occurs when opening the file
        /// 打开文件出错
        /// </summary>
        NET_OPEN_FILE_ERROR			                = 0x80000000 | 19,		
        /// <summary>
        /// Failed to enable PTZ to control timer
        /// 启动云台控制定时器失败
        /// </summary>
        NET_PTZ_SET_TIMER_ERROR		                = 0x80000000 | 20,		
        /// <summary>
        /// Error occurs when verify returned data
        /// 对返回数据的校验出错
        /// </summary>
        NET_RETURN_DATA_ERROR		                = 0x80000000 | 21,		
        /// <summary>
        /// There is no sufficient buffer
        /// 没有足够的缓存
        /// </summary>
        NET_INSUFFICIENT_BUFFER		                = 0x80000000 | 22,		
        /// <summary>
        /// The current SDK does not support this fucntion
        /// 当前SDK未支持该功能
        /// </summary>
        NET_NOT_SUPPORTED			                = 0x80000000 | 23,		
        /// <summary>
        /// There is no searched result
        /// 查询不到录象
        /// </summary>
        NET_NO_RECORD_FOUND			                = 0x80000000 | 24,		
        /// <summary>
        /// You have no operation right
        /// 无操作权限
        /// </summary>
        NET_NOT_AUTHORIZED			                = 0x80000000 | 25,		
        /// <summary>
        /// Can not operate right now
        /// 暂时无法执行
        /// </summary>
        NET_NOT_NOW					                = 0x80000000 | 26,		
        /// <summary>
        /// There is no audio talk channel
        /// 未发现对讲通道
        /// </summary>
        NET_NO_TALK_CHANNEL			                = 0x80000000 | 27,		
        /// <summary>
        /// There is no audio
        /// 未发现音频
        /// </summary>
        NET_NO_AUDIO				                = 0x80000000 | 28,		
        /// <summary>
        /// The network SDK has not been initialized
        /// 网络SDK未经初始化
        /// </summary>
        NET_NO_INIT					                = 0x80000000 | 29,		
        /// <summary>
        /// The download completed
        /// 下载已结束
        /// </summary>
        NET_DOWNLOAD_END			                = 0x80000000 | 30,		
        /// <summary>
        /// There is no searched result
        /// 查询结果为空
        /// </summary>
        NET_EMPTY_LIST				                = 0x80000000 | 31,		
        /// <summary>
        /// Failed to get system property setup
        /// 获取系统属性配置失败
        /// </summary>
        NET_ERROR_GETCFG_SYSATTR	                = 0x80000000 | 32,		
        /// <summary>
        /// Failed to get SN
        /// 获取序列号失败
        /// </summary>
        NET_ERROR_GETCFG_SERIAL		                = 0x80000000 | 33,		
        /// <summary>
        /// Failed to get general property
        /// 获取常规属性失败
        /// </summary>
        NET_ERROR_GETCFG_GENERAL	                = 0x80000000 | 34,		
        /// <summary>
        /// Failed to get DSP capacity description
        /// 获取DSP能力描述失败
        /// </summary>
        NET_ERROR_GETCFG_DSPCAP		                = 0x80000000 | 35,		
        /// <summary>
        /// Failed to get network channel setup
        /// 获取网络配置失败
        /// </summary>
        NET_ERROR_GETCFG_NETCFG		                = 0x80000000 | 36,		
        /// <summary>
        /// Failed to get channel name
        /// 获取通道名称失败
        /// </summary>
        NET_ERROR_GETCFG_CHANNAME	                = 0x80000000 | 37,		
        /// <summary>
        /// Failed to get video property
        /// 获取视频属性失败
        /// </summary>
        NET_ERROR_GETCFG_VIDEO		                = 0x80000000 | 38,		
        /// <summary>
        /// Failed to get record setup
        /// 获取录象配置失败
        /// </summary>
        NET_ERROR_GETCFG_RECORD		                = 0x80000000 | 39,		
        /// <summary>
        /// Failed to get decoder protocol name
        /// 获取解码器协议名称失败
        /// </summary>
        NET_ERROR_GETCFG_PRONAME	                = 0x80000000 | 40,		
        /// <summary>
        /// Failed to get 232 COM function name
        /// 获取232串口功能名称失败
        /// </summary>
        NET_ERROR_GETCFG_FUNCNAME	                = 0x80000000 | 41,		
        /// <summary>
        /// Failed to get decoder property
        /// 获取解码器属性失败
        /// </summary>
        NET_ERROR_GETCFG_485DECODER	                = 0x80000000 | 42,		
        /// <summary>
        /// Failed to get 232 COM setup
        /// 获取232串口配置失败
        /// </summary>
        NET_ERROR_GETCFG_232COM		                = 0x80000000 | 43,		
        /// <summary>
        /// Failed to get external alarm input setup
        /// 获取外部报警输入配置失败
        /// </summary>
        NET_ERROR_GETCFG_ALARMIN	                = 0x80000000 | 44,		
        /// <summary>
        /// Failed to get motion detection alarm
        /// 获取动态检测报警失败
        /// </summary>
        NET_ERROR_GETCFG_ALARMDET	                = 0x80000000 | 45,		
        /// <summary>
        /// Failed to get device time
        /// 获取设备时间失败
        /// </summary>
        NET_ERROR_GETCFG_SYSTIME	                = 0x80000000 | 46,		
        /// <summary>
        /// Failed to get preview parameter
        /// 获取预览参数失败
        /// </summary>
        NET_ERROR_GETCFG_PREVIEW	                = 0x80000000 | 47,		
        /// <summary>
        /// Failed to get audio maintenance setup
        /// 获取自动维护配置失败
        /// </summary>
        NET_ERROR_GETCFG_AUTOMT		                = 0x80000000 | 48,		
        /// <summary>
        /// Failed to get video matrix setup
        /// 获取视频矩阵配置失败
        /// </summary>
        NET_ERROR_GETCFG_VIDEOMTRX	                = 0x80000000 | 49,		
        /// <summary>
        /// Failed to get privacy mask zone setup
        /// 获取区域遮挡配置失败
        /// </summary>
        NET_ERROR_GETCFG_COVER		                = 0x80000000 | 50,		
        /// <summary>
        /// Failed to get video watermark setup
        /// 获取图象水印配置失败
        /// </summary>
        NET_ERROR_GETCFG_WATERMAKE	                = 0x80000000 | 51,		
        /// <summary>
        /// Failed to get config￡omulticast port by channel
        /// 获取配置失败位置：组播端口按通道配置
        /// </summary>
        NET_ERROR_GETCFG_MULTICAST	                = 0x80000000 | 52,	   
        /// <summary>
        /// Failed to modify general property
        /// 修改常规属性失败
        /// </summary>
        NET_ERROR_SETCFG_GENERAL	                = 0x80000000 | 55,	
        /// <summary>
        /// Failed to modify channel setup
        /// 修改网络配置失败
        /// </summary>
        NET_ERROR_SETCFG_NETCFG		                = 0x80000000 | 56,		
        /// <summary>
        /// Failed to modify channel name
        /// 修改通道名称失败
        /// </summary>
        NET_ERROR_SETCFG_CHANNAME	                = 0x80000000 | 57,		
        /// <summary>
        /// Failed to modify video channel
        /// 修改视频属性失败
        /// </summary>
        NET_ERROR_SETCFG_VIDEO		                = 0x80000000 | 58,		
        /// <summary>
        /// Failed to modify record setup
        /// 修改录象配置失败
        /// </summary>
        NET_ERROR_SETCFG_RECORD		                = 0x80000000 | 59,		
        /// <summary>
        /// Failed to modify decoder property 
        /// 修改解码器属性失败
        /// </summary>
        NET_ERROR_SETCFG_485DECODER	                = 0x80000000 | 60,		
        /// <summary>
        /// Failed to modify 232 COM setup
        /// 修改232串口配置失败
        /// </summary>
        NET_ERROR_SETCFG_232COM		                = 0x80000000 | 61,		
        /// <summary>
        /// Failed to modify external input alarm setup
        /// 修改外部输入报警配置失败
        /// </summary>
        NET_ERROR_SETCFG_ALARMIN	                = 0x80000000 | 62,		
        /// <summary>
        /// Failed to modify motion detection alarm setup
        /// 修改动态检测报警配置失败
        /// </summary>
        NET_ERROR_SETCFG_ALARMDET	                = 0x80000000 | 63,		 
        /// <summary>
        /// Failed to modify device time
        /// 修改设备时间失败
        /// </summary>
        NET_ERROR_SETCFG_SYSTIME	                = 0x80000000 | 64,		
        /// <summary>
        /// Failed to modify preview parameter
        /// 修改预览参数失败
        /// </summary>
        NET_ERROR_SETCFG_PREVIEW	                = 0x80000000 | 65,		
        /// <summary>
        /// Failed to modify auto maintenance setup
        /// 修改自动维护配置失败
        /// </summary>
        NET_ERROR_SETCFG_AUTOMT		                = 0x80000000 | 66,		
        /// <summary>
        /// Failed to modify video matrix setup
        /// 修改视频矩阵配置失败
        /// </summary>
        NET_ERROR_SETCFG_VIDEOMTRX	                = 0x80000000 | 67,		 
        /// <summary>
        /// Failed to modify privacy mask zone
        /// 修改区域遮挡配置失败
        /// </summary>
        NET_ERROR_SETCFG_COVER		                = 0x80000000 | 68,		
        /// <summary>
        /// Failed to modify video watermark setup
        /// 修改图象水印配置失败
        /// </summary>
        NET_ERROR_SETCFG_WATERMAKE	                = 0x80000000 | 69,		 
        /// <summary>
        /// Failed to modify wireless network information
        /// 修改无线网络信息失败
        /// </summary>
        NET_ERROR_SETCFG_WLAN		                = 0x80000000 | 70,		
        /// <summary>
        /// Failed to select wireless network device
        /// 选择无线网络设备失败
        /// </summary>
        NET_ERROR_SETCFG_WLANDEV	                = 0x80000000 | 71,		
        /// <summary>
        /// Failed to modify the actively registration parameter setup
        /// 修改主动注册参数配置失败
        /// </summary>
        NET_ERROR_SETCFG_REGISTER	                = 0x80000000 | 72,		
        /// <summary>
        /// Failed to modify camera property
        /// 修改摄像头属性配置失败
        /// </summary>
        NET_ERROR_SETCFG_CAMERA		                = 0x80000000 | 73,		
        /// <summary>
        /// Failed to modify IR alarm setup
        /// 修改红外报警配置失败
        /// </summary>
        NET_ERROR_SETCFG_INFRARED	                = 0x80000000 | 74,		
        /// <summary>
        /// Failed to modify audio alarm setup
        /// 修改音频报警配置失败
        /// </summary>
        NET_ERROR_SETCFG_SOUNDALARM	                = 0x80000000 | 75,		
        /// <summary>
        /// Failed to modify storage position setup
        /// 修改存储位置配置失败
        /// </summary>
        NET_ERROR_SETCFG_STORAGE                    = 0x80000000 | 76,		
        /// <summary>
        /// The audio encode port has not been successfully initialized
        /// 音频编码接口没有成功初始化
        /// </summary>
        NET_AUDIOENCODE_NOTINIT		                = 0x80000000 | 77,		
        /// <summary>
        /// The data are too long
        /// 数据过长
        /// </summary>
        NET_DATA_TOOLONGH			                = 0x80000000 | 78,		
        /// <summary>
        /// The device does not support current operation
        /// 设备不支持该操作
        /// </summary>
        NET_UNSUPPORTED				                = 0x80000000 | 79,		
        /// <summary>
        /// Device resources is not sufficient
        /// 设备资源不足
        /// </summary>
        NET_DEVICE_BUSY				                = 0x80000000 | 80,		
        /// <summary>
        /// The server has boot up
        /// 服务器已经启动
        /// </summary>
        NET_SERVER_STARTED			                = 0x80000000 | 81,		
        /// <summary>
        /// The server has not fully boot up
        /// 服务器尚未成功启动
        /// </summary>
        NET_SERVER_STOPPED			                = 0x80000000 | 82,		
        /// <summary>
        /// Input serial number is not correct
        /// 输入序列号有误
        /// </summary>
        NET_LISTER_INCORRECT_SERIAL	                = 0x80000000 | 83,		
        /// <summary>
        /// Failed to get HDD information
        /// 获取硬盘信息失败
        /// </summary>
        NET_QUERY_DISKINFO_FAILED	                = 0x80000000 | 84,		
        /// <summary>
        /// Failed to get connect session information
        /// 获取连接Session信息
        /// </summary>
        NET_ERROR_GETCFG_SESSION	                = 0x80000000 | 85,		
        /// <summary>
        /// The password you typed is incorrect. You have exceeded the maximum number of retries
        /// 输入密码错误超过限制次数
        /// </summary>
        NET_USER_FLASEPWD_TRYTIME	                = 0x80000000 | 86,		
        /// <summary>
        /// Password is not correct
        /// 密码不正确
        /// </summary>
        NET_LOGIN_ERROR_PASSWORD	                = 0x80000000 | 100,	   
        /// <summary>
        /// The account does not exist
        /// 帐户不存在
        /// </summary>
        NET_LOGIN_ERROR_USER		                = 0x80000000 | 101,	  
        /// <summary>
        /// Time out for log in returned value
        /// 等待登录返回超时
        /// </summary>
        NET_LOGIN_ERROR_TIMEOUT		                = 0x80000000 | 102,	   
        /// <summary>
        /// The account has logged in
        /// 帐号已登录
        /// </summary>
        NET_LOGIN_ERROR_RELOGGIN	                = 0x80000000 | 103,	   
        /// <summary>
        /// The account has been locked
        /// 帐号已被锁定
        /// </summary>
        NET_LOGIN_ERROR_LOCKED		                = 0x80000000 | 104,	 
        /// <summary>
        /// The account bas been in the black list
        /// 帐号已被列为黑名单
        /// </summary>
        NET_LOGIN_ERROR_BLACKLIST	                = 0x80000000 | 105,	   
        /// <summary>
        /// Resources are not sufficient. System is busy now
        /// 资源不足,系统忙
        /// </summary>
        NET_LOGIN_ERROR_BUSY		                = 0x80000000 | 106,	    
        /// <summary>
        /// Time out. Please check network and try again
        /// 登录设备超时,请检查网络并重试
        /// </summary>
        NET_LOGIN_ERROR_CONNECT		                = 0x80000000 | 107,	    
        /// <summary>
        /// Network connection failed
        /// 网络连接失败
        /// </summary>
        NET_LOGIN_ERROR_NETWORK		                = 0x80000000 | 108,	    
        /// <summary>
        /// Successfully logged in the device but can not create video channel. Please check network connection
        /// 登录设备成功,但无法创建视频通道,请检查网络状况
        /// </summary>
        NET_LOGIN_ERROR_SUBCONNECT	                = 0x80000000 | 109,	    
        /// <summary>
        /// exceed the max connect number
        /// 超过最大连接数
        /// </summary>
        NET_LOGIN_ERROR_MAXCONNECT                  = 0x80000000 | 110,    
        /// <summary>
        /// protocol 3 support
        /// 只支持3代协议
        /// </summary>
        NET_LOGIN_ERROR_PROTOCOL3_ONLY              = 0x80000000 | 111,	    
        /// <summary>
        /// There is no USB or USB info error
        /// 未插入U盾或U盾信息错误
        /// </summary>
        NET_LOGIN_ERROR_UKEY_LOST	                = 0x80000000 | 112,	   
        /// <summary>
        /// Client-end IP address has no right to login
        /// 客户端IP地址没有登录权限
        /// </summary>
        NET_LOGIN_ERROR_NO_AUTHORIZED               = 0x80000000 | 113,     
        /// <summary>
        /// user or password error
        /// 账号或密码错误 
        /// </summary>
        NET_LOGIN_ERROR_USER_OR_PASSOWRD            = 0X80000000 | 117,    
        /// <summary>
        /// Error occurs when Render library open audio
        /// Render库打开音频出错
        /// </summary>
        NET_RENDER_SOUND_ON_ERROR	                = 0x80000000 | 120,	    
        /// <summary>
        /// Error occurs when Render library close audio
        /// Render库关闭音频出错
        /// </summary>
        NET_RENDER_SOUND_OFF_ERROR	                = 0x80000000 | 121,	    
        /// <summary>
        /// Error occurs when Render library control volume
        /// Render库控制音量出错
        /// </summary>
        NET_RENDER_SET_VOLUME_ERROR	                = 0x80000000 | 122,	   
        /// <summary>
        /// Error occurs when Render library set video parameter
        /// Render库设置画面参数出错
        /// </summary>
        NET_RENDER_ADJUST_ERROR		                = 0x80000000 | 123,	   
        /// <summary>
        /// Error occurs when Render library pause play
        /// Render库暂停播放出错
        /// </summary>
        NET_RENDER_PAUSE_ERROR		                = 0x80000000 | 124,	    
        /// <summary>
        /// Render library snapshot error
        /// Render库抓图出错
        /// </summary>
        NET_RENDER_SNAP_ERROR		                = 0x80000000 | 125,	    
        /// <summary>
        /// Render library stepper error
        /// Render库步进出错
        /// </summary>
        NET_RENDER_STEP_ERROR		                = 0x80000000 | 126,	   
        /// <summary>
        /// Error occurs when Render library set frame rate
        /// Render库设置帧率出错
        /// </summary>
        NET_RENDER_FRAMERATE_ERROR	                = 0x80000000 | 127,	   
        /// <summary>
        /// Error occurs when Render lib setting show region
        /// Render库设置显示区域出错
        /// </summary>
        NET_RENDER_DISPLAYREGION_ERROR	            = 0x80000000 | 128,     
        /// <summary>
        /// An error occurred when Render library getting current play time
        /// Render库获取当前播放时间出错
        /// </summary>
        NET_RENDER_GETOSDTIME_ERROR                 = 0x80000000 | 129,     
        /// <summary>
        /// Group name has been existed
        /// 组名已存在
        /// </summary>
        NET_GROUP_EXIST				                = 0x80000000 | 140,	   
        /// <summary>
        /// The group name does not exist
        /// 组名不存在
        /// </summary>
	    NET_GROUP_NOEXIST			                = 0x80000000 | 141,	    
        /// <summary>
        /// The group right exceeds the right list
        /// 组的权限超出权限列表范围
        /// </summary>
        NET_GROUP_RIGHTOVER			                = 0x80000000 | 142,	    
        /// <summary>
        /// The group can not be removed since there is user in it
        /// 组下有用户,不能删除
        /// </summary>
        NET_GROUP_HAVEUSER			                = 0x80000000 | 143,	   
        /// <summary>
        /// The user has used one of the group right. It can not be removed
        /// 组的某个权限被用户使用,不能出除
        /// </summary>
        NET_GROUP_RIGHTUSE			                = 0x80000000 | 144,	    
        /// <summary>
        /// New group name has been existed
        /// 新组名同已有组名重复
        /// </summary>
        NET_GROUP_SAMENAME			                = 0x80000000 | 145,	    
        /// <summary>
        /// The user name has been existed
        /// 用户已存在
        /// </summary>
	    NET_USER_EXIST				                = 0x80000000 | 146,	    
        /// <summary>
        /// The account does not exist
        /// 用户不存在
        /// </summary>
        NET_USER_NOEXIST			                = 0x80000000 | 147,	   
        /// <summary>
        /// User right exceeds the group right
        /// 用户权限超出组权限
        /// </summary>
        NET_USER_RIGHTOVER			                = 0x80000000 | 148,	   
        /// <summary>
        /// Reserved account. It does not allow to be modified
        /// 保留帐号,不容许修改密码
        /// </summary>
        NET_USER_PWD				                = 0x80000000 | 149,	    
        /// <summary>
        /// password is not correct
        /// 密码不正确
        /// </summary>
        NET_USER_FLASEPWD			                = 0x80000000 | 150,	    
        /// <summary>
        /// Password is invalid
        /// 密码不匹配
        /// </summary>
        NET_USER_NOMATCHING			                = 0x80000000 | 151,	    
        /// <summary>
        /// account in use
        /// 账号正在使用中
        /// </summary>
        NET_USER_INUSE				                = 0x80000000 | 152,	    
        /// <summary>
        /// Failed to get network card setup
        /// 获取网卡配置失败
        /// </summary>
        NET_ERROR_GETCFG_ETHERNET	                = 0x80000000 | 300,	    
        /// <summary>
        /// Failed to get wireless network information
        /// 获取无线网络信息失败
        /// </summary>
        NET_ERROR_GETCFG_WLAN		                = 0x80000000 | 301,	    
        /// <summary>
        /// Failed to get wireless network device
        /// 获取无线网络设备失败
        /// </summary>
        NET_ERROR_GETCFG_WLANDEV	                = 0x80000000 | 302,	    
        /// <summary>
        /// Failed to get actively registration parameter
        /// 获取主动注册参数失败
        /// </summary>
        NET_ERROR_GETCFG_REGISTER	                = 0x80000000 | 303,	    
        /// <summary>
        /// Failed to get camera property
        /// 获取摄像头属性失败
        /// </summary>
        NET_ERROR_GETCFG_CAMERA		                = 0x80000000 | 304,	    
        /// <summary>
        /// Failed to get IR alarm setup
        /// 获取红外报警配置失败
        /// </summary>
        NET_ERROR_GETCFG_INFRARED	                = 0x80000000 | 305,	    
        /// <summary>
        /// Failed to get audio alarm setup
        /// 获取音频报警配置失败
        /// </summary>
        NET_ERROR_GETCFG_SOUNDALARM	                = 0x80000000 | 306,	    
        /// <summary>
        /// Failed to get storage position
        /// 获取存储位置配置失败
        /// </summary>
        NET_ERROR_GETCFG_STORAGE                    = 0x80000000 | 307,	    
        /// <summary>
        /// Failed to get mail setup.
        /// 获取邮件配置失败
        /// </summary>
        NET_ERROR_GETCFG_MAIL		                = 0x80000000 | 308,	   
        /// <summary>
        /// Can not set right now.
        /// 暂时无法设置
        /// </summary>
        NET_CONFIG_DEVBUSY			                = 0x80000000 | 309,	   
        /// <summary>
        /// The configuration setup data are illegal.
        /// 配置数据不合法
        /// </summary>
        NET_CONFIG_DATAILLEGAL		                = 0x80000000 | 310,	    
        /// <summary>
        /// Failed to get DST setup
        /// 获取夏令时配置失败
        /// </summary>
        NET_ERROR_GETCFG_DST                        = 0x80000000 | 311,     
        /// <summary>
        /// Failed to set DST 
        /// 设置夏令时配置失败
        /// </summary>
        NET_ERROR_SETCFG_DST                        = 0x80000000 | 312,     
        /// <summary>
        /// Failed to get video osd setup.
        /// 获取视频OSD叠加配置失败
        /// </summary>
        NET_ERROR_GETCFG_VIDEO_OSD                  = 0x80000000 | 313,    
        /// <summary>
        /// Failed to set video osd 
        /// 设置视频OSD叠加配置失败
        /// </summary>
        NET_ERROR_SETCFG_VIDEO_OSD                  = 0x80000000 | 314,     
        /// <summary>
        /// Failed to get CDMA\GPRS configuration
        /// 获取CDMA\GPRS网络配置失败
        /// </summary>
        NET_ERROR_GETCFG_GPRSCDMA                   = 0x80000000 | 315,    
        /// <summary>
        /// Failed to set CDMA\GPRS configuration
        /// 设置CDMA\GPRS网络配置失败
        /// </summary>
        NET_ERROR_SETCFG_GPRSCDMA                   = 0x80000000 | 316,     
        /// <summary>
        /// Failed to get IP Filter configuration
        /// 获取IP过滤配置失败
        /// </summary>
        NET_ERROR_GETCFG_IPFILTER                   = 0x80000000 | 317,     
        /// <summary>
        /// Failed to set IP Filter configuration
        /// 设置IP过滤配置失败
        /// </summary>
        NET_ERROR_SETCFG_IPFILTER                   = 0x80000000 | 318,    
        /// <summary>
        /// Failed to get Talk Encode configuration
        /// 获取语音对讲编码配置失败
        /// </summary>
        NET_ERROR_GETCFG_TALKENCODE                 = 0x80000000 | 319,    
        /// <summary>
        /// Failed to set Talk Encode configuration
        /// 设置语音对讲编码配置失败
        /// </summary>
        NET_ERROR_SETCFG_TALKENCODE                 = 0x80000000 | 320,     
        /// <summary>
        /// Failed to get The length of the video package configuration
        /// 获取录像打包长度配置失败
        /// </summary>
        NET_ERROR_GETCFG_RECORDLEN                  = 0x80000000 | 321,     
        /// <summary>
        /// Failed to set The length of the video package configuration
        /// 设置录像打包长度配置失败
        /// </summary>
        NET_ERROR_SETCFG_RECORDLEN                  = 0x80000000 | 322,     
        /// <summary>
        /// Not support Network hard disk partition
        /// 不支持网络硬盘分区
        /// </summary>
	    NET_DONT_SUPPORT_SUBAREA	                = 0x80000000 | 323,	    
        /// <summary>
        /// Failed to get the register server information
        /// 获取设备上主动注册服务器信息失败
        /// </summary>
	    NET_ERROR_GET_AUTOREGSERVER	                = 0x80000000 | 324,	    
        /// <summary>
        /// Failed to control actively registration
        /// 主动注册重定向注册错误
        /// </summary>
	    NET_ERROR_CONTROL_AUTOREGISTER		        = 0x80000000 | 325,	    
        /// <summary>
        /// Failed to disconnect actively registration
        /// 断开主动注册服务器错误
        /// </summary>
	    NET_ERROR_DISCONNECT_AUTOREGISTER	        = 0x80000000 | 326,	    
        /// <summary>
        /// Failed to get mms configuration
        /// 获取mms配置失败
        /// </summary>
        NET_ERROR_GETCFG_MMS				        = 0x80000000 | 327,	    
        /// <summary>
        /// Failed to set mms configuration
        /// 设置mms配置失败
        /// </summary>
        NET_ERROR_SETCFG_MMS				        = 0x80000000 | 328,	    
        /// <summary>
        /// Failed to get SMS configuration
        /// 获取短信激活无线连接配置失败
        /// </summary>
        NET_ERROR_GETCFG_SMSACTIVATION              = 0x80000000 | 329,	    
        /// <summary>
        /// Failed to set SMS configuration
        /// 设置短信激活无线连接配置失败
        /// </summary>
        NET_ERROR_SETCFG_SMSACTIVATION              = 0x80000000 | 330,	    
        /// <summary>
        /// Failed to get activation of a wireless connection
        /// 获取拨号激活无线连接配置失败
        /// </summary>
        NET_ERROR_GETCFG_DIALINACTIVATION	        = 0x80000000 | 331,	    
        /// <summary>
        /// Failed to set activation of a wireless connection
        /// 设置拨号激活无线连接配置失败
        /// </summary>
        NET_ERROR_SETCFG_DIALINACTIVATION	        = 0x80000000 | 332,	    
        /// <summary>
        /// Failed to get the parameter of video output
        /// 查询视频输出参数配置失败
        /// </summary>
        NET_ERROR_GETCFG_VIDEOOUT                   = 0x80000000 | 333,     
        /// <summary>
        /// Failed to set the configuration of video output
        /// 设置视频输出参数配置失败
        /// </summary>
        NET_ERROR_SETCFG_VIDEOOUT			        = 0x80000000 | 334,	    
        /// <summary>
        /// Failed to get osd overlay enabling
        /// 获取osd叠加使能配置失败
        /// </summary>
        NET_ERROR_GETCFG_OSDENABLE			        = 0x80000000 | 335,	    
        /// <summary>
        /// Failed to set OSD overlay enabling
        /// 设置osd叠加使能配置失败
        /// </summary>
        NET_ERROR_SETCFG_OSDENABLE			        = 0x80000000 | 336,	    
        /// <summary>
        /// Failed to set digital input configuration of front encoders
        /// 设置数字通道前端编码接入配置失败
        /// </summary>
        NET_ERROR_SETCFG_ENCODERINFO                = 0x80000000 | 337,     
        /// <summary>
        /// Failed to get TV adjust configuration
        /// 获取TV调节配置失败
        /// </summary>
        NET_ERROR_GETCFG_TVADJUST		            = 0x80000000 | 338,	    
        /// <summary>
        /// Failed to set TV adjust configuration
        /// 设置TV调节配置失败
        /// </summary>
        NET_ERROR_SETCFG_TVADJUST			        = 0x80000000 | 339,	    
        /// <summary>
        /// Failed to request to establish a connection
        /// 请求建立连接失败
        /// </summary>
        NET_ERROR_CONNECT_FAILED			        = 0x80000000 | 340,	    
        /// <summary>
        /// Failed to request to upload burn files
        /// 请求刻录文件上传失败
        /// </summary>
        NET_ERROR_SETCFG_BURNFILE			        = 0x80000000 | 341,	    
        /// <summary>
        /// Failed to get capture configuration information
        /// 获取抓包配置信息失败
        /// </summary>
        NET_ERROR_SNIFFER_GETCFG			        = 0x80000000 | 342,	    
        /// <summary>
        /// Failed to set capture configuration information
        /// 设置抓包配置信息失败
        /// </summary>
        NET_ERROR_SNIFFER_SETCFG			        = 0x80000000 | 343,	    
        /// <summary>
        /// Failed to get download restrictions information
        /// 查询下载限制信息失败
        /// </summary>
        NET_ERROR_DOWNLOADRATE_GETCFG		        = 0x80000000 | 344,	    
        /// <summary>
        /// Failed to set download restrictions information
        /// 设置下载限制信息失败
        /// </summary>
        NET_ERROR_DOWNLOADRATE_SETCFG		        = 0x80000000 | 345,	    
        /// <summary>
        /// Failed to query serial port parameters
        /// 查询串口参数失败
        /// </summary>
        NET_ERROR_SEARCH_TRANSCOM			        = 0x80000000 | 346,	    
        /// <summary>
        /// Failed to get the preset info
        /// 获取预制点信息错误
        /// </summary>
        NET_ERROR_GETCFG_POINT				        = 0x80000000 | 347,	    
        /// <summary>
        /// Failed to set the preset info
        /// 设置预制点信息错误
        /// </summary>
        NET_ERROR_SETCFG_POINT				        = 0x80000000 | 348,	    
        /// <summary>
        /// SDK log out the device abnormally
        /// SDK没有正常登出设备
        /// </summary>
        NET_SDK_LOGOUT_ERROR				        = 0x80000000 | 349,     
        /// <summary>
        /// Failed to get vehicle configuration
        /// 获取车载配置失败
        /// </summary>
        NET_ERROR_GET_VEHICLE_CFG			        = 0x80000000 | 350,	    
        /// <summary>
        /// Failed to set vehicle configuration
        /// 设置车载配置失败
        /// </summary>
        NET_ERROR_SET_VEHICLE_CFG			        = 0x80000000 | 351,	    
        /// <summary>
        /// Failed to get ATM overlay configuration
        /// 获取atm叠加配置失败
        /// </summary>
        NET_ERROR_GET_ATM_OVERLAY_CFG		        = 0x80000000 | 352,	    
        /// <summary>
        /// Failed to set ATM overlay configuration
        /// 设置atm叠加配置失败
        /// </summary>
        NET_ERROR_SET_ATM_OVERLAY_CFG		        = 0x80000000 | 353,	    
        /// <summary>
        /// Failed to get ATM overlay ability
        /// 获取atm叠加能力失败
        /// </summary>
        NET_ERROR_GET_ATM_OVERLAY_ABILITY	        = 0x80000000 | 354,	    
        /// <summary>
        /// Failed to get decoder tour configuration
        /// 获取解码器解码轮巡配置失败
        /// </summary>
        NET_ERROR_GET_DECODER_TOUR_CFG		        = 0x80000000 | 355,	    
        /// <summary>
        /// Failed to set decoder tour configuration
        /// 设置解码器解码轮巡配置失败
        /// </summary>
        NET_ERROR_SET_DECODER_TOUR_CFG		        = 0x80000000 | 356,	    
        /// <summary>
        /// Failed to control decoder tour
        /// 控制解码器解码轮巡失败
        /// </summary>
        NET_ERROR_CTRL_DECODER_TOUR			        = 0x80000000 | 357,	    
        /// <summary>
        /// Beyond the device supports for the largest number of user groups
        /// 超出设备支持最大用户组数目
        /// </summary>
        NET_GROUP_OVERSUPPORTNUM			        = 0x80000000 | 358,	    
        /// <summary>
        /// Beyond the device supports for the largest number of users
        /// 超出设备支持最大用户数目
        /// </summary>
        NET_USER_OVERSUPPORTNUM				        = 0x80000000 | 359,	    
        /// <summary>
        /// Failed to get SIP configuration
        /// 获取SIP配置失败
        /// </summary>
        NET_ERROR_GET_SIP_CFG				        = 0x80000000 | 368,	    
        /// <summary>
        /// Failed to set SIP configuration
        /// 设置SIP配置失败
        /// </summary>
        NET_ERROR_SET_SIP_CFG				        = 0x80000000 | 369,	    
        /// <summary>
        /// Failed to get SIP capability
        /// 获取SIP能力失败
        /// </summary>
        NET_ERROR_GET_SIP_ABILITY			        = 0x80000000 | 370,	    
        /// <summary>
        /// Failed to get "WIFI ap' configuration
        /// 获取WIFI ap配置失败
        /// </summary>
        NET_ERROR_GET_WIFI_AP_CFG			        = 0x80000000 | 371,	    
        /// <summary>
        /// Failed to set "WIFI ap" configuration
        /// 设置WIFI ap配置失败
        /// </summary>
        NET_ERROR_SET_WIFI_AP_CFG			        = 0x80000000 | 372,	    
        /// <summary>
        /// Failed to get decode policy
        /// 获取解码策略配置失败
        /// </summary>
        NET_ERROR_GET_DECODE_POLICY		            = 0x80000000 | 373,	    
        /// <summary>
        /// Failed to set decode policy
        /// 设置解码策略配置失败
        /// </summary>
        NET_ERROR_SET_DECODE_POLICY			        = 0x80000000 | 374,	    
        /// <summary>
        /// refuse talk
        /// 拒绝对讲
        /// </summary>
        NET_ERROR_TALK_REJECT				        = 0x80000000 | 375,	    
        /// <summary>
        /// talk has opened by other client
        /// 对讲被其他客户端打开
        /// </summary>
        NET_ERROR_TALK_OPENED				        = 0x80000000 | 376,	    
        /// <summary>
        /// resource conflict
        /// 资源冲突
        /// </summary>
        NET_ERROR_TALK_RESOURCE_CONFLICIT           = 0x80000000 | 377,	    
        /// <summary>
        /// unsupported encode type
        /// 不支持的语音编码格式
        /// </summary>
        NET_ERROR_TALK_UNSUPPORTED_ENCODE           = 0x80000000 | 378,	    
        /// <summary>
        /// no right
        /// 无权限
        /// </summary>
        NET_ERROR_TALK_RIGHTLESS			        = 0x80000000 | 379,	    
        /// <summary>
        /// request failed
        /// 请求对讲失败
        /// </summary>
        NET_ERROR_TALK_FAILED				        = 0x80000000 | 380,	    
        /// <summary>
        /// Failed to get device relative config
        /// 获取机器相关配置失败
        /// </summary>
        NET_ERROR_GET_MACHINE_CFG			        = 0x80000000 | 381,	    
        /// <summary>
        /// Failed to set device relative config
        /// 设置机器相关配置失败
        /// </summary>
        NET_ERROR_SET_MACHINE_CFG			        = 0x80000000 | 382,	    
        /// <summary>
        /// get data failed
        /// 设备无法获取当前请求数据
        /// </summary>
        NET_ERROR_GET_DATA_FAILED			        = 0x80000000 | 383,	    
        /// <summary>
        /// MAC validate failed
        /// MAC地址验证失败 
        /// </summary>
        NET_ERROR_MAC_VALIDATE_FAILED               = 0x80000000 | 384,     
        /// <summary>
        /// Failed to get server instance 
        /// 获取服务器实例失败
        /// </summary>
        NET_ERROR_GET_INSTANCE                      = 0x80000000 | 385,     
        /// <summary>
        /// Generated json string is error
        /// 生成的jason字符串错误
        /// </summary>
        NET_ERROR_JSON_REQUEST                      = 0x80000000 | 386,     
        /// <summary>
        /// The responding json string is error
        /// 响应的jason字符串错误
        /// </summary>
        NET_ERROR_JSON_RESPONSE                     = 0x80000000 | 387,     
        /// <summary>
        /// The protocol version is lower than current version
        /// 协议版本低于当前使用的版本
        /// </summary>
        NET_ERROR_VERSION_HIGHER                    = 0x80000000 | 388,     
        /// <summary>
        /// Hotspare disk operation failed. The capacity is low
        /// 热备操作失败, 容量不足
        /// </summary>
        NET_SPARE_NO_CAPACITY				        = 0x80000000 | 389,	    
        /// <summary>
        /// Display source is used by other output
        /// 显示源被其他输出占用
        /// </summary>
        NET_ERROR_SOURCE_IN_USE				        = 0x80000000 | 390,	   
        /// <summary>
        /// advanced users grab low-level user resource
        /// 高级用户抢占低级用户资源
        /// </summary>
        NET_ERROR_REAVE                             = 0x80000000 | 391,    
        /// <summary>
        /// net forbid
        /// 禁止入网
        /// </summary>
        NET_ERROR_NETFORBID                         = 0x80000000 | 392,    
        /// <summary>
        /// get MAC filter configuration error
        /// 获取MAC过滤配置失败
        /// </summary>
        NET_ERROR_GETCFG_MACFILTER			        = 0x80000000 | 393,    
        /// <summary>
        /// set MAC filter configuration error
        /// 设置MAC过滤配置失败
        /// </summary>
        NET_ERROR_SETCFG_MACFILTER			        = 0x80000000 | 394,    
        /// <summary>
        /// get IP/MAC filter configuration error
        /// 获取IP/MAC过滤配置失败
        /// </summary>
        NET_ERROR_GETCFG_IPMACFILTER		        = 0x80000000 | 395,    
        /// <summary>
        /// set IP/MAC filter configuration error
        /// 设置IP/MAC过滤配置失败
        /// </summary>
        NET_ERROR_SETCFG_IPMACFILTER		        = 0x80000000 | 396,    
        /// <summary>
        /// operation over time 
        /// 当前操作超时
        /// </summary>
        NET_ERROR_OPERATION_OVERTIME                = 0x80000000 | 397,    
        /// <summary>
        /// senior validation failure
        /// 高级校验失败
        /// </summary>
        NET_ERROR_SENIOR_VALIDATE_FAILED            = 0x80000000 | 398,    
        /// <summary>
        /// device ID is not exist
        /// 设备ID不存在
        /// </summary>
        NET_ERROR_DEVICE_ID_NOT_EXIST		        = 0x80000000 | 399,	   
        /// <summary>
        /// unsupport operation
        /// 不支持当前操作
        /// </summary>
        NET_ERROR_UNSUPPORTED                       = 0x80000000 | 400,    
        /// <summary>
        /// proxy dll load error
        /// 代理库加载失败
        /// </summary>
        NET_ERROR_PROXY_DLLLOAD				        = 0x80000000 | 401,	   
        /// <summary>
        /// proxy user parameter is not legal
        /// 代理用户参数不合法
        /// </summary>
        NET_ERROR_PROXY_ILLEGAL_PARAM		        = 0x80000000 | 402,	   
        /// <summary>
        /// handle invalid
        /// 代理句柄无效
        /// </summary>
        NET_ERROR_PROXY_INVALID_HANDLE		        = 0x80000000 | 403,	   
        /// <summary>
        /// login device error
        /// 代理登入前端设备失败
        /// </summary>
        NET_ERROR_PROXY_LOGIN_DEVICE_ERROR	        = 0x80000000 | 404,	   
        /// <summary>
        /// start proxy server error
        /// 启动代理服务失败
        /// </summary>
        NET_ERROR_PROXY_START_SERVER_ERROR	        = 0x80000000 | 405,	   
        /// <summary>
        /// request speak failed
        /// 请求喊话失败
        /// </summary>
        NET_ERROR_SPEAK_FAILED				        = 0x80000000 | 406,	   
        /// <summary>
        /// unsupport F6
        /// 设备不支持此F6接口调用
        /// </summary>
        NET_ERROR_NOT_SUPPORT_F6                    = 0x80000000 | 407,    
        /// <summary>
        /// CD is not ready
        /// 光盘未就绪
        /// </summary>
        NET_ERROR_CD_UNREADY				        = 0x80000000 | 408,	   
        /// <summary>
        /// Directory does not exist
        /// 目录不存在
        /// </summary>
        NET_ERROR_DIR_NOT_EXIST				        = 0x80000000 | 409,	   
        /// <summary>
        /// The device does not support the segmentation model
        /// 设备不支持的分割模式
        /// </summary>
        NET_ERROR_UNSUPPORTED_SPLIT_MODE	        = 0x80000000 | 410,	   
        /// <summary>
        /// Open the window parameter is illegal
        /// 开窗参数不合法
        /// </summary>
        NET_ERROR_OPEN_WND_PARAM			        = 0x80000000 | 411,	   
        /// <summary>
        /// Open the window more than limit
        /// 开窗数量超过限制
        /// </summary>
        NET_ERROR_LIMITED_WND_COUNT			        = 0x80000000 | 412,	   
        /// <summary>
        /// Request command with the current pattern don't match
        /// 请求命令与当前模式不匹配
        /// </summary>
        NET_ERROR_UNMATCHED_REQUEST			        = 0x80000000 | 413,	   
        /// <summary>
        /// Render Library to enable high-definition image internal adjustment strategy error
        /// Render库启用高清图像内部调整策略出错
        /// </summary>
        NET_RENDER_ENABLELARGEPICADJUSTMENT_ERROR	= 0x80000000 | 414,	    
        /// <summary>
        /// Upgrade equipment failure
        /// 设备升级失败
        /// </summary>
        NET_ERROR_UPGRADE_FAILED                    = 0x80000000 | 415,     
        /// <summary>
        /// Can't find the target device
        /// 找不到目标设备
        /// </summary>
	    NET_ERROR_NO_TARGET_DEVICE			        = 0x80000000 | 416,	    
        /// <summary>
        /// Can't find the verify device
        /// 找不到验证设备
        /// </summary>
	    NET_ERROR_NO_VERIFY_DEVICE			        = 0x80000000 | 417,	    
        /// <summary>
        /// No cascade permissions
        /// 无级联权限
        /// </summary>
	    NET_ERROR_CASCADE_RIGHTLESS			        = 0x80000000 | 418,	    
        /// <summary>
        /// low priority
        /// 低优先级
        /// </summary>
        NET_ERROR_LOW_PRIORITY				        = 0x80000000 | 419,	    
        /// <summary>
        /// The remote device request timeout
        /// 远程设备请求超时
        /// </summary>
        NET_ERROR_REMOTE_REQUEST_TIMEOUT	        = 0x80000000 | 420,	    
        /// <summary>
        /// Input source beyond maximum route restrictions
        /// 输入源超出最大路数限制
        /// </summary>
        NET_ERROR_LIMITED_INPUT_SOURCE		        = 0x80000000 | 421,	    
        /// <summary>
        /// Failed to set log print
        /// 设置日志打印失败
        /// </summary>
        NET_ERROR_SET_LOG_PRINT_INFO                = 0x80000000 | 422,     
        /// <summary>
        /// "dwSize" is not initialized in input param
        /// 入参的dwsize字段出错
        /// </summary>
        NET_ERROR_PARAM_DWSIZE_ERROR                = 0x80000000 | 423,     
        /// <summary>
        /// TV wall exceed limit
        /// 电视墙数量超过上限
        /// </summary>
        NET_ERROR_LIMITED_MONITORWALL_COUNT         = 0x80000000 | 424,     
        /// <summary>
        /// Fail to execute part of the process
        /// 部分过程执行失败
        /// </summary>
        NET_ERROR_PART_PROCESS_FAILED               = 0x80000000 | 425,     
        /// <summary>
        /// Fail to transmit due to not supported by target
        /// 该功能不支持转发
        /// </summary>
        NET_ERROR_TARGET_NOT_SUPPORT                = 0x80000000 | 426,     
        /// <summary>
        /// Access to the file failed
        /// 访问文件失败
        /// </summary>
        NET_ERROR_VISITE_FILE				        = 0x80000000 | 510,	    
        /// <summary>
        /// Device busy
        /// 设备忙
        /// </summary>
        NET_ERROR_DEVICE_STATUS_BUSY		        = 0x80000000 | 511,	    
        /// <summary>
        /// Fail to change the password
        /// 修改密码无权限
        /// </summary>
        NET_USER_PWD_NOT_AUTHORIZED                 = 0x80000000 | 512,     
        /// <summary>
        /// Password strength is not enough
        /// 密码强度不够
        /// </summary>
        NET_USER_PWD_NOT_STRONG                     = 0x80000000 | 513,     
        /// <summary>
        /// No corresponding setup
        /// 没有对应的配置
        /// </summary>
        NET_ERROR_NO_SUCH_CONFIG                    = 0x80000000 | 514,     
        /// <summary>
        /// Failed to record audio
        /// 录音失败
        /// </summary>
        NET_ERROR_AUDIO_RECORD_FAILED               = 0x80000000 | 515,     
        /// <summary>
        /// Failed to send out data 
        /// 数据发送失败
        /// </summary>
        NET_ERROR_SEND_DATA_FAILED                  = 0x80000000 | 516,     
        /// <summary>
        /// Abandoned port 
        /// 废弃接口
        /// </summary>
        NET_ERROR_OBSOLESCENT_INTERFACE             = 0x80000000 | 517,     
        /// <summary>
        /// Internal buffer is not sufficient 
        /// 内部缓冲不足
        /// </summary>
        NET_ERROR_INSUFFICIENT_INTERAL_BUF          = 0x80000000 | 518,     
        /// <summary>
        /// verify password when changing device IP
        /// 修改设备ip时,需要校验密码
        /// </summary>
        NET_ERROR_NEED_ENCRYPTION_PASSWORD          = 0x80000000 | 519,     
        /// <summary>
        /// Failed to serialize data
        /// 设备不支持此记录集
        /// </summary>
        NET_ERROR_SERIALIZE_ERROR                   = 0x80000000 | 1010,    
        /// <summary>
        /// Failed to deserialize data
        /// 数据序列化错误
        /// </summary>
        NET_ERROR_DESERIALIZE_ERROR                 = 0x80000000 | 1011,    
        /// <summary>
        /// the wireless id is already existed
        /// 数据反序列化错误
        /// </summary>
        NET_ERROR_LOWRATEWPAN_ID_EXISTED            = 0x80000000 | 1012,    
        /// <summary>
        /// the wireless id limited
        /// 该无线ID已存在
        /// </summary>
        NET_ERROR_LOWRATEWPAN_ID_LIMIT              = 0x80000000 | 1013,    
        /// <summary>
        /// add the wireless id abnormaly
        /// 无线ID数量已超限
        /// </summary>
        NET_ERROR_LOWRATEWPAN_ID_ABNORMAL           = 0x80000000 | 1014, 
        /// <summary>
        /// encrypt data fail
        /// 加密数据失败
        /// </summary>
        NET_ERROR_ENCRYPT                           = 0x80000000 | 1015,
        /// <summary>
        /// new password illegal
        /// 新密码不合规范
        /// </summary>
        NET_ERROR_PWD_ILLEGAL                       = 0x80000000 | 1016,       
        /// <summary>
        /// device is already init
        /// 设备已经初始化
        /// </summary>
        NET_ERROR_DEVICE_ALREADY_INIT               = 0x80000000 | 1017,       
        /// <summary>
        /// security code check out fail
        /// 安全码错误
        /// </summary>
        NET_ERROR_SECURITY_CODE                     = 0x80000000 | 1018,       
        /// <summary>
        /// security code out of time
        /// 安全码超出有效期
        /// </summary>
        NET_ERROR_SECURITY_CODE_TIMEOUT             = 0x80000000 | 1019,       
        /// <summary>
        /// get passwd specification fail
        /// 获取密码规范失败
        /// </summary>
        NET_ERROR_GET_PWD_SPECI                     = 0x80000000 | 1020,       
        /// <summary>
        /// no authority of operation 
        /// 无权限进行该操作
        /// </summary>
        NET_ERROR_NO_AUTHORITY_OF_OPERATION         = 0x80000000 | 1021,      
        /// <summary>
        /// decrypt data fail
        /// 解密数据失败
        /// </summary>
        NET_ERROR_DECRYPT                           = 0x80000000 | 1022,       
        /// <summary>
        /// 2D code check out fail
        /// 2D code校验失败
        /// </summary>
        NET_ERROR_2D_CODE                           = 0x80000000 | 1023,       
        /// <summary>
        /// invalid request
        /// 非法的RPC请求
        /// </summary>
        NET_ERROR_INVALID_REQUEST                   = 0x80000000 | 1024,       
        /// <summary>
        /// pwd reset disabled
        /// 密码重置功能已关闭
        /// </summary>
        NET_ERROR_PWD_RESET_DISABLE			        = 0x80000000 | 1025,	  
        /// <summary>
        /// failed to display private data,such as rule box
        /// 显示私有数据，比如规则框等失败
        /// </summary>
        NET_ERROR_PLAY_PRIVATE_DATA                 = 0x80000000 | 1026,       
        /// <summary>
        /// robot operate failed
        /// 机器人操作失败
        /// </summary>
        NET_ERROR_ROBOT_OPERATE_FAILED              = 0x80000000 | 1027,       
        /// <summary>
        /// invaild channel
        /// 无效的通道
        /// </summary>
        ERR_INTERNAL_INVALID_CHANNEL                = 0x90001002,           
        /// <summary>
        /// reopen channel failed
        /// 重新打开通道失败
        /// </summary>
        ERR_INTERNAL_REOPEN_CHANNEL                 = 0x90001003,           
        /// <summary>
        /// send data failed
        /// 发送数据失败
        /// </summary>
        ERR_INTERNAL_SEND_DATA                      = 0x90002008,           
        /// <summary>
        /// creat socket failed
        /// 创建套接字失败
        /// </summary>
        ERR_INTERNAL_CREATE_SOCKET                  = 0x90002003,           
    }

    /// <summary>
    /// device information structure
    /// 设备信息结构体
    /// </summary>
    public struct NET_DEVICEINFO_Ex
    {
        /// <summary>
        /// serial number
        /// 序列号
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 48)]
        public string              sSerialNumber;	                        
        /// <summary>
        /// count of alarm input
        /// 报警输入个数
        /// </summary>
        public int	               nAlarmInPortNum;                         
        /// <summary>
        /// count of alarm output
        /// 报警输出个数
        /// </summary>
        public int	               nAlarmOutPortNum;                        
        /// <summary>
        /// number of disk
        /// 硬盘个数
        /// </summary>
        public int	               nDiskNum;                                
        /// <summary>
        /// device type, refer to EM_NET_DEVICE_TYPE
        /// 设备类型,见枚举NET_DEVICE_TYPE
        /// </summary>
        public EM_NET_DEVICE_TYPE nDVRType;                                 
        /// <summary>
        /// number of channel
        /// 通道个数
        /// </summary>
        public int                 nChanNum;                                
        /// <summary>
        /// Online Timeout, Not Limited Access to 0, not 0 Minutes Limit Said
        /// 在线超时时间,为0表示不限制登陆,非0表示限制的分钟数
        /// </summary>
        public byte                byLimitLoginTime;                        
        /// <summary>
        /// When login failed due to password error, notice user by this parameter.This parameter is invalid when remaining login times is zero
        /// 当登陆失败原因为密码错误时,通过此参数通知用户,剩余登陆次数,为0时表示此参数无效
        /// </summary>
        public byte                byLeftLogTimes;                          
        /// <summary>
        /// keep bytes for aligned
        /// 保留字节,字节对齐
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[]              bReserved;                               
        /// <summary>
        /// when log in failed,the left time for users to unlock (seconds), -1 indicate the device haven't set the parameter
        /// 当登陆失败,用户解锁剩余时间（秒数）, -1表示设备未设置该参数
        /// </summary>
        public int                 nLockLeftTime;                            
        /// <summary>
        /// reserved
        /// 保留字节
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
        public byte[]              Reserved;                               
    }

    /// <summary>
    /// device type enumeration
    /// 设备类型枚举
    /// </summary>
    public enum EM_NET_DEVICE_TYPE
    {
        /// <summary>
        /// Unknow
        //  未知
        /// </summary>
        NET_PRODUCT_NONE = 0,
        /// <summary>
        /// Non real-time MACE
        /// 非实时MACE
        /// </summary>
        NET_DVR_NONREALTIME_MACE,					                        
        /// <summary>
        /// Non real-time
        /// 非实时
        /// </summary>
        NET_DVR_NONREALTIME,						                        
        /// <summary>
        /// Network video server
        /// 网络视频服务器
        /// </summary>
        NET_NVS_MPEG1,								                        
        /// <summary>
        /// MPEG1 2-ch DVR
        /// MPEG1二路录像机
        /// </summary>
        NET_DVR_MPEG1_2,							                        
        /// <summary>
        /// MPEG1 8-ch DVR
        /// MPEG1八路录像机
        /// </summary>
        NET_DVR_MPEG1_8,							                        
        /// <summary>
        /// MPEG4 8-ch DVR
        /// MPEG4八路录像机
        /// </summary>
        NET_DVR_MPEG4_8,							                        
        /// <summary>
        /// MPEG4 16-ch DVR
        /// MPEG4 十六路录像机
        /// </summary>
        NET_DVR_MPEG4_16,							                        
        /// <summary>
        /// LB series DVR
        /// LB系列录像机
        /// </summary>
        NET_DVR_MPEG4_SX2,							                        
        /// <summary>
        /// GB  series DVR
        /// GB系列录像机
        /// </summary>
        NET_DVR_MEPG4_ST2,							                        
        /// <summary>
        /// HB  series DVR
        /// HB系列录像机
        /// </summary>
        NET_DVR_MEPG4_SH2,							                        
        /// <summary>
        /// GBE  series DVR
        /// GBE系列录像机
        /// </summary>
        NET_DVR_MPEG4_GBE,							                        
        /// <summary>
        /// II network video server
        /// II代网络视频服务器
        /// </summary>
        NET_DVR_MPEG4_NVSII,						                        
        /// <summary>
        /// New standard configuration protocol
        /// 新标准配置协议
        /// </summary>
        NET_DVR_STD_NEW,							                        
        /// <summary>
        /// DDNS server
        /// DDNS服务器
        /// </summary>
        NET_DVR_DDNS,								                        
        /// <summary>
        /// ATM series
        /// ATM机
        /// </summary>
        NET_DVR_ATM,								                        
        /// <summary>
        /// 2nd non real-time NB series DVR
        /// 二代非实时NB系列机器
        /// </summary>
        NET_NB_SERIAL,								                        
        /// <summary>
        /// LN  series
        /// LN系列产品
        /// </summary>
        NET_LN_SERIAL,								                        
        /// <summary>
        /// BAV series
        /// BAV系列产品
        /// </summary>
        NET_BAV_SERIAL,								                        
        /// <summary>
        /// SDIP series
        /// SDIP系列产品
        /// </summary>
        NET_SDIP_SERIAL,							                        
        /// <summary>
        /// IPC series
        /// IPC系列产品
        /// </summary>
        NET_IPC_SERIAL,								                        
        /// <summary>
        /// NVS B series
        /// NVS B系列
        /// </summary>
        NET_NVS_B,									                        
        /// <summary>
        /// NVS H series
        /// NVS H系列
        /// </summary>
        NET_NVS_C,									                        
        /// <summary>
        /// NVS S series
        /// NVS S系列
        /// </summary>
        NET_NVS_S,									                       
        /// <summary>
        /// NVS E series
        /// NVS E系列
        /// </summary>
        NET_NVS_E,									                        
        /// <summary>
        /// Search device type from QueryDevState. it is in string format
        /// 从QueryDevState中查询设备类型,以字符串格式
        /// </summary>
        NET_DVR_NEW_PROTOCOL,						                        
        /// <summary>
        /// NVD
        /// 解码器
        /// </summary>
        NET_NVD_SERIAL,								                        
        /// <summary>
        /// N5
        /// N5
        /// </summary>
        NET_DVR_N5,									                        
        /// <summary>
        /// HDVR
        /// 混合DVR
        /// </summary>
        NET_DVR_MIX_DVR,							                        
        /// <summary>
        /// SVR series
        /// SVR系列
        /// </summary>
        NET_SVR_SERIAL,								                        
        /// <summary>
        /// SVR-BS
        /// SVR-BS
        /// </summary>
        NET_SVR_BS,									                        
        /// <summary>
        /// NVR series
        /// NVR系列
        /// </summary>
        NET_NVR_SERIAL,								                       
        /// <summary>
        /// N51
        /// N51
        /// </summary>
        NET_DVR_N51,                                                        
        /// <summary>
        /// ITSE Intelligent Analysis Box
        /// ITSE 智能分析盒
        /// </summary>
        NET_ITSE_SERIAL,							                        
        /// <summary>
        /// Intelligent traffic camera equipment
        /// 智能交通像机设备
        /// </summary>
        NET_ITC_SERIAL,                                                      
        /// <summary>
        /// radar speedometer HWS
        /// 雷达测速仪HWS
        /// </summary>
        NET_HWS_SERIAL,                                                     
        /// <summary>
        /// portable video record
        /// 便携式音视频录像机
        /// </summary>
        NET_PVR_SERIAL,                                                     
        /// <summary>
        /// IVS(intelligent video server series)
        /// IVS（智能视频服务器系列）
        /// </summary>
        NET_IVS_SERIAL,                                                     
        /// <summary>
        /// universal intelligent detect video server series 
        /// 通用智能视频侦测服务器
        /// </summary>
        NET_IVS_B,                                                          
        /// <summary>
        /// face recognisation server
        /// 人脸识别服务器
        /// </summary>
        NET_IVS_F,                                                          
        /// <summary>
        /// video quality diagnosis server
        /// 视频质量诊断服务器
        /// </summary>
        NET_IVS_V,                                                          
        /// <summary>
        /// matrix
        /// 矩阵
        /// </summary>
        NET_MATRIX_SERIAL,							                        
        /// <summary>
        /// N52
        /// N52
        /// </summary>
        NET_DVR_N52,								                        
        /// <summary>
        /// N56
        /// N56
        /// </summary>
        NET_DVR_N56,								                        
        /// <summary>
        /// ESS
        /// ESS
        /// </summary>
        NET_ESS_SERIAL,                                                     
        /// <summary>
        /// 人数统计服务器
        /// </summary>
        NET_IVS_PC,                                                         
        /// <summary>
        /// pc-nvr
        /// pc-nvr
        /// </summary>
        NET_PC_NVR,                                                         
        /// <summary>
        /// screen controller
        /// 大屏控制器
        /// </summary>
        NET_DSCON,									                        
        /// <summary>
        /// network video storage server
        /// 网络视频存储服务器
        /// </summary>
        NET_EVS,									                        
        /// <summary>
        /// an embedded intelligent video analysis system
        /// 嵌入式智能分析视频系统
        /// </summary>
        NET_EIVS,									                        
        /// <summary>
        /// DVR-N6
        /// DVR-N6
        /// </summary>
        NET_DVR_N6,                                                         
        /// <summary>
        /// K-Lite Codec Pack
        /// 万能解码器
        /// </summary>
        NET_UDS,                                                            
        /// <summary>
        /// Bank alarm host
        /// 银行报警主机
        /// </summary>
        NET_AF6016,									                        
        /// <summary>
        /// Video network alarm host
        /// 视频网络报警主机
        /// </summary>
        NET_AS5008,									                        
        /// <summary>
        /// Network alarm host
        /// 网络报警主机
        /// </summary>
        NET_AH2008,									                        
        /// <summary>
        /// Alarm host series
        /// 报警主机系列
        /// </summary>
        NET_A_SERIAL,								                        
        /// <summary>
        /// Access control series of products
        /// 门禁系列产品
        /// </summary>
        NET_BSC_SERIAL,								                        
        /// <summary>
        /// NVS series product
        /// NVS系列产品
        /// </summary>
        NET_NVS_SERIAL,          
        /// <summary>
        /// VTO series product
        /// VTO系列产品
        /// </summary>                           
        NET_VTO_SERIAL,                                                     
        /// <summary>
        /// VTNC series product
        /// VTNC系列产品
        /// </summary>
        NET_VTNC_SERIAL,                                                    
        /// <summary>
        /// TPC series product, it is the thermal device 
        /// TPC系列产品, 即热成像设备
        /// </summary>
        NET_TPC_SERIAL,               				                        
        /// <summary>
        /// ASM series product
        /// 无线中继设备
        /// </summary>
        NET_ASM_SERIAL,                                                     
        /// <summary>
        /// VTS series product
        /// 管理机
        /// </summary>
        NET_VTS_SERIAL,
        /// <summary>
        /// Alarm host-ARC2016C
        /// 报警主机ARC2016C
        /// </summary>
        NET_ARC2016C,                 
        /// <summary>
        /// ASA Attendance machine
        /// 考勤机
        /// </summary>
        NET_ASA,                      
        /// <summary>
        /// Industry terminal walkie-talkie
        /// 行业对讲终端
        /// </summary>
        NET_VTT_SERIAL,				 
        /// <summary>
        /// Alarm column
        /// 报警柱
        /// </summary>
        NET_VTA_SERIAL,				  
        /// <summary>
        /// SIP Server
        /// SIP服务器
        /// </summary>
        NET_VTNS_SERIAL,			  
        /// <summary>
        /// Indoor unit
        /// 室内机
        /// </summary>
        NET_VTH_SERIAL,				                                   
    }

    /// <summary>
    /// login device mode enumeration
    /// 登陆设备方式枚举
    /// </summary>
    public enum EM_LOGIN_SPAC_CAP_TYPE
    {
        /// <summary>
        /// TCP login, default
        /// TCP登陆, 默认方式
        /// </summary>
        TCP                 = 0,                                            
        /// <summary>
        /// No criteria login
        /// 无条件登陆
        /// </summary>
        ANY                 = 1,                                           
        /// <summary>
        /// auto sign up login
        /// 主动注册的登入
        /// </summary>
        SERVER_CONN         = 2,                                            
        /// <summary>
        /// multicast login, default
        /// 组播登陆
        /// </summary>
        MULTICAST           = 3,                                            
        /// <summary>
        /// UDP method login
        /// UDP方式下的登入
        /// </summary>
        UDP                 = 4,                                            
        /// <summary>
        /// only main connection login
        /// 只建主连接下的登入
        /// </summary>
        MAIN_CONN_ONLY      = 6,                                            
        /// <summary>
        /// SSL encryption login
        /// SSL加密方式登陆
        /// </summary>
        SSL                 = 7,                                            
        /// <summary>
        /// login IVS box remote device
        /// 登录智能盒远程设备
        /// </summary>
        INTELLIGENT_BOX     = 9,                                            
        /// <summary>
        /// login device do not config
        /// 登录设备后不做取配置操作
        /// </summary>
        NO_CONFIG           = 10,                                           
        /// <summary>
        /// USB key device login
        /// 用U盾设备的登入
        /// </summary>
        U_LOGIN             = 11,                                           
        /// <summary>
        /// LDAP login
        /// LDAP方式登录
        /// </summary>
        LDAP                = 12,                                           
        /// <summary>
        /// AD login
        /// AD（ActiveDirectory）登录方式
        /// </summary>
        AD                  = 13,                                           
        /// <summary>
        /// Radius  login 
        /// Radius 登录方式
        /// </summary>
        RADIUS              = 14,                                           
        /// <summary>
        /// Socks5 login
        /// Socks5登陆方式
        /// </summary>
        SOCKET_5            = 15,                                           
        /// <summary>
        /// cloud login
        /// 云登陆方式
        /// </summary>
        CLOUD               = 16,                                           
        /// <summary>
        /// dual authentication loin
        /// 二次鉴权登陆方式
        /// </summary>
        AUTH_TWICE          = 17,                                           
        /// <summary>
        /// TS stream client login
        /// TS码流客户端登陆方式
        /// </summary>
        TS                  = 18,                                           
        /// <summary>
        /// web private login
        /// 为P2P登陆方式
        /// </summary>
        P2P                 = 19,                                           
        /// <summary>
        /// mobile client login
        /// 手机客户端登陆
        /// </summary>
        MOBILE              = 20,                  
        /// <summary>
        /// invalid login
        /// 无效的登陆方式
        /// </summary>          
        INVALID             = 21,                                           
    }

    /// <summary>
    /// the corresponding parameter when setting log in structure
    /// 设置登入时的相关参数
    /// </summary>
    public struct NET_PARAM
    {
        /// <summary>
        /// Waiting time(unit is ms), 0:default 5000ms.
        /// 等待超时时间(毫秒为单位),为0默认5000ms
        /// </summary>
	    public int					nWaittime;				                
        /// <summary>
        /// Connection timeout value(Unit is ms), 0:default 1500ms.
        /// 连接超时时间(毫秒为单位),为0默认1500ms
        /// </summary>
        public int                  nConnectTime;			                
        /// <summary>
        /// Connection trial times, 0:default 1.
        /// 连接尝试次数,为0默认1次
        /// </summary>
        public int                  nConnectTryNum;			                
        /// <summary>
        /// Sub-connection waiting time(Unit is ms), 0:default 10ms.
        /// 子连接之间的等待时间(毫秒为单位),为0默认10ms
        /// </summary>
        public int                  nSubConnectSpaceTime;	                
        /// <summary>
        /// Access to device information timeout, 0:default 1000ms.
        /// 获取设备信息超时时间,为0默认1000ms
        /// </summary>
        public int                  nGetDevInfoTime;		                
        /// <summary>
        /// Each connected to receive data buffer size(Bytes), 0:default 250*1024
        /// 每个连接接收数据缓冲大小(字节为单位),为0默认250*1024
        /// </summary>
        public int                  nConnectBufSize;		                
        /// <summary>
        /// Access to sub-connect information timeout(Unit is ms), 0:default 1000ms.
        /// 获取子连接信息超时时间(毫秒为单位),为0默认1000ms
        /// </summary>
        public int                  nGetConnInfoTime;		                
        /// <summary>
        /// Timeout value of search video (unit ms), default 3000ms
        /// 按时间查询录像文件的超时时间(毫秒为单位),为0默认为3000ms
        /// </summary>
        public int                  nSearchRecordTime;                      
        /// <summary>
        /// dislink disconnect time,0:default 60000ms
        /// 检测子链接断线等待时间(毫秒为单位),为0默认为60000ms
        /// </summary>
        public int                  nsubDisconnetTime;                      
        /// <summary>
        /// net type, 0-LAN, 1-WAN
        /// 网络类型, 0-LAN, 1-WAN
        /// </summary>
        public byte                 byNetType;				                
        /// <summary>
        /// playback data from the receive buffer size(m),when value = 0,default 4M
        /// 回放数据接收缓冲大小（M为单位）,为0默认为4M
        /// </summary>
        public byte                 byPlaybackBufSize;                      
        /// <summary>
        /// Pulse detect offline time(second) .When it is 0, the default setup is 60s, and the min time is 2s 
        /// 心跳检测断线时间(单位为秒),为0默认为60s,最小时间为2s
        /// </summary>
        public byte                 bDetectDisconnTime;                     
        /// <summary>
        /// Pulse send out interval(second). When it is 0, the default setup is 10s, the min internal is 2s.
        /// 心跳包发送间隔(单位为秒),为0默认为10s,最小间隔为2s
        /// </summary>
        public byte                 bKeepLifeInterval;                      
        /// <summary>
        /// actual pictures of the receive buffer size(byte)when value = 0,default 2*1024*1024
        /// 实时图片接收缓冲大小（字节为单位）,为0默认为2*1024*1024
        /// </summary>
        public int                  nPicBufSize;         
        /// <summary>
        /// reserved
        /// 保留
        /// </summary>    
        [MarshalAs(UnmanagedType.ByValArray,SizeConst = 4)]
	    public byte[]				bReserved;			                    
    }

    /// <summary>
    /// snapshot parameter structure
    /// 抓图参数结构体
    /// </summary>
    public struct NET_SNAP_PARAMS
    {
        /// <summary>
        /// Snapshot channel
        /// 抓图的通道
        /// </summary>
        public uint Channel;				                                
        /// <summary>
        /// Image quality:level 1 to level 6
        /// 画质；1~6
        /// </summary>
        public uint Quality;				                                
        /// <summary>
        /// Video size;0:QCIF,1:CIF,2:D1
        /// 画面大小；0：QCIF,1：CIF,2：D1
        /// </summary>
        public uint ImageSize;				                                
        /// <summary>
        /// Snapshot mode;0:request one frame,1:send out requestion regularly,2: Request consecutively
        /// 抓图模式；-1:表示停止抓图, 0：表示请求一帧, 1：表示定时发送请求, 2：表示连续请求
        /// </summary>
        public uint mode;					                                
        /// <summary>
        /// Time unit is second.If mode=1, it means send out requestion regularly. The time is valid.
        /// 时间单位秒；若mode=1表示定时发送请求时只有部分特殊设备(如：车载设备)支持通过该字段实现定时抓图时间间隔的配置建议通过 CFG_CMD_ENCODE 配置的stuSnapFormat[nSnapMode].stuVideoFormat.nFrameRate字段实现相关功能
        /// </summary>
        public uint InterSnap;				                                
        /// <summary>
        /// Request serial number
        /// 请求序列号，有效值范围 0~65535，超过范围会被截断为 unsigned short
        /// </summary>
        public uint CmdSerial;				                                
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public uint[] Reserved;
    }

    /// <summary>
    /// real data flag, corresponding param dwFlag in SetRealDataCallBack.supports '|' operator, like dwFlag = EM_REALDATA_FLAG.RAW_DATA | EM_REALDATA_FLAG.YUV_DATA
    /// 实时监视的实时数据标志, 对应 SetRealDataCallBack 中的 dwFlag 参数,支持 '|' 运算符, 如 dwFlag = EM_REALDATA_FLAG.RAW_DATA | EM_REALDATA_FLAG.YUV_DATA
    /// </summary>
    [Flags]
    public enum EM_REALDATA_FLAG
    {
        /// <summary>
        /// raw data flag,		corresponding param dwDataType in fRealDataCallBackEx / fRealDataCallBackEx2 is 0, 0x01 = 0x01 << 0
        /// 原始数据标志,			对应fRealDataCallBack(Ex/Ex2)回调函数中 dwDataType 为0, 0x01 = 0x01 << 0
        /// </summary>
        RAW_DATA = 0x01,	                        
        /// <summary>
        /// data with frame info flag,	corresponding param dwDataType in fRealDataCallBackEx / fRealDataCallBackEx2 is 1, 0x02 = 0x01 << 1
        /// 带有帧信息的数据标志,	对应fRealDataCallBack(Ex/Ex2)回调函数中 dwDataType 为1, 0x02 = 0x01 << 1
        /// </summary>
        DATA_WITH_FRAME_INFO = 0x02,	                
        /// <summary>
        /// YUV data flag,		corresponding param dwDataType in fRealDataCallBackEx / fRealDataCallBackEx2 is 2, 0x04 = 0x01 << 2
        /// YUV 数据标志,			对应fRealDataCallBack(Ex/Ex2)回调函数中 dwDataType 为2, 0x04 = 0x01 << 2
        /// </summary>
        YUV_DATA = 0x04,	                
        /// <summary>
        /// PCM audio data flag,	corresponding param dwDataType in fRealDataCallBackEx / fRealDataCallBackEx2 is 3, 0x08 = 0x01 << 3
        /// PCM 音频数据标志,		对应fRealDataCallBack(Ex/Ex2)回调函数中 dwDataType 为3, 0x08 = 0x01 << 3
        /// </summary>
        PCM_AUDIO_DATA = 0x08,	        
    }

    /// <summary>
    /// SnapPictureToFile function input parameter
    /// SnapPictureToFile函数输入参数
    /// </summary>
    public struct NET_IN_SNAP_PIC_TO_FILE_PARAM 
    {
        /// <summary>
        /// structure size
        /// 结构体大小
        /// </summary>
        public uint             dwSize;
        /// <summary>
        /// snapshot parameter, mode field is only snapshot for once, fail to support timed or continuous snapshot; except mobile DVR, other devices only support snapshot frequency of one snapshot per second
        /// 抓图参数, 其中mode字段仅一次性抓图, 不支持定时或持续抓图; 除了车载DVR, 其他设备仅支持每秒一张的抓图频率
        /// </summary>
        public NET_SNAP_PARAMS  stuParam;                                    
        /// <summary>
        /// write in file address
        /// 写入文件的地址
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string           szFilePath;                                  
    }

    /// <summary>
    /// SnapPictureToFile function output parameter 
    /// SnapPictureToFile函数输出参数
    /// </summary>
    public struct NET_OUT_SNAP_PIC_TO_FILE_PARAM 
    {
        /// <summary>
        /// structure size
        /// 结构体大小
        /// </summary>
        public uint         dwSize;
        /// <summary>
        /// picture content, user memory allocation, memory size is dwPicBufLen
        /// 图片内容,用户分配内存,大小为dwPicBufLen
        /// </summary>
        public IntPtr       szPicBuf;                                       
        /// <summary>
        /// picture content memory size, unit: byte
        /// 图片内容内存大小, 单位:字节
        /// </summary>
        public uint         dwPicBufLen;                                    
        /// <summary>
        /// returned picture size, unit:byte
        /// 返回的图片大小, 单位:字节
        /// </summary>
        public uint         dwPicBufRetLen;                                  
    }

    /// <summary>
    /// realplay type
    /// 监视类型
    /// </summary>
	public enum EM_RealPlayType
    {
        /// <summary>
        /// Real-time preview
        /// 实时预览
        /// </summary>
        Realplay = 0,						                                
        /// <summary>
        /// Multiple-channel preview 
        /// 多画面预览
        /// </summary>
        Multiplay,							                                
        /// <summary>
        /// Real-time monitor-main stream. It is the same as EM_RealPlayType.Realplay
        /// 实时监视-主码流,等同于EM_RealPlayType.Realplay
        /// </summary>
        Realplay_0,				    		                                
        /// <summary>
        /// Real-time monitor -- extra stream 1
        /// 实时监视-从码流1
        /// </summary>
        Realplay_1,					    	                                
        /// <summary>
        /// Real-time monitor -- extra stream 2
        /// 实时监视-从码流2
        /// </summary>
        Realplay_2,					    	                                
        /// <summary>
        /// Real-time monitor -- extra stream 3
        /// 实时监视-从码流3
        /// </summary>
        Realplay_3,					    	                                
        /// <summary>
        /// Multiple-channel preview--1-window 
        /// 多画面预览－1画面
        /// </summary>
        Multiplay_1,						                                
        /// <summary>
        /// Multiple-channel preview--4-window
        /// 多画面预览－4画面
        /// </summary>
        Multiplay_4,						                               
        /// <summary>
        /// Multiple-channel preview--8-window
        /// 多画面预览－8画面
        /// </summary>
        Multiplay_8,						                                
        /// <summary>
        /// Multiple-channel preview--9-window
        /// 多画面预览－9画面
        /// </summary>
        Multiplay_9,						                                
        /// <summary>
        /// Multiple-channel preview--16-window
        /// 多画面预览－16画面
        /// </summary>
        Multiplay_16,						                                
        /// <summary>
        /// Multiple-channel preview--6-window
        /// 多画面预览－6画面
        /// </summary>
        Multiplay_6,						                                
        /// <summary>
        /// Multiple-channel preview--12-window
        /// 多画面预览－12画面
        /// </summary>
        Multiplay_12,						                                
        /// <summary>
        /// Multiple-channel preview--25-window
        /// 多画面预览－25画面
        /// </summary>
        Multiplay_25,                                                     
        /// <summary>
        /// Multiple-channel preview--36-window
        /// 多画面预览－36画面
        /// </summary>
        Multiplay_36,
        /// <summary>
        /// test stream
        /// 带宽测试码流 
        /// </summary>
        Realplay_Test = 255,                                                    
    }

    /// <summary>
    /// realplay disconnnect event
    /// 监视断线类型
    /// </summary>
    public enum EM_REALPLAY_DISCONNECT_EVENT_TYPE
    {
        /// <summary>
        /// resources is taked by advanced user
        /// 表示高级用户抢占低级用户资源
        /// </summary>
        REAVE,                                                              
        /// <summary>
        /// forbidden
        /// 禁止入网
        /// </summary>
        NETFORBID,                                                          
        /// <summary>
        /// sublink disconnect
        /// 子链接断线
        /// </summary>
        SUBCONNECT,                                                         
    }

    /// <summary>
    /// absolute control PTZ corresponding structure
    /// 绝对控制云台对应结构
    /// </summary>
    public struct NET_PTZ_CONTROL_ABSOLUTELY
    {
        /// <summary>
        /// PTZ Absolute Speed
        /// 云台绝对移动位置
        /// </summary>
        public NET_PTZ_SPACE_UNIT       stuPosition;                        
        /// <summary>
        /// PTZ Operation Speed
        /// 云台运行速度
        /// </summary>
        public NET_PTZ_SPEED_UNIT       stuSpeed;                          
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public  byte[]                  szReserve;                          
    }

    /// <summary>
    /// continuous control PTZ corresponding structure
    /// 云台控制坐标单元
    /// </summary>
    public struct NET_PTZ_SPEED_UNIT
    {
        /// <summary>
        /// PTZ horizontal speed, normalized to -1~1
        /// 云台水平方向速率,归一化到-1~1
        /// </summary>
        public float                    fPositionX;                         
        /// <summary>
        /// PTZ vertical speed, normalized to -1~1 
        /// 云台垂直方向速率,归一化到-1~1
        /// </summary>
        public float                    fPositionY;                        
        /// <summary>
        /// PTZ aperture magnification, normalized to 0~1 
        /// 云台光圈放大倍率,归一化到 0~1
        /// </summary>
        public float                    fZoom;                             
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[]                   szReserve;                          
    }

    /// <summary>
    /// PTZ control coordinate unit structure
    /// 云台控制坐标单元
    /// </summary>
    public struct NET_PTZ_SPACE_UNIT
    {
        /// <summary>
        /// PTZ horizontal motion position, effective range[0,3600]
        /// 云台水平运动位置,有效范围：[0,3600]
        /// </summary>
        public int                      nPositionX;                        
        /// <summary>
        /// PTZ vertical motion position, effective range[-1800,1800]
        /// 云台垂直运动位置,有效范围：[-1800,1800]
        /// </summary>
        public int                      nPositionY;                        
        /// <summary>
        /// PTZ aperture change position, the effective range[0,128]
        /// 云台光圈变动位置,有效范围：[0,128]
        /// </summary>
        public int                      nZoom;                             
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[]                   szReserve;                         
    }

    /// <summary>
    /// continuous control PTZ corresponding structure
    /// 持续控制云台对应结构
    /// </summary>
    public struct NET_PTZ_CONTROL_CONTINUOUSLY
    {
        /// <summary>
        /// PTZ speed
        /// 云台运行速度
        /// </summary>
        public NET_PTZ_SPEED_UNIT       stuSpeed;                          
        /// <summary>
        /// Continuous motion timeout, the unit is in seconds 
        /// 连续移动超时时间,单位为秒
        /// </summary>
        public int                      nTimeOut;                          
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[]                   szReserve;                         
    }

    /// <summary>
    /// with speed rotation site PTZ control corresponding to the preset structure
    /// 带速度转动到预置位点云台控制对应结构
    /// </summary>
    public struct NET_PTZ_CONTROL_GOTOPRESET
    {
        /// <summary>
        /// Preset BIT Index 
        /// 预置位索引
        /// </summary>
        public int                      nPresetIndex;                     
        /// <summary>
        /// PTZ Operation Speed
        /// 云台运行速度
        /// </summary>
        public NET_PTZ_SPEED_UNIT       stuSpeed;                         
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[]                   szReserve;                        
    }

    /// <summary>
    /// set the PTZ vision information structure
    /// 设置云台可视域信息
    /// </summary>
    public struct NET_PTZ_VIEW_RANGE_INFO
    {
        /// <summary>
        /// current struct size
        /// 结构体大小
        /// </summary>
        public int                      nStructSize;                      
        /// <summary>
        /// Horizontal azimuth Angle, 0~3600, unit: degrees 
        /// 水平方位角度, 0~3600, 单位:度
        /// </summary>
        public int                      nAzimuthH;                        
    }

    /// <summary>
    /// PTZ absolute focus corresponding structure
    /// 云台绝对聚焦对应结构体
    /// </summary>
    public struct NET_PTZ_FOCUS_ABSOLUTELY
    {
        /// <summary>
        /// PTZ Focused On Location, range (0~8191)
        /// 云台聚焦位置,取值范围(0~8191)
        /// </summary>
        public uint                     dwValue;                          
        /// <summary>
        /// PTZ Focused On Speed, the scope (0~7)
        /// 云台聚焦速度,取值范围(0~7)
        /// </summary>
        public uint                     dwSpeed;                          
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[]                   szReserve;                        
    }

    /// <summary>
    /// PTZ control - fan and corresponding structure
    /// 云台控制-扇扫对应结构
    /// </summary>
    public struct NET_PTZ_CONTROL_SECTORSCAN
    {
        /// <summary>
        /// Staring Angle,Range:[-180,180]
        /// 起始角度,范围:[-180,180]
        /// </summary>
        public int                      nBeginAngle;                     
        /// <summary>
        /// Ending Angle,Range:[-180,180]
        /// 结束角度,范围:[-180,180]
        /// </summary>
        public int                      nEndAngle;                       
        /// <summary>
        /// Speed,Range:[0,255]
        /// 速度,范围:[0,255]
        /// </summary>
        public int                      nSpeed;                          
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[]                   szReserve;                       
    }

    /// <summary>
    /// control Fish eye E-PTZ information structure 
    /// 控制鱼眼电子云台信息
    /// </summary>
    public struct NET_PTZ_CONTROL_SET_FISHEYE_EPTZ
    {
        /// <summary>
        /// structure size
        /// 结构体大小
        /// </summary>
        public uint                     dwSize;	                            
        /// <summary>
        /// EPtz control window no
        /// 进行EPtz控制的窗口编号
        /// </summary>
        public uint                     dwWindowID;                         
        /// <summary>
        /// E-PTZ command
        /// 电子云台命令
        /// </summary>
        public uint                     dwCommand;                          
        /// <summary>
        /// command corresponding to parameter 1
        /// 命令对应参数1
        /// </summary>
        public uint                     dwParam1;                           
        /// <summary>
        /// command corresponding to  parameter 2
        /// 命令对应参数2
        /// </summary>
        public uint                     dwParam2;                           
        /// <summary>
        /// command corresponding to  parameter 3
        /// 命令对应参数3
        /// </summary>
        public uint                     dwParam3;                           
        /// <summary>
        /// command corresponding to  parameter 4
        /// 命令对应参数4
        /// </summary>
        public uint                     dwParam4;                           
    }

    /// <summary>
    /// track control command enumeration
    /// 轨道机控制命令
    /// </summary>
    public enum EM_NET_TRACK_CONTROL_CMD
    {
        /// <summary>
        /// Move up, dwParam1 means step length range 1-8
        /// 向上移动,dwParam1表示步长,范围1～8
        /// </summary>
        UP,                                                                
        /// <summary>
        /// Move down, dwParam1 means step length  range 1-8
        /// 向下移动,dwParam1表示步长,范围1～8
        /// </summary>
        DOWN,                                                              
        /// <summary>
        /// Move left, dwParam1 means step length  range 1-8
        /// 向左移动,dwParam1表示步长,范围1～8
        /// </summary>
        LEFT,                                                              
        /// <summary>
        /// Move right, dwParam1 means step length  range 1-8
        /// 向右移动,dwParam1表示步长,范围1～8
        /// </summary>
        RIGHT,                                                             
        /// <summary>
        /// Set preset，dwParam1 means preset value
        /// 设置预置点,dwParam1表示预置点值
        /// </summary>
        SETPRESET,                                                         
        /// <summary>
        /// Clear preset，dwParam1 means preset value
        /// 清除预置点,dwParam1表示预置点值
        /// </summary>
        CLEARPRESET,                                                       
        /// <summary>
        /// Goto preset，dwParam1 means preset value
        /// 转至预置点,dwParam1表示预置点值
        /// </summary>
        GOTOPRESET,                                                        
    }

    /// <summary>
    /// track control information structure
    /// 轨道机控制信息
    /// </summary>
    public struct NET_PTZ_CONTROL_SET_TRACK_CONTROL
    {
        /// <summary>
        /// dwSize need to be assigned sizeof(NET_PTZ_CONTROL_SET_TRACK_CONTROL)
        /// 用户使用该结构体时,dwSize 需赋值为 sizeof(NET_PTZ_CONTROL_SET_TRACK_CONTROL)
        /// </summary>
        public uint                     dwSize;                            
        /// <summary>
        /// channel number
        /// 通道号
        /// </summary>
        public uint                     dwChannelID;                       
        /// <summary>
        /// Control command，corresponding to enum EM_NET_TRACK_CONTROL_CMD
        /// 电子云台命令,对应枚举EM_NET_TRACK_CONTROL_CMD
        /// </summary>
        public uint                     dwCommand;                         
        /// <summary>
        /// command corresponding to parameter 1
        /// 命令对应参数1
        /// </summary>
        public uint                     dwParam1;                          
        /// <summary>
        /// command corresponding to parameter 2
        /// 命令对应参数2
        /// </summary>
        public uint                     dwParam2;                          
        /// <summary>
        /// command corresponding to parameter 3
        /// 命令对应参数3
        /// </summary>
        public uint                     dwParam3;                          
    } 

    /// <summary>
    /// PTZ control command enumeration
    /// 云台控制命令
    /// </summary>
    public enum EM_EXTPTZ_ControlType:uint
    {
        /// <summary>
        /// Up
        /// 上
        /// </summary>
        UP_CONTROL                  = 0,                                    
        /// <summary>
        /// Down
        /// 下
        /// </summary>
        DOWN_CONTROL,                                                       
        /// <summary>
        /// Left
        /// 左
        /// </summary>
        LEFT_CONTROL,                                                     
        /// <summary>
        /// Right
        /// 右
        /// </summary>
        RIGHT_CONTROL,                                                    
        /// <summary>
        /// +Zoom in 
        /// 变倍+
        /// </summary>
        ZOOM_ADD_CONTROL,                                                 
        /// <summary>
        /// -Zoom out
        /// 变倍-
        /// </summary>
        ZOOM_DEC_CONTROL,                                                 
        /// <summary>
        /// +Focus 
        /// 调焦+
        /// </summary>
        FOCUS_ADD_CONTROL,                                                
        /// <summary>
        /// -Focus
        /// 调焦-
        /// </summary>
        FOCUS_DEC_CONTROL,                                                 
        /// <summary>
        /// + Aperture 
        /// 光圈+
        /// </summary>
        APERTURE_ADD_CONTROL,                                              
        /// <summary>
        /// -Aperture
        /// 光圈-
        /// </summary>
        APERTURE_DEC_CONTROL,                                              
        /// <summary>
        /// Go to preset 
        /// 转至预置点
        /// </summary>
        POINT_MOVE_CONTROL,                                                
        /// <summary>
        /// Set
        /// 设置
        /// </summary>
        POINT_SET_CONTROL,                                                 
        /// <summary>
        /// Delete
        /// 删除
        /// </summary>
        POINT_DEL_CONTROL,                                                 
        /// <summary>
        /// Tour
        /// 点间巡航
        /// </summary>
        POINT_LOOP_CONTROL,                                                
        /// <summary>
        /// Light and wiper 
        /// 灯光雨刷
        /// </summary>
        LAMP_CONTROL,                                                      
        /// <summary>
        /// Upper left
        /// 左上
        /// </summary>
        LEFTTOP                     = 0x20,				                   
        /// <summary>
        /// Upper right
        /// 右上
        /// </summary>
        RIGHTTOP,						                                   
        /// <summary>
        /// Down left
        /// 左下
        /// </summary>
        LEFTDOWN,						                                   
        /// <summary>
        /// Down right 
        /// 右下
        /// </summary>
        RIGHTDOWN,						                                   
        /// <summary>
        ///  Add preset to tour	tour preset value
        /// 加入预置点到巡航 巡航线路 预置点值
        /// </summary>
        ADDTOLOOP,						                                   
        /// <summary>
        /// Delete preset in tour tour preset value
        /// 删除巡航中预置点 巡航线路 预置点值
        /// </summary>
        DELFROMLOOP,					                                   
        /// <summary>
        /// Delete tour tour
        /// 清除巡航 巡航线路
        /// </summary>
        CLOSELOOP,						                                   
        /// <summary>
        /// Begin pan rotation
        /// 开始水平旋转
        /// </summary>
        STARTPANCRUISE,					                                   
        /// <summary>
        /// Stop pan rotation
        /// 停止水平旋转
        /// </summary>
        STOPPANCRUISE,					                                   
        /// <summary>
        /// Set left limit
        /// 设置左边界
        /// </summary>
        SETLEFTBORDER,					                                   
        /// <summary>
        /// Set right limit
        /// 设置右边界
        /// </summary>
        SETRIGHTBORDER,					                                   
        /// <summary>
        /// Begin scanning	
        /// 开始线扫
        /// </summary>
        STARTLINESCAN,					                                   
	    /// <summary>
        /// Stop scanning
        /// 停止线扫
	    /// </summary>
        CLOSELINESCAN,					                                   
        /// <summary>
        /// Start mode	mode line	
        /// 设置模式开始    模式线路
        /// </summary>
        SETMODESTART,					                                   
	    /// <summary>
        /// Stop mode	mode line	
        /// 设置模式结束    模式线路
	    /// </summary>
        SETMODESTOP,					                                   
	    /// <summary>
        /// Enable mode	Mode line
        /// 运行模式    模式线路
	    /// </summary>
        RUNMODE,						                                   
        /// <summary>
        /// Disable mode	Mode line
        /// 停止模式    模式线路
        /// </summary>
        STOPMODE,						                                   
        /// <summary>
        /// Delete mode	Mode line
        /// 清除模式    模式线路
        /// </summary>
        DELETEMODE,						                                   
        /// <summary>
        /// Flip
        /// 翻转命令
        /// </summary>
        REVERSECOMM,					                                   
        /// <summary>
        /// 3D position	X address(8192)	Y address(8192)	zoom(4)
        /// 快速定位 水平坐标(8192) 垂直坐标(8192) 变倍(4)
        /// </summary>
        FASTGOTO,						                                   
        /// <summary>
        /// auxiliary open	Auxiliary point(param4 corresponding struct PTZ_CONTROL_AUXILIARY,param1、param2、param3 is invalid,dwStop set to FALSE)
        /// 辅助开关开 辅助点(param4对应 PTZ_CONTROL_AUXILIARY,param1、param2、param3无效,dwStop设置为FALSE)
        /// </summary>
        AUXIOPEN,						                                   
        /// <summary>
        /// Auxiliary close	Auxiliary point(param4 corresponding struct PTZ_CONTROL_AUXILIARY,param1、param2、param3 is invalid,dwStop set to FALSE)
        /// 辅助开关关 辅助点(param4对应 PTZ_CONTROL_AUXILIARY,param1、param2、param3无效,dwStop设置为FALSE)
        /// </summary>
        AUXICLOSE,						                                   
        /// <summary>
        /// Open dome menu 
        /// 打开球机菜单
        /// </summary>
        OPENMENU                    = 0x36,				                   
        /// <summary>
        /// Close menu 
        /// 关闭菜单
        /// </summary>
        CLOSEMENU,						                                   
        /// <summary>
        /// Confirm menu 
        /// 菜单确定
        /// </summary>
        MENUOK,							                                   
        /// <summary>
        /// Cancel menu 
        /// 菜单取消
        /// </summary>
        MENUCANCEL,						                                   
        /// <summary>
        /// menu up 
        /// 菜单上
        /// </summary>
        MENUUP,							                                   
        /// <summary>
        /// menu down
        /// 菜单下
        /// </summary>
        MENUDOWN,						                                   
        /// <summary>
        /// menu left
        /// 菜单左
        /// </summary>
        MENULEFT,						                                   
        /// <summary>
        /// Menu right
        /// 菜单右
        /// </summary>
        MENURIGHT,						                                   
        /// <summary>
        /// Alarm activate PTZ parm1:Alarm input channel;parm2:Alarm activation type  1-preset 2-scan 3-tour;parm 3:activation value,such as preset value.
        /// 报警联动云台 parm1：报警输入通道；parm2：报警联动类型1-预置点2-线扫3-巡航；parm3：联动值,如预置点号
        /// </summary>
        ALARMHANDLE                 = 0x40,				                     
        /// <summary>
        /// Matrix switch parm1:monitor number(video output number);parm2:video input number;parm3:matrix number 
        /// 矩阵切换 parm1：监视器号(视频输出号)；parm2：视频输入号；parm3：矩阵号
        /// </summary>
        MATRIXSWITCH                = 0x41,			                        
        /// <summary>
        /// Light controller
        /// 灯光控制器
        /// </summary>
        LIGHTCONTROL,					                                    
        /// <summary>
        /// 3D accurately positioning parm1:Pan degree(0~3600); parm2: tilt coordinates(0~900); parm3:zoom(1~128)
        /// 三维精确定位 parm1：水平角度(0~3600)；parm2：垂直坐标(0~900)；parm3：变倍(1~128)
        /// </summary>
        EXACTGOTO,						                                    
        /// <summary>
        /// Reset  3D positioning as zero 
        /// 三维定位重设零位
        /// </summary>
        RESETZERO,                                                          
        /// <summary>
        /// Absolute motion control command,param4 corresponding struct NET_PTZ_CONTROL_ABSOLUTELY
        /// 绝对移动控制命令,param4对应结构 NET_PTZ_CONTROL_ABSOLUTELY
        /// </summary>
        MOVE_ABSOLUTELY,                                                    
        /// <summary>
        /// Continuous motion control command,param4 corresponding struct NET_PTZ_CONTROL_CONTINUOUSLY
        /// 持续移动控制命令,param4对应结构 NET_PTZ_CONTROL_CONTINUOUSLY
        /// </summary>
        MOVE_CONTINUOUSLY,                                                 
        /// <summary>
        /// PTZ control command, at a certain speed to preset locu,parm4 corresponding struct NET_PTZ_CONTROL_GOTOPRESET
        /// 云台控制命令,以一定速度转到预置位点,parm4对应结构NET_PTZ_CONTROL_GOTOPRESET
        /// </summary>
        GOTOPRESET,                                                         
        /// <summary>
        /// Set to horizon(param4 corresponding struct NET_PTZ_VIEW_RANGE_INFO)
        /// 设置可视域(param4对应结构 NET_PTZ_VIEW_RANGE_INFO)
        /// </summary>
        SET_VIEW_RANGE              = 0x49,                                 
        /// <summary>
        /// Absolute focus(param4 corresponding struct NET_PTZ_FOCUS_ABSOLUTELY)
        /// 绝对聚焦(param4对应结构NET_PTZ_FOCUS_ABSOLUTELY)
        /// </summary>
        FOCUS_ABSOLUTELY            = 0x4A,                                
        /// <summary>
        /// Level fan sweep(param4 corresponding NET_PTZ_CONTROL_SECTORSCAN,param1,param2,param3 is invalid)
        /// 水平扇扫(param4对应PTZ_CONTROL_SECTORSCAN,param1、param2、param3无效)
        /// </summary>
        HORSECTORSCAN               = 0x4B,                                 
        /// <summary>
        /// Vertical sweep fan(param4 corresponding NET_PTZ_CONTROL_SECTORSCAN,param1,param2,param3 is invalid)
        /// 垂直扇扫(param4对应PTZ_CONTROL_SECTORSCAN,param1、param2、param3无效)
        /// </summary>
        VERSECTORSCAN               = 0x4C,                                 
        /// <summary>
        /// Set absolute focus, focus on value, param1 for focal length, range: [0255], param2 as the focus, scope: [0255], param3, param4 is invalid
        /// 设定绝对焦距、聚焦值,param1为焦距,范围:[0,255],param2为聚焦,范围:[0,255],param3、param4无效
        /// </summary>
        SET_ABS_ZOOMFOCUS           = 0x4D,                                 
        /// <summary>
        /// Control fish eye PTZ,param4corresponding to structure NET_PTZ_CONTROL_SET_FISHEYE_EPTZ  
        /// 控制鱼眼电子云台,param4对应结构 PTZ_CONTROL_SET_FISHEYE_EPTZ
        /// </summary>
        SET_FISHEYE_EPTZ            = 0x4E,                                 
        /// <summary>
        /// Track start control(param4 corresponding to structure  NET_PTZ_CONTROL_SET_TRACK_CONTROL,dwStop set as FALSE， param1、param2、param3 is invalid)
        /// 轨道机开始控制(param4对应结构体为 PTZ_CONTROL_SET_TRACK_CONTROL,dwStop传FALSE, param1、param2、param3无效)
        /// </summary>
        SET_TRACK_START             = 0x4F,                                 
        /// <summary>
        /// Track stop control (param4 corresponding to structure NET_PTZ_CONTROL_SET_TRACK_CONTROL,dwStop set as FALSE，param1、param2、param3  is invalid)
        /// 轨道机停止控制(param4对应结构体为 PTZ_CONTROL_SET_TRACK_CONTROL,dwStop传FALSE,param1、param2、param3无效)
        /// </summary>
        SET_TRACK_STOP              = 0x50,                                
        /// <summary>
        /// Up + TELE param1=speed (1-8) 
        /// 上 + TELE param1=速度(1-8),下同
        /// </summary>                                                     
        UP_TELE                     = 0x70,				                   
        /// <summary>
        /// Down + TELE
        /// 下 + TELE
        /// </summary>
        DOWN_TELE,						                                   
        /// <summary>
        /// Left + TELE
        /// 左 + TELE
        /// </summary>
        LEFT_TELE,						                                   
        /// <summary>
        /// Right + TELE
        /// 右 + TELE
        /// </summary>
        RIGHT_TELE,						                                   
        /// <summary>
        /// Upper left + TELE
        /// 左上 + TELE
        /// </summary>
        LEFTUP_TELE,					                                   
        /// <summary>
        /// Down left + TELE
        /// 左下 + TELE
        /// </summary>
        LEFTDOWN_TELE,					                                   
        /// <summary>
        /// Upper right + TELE
        /// 右上 + TELE
        /// </summary>
        TIGHTUP_TELE,					                                   
        /// <summary>
        /// Down right + TELE
        /// 右下 + TELE
        /// </summary>
        RIGHTDOWN_TELE,					                                   
        /// <summary>
        /// Up + WIDE param1=speed (1-8) 
        /// 上 + WIDE param1=速度(1-8),下同
        /// </summary>
        UP_WIDE,						                                   
        /// <summary>
        /// Down + WIDE
        /// 下 + WIDE
        /// </summary>
        DOWN_WIDE,						                                   
        /// <summary>
        /// Left + WIDE
        /// 左 + WIDE
        /// </summary>
        LEFT_WIDE,						                                   
        /// <summary>
        /// Right + WIDE
        /// 右 + WIDE
        /// </summary>
        RIGHT_WIDE,						                                   
        /// <summary>
        /// Upper left + WIDE
        /// 左上 + WIDE
        /// </summary>
        LEFTUP_WIDE,					                                   
        /// <summary>
        /// Down left+ WIDE
        /// 左下 + WIDE
        /// </summary>
        LEFTDOWN_WIDE,					                                   
        /// <summary>
        /// Upper right + WIDE
        /// 右上 + WIDE
        /// </summary>
        TIGHTUP_WIDE,					                                   
        /// <summary>
        /// Down right + WIDE
        /// 右下 + WIDE
        /// </summary>
        RIGHTDOWN_WIDE,					                                   
        /// <summary>
        /// max command value
        /// 最大命令值
        /// </summary>
        TOTAL,							                                   
    }

    /// <summary>
    /// frame parameter structure of Callback video data frame
    /// 回调视频数据帧的帧参数结构体
    /// </summary>
    public struct NET_VideoFrameParam
    {
        /// <summary>
        /// Encode type 
        /// 编码类型
        /// </summary>
        public byte                                 encode;				   
        /// <summary>
        /// I = 0, P = 1, B = 2...
        /// I = 0, P = 1, B = 2...
        /// </summary>
        public byte                                 frametype;				
        /// <summary>
        /// PAL - 0, NTSC - 1
        /// PAL - 0, NTSC - 1
        /// </summary>
        public byte                                 format;			    	
        /// <summary>
        /// CIF - 0, HD1 - 1, 2CIF - 2, D1 - 3, VGA - 4, QCIF - 5, QVGA - 6 ,SVCD - 7,QQVGA - 8, SVGA - 9, XVGA - 10,WXGA - 11,SXGA - 12,WSXGA - 13,UXGA - 14,WUXGA - 15,LFT - 16, 720 - 17, 1080 - 18,1_3M-19, 2M-20, 5M-21;when size equal to 255, width and height valid
        /// CIF - 0, HD1 - 1, 2CIF - 2, D1 - 3, VGA - 4, QCIF - 5, QVGA - 6 ,SVCD - 7,QQVGA - 8, SVGA - 9, XVGA - 10,WXGA - 11,SXGA - 12,WSXGA - 13,UXGA - 14,WUXGA - 15,LFT - 16, 720 - 17, 1080 - 18 ,1_3M-19,2M-20, 5M-21;当size=255时，成员变量width,height 有效
        /// </summary>
        public byte                                 size;					
        /// <summary>
        /// If it is H264 encode it is always 0,Fill in FOURCC('X','V','I','D') in MPEG 4
        /// 如果是H264编码则总为0，否则值为*( DWORD*)"DIVX"，即0x58564944
        /// </summary>
        public uint                                 fourcc;				    
        /// <summary>
        /// width pixel, valid when struct member "size"  equal to 255
        /// 宽，单位是像素，当size=255时有效
        /// </summary>
        public ushort                               width;
        /// <summary>
        /// height pixel, valid when struct member "size"  equal to 255
        /// 高，单位是像素，当size=255时有效
        /// </summary>
        public ushort                               height;		
        /// <summary>
        /// Time information
        /// 时间信息
        /// </summary>
        public NET_TIME                             struTime;			    
    }

    /// <summary>
    /// frame parameter structure of audio data callback 
    /// 回调音频数据帧的帧参数结构体
    /// </summary>
    public struct NET_CBPCMDataParam
    {
        /// <summary>
        /// Track amount
        /// 声道数
        /// </summary>
        public byte                                 channels;				 
        /// <summary>
        /// sample 0 - 8000, 1 - 11025, 2 - 16000, 3 - 22050, 4 - 32000, 5 - 44100, 6 - 48000
        /// 采样 0 - 8000, 1 - 11025, 2 - 16000, 3 - 22050, 4 - 32000, 5 - 44100, 6 - 48000
        /// </summary>
        public byte                                 samples;				
        /// <summary>
        /// Sampling depth. Value:8/16 show directly
        /// 采样深度 取值8或者16等。直接表示
        /// </summary>
        public byte                                 depth;					
        /// <summary>
        /// 0 - indication no symbol,1-indication with symbol
        /// 0 - 指示无符号,1-指示有符号
        /// </summary>
        public byte                                 param1;				    
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        public uint                                 reserved;				
    }

    /// <summary>
    /// Time structure
    /// 时间结构体
    /// </summary>
    public struct NET_TIME
    {
        /// <summary>
        /// Year
        /// 年
        /// </summary>
        public uint                                 dwYear;               
        /// <summary>
        /// Month
        /// 月
        /// </summary>
        public uint                                 dwMonth;              
        /// <summary>
        /// Day
        /// 天
        /// </summary>
        public uint                                 dwDay;                
        /// <summary>
        /// Hour
        /// 小时
        /// </summary>
        public uint                                 dwHour;               
        /// <summary>
        /// Minute
        /// 分
        /// </summary>
        public uint                                 dwMinute;             
        /// <summary>
        /// Second
        /// 秒
        /// </summary>
        public uint                                 dwSecond;             
        /// <summary>
        /// DateTime change to NET_TIME static funtion.
        /// DateTime转为NET_TIME静态函数
        /// </summary>
        /// <param name="dateTime">datetime</param>
        /// <returns>NET_TIME</returns>
        public static NET_TIME FromDateTime(DateTime dateTime)
        {
            try
            {
                NET_TIME net_time = new NET_TIME();
                net_time.dwYear = (uint)dateTime.Year;
                net_time.dwMonth = (uint)dateTime.Month;
                net_time.dwDay = (uint)dateTime.Day;
                net_time.dwHour = (uint)dateTime.Hour;
                net_time.dwMinute = (uint)dateTime.Minute;
                net_time.dwSecond = (uint)dateTime.Second;
                return net_time;
            }
            catch 
            {
                return new NET_TIME();
            }
        }
        /// <summary>
        /// change NET_TIME to DateTime
        /// NET_TIME 转为 DateTime
        /// </summary>
        /// <returns>DateTime</returns>
        public DateTime ToDateTime()
        {
            try
            {
                return new DateTime((int)dwYear, (int)dwMonth, (int)dwDay, (int)dwHour, (int)dwMinute, (int)dwSecond);
            }
            catch
            {
                return new DateTime();
            }
        }
        /// <summary>
        /// oveeride toString function
        /// 重写toString函数
        /// </summary>
        /// <returns>return time string</returns>
        public override string ToString()
        {
            return string.Format("{0}-{1}-{2} {3}:{4}:{5}", dwYear.ToString("D4"), dwMonth.ToString("D2"), dwDay.ToString("D2"), dwHour.ToString("D2"), dwMinute.ToString("D2"), dwSecond.ToString("D2"));
        }
    }

    /// <summary>
    /// control playback type
    /// 回放控制类型
    /// </summary>
    public enum PlayBackType
    {
        /// <summary>
        /// play
        /// 播发
        /// </summary>
        Play,                                                               
        /// <summary>
        /// pause
        /// 暂停
        /// </summary>
        Pause,                                                              
        /// <summary>
        /// stop
        /// 停止
        /// </summary>
        Stop,                                                               
        /// <summary>
        /// fast
        /// 快放
        /// </summary>
        Fast,                                                               
        /// <summary>
        /// slow
        /// 慢放
        /// </summary>
        Slow,                                                               
        /// <summary>
        /// normal
        /// 正常播放
        /// </summary>
        Normal,                                                             
    }

    /// <summary>
    /// user work mode enumeration
    /// 用户设置工作模式枚举
    /// </summary>
    public enum EM_USEDEV_MODE
    {
        /// <summary>
        /// Set client-end mode to begin audio talk 
        /// 设置客户端方式进行语音对讲
        /// </summary>
        TALK_CLIENT_MODE,						                           
        /// <summary>
        /// Set server mode to begin audio talk 
        /// 设置服务器方式进行语音对讲
        /// </summary>
        TALK_SERVER_MODE,						                           
        /// <summary>
        /// Set encode format for audio talk,corresponding structure NET_DEV_TALKDECODE_INFO
        /// 设置语音对讲编码格式(对应NET_DEV_TALKDECODE_INFO)
        /// </summary>
        TALK_ENCODE_TYPE,						                            
        /// <summary>
        /// Set alarm subscribe way
        /// 设置报警订阅方式
        /// </summary>
        ALARM_LISTEN_MODE,						                             
        /// <summary>
        /// Set user right to realize configuration management
        /// 设置通过权限进行配置管理
        /// </summary>
        CONFIG_AUTHORITY_MODE,					                            
        /// <summary>
        /// set talking channel(0~MaxChannel-1)
        /// 设置对讲通道(0~MaxChannel-1)
        /// </summary>
        TALK_TALK_CHANNEL,						                            
        /// <summary>
        /// set the stream type of the record for query(0-both main and extra stream,1-only main stream,2-only extra stream)
        /// 设置待查询及按时间回放的录像码流类型(0-主辅码流,1-主码流,2-辅码流)
        /// </summary>
        RECORD_STREAM_TYPE,                                                 
        /// <summary>
        /// set speaking parameter,corresponding structure NET_SPEAK_PARAM
        /// 设置语音对讲喊话参数,对应结构体 NET_SPEAK_PARAM
        /// </summary>
        TALK_SPEAK_PARAM,                                                   
        /// <summary>
        /// Set by time video playback and download the video file TYPE,see to EM_RECORD_TYPE
        /// 设置按时间录像回放及下载的录像文件类型(详见EM_RECORD_TYPE)
        /// </summary>
        RECORD_TYPE,                                                       
        /// <summary>
        /// Set voice intercom parameters of three generations of equipment and the corresponding structure NET_TALK_EX
        /// 设置三代设备的语音对讲参数, 对应结构体 NET_TALK_EX
        /// </summary>
        TALK_MODE3,								                            
        /// <summary>
        /// set real time playback function(0-off,1-on)
        /// 设置实时回放功能(0-关闭,1开启)
        /// </summary>
        PLAYBACK_REALTIME_MODE,                                             
        /// <summary>
        /// judge the voice intercom if it was a forwarding mode, (corresponding to  NET_TALK_TRANSFER_PARAM)
        /// 设置语音对讲是否为转发模式, 对应结构体 NET_TALK_TRANSFER_PARAM
        /// </summary>
        TALK_TRANSFER_MODE,                                                 
        /// <summary>
        /// set VT parameters,corresponding structure NET_VT_TALK_PARAM
        /// 设置VT对讲参数, 对应结构体 NET_VT_TALK_PARAM
        /// </summary>
        TALK_VT_PARAM,                                                      
        /// <summary>
        /// set target device identifier for searching system capacity information, (not zero - locate device forwards the information)
        /// 设置目标设备标示符, 用以查询新系统能力(非0-转发系统能力消息)
        /// </summary>
        TARGET_DEV_ID,                                                      
    }

    /// <summary>
    /// audio encode information structure
    /// 语音编码信息
    /// </summary>
    public struct  NET_DEV_TALKDECODE_INFO
    {
        /// <summary>
        /// Encode type
        /// 编码类型
        /// </summary>
        public EM_TALK_CODING_TYPE                  encodeType;				
        /// <summary>
        /// Bit:8/16
        /// 位数,如8或16, 目前只能是16
        /// </summary>
	    public int					                nAudioBit;				
        /// <summary>
        /// Sampling rate such as 8000 or 16000
        /// 采样率,如8000或16000
        /// </summary>
	    public uint				                    dwSampleRate;		    
        /// <summary>
        /// Pack Period,Unit ms
        /// 打包周期, 单位ms
        /// </summary>
        public int                                  nPacketPeriod;          
        /// <summary>
        /// resrved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 60)]
        public byte[]                               reserved;               
    }

    /// <summary>
    /// audio encode type enumeration
    /// 语音编码类型
    /// </summary>
    public enum EM_TALK_CODING_TYPE
    {
        /// <summary>
        /// No-head PCM
        /// 无头PCM
        /// </summary>
        DEFAULT = 0,						                               
        /// <summary>
        /// With head PCM
        /// 带头PCM
        /// </summary>
        PCM = 1,							                               
        /// <summary>
        /// G711a
        /// G711a
        /// </summary>
        G711a,								                               
        /// <summary>
        /// AMR
        /// AMR
        /// </summary>
        AMR,								                               
        /// <summary>
        /// G711u
        /// G711u
        /// </summary>
        G711u,								                               
        /// <summary>
        /// G726
        /// G726
        /// </summary>
        G726,								                               
        /// <summary>
        /// G723_53
        /// G723_53
        /// </summary>
        G723_53,							                               
        /// <summary>
        /// G723_63
        /// G723_63
        /// </summary>
        G723_63,							                               
        /// <summary>
        /// AAC
        /// AAC
        /// </summary>
        AAC,								                               
        /// <summary>
        /// OGG
        /// OGG
        /// </summary>
        OGG,                                                               
        /// <summary>
        /// G729
        /// G729
        /// </summary>
        G729 = 10,                                                         
        /// <summary>
        /// MPEG2
        /// MPEG2
        /// </summary>
        MPEG2,                                                             
        /// <summary>
        /// MPEG2-Layer2
        /// MPEG2-Layer2
        /// </summary>
        MPEG2_Layer2,                                                      
        /// <summary>
        /// G.722.1
        /// G.722.1
        /// </summary>
        G722_1,                                                            
        /// <summary>
        /// ADPCM
        /// ADPCM
        /// </summary>
        ADPCM = 21,                                                        
        /// <summary>
        /// MP3
        /// MP3
        /// </summary>
        MP3 = 22,							                               
    }

    /// <summary>
    /// speak information structure
    /// 对讲信息结构体
    /// </summary>
    public struct NET_SPEAK_PARAM
    {
        /// <summary>
        /// struct size 
        /// 结构体大小
        /// </summary>
        public uint                         dwSize;                         
        /// <summary>
        /// 0:talk back(default), 1: propaganda,from propaganda ro talk back,need afresh to configure
        /// 0：对讲（默认模式）,1：喊话；从喊话切换到对讲要重新设置
        /// </summary>
        public int                          nMode;                          
        /// <summary>
        /// reproducer channel
        /// 扬声器通道号,喊话时有效
        /// </summary>
        public int                          nSpeakerChannel;                
        /// <summary>
        /// Wait for device to responding or not when enable bidirectional talk. Default setup is no.TRUE:wait ;FALSE:no
        /// 开启对讲时是否等待设备的响应,默认不等待.TRUE:等待;FALSE:不等待，超时时间由CLIENT_SetNetworkParam设置,对应NET_PARAM的nWaittime字段
        /// </summary>
        public bool                         bEnableWait;                   
    }

    /// <summary>
    /// record file type
    /// 录像文件类型
    /// </summary>
    public enum EM_RECORD_TYPE
    {
        /// <summary>
        /// All the video
        /// 所有录像
        /// </summary>
        ALL,                                                              
        /// <summary>
        /// normal  video
        /// 普通录像
        /// </summary>
        NORMAL,                                                           
        /// <summary>
        /// External alarm video
        /// 外部报警录像
        /// </summary>
        ALARM,                                                            
        /// <summary>
        /// motion alarm video
        /// 动检报警录像
        /// </summary>
        MOTION,                                                           
    }

    /// <summary>
    /// extend talk information for EM_USEDEV_MODE.TALK_MODE3
    /// 对讲扩展结构体
    /// </summary>
    public struct NET_TALK_EX
    {
        /// <summary>
        /// struct size
        /// 结构体大小
        /// </summary>
        public uint                         dwSize;                      
        /// <summary>
        /// channel number
        /// 通道号
        /// </summary>
	    public int					        nChannel;                    
        /// <summary>
        /// Audio transmission listener ports
        /// 音频传输侦听端口
        /// </summary>
	    public int                          nAudioPort;                  
        /// <summary>
        /// Ms wait time, unit, use the default value is 0
        /// 等待时间, 单位ms,为0则使用默认值
        /// </summary>
	    public int					        nWaitTime;                    
        /// <summary>
        /// Visual talk video window
        /// 可视对讲视频显示窗口
        /// </summary>
        public IntPtr				        hVideoWnd;				      
        /// <summary>
        /// Video encode format
        /// 视频编码格式
        /// </summary>
	    public NET_TALK_VIDEO_FORMAT        stuVideoFmt;			      
        /// <summary>
        /// Multicast address
        /// 组播地址
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
	    public byte[]				        szMulticastAddr;              
        /// <summary>
        /// Multicast local port
        /// 组播本地端口
        /// </summary>
	    public ushort				        wMulticastLocalPort;	      
        /// <summary>
        /// Multicast remote port
        /// 组播远程端口
        /// </summary>
	    public ushort				        wMulticastRemotePort;	      
    }

    /// <summary>
    /// video format information
    /// 视频格式信息结构体
    /// </summary>
    public struct NET_TALK_VIDEO_FORMAT
    {
        /// <summary>
        /// struct size
        /// 结构体大小
        /// </summary>
        public uint                         dwSize;                         
        /// <summary>
        /// Video compression format
        /// 视频压缩格式
        /// </summary>
	    public uint				            dwCompression;			       
        /// <summary>
        /// Video sampling frequency
        /// 视频采样频率
        /// </summary>
	    public int					        nFrequency;				        
    }

    /// <summary>
    /// open the forwarding mode of intercom or not 
    /// 是否开启语音对讲的转发模式
    /// </summary>
    public struct NET_TALK_TRANSFER_PARAM
    {
        /// <summary>
        /// struct size
        /// 结构体大小
        /// </summary>
        public uint                         dwSize;                         
        /// <summary>
        /// Open the forwarding mode of intercom or not, TRUE: yes, FALSE: no
        /// 是否开启语音对讲转发模式, TRUE: 开启转发, FALSE: 关闭转发
        /// </summary>
        public bool                         bTransfer;                       
    }

    /// <summary>
    /// talk about VT information
    /// VT对讲参数
    /// </summary>
    public struct NET_VT_TALK_PARAM
    {
        /// <summary>
        /// struct size
        /// 结构体大小
        /// </summary>
        public uint                         dwSize;                        
        /// <summary>
        /// identity filed is valid by bitwise.see EM_VT_PARAM_VALID
        /// 按位标识后面的字段是否有效, EM_VT_PARAM_VALID的组合
        /// </summary>
        public int                          nValidFlag;                    
        /// <summary>
        /// event call back, EM_VT_PARAM_VALID.EVENT_CB is valid
        /// 事件回调函数, EM_VT_PARAM_VALID.EVENT_CB
        /// </summary>
        public fVtEventCallBack             pfEventCb;                     
        /// <summary>
        /// call back user data, EM_VT_PARAM_VALID.USER_DATA is valid
        /// 事件回调函数自定义数据, EM_VT_PARAM_VALID.USER_DATA
        /// </summary>
        public IntPtr                       dwUser;                        
        /// <summary>
        /// Mid-number(the called number), 8byte, EM_VT_PARAM_VALID.MID_NUM is valid
        /// 被叫中号, 8位, EM_VT_PARAM_VALID.MID_NUM
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[]                       szPeerMidNum;                   
        /// <summary>
        /// call operation, 0:no-operation, 1:repulse, 2:accept, EM_VT_PARAM_VALID.ACTION is valid
        /// 对呼叫的操作, 0:无操作, 1:拒接, 2:接入, EM_VT_PARAM_VALID_ACTION
        /// </summary>
        public EM_NEWCALL_ACTION            emAction;                     
        /// <summary>
        /// waitting time(ms), EM_VT_PARAM_VALID.WAITTIME is valid
        /// 超时时间, 单位ms, EM_VT_PARAM_VALID.WAITTIME
        /// </summary>
        public int                          nWaitTime;                    
        /// <summary>
        /// handle for show video, EM_VT_PARAM_VALID.VIDEOWND is valid
        /// 可视对讲视频显示窗口, EM_VT_PARAM_VALID.VIDEOWND
        /// </summary>
        public IntPtr                       hVideoWnd;                    
        /// <summary>
        /// talk mode, true:client, false:server, EM_VT_PARAM_VALID.CSMODE is valid
        /// 客户端/服务器模式, TRUE:客户端, FALSE:服务器, EM_VT_PARAM_VALID.CSMODE
        /// </summary>
        public bool                         bClient;                       
        /// <summary>
        /// talk decode information.
        /// 语音编码信息, EM_VT_PARAM_VALID.AUDIO_ENCODE
        /// </summary>
        public NET_DEV_TALKDECODE_INFO      stAudioEncode;                 
    }

    /// <summary>
    /// call operation  for VT 
    /// 呼叫事件处理动作
    /// </summary>
    public enum EM_NEWCALL_ACTION
    {
        /// <summary>
        /// no-operation
        /// 无操作
        /// </summary>                                                     
        UNKNOWN,                                                           
        /// <summary>                                                      
        /// repulse                                                        
        /// 拒接                                                               
        /// </summary>                                                     
        REFUSE,                                                            
        /// <summary>                                                      
        /// accept                                                         
        /// 接入                                                               
        /// </summary>                                                     
        ACCEPT,                                                            
    }

    /// <summary>
    /// valid paramter for VT
    /// VT有效参数类型
    /// </summary>
    public enum EM_VT_PARAM_VALID
    {
        /// <summary>
        /// event call back
        /// 事件回调
        /// </summary>
        EVENT_CB                    = 0x0001,                             
        /// <summary>
        /// user data
        /// 用户数据
        /// </summary>
        USER_DATA                   = 0x0002,                             
        /// <summary>
        /// Mid-number
        /// 中号
        /// </summary>
        MID_NUM                     = 0x0004,                             
        /// <summary>
        /// call operation
        /// 呼叫操作
        /// </summary>
        ACTION                      = 0x0008,                             
        /// <summary>
        /// waitting time
        /// 等待
        /// </summary>
        WAITTIME                    = 0x0010,                             
        /// <summary>
        /// handle for show video
        /// 显示视频
        /// </summary>
        VIDEOWND                    = 0x0020,                             
        /// <summary>
        /// talk mode
        /// 对讲模式
        /// </summary>
        CSMODE                      = 0x0040,                             
        /// <summary>
        /// audio encode
        /// 音频编码
        /// </summary>
        AUDIO_ENCODE                = 0x0080,                             
        /// <summary>
        /// local ip
        /// 本地IP
        /// </summary>
        LOCAL_IP                    = 0x0100,                             
    }

    /// <summary>
    /// event type
    /// 事件类型
    /// </summary>
    public enum EM_AUDIO_CB_FLAG
    {
        /// <summary>
        /// unknow
        /// 未知
        /// </summary>
        UNKNOWN,                                                          
        /// <summary>
        /// new call
        /// 有呼叫进来
        /// </summary>
        NEWCALL,                                                          
        /// <summary>
        /// hangup
        /// 对方挂断
        /// </summary>
        REMOTE_HANGUP,                                                    
        /// <summary>
        /// disconncet
        /// 断线
        /// </summary>
        DISCONNECT,                                                       
        /// <summary>
        /// ring
        /// 对端响铃
        /// </summary>
        RING,                                                             
    }

    /// <summary>
    /// record play back parameter information
    /// 录像回放入参信息
    /// </summary>
    public struct NET_IN_PLAY_BACK_BY_TIME_INFO
    {
        /// <summary>
        /// Begin time
        /// 开始时间
        /// </summary>
        public NET_TIME             stStartTime;                           
        /// <summary>
        /// End time
        /// 结束时间
        /// </summary>
        public NET_TIME             stStopTime;                            
        /// <summary>
        /// Play window
        /// 播放窗格, 可为NULL
        /// </summary>
        public IntPtr               hWnd;                                  
        /// <summary>
        /// Download pos callback
        /// 进度回调
        /// </summary>
        public fDownLoadPosCallBack cbDownLoadPos;                         
        /// <summary>
        /// Pos user
        /// 进度回调用户信息
        /// </summary>
        public IntPtr               dwPosUser;                             
        /// <summary>
        /// Download data callback
        /// 数据回调
        /// </summary>
        public fDataCallBack        fDownLoadDataCallBack;                 
        /// <summary>
        /// Data user
        /// 数据回调用户信息
        /// </summary>
        public IntPtr               dwDataUser;                            
        /// <summary>
        /// Playback direction 
        /// 播放方向, 0:正放; 1:倒放(需要设备支持）
        /// </summary>
        public int                  nPlayDirection;                        
        /// <summary>
        /// Watiting time
        /// 接口超时时间, 目前倒放使用
        /// </summary>
        public int                  nWaittime;                             
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
        public byte[]               bReserved;                             
    }

    /// <summary>
    /// record play back parameter out
    /// 录像回放出参信息
    /// </summary>
    public struct NET_OUT_PLAY_BACK_BY_TIME_INFO
    {
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
        public byte[]              bReserved;                                
    }

    /// <summary>
    /// record file information
    /// 录像文件信息
    /// </summary>
    public struct NET_RECORDFILE_INFO
    {
        /// <summary>
        /// Channel number
        /// 通道号
        /// </summary>
        public uint	        	ch;						                   
        /// <summary>
        /// File name
        /// 文件名
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 124)]
        public string			filename;		    	                   
        /// <summary>
        /// the total number of file frames
        /// 文件总帧数
        /// </summary>
	    public uint             framenum;                                  
        /// <summary>
        /// File length 
        /// 文件长度, 单位为Kbyte
        /// </summary>
        public uint		        size;					                    
        /// <summary>
        /// Start time 
        /// 开始时间
        /// </summary>
        public NET_TIME			starttime;				                    
        /// <summary>
        /// End time 
        /// 结束时间
        /// </summary>
        public NET_TIME			endtime;				                    
        /// <summary>
        /// HDD number, 0－127 is the local record. 128-network record
        /// 磁盘号(区分网络录像和本地录像的类型,0－127表示本地录像,其中64表示光盘1,128表示网络录像)
        /// </summary>
        public uint		        driveno;				                    
        /// <summary>
        /// Start cluster number 
        /// 起始簇号
        /// </summary>
        public uint		        startcluster;			                    
        /// <summary>
        /// Recorded file type  0:general record;1:alarm record ;2:motion detection;3:card number record ;4:image ;255:all
        /// 录象文件类型  0：普通录象；1：报警录象；2：移动检测；3：卡号录象；4：图片, 5: 智能录像, 19: POS录像, 255:所有录像
        /// </summary>
	    public byte				nRecordFileType;		                   
        /// <summary>
        /// 0:general record 1:Important record
        /// 0:普通录像 1:重要录像
        /// </summary>
	    public byte             bImportantRecID;		                   
        /// <summary>
        /// Document Indexing
        /// 文件定位索引(nRecordFileType==4<图片>时,bImportantRecID<<8 +bHint ,组成图片定位索引 )
        /// </summary>
	    public byte             bHint;					                   
        /// <summary>
        /// 0-main stream record 1-sub1 stream record 2-sub2 stream record 3-sub3 stream record
        /// 0-主码流录像 1-辅码1流录像 2-辅码流2 3-辅码流3录像
        /// </summary>
	    public byte             bRecType;                                   
    }

    /// <summary>
    /// type of video search
    /// 录像查询类型
    /// </summary>
    public enum EM_QUERY_RECORD_TYPE
    {
        /// <summary>
        /// All the recorded video  
        /// 所有录像
        /// </summary>
        ALL              = 0,                                              
        /// <summary>
        /// The video of external alarm
        /// 外部报警录像
        /// </summary>
        ALARM            = 1,                                              
        /// <summary>
        /// The video of dynamic detection alarm
        /// 动态检测报警录像
        /// </summary>
        MOTION_DETECT    = 2,                                              
        /// <summary>
        /// All the alarmed video
        /// 所有报警录像
        /// </summary>
        ALARM_ALL        = 3,                                              
        /// <summary>
        /// query by the card number
        /// 卡号查询
        /// </summary>
        CARD             = 4,                                              
        /// <summary>
        /// query by condition
        /// 按条件查询
        /// </summary>
        CONDITION        = 5,                                              
        /// <summary>
        /// combination query 
        /// 组合查询
        /// </summary>
        JOIN             = 6,                                              
        /// <summary>
        /// query pictures by the card number, used by HB-U and NVS
        /// 按卡号查询图片,HB-U、NVS等使用
        /// </summary>
        CARD_PICTURE     = 8,                                              
        /// <summary>
        /// query pictures, used by HB-U and NVS
        /// 查询图片,HB-U、NVS等使用
        /// </summary>
        PICTURE          = 9,                                              
        /// <summary>
        /// query by field
        /// 按字段查询
        /// </summary>
        FIELD            = 10,                                             
        /// <summary>
        /// Smart record search 
        /// 智能录像查询
        /// </summary>
        INTELLI_VIDEO    = 11,			                                   
        /// <summary>
        /// query network data, used by Jinqiao Internet Bar
        /// 查询网络数据,金桥网吧等使用
        /// </summary>
        NET_DATA         = 15,                                             
        /// <summary>
        /// query the video of serial data
        /// 查询透明串口数据录像
        /// </summary>
        TRANS_DATA       = 16,                                             
        /// <summary>
        /// query the important video
        /// 查询重要录像
        /// </summary>
        IMPORTANT        = 17,                                             
        /// <summary>
        /// query the talk file
        /// 查询录音文件
        /// </summary>
        TALK_DATA        = 18,                                             
        /// <summary>
        /// invalid query type
        /// POS录像
        /// </summary>
        INVALID          = 256,                                            
    }

    /// <summary>
    /// alarm type,used in fMessCallBackEx
    /// 报警类型
    /// </summary>
    public enum EM_ALARM_TYPE                                               
    {
        /// <summary>
        /// External alarm ,data's length(byte) is same to device's alarm channels' count, 1 means alarm, 0 means Non alarm.
        /// 外部报警，数据字节数与设备报警通道个数相同，每个字节表示一个报警通道的报警状态，1为有报警，0为无报警
        /// </summary>
        ALARM_ALARM_EX			                            = 0x2101,		 
        /// <summary>
        /// Motion detection alarm 
        /// 动态检测报警，数据字节数与设备视频通道个数相同，每个字节表示一个视频通道的动态检测报警状态，1为有报警，0为无报警
        /// </summary>
        MOTION_ALARM_EX			                            = 0x2102,		
        /// <summary>
        /// Video loss alarm 
        /// 视频丢失报警，数据字节数与设备视频通道个数相同，每个字节表示一个视频通道的视频丢失报警状态，1为有报警，0为无报警
        /// </summary>
        VIDEOLOST_ALARM_EX		                            = 0x2103,		
        /// <summary>
        /// Camera masking alarm 
        /// 视频遮挡报警，数据字节数与设备视频通道个数相同，每个字节表示一个视频通道的遮挡(黑屏)报警状态，1为有报警，0为无报警
        /// </summary>
        SHELTER_ALARM_EX		                            = 0x2104,		
        /// <summary>
        /// Audio detection alarm 
        /// 音频检测报警，数据为16个字节，每个字节表示一个视频通道的音频检测报警状态，1为有报警，0为无报警
        /// </summary>
        SOUND_DETECT_ALARM_EX	                            = 0x2105,		
        /// <summary>
        /// HDD full alarm 
        /// 硬盘满报警，数据为1个字节，1为有硬盘满报警，0为无报警
        /// </summary>
        DISKFULL_ALARM_EX		                            = 0x2106,		
        /// <summary>
        /// HDD error alarm
        /// 坏硬盘报警，数据为32个字节，每个字节表示一个硬盘的故障报警状态，1为有报警，0为无报警
        /// </summary>
        DISKERROR_ALARM_EX		                            = 0x2107,		 
        /// <summary>
        /// Encoder alarm
        /// 编码器报警，数据为16个字节，每个字节表示一个通道编码器状态，1为有报警，0为无报警
        /// </summary>
        ENCODER_ALARM_EX		                            = 0x210A,		
        /// <summary>
        /// Emergency alarm 
        /// 紧急报警，数据为16个字节，每个字节表示一个通道编码器状态，1为有报警，0为无报警
        /// </summary>
        URGENCY_ALARM_EX		                            = 0x210B,		
        /// <summary>
        /// Wireless alarm
        /// 无线报警，数据为16个字节，每个字节表示一个通道编码器状态，1为有报警，0为无报警
        /// </summary>
        WIRELESS_ALARM_EX		                            = 0x210C,		  
        /// <summary>
        /// New auido detection alarm. Please refer to NET_NEW_SOUND_ALARM_STATE for alarm information structure
        /// 新音频检测报警,报警信息的结构体见NET_NEW_SOUND_ALARM_STATE
        /// </summary>
        NEW_SOUND_DETECT_ALARM_EX                           = 0x210D,		
        /// <summary>
        /// Alarm decoder alarm
        /// 报警解码器报警，报警信息的结构体见 NET_ALARM_DECODER_ALARM
        /// </summary>
        ALARM_DECODER_ALARM_EX	                            = 0x210E,		 
        /// <summary>
        /// NVD:Decoding capacity
        /// 解码器：解码能力报警，数据为一个字节，0：能正常解码 1：表示超出解码能力
        /// </summary>
        DECODER_DECODE_ABILITY	                            = 0x210F,		 
        /// <summary>
        /// Fiber encoder alarm
        /// 光纤编码器状态报警，报警信息的结构体见 NET_ALARM_FDDI_ALARM
        /// </summary>
        FDDI_DECODER_ABILITY	                            = 0x2110,		
        /// <summary>
        /// Panorama switch alarm
        /// 切换场景报警，数据为16个字节，每个字节表示一个通道编码器状态，1为有报警，0为无报警
        /// </summary>
        PANORAMA_SWITCH_ALARM_EX	                        = 0x2111,		
        /// <summary>
        /// Lost focus alarm
        /// 失去焦点报警，数据为16个字节，每个字节表示一个通道编码器状态，1为有报警，0为无报警
        /// </summary>
        LOSTFOCUS_ALARM_EX		                            = 0x2112,		
        /// <summary>
        /// oem state
        /// oem报停状态，数据为 1 BYTE
        /// </summary>
        OEMSTATE_EX				                            = 0x2113,		 
        /// <summary>
        /// DSP alarm
        /// DSP报警，报警信息的结构体见 NET_DSP_ALARM
        /// </summary>
        DSP_ALARM_EX				                        = 0x2114,		 
        /// <summary>
        /// atm and pos disconnection alarm, 0:disconnection 1:connection
        /// atm和pos机断开报警, 数据为 1 BYTE，0：连接断开 1：连接正常
        /// </summary>
        ATMPOS_BROKEN_EX			                        = 0x2115,		
        /// <summary>
        /// Record state changed alarm
        /// 录像状态变化报警，报警信息为 NET_ALARM_RECORDING_CHANGED 数组
        /// </summary>
        RECORD_CHANGED_EX		                            = 0x2116,		
        /// <summary>
        /// Device config changed alarm
        /// 配置发生变化报警，数据 无
        /// </summary>
        CONFIG_CHANGED_EX		                            = 0x2117,		
        /// <summary>
        /// Device rebooting alarm
        /// 设备重启报警，数据 无
        /// </summary>
        DEVICE_REBOOT_EX			                        = 0x2118,		
        /// <summary>
        /// CoilFault alarm
        /// 线圈/车检器故障报警(对应结构体 NET_ALARM_WINGDING_INFO)
        /// </summary>
        WINGDING_ALARM_EX                                   = 0x2119,       
        /// <summary>
        /// traffic congestion alarm
        /// 交通阻塞报警(车辆出现异常停止或者排队)(对应结构体 NET_ALARM_TRAF_CONGESTION_INFO)
        /// </summary>
        TRAF_CONGESTION_ALARM_EX                            = 0x211A,       
        /// <summary>
        /// traffic exception alarm
        /// 交通异常报警(交通流量趋于0或异常空闲)(对应结构体 NET_ALARM_TRAF_EXCEPTION_INFO)
        /// </summary>
        TRAF_EXCEPTION_ALARM_EX                             = 0x211B,       
        /// <summary>
        /// FlashFault alarm
        /// 补光设备故障报警(对应结构体 NET_ALARM_EQUIPMENT_FILL_INFO)
        /// </summary>
        EQUIPMENT_FILL_ALARM_EX                             = 0x211C,       
        /// <summary>
        /// alarm arm disarm 
        /// 报警布撤防状态(对应结构体 NET_ALARM_EQUIPMENT_FILL_INFO)
        /// </summary>
        ALARM_ARM_DISARM_STATE	                            = 0x211D,		
        /// <summary>
        /// ACC power off alarm
        /// ACC断电报警，数据为 DWORD 0：ACC通电 1：ACC断电
        /// </summary>
        ALARM_ACC_POWEROFF                                  = 0x211E,        
        /// <summary>
        /// Alarm of 3G flow exceed(see struct NET_DEV_3GFLOW_EXCEED_STATE_INFO)
        /// 3G流量超出阈值报警(对应结构体 NET_DEV_3GFLOW_EXCEED_STATE_INFO)
        /// </summary>
        ALARM_3GFLOW_EXCEED                                 = 0x211F,       
        /// <summary>
        /// Speed limit alarm 
        /// 限速报警(对应结构体 NET_ALARM_SPEED_LIMIT)
        /// </summary>
        ALARM_SPEED_LIMIT                                   = 0x2120,        
        /// <summary>
        /// Vehicle information uploading
        /// 车载自定义信息上传 (对应结构体 NET_ALARM_VEHICLE_INFO_UPLOAD)
        /// </summary>
        ALARM_VEHICLE_INFO_UPLOAD                           = 0x2121,        
        /// <summary>
        /// Static detection alarm
        /// 静态检测报警，数据字节数与设备视频通道个数相同，每个字节表示一个视频通道的静态检测报警状态，1为有报警，0为无报警
        /// </summary>
        STATIC_ALARM_EX                                     = 0x2122,       
        /// <summary>
        /// ptz location info
        /// 云台定位信息(对应结构体 NET_PTZ_LOCATION_INFO)
        /// </summary>
        PTZ_LOCATION_EX                                     = 0x2123,       
        /// <summary>
        /// card record info(struct NET_ALARM_CARD_RECORD_INFO_UPLOAD)
        /// 卡号录像信息上传(对应结构体 NET_ALARM_CARD_RECORD_INFO_UPLOAD)
        /// </summary>
        ALARM_CARD_RECORD_UPLOAD	                        = 0x2124,		
        /// <summary>
        /// ATM trade info(struct NET_ALARM_ATM_INFO_UPLOAD)
        /// ATM交易信息上传(对应结构体 ALARM_ATM_INFO_UPLOAD)
        /// </summary>
        ALARM_ATM_INFO_UPLOAD	                            = 0x2125,		 
        /// <summary>
        /// enclosure alarm(struct NET_ALARM_ENCLOSURE_INFO)
        /// 电子围栏报警(对应结构体NET_ALARM_ENCLOSURE_INFO)
        /// </summary>
        ALARM_ENCLOSURE                                     = 0x2126,        
        /// <summary>
        /// SIP state alarm(struct NET_ALARM_SIP_STATE)
        /// SIP状态报警(对应结构体 NET_ALARM_SIP_STATE)
        /// </summary>
        ALARM_SIP_STATE                                     = 0x2127,        
        /// <summary>
        /// RAID state alarm(struct NET_ALARM_RAID_INFO)
        /// RAID异常报警(对应结构体 NET_ALARM_RAID_INFO)
        /// </summary>
        ALARM_RAID_STATE                                    = 0x2128,       
        /// <summary>
        /// crossing speed limit alarm(struct NET_ALARM_SPEED_LIMIT)
        /// 路口限速报警(对应结构体 NET_ALARM_SPEED_LIMIT)
        /// </summary>
        ALARM_CROSSING_SPEED_LIMIT                          = 0x2129,	   
        /// <summary>
        /// over loading alarm(struct NET_ALARM_OVER_LOADING)
        /// 超载报警(对应结构体NET_ALARM_OVER_LOADING)
        /// </summary>
        ALARM_OVER_LOADING                                  = 0x212A,       
        /// <summary>
        /// hard brake alarm(struct NET_ALARM_HARD_BRAKING)
        /// 急刹车报警(对应机构体NET_ALARM_HARD_BRAKING)
        /// </summary>
        ALARM_HARD_BRAKING                                  = 0x212B,       
        /// <summary>
        /// smoke sensor alarm(struct NET_ALARM_SMOKE_SENSOR)
        /// 烟感报警(对应结构体NET_ALARM_SMOKE_SENSOR)
        /// </summary>
        ALARM_SMOKE_SENSOR                                  = 0x212C,       
        /// <summary>
        /// traffic light fault alarm(struct NET_ALARM_TRAFFIC_LIGHT_FAULT) 
        /// 交通灯故障报警(对应结构体NET_ALARM_TRAFFIC_LIGHT_FAULT)
        /// </summary>
        ALARM_TRAFFIC_LIGHT_FAULT                           = 0x212D,       
        /// <summary>
        /// traffic flux alarm(struct NET_ALARM_TRAFFIC_FLUX_LANE_INFO)
        /// 交通流量统计报警(对应结构体NET_ALARM_TRAFFIC_FLUX_LANE_INFO)
        /// </summary>
        ALARM_TRAFFIC_FLUX_STAT                             = 0x212E,       
        /// <summary>
        /// camera move alarm(struct NET_ALARM_CAMERA_MOVE_INFO)
        /// 摄像机移位报警事件(对应结构体NET_ALARM_CAMERA_MOVE_INFO)
        /// </summary>
        ALARM_CAMERA_MOVE                                   = 0x212F,       
        /// <summary>
        /// detailed motion alarm(struct NET_ALARM_DETAILEDMOTION_CHNL_INFO)
        /// 详细动检报警上报信息(对应结构体NET_ALARM_DETAILEDMOTION_CHNL_INFO)
        /// </summary>
        ALARM_DETAILEDMOTION                                = 0x2130,       
        /// <summary>
        /// storage failure alarm(struct NET_ALARM_STORAGE_FAILURE)
        /// 存储异常报警(对应结构体 NET_ALARM_STORAGE_FAILURE 数组)
        /// </summary>
        ALARM_STORAGE_FAILURE                               = 0x2131,        
        /// <summary>
        /// front IPC disconnect alarm(struct NET_ALARM_FRONTDISCONNET_INFO)
        /// 前端IPC断网报警(对应结构体NET_ALARM_FRONTDISCONNET_INFO)
        /// </summary>
        ALARM_FRONTDISCONNECT                               = 0x2132,        
        /// <summary>
        /// remote external alarm
        /// 远程外部报警(对应结构体 NET_ALARM_REMOTE_ALARM_INFO)
        /// </summary>
        ALARM_ALARM_EX_REMOTE                               = 0x2133,       
        /// <summary>
        /// battery low power alarm(struct NET_ALARM_BATTERYLOWPOWER_INFO)
        /// 电池电量低报警(对应结构体NET_ALARM_BATTERYLOWPOWER_INFO)
        /// </summary>
        ALARM_BATTERYLOWPOWER                               = 0x2134,        
        /// <summary>
        /// temperature alarm(struct NET_ALARM_TEMPERATURE_INFO)
        /// 温度过高报警(对应结构体 NET_ALARM_TEMPERATURE_INFO)
        /// </summary>
        ALARM_TEMPERATURE                                   = 0x2135,       
        /// <summary>
        /// tired drive alarm(struct NET_ALARM_TIREDDRIVE_INFO)
        /// 疲劳驾驶报警(对应结构体NET_ALARM_TIREDDRIVE_INFO)
        /// </summary>
        ALARM_TIREDDRIVE                                    = 0x2136,       
        /// <summary>
        /// Alarm of record loss (corresponding structure NET_ALARM_LOST_RECORD)
        /// 丢录像事件报警(对应结构体NET_ALARM_LOST_RECORD)
        /// </summary>
        ALARM_LOST_RECORD                                   = 0x2137,       
        /// <summary>
        /// Alarm of High CPU Occupancy rate (corresponding structure NET_ALARM_HIGH_CPU) 
        /// CPU占用率过高事件报警(对应结构体 NET_ALARM_HIGH_CPU)
        /// </summary>
        ALARM_HIGH_CPU                                      = 0x2138,       
        /// <summary>
        /// Alarm of net package loss (corresponding structure NET_ALARM_LOST_NETPACKET)
        /// 网络发送数据丢包事件报警(对应结构体 NET_ALARM_LOST_NETPACKET)
        /// </summary>
        ALARM_LOST_NETPACKET                                = 0x2139,       
        /// <summary>
        /// Alarm of high memory occupancy rate(corresponding structure NET_ALARM_HIGH_MEMORY)
        /// 内存占用率过高事件报警(对应结构体NET_ALARM_HIGH_MEMORY)
        /// </summary>
        ALARM_HIGH_MEMORY                                   = 0x213A,       
        /// <summary>
        /// WEB user have no operation for long time (no extended info)
        /// WEB用户长时间无操作事件（无扩展信息）
        /// </summary>
        LONG_TIME_NO_OPERATION	                            = 0x213B,	   
        /// <summary>
        /// blacklist snap(corresponding to NET_BLACKLIST_SNAP_INFO)  
        /// 黑名单车辆抓拍事件(对应结构体NET_BLACKLIST_SNAP_INFO)  
        /// </summary>
        BLACKLIST_SNAP                                      = 0x213C,          
        /// <summary>
        /// alarm of disk(corresponding to NET_ALARM_DISK_INFO)
        /// 硬盘报警(对应 NET_ALARM_DISK_INFO 数组)
        /// </summary>
        ALARM_DISK				                            = 0x213E,		
        /// <summary>
        /// alarm of file systemcorresponding to NET_ALARM_FILE_SYSTEM_INFO)
        /// 文件系统报警(对应NET_ALARM_FILE_SYSTEM_INFO数组)
        /// </summary>
        ALARM_FILE_SYSTEM		                            = 0x213F,		
        /// <summary>
        /// alarm of ivs(corresponding to NET_ALARM_IVS_INFO)
        /// 智能报警事件(对应结构体NET_ALARM_IVS_INFO)
        /// </summary>
        ALARM_IVS                                           = 0x2140,       
        /// <summary>
        /// goods weight (corresponding to NET_ALARM_GOODS_WEIGHT_UPLOAD_INFO)
        /// 货重信息上报(对应NET_ALARM_GOODS_WEIGHT_UPLOAD_INFO)
        /// </summary>
        ALARM_GOODS_WEIGHT_UPLOAD                           = 0x2141,		
        /// <summary>
        /// alarm of goods weight(corresponding to NET_ALARM_GOODS_WEIGHT_INFO)
        /// 货重信息报警(对应NET_ALARM_GOODS_WEIGHT_INFO)
        /// </summary>
        ALARM_GOODS_WEIGHT		                            = 0x2142,		
        /// <summary>
        /// GPS orientation info(corresponding to NET_GPS_STATUS_INFO)
        /// GPS定位信息(对应 NET_GPS_STATUS_INFO)
        /// </summary>
        GPS_STATUS                                          = 0x2143,       
        /// <summary>
        /// alarm disk burned full(corresponding to NET_ALARM_DISKBURNED_FULL_INFO)
        /// 硬盘刻录满报警(对应 NET_ALARM_DISKBURNED_FULL_INFO)
        /// </summary>
        ALARM_DISKBURNED_FULL                               = 0x2144,       
        /// <summary>
        /// storage low space(corresponding to NET_ALARM_STORAGE_LOW_SPACE_INFO)
        /// 存储容量不足事件(对应NET_ALARM_STORAGE_LOW_SPACE_INFO)
        /// </summary>
        ALARM_STORAGE_LOW_SPACE	                            = 0x2145,		
        /// <summary>
        /// disk flux abnormal(corresponding to NET_ALARM_DISK_FLUX)
        /// 硬盘数据异常事件(对应 NET_ALARM_DISK_FLUX)
        /// </summary>
        ALARM_DISK_FLUX			                            = 0x2160,		
        /// <summary>
        /// net flux abnormal(corresponding to NET_ALARM_NET_FLUX)
        /// 网络数据异常事件(对应 NET_ALARM_NET_FLUX)
        /// </summary>
        ALARM_NET_FLUX			                            = 0x2161,		
        /// <summary>
        /// fan speed abnormal(corresponding to NET_ALARM_FAN_SPEED)
        /// 风扇转速异常事件(对应 NET_ALARM_FAN_SPEED)
        /// </summary>
        ALARM_FAN_SPEED			                            = 0x2162,		
        /// <summary>
        /// storage mistake(corresponding to NET_ALARM_STORAGE_FAILURE_EX)
        /// 存储错误报警(对应结构体NET_ALARM_STORAGE_FAILURE_EX)
        /// </summary>
        ALARM_STORAGE_FAILURE_EX                            = 0x2163,       
        /// <summary>
        /// record abnormal(corresponding to NET_ALARM_RECORD_FAILED_INFO)
        /// 录像异常报警(对应结构体NET_ALARM_RECORD_FAILED_INFO)
        /// </summary>
        ALARM_RECORD_FAILED		                            = 0x2164,		
        /// <summary>
        /// storage break down(corresponding to NET_ALARM_STORAGE_BREAK_DOWN_INFO)
        /// 存储崩溃事件(对应结构体 NET_ALARM_STORAGE_BREAK_DOWN_INFO)
        /// </summary>
        ALARM_STORAGE_BREAK_DOWN	                        = 0x2165,		
        /// <summary>
        /// NET_ALARM_VIDEO_ININVALID_INFO
        /// 视频输入通道失效事件（例：配置的视频输入通道码流,超出设备处理能力）NET_ALARM_VIDEO_ININVALID_INFO
        /// </summary>
        ALARM_VIDEO_ININVALID                               = 0x2166,       
        /// <summary>
        /// vehicle turnover arm event(struct NET_ALARM_VEHICEL_TURNOVER_EVENT_INFO)
        /// 车辆侧翻报警事件(对应结构体NET_ALARM_VEHICEL_TURNOVER_EVENT_INFO)
        /// </summary>
        ALARM_VEHICLE_TURNOVER	                            = 0x2167,		 
        /// <summary>
        /// vehicle collision event(struct NET_ALARM_VEHICEL_COLLISION_EVENT_INFO)
        /// 车辆撞车报警事件(对应结构体NET_ALARM_VEHICEL_COLLISION_EVENT_INFO)
        /// </summary>
        ALARM_VEHICLE_COLLISION	                            = 0x2168,        
        /// <summary>
        /// vehicle confirm information event(struct NET_ALARM_VEHICEL_CONFIRM_INFO)
        /// 车辆上传信息事件(对应结构体NET_ALARM_VEHICEL_CONFIRM_INFO)
        /// </summary>
        ALARM_VEHICLE_CONFIRM                               = 0x2169,        
        /// <summary>
        /// vehicle camero large angle event(struct NET_ALARM_VEHICEL_LARGE_ANGLE)
        /// 车载摄像头大角度扭转事件(对应结构体NET_ALARM_VEHICEL_LARGE_ANGLE)
        /// </summary>
        ALARM_VEHICLE_LARGE_ANGLE                           = 0x2170,        
        /// <summary>
        /// device talking invite event (struct NET_ALARM_TALKING_INVITE_INFO)
        /// 设备请求对方发起对讲事件(对应结构体NET_ALARM_TALKING_INVITE_INFO)
        /// </summary>
        ALARM_TALKING_INVITE		                        = 0x2171,		
        /// <summary>
        /// local alarm event (struct NET_ALARM_ALARM_INFO_EX2)
        /// 本地报警事件(对应结构体 NET_ALARM_ALARM_INFO_EX2)
        /// </summary>
        ALARM_ALARM_EX2			                            = 0x2175,		
        /// <summary>
        /// video timing detecting event(struct NET_ALARM_VIDEO_TIMING)
        /// 视频定时检测事件(对应结构体NET_ALARM_VIDEO_TIMING)
        /// </summary>
        ALARM_VIDEO_TIMING                                  = 0x2176,       
        /// <summary>
        /// COM event(struct NET_ALARM_COMM_PORT_EVENT_INFO)
        /// 串口事件(对应结构体NET_ALARM_COMM_PORT_EVENT_INFO)
        /// </summary>
        ALARM_COMM_PORT			                            = 0x2177,       
        /// <summary>
        /// audio anomaly event(struct NET_ALARM_AUDIO_ANOMALY)
        /// 音频异常事件(对应结构体NET_ALARM_AUDIO_ANOMALY)
        /// </summary>
        ALARM_AUDIO_ANOMALY                                 = 0x2178,       
        /// <summary>
        /// audio mutation event(struct NET_ALARM_AUDIO_MUTATION)
        /// 声强突变事件(对应结构体NET_ALARM_AUDIO_MUTATION)
        /// </summary>
        ALARM_AUDIO_MUTATION                                = 0x2179,       
        /// <summary>
        /// Tyre information report event (struct NET_EVENT_TYRE_INFO)
        /// 轮胎信息上报事件(对应结构体NET_EVENT_TYRE_INFO)
        /// </summary>
        EVENT_TYREINFO                                      = 0x2180,       
        /// <summary>
        /// Redundant power supplies abnormal alarm(struct NET_ALARM_POWER_ABNORMAL_INFO)
        /// 冗余电源异常报警(对应结构体NET_ALARM_POWER_ABNORMAL_INFO)
        /// </summary>
        ALARM_POWER_ABNORMAL                                = 0X2181,       
        /// <summary>
        /// On-board equipment active offline events(struct  NET_EVENT_REGISTER_OFF_INFO)
        /// 车载设备主动下线事件(对应结构体 NET_EVENT_REGISTER_OFF_INFO)
        /// </summary>
        EVENT_REGISTER_OFF		                            = 0x2182,		
        /// <summary>
        /// No hard disk alarm(struct NET_ALARM_NO_DISK_INFO)
        /// 无硬盘报警(对应结构体NET_ALARM_NO_DISK_INFO)
        /// </summary>
        ALARM_NO_DISK                                       = 0x2183,       
        /// <summary>
        /// The fall alarm(struct NET_ALARM_FALLING_INFO)
        /// 跌落事件报警(对应结构体NET_ALARM_FALLING_INFO)
        /// </summary>
        ALARM_FALLING                                       = 0x2184,       
        /// <summary>
        /// Protective capsule event(corresponding structure NET_ALARM_PROTECTIVE_CAPSULE_INFO)
        /// 防护舱事件(对应结构体NET_ALARM_PROTECTIVE_CAPSULE_INFO)
        /// </summary>
        ALARM_PROTECTIVE_CAPSULE                            = 0x2185,       
        /// <summary>
        /// Call Non-response alarm(corresponding to NET_ALARM_NO_RESPONSE_INFO)
        /// 呼叫未应答警报(对应结构体NET_ALARM_NO_RESPONSE_INFO)
        /// </summary>
        ALARM_NO_RESPONSE                                   = 0x2186,       
        /// <summary>
        /// Config enable to change reported event(corresponding to structure  NET_ALARM_CONFIG_ENABLE_CHANGE_INFO)
        /// 配置使能改变上报事件(对应结构体 NET_ALARM_CONFIG_ENABLE_CHANGE_INFO)
        /// </summary>
        ALARM_CONFIG_ENABLE_CHANGE                          = 0x2187,       
        /// <summary>
        /// Cross warning line event( Corresponding to structure NET_ALARM_EVENT_CROSSLINE_INFO )
        /// 警戒线事件( 对应结构体 NET_ALARM_EVENT_CROSSLINE_INFO )
        /// </summary>
        EVENT_CROSSLINE_DETECTION                           = 0x2188,       
        /// <summary>
        /// Warning zone event(Corresponding to structure NET_ALARM_EVENT_CROSSREGION_INFO )
        /// 警戒区事件( 对应结构体 NET_ALARM_EVENT_CROSSREGION_INFO )
        /// </summary>
        EVENT_CROSSREGION_DETECTION                         = 0x2189,       
        /// <summary>
        /// Abandoned object event(Corresponding to structure NET_ALARM_EVENT_LEFT_INFO )
        /// 物品遗留事件( 对应结构体 NET_ALARM_EVENT_LEFT_INFO )
        /// </summary>
        EVENT_LEFT_DETECTION                                = 0x218a,        
        /// <summary>
        /// Human face detect event(Corresponding to structure NET_ALARM_EVENT_FACE_INFO ) 
        /// 人脸检测事件( 对应结构体 NET_ALARM_EVENT_FACE_INFO )
        /// </summary>
        EVENT_FACE_DETECTION                                = 0x218b,      
        /// <summary>
        /// IPC alarm,IPC upload local alarm via DVR or NVR(Corresponding to structure NET_ALARM_IPC_INFO)
        /// IPC报警,IPC通过DVR或NVR上报的本地报警(对应结构体 NET_ALARM_IPC_INFO)
        /// </summary>
        ALARM_IPC                                           = 0x218c,        
        /// <summary>
        /// Missing object event(Corresponding to structure NET_ALARM_TAKENAWAY_DETECTION_INFO)
        /// 物品搬移事件(对应结构体 NET_ALARM_TAKENAWAY_DETECTION_INFO)
        /// </summary>
        EVENT_TAKENAWAYDETECTION                            = 0x218d,      
        /// <summary>
        /// Video abnormal event(Corresponding to structure NET_ALARM_VIDEOABNORMAL_DETECTION_INFO)
        /// 视频异常事件(对应结构体 NET_ALARM_VIDEOABNORMAL_DETECTION_INFO)
        /// </summary>
        EVENT_VIDEOABNORMALDETECTION                        = 0x218e,       
        /// <summary>
        /// Video motion detect event  (Corresponding to structure NET_ALARM_MOTIONDETECT_INFO)
        /// 视频移动侦测事件(对应结构体 NET_ALARM_MOTIONDETECT_INFO)
        /// </summary>
        EVENT_MOTIONDETECT                                  = 0x218f,       
        /// <summary>
        /// PIR alarm (Corresponding to BYTE*, pBuf length dwBufLen)
        /// PIR警报(对应BYTE*, pBuf长度dwBufLen)
        /// </summary>
        ALARM_PIR                                           = 0x2190,       
        /// <summary>
        /// Storage hot swap event(Corresponding to structure NET_ALARM_STORAGE_HOT_PLUG_INFO)
        /// 存储热插拔事件(对应结构体 NET_ALARM_STORAGE_HOT_PLUG_INFO)
        /// </summary>
        ALARM_STORAGE_HOT_PLUG                              = 0x2191,       
        /// <summary>
        /// the event of rate of flow(Corresponding to structure NET_ALARM_FLOW_RATE_INFO)
        /// 流量使用情况事件(对应结构体 NET_ALARM_FLOW_RATE_INFO)
        /// </summary>
        ALARM_FLOW_RATE				                        = 0x2192,		
        /// <summary>
        /// Move detection event(Corresponding to structure NET_ALARM_MOVE_DETECTION_INFO)
        /// 移动事件(对应NET_ALARM_MOVE_DETECTION_INFO)
        /// </summary>
        ALARM_MOVEDETECTION			                        = 0x2193,		
        /// <summary>
        /// WanderDetection event(Corresponding to structure NET_ALARM_WANDERDETECTION_INFO)
        /// 徘徊事件(对应NET_ALARM_WANDERDETECTION_INFO)
        /// </summary>
        ALARM_WANDERDETECTION		                        = 0x2194,		
        /// <summary>
        /// cross fence(Corresponding to NET_ALARM_CROSSFENCEDETECTION_INFO)
        /// 翻越围栏事件(对应NET_ALARM_CROSSFENCEDETECTION_INFO)
        /// </summary>
        ALARM_CROSSFENCEDETECTION	                        = 0x2195,		 
        /// <summary>
        /// parking detection event(Corresponding to NET_ALARM_PARKINGDETECTION_INFO)
        /// 非法停车事件(对应NET_ALARM_PARKINGDETECTION_INFO)
        /// </summary>
        ALARM_PARKINGDETECTION                              = 0x2196,		
        /// <summary>
        /// Rioter detection event(Corresponding to NET_ALARM_RIOTERDETECTION_INFO)
        /// 人员聚集事件(对应NET_ALARM_RIOTERDETECTION_INFO)
        /// </summary>
        ALARM_RIOTERDETECTION		                        = 0x2197,		
        /// <summary>
        /// A storage group does not exist(struct NET_ALARM_STORAGE_NOT_EXIST_INFO)
        /// 存储组不存在事件(对应结构体 NET_ALARM_STORAGE_NOT_EXIST_INFO)
        /// </summary>
        ALARM_STORAGE_NOT_EXIST                             = 0x3167,		
        /// <summary>
        /// Network fault event(struct NET_ALARM_NETABORT_INFO)
        /// 网络故障事件(对应结构体 NET_ALARM_NETABORT_INFO)
        /// </summary>
        ALARM_NET_ABORT			                            = 0x3169,		
        /// <summary>
        /// IP conflict event(struct NET_ALARM_IP_CONFLICT_INFO)
        /// IP冲突事件(对应结构体 NET_ALARM_IP_CONFLICT_INFO)
        /// </summary>
        ALARM_IP_CONFLICT		                            = 0x3170,	    
        /// <summary>
        /// MAC conflict event(struct NET_ALARM_MAC_CONFLICT_INFO)
        /// MAC冲突事件(对应结构体 NET_ALARM_MAC_CONFLICT_INFO)
        /// </summary>
        ALARM_MAC_CONFLICT		                            = 0x3171,		
        /// <summary>
        /// power fault event(struct NET_ALARM_POWERFAULT_INFO)
        /// 电源故障事件(对应结构体NET_ALARM_POWERFAULT_INFO)
        /// </summary>
        ALARM_POWERFAULT		                            = 0x3172,		
        /// <summary>
        /// Chassis intrusion, tamper alarm events(struct NET_ALARM_CHASSISINTRUDED_INFO)
        /// 机箱入侵(防拆)报警事件(对应结构体NET_ALARM_CHASSISINTRUDED_INFO)
        /// </summary>
        ALARM_CHASSISINTRUDED	                            = 0x3173,		
        /// <summary>
        /// Native extension alarm events(struct NET_ALARM_ALARMEXTENDED_INFO)
        /// 本地扩展报警事件(对应结构体 NET_ALARM_ALARMEXTENDED_INFO)
        /// </summary>
        ALARM_ALARMEXTENDED		                            = 0x3174,		
        /// <summary>
        /// Cloth removal state change events(struct NET_ALARM_ARMMODE_CHANGE_INFO)
        /// 布撤防状态变化事件(对应结构体NET_ALARM_ARMMODE_CHANGE_INFO)
        /// </summary>
        ALARM_ARMMODE_CHANGE_EVENT		                    = 0x3175,		
        /// <summary>
        /// The bypass state change events(struct NET_ALARM_BYPASSMODE_CHANGE_INFO)
        /// 旁路状态变化事件(对应结构体NET_ALARM_BYPASSMODE_CHANGE_INFO)
        /// </summary>
        ALARM_BYPASSMODE_CHANGE_EVENT	                    = 0x3176,		
        /// <summary>
        /// Entrance guard did not close events(struct NET_ALARM_ACCESS_CTL_NOT_CLOSE_INFO)
        /// 门禁未关事件(对应结构体NET_ALARM_ACCESS_CTL_NOT_CLOSE_INFO)
        /// </summary>
        ALARM_ACCESS_CTL_NOT_CLOSE		                    = 0x3177,		
        /// <summary>
        /// break-in event(struct NET_ALARM_ACCESS_CTL_BREAK_IN_INFO)
        /// 闯入事件(对应结构体NET_ALARM_ACCESS_CTL_BREAK_IN_INFO)
        /// </summary>
        ALARM_ACCESS_CTL_BREAK_IN		                    = 0x3178,		
        /// <summary>
        /// access Again and again event(struct NET_ALARM_ACCESS_CTL_REPEAT_ENTER_INFO)
        /// 反复进入事件(对应结构体NET_ALARM_ACCESS_CTL_REPEAT_ENTER_INFO)
        /// </summary>
        ALARM_ACCESS_CTL_REPEAT_ENTER	                    = 0x3179,		
        /// <summary>
        /// Stress CARDS event(struct NET_ALARM_ACCESS_CTL_DURESS_INFO)
        /// 胁迫卡刷卡事件(对应结构体NET_ALARM_ACCESS_CTL_DURESS_INFO)
        /// </summary>
        ALARM_ACCESS_CTL_DURESS			                    = 0x3180,		
        /// <summary>
        /// Access event(struct NET_ALARM_ACCESS_CTL_EVENT_INFO)
        /// 门禁事件(对应结构体 NET_ALARM_ACCESS_CTL_EVENT_INFO)
        /// </summary>
        ALARM_ACCESS_CTL_EVENT			                    = 0x3181,		
        /// <summary>
        /// Emergency ALARM EX2(struct NET_ALARM_URGENCY_ALARM_EX2), Artificially triggered emergency, general processing is linked external communication function requests for help
        /// 紧急报警EX2(对应结构体NET_ALARM_URGENCY_ALARM_EX2), 人为触发的紧急事件, 一般处理是联动外部通讯功能请求帮助
        /// </summary>
        URGENCY_ALARM_EX2                                   = 0x3182,       
        /// <summary>
        /// Alarm input source signal events (as long as there is input will generate the event, whether to play the current mode, unable to block, struct NET_ALARM_INPUT_SOURCE_SIGNAL_INFO)
        /// 报警输入源信号事件(只要有输入就会产生该事件, 不论防区当前的模式,无法屏蔽, 对应 NET_ALARM_INPUT_SOURCE_SIGNAL_INFO )
        /// </summary>
        ALARM_INPUT_SOURCE_SIGNAL                           = 0x3183,       
        /// <summary>
        /// analog alarm(struct NET_ALARM_ANALOGALARM_EVENT_INFO)
        /// 模拟量报警输入通道事件(对应结构体NET_ALARM_ANALOGALARM_EVENT_INFO)
        /// </summary>
        ALARM_ANALOGALARM_EVENT                             = 0x3184,        
        /// <summary>
        /// Access control status event(corresponding structure NET_ALARM_ACCESS_CTL_STATUS_INFO)
        /// 门禁状态事件(对应结构体NET_ALARM_ACCESS_CTL_STATUS_INFO)
        /// </summary>
        ALARM_ACCESS_CTL_STATUS                             = 0x3185,        
        /// <summary>
        /// Access control snapshot event(corresponding to NET_ALARM_ACCESS_SNAP_INFO)
        /// 门禁抓图事件(对应结构体NET_ALARM_ACCESS_SNAP_INFO)
        /// </summary>
        ALARM_ACCESS_SNAP                                   = 0x3186,      
        /// <summary>
        /// Cancel alarm(corresponding to structure NET_ALARM_ALARMCLEAR_INFO)
        /// 消警事件(对应结构体NET_ALARM_ALARMCLEAR_INFO)
        /// </summary>
        ALARM_ALARMCLEAR                                    = 0x3187,      
        /// <summary>
        /// CID event(corresponding to structure NET_ALARM_CIDEVENT_INFO)
        /// CID事件(对应结构体 NET_ALARM_CIDEVENT_INFO)
        /// </summary>
        ALARM_CIDEVENT                                      = 0x3188,        
        /// <summary>
        /// Device hand up evnt(corresponding to structure NET_ALARM_TALKING_HANGUP_INFO)
        /// 设备主动挂断对讲事件(对应结构体NET_ALARM_TALKING_HANGUP_INFO)
        /// </summary>
        ALARM_TALKING_HANGUP                                = 0x3189,       
        /// <summary>
        /// Bank card evnt(corresponding to structure NET_ALARM_BANKCARDINSERT_INFO)
        /// 银行卡插卡事件(对应结构体NET_ALARM_BANKCARDINSERT_INFO)
        /// </summary>
        ALARM_BANKCARDINSERT                                = 0x318a,      
        /// <summary>
        /// Emergency call alarm event(corresponding to structure NET_ALARM_RCEMERGENCY_CALL_INFO)
        /// 紧急呼叫报警事件(对应结构体 NET_ALARM_RCEMERGENCY_CALL_INFO)
        /// </summary>
        ALARM_RCEMERGENCY_CALL                              = 0x318b,       
        /// <summary>
        /// Multi-people group unlock event(corresponding to  structure NET_ALARM_OPEN_DOOR_GROUP_INFO)
        /// 多人组合开门事件(对应结构体NET_ALARM_OPEN_DOOR_GROUP_INFO)
        /// </summary>
        ALARM_OPENDOORGROUP                                 = 0x318c,       
        /// <summary>
        /// get fingerprint event(corresponding to  structure NET_ALARM_CAPTURE_FINGER_PRINT_INFO)
        /// 获取指纹事件(对应结构体NET_ALARM_CAPTURE_FINGER_PRINT_INFO)
        /// </summary>
        ALARM_FINGER_PRINT                                  = 0x318d,       
        /// <summary>
        /// card no. record event(corresponding to  structure  NET_ALARM_CARD_RECORD_INFO)
        /// 卡号录像事件(对应结构体 NET_ALARM_CARD_RECORD_INFO)
        /// </summary>
        ALARM_CARD_RECORD                                   = 0x318e,       
        /// <summary>
        /// sub system status change event(corresponding to  structure NET_ALARM_SUBSYSTEM_STATE_CHANGE_INFO)
        /// 子系统状态改变事件(对应结构体NET_ALARM_SUBSYSTEM_STATE_CHANGE_INFO)
        /// </summary>
        ALARM_SUBSYSTEM_STATE_CHANGE                        = 0x318f,       
        /// <summary>
        /// battery scheduled warning event(corresponding to  structure NET_ALARM_BATTERYPOWER_INFO)
        /// 电池电量定时通知事件(对应结构体NET_ALARM_BATTERYPOWER_INFO)
        /// </summary>
        ALARM_BATTERYPOWER_EVENT                            = 0x3190,       
        /// <summary>
        /// bell status event(corresponding to  structure NET_ALARM_BELLSTATUS_INFO)
        /// 警号状态事件(对应结构体NET_ALARM_BELLSTATUS_INFO)
        /// </summary>
        ALARM_BELLSTATUS_EVENT                              = 0x3191,       
        /// <summary>
        /// zone status change event(corresponding to  structure NET_ALARM_DEFENCE_STATUS_CHANGE_INFO),customized need￡?and arm/disarm change event, bypass event status have different definitions,The status CLIENT_QueryDevState function NET_DEVSTATE_DEFENCE_STATE command get
        /// 防区状态变化事件(对应结构体ALARM_DEFENCE_STATUS_CHANGE_INFO),定制需求,和布防撤防变化事件、旁路状态变化事件中的状态定义不同,该状态通过CLIENT_QueryDevState()接口的NET_DEVSTATE_DEFENCE_STATE命令获取
        /// </summary>
        ALARM_DEFENCE_STATE_CHANGE_EVENT                    = 0x3192,        
        /// <summary>
        /// ticket statistics info event(corresponding to  structure  NET_ALARM_TICKET_STATISTIC)
        /// 车票统计信息事件(对应结构体 NET_ALARM_TICKET_STATISTIC)
        /// </summary>
        ALARM_TICKET_STATISTIC                              = 0x3193,       
        /// <summary>
        /// login failed event(corresponding to  structure NET_ALARM_LOGIN_FAILIUR_INFO)
        /// 登陆失败事件(对应结构体NET_ALARM_LOGIN_FAILIUR_INFO)
        /// </summary>
        ALARM_LOGIN_FAILIUR                                 = 0x3194,        
        /// <summary>
        /// expansion module offline event(corresponding to  structure  NET_ALARM_MODULE_LOST_INFO)
        /// 扩展模块掉线事件(对应结构体 NET_ALARM_MODULE_LOST_INFO)
        /// </summary>
        ALARM_MODULE_LOST                                   = 0x3195,        
        /// <summary>
        /// PSTN offline event(corresponding to  structure NET_ALARM_PSTN_BREAK_LINE_INFO)
        /// PSTN掉线事件(对应结构体NET_ALARM_PSTN_BREAK_LINE_INFO)
        /// </summary>
        ALARM_PSTN_BREAK_LINE                               = 0x3196,       
        /// <summary>
        /// analog alarm evnet(instant event), specific sensor  trigger(corresponding to  structure NET_ALARM_ANALOGPULSE_INFO)
        /// 模拟量报警事件(瞬时型事件), 特定传感器类型时才触发(对应结构体NET_ALARM_ANALOGPULSE_INFO)
        /// </summary>
        ALARM_ANALOG_PULSE                                  = 0x3197,       
        /// <summary>
        /// task confirmation event(corresponding to  structure  NET_ALARM_MISSION_CONFIRM_INFO)
        /// 任务确认事件(对应结构体 任务确认事件(对应结构体 NET_ALARM_MISSION_CONFIRM_INFO))
        /// </summary>
        ALARM_MISSION_CONFIRM                               = 0x3198,      
        /// <summary>
        /// device to platform notice event?t(corresponding to  structure  NET_ALARM_DEVICE_MSG_NOTIFY_INFO)
        /// 设备向平台发通知的事件(对应结构体 NET_ALARM_DEVICE_MSG_NOTIFY_INFO)
        /// </summary>
        ALARM_DEVICE_MSG_NOTIFY                             = 0x3199,       
        /// <summary>
        /// parking timeout event(corresponding to  structure  NET_ALARM_VEHICLE_STANDING_OVER_TIME_INFO)
        /// 停车超时报警(对应结构体 NET_ALARM_VEHICLE_STANDING_OVER_TIME_INFO)
        /// </summary>
        ALARM_VEHICLE_STANDING_OVER_TIME                    = 0x319A,      
        /// <summary>
        /// e-fence event(corresponding to  structure  NET_ALARM_ENCLOSURE_ALARM_INFO)
        /// 电子围栏事件(对应结构体 NET_ALARM_ENCLOSURE_ALARM_INFO)
        /// </summary>
        ALARM_ENCLOSURE_ALARM                               = 0x319B,        
        /// <summary>
        /// station detection event, one in station first report the start event and last on in station report stop event before leave (corresponding to  structure NET_ALARM_GUARD_DETECT_INFO)
        /// 岗亭检测事件,此事件岗亭有第一个人时上报start事件,岗亭最后一个人离开时上报stop 事件(对应结构体NET_ALARM_GUARD_DETECT_INFO)
        /// </summary>
        ALARM_GUARD_DETECT			                        = 0x319C,	    
        /// <summary>
        /// station info update event￡?report if people in station(corresponding to  structure NET_ALARM_GUARD_UPDATE_INFO)
        /// 岗亭信息更新事件,只要岗亭有人员出入就上报(对应结构体NET_ALARM_GUARD_UPDATE_INFO)  
        /// </summary>
        ALARM_GUARD_INFO_UPDATE		                        = 0x319D,	    
        /// <summary>
        /// Node activation event (corresponding to structure NET_ALARM_NODE_ACTIVE_INFO)
        /// 节点激活事件(对应结构体NET_ALARM_NODE_ACTIVE_INFO)
        /// </summary>
        ALARM_NODE_ACTIVE                                   = 0x319E,        
        /// <summary>
        /// Video static detection event (corresponding to structure NET_ALARM_VIDEO_STATIC_INFO)
        /// 视频静态检测事件(对应结构体 NET_ALARM_VIDEO_STATIC_INFO)
        /// </summary>
        ALARM_VIDEO_STATIC                                  = 0x319F,       
        /// <summary>
        /// Active registration device re-login event (corresponding to structure NET_ALARM_REGISTER_REONLINE_INFO)
        /// 主动注册设备重新登陆事件(对应结构体NET_ALARM_REGISTER_REONLINE_INFO)
        /// </summary>
        ALARM_REGISTER_REONLINE                             = 0x31a0,        
        /// <summary>
        /// ISCSI alarm event (corresponding to structure NET_ALARM_ISCSI_STATUS_INFO)
        /// ISCSI告警事件(对应结构体 NET_ALARM_ISCSI_STATUS_INFO)
        /// </summary>
        ALARM_ISCSI_STATUS                                  = 0x31a1,       
        /// <summary>
        /// detection collection device alarm event (corresponding to structure NET_ALARM_SCADA_DEV_INFO)
        /// 检测采集设备报警事件(对应结构体 NET_ALARM_SCADA_DEV_INFO)
        /// </summary>
        ALARM_SCADA_DEV_ALARM                               = 0x31a2,       
        /// <summary>
        /// Sub device status(corresponding structure NET_ALARM_AUXILIARY_DEV_STATE)
        /// 辅助设备状态(对应结构体NET_ALARM_AUXILIARY_DEV_STATE)
        /// </summary>
        ALARM_AUXILIARY_DEV_STATE                           = 0x31a3,      
        /// <summary>
        /// Parking swipe card event(corresponding structure NET_ALARM_PARKING_CARD)
        /// 停车刷卡事件(对应结构体NET_ALARM_PARKING_CARD)
        /// </summary>
        ALARM_PARKING_CARD                                  = 0x31a4,        
        /// <summary>
        /// Alarm transmit event(corresponding structure NET_ALARM_PROFILE_ALARM_TRANSMIT_INFO)
        /// 报警传输事件(对应结构体NET_ALARM_PROFILE_ALARM_TRANSMIT_INFO)
        /// </summary>
        ALARM_PROFILE_ALARM_TRANSMIT                        = 0x31a5,        
        /// <summary>
        /// Vehicle acc event(corresponding structure NET_ALARM_VEHICLE_ACC_INFO)
        /// 车辆ACC报警事件(对应结构体 NET_ALARM_VEHICLE_ACC_INFO)
        /// </summary>
        ALARM_VEHICLE_ACC                                   = 0x31a6,       
        /// <summary>
        /// suspiciouscar event(corresponding structure NET_ALARM_TRAFFIC_SUSPICIOUSCAR_INFO)
        /// 嫌疑车辆上报事件(对应结构体 NET_ALARM_TRAFFIC_SUSPICIOUSCAR_INFO)
        /// </summary>
        ALARM_TRAFFIC_SUSPICIOUSCAR                         = 0x31a7,       
        /// <summary>
        /// the event of latch state (corresponding structure  NET_ALARM_ACCESS_LOCK_STATUS_INFO)
        /// 门锁状态事件(对应结构体 NET_ALARM_ACCESS_LOCK_STATUS_INFO)
        /// </summary>
        ALARM_ACCESS_LOCK_STATUS                            = 0x31a8,       
        /// <summary>
        /// Finace scheme event(corresponding structure NET_ALARM_FINACE_SCHEME_INFO)
        /// 理财经办事件(对应结构体 NET_ALARM_FINACE_SCHEME_INFO)
        /// </summary>
        ALARM_FINACE_SCHEME                                 = 0x31a9,       
        /// <summary>
        /// Thermal temperature abnormal event alarm(Corresponding to structure NET_ALARM_HEATIMG_TEMPER_INFO)
        /// 热成像测温点温度异常报警事件(对应结构体 NET_ALARM_HEATIMG_TEMPER_INFO)
        /// </summary>
        ALARM_HEATIMG_TEMPER                                = 0x31aa,        
        /// <summary>
        /// Device cancel bidirectional talk query event(Corresponding to structure NET_ALARM_TALKING_IGNORE_INVITE_INFO)
        /// 设备取消对讲请求事件(对应结构体NET_ALARM_TALKING_IGNORE_INVITE_INFO)
        /// </summary>
        ALARM_TALKING_IGNORE_INVITE                         = 0x31ab,       
        /// <summary>
        /// Vehicle Abrupt-turn event(Corresponding to structure NET_ALARM_BUS_SHARP_TURN_INFO)
        /// 车辆急转事件(对应结构体NET_ALARM_BUS_SHARP_TURN_INFO)
        /// </summary>
        ALARM_BUS_SHARP_TURN                                = 0x31ac,        
        /// <summary>
        /// vehicle abrupt stop event(Corresponding to structure NET_ALARM_BUS_SCRAM_INFO)
        /// 车辆急停事件(对应结构体NET_ALARM_BUS_SCRAM_INFO)
        /// </summary>
        ALARM_BUS_SCRAM                                     = 0x31ad,      
        /// <summary>
        /// Vehicle abrupt speed up event(Corresponding to structure NET_ALARM_BUS_SHARP_ACCELERATE_INFO)
        /// 车辆急加速事件(对应结构体NET_ALARM_BUS_SHARP_ACCELERATE_INFO)
        /// </summary>
        ALARM_BUS_SHARP_ACCELERATE                          = 0x31ae,       
        /// <summary>
        /// Vehicle abrupt slow down event (Corresponding to structure NET_ALARM_BUS_SHARP_DECELERATE_INFO)
        /// 车辆急减速事件(对应结构体NET_ALARM_BUS_SHARP_DECELERATE_INFO)
        /// </summary>
        ALARM_BUS_SHARP_DECELERATE                          = 0x31af,      
        /// <summary>
        /// A&C data operation event (Corresponding to structure NET_ALARM_ACCESS_CARD_OPERATE_INFO)
        /// 门禁卡数据操作事件(对应结构体NET_ALARM_ACCESS_CARD_OPERATE_INFO)
        /// </summary>
        ALARM_ACCESS_CARD_OPERATE                           = 0x31b0,		
        /// <summary>
        /// Policeman check in event(Corresponding to structure NET_ALARM_POLICE_CHECK_INFO)
        /// 警员签到事件(对应结构体NET_ALARM_POLICE_CHECK_INFO)
        /// </summary>
        ALARM_POLICE_CHECK                                  = 0x31b1,       
        /// <summary>
        /// Network alarm event(Corresponding to structure NET_ALARM_NET_INFO)
        /// 网络报警事件(对应结构体 NET_ALARM_NET_INFO)
        /// </summary>
        ALARM_NET                                           = 0x31b2,       
        /// <summary>
        /// New file event(Corresponding to structure NET_ALARM_NEW_FILE_INFO)
        /// 新文件事件(对应结构体NET_ALARM_NEW_FILE_INFO)
        /// </summary>
        ALARM_NEW_FILE                                      = 0x31b3,       
        /// <summary>
        /// Thermal fire position (Corresponding to structure NET_ALARM_FIREWARNING_INFO)
        /// 热成像着火点事件 (对应结构体 NET_ALARM_FIREWARNING_INFO)
        /// </summary>
        ALARM_FIREWARNING                                   = 0x31b5,       
        /// <summary>
        /// Record loss event: the HDD is OK, delete results from misoperation.  (Corresponding to structure NET_ALARM_RECORD_LOSS_INFO)
        /// 录像丢失事件,指硬盘完好的情况下,发生误删等原因引起(对应结构体NET_ALARM_RECORD_LOSS_INFO)
        /// </summary>
        ALARM_RECORD_LOSS                                   = 0x31b6,       
        /// <summary>
        /// Frame loss event，it results from poor network environment or insufficient encode capability (Corresponding to structure NET_ALARM_VIDEO_FRAME_LOSS_INFO)
        /// 视频丢帧事件,比如网络不好或编码能力不足引起的丢帧(对应结构体NET_ALARM_VIDEO_FRAME_LOSS_INFO)
        /// </summary>
        ALARM_VIDEO_FRAME_LOSS                              = 0x31b7,       
        /// <summary>
        /// Abnormal record results from HDD volume(Corresponding to structure NET_ALARM_RECORD_VOLUME_FAILURE_INFO)
        /// 由保存录像的磁盘卷发生异常,引起的录像异常(对应结构体 NET_ALARM_RECORD_VOLUME_FAILURE_INFO)
        /// </summary>
        ALARM_RECORD_VOLUME_FAILURE                         = 0x31b8,       
        /// <summary>
        /// Image upload completion event(Corresponding to structure NET_EVENT_SNAP_UPLOAD_INFO)
        /// 图上传完成事件(对应结构体NET_EVENT_SNAP_UPLOAD_INFO)
        /// </summary>
        EVENT_SNAP_UPLOAD                                   = 0X31b9,        
        /// <summary>
        /// Audio detect event(Corresponding to structure NET_ALARM_AUDIO_DETECT )
        /// 音频检测事件(对应结构体 NET_ALARM_AUDIO_DETECT )
        /// </summary>
        ALARM_AUDIO_DETECT                                  = 0x31ba,       
        /// <summary>
        /// Failure data amount during the image upload process （Corresponding to structure NET_ALARM_UPLOADPIC_FAILCOUNT_INFO）
        /// 上传中盟失败数据个数（对应结构体NET_ALARM_UPLOADPIC_FAILCOUNT_INFO）
        /// </summary>
        ALARM_UPLOADPIC_FAILCOUNT                           = 0x31bb,       
        /// <summary>
        /// POS management event(Corresponding to NET_ALARM_POS_MANAGE_INFO )
        /// POS管理事件事件(对应结构体 NET_ALARM_POS_MANAGE_INFO )
        /// </summary>
        ALARM_POS_MANAGE                                    = 0x31bc,       
        /// <summary>
        /// remote control status(Corresponding to NET_ALARM_REMOTE_CTRL_STATUS )
        /// 无线遥控器状态事件(对应结构体 NET_ALARM_REMOTE_CTRL_STATUS )
        /// </summary>
        ALARM_REMOTE_CTRL_STATUS                            = 0x31bd,        
        /// <summary>
        /// desuetude, passenger card check(Corresponding to structure NET_ALARM_PASSENGER_CARD_CHECK )
        /// 废弃, 乘客刷卡事件(对应结构体 NET_ALARM_PASSENGER_CARD_CHECK )
        /// </summary>
        ALARM_PASSENGER_CARD_CHECK                          = 0x31be,      
        /// <summary>
        /// Sound event(Corresponding to NET_ALARM_SOUND )
        /// 声音事件(对应结构体 NET_ALARM_SOUND )
        /// </summary>
        ALARM_SOUND                                         = 0x31bf,      
        /// <summary>
        /// Lock break event(Corresponding to NET_ALARM_LOCK_BREAK_INFO )
        /// 撬锁事件(对应结构体 NET_ALARM_LOCK_BREAK_INFO )
        /// </summary>
        ALARM_LOCK_BREAK                                    = 0x31c0,      
        /// <summary>
        /// Human Inside event((Corresponding to structure NET_ALARM_HUMAN_INSIDE_INFO)
        /// 舱内有人事件(对应结构体NET_ALARM_HUMAN_INSIDE_INFO)
        /// </summary>
        ALARM_HUMAN_INSIDE                                  = 0x31c1,        
        /// <summary>
        /// Human tumble Inside(Corresponding to structure NET_ALARM_HUMAN_TUMBLE_INSIDE_INFO)
        /// 舱内有人摔倒事件(对应结构体NET_ALARM_HUMAN_TUMBLE_INSIDE_INFO)
        /// </summary>
        ALARM_HUMAN_TUMBLE_INSIDE                           = 0x31c2,       
        /// <summary>
        /// Lock entry trigger event(Corresponding to structure NET_ALARM_DISABLE_LOCKIN_INFO)
        /// 闭锁进门按钮触发事件(对应NET_ALARM_DISABLE_LOCKIN_INFO)
        /// </summary>
        ALARM_DISABLE_LOCKIN                                = 0x31c3,       
        /// <summary>
        /// Lock go out trigger(Corresponding to structure NET_ALARM_DISABLE_LOCKOUT_INFO)
        /// 闭锁出门按钮触发事件(对应结构体NET_ALARM_DISABLE_LOCKOUT_INFO)
        /// </summary>
        ALARM_DISABLE_LOCKOUT                               = 0x31c4,       
        /// <summary>
        /// break rules data upload failed (Corresponding to NET_ALARM_UPLOAD_PIC_FAILED_INFO )
        /// 违章数据上传失败事件(对应结构体 NET_ALARM_UPLOAD_PIC_FAILED_INFO )
        /// </summary>
        ALARM_UPLOAD_PIC_FAILED                             = 0x31c5,      
        /// <summary>
        /// flow meter info event (NET_ALARM_FLOW_METER_INFO)
        /// 水流量统计信息上报事件(对应结构体 NET_ALARM_FLOW_METER_INFO)
        /// </summary>
        ALARM_FLOW_METER                                    = 0x31c6,       
        /// <summary>
        /// search around wifi device(Corresponding to NET_ALARM_WIFI_SEARCH_INFO)
        /// 获取到周围环境中WIFI设备上报事件(对应结构体 NET_ALARM_WIFI_SEARCH_INFO)
        /// </summary>
        ALARM_WIFI_SEARCH                                   = 0x31c7,       
        /// <summary>
        /// lowpower of wirelessdevice(NET_ALARM_WIRELESSDEV_LOWPOWER_INFO)
        /// 获取无线设备低电量上报事件(对应结构体NET_ALARM_WIRELESSDEV_LOWPOWER_INFO)
        /// </summary>
        ALARM_WIRELESSDEV_LOWPOWER                          = 0X31C8,       
        /// <summary>
        /// Ptz Diagnoses event(Corresponding to NET_ALARM_PTZ_DIAGNOSES_INFO)
        /// 云台诊断事件(对应结构体NET_ALARM_PTZ_DIAGNOSES_INFO)
        /// </summary>
        ALARM_PTZ_DIAGNOSES			                        = 0x31c9,		 
        /// <summary>
        /// flash light fault event (Corresponding to NET_ALARM_FLASH_LIGHT_FAULT_INFO)
        /// 爆闪灯(闪光灯)报警事件 (对应结构体 NET_ALARM_FLASH_LIGHT_FAULT_INFO)
        /// </summary>
        ALARM_FLASH_LIGHT_FAULT                             = 0x31ca,       
        /// <summary>
        /// stroboscopic light fault event (Corresponding to NET_ALARM_STROBOSCOPIC_LIGTHT_FAULT_INFO)
        /// 频闪灯报警事件 (对应结构体 NET_ALARM_STROBOSCOPIC_LIGTHT_FAULT_INFO)
        /// </summary>
        ALARM_STROBOSCOPIC_LIGTHT_FAULT                     = 0x31cb,       
        /// <summary>
        /// NumberStat event (Corresponding to NET_ALARM_HUMAN_NUMBER_STATISTIC_INFO)
        /// 人数量/客流量统计事件 (对应结构体 NET_ALARM_HUMAN_NUMBER_STATISTIC_INFO)
        /// </summary>
        ALARM_HUMAM_NUMBER_STATISTIC                        = 0x31cc,       
        /// <summary>
        /// Video unfocus (Corresponding NET_ALARM_VIDEOUNFOCUS_INFO)
        /// 视频虚焦报警(对应结构体 NET_ALARM_VIDEOUNFOCUS_INFO)
        /// </summary>
        ALARM_VIDEOUNFOCUS                                  = 0x31ce,       
        /// <summary>
        /// Video recond buffer drop frame event(Corresponding to NET_ALARM_BUF_DROP_FRAME_INFO)
        /// 录像缓冲区丢帧事件(对应结构体 NET_ALARM_BUF_DROP_FRAME_INFO)
        /// </summary>
        ALARM_BUF_DROP_FRAME                                = 0x31cd,       
        /// <summary>
        /// Abnormal event when master broad'version and slave broad'version different  (Corresponding to NET_ALARM_DOUBLE_DEV_VERSION_ABNORMAL_INFO)
        /// 双控设备主板与备板之间版本信息不一致异常事件 (对应结构体 NET_ALARM_DOUBLE_DEV_VERSION_ABNORMAL_INFO)
        /// </summary>
        ALARM_DOUBLE_DEV_VERSION_ABNORMAL                   = 0x31cf,        
        /// <summary>
        /// Switch with master and slave(Corresponding to NET_ALARM_DCSSWITCH_INFO)
        /// 主备切换事件 集群切换报警 (对应结构体 NET_ALARM_DCSSWITCH_INFO)
        /// </summary>
        ALARM_DCSSWITCH                                     = 0x31d0,       
        /// <summary>
        /// Radar connect state(Corresponding to NET_ALARM_RADAR_CONNECT_STATE_INFO)
        /// 雷达状态事件(对应结构体 NET_ALARM_RADAR_CONNECT_STATE_INFO)
        /// </summary>
        ALARM_RADAR_CONNECT_STATE                           = 0x31d1,        
        /// <summary>
        /// Defence arming status change(Corresponding to NET_ALARM_DEFENCE_ARMMODECHANGE_INFO)
        /// 防区布撤防状态改变事件(对应结构体 NET_ALARM_DEFENCE_ARMMODECHANGE_INFO)
        /// </summary>
        ALARM_DEFENCE_ARMMODE_CHANGE                        = 0x31d2,       
        /// <summary>
        /// Subsystem arming status change(Corresponding to NET_ALARM_SUBSYSTEM_ARMMODECHANGE_INFO)
        /// 子系统布撤防状态改变事件(对应结构体 NET_ALARM_SUBSYSTEM_ARMMODECHANGE_INFO)
        /// </summary>
        ALARM_SUBSYSTEM_ARMMODE_CHANGE                      = 0x31d3,       
        /// <summary>
        /// infrared detection information event (Corresponding NET_ALARM_RFID_INFO)
        /// 红外线检测信息事件(对应结构体 NET_ALARM_RFID_INFO)
        /// </summary>
        ALARM_RFID_INFO                                     = 0x31d4,       
        /// <summary>
        /// smoke detection(Corresponding NET_ALARM_SMOKE_DETECTION_INFO)
        /// 烟雾报警事件(对应结构体 NET_ALARM_SMOKE_DETECTION_INFO)
        /// </summary>
        ALARM_SMOKE_DETECTION                               = 0x31d5,       
        /// <summary>
        /// TemperatureDifference Between Rule (Corresponding NET_ALARM_BETWEENRULE_DIFFTEMPER_INFO)
        /// 热成像规则间温差异常报警(对应结构体 NET_ALARM_BETWEENRULE_DIFFTEMPER_INFO)
        /// </summary>
        ALARM_BETWEENRULE_TEMP_DIFF                         = 0x31d6,       
        /// <summary>
        /// Traffic picture analyse(Corresponding NET_ALARM_PIC_ANALYSE_INFO)
        /// 图片二次分析事件(对应 NET_ALARM_PIC_ANALYSE_INFO)
        /// </summary>
        ALARM_TRAFFIC_PIC_ANALYSE	                        = 0x31d7,		 
        /// <summary>
        /// Hotspot warning(Corresponding NET_ALARM_HOTSPOT_WARNING_INFO)
        /// 热成像热点异常报警(对应结构体 NET_ALARM_HOTSPOT_WARNING_INFO)
        /// </summary>
        ALARM_HOTSPOT_WARNING                               = 0x31d8,        
        /// <summary>
        /// coldspot warning(Corresponding NET_ALARM_COLDSPOT_WARNING_INFO)
        /// 热成像冷点异常报警(对应结构体 NET_ALARM_COLDSPOT_WARNING_INFO)
        /// </summary>
        ALARM_COLDSPOT_WARNING                              = 0x31d9,      
        /// <summary>
        /// firewarning (Corresponding NET_ALARM_FIREWARNING_INFO_DETAIL)
        /// 热成像火情报警信息上报(对应结构体 NET_ALARM_FIREWARNING_INFO_DETAIL)
        /// </summary>
        ALARM_FIREWARNING_INFO                              = 0x31da,       
        /// <summary>
        /// face overheating(Corresponding NET_ALARM_FACE_OVERHEATING_INFO)
        /// 热成像人体发烧预警(对应结构体 NET_ALARM_FACE_OVERHEATING_INFO)
        /// </summary>
        ALARM_FACE_OVERHEATING                              = 0x31db,        
        /// <summary>
        /// Sensor abnormal(Corresponding NET_ALARM_SENSOR_ABNORMAL_INFO)
        /// 探测器异常报警(对应结构体 NET_ALARM_SENSOR_ABNORMAL_INFO)
        /// </summary>
        ALARM_SENSOR_ABNORMAL                               = 0X31dc,     
        /// <summary>
        /// patient detection(Corresponding NET_ALARM_PATIENTDETECTION_INFO)
        /// 监控病人活动状态报警事件(对应结构体 NET_ALARM_PATIENTDETECTION_INFO)
        /// </summary>
        ALARM_PATIENTDETECTION                              = 0x31de,       
        /// <summary>
        /// radar high speed detection(Corresponding to NET_ALARM_RADAR_HIGH_SPEED_INFO)
        /// 雷达监测超速报警事件 智能楼宇专用 (对应结构体 NET_ALARM_RADAR_HIGH_SPEED_INFO)
        /// </summary>
        ALARM_RADAR_HIGH_SPEED                              = 0x31df,       
        /// <summary>
        /// Polling Alarm (Corresponding to NET_ALARM_POLLING_ALARM_INFO)
        /// 设备巡检报警事件 智能楼宇专用 (对应结构体 NET_ALARM_POLLING_ALARM_INFO)
        /// </summary>
        ALARM_POLLING_ALARM                                 = 0x31e0,       
        /// <summary>
        /// the alarm event for ITC_HWS000 (Corresponding NET_ALARM_ITC_HWS000)
        /// 虚点测速仪设备事件与报警(对应结构体 NET_ALARM_ITC_HWS000)
        /// </summary>
        ALARM_ITC_HWS000                                    = 0x31e1,       
        /// <summary>
        /// Traffic Strobe State(Corresponding to NET_ALARM_TRAFFICSTROBESTATE_INFO)
        /// 道闸栏状态事件(对应结构体 NET_ALARM_TRAFFICSTROBESTATE_INFO)
        /// </summary>
        ALARM_TRAFFICSTROBESTATE                            = 0x31e2,       
        /// <summary>
        /// telephone number check event(Corresponding to NET_ALARM_TELEPHONE_CHECK_INFO)
        /// 手机号码上报事件(对应结构体 NET_ALARM_TELEPHONE_CHECK_INFO)
        /// </summary>
        ALARM_TELEPHONE_CHECK                               = 0x31e3,       
        /// <summary>
        /// Paste Detection(Corresponding to NET_ALARM_PASTE_DETECTION_INFO )
        /// 贴条事件(对应结构体 NET_ALARM_PASTE_DETECTION_INFO )
        /// </summary>
        ALARM_PASTE_DETECTION                               = 0x31e4,      
        /// <summary>
        /// the alarm event for Shooting (Corresponding to NET_ALARM_PIC_SHOOTINGSCORERECOGNITION_INFO)
        /// 打靶像机事件(对应结构体 NET_ALARM_PIC_SHOOTINGSCORERECOGNITION_INFO)
        /// </summary>
        ALARM_SHOOTINGSCORERECOGNITION                      = 0x31e5,       
        /// <summary>
        /// the alarm event for swipe overtime(Corresponding to NET_ALARM_SWIPE_OVERTIME_INFO)
        /// 超时未刷卡事件(对应结构体 NET_ALARM_SWIPE_OVERTIME_INFO)
        /// </summary>
        ALARM_SWIPEOVERTIME                                 = 0x31e6,       
        /// <summary>
        /// the alarm event for driving without card(Corresponding to NET_ALARM_DRIVING_WITHOUTCARD_INFO)
        /// 无卡驾驶事件(对应结构体 NET_ALARM_DRIVING_WITHOUTCARD_INFO)
        /// </summary>
        ALARM_DRIVING_WITHOUTCARD                           = 0x31e7,       
        /// <summary>
        /// red light event (Corresponding to NET_ALARM_TRAFFIC_PEDESTRIAN_RUN_REDLIGHT_DETECTION_INFO)
        /// 闯红灯事件(对应结构体 NET_ALARM_TRAFFIC_PEDESTRIAN_RUN_REDLIGHT_DETECTION_INFO ) 
        /// </summary>
        ALARM_TRAFFIC_PEDESTRIAN_RUN_REDLIGHT_DETECTION     = 0x31e8,       
        /// <summary>
        /// the alarm event for fight detection(Corresponding to NET_ALARM_FIGHTDETECTION)
        /// 斗殴事件(对应结构体 NET_ALARM_FIGHTDETECTION)
        /// </summary>
        ALARM_FIGHTDETECTION			                    = 0x31e9, 		
    }

    /// <summary>
    /// intelligent event type,used in RealLoadPicture or fAnalyzerDataCallBack
    /// 智能事件类型
    /// </summary>
    public enum EM_EVENT_IVS_TYPE
    {
        /// <summary>
        /// subscription all event
        /// 订阅所有事件
        /// </summary>
        ALL						        = 0x00000001,		                
        /// <summary>
        /// cross line event(Corresponding to NET_DEV_EVENT_CROSSLINE_INFO)
        /// 警戒线事件(对应 NET_DEV_EVENT_CROSSLINE_INFO)
        /// </summary>
        CROSSLINEDETECTION		        = 0x00000002,		                
        /// <summary>
        /// cross region event(Corresponding to NET_DEV_EVENT_CROSSREGION_INFO)
        /// 警戒区事件(对应 NET_DEV_EVENT_CROSSREGION_INFO)
        /// </summary>
        CROSSREGIONDETECTION		    = 0x00000003,		                
        /// <summary>
        /// past event(Corresponding to NET_DEV_EVENT_PASTE_INFO)
        /// 贴条事件(对应 NET_DEV_EVENT_PASTE_INFO)
        /// </summary>
        PASTEDETECTION			        = 0x00000004,		                 
        /// <summary>
        /// left event(Corresponding to NET_DEV_EVENT_LEFT_INFO)
        /// 物品遗留事件(对应 NET_DEV_EVENT_LEFT_INFO)
        /// </summary>
        LEFTDETECTION				    = 0x00000005,		               
        /// <summary>
        /// stay event(Corresponding to NET_DEV_EVENT_STAY_INFO)
        /// 停留事件(对应 NET_DEV_EVENT_STAY_INFO)
        /// </summary>
        STAYDETECTION				    = 0x00000006,		                
        /// <summary>
        /// wander event(Corresponding to NET_DEV_EVENT_WANDER_INFO)
        /// 徘徊事件(对应 NET_DEV_EVENT_WANDER_INFO)
        /// </summary>
        WANDERDETECTION			        = 0x00000007,		                
        /// <summary>
        /// reservation event(Corresponding to NET_DEV_EVENT_PRESERVATION_INFO) 
        /// 物品保全事件(对应 NET_DEV_EVENT_PRESERVATION_INFO)
        /// </summary>
        PRESERVATION			        = 0x00000008,		              
        /// <summary>
        /// move event(Corresponding to NET_DEV_EVENT_MOVE_INFO)
        /// 移动事件(对应 NET_DEV_EVENT_MOVE_INFO)
        /// </summary>
        MOVEDETECTION			        = 0x00000009,		                
        /// <summary>
        /// tail event(Corresponding to NET_DEV_EVENT_TAIL_INFO)
        /// 尾随事件(对应 NET_DEV_EVENT_TAIL_INFO)
        /// </summary>
        TAILDETECTION			        = 0x0000000A,		                
        /// <summary>
        /// rioter event(Corresponding to NET_DEV_EVENT_RIOTERL_INFO)
        /// 聚众事件(对应 NET_DEV_EVENT_RIOTERL_INFO)
        /// </summary>
        RIOTERDETECTION			        = 0x0000000B,		                
        /// <summary>
        /// fire event(Corresponding to NET_DEV_EVENT_FIRE_INFO)
        /// 火警事件(对应 NET_DEV_EVENT_FIRE_INFO)
        /// </summary>
        FIREDETECTION				    = 0x0000000C,		              
        /// <summary>
        /// smoke event(Corresponding to NET_DEV_EVENT_SMOKE_INFO)
        /// 烟雾报警事件(对应 NET_DEV_EVENT_SMOKE_INFO)
        /// </summary>
        SMOKEDETECTION			        = 0x0000000D,		              
        /// <summary>
        /// fight event(Corresponding to NET_DEV_EVENT_FLOWSTAT_INFO)
        /// 斗殴事件(对应 NET_DEV_EVENT_FLOWSTAT_INFO)
        /// </summary>
        FIGHTDETECTION			        = 0x0000000E,		             
        /// <summary>
        /// flow stat event(Corresponding to NET_DEV_EVENT_FLOWSTAT_INFO)
        /// 流量统计事件(对应 NET_DEV_EVENT_FLOWSTAT_INFO)
        /// </summary>
        FLOWSTAT					    = 0x0000000F,		              
        /// <summary>
        /// number stat event(Corresponding to NET_DEV_EVENT_NUMBERSTAT_INFO)
        /// 数量统计事件(对应 NET_DEV_EVENT_NUMBERSTAT_INFO)
        /// </summary>
        NUMBERSTAT				        = 0x00000010,		                
        /// <summary>
        /// camera cover event
        /// 摄像头覆盖事件(保留)
        /// </summary>
        CAMERACOVERDDETECTION		    = 0x00000011,		                
        /// <summary>
        /// camera move event
        /// 摄像头移动事件(保留)
        /// </summary>
        CAMERAMOVEDDETECTION		    = 0x00000012,		                 
        /// <summary>
        /// video abnormal event(Corresponding to NET_DEV_EVENT_VIDEOABNORMALDETECTION_INFO)
        /// 视频异常事件(对应 NET_DEV_EVENT_VIDEOABNORMALDETECTION_INFO)
        /// </summary>
        VIDEOABNORMALDETECTION	        = 0x00000013,		                
        /// <summary>
        /// video bad event
        /// 视频损坏事件(保留)
        /// </summary>
        VIDEOBADDETECTION			    = 0x00000014,		                
        /// <summary>
        /// traffic control event(Corresponding to NET_DEV_EVENT_TRAFFICCONTROL_INFO)
        /// 交通管制事件(对应 NET_DEV_EVENT_TRAFFICCONTROL_INFO)
        /// </summary>
        TRAFFICCONTROL			        = 0x00000015,		                
        /// <summary>
        /// traffic accident event(Corresponding to NET_DEV_EVENT_TRAFFICACCIDENT_INFO)
        /// 交通事故事件(对应 NET_DEV_EVENT_TRAFFICACCIDENT_INFO)
        /// </summary>
        TRAFFICACCIDENT			        = 0x00000016,		                
        /// <summary>
        /// traffic junction event(Corresponding to NET_DEV_EVENT_TRAFFICJUNCTION_INFO)
        /// 交通路口事件----老规则(对应 NET_DEV_EVENT_TRAFFICJUNCTION_INFO)
        /// </summary>
        TRAFFICJUNCTION			        = 0x00000017,		                 
        /// <summary>
        /// traffic gate event(Corresponding to NET_DEV_EVENT_TRAFFICGATE_INFO)
        /// 交通卡口事件----老规则(对应 NET_DEV_EVENT_TRAFFICGATE_INFO)
        /// </summary>
        TRAFFICGATE				        = 0x00000018,		                
        /// <summary>
        /// traffic snapshot(Corresponding to NET_DEV_EVENT_TRAFFICSNAPSHOT_INFO)
        /// 交通抓拍事件(对应 NET_DEV_EVENT_TRAFFICSNAPSHOT_INFO)
        /// </summary>
        TRAFFICSNAPSHOT				    = 0x00000019,		                
        /// <summary>
        /// face detection(Corresponding to NET_DEV_EVENT_FACEDETECT_INFO)
        /// 人脸检测事件 (对应 NET_DEV_EVENT_FACEDETECT_INFO)
        /// </summary>
        FACEDETECT                      = 0x0000001A,                       
        /// <summary>
        /// traffic-Jam(Corresponding to NET_DEV_EVENT_TRAFFICJAM_INFO)
        /// 交通拥堵事件(对应 NET_DEV_EVENT_TRAFFICJAM_INFO)
        /// </summary>
        TRAFFICJAM                      = 0x0000001B,                       
        /// <summary>
        /// traffic-RunRedLight(Corresponding to NET_DEV_EVENT_TRAFFIC_RUNREDLIGHT_INFO)
        /// 交通违章-闯红灯事件(对应 NET_DEV_EVENT_TRAFFIC_RUNREDLIGHT_INFO)
        /// </summary>
        TRAFFIC_RUNREDLIGHT		        = 0x00000100,		                
        /// <summary>
        /// traffic-Overline(Corresponding to NET_DEV_EVENT_TRAFFIC_OVERLINE_INFO)
        /// 交通违章-压车道线事件(对应 NET_DEV_EVENT_TRAFFIC_OVERLINE_INFO)
        /// </summary>
        TRAFFIC_OVERLINE			    = 0x00000101,		                
        /// <summary>
        /// traffic-Retrograde(Corresponding to NET_DEV_EVENT_TRAFFIC_RETROGRADE_INFO)
        /// 交通违章-逆行事件(对应 NET_DEV_EVENT_TRAFFIC_RETROGRADE_INFO)
        /// </summary>
        TRAFFIC_RETROGRADE		        = 0x00000102,		               
        /// <summary>
        /// traffic-TurnLeft(Corresponding to NET_DEV_EVENT_TRAFFIC_TURNLEFT_INFO)
        /// 交通违章-违章左转(对应 NET_DEV_EVENT_TRAFFIC_TURNLEFT_INFO)
        /// </summary>
        TRAFFIC_TURNLEFT			    = 0x00000103,		                 
        /// <summary>
        /// traffic-TurnRight(Corresponding to NET_DEV_EVENT_TRAFFIC_TURNRIGHT_INFO)	
        /// 交通违章-违章右转(对应 NET_DEV_EVENT_TRAFFIC_TURNRIGHT_INFO)
        /// </summary>
        TRAFFIC_TURNRIGHT			    = 0x00000104,		                 
        /// <summary>
        /// traffic-Uturn(Corresponding to NET_DEV_EVENT_TRAFFIC_UTURN_INFO)
        /// 交通违章-违章掉头(对应 NET_DEV_EVENT_TRAFFIC_UTURN_INFO)
        /// </summary>
        TRAFFIC_UTURN				    = 0x00000105,		                
        /// <summary>
        /// traffic-Overspeed(Corresponding to NET_DEV_EVENT_TRAFFIC_OVERSPEED_INFO)
        /// 交通违章-超速(对应 NET_DEV_EVENT_TRAFFIC_OVERSPEED_INFO)
        /// </summary>
        TRAFFIC_OVERSPEED			    = 0x00000106,		                
        /// <summary>
        /// traffic-Underspeed(Corresponding to NET_DEV_EVENT_TRAFFIC_UNDERSPEED_INFO)
        /// 交通违章-低速(对应 NET_DEV_EVENT_TRAFFIC_UNDERSPEED_INFO)
        /// </summary>
        TRAFFIC_UNDERSPEED		        = 0x00000107,		                
        /// <summary>
        /// traffic-Parking(Corresponding to NET_DEV_EVENT_TRAFFIC_PARKING_INFO)
        /// 交通违章-违章停车(对应 NET_DEV_EVENT_TRAFFIC_PARKING_INFO)
        /// </summary>
        TRAFFIC_PARKING                 = 0x00000108,                       
        /// <summary>
        /// traffic-WrongRoute(Corresponding to NET_DEV_EVENT_TRAFFIC_WRONGROUTE_INFO)
        /// 交通违章-不按车道行驶(对应 NET_DEV_EVENT_TRAFFIC_WRONGROUTE_INFO)
        /// </summary>
        TRAFFIC_WRONGROUTE              = 0x00000109,                      
        /// <summary>
        /// traffic-CrossLane(Corresponding to NET_DEV_EVENT_TRAFFIC_CROSSLANE_INFO)
        /// 交通违章-违章变道(对应 NET_DEV_EVENT_TRAFFIC_CROSSLANE_INFO)
        /// </summary>
        TRAFFIC_CROSSLANE               = 0x0000010A,                       
        /// <summary>
        /// traffic-OverYellowLine(Corresponding to NET_DEV_EVENT_TRAFFIC_OVERYELLOWLINE_INFO)
        /// 交通违章-压黄线 (对应 NET_DEV_EVENT_TRAFFIC_OVERYELLOWLINE_INFO)
        /// </summary>
        TRAFFIC_OVERYELLOWLINE          = 0x0000010B,                      
        /// <summary>
        /// traffic-DrivingOnShoulder(Corresponding to NET_DEV_EVENT_TRAFFIC_DRIVINGONSHOULDER_INFO)
        /// 交通违章-路肩行驶事件(对应 NET_DEV_EVENT_TRAFFIC_DRIVINGONSHOULDER_INFO)  
        /// </summary>
        TRAFFIC_DRIVINGONSHOULDER       = 0x0000010C,                         
        /// <summary>
        /// traffic-YellowPlateInLane(Corresponding to NET_DEV_EVENT_TRAFFIC_YELLOWPLATEINLANE_INFO)
        /// 交通违章-黄牌车占道事件(对应 NET_DEV_EVENT_TRAFFIC_YELLOWPLATEINLANE_INFO)
        /// </summary>
        TRAFFIC_YELLOWPLATEINLANE       = 0x0000010E,                      
        /// <summary>
        /// Traffic offense-Pedestral has higher priority at the  crosswalk(Corresponding to NET_DEV_EVENT_TRAFFIC_PEDESTRAINPRIORITY_INFO)
        /// 交通违章-斑马线行人优先事件(对应 NET_DEV_EVENT_TRAFFIC_PEDESTRAINPRIORITY_INFO)
        /// </summary>
        TRAFFIC_PEDESTRAINPRIORITY      = 0x0000010F,		                
        /// <summary>
        /// cross fence(Corresponding to NET_DEV_EVENT_CROSSFENCEDETECTION_INFO)
        /// 翻越围栏事件(对应 NET_DEV_EVENT_CROSSFENCEDETECTION_INFO)
        /// </summary>
        CROSSFENCEDETECTION             = 0x0000011F,                        
        /// <summary>
        /// ElectroSpark event(Corresponding to NET_DEV_EVENT_ELECTROSPARK_INFO) 
        /// 电火花事件(对应 NET_DEV_EVENT_ELECTROSPARK_INFO)
        /// </summary>
        ELECTROSPARKDETECTION           = 0X00000110,                       
        /// <summary>
        /// no passing(Corresponding to NET_DEV_EVENT_TRAFFIC_NOPASSING_INFO)
        /// 交通违章-禁止通行事件(对应 NET_DEV_EVENT_TRAFFIC_NOPASSING_INFO)
        /// </summary>
        TRAFFIC_NOPASSING               = 0x00000111,                       
        /// <summary>
        /// abnormal run(Corresponding to NET_DEV_EVENT_ABNORMALRUNDETECTION_INFO)
        /// 异常奔跑事件(对应 NET_DEV_EVENT_ABNORMALRUNDETECTION_INFO)
        /// </summary>
        ABNORMALRUNDETECTION            = 0x00000112,                      
        /// <summary>
        /// retrograde(Corresponding to NET_DEV_EVENT_RETROGRADEDETECTION_INFO)
        /// 人员逆行事件(对应 NET_DEV_EVENT_RETROGRADEDETECTION_INFO)
        /// </summary>
        RETROGRADEDETECTION             = 0x00000113,                       
        /// <summary>
        /// in region detection(Corresponding to NET_DEV_EVENT_INREGIONDETECTION_INFO)
        /// 区域内检测事件(对应 NET_DEV_EVENT_INREGIONDETECTION_INFO)
        /// </summary>
        INREGIONDETECTION               = 0x00000114,                       
        /// <summary>
        /// taking away things(Corresponding to NET_DEV_EVENT_TAKENAWAYDETECTION_INFO)
        /// 物品搬移事件(对应 NET_DEV_EVENT_TAKENAWAYDETECTION_INFO)
        /// </summary>
        TAKENAWAYDETECTION              = 0x00000115,                       
        /// <summary>
        /// parking(Corresponding to NET_DEV_EVENT_PARKINGDETECTION_INFO)
        /// 非法停车事件(对应 NET_DEV_EVENT_PARKINGDETECTION_INFO)
        /// </summary>
        PARKINGDETECTION                = 0x00000116,                       
        /// <summary>
        /// face recognition(Corresponding to NET_DEV_EVENT_FACERECOGNITION_INFO)
        /// 人脸识别事件(对应 NET_DEV_EVENT_FACERECOGNITION_INFO)
        /// </summary>
        FACERECOGNITION			        = 0x00000117,		               
        /// <summary>
        /// manual snap(Corresponding to NET_DEV_EVENT_TRAFFIC_MANUALSNAP_INFO)
        /// 交通手动抓拍事件(对应 NET_DEV_EVENT_TRAFFIC_MANUALSNAP_INFO)
        /// </summary>
        TRAFFIC_MANUALSNAP              = 0x00000118,                       
        /// <summary>
        /// traffic flow state(Corresponding to NET_DEV_EVENT_TRAFFIC_FLOW_STATE)
        /// 交通流量统计事件(对应 NET_DEV_EVENT_TRAFFIC_FLOW_STATE)
        /// </summary>
        TRAFFIC_FLOWSTATE			    = 0x00000119,		              
        /// <summary>
        /// traffic stay(Corresponding to NET_DEV_EVENT_TRAFFIC_STAY_INFO)
        /// 交通滞留事件(对应 NET_DEV_EVENT_TRAFFIC_STAY_INFO)
        /// </summary>
        TRAFFIC_STAY				    = 0x0000011A,		                 
        /// <summary>
        /// traffic vehicle route(Corresponding to NET_DEV_EVENT_TRAFFIC_VEHICLEINROUTE_INFO)
        /// 有车占道事件(对应 NET_DEV_EVENT_TRAFFIC_VEHICLEINROUTE_INFO)
        /// </summary>
        TRAFFIC_VEHICLEINROUTE	        = 0x0000011B,		                
        /// <summary>
        /// motion detect(Corresponding to NET_DEV_EVENT_ALARM_INFO)
        /// 视频移动侦测事件(对应 NET_DEV_EVENT_ALARM_INFO)
        /// </summary>
        ALARM_MOTIONDETECT              = 0x0000011C,                       
        /// <summary>
        /// local alarm(Corresponding to NET_DEV_EVENT_ALARM_INFO)
        /// 外部报警事件(对应 NET_DEV_EVENT_ALARM_INFO)
        /// </summary>
        ALARM_LOCALALARM                = 0x0000011D,                       
        /// <summary>
        /// prisoner rise detect(Corresponding to NET_DEV_EVENT_PRISONERRISEDETECTION_INFO)
        /// 看守所囚犯起身事件(对应 NET_DEV_EVENT_PRISONERRISEDETECTION_INFO)
        /// </summary>
        PRISONERRISEDETECTION		    = 0x0000011E,		               
        /// <summary>
        /// traffic tollgate(Corresponding to NET_DEV_EVENT_TRAFFICJUNCTION_INFO)
        /// 交通违章-卡口事件----新规则(对应 NET_DEV_EVENT_TRAFFICJUNCTION_INFO)
        /// </summary>
        TRAFFIC_TOLLGATE			    = 0x00000120,		              
        /// <summary>
        /// density detection of persons(Corresponding to NET_DEV_EVENT_DENSITYDETECTION_INFO)
        /// 人员密集度检测(对应 NET_DEV_EVENT_DENSITYDETECTION_INFO)
        /// </summary>
        DENSITYDETECTION			    = 0x00000121,                       
        /// <summary>
        /// video diagnosis result(Corresponding to NET_VIDEODIAGNOSIS_COMMON_INFO and NET_REAL_DIAGNOSIS_RESULT)
        /// 视频诊断结果事件(对应 NET_VIDEODIAGNOSIS_COMMON_INFO 和 NET_REAL_DIAGNOSIS_RESULT)
        /// </summary>
        VIDEODIAGNOSIS                  = 0x00000122,		                
        /// <summary>
        /// queue detection(Corresponding to NET_DEV_EVENT_QUEUEDETECTION_INFO)
        /// 排队检测报警事件(对应 NET_DEV_EVENT_QUEUEDETECTION_INFO)
        /// </summary>
        QUEUEDETECTION                  = 0x00000123,                       
        /// <summary>
        /// take up in bus route(Corresponding to NET_DEV_EVENT_TRAFFIC_VEHICLEINBUSROUTE_INFO)
        /// 占用公交车道事件(对应 NET_DEV_EVENT_TRAFFIC_VEHICLEINBUSROUTE_INFO)
        /// </summary>
        TRAFFIC_VEHICLEINBUSROUTE       = 0x00000124,                       
        /// <summary>
        /// illegal astern(Corresponding to NET_DEV_EVENT_IVS_TRAFFIC_BACKING_INFO) 
        /// 违章倒车事件(对应 NET_DEV_EVENT_IVS_TRAFFIC_BACKING_INFO)
        /// </summary>
        TRAFFIC_BACKING                 = 0x00000125,                      
        /// <summary>
        /// audio abnormity(Corresponding to NET_DEV_EVENT_IVS_AUDIO_ABNORMALDETECTION_INFO)
        /// 声音异常检测(对应 NET_DEV_EVENT_IVS_AUDIO_ABNORMALDETECTION_INFO)
        /// </summary>
        AUDIO_ABNORMALDETECTION         = 0x00000126,                       
        /// <summary>
        /// run yellow light(Corresponding to NET_DEV_EVENT_TRAFFIC_RUNYELLOWLIGHT_INFO)
        /// 交通违章-闯黄灯事件(对应 NET_DEV_EVENT_TRAFFIC_RUNYELLOWLIGHT_INFO)
        /// </summary>
        TRAFFIC_RUNYELLOWLIGHT          = 0x00000127,                      
        /// <summary>
        /// climb detection(Corresponding to NET_DEV_EVENT_IVS_CLIMB_INFO) 
        /// 攀高检测事件(对应 NET_DEV_EVENT_IVS_CLIMB_INFO)
        /// </summary>
        CLIMBDETECTION                  = 0x00000128,                      
        /// <summary>
        /// leave detection(Corresponding to NET_DEV_EVENT_IVS_LEAVE_INFO)
        /// 离岗检测事件(对应 NET_DEV_EVENT_IVS_LEAVE_INFO)
        /// </summary>
        LEAVEDETECTION                  = 0x00000129,                       
        /// <summary>
        /// parking on yellow box(Corresponding to NET_DEV_EVENT_TRAFFIC_PARKINGONYELLOWBOX_INFO)
        /// 黄网格线抓拍事件(对应 NET_DEV_EVENT_TRAFFIC_PARKINGONYELLOWBOX_INFO)
        /// </summary>
        TRAFFIC_PARKINGONYELLOWBOX      = 0x0000012A,                       
        /// <summary>
        /// parking space parking(Corresponding to NET_DEV_EVENT_TRAFFIC_PARKINGSPACEPARKING_INFO)
        /// 车位有车事件(对应 NET_DEV_EVENT_TRAFFIC_PARKINGSPACEPARKING_INFO)
        /// </summary>
        TRAFFIC_PARKINGSPACEPARKING     = 0x0000012B,                      
        /// <summary>
        /// parking space no parking(Corresponding to NET_DEV_EVENT_TRAFFIC_PARKINGSPACENOPARKING_INFO)
        /// 车位无车事件(对应 NET_DEV_EVENT_TRAFFIC_PARKINGSPACENOPARKING_INFO)   
        /// </summary>
        TRAFFIC_PARKINGSPACENOPARKING   = 0x0000012C,                       
        /// <summary>
        /// passerby(Corresponding to NET_DEV_EVENT_TRAFFIC_PEDESTRAIN_INFO)
        /// 交通行人事件(对应 NET_DEV_EVENT_TRAFFIC_PEDESTRAIN_INFO)
        /// </summary>
        TRAFFIC_PEDESTRAIN              = 0x0000012D,                       
        /// <summary>
        /// throw(Corresponding to NET_DEV_EVENT_TRAFFIC_THROW_INFO)
        /// 交通抛洒物品事件(对应 NET_DEV_EVENT_TRAFFIC_THROW_INFO)
        /// </summary>
        TRAFFIC_THROW                   = 0x0000012E,                       
        /// <summary>
        /// idle(Corresponding to NET_DEV_EVENT_TRAFFIC_IDLE_INFO)
        /// 交通空闲事件(对应 NET_DEV_EVENT_TRAFFIC_IDLE_INFO)
        /// </summary>
        TRAFFIC_IDLE                    = 0x0000012F,                       
        /// <summary>
        /// Vehicle ACC power outage alarm events(Corresponding to NET_DEV_EVENT_ALARM_VEHICLEACC_INFO)
        /// 车载ACC断电报警事件(对应 NET_DEV_EVENT_ALARM_VEHICLEACC_INFO)
        /// </summary>
        ALARM_VEHICLEACC                = 0x00000130,                     
        /// <summary>
        /// Vehicle rollover alarm events(Corresponding to NET_DEV_EVENT_VEHICEL_ALARM_INFO)
        /// 车辆侧翻报警事件(对应 NET_DEV_EVENT_VEHICEL_ALARM_INFO)
        /// </summary>
        ALARM_VEHICLE_TURNOVER          = 0x00000131,                       
        /// <summary>
        /// Vehicle crash alarm events(Corresponding to NET_DEV_EVENT_VEHICEL_ALARM_INFO)
        /// 车辆撞车报警事件(对应 NET_DEV_EVENT_VEHICEL_ALARM_INFO)
        /// </summary>
        ALARM_VEHICLE_COLLISION         = 0x00000132,                       
        /// <summary>
        /// On-board camera large Angle turn events
        /// 车载摄像头大角度扭转事件
        /// </summary>
        ALARM_VEHICLE_LARGE_ANGLE       = 0x00000133,                       
        /// <summary>
        /// Parking line pressing events(Corresponding to NET_DEV_EVENT_TRAFFIC_PARKINGSPACEOVERLINE_INFO)
        /// 车位压线事件(对应 NET_DEV_EVENT_TRAFFIC_PARKINGSPACEOVERLINE_INFO)
        /// </summary>
        TRAFFIC_PARKINGSPACEOVERLINE    = 0x00000134,                       
        /// <summary>
        /// Many scenes switching events(Corresponding to NET_DEV_EVENT_IVS_MULTI_SCENE_SWICH_INFO)
        /// 多场景切换事件(对应 NET_DEV_EVENT_IVS_MULTI_SCENE_SWICH_INFO)
        /// </summary>
        MULTISCENESWITCH                = 0x00000135,                       
        /// <summary>
        /// Limited license plate event(Corresponding to NET_DEV_EVENT_TRAFFIC_RESTRICTED_PLATE)
        /// 受限车牌事件(对应 NET_DEV_EVENT_TRAFFIC_RESTRICTED_PLATE)
        /// </summary>
        TRAFFIC_RESTRICTED_PLATE        = 0X00000136,                      
        /// <summary>
        /// Cross stop line event(Corresponding to NET_DEV_EVENT_TRAFFIC_OVERSTOPLINE)
        /// 压停止线事件(对应 NET_DEV_EVENT_TRAFFIC_OVERSTOPLINE)
        /// </summary>
        TRAFFIC_OVERSTOPLINE            = 0X00000137,                       
        /// <summary>
        /// Traffic unfasten seat belt event(Corresponding to NET_DEV_EVENT_TRAFFIC_WITHOUT_SAFEBELT) 
        /// 交通未系安全带事件(对应 NET_DEV_EVENT_TRAFFIC_WITHOUT_SAFEBELT)
        /// </summary>
        TRAFFIC_WITHOUT_SAFEBELT        = 0x00000138,                       
        /// <summary>
        /// Driver smoking event(Corresponding to NET_DEV_EVENT_TRAFFIC_DRIVER_SMOKING) 
        /// 驾驶员抽烟事件(对应 NET_DEV_EVENT_TRAFFIC_DRIVER_SMOKING)
        /// </summary>
        TRAFFIC_DRIVER_SMOKING          = 0x00000139,                       
        /// <summary>
        /// Driver call event(Corresponding to NET_DEV_EVENT_TRAFFIC_DRIVER_CALLING) 
        /// 驾驶员打电话事件(对应 NET_DEV_EVENT_TRAFFIC_DRIVER_CALLING)
        /// </summary>
        TRAFFIC_DRIVER_CALLING          = 0x0000013A,                      
        /// <summary>
        /// Pedestrain red light(Corresponding to NET_DEV_EVENT_TRAFFIC_PEDESTRAINRUNREDLIGHT_INFO)
        /// 行人闯红灯事件(对应 NET_DEV_EVENT_TRAFFIC_PEDESTRAINRUNREDLIGHT_INFO)
        /// </summary>
        TRAFFIC_PEDESTRAINRUNREDLIGHT   = 0x0000013B,                       
        /// <summary>
        /// Pass not in order(corresponding NET_DEV_EVENT_TRAFFIC_PASSNOTINORDER_INFO)
        /// 未按规定依次通行(对应 NET_DEV_EVENT_TRAFFIC_PASSNOTINORDER_INFO)
        /// </summary>
        TRAFFIC_PASSNOTINORDER          = 0x0000013C,                     
        /// <summary>
        /// Object feature detection event(Corresponding to NET_DEV_EVENT_TRAFFIC_OBJECT_DETECTION) 
        /// 物体特征检测事件 NET_DEV_EVENT_TRAFFIC_OBJECT_DETECTION
        /// </summary>
        OBJECT_DETECTION                = 0x00000141,                      
        /// <summary>
        /// Analog alarm channel?ˉs alarm event(corresponding NET_DEV_EVENT_ALARM_ANALOGALRM_INFO)
        /// 模拟量报警通道的报警事件(对应NET_DEV_EVENT_ALARM_ANALOGALRM_INFO)
        /// </summary>
        ALARM_ANALOGALARM               = 0x00000150,                      
        /// <summary>
        /// Warning lineexpansion event(Corresponding to NET_DEV_EVENT_CROSSLINE_INFO_EX) 
        /// 警戒线扩展事件 NET_DEV_EVENT_CROSSLINE_INFO_EX
        /// </summary>
        CROSSLINEDETECTION_EX	        = 0x00000151,                     
        /// <summary>
        /// Normal Record
        /// 普通录像
        /// </summary>
        ALARM_COMMON                    = 0x00000152,                       
        /// <summary>
        /// Video tampering event(Corresponding to NET_DEV_EVENT_ALARM_VIDEOBLIND)
        /// 视频遮挡事件(对应 NET_DEV_EVENT_ALARM_VIDEOBLIND)
        /// </summary>
        ALARM_VIDEOBLIND                = 0x00000153,                       
        /// <summary>
        /// Video loss event
        /// 视频丢失事件
        /// </summary>
        ALARM_VIDEOLOSS                 = 0x00000154,                       
        /// <summary>
        /// Event of getting out bed detection(Corresponding to NET_DEV_EVENT_GETOUTBED_INFO)
        /// 看守所下床事件(对应 NET_DEV_EVENT_GETOUTBED_INFO)
        /// </summary>
        GETOUTBEDDETECTION			    = 0x00000155,		                
        /// <summary>
        /// Event of patrol detection(Corresponding to NET_DEV_EVENT_PATROL_INFO)
        /// 巡逻检测事件(对应 NET_DEV_EVENT_PATROL_INFO)
        /// </summary>
        PATROLDETECTION			        = 0x00000156,		            
        /// <summary>
        /// Event of on duty detection(Corresponding to NET_DEV_EVENT_ONDUTY_INFO)
        /// 站岗检测事件(对应 NET_DEV_EVENT_ONDUTY_INFO)
        /// </summary>
        ONDUTYDETECTION				    = 0x00000157,		                
        /// <summary>
        /// Event of VTO do not answer calling request
        /// 门口机呼叫未响应事件
        /// </summary>
        NOANSWERCALL                    = 0x00000158,                     
        /// <summary>
        /// Event of storage do not exist
        /// 存储组不存在事件
        /// </summary>
        STORAGENOTEXIST                 = 0x00000159,                    
        /// <summary>
        /// Event of storage space low
        /// 硬盘空间低报警事件
        /// </summary>
        STORAGELOWSPACE                 = 0x0000015A,                      
        /// <summary>
        /// Event of storage failure
        /// 存储错误事件
        /// </summary>
        STORAGEFAILURE                  = 0x0000015B,                      
        /// <summary>
        /// Event of profile alarm transmit
        /// 报警传输事件
        /// </summary>
        PROFILEALARMTRANSMIT            = 0x0000015C,                      
        /// <summary>
        /// Event of static video detect(corresponding NET_DEV_EVENT_ALARM_VIDEOSTATIC_INFO)
        /// 视频静态检测事件(对应 NET_DEV_EVENT_ALARM_VIDEOSTATIC_INFO)
        /// </summary>
        VIDEOSTATIC                     = 0x0000015D,                       
        /// <summary>
        /// Event of video timing detect(corresponding NET_DEV_EVENT_ALARM_VIDEOTIMING_INFO)
        /// 视频定时检测事件(对应 NET_DEV_EVENT_ALARM_VIDEOTIMING_INFO)
        /// </summary>
        VIDEOTIMING                     = 0x0000015E,                       
        /// <summary>
        /// Heat map 
        /// 热度图
        /// </summary>
        HEATMAP                         = 0x0000015F,                       
        /// <summary>
        /// ID info reading event (Corresponding to NET_DEV_EVENT_ALARM_CITIZENIDCARD_INFO)
        /// 身份证信息读取事件(对应 NET_DEV_EVENT_ALARM_CITIZENIDCARD_INFO)
        /// </summary>
        CITIZENIDCARD                   = 0x00000160,                      
        /// <summary>
        /// Image info event(Corresponding to NET_DEV_EVENT_ALARM_PIC_INFO)
        /// 图片信息事件(对应 NET_DEV_EVENT_ALARM_PIC_INFO)
        /// </summary>
        PICINFO                         = 0x00000161,                       
        /// <summary>
        /// NetPlayCheck event(corresponding NET_DEV_EVENT_ALARM_NETPLAYCHECK_INFO)
        /// 上网登记事件(对应 NET_DEV_EVENT_ALARM_NETPLAYCHECK_INFO)
        /// </summary>
        NETPLAYCHECK					= 0x00000162,		                
        /// <summary>
        /// Jam Forbid into  event(corresponding NET_DEV_EVENT_ALARM_JAMFORBIDINTO_INFO)
        /// 车辆拥堵禁入事件(对应 NET_DEV_EVENT_ALARM_JAMFORBIDINTO_INFO)
        /// </summary>
        TRAFFIC_JAM_FORBID_INTO		    = 0x00000163,		                 
        /// <summary>
        /// Snap by time event(corresponding NET_DEV_EVENT_SNAPBYTIME)
        /// 定时抓图事件(对应NET_DEV_EVENT_SNAPBYTIME)
        /// </summary>
        SNAPBYTIME                      = 0x00000164,                       
        /// <summary>
        /// PTZ turn to preset event(corresponding to NET_DEV_EVENT_ALARM_PTZ_PRESET_INFO)
        /// 云台转动到预置点事件(对应 NET_DEV_EVENT_ALARM_PTZ_PRESET_INFO)
        /// </summary>
        PTZ_PRESET                      = 0x00000165,                     
        /// <summary>
        /// Event of infrared detect info(corresponding to NET_DEV_EVENT_ALARM_RFID_INFO)
        /// 红外线检测信息事件(对应 NET_DEV_EVENT_ALARM_RFID_INFO)
        /// </summary>
        RFID_INFO                       = 0x00000166,                       
        /// <summary>
        /// Event of standing up detection
        /// 人起立检测事件
        /// </summary>
        STANDUPDETECTION				= 0X00000167,		                
        /// <summary>
        /// Event of QSYTrafficCarWeight (corresponding to NET_DEV_EVENT_QSYTRAFFICCARWEIGHT_INFO)
        /// 交通卡口称重事件(对应 NET_DEV_EVENT_QSYTRAFFICCARWEIGHT_INFO)
        /// </summary>
        QSYTRAFFICCARWEIGHT			    = 0x00000168,		                 
        /// <summary>
        /// Event of compare plate(corresponding to NET_DEV_EVENT_TRAFFIC_COMPAREPLATE_INFO)
        /// 卡口前后车牌合成事件(对应NET_DEV_EVENT_TRAFFIC_COMPAREPLATE_INFO)
        /// </summary>
        TRAFFIC_COMPAREPLATE			= 0x00000169,		                
        /// <summary>
        /// Event of shooting score recognition(corresponding to NET_CFG_IVS_SHOOTINGSCORERECOGNITION_INFO)
        /// 打靶像机事件(对应 NET_CFG_IVS_SHOOTINGSCORERECOGNITION_INFO)
        /// </summary>
        SHOOTINGSCORERECOGNITION		= 0x0000016A,		                
        /// <summary>
        /// Event of presnap analyse(corresponding to NET_DEV_EVENT_TRAFFIC_ANALYSE_PRESNAP_INFO)
        /// 预分析抓拍图片事件(对应 NET_DEV_EVENT_TRAFFIC_ANALYSE_PRESNAP_INFO)
        /// </summary>
        TRAFFIC_ANALYSE_PRESNAP         = 0x00000170,                       
        /// <summary>
        /// All event start with [TRAFFIC](EVENT_IVS_TRAFFICCONTROL to EVENT_TRAFFICSNAPSHOT,EVENT_IVS_TRAFFIC_RUNREDLIGHT to EVENT_IVS_TRAFFIC_UNDERSPEED)
        /// 所有以traffic开头的事件目前指的是EVENT_IVS_TRAFFICCONTROL 到 EVENT_TRAFFICSNAPSHOT,EVENT_IVS_TRAFFIC_RUNREDLIGHT 到 EVENT_IVS_TRAFFIC_UNDERSPEED
        /// </summary>                    
        TRAFFIC_ALL                     = 0x000001FF,                       
        /// <summary>
        /// All IVS events 
        /// 所有智能分析事件
        /// </summary>
        VIDEOANALYSE                    = 0x00000200,                        
        /// <summary>
        /// LinkSD events(Corresponding to NET_DEV_EVENT_LINK_SD)
        /// LinkSD事件(对应 NET_DEV_EVENT_LINK_SD)
        /// </summary>
        LINKSD                          = 0x00000201,                       
        /// <summary>
        /// Vehicle Analyse (Corresponding to NET_DEV_EVENT_VEHICLEANALYSE)
        /// 车辆特征检测分析(对应NET_DEV_EVENT_VEHICLEANALYSE)
        /// </summary>
        VEHICLEANALYSE				    = 0x00000202,		                
        /// <summary>
        /// Flow rate events(Corresponding to NET_DEV_EVENT_FLOWRATE_INFO)
        /// 流量使用情况事件(对应 NET_DEV_EVENT_FLOWRATE_INFO)
        /// </summary>
        FLOWRATE						= 0x00000203,		                
    }

    /// <summary>
    /// catch a figure type CLIENT_CapturePictureEx interface using
    /// 抓图类型
    /// </summary>
    public enum EM_NET_CAPTURE_FORMATS
    {
        /// <summary>
        /// BMP
        /// BMP
        /// </summary>
        BMP,
        /// <summary>
        /// 100% quality JPEG
        /// 100%质量的JPEG
        /// </summary>
        JPEG,                                                               
        /// <summary>
        /// 70% quality JPEG
        /// 70%质量的JPEG
        /// </summary>
        JPEG_70,                   
        /// <summary>
        /// 50% quality JPEG
        /// 50%质量的JPEG
        /// </summary>                       
        JPEG_50,
        /// <summary>
        /// 30% quality JPEG
        /// 30%质量的JPEG
        /// </summary>
        JPEG_30,
    }

    /// <summary>
    /// the describe of EVENT_IVS_TRAFFIC_RUNREDLIGHT's data
    /// 交通-闯红灯事件对应的数据块描述信息
    /// </summary>
    public struct NET_DEV_EVENT_TRAFFIC_RUNREDLIGHT_INFO
    {
        /// <summary>
        /// channel ID
        /// 通道号
        /// </summary>
	    public int					                    nChannelID;			
        /// <summary>
        /// event name
        /// 事件名称
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[]				                    szName;			    
        /// <summary>
        /// byte alignment
        /// 字节对齐
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	    public byte[]                                   bReserved1;         
        /// <summary>
        /// PTS(ms)
        /// 时间戳(单位是毫秒)
        /// </summary>
	    public double				                    PTS;				
        /// <summary>
        /// the event happen time
        /// 事件发生的时间
        /// </summary>
	    public NET_TIME_EX			                    UTC;				
        /// <summary>
        /// event ID
        /// 事件ID
        /// </summary>
	    public int					                    nEventID;			
        /// <summary>
        /// Corresponding Lane number
        /// 对应车道号
        /// </summary>
	    public int					                    nLane;				
        /// <summary>
        /// have being detected object
        /// 对像信息
        /// </summary>
	    public NET_MSG_OBJECT		                    stuObject;	        
        /// <summary>
        /// vehicle info
        /// 车身信息
        /// </summary>
	    public NET_MSG_OBJECT                           stuVehicle;         
        /// <summary>
        /// event file info
        /// 事件对应文件信息
        /// </summary>
	    public NET_EVENT_FILE_INFO                      stuFileInfo;        
        /// <summary>
        /// state of traffic light 0:unknown 1:green 2:red 3:yellow
        /// 红绿灯状态 0:未知 1：绿灯 2:红灯 3:黄灯
        /// </summary>
	    public int					                    nLightState;	    
        /// <summary>
        /// speed,km/h
        /// 车速,km/h
        /// </summary>
	    public int					                    nSpeed;			    
        /// <summary>
        /// snap index,such as 3,2,1,1 means the last one,0 means there has eption and snap stop
        /// 表示抓拍序号,如3,2,1,1表示抓拍结束,0表示异常结束
        /// </summary>
	    public int                                      nSequence;          
        /// <summary>
        /// Event action,0 means pulse event,1 means continuous event's begin,2means continuous event's end;
        /// 事件动作,0表示脉冲事件,1表示持续性事件开始,2表示持续性事件结束
        /// </summary>
	    public byte                                     bEventAction;		
        /// <summary>
        /// Reserved
        /// 保留，字节对齐
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[]                                   byReserved;
        /// <summary>
        /// Serial number of the picture, in the same time (accurate to seconds) may have multiple images, starting from 0
        /// 图片的序号, 同一时间内(精确到秒)可能有多张图片, 从0开始
        /// </summary>
        public byte                                     byImageIndex;		
        /// <summary>
        /// snap flags(by bit),0bit:"*",1bit:"Timing",2bit:"Manual",3bit:"Marked",4bit:"Event",5bit:"Mosaic",6bit:"Cutout"
        /// 抓图标志(按位)
        /// </summary>
        public uint                                     dwSnapFlagMask;		
        /// <summary>
        /// time of red light starting
        /// 红灯开始时间
        /// </summary>
	    public NET_TIME_EX                              stRedLightUTC;		
        /// <summary>
        /// picture resolution
        /// 对应图片的分辨率
        /// </summary>
	    public NET_RESOLUTION_INFO                      stuResolution;		
        /// <summary>
        /// red light margin
        /// 红灯容许间隔时间,单位：秒
        /// </summary>
	    public byte                                     byRedLightMargin;	
        /// <summary>
        /// Align string
        /// 字节对齐
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[]                                   byAlignment;		
        /// <summary>
        /// Red light period. The unit is ms. 
        /// 表示红灯周期时间,单位毫秒
        /// </summary>
        public int                                      nRedLightPeriod;
        /// <summary>
        /// GPS info ,use in mobile DVR/NVR
        /// GPS信息
        /// </summary>
        public NET_GPS_INFO                             stuGPSInfo;                                 
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 928)]
        public byte[]                                   bReserved;          
        /// <summary>
        /// Traffic vehicle info
        /// 交通车辆信息
        /// </summary>
	    public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO    stTrafficCar;       
        /// <summary>
        /// public info 
        /// 公共信息
        /// </summary>
        public NET_EVENT_COMM_INFO                      stCommInfo;         
    } 

    /// <summary>
    /// time struct
    /// 时间信息结构体
    /// </summary>
    public struct NET_TIME_EX
    {
        /// <summary>
        /// Year
        /// 年
        /// </summary>
        public uint				                        dwYear;				
        /// <summary>
        /// Month
        /// 月
        /// </summary>
	    public uint				                        dwMonth;			
        /// <summary>
        /// Day
        /// 日
        /// </summary>
	    public uint				                        dwDay;				
        /// <summary>
        /// Hour
        /// 时
        /// </summary>
	    public uint				                        dwHour;				
        /// <summary>
        /// Minute
        /// 分
        /// </summary>
	    public uint				                        dwMinute;			
        /// <summary>
        /// Second
        /// 秒
        /// </summary>
	    public uint				                        dwSecond;			
        /// <summary>
        /// Millisecond
        /// 毫秒
        /// </summary>
	    public uint                                     dwMillisecond;      
        /// <summary>
        /// reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	    public uint[]                                   dwReserved;         

        /// <summary>
        /// override tostring function
        /// 重写tostring函数
        /// </summary>
        /// <returns>timer string</returns>
        public override string ToString()
        {
            return string.Format("{0}-{1}-{2} {3}:{4}:{5}.{6}", dwYear.ToString("D4"), dwMonth.ToString("D2"), dwDay.ToString("D2"), dwHour.ToString("D2"), dwMinute.ToString("D2"), dwSecond.ToString("D2"),dwMillisecond.ToString("D3"));
        }
    }

	/// <summary>
    /// Struct of object info for video analysis,4-byte alignment
    /// 物体信息结构体,强制4字节对齐
	/// </summary>
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)] 
	public struct NET_MSG_OBJECT
	{
        /// <summary>
        /// Object ID,each ID represent a unique object
        /// 物体ID,每个ID表示一个唯一的物体
        /// </summary>
		public int					                nObjectID;			    
        /// <summary>
        /// Object type
        /// 物体类型
        /// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
		public byte[]				                szObjectType;	         
        /// <summary>
        /// Confidence(0~255),a high value indicate a high confidence
        /// 置信度(0~255),值越大表示置信度越高
        /// </summary>
		public int					                nConfidence;		     
        /// <summary>
        /// Object action:1:Appear 2:Move 3:Stay 4:Remove 5:Disappear 6:Split 7:Merge 8:Rename
        /// 物体动作:1:Appear 2:Move 3:Stay 4:Remove 5:Disappear 6:Split 7:Merge 8:Rename
        /// </summary>
		public int					                nAction;			    
        /// <summary>
        /// BoundingBox
        /// 包围盒
        /// </summary>
		#if (LINUX_X64)
		public NET_RECT_LONG_TYPE                   BoundingBox;		     
		#else
		public NET_RECT				                BoundingBox;		    
		#endif
        /// <summary>
        /// The shape center of the object
        /// 物体型心
        /// </summary>
		public NET_POINT			                Center;				    
        /// <summary>
        /// the number of culminations for the polygon
        /// 多边形顶点个数
        /// </summary>
		public int					                nPolygonNum;		    
        /// <summary>
        /// a polygon that have a exactitude figure
        /// 较精确的轮廓多边形
        /// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public NET_POINT[]			                Contour;	            
        /// <summary>
        /// The main color of the object;the first byte indicate red value, as byte order as green, blue, transparence, for example:RGB(0,255,0),transparence = 0, rgbaMainColor = 0x00ff0000.
        /// 表示车牌、车身等物体主要颜色；按字节表示,分别为红、绿、蓝和透明度,例如:RGB值为(0,255,0),透明度为0时, 其值为0x00ff0000.
        /// </summary>
		public uint				                    rgbaMainColor;		    
        /// <summary>
        /// the interrelated text of object,such as number plate,container number
        /// 物体上相关的带0结束符文本,比如车牌,集装箱号等等
        /// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
		public byte[]				                szText;				    
        /// <summary>
        /// object sub type,different object type has different sub type:Vehicle Category:"Unknown","Motor","Non-Motor","Bus","Bicycle","Motorcycle";Plate Category:"Unknown","mal","Yellow","DoubleYellow","Police","Armed"
        /// 物体子类别,根据不同的物体类型,可以取以下子类型:Vehicle Category:"Unknown"  未知,"Motor" 机动车,"Non-Motor":非机动车,"Bus": 公交车;Plate Category："Unknown" 未知,"Normal" 蓝牌黑牌,"Yellow" 黄牌,"DoubleYellow" 双层黄尾牌,"Police" 警牌"Armed" 武警牌
        /// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
		public byte[]                               szObjectSubType;         
        /// <summary>
        /// Specifies the sub-brand of vehicle,the real value can be found in a mapping table from the development manual
        /// 车辆子品牌 需要通过映射表得到真正的子品牌 映射表详见开发手册
        /// </summary>
		public ushort                               wSubBrand;              
        /// <summary>
        /// reserved
        /// 保留，字节对齐
        /// </summary>
		public byte                                 byReserved1;                 
        /// <summary>
        /// picture info enable
        /// 是否有物体对应图片文件信息
        /// </summary>
		public byte                                 bPicEnble;               
        /// <summary>
        /// picture info
        /// 物体对应图片信息
        /// </summary>
		public NET_PIC_INFO                         stPicInfo;              
        /// <summary>
        /// is shot frame
        /// 是否是抓拍张的识别结果
        /// </summary>
		public byte				                    bShotFrame;				
        /// <summary>
        /// rgbaMainColor is enable
        /// 物体颜色(rgbaMainColor)是否可用
        /// </summary>
		public byte				                    bColor;					 
        /// <summary>
        /// Reserved
        /// 保留，字节对齐
        /// </summary>
		public byte				                    byReserved2;
        /// <summary>
        /// Time indicates the type of detailed instructions,EM_TIME_TYP
        /// 时间表示类型,详见EM_TIME_TYPE说明
        /// </summary>
		public byte                                 byTimeType;             
        /// <summary>
        /// in view of the video compression,current time(when object snap or reconfnition, the frame will be attached to the frame in a video or pictures,means the frame in the original video of the time)
        /// 针对视频浓缩,当前时间戳（物体抓拍或识别时,会将此识别智能帧附在一个视频帧或jpeg图片中,此帧所在原始视频中的出现时间）
        /// </summary>
		public NET_TIME_EX			                stuCurrentTime;			 
        /// <summary>
        /// strart time(object appearing for the first time)
        /// 开始时间戳（物体开始出现时）
        /// </summary>
		public NET_TIME_EX			                stuStartTime;			
        /// <summary>
        /// end time(object appearing for the last time) 
        /// 结束时间戳（物体最后出现时）
        /// </summary>
		public NET_TIME_EX			                stuEndTime;				     
		#if(LINUX_X64)
		public NET_RECT_LONG_TYPE                   stuOriginalBoundingBox;	
        public NET_RECT_LONG_TYPE                   stuSignBoundingBox;	    
        #else
        /// <summary>
        /// original bounding box(absolute coordinates)
        /// 包围盒(绝对坐标)
        /// </summary>
        public NET_RECT                             stuOriginalBoundingBox;	 
        /// <summary>
        /// sign bounding box coordinate
        /// 车标坐标包围盒
        /// </summary>
        public NET_RECT                             stuSignBoundingBox;     
#endif
        /// <summary>
        /// The current frame number (frames when grabbing the object)
        /// 当前帧序号（抓下这个物体时的帧）
        /// </summary>
	    public uint				                    dwCurrentSequence;		
        /// <summary>
        /// Start frame number (object appeared When the frame number
        /// 开始帧序号（物体开始出现时的帧序号）
        /// </summary>
	    public uint				                    dwBeginSequence;		
        /// <summary>
        /// The end of the frame number (when the object disappearing Frame number)
        /// 结束帧序号（物体消逝时的帧序号）
        /// </summary>
	    public uint				                    dwEndSequence;			 
        /// <summary>
        /// At the beginning of the file offset, Unit: Word Section (when objects began to appear, the video frames in the original video file offset relative to the beginning of the file
        /// 开始时文件偏移, 单位: 字节（物体开始出现时,视频帧在原始视频文件中相对于文件起始处的偏移）
        /// </summary>
	    public Int64				                nBeginFileOffset;		 
        /// <summary>
        /// At the end of the file offset, Unit: Word Section (when the object disappeared, video frames in the original video file offset relative to the beginning of the file)
        /// 结束时文件偏移, 单位: 字节（物体消逝时,视频帧在原始视频文件中相对于文件起始处的偏移）
        /// </summary>
	    public Int64				                nEndFileOffset;			 
        /// <summary>
        /// Object color similarity, the range :0-100, represents an array subscript Colors, see EM_COLOR_TYPE
        /// 物体颜色相似度,取值范围：0-100,数组下标值代表某种颜色,详见EM_COLOR_TYPE
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[]                               byColorSimilar;         
        /// <summary>
        /// When upper body color similarity (valid object type man )
        /// 上半身物体颜色相似度(物体类型为人时有效)
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
 	    public byte[]                               byUpperBodyColorSimilar;
        /// <summary>
        /// Lower body color similarity when objects (object type human valid )
        /// 下半身物体颜色相似度(物体类型为人时有效)
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
 	    public byte[]                               byLowerBodyColorSimilar;
        /// <summary>
        /// ID of relative object
        /// 相关物体ID
        /// </summary>
        public int                                  nRelativeID;            
        /// <summary>
        /// "ObjectType"is "Vehicle" or "Logo" means a certain brand under LOGO such as Audi A6L since there are so many brands SDK sends this field in real-time ,device filled as real.
        /// "ObjectType"为"Vehicle"或者"Logo"时,表示车标下的某一车系,比如奥迪A6L,由于车系较多,SDK实现时透传此字段,设备如实填写
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	    public byte[]				                szSubText;				 
        /// <summary>
        /// Specifies the model years of vehicle. the real value can be found in a mapping table from the development manual 
        /// 车辆品牌年款 需要通过映射表得到真正的年款 映射表详见开发手册
        /// </summary>
        public ushort                               wBrandYear;             
    }

    /// <summary>
    /// enum time type
    /// 时间类型
    /// </summary>
    public enum EM_TIME_TYPE
    {
        /// <summary>
        /// absolute time 
        /// 绝对时间
        /// </summary>
	    ABSLUTE,                                                             
        /// <summary>
        /// Relative time, relative to the video file header frame as the time basis points, the first frame corresponding to the UTC (0000-00-00 00:00:00)
        /// 相对时间,相对于视频文件头帧为时间基点,头帧对应于UTC(0000-00-00 00:00:00)
        /// </summary>
	    RELATIVE,                                                           
    }

    /// <summary>
    /// enum color type
    /// 颜色类型
    /// </summary>
    public enum EM_COLOR_TYPE
    {
        /// <summary>
        /// red
        /// 红色
        /// </summary>
	    RED,                                                              
        /// <summary>
        /// yellow
        /// 黄色
        /// </summary>
	    YELLOW,                                                           
        /// <summary>
        /// green
        /// 绿色
        /// </summary>
	    GREEN,                                                            
        /// <summary>
        /// cyan
        /// 青色
        /// </summary>
	    CYAN,                                                             
        /// <summary>
        /// glue
        /// 蓝色
        /// </summary>
	    BLUE,                                                             
        /// <summary>
        /// purple
        /// 紫色
        /// </summary>
	    PURPLE,                                                           
        /// <summary>
        /// black
        /// 黑色
        /// </summary>
	    BLACK,                                                            
        /// <summary>
        /// white
        /// 白色
        /// </summary>
	    WHITE,
        /// <summary>
        /// max
        /// 最大值
        /// </summary>
        MAX,                                           
    }

    /// <summary>
    /// rect size struct
    /// 矩形大小
    /// </summary>
    public struct NET_RECT 
    {
        /// <summary>
        /// left
        /// 左
        /// </summary>
        public int					                nLeft;               
        /// <summary>
        /// top
        /// 上
        /// </summary>
        public int					                nTop;                
        /// <summary>
        /// right
        /// 右
        /// </summary>
        public int					                nRight;              
        /// <summary>
        /// bottom
        /// 下
        /// </summary>
        public int					                nBottom;             
    }

	/// <summary>
	/// rect size struct for linux x64
    /// Linux64平台下矩形大小
	/// </summary>
	public struct NET_RECT_LONG_TYPE
	{
        /// <summary>
        /// left
        /// 左
        /// </summary>
		public long                                 nLeft;                
        /// <summary>
        /// top
        /// 上
        /// </summary>
		public long                                 nTop;                 
        /// <summary>
        /// right
        /// 右
        /// </summary>
		public long                                 nRight;               
        /// <summary>
        /// bottom
        /// 下
        /// </summary>
		public long                                 nBottom;              
	}

	/// <summary>
	/// dimension point struct
    /// 坐标点
	/// </summary>
	public struct NET_POINT    
	{
        /// <summary>
        /// x
        /// 坐标x
        /// </summary>
		public short					            nx;                    
        /// <summary>
        /// y
        /// 坐标y
        /// </summary>
		public short					            ny;                    
	}

    /// <summary>
    /// picture information struct
    /// 图片信息
    /// </summary>
    public struct NET_PIC_INFO  
    {
        /// <summary>
        /// current picture file's offset in the binary file, byte
        /// 文件在二进制数据块中的偏移位置, 单位:字节
        /// </summary>
	    public uint                                 dwOffSet;              
        /// <summary>
        /// current picture file's size, byte
        /// 文件大小, 单位:字节
        /// </summary>
	    public uint                                 dwFileLenth;           
        /// <summary>
        /// picture width, pixel
        /// 图片宽度, 单位:像素
        /// </summary>
	    public ushort                               wWidth;                
        /// <summary>
        /// picture high, pixel
        /// 图片高度, 单位:像素
        /// </summary>
	    public ushort                               wHeight;               
        /// <summary>
        /// File path,User use this field need to apply for space for copy and storage
        /// 文件路径，用户使用该字段时需要自行申请空间进行拷贝保存
        /// </summary>
        public IntPtr                               pszFilePath;                                                                             
        /// <summary>
        /// When submit to the server, the algorithm has checked the image or not 
        /// 图片是否算法检测出来的检测过的提交识别服务器时
        /// </summary>
        public byte                                 bIsDetected;			
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
        public byte[]                               bReserved;
        /// <summary>
        /// The upper left corner of the figure is in the big picture. Absolute coordinates are used
        /// 小图左上角在大图的位置，使用绝对坐标系
        /// </summary>
        public NET_POINT                            stuPoint;
    }

    /// <summary>
    /// event file information struct
    /// 事件对应文件信息
    /// </summary>
    public struct NET_EVENT_FILE_INFO
    {
        /// <summary>
        /// the file count in the current file's group
        /// 当前文件所在文件组中的文件总数
        /// </summary>
	    public byte                                 bCount;              
        /// <summary>
        /// the index of the file in the group
        /// 当前文件在文件组中的文件编号(编号1开始)
        /// </summary>
	    public byte                                 bIndex;              
        /// <summary>
        /// file tag, see the enum EM_EVENT_FILETAG
        /// 文件标签, EM_EVENT_FILETAG
        /// </summary>
	    public byte                                 bFileTag;            
        /// <summary>
        /// file type,0-normal 1-compose 2-cut picture
        /// 文件类型,0-普通 1-合成 2-抠图
        /// </summary>
	    public byte                                 bFileType;           
        /// <summary>
        /// file time
        /// 文件时间
        /// </summary>
	    public NET_TIME_EX                          stuFileTime;         
        /// <summary>
        /// the only id of one group file
        /// 同一组抓拍文件的唯一标识
        /// </summary>
	    public uint                                 nGroupId;            
    }

    /// <summary>
    /// event file's tag type
    /// 事件文件的文件标签类型
    /// </summary>
    public enum EM_EVENT_FILETAG
    {
        /// <summary>
        /// Before ATM Paste
        /// ATM贴条前
        /// </summary>
        NET_ATMBEFOREPASTE = 1,                                            
        /// <summary>
        /// After ATM Paste
        /// ATM贴条后
        /// </summary>
        NET_ATMAFTERPASTE,                                                 
    }

    /// <summary>
    /// picture resolution struct
    /// 图片分辨率
    /// </summary>
    public struct NET_RESOLUTION_INFO
    {
        /// <summary>
        /// width
        /// 宽
        /// </summary>
	    public ushort                               snWidth;               
        /// <summary>
        /// hight
        /// 高
        /// </summary>
 	    public ushort                               snHight;               
    }

    /// <summary>
    /// trafficCar event information struct
    /// 交通车辆信息
    /// </summary>
    public struct NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO
    {
        /// <summary>
        /// plate number
        /// 车牌号码
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	    public string                               szPlateNumber;        
        /// <summary>
        /// plate type
        /// 号牌类型
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	    public string                               szPlateType;          
        /// <summary>
        /// plate color, "Blue","Yellow", "White","Black"
        /// 车牌颜色
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	    public string                               szPlateColor;         
        /// <summary>
        /// vehicle color, "White", "Black", "Red", "Yellow", "Gray", "Blue","Green"
        /// 车身颜色
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	    public string                               szVehicleColor;        
        /// <summary>
        /// speed, Km/H
        /// 速度    单位Km/H
        /// </summary>
	    public int                                  nSpeed;                
        /// <summary>
        /// trigger event type
        /// 触发的相关事件
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[]                               szEvent;              
        /// <summary>
        /// violation code, see TrafficGlobal.ViolationCode
        /// 违章代码
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[]                               szViolationCode;      
        /// <summary>
        /// violation describe
        /// 违章描述
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[]                               szViolationDesc;      
        /// <summary>
        /// lower speed limit
        /// 速度下限
        /// </summary>
	    public int                                  nLowerSpeedLimit;     
        /// <summary>
        /// upper speed limit
        /// 速度上限
        /// </summary>
	    public int                                  nUpperSpeedLimit;     
        /// <summary>
        /// over speed margin, km/h 
        /// 限高速宽限值    单位：km/h 
        /// </summary>
	    public int                                  nOverSpeedMargin;     
        /// <summary>
        /// under speed margin, km/h 
        /// 限低速宽限值    单位：km/h
        /// </summary>
	    public int                                  nUnderSpeedMargin;    
        /// <summary>
        /// lane
        /// 车道
        /// </summary>
	    public int                                  nLane;                
        /// <summary>
        /// vehicle size type
        /// 车辆大小类型
        /// </summary>
        public EM_VehicleSizeType                   nVehicleSize;                                                                           
        /// <summary>
        /// vehicle length, m
        /// 车辆长度    单位米
        /// </summary>
	    public float                                fVehicleLength;         
        /// <summary>
        /// snap mode 0-normal,1-globle,2-near,4-snap on the same side,8-snap on the reverse side,16-plant picture
        /// 抓拍方式    0-未分类,1-全景,2-近景,4-同向抓拍,8-反向抓拍,16-号牌图像
        /// </summary>
	    public int                                  nSnapshotMode;        
        /// <summary>
        /// channel name
        /// 本地或远程的通道名称,可以是地点信息
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[]                               szChannelName;        
        /// <summary>
        /// Machine name
        /// 本地或远程设备名称
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	    public byte[]                               szMachineName;        
        /// <summary>
        /// machine group
        /// 机器分组或叫设备所属单位
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	    public byte[]                               szMachineGroup;       
        /// <summary>
        /// road way number
        /// 道路编号
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[]                               szRoadwayNo;          
        /// <summary>
        /// DrivingDirection: for example ["Approach", "Shanghai", "Hangzhou"]
        /// 行驶方向 , "DrivingDirection" : ["Approach", "上海", "杭州"]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3 * 256)]
	    public byte[]                               szDrivingDirection;      
        /// <summary>
        /// device address,OSD superimposed onto the image,from TrafficSnapshot.DeviceAddress,'\0'means end.
        /// 设备地址,OSD叠加到图片上的,来源于配置TrafficSnapshot.DeviceAddress,'\0'结束
        /// </summary>
	    public IntPtr                               szDeviceAddress;         
        /// <summary>
        /// Vehicle identification, such as "Unknown" - unknown "Audi" - Audi, "Honda" - Honda
        /// 车辆标识, 例如 "Unknown"-未知, "Audi"-奥迪, "Honda"-本田
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[]			                    szVehicleSign;			
        /// <summary>
        /// Generated by the vehicle inspection device to capture the signal redundancy
        /// 由车检器产生抓拍信号冗余信息
        /// </summary>
	    public NET_SIG_CARWAY_INFO_EX               stuSigInfo;            
        /// <summary>
        /// Equipment deployment locations
        /// 设备部署地点
        /// </summary>
	    public IntPtr                               szMachineAddr;			
        /// <summary>
        /// Current picture exposure time, in milliseconds
        /// 当前图片曝光时间,单位为毫秒
        /// </summary>
	    public float                                fActualShutter;        
        /// <summary>
        /// Current picture gain, ranging from 0 to 100
        /// 当前图片增益,范围为0~100
        /// </summary>
	    public byte                                 byActualGain;          
        /// <summary>
        /// Lane Direction,0 - south to north 1- Southwest to northeast 2 - West to east, 3 - Northwest to southeast 4 - north to south 5 - northeast to southwest 6 - East to West 7 - Southeast to northwest 8 - Unknown 9-customized
        /// 车道方向,0-南向北 1-西南向东北 2-西向东 3-西北向东南 4-北向南 5-东北向西南 6-东向西 7-东南向西北 8-未知 9-自定义
        /// </summary>
	    public byte			                        byDirection;			 
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[]			                    byReserved;
        /// <summary>
        /// Address, as szDeviceAddress supplement
        /// 详细地址, 作为szDeviceAddress的补充
        /// </summary>
	    public IntPtr			                    szDetailedAddress;       
        /// <summary>
        /// waterproof
        /// 图片防伪码
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[]                               szDefendCode;              
        /// <summary>
        /// Link black list data recorddefualt main keyID, 0 invalid,>0 black list data record
        /// 关联黑名单数据库记录默认主键ID, 0,无效；> 0,黑名单数据记录
        /// </summary>
        public int                                  nTrafficBlackListID;     
        /// <summary>
        /// bofy color RGBA
        /// 车身颜色RGBA
        /// </summary>
        public NET_COLOR_RGBA                       stuRGBA;                 
        /// <summary>
        /// snap time
        /// 抓拍时间
        /// </summary>
        public NET_TIME                             stSnapTime;             
        /// <summary>
        /// Rec No
        /// 记录编号
        /// </summary>
        public int                                  nRecNo;                 
        /// <summary>
        /// self defined parking space number for parking
        /// 自定义车位号（停车场用）
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)]
        public byte[]                               szCustomParkNo;          
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[]                               byReserved1;
        /// <summary>
        /// Metal plate No. 
        /// 车板位号
        /// </summary>
        public int                                  nDeckNo;                
        /// <summary>
        /// Free metal plate No.
        /// 空闲车板数量
        /// </summary>
        public int                                  nFreeDeckCount;          
        /// <summary>
        /// Occupized metal plate No. 
        /// 占用车板数量
        /// </summary>
        public int                                  nFullDeckCount;          
        /// <summary>
        /// Total metal plate No. 
        /// 总共车板数量
        /// </summary>
        public int                                  nTotalDeckCount;         
        /// <summary>
        /// violation name
        /// 违章名称
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[]                               szViolationName;         
        /// <summary>
        /// Weight of car(kg)
        /// 车重(单位 Kg)
        /// </summary>
	    public uint	                                nWeight;				
        /// <summary>
        /// custom road way, valid when byDirection is 9
        /// 自定义车道方向,byDirection为9时有效
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[]                               szCustomRoadwayDirection; 
        /// <summary>
        /// the physical lane number,value form 0 to 5
        /// 物理车道号,取值0到5
        /// </summary>
        public byte                                 byPhysicalLane;                     
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[]                               byReserved2;
        /// <summary>
        /// moving direction
        /// 车辆行驶方向
        /// </summary>
        public EM_TRAFFICCAR_MOVE_DIRECTION         emMovingDirection;         
        /// <summary>
        /// corresponding to throughTime
        /// 对应电子车牌标签信息中的过车时间(ThroughTime)
        /// </summary>
        public NET_TIME		                        stuEleTagInfoUTC;			
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 552)]
        public byte[]                               bReserved;             
    }

    /// <summary>
    /// traffic car move direction type
    /// 交通车辆行驶方向类型
    /// </summary>
    public enum EM_TRAFFICCAR_MOVE_DIRECTION
    {
        /// <summary>
        /// unknown
        /// 未知的
        /// </summary>
        UNKNOWN,                          
        /// <summary>
        /// straight
        /// 直行
        /// </summary>
        STRAIGHT,                         
        /// <summary>
        /// turn left
        /// 左转
        /// </summary>
        TURN_LEFT,                        
        /// <summary>
        /// turn right
        /// 右转
        /// </summary>
        TURN_RIGHT,                       
        /// <summary>
        /// turn around
        /// 掉头
        /// </summary>
        TURN_AROUND,                      
    }

    /// <summary>
    /// VehicleSize
    /// 车身大小
    /// </summary>
    public enum EM_VehicleSizeType
    {
        /// <summary>
        /// UnKnow
        /// 未知
        /// </summary>
        UnKnow = -1,
        /// <summary>
        /// Light-duty
        /// 小型车
        /// </summary>
        Light_Duty = 1,
        /// <summary>
        /// Medium
        /// 中型车
        /// </summary>
        Medium = 1 << 1,
        /// <summary>
        /// Oversize
        /// 大型车
        /// </summary>
        Oversize = 1 << 2,
        /// <summary>
        /// Minisize
        /// 微型车
        /// </summary>
        Minisize = 1 << 3,
        /// <summary>
        /// Largesize
        /// 长车
        /// </summary>
        Largesize = 1 << 4,
    }

    /// <summary>
    /// Vehicle detector redundancy information
    /// 车检器冗余信息
    /// </summary>
    public struct NET_SIG_CARWAY_INFO_EX
    {
        /// <summary>
        /// The vehicle detector generates the snap signal redundancy info
        /// 由车检器产生抓拍信号冗余信息
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	    public byte[]                               byRedundance;            
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 120)]
	    public byte[]                               bReserved;            
    }

    /// <summary>
    /// color RGBA
    /// 颜色RGBA
    /// </summary>
    public struct NET_COLOR_RGBA
    {
        /// <summary>
        /// red
        /// 红
        /// </summary>
        public int	                                nRed;                  
        /// <summary>
        /// green
        /// 绿
        /// </summary>
        public int                                  nGreen;                
        /// <summary>
        /// blue
        /// 蓝
        /// </summary>
        public int                                  nBlue;                 
        /// <summary>
        /// transparent
        /// 透明
        /// </summary>
        public int                                  nAlpha;                
    }

    /// <summary>
    /// common event information
    /// 事件通用信息
    /// </summary>
    public struct NET_EVENT_COMM_INFO
    {
        /// <summary>
        /// NTP time sync status
        /// NTP校时状态
        /// </summary>
        public EM_NTP_STATUS				emNTPStatus;					 
        /// <summary>
        /// driver info number
        /// 驾驶员信息数
        /// </summary>
        public int							nDriversNum;					
        /// <summary>
        /// driver info data (NET_MSG_OBJECT_EX)
        /// 驾驶员信息数据(NET_MSG_OBJECT_EX)
        /// </summary>
        public IntPtr			            pstDriversInfo;					
        /// <summary>
        /// writing path for loacl disk or sd card, or write to default path if NULL
        /// 本地硬盘或者sd卡成功写入路径,为NULL时,路径不存在
        /// </summary>
        public IntPtr						pszFilePath;					
        /// <summary>
        /// ftp path
        /// 设备成功写到ftp服务器的路径
        /// </summary>
        public IntPtr						pszFTPPath;						
        /// <summary>
        /// ftp path for assocated video
        /// 当前接入需要获取当前违章的关联视频的FTP上传路径
        /// </summary>
        public IntPtr						pszVideoPath;					
        /// <summary>
        /// Seat info
        /// 驾驶位信息
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public NET_EVENT_COMM_SEAT[]		stCommSeat;					    
        /// <summary>
        /// Car Attachment number
        /// 车辆物件个数
        /// </summary>
	    public int							nAttachmentNum;					
        /// <summary>
        /// Car Attachment
        /// 车辆物件信息
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	    public NET_EVENT_COMM_ATTACHMENT[]	stuAttachment;				    
        /// <summary>
        /// Annual Inspection number
        /// 年检标志个数
        /// </summary>
	    public int							nAnnualInspectionNum;		    
        /// <summary>
        /// Annual Inspection
        /// 年检标志
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	    public NET_RECT[]				    stuAnnualInspection;
        /// <summary>
        /// The ratio of HC,unit,%/1000000
        /// HC所占比例，单位：%/1000000 
        /// </summary>
	    public float                        fHCRatio;                                               
        /// <summary>
        /// The ratio of NO,unit,%/1000000
        /// NO所占比例，单位：%/1000000 
        /// </summary>
        public float                        fNORatio;                                              
        /// <summary>
        /// The percent of CO,unit,% ,range from 0 to 100
        /// CO所占百分比，单位：% 取值0~100
        /// </summary>
        public float                        fCOPercent;                                             
        /// <summary>
        /// The percent of CO2,unit: % ,range from 0 to 100  
        /// CO2所占百分比，单位：% 取值0~100 
        /// </summary>
        public float                        fCO2Percent;                                           
        /// <summary>
        /// The obscuration of light,unit,% ,range from 0 to 100
        /// 不透光度，单位：% 取值0~100
        /// </summary>
        public float                        fLightObscuration;                                    
        /// <summary>
        /// Original pictures info number
        /// 原始图片张数
        /// </summary>
        public int                          nPictureNum;                                           
        /// <summary>
        /// Original pictures info data
        /// 原始图片信息
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public NET_EVENT_PIC_INFO[]         stuPicInfos;                     
        /// <summary>
        /// Temperature,unit: centigrade
        /// 温度值,单位摄氏度
        /// </summary>
        public float                        fTemperature;                                           
        /// <summary>
        /// Humidity,unit: %
        /// 相对湿度百分比值
        /// </summary>
        public int                          nHumidity;                                              
        /// <summary>
        /// Pressure,unit: Kpa
        /// 气压值,单位Kpa
        /// </summary>
        public float                        fPressure;                                              
        /// <summary>
        /// Wind force,unit: m/s
        /// 风力值,单位m/s
        /// </summary>
        public float                        fWindForce;                                             
        /// <summary>
        /// Wind direction,unit: degree,range:[0,360]
        /// 风向,单位度,范围:[0,360]
        /// </summary>
        public uint                         nWindDirection;                                         
        /// <summary>
        /// Road gradient,unit: degree
        /// 道路坡度值,单位度
        /// </summary>
        public float                        fRoadGradient;                                          
        /// <summary>
        /// Acceleration,unit: m/s2
        /// 加速度值,单位:m/s2
        /// </summary>
        public float                        fAcceleration;                                          
        /// <summary>
        /// RFID electronics tag info
        /// RFID 电子车牌标签信息
        /// </summary>
	    public NET_RFIDELETAG_INFO			stuRFIDEleTagInfo;										     
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 704)]
        public byte[]					    bReserved;						
        /// <summary>
        /// Country
        /// 国家
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[]						szCountry;						
    }

    /// <summary>
    /// traffic event snap picture info
    /// 交通抓图图片信息
    /// </summary>
    public struct NET_EVENT_PIC_INFO
    {
        /// <summary>
        /// offset
        /// 原始图片偏移，单位字节
        /// </summary>
        public uint                       nOffset;                
        /// <summary>
        /// length of picture
        /// 原始图片长度，单位字节
        /// </summary>
        public uint                       nLength;               
    }

    /// <summary>
    /// the info of RFID electronic tag 
    /// RFID 电子车牌标签信息
    /// </summary>
    public struct NET_RFIDELETAG_INFO
    {
        /// <summary>
        /// card ID
        /// 卡号
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public byte[]					        szCardID;			
        /// <summary>
        /// card type, 0:issued by transport administration offices, 1:new factory preloaded card
        /// 卡号类型, 0:交通管理机关发行卡, 1:新车出厂预装卡
        /// </summary>
	    public int						        nCardType;										
        /// <summary>
        /// card privince
        /// 卡号省份
        /// </summary>
	    public EM_CARD_PROVINCE		            emCardPrivince;									
        /// <summary>
        /// plate number
        /// 车牌号码
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[]					        szPlateNumber;			
        /// <summary>
        /// production data
        /// 出厂日期
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public byte[]					        szProductionDate;		
        /// <summary>
        /// car type
        /// 车辆类型
        /// </summary>
	    public EM_CAR_TYPE				        emCarType;										
        /// <summary>
        /// power, unit:kilowatt-hour, range:0~254, 255 means larger than maximum power value can be stored
        /// 功率,单位：千瓦时，功率值范围0~254；255表示该车功率大于可存储的最大功率值
        /// </summary>
	    public int						        nPower;											
        /// <summary>
        /// displacement, unit:100ml, range:0~254, 255 means larger than maximum displacement value can be stored
        /// 排量,单位：百毫升，排量值范围0~254；255表示该车排量大于可存储的最大排量值
        /// </summary>
	    public int						        nDisplacement;									
        /// <summary>
        /// antenna ID, range:1~4
        /// 天线ID，取值范围:1~4
        /// </summary>
	    public int						        nAntennaID;										
        /// <summary>
        /// plate type
        /// 号牌种类
        /// </summary>
	    public EM_PLATE_TYPE			        emPlateType;									
        /// <summary>
        /// validity of inspection, year-month
        /// 检验有效期，年-月
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public byte[]					        szInspectionValidity;	
        /// <summary>
        /// the flag of inspetion, 0:already inspection, 1:not inspection
        /// 逾期未年检标志, 0:已年检, 1:逾期未年检
        /// </summary>
	    public int						        nInspectionFlag;								
        /// <summary>
        /// the years form effective inspection preiod to compulsory discarding preiod
        /// 强制报废期，从检验有效期开始，距离强制报废期的年数
        /// </summary>
	    public int						        nMandatoryRetirement;							
        /// <summary>
        /// car color
        /// 车身颜色
        /// </summary>
	    public EM_CAR_COLOR_TYPE		        emCarColor;										
        /// <summary>
        /// authorized capacity, unit:people, less than 0:incalid
        /// 核定载客量，该值 小于0 时：无效；此值表示核定载客，单位为人
        /// </summary>
	    public int						        nApprovedCapacity;								
        /// <summary>
        /// total weight, unit:100kg, range:0~0x3FF,  0x3FF1023:larger than maximum value can be stored, less than 0:invalid
        /// 此值表示总质量，单位为百千克；该值小于0时：无效；该值的有效范围为0~0x3FF，0x3FF（1023）表示数据值超过了可存储的最大值
        /// </summary>
	    public int						        nApprovedTotalQuality;							
        /// <summary>
        /// the time when the car is pass
        /// 过车时间
        /// </summary>
	    public NET_TIME_EX				        stuThroughTime;									
        /// <summary>
        /// use property
        /// 使用性质
        /// </summary>
	    public EM_USE_PROPERTY_TYPE	            emUseProperty;									
        /// <summary>
        /// Licensing code, UTF-8 encoding
        /// 发牌代号，UTF-8编码
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	    public byte[]					        szPlateCode;				
        /// <summary>
        /// Plate number, serial number, UTF-8 code
        /// 号牌号码序号，UTF-8编码
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public byte[]					        szPlateSN;				
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 104)]
	    public byte[]               		    bReserved;		                      		
    }

    /// <summary>
    /// card province
    /// 卡号省份
    /// </summary>
    public enum EM_CARD_PROVINCE
    {
        /// <summary>
        /// UNKNOWN
        /// 解析出错，未知省份
        /// </summary>
	    UNKNOWN			= 10,		
        /// <summary>
        /// BeiJing
        /// 北京
        /// </summary>
	    BEIJING			= 11,		
        /// <summary>
        /// TianJin
        /// 天津
        /// </summary>
	    TIANJIN			= 12,		
        /// <summary>
        /// HeBei
        /// 河北
        /// </summary>
	    HEBEI			= 13,		
        /// <summary>
        /// ShanXi, the provincial capital is TaiYuan
        /// 山西
        /// </summary>
	    SHANXI_TAIYUAN	= 14,		
        /// <summary>
        /// NeiMengGu
        /// 内蒙古
        /// </summary>
	    NEIMENGGU		= 15,		
        /// <summary>
        /// LiaoNing
        /// 辽宁
        /// </summary>
	    LIAONING		= 21,		
        /// <summary>
        /// JiKin
        /// 吉林
        /// </summary>
	    JILIN			= 22,		
        /// <summary>
        /// HeiLongJiang
        /// 黑龙江
        /// </summary>
	    HEILONGJIANG	= 23,		
        /// <summary>
        /// ShangHai
        /// 上海
        /// </summary>
	    SHANGHAI		= 31,		
        /// <summary>
        /// JiangSu
        /// 江苏
        /// </summary>
	    JIANGSU			= 32,		
        /// <summary>
        /// ZheJiang
        /// 浙江
        /// </summary>
	    ZHEJIANG		= 33,		
        /// <summary>
        /// AnHui
        /// 安徽
        /// </summary>
	    ANHUI			= 34,		
        /// <summary>
        /// FuJian
        /// 福建
        /// </summary>
	    FUJIAN			= 35,		
        /// <summary>
        /// JiangXi
        /// 江西
        /// </summary>
	    JIANGXI			= 36,		
        /// <summary>
        /// ShanDong
        /// 山东
        /// </summary>
	    SHANDONG		= 37,		
        /// <summary>
        /// HeNan
        /// 河南
        /// </summary>
	    HENAN			= 41,		
        /// <summary>
        /// HuBei
        /// 湖北
        /// </summary>
	    HUBEI			= 42,		
        /// <summary>
        /// HuNan
        /// 湖南
        /// </summary>
	    HUNAN			= 43,		
        /// <summary>
        /// GuangDong
        /// 广东
        /// </summary>
	    GUANGDONG		= 44,		
        /// <summary>
        /// GuangXi
        /// 广西
        /// </summary>
	    GUANGXI			= 45,		
        /// <summary>
        /// HaiNan
        /// 海南
        /// </summary>
	    HAINAN			= 46,		
        /// <summary>
        /// ChongQing
        /// 重庆
        /// </summary>
	    CHONGQING		= 50,		
        /// <summary>
        /// SiChuan
        /// 四川
        /// </summary>
	    SICHUAN			= 51,		
        /// <summary>
        /// GuiZhou
        /// 贵州
        /// </summary>
	    GUIZHOU			= 52,		
        /// <summary>
        /// YunNan
        /// 云南
        /// </summary>
	    YUNNAN			= 53,		
        /// <summary>
        /// XiZang
        /// 西藏
        /// </summary>
	    XIZANG			= 54,		
        /// <summary>
        /// ShanXi , the provincial capital is XiAn
        /// 陕西
        /// </summary>
	    SHANXI_XIAN		= 61,		
        /// <summary>
        /// GanSu
        /// 甘肃
        /// </summary>
	    GANSU			= 62,		
        /// <summary>
        /// QingHai
        /// 青海
        /// </summary>
	    QINGHAI			= 63,		
        /// <summary>
        /// NingXia
        /// 宁夏
        /// </summary>
	    NINGXIA			= 64,		
        /// <summary>
        /// XinJiang
        /// 新疆
        /// </summary>
	    XINJIANG		= 65,		
        /// <summary>
        /// XiangGang
        /// 香港
        /// </summary>
	    XIANGGANG		= 71,		
        /// <summary>
        /// AoMen
        /// 澳门
        /// </summary>
	    AOMEN			= 82,		
    }

    /// <summary>
    /// the type of the car
    /// 车辆类型
    /// </summary>
    public enum EM_CAR_TYPE
    {
        /// <summary>
        /// unknown
        /// 未知
        /// </summary>
	    UNKNOWN,			
        /// <summary>
        /// bus
        /// 客车
        /// </summary>
	    BUS,				
        /// <summary>
        /// big truck
        /// 大货车
        /// </summary>
	    BIG_TRUCK,			
        /// <summary>
        /// medium truck
        /// 中货车
        /// </summary>
	    MEDIUM_TRUCK,		
        /// <summary>
        /// car
        /// 轿车
        /// </summary>
	    CAR,				
        /// <summary>
        /// van
        /// 面包车
        /// </summary>
	    VAN,				
        /// <summary>
        /// small truck
        /// 小货车
        /// </summary>
	    SMALL_TRUCK,		
        /// <summary>
        /// tricycle
        /// 三轮车
        /// </summary>
	    TRICYCLE,			
        /// <summary>
        /// motocycle
        /// 摩托车
        /// </summary>
	    MOTORCYCLE,			
        /// <summary>
        /// pedestrian
        /// 行人
        /// </summary>
	    PEDESTRIAN,			
        /// <summary>
        /// SUV-MPV
        /// SUV-MPV
        /// </summary>
	    SUVMPV,				
        /// <summary>
        /// medium bus
        /// 中客车
        /// </summary>
	    MEDIUM_BUS,			
        /// <summary>
        /// hazardous chemical vehicles
        /// 危化品车辆
        /// </summary>
	    DANGE_VEHICLE,		
    }

    /// <summary>
    /// the tpye of the plate
    /// 号牌类型
    /// </summary>
    public enum EM_PLATE_TYPE
    {
        /// <summary>
        /// unkonwn
        /// 未知
        /// </summary>
	    UNKNOWN,				
        /// <summary>
        /// big car (black words on yellow background)
        /// 大型汽车（黄底黑字）
        /// </summary>
	    BIGCAR,				
        /// <summary>
        /// small car (white words on blue background)
        /// 小型汽车（蓝底白字）
        /// </summary>
	    SMALLCAR,				
        /// <summary>
        /// embassy car (white words on black background, and the word '使' is red)
        /// 使馆汽车（黑底白字、红'使'字）
        /// </summary>
	    EMBASSYCAR,			
        /// <summary>
        /// consulate car (white words on black background, and the word '领' is red)
        /// 领馆汽车（黑底白字，红'领'字）
        /// </summary>
	    CONSULATECAR,			
        /// <summary>
        /// abroad car (white/red words on black background)
        /// 境外汽车（黑底白/红字）
        /// </summary>
	    ABROADCAR,				
        /// <summary>
        /// foreign car (white words on black background)
        /// 外籍汽车（黑底白字）
        /// </summary>
	    FOREIGNCAR,			
        /// <summary>
        /// police plate
        /// 警牌
        /// </summary>
	    POLICE,				
        /// <summary>
        /// armed police plate
        /// 武警牌
        /// </summary>
	    ARMEDPOLICE,		
        /// <summary>
        /// troops plate
        /// 部队号牌
        /// </summary>
	    TROOPS,				
        /// <summary>
        /// troops plate which is double layer
        /// 部队双层
        /// </summary>
	    TROOPSDOUBLE,		
        /// <summary>
        /// yellow tail plate which double layer
        /// 双层黄尾牌
        /// </summary>
	    YELLOWTAILDOUBLE,	
	    /// <summary>
	    /// coach car plate
        /// 教练车号牌
	    /// </summary>
	    COACHCAR,			
        /// <summary>
        /// personality plate
        /// 个性号牌
        /// </summary>
	    PERSONALITY,		
        /// <summary>
        /// agricultural plate
        /// 农用牌
        /// </summary>
	    AGRICULTURAL,		
        /// <summary>
        /// motorcycle plate
        /// 摩托车号牌
        /// </summary>
	    MOTORCYCLE,			
        /// <summary>
        /// tractor plate
        /// 拖拉机号牌
        /// </summary>
	    TRACTOR,				
        /// <summary>
        /// small car (white words on black background)
        /// 小型汽车(黑底白字)
        /// </summary>
	    SMALLCAR_BLACK,		
        /// <summary>
        /// red plate
        /// 红牌车
        /// </summary>
	    RED,					
        /// <summary>
        /// blue plate
        /// 青牌车
        /// </summary>
	    BLUE,					
        /// <summary>
        /// white plate
        /// 白牌车
        /// </summary>
	    WHITE,					
        /// <summary>
        /// pure electric and new enegry car
        /// 纯电动新能源小车
        /// </summary>
	    PURE_NEW_SMALLCAR,		
        /// <summary>
        /// hybrid and new enegry car
        /// 混合新能源小车
        /// </summary>
	    BLEND_NEW_SMALLCAR,	 
        /// <summary>
        /// pure electric and new enegry cart
        /// 纯电动新能源大车
        /// </summary>
	    PURE_NEW_BIGCAR,		
        /// <summary>
        /// hybrid and new enegry cart
        /// 混合新能源大车
        /// </summary>
	    BLEND_NEW_BIGCAR,		
    }

    /// <summary>
    /// car color
    /// 车身颜色
    /// </summary>
    public enum EM_CAR_COLOR_TYPE
    {
        /// <summary>
        /// white
        /// 白色
        /// </summary>
	    WHITE,			
        /// <summary>
        /// black
        /// 黑色
        /// </summary>
	    BLACK,			
        /// <summary>
        /// red
        /// 红色
        /// </summary>
	    RED,			
        /// <summary>
        /// yellow
        /// 黄色
        /// </summary>
	    YELLOW,			
        /// <summary>
        /// gray
        /// 灰色
        /// </summary>
	    GRAY,			
        /// <summary>
        /// blue
        /// 蓝色
        /// </summary>
	    BLUE,			
        /// <summary>
        /// green
        /// 绿色
        /// </summary>
	    GREEN,			
        /// <summary>
        /// pink
        /// 粉色
        /// </summary>
	    PINK,			
        /// <summary>
        /// purple
        /// 紫色
        /// </summary>
	    PURPLE,			
        /// <summary>
        /// dark purple
        /// 暗紫色
        /// </summary>
	    DARK_PURPLE,	
        /// <summary>
        /// brown
        /// 棕色
        /// </summary>
	    BROWN,			
        /// <summary>
        /// marron
        /// 粟色
        /// </summary>
	    MAROON,			
        /// <summary>
        /// silver gray
        /// 银灰色
        /// </summary>
	    SILVER_GRAY,	
        /// <summary>
        /// dark gray
        /// 暗灰色
        /// </summary>
	    DARK_GRAY,		
        /// <summary>
        /// white smoke
        /// 白烟色
        /// </summary>
	    WHITE_SMOKE,	
        /// <summary>
        /// deep orange
        /// 深橙色
        /// </summary>
	    DEEP_ORANGE,	
        /// <summary>
        /// light rose
        /// 浅玫瑰色
        /// </summary>
	    LIGHT_ROSE,		
        /// <summary>
        /// tomato red
        /// 番茄红色
        /// </summary>
	    TOMATO_RED,		
        /// <summary>
        /// olive
        /// 橄榄色
        /// </summary>
	    OLIVE,			
        /// <summary>
        /// golden
        /// 金色
        /// </summary>
	    GOLDEN,			
        /// <summary>
        /// dark olive
        /// 暗橄榄色
        /// </summary>
	    DARK_OLIVE,		
        /// <summary>
        /// yellow green
        /// 黄绿色
        /// </summary>
	    YELLOW_GREEN,	
        /// <summary>
        /// green yellow
        /// 绿黄色
        /// </summary>
	    GREEN_YELLOW,	
        /// <summary>
        /// forest green
        /// 森林绿
        /// </summary>
	    FOREST_GREEN,	
        /// <summary>
        /// ocean blue
        /// 海洋绿
        /// </summary>
	    OCEAN_BLUE,		
        /// <summary>
        /// deep sky blue
        /// 深天蓝
        /// </summary>
	    DEEP_SKYBLUE,	
        /// <summary>
        /// cyan
        /// 青色
        /// </summary>
	    CYAN,			
        /// <summary>
        /// deep blue
        /// 深蓝色
        /// </summary>
	    DEEP_BLUE,		
        /// <summary>
        /// deep red
        /// 深红色
        /// </summary>
	    DEEP_RED,		
        /// <summary>
        /// deep green
        /// 深绿色
        /// </summary>
	    DEEP_GREEN,		
        /// <summary>
        /// deep yellow
        /// 深黄色
        /// </summary>
	    DEEP_YELLOW,	
        /// <summary>
        /// deep pink
        /// 深粉色
        /// </summary>
	    DEEP_PINK,		
        /// <summary>
        /// deep purple
        /// 深紫色
        /// </summary>
	    DEEP_PURPLE,	
        /// <summary>
        /// deep brown
        /// 深棕色
        /// </summary>
	    DEEP_BROWN,		
        /// <summary>
        /// deep cyan
        /// 深青色
        /// </summary>
	    DEEP_CYAN,		
        /// <summary>
        /// orange
        /// 橙色
        /// </summary>
	    ORANGE,			
        /// <summary>
        /// deep golden
        /// 深金色
        /// </summary>
	    DEEP_GOLDEN,	
        /// <summary>
        /// other
        /// 未识别、其他
        /// </summary>
	    OTHER	= 255,	
    }

    /// <summary>
    /// use property
    /// 使用性质
    /// </summary>
    public enum EM_USE_PROPERTY_TYPE
    {
        /// <summary>
        /// other
        /// 其他
        /// </summary>
	    OTHER,					
        /// <summary>
        /// not operating
        /// 非营运
        /// </summary>
	    NOTOPERATING,			
        /// <summary>
        /// higway
        /// 公路客运
        /// </summary>
	    HIGWAY,					
        /// <summary>
        /// bus
        /// 公交客运
        /// </summary>
	    BUS,					
        /// <summary>
        /// taxi
        /// 出租客运
        /// </summary>
	    TAXI,					
        /// <summary>
        /// tourism
        /// 旅游客运
        /// </summary>
	    TOURISM,				
        /// <summary>
        /// freight
        /// 货运
        /// </summary>
	    FREIGHT,				
        /// <summary>
        /// lease
        /// 租赁
        /// </summary>
	    LEASE,					
        /// <summary>
        /// for police
        /// 警用
        /// </summary>
	    POLICE,					
        /// <summary>
        /// for fire police
        /// 消防
        /// </summary>
	    FIRE,					
        /// <summary>
        /// for rescue
        /// 救护
        /// </summary>
	    RESCUE,					
        /// <summary>
        /// engineering emergency
        /// 工程救险
        /// </summary>
	    ENGINEERING,			
        /// <summary>
        /// form operating to not operating
        /// 营转非
        /// </summary>
	    OPERATION_TO_NOT,		
        /// <summary>
        /// form taxi to not taxi
        /// 出租转非
        /// </summary>
	    TAXI_TO_NOT,			
        /// <summary>
        /// for coach
        /// 教练
        /// </summary>
	    COACH,					
        /// <summary>
        /// kindergarten school bus
        /// 幼儿校车
        /// </summary>
	    KINDER_SCHOOLBUS,		
        /// <summary>
        /// pupil school bus
        /// 小学生校车
        /// </summary>
	    PUPIL_SCHOOLBUS,		
        /// <summary>
        /// other school bus
        /// 其他校车
        /// </summary>
	    OTHER_SCHOOLBUS,		
        /// <summary>
        /// for dangerous goods transportation
        /// 危化品运输
        /// </summary>
	    FOR_DANGE_VEHICLE,		
    }

    /// <summary>
    /// NTP status
    /// NTP状态
    /// </summary>
    public enum EM_NTP_STATUS
    {
        /// <summary>
        /// unknow
        /// 未知
        /// </summary>
        UNKNOWN = 0 ,                                                     
        /// <summary>
        /// disable
        /// 禁用
        /// </summary>
        DISABLE     ,                                                     
        /// <summary>
        /// successful
        /// 成功
        /// </summary>
        SUCCESSFUL  ,                                                     
        /// <summary>
        /// failed
        /// 失败
        /// </summary>
        FAILED      ,                                                     
    }

	/// <summary>
    /// Video analysis object info expansion structure,4-byte alignment
    /// 物体信息扩展结构体，强制4字节对齐
	/// </summary>
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)] 
	public struct NET_MSG_OBJECT_EX
	{
        /// <summary>
        /// struct size
        /// 结构体大小
        /// </summary>
		public uint                         dwSize;                        
        /// <summary>
        /// object ID, each ID means a exclusive object
        /// 物体ID,每个ID表示一个唯一的物体
        /// </summary>
		public int                          nObjectID;                     
        /// <summary>
        /// object  type
        /// 物体类型
        /// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
		public byte[]                       szObjectType;                  
        /// <summary>
        /// confidence coefficient (0~255) value the bigger means  confidence coefficient the higher
        /// 置信度(0~255),值越大表示置信度越高
        /// </summary>
		public int                          nConfidence;                 
        /// <summary>
        /// object  motion :1:Appear 2:Move 3:Stay 4:Remove 5:Disappear 6:Split 7:Merge 8:Rename
        /// 物体动作:1:Appear 2:Move 3:Stay 4:Remove 5:Disappear 6:Split 7:Merge 8:Rename
        /// </summary>
		public int                          nAction;                       
		#if (LINUX_X64)
		public NET_RECT_LONG_TYPE           BoundingBox;		           
		#else
        /// <summary>
        /// BoundingBox
        /// 包围盒
        /// </summary>
		public NET_RECT                     BoundingBox;		            
		#endif
        /// <summary>
        /// object model center
        /// 物体型心
        /// </summary>
		public NET_POINT                    Center;                        
        /// <summary>
        /// polygon vertex number 
        /// 多边形顶点个数
        /// </summary>
		public int                          nPolygonNum;                   
        /// <summary>
        /// relatively accurate outline the polygon 
        /// 较精确的轮廓多边形
        /// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public NET_POINT[]                  Contour;                       
        /// <summary>
        /// means plate, vehicle body and etc. object major color by byte means are red, green, blue and transparency , such as:RGB value is (0,255,0), transparency is 0, its value is 0x00ff0000.
        /// 表示车牌、车身等物体主要颜色；按字节表示,分别为红、绿、蓝和透明度,例如:RGB值为(0,255,0),透明度为0时, 其值为0x00ff0000
        /// </summary>
		public uint                         rgbaMainColor;                  
        /// <summary>
        /// same as NET_MSG_OBJECT corresponding field
        /// 同NET_MSG_OBJECT相应字段
        /// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
		public byte[]                       szText;                         
        /// <summary>
        /// object sub type according to different object  types may use the following sub type,same as NET_MSG_OBJECT field
        /// 物体子类别,根据不同的物体类型,可以取以下子类型，同NET_MSG_OBJECT相应字段
        /// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
		public byte[]                       szObjectSubType;               
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		public byte[]                       byReserved1;                   
        /// <summary>
        /// object corresponding to picture file info or not
        /// 是否有物体对应图片文件信息
        /// </summary>
		public byte                         bPicEnble;                    
        /// <summary>
        /// object corresponding to picture info 
        /// 物体对应图片信息
        /// </summary>
		public NET_PIC_INFO                 stPicInfo;                    
        /// <summary>
        /// snapshot recognition result or not 
        /// 是否是抓拍张的识别结果
        /// </summary>
		public byte                         bShotFrame;                   
        /// <summary>
        /// object  color (rgbaMainColor) usable or not
        /// 物体颜色(rgbaMainColor)是否可用
        /// </summary>
		public byte                         bColor;                       
        /// <summary>
        /// lower color (rgbaLowerBodyColor) usable or not
        /// 下半身颜色(rgbaLowerBodyColor)是否可用
        /// </summary>
		public byte                         bLowerBodyColor;              
        /// <summary>
        /// time means type, see EM_TIME_TYPE note
        /// 时间表示类型,详见EM_TIME_TYPE说明
        /// </summary>
		public byte                         byTimeType;                   
        /// <summary>
        /// for video compression current time stamp, object snapshot or recognition, attach this recognition frame in one vire frame or jpegpicture,this frame's appearance time in original video
        /// 针对视频浓缩,当前时间戳（物体抓拍或识别时,会将此识别智能帧附在一个视频帧或jpeg图片中,此帧所在原始视频中的出现时间）
        /// </summary>
		public NET_TIME_EX                  stuCurrentTime;                
        /// <summary>
        /// start time stamp,object start appearance
        /// 开始时间戳（物体开始出现时）
        /// </summary>
		public NET_TIME_EX                  stuStartTime;                  
        /// <summary>
        /// end time stamp,object last aapearance
        /// 结束时间戳（物体最后出现时）
        /// </summary>
		public NET_TIME_EX                  stuEndTime;                    
#if(LINUX_X64)
		public NET_RECT_LONG_TYPE           stuOriginalBoundingBox;	        // original bounding box(absolute coordinates)
        public NET_RECT_LONG_TYPE           stuSignBoundingBox;	            // sign bounding box coordinate
#else
        /// <summary>
        /// original bounding box(absolute coordinates)
        /// 包围盒(绝对坐标)
        /// </summary>
        public NET_RECT                     stuOriginalBoundingBox;	       
        /// <summary>
        /// sign bounding box coordinate
        /// 车标坐标包围盒
        /// </summary>
        public NET_RECT                     stuSignBoundingBox;            
#endif
        /// <summary>
        /// current frame no. snapshot this object frame
        /// 当前帧序号（抓下这个物体时的帧）
        /// </summary>
        public uint                         dwCurrentSequence;             
        /// <summary>
        /// start frame no. object start appearance frame no.
        /// 开始帧序号（物体开始出现时的帧序号）
        /// </summary>
        public uint                         dwBeginSequence;               
        /// <summary>
        /// end frame no. object disappearance frame no.
        /// 结束帧序号（物体消逝时的帧序号）
        /// </summary>
        public uint                         dwEndSequence;                 
        /// <summary>
        /// start file shift, unit: byte object start appearance video in original video file moves toward file origin
        /// 开始时文件偏移, 单位: 字节（物体开始出现时,视频帧在原始视频文件中相对于文件起始处的偏移）
        /// </summary>
        public Int64                        nBeginFileOffset;                
        /// <summary>
        /// End file shift, unit: byte object disappearance video in original video file moves toward file origin
        /// 结束时文件偏移, 单位: 字节（物体消逝时,视频帧在原始视频文件中相对于文件起始处的偏移）
        /// </summary>
        public Int64                        nEndFileOffset;                  
        /// <summary>
        /// object  color similarity take  value range 0-100 group subscript value represents certain color, see EM_COLOR_TYPE
        /// 物体颜色相似度,取值范围：0-100,数组下标值代表某种颜色,详见EM_COLOR_TYPE
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[]                       byColorSimilar;                 
        /// <summary>
        /// upper object  color  similarity (object  type as human is valid )
        /// 上半身物体颜色相似度(物体类型为人时有效)
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[]                       byUpperBodyColorSimilar;       
        /// <summary>
        /// lower object  color  similarity (object  type as human is valid )
        /// 下半身物体颜色相似度(物体类型为人时有效)
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[]                       byLowerBodyColorSimilar;       
        /// <summary>
        /// related object ID
        /// 相关物体ID
        /// </summary>
        public int                          nRelativeID;                   
        /// <summary>
        /// "ObjectType"is "Vehicle"or "Logo" means LOGO lower brand such as Audi A6L since there are many brands SDK shows this field in real-time,device filled as real.
        /// "ObjectType"为"Vehicle"或者"Logo"时,表示车标下的某一车系,比如奥迪A6L,由于车系较多,SDK实现时透传此字段,设备如实填写
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	    public byte[]				        szSubText;                     
        /// <summary>
        /// Intrusion staff height unit cm
        /// 入侵人员身高,单位cm
        /// </summary>
	    public int					        nPersonStature;	               
        /// <summary>
        /// Staff intrusion direction
        /// 人员入侵方向
        /// </summary>
	    public EM_MSG_OBJ_PERSON_DIRECTION	emPersonDirection;             
        /// <summary>
        /// Use direction same as rgbaMainColor,object  type as human is valid 
        /// 使用方法同rgbaMainColor,物体类型为人时有效
        /// </summary>
        public uint                         rgbaLowerBodyColor;              	
    }

    /// <summary>
    /// intrusion direction
    /// 入侵方向
    /// </summary>
    public enum EM_MSG_OBJ_PERSON_DIRECTION
    {
        /// <summary>
        /// unknown direction
        /// 未知方向
        /// </summary>
        UNKOWN,                                                             
        /// <summary>
        /// from left to right
        /// 从左向右
        /// </summary>
        LEFT_TO_RIGHT,                                                      
        /// <summary>
        /// from right ro left
        /// 从右向左
        /// </summary>
        RIGHT_TO_LEFT                                                      
    }

    /// <summary>
    /// driver's illegal info
    /// 驾驶位违规信息
    /// </summary>
    public struct NET_EVENT_COMM_SEAT
    {
        /// <summary>
        /// whether seat info detected
        /// 是否检测到座驾信息
        /// </summary>
        public bool                         bEnable;                         
        /// <summary>
        /// seat type
        /// 座驾类型, 0:未识别; 1:主驾驶; 2:副驾驶
        /// </summary>
        public EM_COMMON_SEAT_TYPE          emSeatType;                     
        /// <summary>
        /// illegal state
        /// 违规状态
        /// </summary>
        public NET_EVENT_COMM_STATUS        stStatus;                       
        /// <summary>
        /// safe belt state
        /// 安全带状态
        /// </summary>
	    public EM_SAFEBELT_STATE            emSafeBeltStatus;               
        /// <summary>
        /// sun shade state
        /// 遮阳板状态
        /// </summary>
        public EM_SUNSHADE_STATE            emSunShadeStatus;              
        /// <summary>
        /// reversed
        /// 预留字节
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
        public byte[]                       szReserved;                     
    }

    /// <summary>
    /// seat type
    /// 座位类型
    /// </summary>
    public enum EM_COMMON_SEAT_TYPE
    {
        /// <summary>
        /// unknown
        /// 未识别
        /// </summary>
        UNKNOWN    = 0,                                                   
        /// <summary>
        /// main seat
        /// 主驾驶
        /// </summary>
        MAIN       = 1,                                                   
        /// <summary>
        /// slave seat
        /// 副驾驶
        /// </summary>
        SLAVE      = 2,                                                   
    }

    /// <summary>
    /// illegal state type of driver
    /// 违规状态
    /// </summary>
    public struct NET_EVENT_COMM_STATUS                 
    {
        /// <summary>
        /// smoking
        /// 是否抽烟
        /// </summary>
        public byte bySmoking;                                           
        /// <summary>
        /// calling
        /// 是否打电话
        /// </summary>
        public byte byCalling;                                           
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 14)]
        public byte[] szReserved;                                        
    }

    /// <summary>
    /// safebelt state
    /// 安全带状态
    /// </summary>
    public enum EM_SAFEBELT_STATE
    {
        /// <summary>
        /// Unknow
        /// 未知
        /// </summary>
        UNKNOW ,				                                          
        /// <summary>
        /// WithSafeBelt
        /// 已系安全带
        /// </summary>
	    WITH_SAFE_BELT ,				                                  
        /// <summary>
        /// WithoutSafeBelt
        /// 未系安全带
        /// </summary>
	    WITHOUT_SAFE_BELT ,			                                      
    }

    /// <summary>
    /// sunshade state
    /// 遮阳板状态
    /// </summary>
    public enum EM_SUNSHADE_STATE
    {
        /// <summary>
        /// Unknow
        /// 未知
        /// </summary>
        UNKNOW_SUN_SHADE ,		                                           
        /// <summary>
        /// WithSunShade
        /// 有遮阳板
        /// </summary>
	    WITH_SUN_SHADE ,				                                   
        /// <summary>
        /// WithoutSunShade
        /// 无遮阳板
        /// </summary>
	    WITHOUT_SUN_SHADE ,			                                       
    }

    /// <summary>
    /// event attachment struct
    /// 车辆物件
    /// </summary>
    public struct NET_EVENT_COMM_ATTACHMENT
    {
        /// <summary>
        /// type
        /// 物件类型
        /// </summary>
        public EM_COMM_ATTACHMENT_TYPE          emAttachmentType;           
        /// <summary>
        /// coordinate
        /// 坐标
        /// </summary>
	    public NET_RECT                         stuRect;                    
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	    public byte[]					        bReserved;		            
    }

    /// <summary>
    /// attachment type
    /// 车辆物件类型
    /// </summary>
    public enum EM_COMM_ATTACHMENT_TYPE      
    {       
        /// <summary>
        /// Unknown type
        /// 未知类型
        /// </summary>
	    UNKNOWN    = 0,                                                    
        /// <summary>
        /// Furniture
        /// 摆件
        /// </summary>
	    FURNITURE  = 1,                                                     
        /// <summary>
        /// Pendant
        /// 挂件
        /// </summary>
	    PENDANT    = 2,                                                     
        /// <summary>
        /// TissueBox
        /// 纸巾盒
        /// </summary>
	    TISSUEBOX  = 3,                                                       
        /// <summary>
        /// Danger
        /// 危险品
        /// </summary>
	    DANGER     = 4,                                                     
        /// <summary>
        /// perfumebox
        /// 香水
        /// </summary>
	    PERFUMEBOX = 5,			                                         
     }

    /// <summary>
    /// Event Type EVENT_IVS_TRAFFICJUNCTION (transportation card traffic junctions old rule event / video port on the old electric alarm event rules) corresponding to the description of the data block
    /// Due to historical reasons, if you want to deal with bayonet event, NET_DEV_EVENT_TRAFFICJUNCTION_INFO and NET_EVENT_IVS_TRAFFICGATE be processed together to prevent police and video electrical coil electric alarm occurred while the case access platform
    /// Also NET_EVENT_IVS_TRAFFIC_TOLLGATE only support the new bayonet events
    /// 事件类型EVENT_IVS_TRAFFICJUNCTION(交通路口老规则事件/视频电警上的交通卡口老规则事件)对应的数据块描述信息
    /// 由于历史原因,如果要处理卡口事件,NET_DEV_EVENT_TRAFFICJUNCTION_INFO和NET_EVENT_IVS_TRAFFICGATE要一起处理,以防止有视频电警和线圈电警同时接入平台的情况发生
    /// 另外NET_EVENT_IVS_TRAFFIC_TOLLGATE只支持新卡口事件的配置
    /// </summary>
    public struct NET_DEV_EVENT_TRAFFICJUNCTION_INFO 
    {
        /// <summary>
        /// ChannelId
        /// 通道号
        /// </summary>
        public int					                    nChannelID;			
        /// <summary>
        /// event name
        /// 事件名称
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[]				                    szName;				
        /// <summary>
        /// main driver's seat safety belt,1-fastened,2-unfastened
        /// 主驾驶座,系安全带状态,1-系安全带,2-未系安全带
        /// </summary>
        public byte                                     byMainSeatBelt;   
        /// <summary>
        /// co-drvier's seat safety belt,1-fastened,2-unfastened
        /// 副驾驶座,系安全带状态,1-系安全带,2-未系安全带
        /// </summary>
        public byte                                     bySlaveSeatBelt;  
        /// <summary>
        /// Current snapshot is head or rear see  EM_VEHICLE_DIRECTION
        /// 当前被抓拍到的车辆是车头还是车尾,具体请见 EM_VEHICLE_DIRECTION
        /// </summary>
        public byte                                     byVehicleDirection;
        /// <summary>
        /// Open status see EM_OPEN_STROBE_STATE 
        /// 开闸状态,具体请见 EM_OPEN_STROBE_STATE
        /// </summary>
        public byte                                     byOpenStrobeState;  
        /// <summary>
        /// PTS(ms)
        /// 时间戳(单位是毫秒)
        /// </summary>
        public double				                    PTS;				
        /// <summary>
        /// the event happen time
        /// 事件发生的时间
        /// </summary>
        public NET_TIME_EX			                    UTC;				
        /// <summary>
        /// event ID
        /// 事件ID
        /// </summary>
        public int					                    nEventID;			
        /// <summary>
        /// have being detected object
        /// 检测到的物体
        /// </summary>
        public NET_MSG_OBJECT		                    stuObject;			
        /// <summary>
        /// road number
        /// 对应车道号
        /// </summary>
        public int					                    nLane;				
        /// <summary>
        /// BreakingRule's mask,first byte: crash red light;secend byte:break the rule of driving road number; the third byte:converse; the forth byte:break rule to turn around;the five byte:traffic jam; the six byte:traffic vacancy; the seven byte: Overline; defalt:trafficJunction
        /// 违反规则掩码,第一位:闯红灯;第二位:不按规定车道行驶;第三位:逆行; 第四位：违章掉头;第五位:交通堵塞; 第六位:交通异常空闲;第七位:压线行驶; 否则默认为:交通路口事件
        /// </summary>
        public uint				                        dwBreakingRule;				                            
        /// <summary>
        /// the begin time of red light
        /// 红灯开始UTC时间
        /// </summary>                                         
        public NET_TIME_EX			                    RedLightUTC;		
        /// <summary>
        /// event file info
        /// 事件对应文件信息
        /// </summary>
        public NET_EVENT_FILE_INFO                      stuFileInfo;        
        /// <summary>
        /// snap index,such as 3,2,1,1 means the last one,0 means there has some exception and snap stop
        /// 表示抓拍序号,如3,2,1,1表示抓拍结束,0表示异常结束
        /// </summary>
        public int                                      nSequence;         
        /// <summary>
        /// car's speed (km/h)
        /// 车辆实际速度Km/h 
        /// </summary>
        public int                                      nSpeed;            
        /// <summary>
        /// Event action,0 means pulse event,1 means continuous event's begin,2means continuous event's end
        /// 事件动作,0表示脉冲事件,1表示持续性事件开始,2表示持续性事件结束
        /// </summary>
        public byte                                     bEventAction;      
        /// <summary>
        /// Intersection direction 1 - denotes the forward 2 - indicates the opposite
        /// 路口方向,1-表示正向,2-表示反向
        /// </summary>
        public byte                                     byDirection;        
        /// <summary>
        /// LightState means red light status:0 unknown,1 green,2 red,3 yellow
        /// LightState表示红绿灯状态:0 未知,1 绿灯,2 红灯,3 黄灯
        /// </summary>
        public byte                                     byLightState;     
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        public byte                                     byReserved;       
        /// <summary>
        /// Serial number of the picture, in the same time (accurate to seconds) may have multiple images, starting from 0
        /// 图片的序号, 同一时间内(精确到秒)可能有多张图片, 从0开始
        /// </summary>
        public byte                                     byImageIndex;     
        /// <summary>
        /// vehicle info
        /// 车身信息
        /// </summary>
        public NET_MSG_OBJECT                           stuVehicle;       
        /// <summary>
        /// snap flags(by bit),0bit:"*",1bit:"Timing",2bit:"Manual",3bit:"Marked",4bit:"Event",5bit:"Mosaic",6bit:"Cutout"
        /// 抓图标志(按位),具体见NET_RESERVED_COMMON
        /// </summary>
        public uint                                     dwSnapFlagMask;	   
        /// <summary>
        /// picture resolution
        /// 对应图片的分辨率
        /// </summary>
        public NET_RESOLUTION_INFO                      stuResolution;     
        /// <summary>
        /// Alarm corresponding original video file information
        /// 报警对应的原始录像文件信息
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[]                                   szRecordFile;
        /// <summary>
        /// custom info
        /// 自定义信息
        /// </summary>
        public NET_EVENT_JUNCTION_CUSTOM_INFO           stuCustomInfo;         
        /// <summary>
        /// the source of plate text, 0:Local,1:Server
        /// 车牌识别来源, 0:本地算法识别,1:后端服务器算法识别
        /// </summary>
        public byte                                     byPlateTextSource;              
        /// <summary>
        /// Reserved bytes
        /// 保留字节
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray,SizeConst = 3)]
	    public byte[]				                    bReserved1;				   
        /// <summary>
        /// GPS info
        /// GPS信息
        /// </summary>
        public NET_GPS_INFO                             stuGPSInfo;                     
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 196)]
        public byte[]				                    bReserved;			
        /// <summary>
        /// Trigger Type:0 vehicle inspection device,1 radar,2 video
        /// TriggerType:触发类型,0车检器,1雷达,2视频
        /// </summary>
        public int                                      nTriggerType;       
        /// <summary>
        /// Traffic vehicle info
        /// 交通车辆信息
        /// </summary>
        public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO    stTrafficCar;       
        /// <summary>
        /// Card Number
        /// 卡片个数
        /// </summary>
        public uint                                     dwRetCardNumber;    
        /// <summary>
        /// Card information
        /// 卡片信息
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public NET_EVENT_CARD_INFO[]                    stuCardInfo;        
        /// <summary>
        /// public info
        /// 公共信息
        /// </summary>
        public NET_EVENT_COMM_INFO                      stCommInfo;         
    }

    /// <summary>
    /// custom info
    /// 卡口事件专用定制上报内容，定制需求增加到Custom下
    /// </summary>
    public struct NET_EVENT_JUNCTION_CUSTOM_INFO
    {
        /// <summary>
        /// custom weight info
        /// 原始图片信息
        /// </summary>
        public NET_EVENT_CUSTOM_WEIGHT_INFO    stuWeightInfo;      
        /// <summary>
        /// reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 60)]
	    public byte[]						bReserved;		 
    }

    /// <summary>
    /// custom weight info
    /// 建委地磅定制称重信息
    /// </summary>
    public struct NET_EVENT_CUSTOM_WEIGHT_INFO
    {
        /// <summary>
        /// Rough Weight,unit:KG
        /// 毛重,车辆满载货物重量。单位KG
        /// </summary>
	    public uint             dwRoughWeight;                    
        /// <summary>
        /// Tare Weight,unit:KG
        /// 皮重,空车重量。单位KG
        /// </summary>
        public uint             dwTareWeight;                     
        /// <summary>
        /// Net Weight,unit:KG
        /// 净重,载货重量。单位KG
        /// </summary>
        public uint             dwNetWeight;                      
        /// <summary>
        /// reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 28)]
	    public byte[]		    bReserved;					    
    }

    /// <summary>
    /// vehicle direction
    /// 车辆方向
    /// </summary>
    public enum EM_VEHICLE_DIRECTION
    {
        /// <summary>
        /// unknown
        /// 未知
        /// </summary>
        UNKOWN,                                                           
        /// <summary>
        /// head
        /// 车头
        /// </summary>
        HEAD,                                                             
        /// <summary>
        /// rear
        /// 车尾
        /// </summary>
        TAIL,                                                             
    }

    /// <summary>
    /// incidents reported to carry the card information
    /// 事件上报携带卡片信息
    /// </summary>
    public struct NET_EVENT_CARD_INFO
    {
        /// <summary>
        /// Card number string
        /// 卡片序号字符串
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 36)]
        public byte[]                                   szCardNumber;      
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[]                                   bReserved;	       
    }

    /// <summary>
    /// the describe of EVENT_TRAFFIC_TURNLEFT's data
    /// 交通-违章左转对应的数据块描述信息
    /// </summary>
    public struct NET_DEV_EVENT_TRAFFIC_TURNLEFT_INFO
    {
        /// <summary>
        /// channel ID
        /// 通道号
        /// </summary>
	    public int					                    nChannelID;			
        /// <summary>
        /// event name
        /// 事件名称
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[]				                    szName;		       
        /// <summary>
        /// byte alignment
        /// 字节对齐
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	    public byte[]                                   bReserved1;        
        /// <summary>
        /// PTS(ms)
        /// 时间戳(单位是毫秒)
        /// </summary>
	    public double				                    PTS;				
        /// <summary>
        /// the event happen time
        /// 事件发生的时间
        /// </summary>
	    public NET_TIME_EX			                    UTC;				
        /// <summary>
        /// event ID
        /// 事件ID
        /// </summary>
	    public int					                    nEventID;			
        /// <summary>
        /// Corresponding Lane number
        /// 对应车道号
        /// </summary>
	    public int					                    nLane;				
        /// <summary>
        /// have being detected object
        /// 车牌信息
        /// </summary>
	    public NET_MSG_OBJECT		                    stuObject;			
        /// <summary>
        /// vehicle info
        /// 车身信息
        /// </summary>
	    public NET_MSG_OBJECT                           stuVehicle;         
        /// <summary>
        /// event file info
        /// 事件对应文件信息
        /// </summary>
	    public NET_EVENT_FILE_INFO                      stuFileInfo;        
        /// <summary>
        /// snap index: such as 3,2,1,1 means the last one,0 means there has some exception and snap stop
        /// 表示抓拍序号,如3,2,1,1表示抓拍结束,0表示异常结束
        /// </summary>
	    public int                                      nSequence;         
        /// <summary>
        /// speed,km/h
        /// 车辆实际速度,Km/h
        /// </summary>
	    public int                                      nSpeed;            
        /// <summary>
        /// Event action,0 means pulse event,1 means continuous event's begin,2means continuous event's end;
        /// 事件动作,0表示脉冲事件,1表示持续性事件开始,2表示持续性事件结束
        /// </summary>
	    public byte                                     bEventAction;		 
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[]                                   byReserved;         
        /// <summary>
        /// Serial number of the picture, in the same time (accurate to seconds) may have multiple images, starting from 0
        /// 图片的序号, 同一时间内(精确到秒)可能有多张图片, 从0开始
        /// </summary>
        public byte                                     byImageIndex;       
        /// <summary>
        /// snap flags(by bit),0bit:"*",1bit:"Timing",2bit:"Manual",3bit:"Marked",4bit:"Event",5bit:"Mosaic",6bit:"Cutout"
        /// 抓图标志(按位),具体见NET_RESERVED_COMMON
        /// </summary>
        public uint                                     dwSnapFlagMask;	   
        /// <summary>
        /// picture resolution
        /// 对应图片的分辨率
        /// </summary>
	    public NET_RESOLUTION_INFO                      stuResolution;
        /// <summary>
        /// GPS info
        /// GPS信息
        /// </summary>
        public NET_GPS_INFO                             stuGPSInfo;                                 
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 968)]
	    public byte[]				                    bReserved;	       
        /// <summary>
        /// Traffic vehicle info
        /// 交通车辆信息
        /// </summary>
	    public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO    stTrafficCar;      
        /// <summary>
        /// public info 
        /// 公共信息
        /// </summary>
	    public NET_EVENT_COMM_INFO                      stCommInfo;        
    }

    /// <summary>
    /// the describe of EVENT_IVS_TRAFFIC_TURNRIGHT's data
    /// 交通-违章右转对应的数据块描述信息
    /// </summary>
    public struct NET_DEV_EVENT_TRAFFIC_TURNRIGHT_INFO
    {
        /// <summary>
        /// channel ID
        /// 通道号
        /// </summary>
	    public int					                    nChannelID;		
        /// <summary>
        /// event name
        /// 事件名称
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[]				                    szName;		    
        /// <summary>
        /// byte alignment
        /// 字节对齐
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	    public byte[]                                   bReserved1;     
        /// <summary>
        /// PTS(ms)
        /// 时间戳(单位是毫秒)
        /// </summary>
	    public double				                    PTS;			
        /// <summary>
        /// the event happen time
        /// 事件发生的时间
        /// </summary>
	    public NET_TIME_EX			                    UTC;				
        /// <summary>
        /// event ID
        /// 事件ID
        /// </summary>
	    public int					                    nEventID;			
        /// <summary>
        /// Corresponding Lane number
        /// 对应车道号
        /// </summary>
	    public int					                    nLane;				
        /// <summary>
        /// have being detected object
        /// 车牌信息
        /// </summary>
	    public NET_MSG_OBJECT		                    stuObject;			
        /// <summary>
        /// vehicle info
        /// 车身信息
        /// </summary>
	    public NET_MSG_OBJECT                           stuVehicle;         
        /// <summary>
        /// event file info
        /// 事件对应文件信息
        /// </summary>
	    public NET_EVENT_FILE_INFO                      stuFileInfo;        
        /// <summary>
        /// snap index: such as 3,2,1,1 means the last one,0 means there has some exception and snap stop
        /// 表示抓拍序号,如3,2,1,1表示抓拍结束,0表示异常结束
        /// </summary>
	    public int                                      nSequence;         
        /// <summary>
        /// speed,km/h
        /// 车辆实际速度,Km/h
        /// </summary>
	    public int                                      nSpeed;            
        /// <summary>
        /// Event action,0 means pulse event,1 means continuous event's begin,2means continuous event's end
        /// 事件动作,0表示脉冲事件,1表示持续性事件开始,2表示持续性事件结束
        /// </summary>
	    public byte                                     bEventAction;		
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[]                                   byReserved;         
        /// <summary>
        /// Serial number of the picture, in the same time (accurate to seconds) may have multiple images, starting from 0
        /// 图片的序号, 同一时间内(精确到秒)可能有多张图片, 从0开始
        /// </summary>
        public byte                                     byImageIndex;       
        /// <summary>
        /// snap flags(by bit),0bit:"*",1bit:"Timing",2bit:"Manual",3bit:"Marked",4bit:"Event",5bit:"Mosaic",6bit:"Cutout"
        /// 抓图标志(按位),具体见NET_RESERVED_COMMON
        /// </summary>
        public uint                                     dwSnapFlagMask;	     
        /// <summary>
        /// picture resolution
        /// 对应图片的分辨率
        /// </summary>
	    public NET_RESOLUTION_INFO                      stuResolution;
        /// <summary>
        /// GPS info
        /// GPS信息
        /// </summary>
        public NET_GPS_INFO                             stuGPSInfo; 
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 968)]
	    public byte[]				                    bReserved;	        
        /// <summary>
        /// Traffic vehicle info
        /// 交通车辆信息
        /// </summary>
	    public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO    stTrafficCar;       
        /// <summary>
        /// public info
        /// 公共信息
        /// </summary>
        public NET_EVENT_COMM_INFO                      stCommInfo;         
    }

    /// <summary>
    /// the describe of EVENT_IVS_TRAFFIC_OVERSPEED's data
    /// 交通超速事件对应的数据块描述信息
    /// </summary>
    public struct NET_DEV_EVENT_TRAFFIC_OVERSPEED_INFO 
    {
        /// <summary>
        /// channel ID
        /// 通道号
        /// </summary>
	    public int					                    nChannelID;			
        /// <summary>
        /// event name
        /// 事件名称
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[]				                    szName;				
        /// <summary>
        /// byte alignment
        /// 字节对齐
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	    public byte[]                                   bReserved1;        
        /// <summary>
        /// PTS(ms)
        /// 时间戳(单位是毫秒)
        /// </summary>
	    public double				                    PTS;				
        /// <summary>
        /// the event happen time
        /// 事件发生的时间
        /// </summary>
	    public NET_TIME_EX			                    UTC;				
        /// <summary>
        /// event ID
        /// 事件ID
        /// </summary>
	    public int					                    nEventID;			
        /// <summary>
        /// Corresponding Lane number
        /// 对应车道号
        /// </summary>
	    public int					                    nLane;				
        /// <summary>
        /// have being detected object
        /// 车牌信息
        /// </summary>
	    public NET_MSG_OBJECT		                    stuObject;			
        /// <summary>
        /// vehicle info
        /// 车身信息
        /// </summary>
	    public NET_MSG_OBJECT                           stuVehicle;        
        /// <summary>
        /// event file info
        /// 事件对应文件信息
        /// </summary>
	    public NET_EVENT_FILE_INFO                      stuFileInfo;		
        /// <summary>
        /// speed,km/h
        /// 车辆实际速度,Km/h
        /// </summary>
        public int                                      nSpeed;             
        /// <summary>
        /// Speed Up limit Unit:km/h
        /// 速度上限 单位：km/h
        /// </summary>
	    public int					                    nSpeedUpperLimit;	
        /// <summary>
        /// Speed Low limit Unit:km/h 
        /// 速度下限 单位：km/h 
        /// </summary>
	    public int					                    nSpeedLowerLimit;
        /// <summary>
        /// snap index: such as 3,2,1,1 means the last one,0 means there has some exception and snap stop
        /// 表示抓拍序号,如3,2,1,1表示抓拍结束,0表示异常结束
        /// </summary>
	    public int                                      nSequence;
        /// <summary>
        /// Event action,0 means pulse event,1 means continuous event's begin,2means continuous event's end
        /// 事件动作,0表示脉冲事件,1表示持续性事件开始,2表示持续性事件结束
        /// </summary>
	    public byte                                     bEventAction;	
	    /// <summary>
        /// Reserved
        /// 保留
	    /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[]                                   byReserved;
        /// <summary>
        /// Serial number of the picture, in the same time (accurate to seconds) may have multiple images, starting from 0
        /// 图片的序号, 同一时间内(精确到秒)可能有多张图片, 从0开始
        /// </summary>
        public byte                                     byImageIndex;
        /// <summary>
        /// snap flags(by bit),0bit:"*",1bit:"Timing",2bit:"Manual",3bit:"Marked",4bit:"Event",5bit:"Mosaic",6bit:"Cutout"
        /// 抓图标志(按位),具体见NET_RESERVED_COMMON
        /// </summary>
        public uint                                     dwSnapFlagMask;
        /// <summary>
        /// picture resolution
        /// 对应图片的分辨率
        /// </summary>
	    public NET_RESOLUTION_INFO                      stuResolution;      
        /// <summary>
        /// Faile path
        /// 文件路径
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
        public byte[]                                   szFilePath;         
        /// <summary>
        /// intelli comm info
        /// 智能事件公共信息
	    /// </summary>
        public NET_EVENT_INTELLI_COMM_INFO              stuIntelliCommInfo;
        /// <summary>
        /// GPS info
        /// GPS信息
        /// </summary>
        public NET_GPS_INFO                             stuGPSInfo; 
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 576)]
	    public byte[]                                   bReserved;			
        /// <summary>
        /// Traffic vehicle info
        /// 交通车辆信息
        /// </summary>
	    public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO    stTrafficCar;       
        /// <summary>
        /// public info
        /// 公共信息
        /// </summary>
        public NET_EVENT_COMM_INFO                      stCommInfo;         
    }

    /// <summary>
    /// intelli event comm info
    /// 智能报警事件公共信息
    /// </summary>
    public struct NET_EVENT_INTELLI_COMM_INFO
    {
        /// <summary>
        /// class type
        /// 智能事件所属大类
        /// </summary>
	    public EM_CLASS_TYPE		                    emClassType;	
        /// <summary>
        /// Preset ID
        /// 该事件触发的预置点，对应该设置规则的预置点
        /// </summary>
	    public int					                    nPresetID;									
        /// <summary>
        /// reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 124)]
	    public byte[]                                   bReserved;                     		
    }

    /// <summary>
    /// class type
    /// 类类型
    /// </summary>
    public enum  EM_CLASS_TYPE        
    {
        /// <summary>
        /// unknow
        /// 未知业务
        /// </summary>
	    UNKNOWN                	    = 0,                                 
        /// <summary>
        /// video-synopsis
        /// 视频浓缩
        /// </summary>
        VIDEO_SYNOPSIS            	= 1,                                 
        /// <summary>
        /// traffiv-gate
        /// 卡口
        /// </summary>
        TRAFFIV_GATE            	= 2,                                 
        /// <summary>
        /// electronic-police
        /// 电警
        /// </summary>
        ELECTRONIC_POLICE        	= 3,                                 
        /// <summary>
        /// single-PTZ-parking
        /// 单球违停
        /// </summary>
        SINGLE_PTZ_PARKING        	= 4,                                 
        /// <summary>
        /// PTZ-parking
        /// 主从违停
        /// </summary>
        PTZ_PARKINBG            	= 5,                                 
        /// <summary>
        /// Traffic
        /// 交通事件
        /// </summary>
        TRAFFIC                	    = 6,                                 
        /// <summary>
        /// Normal
        /// 通用行为分析
        /// </summary>
        NORMAL                    	= 7,                                   
        /// <summary>
        /// Prison
        /// 监所行为分析
        /// </summary>
        PRISON                    	= 8,                                   
        /// <summary>
        /// ATM
        /// 金融行为分析
        /// </summary>
        ATM                    	    = 9,                                   
        /// <summary>
        /// metro
        /// 地铁行为分析
        /// </summary>
        METRO                    	= 10,                                
        /// <summary>
        /// FaceDetection
        /// 人脸检测
        /// </summary>
        FACE_DETECTION            	= 11,                                  
        /// <summary>
        /// FaceRecognition
        /// 人脸识别
        /// </summary>
        FACE_RECOGNITION        	= 12,                                  
        /// <summary>
        /// NumberStat
        /// 人数统计
        /// </summary>
        NUMBER_STAT            	    = 13,                                  
        /// <summary>
        /// HeatMap
        /// 热度图
        /// </summary>
        HEAT_MAP                	= 14,                                 
        /// <summary>
        /// VideoDiagnosis
        /// 视频诊断
        /// </summary>
        VIDEO_DIAGNOSIS        	    = 15,                                  
        /// <summary>
        /// VideoEnhance
        /// 视频增强
        /// </summary>
        VIDEO_ENHANCE            	= 16,                                
        /// <summary>
        /// Smokefire detect 
        /// 烟火检测
        /// </summary>
        SMOKEFIRE_DETECT        	= 17,                                
        /// <summary>
        /// VehicleAnalyse
        /// 车辆特征识别
        /// </summary>
        VEHICLE_ANALYSE        	    = 18,                                
        /// <summary>
        /// Person feature
        /// 人员特征识别
        /// </summary>
        PERSON_FEATURE            	= 19,
        /// <summary>
        /// SDFaceDetect
        /// 多预置点人脸检测"SDFaceDetect",配置一条规则但可以在不同预置点下生效
        /// </summary>
        SDFACEDETECTION              = 20,	 
        /// <summary>
        /// HeatMapPlan
        /// 球机热度图计划"HeatMapPlan" 
        /// </summary>
        HEAT_MAP_PLAN                = 21,	
        /// <summary>
        /// NumberStatPlan
        /// 球机客流量统计计划 "NumberStatPlan"
        /// </summary>
        NUMBERSTAT_PLAN              = 22,	
        /// <summary>
        /// ATMFD
        /// 金融人脸检测，包括正常人脸、异常人脸、相邻人脸、头盔人脸等针对ATM场景特殊优化
        /// </summary>
        ATMFD                        = 23,	
        /// <summary>
        /// Highway
        /// 高速交通事件检测"Highway"
        /// </summary>
        HIGHWAY                      = 24,	
        /// <summary>
        /// City
        /// 城市交通事件检测 "City"
        /// </summary>
        CITY                         = 25,	
        /// <summary>
        /// LeTrack
        /// 民用简易跟踪"LeTrack"
        /// </summary>
        LETRACK                      = 26,	
        /// <summary>
        /// SCR
        /// 打靶相机"SCR"
        /// </summary>
        SCR                          = 27,	
        /// <summary>
        /// StereoVision
        /// 立体视觉(双目)"StereoVision"
        /// </summary>
        STEREO_VISION                = 28,   
        /// <summary>
        /// HumanDetect
        /// 人体检测"HumanDetect"
        /// </summary>
        HUMANDETECT                  = 29,   
        /// <summary>
        /// FaceAnalysis
        /// 人脸分析 "FaceAnalysis"
        /// </summary>
        FACE_ANALYSIS                = 30,	
    }

    /// <summary>
    /// the describe of EVENT_IVS_TRAFFIC_UNDERSPEED's data
    /// 交通欠速事件对应的数据块描述信息
    /// </summary>
    public struct NET_DEV_EVENT_TRAFFIC_UNDERSPEED_INFO 
    {
        /// <summary>
        /// channel ID
        /// 通道号
        /// </summary>
	    public int					                    nChannelID;			
        /// <summary>
        /// event name
        /// 事件名称
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[]				                    szName;				
        // <summary>
        /// byte alignment
        /// 字节对齐
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	    public byte[]                                   bReserved2;         
        /// <summary>
        /// PTS(ms)
        /// 时间戳(单位是毫秒)
        /// </summary>
	    public double				                    PTS;				
        /// <summary>
        /// the event happen time
        /// 事件发生的时间
        /// </summary>
	    public NET_TIME_EX			                    UTC;				
        /// <summary>
        /// event ID
        /// 事件ID
        /// </summary>
	    public int					                    nEventID;			
        /// <summary>
        /// Corresponding Lane number
        /// 对应车道号
        /// </summary>
	    public int					                    nLane;				
        /// <summary>
        /// have being detected object
        /// 车牌信息
        /// </summary>
	    public NET_MSG_OBJECT		                    stuObject;			
        /// <summary>
        /// vehicle info
        /// 车身信息
        /// </summary>
	    public NET_MSG_OBJECT                           stuVehicle;         
        /// <summary>
        /// event file info
        /// 事件对应文件信息
        /// </summary>
	    public NET_EVENT_FILE_INFO                      stuFileInfo;		
        /// <summary>
        /// speed,km/h
        /// 车辆实际速度,Km/h
        /// </summary>
        public int                                      nSpeed;             
        /// <summary>
        /// Speed Up limit Unit:km/h
        /// 速度上限 单位：km/h
        /// </summary>
	    public int					                    nSpeedUpperLimit;	
        /// <summary>
        /// Speed Low limit Unit:km/h 
        /// 速度下限 单位：km/h 
        /// </summary>
	    public int					                    nSpeedLowerLimit;	
        /// <summary>
        /// snap index: such as 3,2,1,1 means the last one,0 means there has some exception and snap stop
        /// 表示抓拍序号,如3,2,1,1表示抓拍结束,0表示异常结束
        /// </summary>
	    public int                                      nSequence;          
        /// <summary>
        /// Event action,0 means pulse event,1 means continuous event's begin,2means continuous event's end
        /// 事件动作,0表示脉冲事件,1表示持续性事件开始,2表示持续性事件结束
        /// </summary>
	    public byte                                     bEventAction;		
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[]                                   bReserved1;         
        /// <summary>
        /// Serial number of the picture, in the same time (accurate to seconds) may have multiple images, starting from 0
        /// 图片的序号, 同一时间内(精确到秒)可能有多张图片, 从0开始
        /// </summary>
        public byte                                     byImageIndex;       
        /// <summary>
        /// under speed percentage
        /// 欠速百分比
        /// </summary>
	    public int                                      nUnderSpeedingPercentage; 
        /// <summary>
        /// snap flags(by bit),0bit:"*",1bit:"Timing",2bit:"Manual",3bit:"Marked",4bit:"Event",5bit:"Mosaic",6bit:"Cutout"
        /// 抓图标志(按位),具体见NET_RESERVED_COMMON
        /// </summary>
        public uint                                     dwSnapFlagMask;	    
        /// <summary>
        /// picture resolution
        /// 对应图片的分辨率
        /// </summary>
	    public NET_RESOLUTION_INFO                      stuResolution;      
        /// <summary>
        /// intelli comm info
        /// 智能事件公共信息
        /// </summary>
	    public NET_EVENT_INTELLI_COMM_INFO              stuIntelliCommInfo;
        /// <summary>
        /// GPS info
        /// GPS信息
        /// </summary>
        public NET_GPS_INFO                             stuGPSInfo; 
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 832)]
	    public byte[]                                   bReserved;			
        /// <summary>
        /// Traffic vehicle info
        /// 交通车辆信息
        /// </summary>
	    public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO    stTrafficCar;       
        /// <summary>
        /// public info
        /// 公共信息
        /// </summary>
        public NET_EVENT_COMM_INFO                      stCommInfo;        
    }

    /// <summary>
    /// the describe of EVENT_IVS_TRAFFICGATE's data
    /// owing to history, if you want to deal with TRAFFICGATE,NET_DEV_EVENT_TRAFFICJUNCTION_INFO and NET_EVENT_IVS_TRAFFICGATE must be handle together;
    /// in addition: EVENT_IVS_TRAFFIC_TOLLGATE only support new tollgate event configuration
    /// 事件类型EVENT_IVS_TRAFFICGATE(交通卡口老规则事件/线圈电警上的交通卡口老规则事件)对应的数据块描述信息
    /// 由于历史原因,如果要处理卡口事件,NET_DEV_EVENT_TRAFFICJUNCTION_INFO和NET_EVENT_IVS_TRAFFICGATE要一起处理,以防止有视频电警和线圈电警同时接入平台的情况发生
    /// 另外NET_EVENT_IVS_TRAFFIC_TOLLGATE只支持新卡口事件的配置
    /// </summary>
    public struct NET_DEV_EVENT_TRAFFICGATE_INFO 
    {
        /// <summary>
        /// ChannelId
        /// 通道号
        /// </summary>
	    public int					    nChannelID;						    
        /// <summary>
        /// event name
        /// 事件名称
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[]				    szName;					            
        /// <summary>
        /// Open gateway status see EM_OPEN_STROBE_STATE
        /// 开闸状态,具体请见EM_OPEN_STROBE_STATE
        /// </summary>
        public byte                     byOpenStrobeState;                  
        /// <summary>
        /// byte alignment
        /// 字节对齐
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[]                   bReserved1;                         
        /// <summary>
        /// PTS(ms)
        /// 时间戳(单位是毫秒)
        /// </summary>
	    public double				    PTS;							   
        /// <summary>
        /// the event happen time
        /// 事件发生的时间
        /// </summary>
	    public NET_TIME_EX			    UTC;							    
        /// <summary>
        /// event ID
        /// 事件ID
        /// </summary>
	    public int					    nEventID;						    
        /// <summary>
        /// have being detected object
        /// 检测到的物体，车标
        /// </summary>
	    public NET_MSG_OBJECT		    stuObject;						  
        /// <summary>
        /// road number
        /// 对应车道号
        /// </summary>
	    public int					    nLane;							    
        /// <summary>
        /// the car's actual rate(Km/h)
        /// 车辆实际速度Km/h
        /// </summary>
	    public int					    nSpeed;							    
        /// <summary>
        /// rate upper limit(km/h)
        /// 速度上限 单位：km/h
        /// </summary>
	    public int					    nSpeedUpperLimit;				    
        /// <summary>
        /// rate lower limit(km/h)
        /// 速度下限 单位：km/h 
        /// </summary>
	    public int					    nSpeedLowerLimit;				    
        /// <summary>
        /// BreakingRule's mask,first byte: Retrograde;second byte:Overline; the third byte:Overspeed;the forth byte:UnderSpeed;the five byte: crash red light;the six byte:passing(trafficgate),the seven byte: OverYellowLine; the eight byte: WrongRunningRoute; the nine byte: YellowVehicleInRoute; default: trafficgate
        /// 违反规则掩码,第一位:逆行;第二位:压线行驶; 第三位:超速行驶;第四位：欠速行驶; 第五位:闯红灯;第六位:穿过路口(卡口事件);第七位: 压黄线; 第八位: 有车占道; 第九位: 黄牌占道;否则默认为:交通卡口事件
        /// </summary>
	    public uint				        dwBreakingRule;					    
	    /// <summary>
        /// event file info
        /// 事件对应文件信息
	    /// </summary>
        public NET_EVENT_FILE_INFO      stuFileInfo;                        
        /// <summary>
        /// vehicle info
        /// 车身信息，有存放车牌信息
        /// </summary>
	    public NET_MSG_OBJECT           stuVehicle;                        
        /// <summary>
        /// manual snap sequence string 
        /// 手动抓拍序号
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	    public byte[]                   szManualSnapNo;                     
        /// <summary>
        /// snap index,such as 3,2,1,1 means the last one,0 means there has some exception and snap stop
        /// 表示抓拍序号,如3,2,1,1表示抓拍结束,0表示异常结束
        /// </summary>
	    public int                      nSequence;                          
        /// <summary>
        /// Event action,0 means pulse event,1 means continuous event's begin,2means continuous event's end
        /// 事件动作,0表示脉冲事件,1表示持续性事件开始,2表示持续性事件结束
        /// </summary>
	    public byte                     bEventAction;                        
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[]                   byReserved;                         
        /// <summary>
        /// snap flag from device
        /// 设备产生的抓拍标识
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public byte[]                   szSnapFlag;                         
        /// <summary>
        /// snap mode,0-normal 1-globle 2-near 4-snap on the same side 8-snap on the reverse side 16-plant picture
        /// 抓拍方式,0-未分类 1-全景 2-近景 4-同向抓拍 8-反向抓拍 16-号牌图像
        /// </summary>
	    public byte                     bySnapMode;                         
        /// <summary>
        /// over speed percentage
        /// 超速百分比
        /// </summary>
	    public byte                     byOverSpeedPercentage;              
        /// <summary>
        /// under speed percentage
        /// 欠速百分比
        /// </summary>
	    public byte                     byUnderSpeedingPercentage;          
        /// <summary>
        /// red light margin, s
        /// 红灯容许间隔时间,单位：秒
        /// </summary>
	    public byte                     byRedLightMargin;                   
        /// <summary>
        /// drive direction,0-"Approach",where the car is more near,1-"Leave",means where if mor far to the car
        /// 行驶方向,0-上行(即车辆离设备部署点越来越近),1-下行(即车辆离设备部署点越来越远)
        /// </summary>
	    public byte                     byDriveDirection;                   
        /// <summary>
        /// road way number
        /// 道路编号
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[]                   szRoadwayNo;                         
        /// <summary>
        /// violation code
        /// 违章代码
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	    public byte[]                   szViolationCode;                    
        /// <summary>
        /// violation desc
        /// 违章描述
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[]                   szViolationDesc;                    
        /// <summary>
        /// picture resolution
        /// 对应图片的分辨率
        /// </summary>
	    public NET_RESOLUTION_INFO      stuResolution;                      
        /// <summary>
        /// car type,"Motor", "Light-duty", "Medium", "Oversize", "Huge", "Other"
        /// 车辆大小类型 Minisize"微型车,"Light-duty"小型车,"Medium"中型车
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	    public byte[]                   szVehicleType;                       
        /// <summary>
        /// car length, m
        /// 车辆长度, 单位米
        /// </summary>
	    public byte                     byVehicleLenth;                     
        /// <summary>
        /// LightState means red light status:0 unknown,1 green,2 red,3 yellow
        /// LightState表示红绿灯状态:0 未知,1 绿灯,2 红灯,3 黄灯
        /// </summary>
        public byte                     byLightState;                       
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
	    public byte                     byReserved1;                       
        /// <summary>
        /// Serial number of the picture, in the same time (accurate to seconds) may have multiple images, starting from 0
        /// 图片的序号, 同一时间内(精确到秒)可能有多张图片, 从0开始
        /// </summary>
        public byte                     byImageIndex;                       
        /// <summary>
        /// over speed margin, km/h
        /// 限高速宽限值    单位：km/h 
        /// </summary>
	    public int                      nOverSpeedMargin;                    
        /// <summary>
        /// under speed margin, km/h
        /// 限低速宽限值    单位：km/h 
        /// </summary>
	    public int                      nUnderSpeedMargin;                   
        /// <summary>
        /// DrivingDirection : ["Approach", "Shanghai", "Hangzhou"]
        /// DrivingDirection : ["Approach", "上海", "杭州"]
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3 * 256)]
	    public byte[]                   szDrivingDirection;                                                                    	                    
        /// <summary>
        /// machine name
        /// 本地或远程设备名称
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	    public byte[]                   szMachineName;                      
        /// <summary>
        /// machine address
        /// 机器部署地点、道路编码
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	    public byte[]                   szMachineAddress;                   
        /// <summary>
        /// machine group
        /// 机器分组、设备所属单位
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	    public byte[]                   szMachineGroup;                     
        /// <summary>
        /// snap flags(by bit),0bit:"*",1bit:"Timing",2bit:"Manual",3bit:"Marked",4bit:"Event",5bit:"Mosaic",6bit:"Cutout"
        /// 抓图标志(按位),具体见NET_RESERVED_COMMON
        /// </summary>
        public uint                     dwSnapFlagMask;	                    
        /// <summary>
        /// The vehicle detector generates the snap signal redundancy info
        /// 由车检器产生抓拍信号冗余信息
        /// </summary>
	    public NET_SIG_CARWAY_INFO_EX   stuSigInfo;                         
        /// <summary>
        /// File path
        /// 文件路径
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
	    public byte[]                   szFilePath;                        
        /// <summary>
        /// the begin time of red light
        /// 红灯开始UTC时间
        /// </summary>
	    public NET_TIME_EX			    RedLightUTC;					     
        /// <summary>
        /// device address,OSD superimposed onto the image,from TrafficSnapshot.DeviceAddress,'\0'means end
        /// 设备地址,OSD叠加到图片上的,来源于配置TrafficSnapshot.DeviceAddress,'\0'结束
        /// </summary>
	    public IntPtr                   szDeviceAddress;                    
        /// <summary>
        /// Current picture exposure time, in milliseconds
        /// 当前图片曝光时间,单位为毫秒
        /// </summary>
	    public float                    fActualShutter;                     
        /// <summary>
        /// Current picture gain, ranging from 0 to 1000
        /// 当前图片增益,范围为0~100
        /// </summary>
	    public byte                     byActualGain;                       
        /// <summary>
        /// 0-S to N  1-SW to NE 2-W to E 3-NW to SE 4-N to S 5-NE to SW 6-E to W 7-SE to NW 8-Unknown
        /// 0-南向北 1-西南向东北 2-西向东 3-西北向东南 4-北向南 5-东北向西南 6-东向西 7-东南向西北 8-未知
        /// </summary>
        public byte                     byDirection;                        
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        public byte                     bReserve;                           
        /// <summary>
        /// Card Number
        /// 卡片个数
        /// </summary>
        public byte                     bRetCardNumber;                     
        /// <summary>
        /// Card information
        /// 卡片信息
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public NET_EVENT_CARD_INFO[]    stuCardInfo;                        
        /// <summary>
        /// Waterproof
        /// 图片防伪码
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[]                   szDefendCode;                      
        /// <summary>
        /// Link to balcklist main keyID, 0 invalid >0 blacklist data record
        /// 关联黑名单数据库记录默认主键ID, 0,无效；> 0,黑名单数据记录
        /// </summary>
        public int                      nTrafficBlackListID;                 
        /// <summary>
        /// public info
        /// 公共信息
        /// </summary>
        public NET_EVENT_COMM_INFO      stCommInfo;                          
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 452)]
        public byte[]                   bReserved;	                        
    }

    /// <summary>
    /// strobe state
    /// 道闸状态
    /// </summary>
    public enum EM_OPEN_STROBE_STATE
    {
        /// <summary>
        /// unknown
        /// 未知状态
        /// </summary>
        UNKOWN,                                                             
        /// <summary>
        /// close
        /// 关闸
        /// </summary>
        CLOSE,                                                            
        /// <summary>
        /// auto open
        /// 自动开闸
        /// </summary>
        AUTO,                                                             
        /// <summary>
        /// manual open
        /// 手动开闸
        /// </summary>
        MANUAL,                                                           
    }
    
    /// <summary>
    /// the describe of EVENT_IVS_TRAFFIC_MANUALSNAP's data
    /// 交通手动抓拍事件对应的数据块描述信息
    /// </summary>
    public struct NET_DEV_EVENT_TRAFFIC_MANUALSNAP_INFO
    {
        /// <summary>
        /// channel ID
        /// 通道号
        /// </summary>
	    public int					                    nChannelID;			// channel ID
        /// <summary>
        /// event name
        /// 事件名称
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	    public byte[]				                    szName;			    // event name
        /// <summary>
        /// byte alignment
        /// 字节对齐
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	    public byte[]                                   bReserved1;         // byte alignment
        /// <summary>
        /// PTS(ms)
        /// 时间戳(单位是毫秒)
        /// </summary>
	    public double				                    PTS;				// PTS(ms)
        /// <summary>
        /// the event happen time
        /// 事件发生的时间
        /// </summary>
	    public NET_TIME_EX			                    UTC;				// the event happen time
        /// <summary>
        /// event ID
        /// 事件ID
        /// </summary>
	    public int					                    nEventID;			// event ID
        /// <summary>
        /// Corresponding Lane number
        /// 对应车道号
        /// </summary>
	    public int					                    nLane;				// lane number
        /// <summary>
        /// manual snap number
        /// 手动抓拍序号
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	    public string                                   szManualSnapNo;     // manual snap number 
        /// <summary>
        /// have being detected object
        /// 对像信息
        /// </summary>
	    public NET_MSG_OBJECT		                    stuObject;			// have being detected object
        /// <summary>
        /// vehicle info
        /// 车身信息
        /// </summary>
	    public NET_MSG_OBJECT                           stuVehicle;         // have being detected vehicle
        /// <summary>
        /// Traffic vehicle info
        /// 交通车辆信息
        /// </summary>
	    public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO    stTrafficCar;       // TrafficCar info
        /// <summary>
        /// event file info
        /// 事件对应文件信息
        /// </summary>
	    public NET_EVENT_FILE_INFO                      stuFileInfo;        // event file info
        /// <summary>
        /// Event action,0 means pulse event,1 means continuous event's begin,2means continuous event's end
        /// 事件动作,0表示脉冲事件,1表示持续性事件开始,2表示持续性事件结束
        /// </summary>
	    public byte                                     bEventAction;       // Event action,0 means pulse event,1 means continuous event's begin,2means continuous event's end
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[]                                   byReserved;
        /// <summary>
        /// Serial number of the picture, in the same time (accurate to seconds) may have multiple images, starting from 0
        /// 图片的序号, 同一时间内(精确到秒)可能有多张图片, 从0开始
        /// </summary>
        public byte                                     byImageIndex;       // Serial number of the picture, in the same time (accurate to seconds) may have multiple images, starting from 0
        /// <summary>
        /// snap flags(by bit),0bit:"*",1bit:"Timing",2bit:"Manual",3bit:"Marked",4bit:"Event",5bit:"Mosaic",6bit:"Cutout"
        /// 抓图标志(按位),具体见NET_RESERVED_COMMON
        /// </summary>
        public uint                                     dwSnapFlagMask;	    // snap flags(by bit),0bit:"*",1bit:"Timing",2bit:"Manual",3bit:"Marked",4bit:"Event",5bit:"Mosaic",6bit:"Cutout"
        /// <summary>
        /// picture resolution
        /// 对应图片的分辨率
        /// </summary>
	    public NET_RESOLUTION_INFO                      stuResolution;      // picture resolution
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1016)]
	    public byte[]				                    bReserved;			// reserved
        /// <summary>
        /// public info
        /// 公共信息
        /// </summary>
        public NET_EVENT_COMM_INFO                      stCommInfo;         // public info 
    }

    /// <summary>
    /// event type  EVENT_IVS_TRAFFIC_PARKINGSPACEPARKING(parking space parking)corresponding data block description info
    /// 车位有车事件对应的数据块描述信息
    /// </summary>
    public struct NET_DEV_EVENT_TRAFFIC_PARKINGSPACEPARKING_INFO
    {
        /// <summary>
        /// channel ID
        /// 通道号
        /// </summary>
	    public int					                    nChannelID;			
        /// <summary>
        /// event name
        /// 事件名称
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[]                                   szName;             
        /// <summary>
        /// byte alignment
        /// 字节对齐
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	    public byte[]                                   bReserved1;         
        /// <summary>
        /// Time stamp(ms)
        /// 时间戳(单位是毫秒)
        /// </summary>
	    public uint				                        PTS;			   
        /// <summary>
        /// Event occurred time
        /// 事件发生的时间
        /// </summary>
	    public NET_TIME_EX			                    UTC;			    
        /// <summary>
        /// Event ID
        /// 事件ID
        /// </summary>
	    public int					                    nEventID;		    
        /// <summary>
        /// Corresponding lane No.
        /// 对应车道号
        /// </summary>
	    public int					                    nLane;			    
        /// <summary>
        /// Detected object
        /// 检测到的物体
        /// </summary>
	    public NET_MSG_OBJECT		                    stuObject;		    
        /// <summary>
        /// Vehicle body info
        /// 车身信息
        /// </summary>
	    public NET_MSG_OBJECT                           stuVehicle;         
        /// <summary>
        /// The corresponding file info of the event
        /// 事件对应文件信息
        /// </summary>
	    public NET_EVENT_FILE_INFO                      stuFileInfo;        
	    /// <summary>
        /// snap index: such as 3,2,1,1 means the last one,0 means there has some exception and snap stop
        /// 表示抓拍序号,如3,2,1,1表示抓拍结束,0表示异常结束 
	    /// </summary>
	    public int                                      nSequence;           
        /// <summary>
        /// Event operation.0=pulse event,1=begin of the durative event,2=end of the durative event
        /// 事件动作,0表示脉冲事件,1表示持续性事件开始,2表示持续性事件结束
        /// </summary>
	    public byte                                     bEventAction;       
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[]                                   byReserved;
        /// <summary>
        /// Serial number of the picture, in the same time (accurate to seconds) may have multiple images, starting from 0
        /// 图片的序号, 同一时间内(精确到秒)可能有多张图片, 从0开始
        /// </summary>
        public byte                                     byImageIndex;      
        /// <summary>
        /// snap flags(by bit),0bit:"*",1bit:"Timing",2bit:"Manual",3bit:"Marked",4bit:"Event",5bit:"Mosaic",6bit:"Cutout"
        /// 抓图标志(按位),具体见NET_RESERVED_COMMON 
        /// </summary>
	    public uint                                     dwSnapFlagMask;	    
	    /// <summary>
        /// picture resolution
        /// 对应图片的分辨率
	    /// </summary>
	    public NET_RESOLUTION_INFO                      stuResolution;      
        /// <summary>
        /// Traffic vehicle info
        /// 交通车辆信息
        /// </summary>
	    public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO    stTrafficCar;       
        /// <summary>
        /// parking space status 0-free 1-not free 2-on line
        /// 车位综合的状态,0-占用,1-空闲,2-压线
        /// </summary>
	    public int                                      nParkingSpaceStatus;
        /// <summary>
        /// traffic paring information
        /// 停车场信息
        /// </summary>
        public NET_DEV_TRAFFIC_PARKING_INFO             stTrafficParingInfo;
        /// <summary>
        /// The source of plate text, 0:Local,1:Server
        /// 车牌识别来源, 0:本地算法识别,1:后端服务器算法识别
        /// </summary>
        public byte                                     byPlateTextSource;                          
        /// <summary>
        /// reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 379)]
        public byte[]                                   bReserved;            
        /// <summary>
        /// public info 
        /// 公共信息
        /// </summary>
        public NET_EVENT_COMM_INFO                      stCommInfo;          
    }

    /// <summary>
    /// Parking lot info
    /// 停车场信息
    /// </summary>
    public struct NET_DEV_TRAFFIC_PARKING_INFO
    {
        /// <summary>
        /// Feature image point number
        /// 特征图片区点个数
        /// </summary>
        public int                              nFeaturePicAreaPointNum;    
        /// <summary>
        /// Feature image info
        /// 特征图片区信息
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public NET_POINT[]                        stFeaturePicArea;         
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 572)]
        public byte[]                             bReserved;                
    }

    /// <summary>
    /// event type  EVENT_IVS_TRAFFIC_PARKINGSPACENOPARKING(parking space no parking)corresponding data block description info
    /// 车位无车事件对应的数据块描述信息
    /// </summary>
    public struct NET_DEV_EVENT_TRAFFIC_PARKINGSPACENOPARKING_INFO
    {
        /// <summary>
        /// channel ID
        /// 通道号
        /// </summary>
	    public int					                    nChannelID;			
        /// <summary>
        /// event name
        /// 事件名称
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string                                   szName;             
        /// <summary>
        /// byte alignment
        /// 字节对齐
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	    public byte[]                                   bReserved1;         
        /// <summary>
        /// Time stamp(ms)
        /// 时间戳(单位是毫秒)
        /// </summary>
	    public uint				                        PTS;				
        /// <summary>
        /// Event occurred time
        /// 事件发生的时间
        /// </summary>
	    public NET_TIME_EX			                    UTC;				
        /// <summary>
        /// Event ID
        /// 事件ID
        /// </summary>
	    public int					                    nEventID;			
        /// <summary>
        /// Corresponding lane No.
        /// 对应车道号
        /// </summary>
	    public int					                    nLane;				
        /// <summary>
        /// Detected object
        /// 检测到的物体
        /// </summary>
	    public NET_MSG_OBJECT		                    stuObject;			
        /// <summary>
        /// Vehicle body info
        /// 车身信息
        /// </summary>
	    public NET_MSG_OBJECT                           stuVehicle;         
        /// <summary>
        /// The corresponding file info of the event
        /// 事件对应文件信息
        /// </summary>
	    public NET_EVENT_FILE_INFO                      stuFileInfo;        
	    /// <summary>
        /// snap index: such as 3,2,1,1 means the last one,0 means there has some exception and snap stop
        /// 表示抓拍序号,如3,2,1,1表示抓拍结束,0表示异常结束
	    /// </summary>
	    public int                                      nSequence;          
        /// <summary>
        /// Event operation.0=pulse event,1=begin of the durative event,2=end of the durative event
        /// 事件动作,0表示脉冲事件,1表示持续性事件开始,2表示持续性事件结束
        /// </summary>
	    public byte                                     bEventAction;       
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[]                                   byReserved;
        /// <summary>
        /// Serial number of the picture, in the same time (accurate to seconds) may have multiple images, starting from 0
        /// 图片的序号, 同一时间内(精确到秒)可能有多张图片, 从0开始
        /// </summary>
        public byte                                     byImageIndex;       
        /// <summary>
        /// snap flags(by bit),0bit:"*",1bit:"Timing",2bit:"Manual",3bit:"Marked",4bit:"Event",5bit:"Mosaic",6bit:"Cutout"
        /// 抓图标志(按位),具体见NET_RESERVED_COMMON
        /// </summary>
	    public uint                                     dwSnapFlagMask;	     
	    /// <summary>
        /// picture resolution
        /// 对应图片的分辨率
	    /// </summary>
	    public NET_RESOLUTION_INFO                      stuResolution;       
        /// <summary>
        /// Traffic vehicle info
        /// 交通车辆信息
        /// </summary>
	    public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO    stTrafficCar;        
        /// <summary>
        /// traffic paring information
        /// 停车场信息
        /// </summary>
        public NET_DEV_TRAFFIC_PARKING_INFO             stTrafficParingInfo;
        /// <summary>
        /// The source of plate text, 0:Local,1:Server
        /// 车牌识别来源, 0:本地算法识别,1:后端服务器算法识别
        /// </summary>
        public byte                                     byPlateTextSource;    
        /// <summary>
        /// reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 383)]
        public byte[]                                   bReserved;           
        /// <summary>
        /// public info
        /// 公共信息
        /// </summary>
        public NET_EVENT_COMM_INFO                      stCommInfo;           
    }
	
    /// <summary>
    /// event type EVENT_IVS_PARKINGDETECTION corresponding data block description info 
    /// 非法停车事件对应的数据块描述信息
    /// </summary>
	public struct NET_DEV_EVENT_PARKINGDETECTION_INFO
    {
        /// <summary>
        /// ChannelId
        /// 通道号
        /// </summary>
	    public int					    nChannelID;						    
        /// <summary>
        /// event name
        /// 事件名称
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	    public string				    szName;					            
        /// <summary>
        /// byte alignment
        /// 字节对齐
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	    public byte[]                   bReserved1;                         
        /// <summary>
        /// PTS(ms)
        /// 时间戳(单位是毫秒)
        /// </summary>
	    public double				    PTS;							    
        /// <summary>
        /// the event happen time
        /// 事件发生的时间
        /// </summary>
	    public NET_TIME_EX			    UTC;							    
        /// <summary>
        /// event ID
        /// 事件ID
        /// </summary>
	    public int					    nEventID;						    
        /// <summary>
        /// have being detected object
        /// 检测到的物体
        /// </summary>
	    public NET_MSG_OBJECT		    stuObject;						    
        /// <summary>
        /// detect region's point number
        /// 规则检测区域顶点数
        /// </summary>
	    public int                      nDetectRegionNum;				    
        /// <summary>
        /// detect region info
        /// 规则检测区域
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	    public NET_POINT[]              DetectRegion;                     
        /// <summary>
        /// event file info
        /// 事件对应文件信息
        /// </summary>
	    public NET_EVENT_FILE_INFO      stuFileInfo;                       
        /// <summary>
        /// Event action,0 means pulse event,1 means continuous event's begin,2means continuous event's end
        /// 事件动作,0表示脉冲事件,1表示持续性事件开始,2表示持续性事件结束
        /// </summary>
	    public byte                     bEventAction;                       
        /// <summary>
        /// reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[]                   byReserved;                        
        /// <summary>
        /// Serial number of the picture, in the same time (accurate to seconds) may have multiple images, starting from 0
        /// 图片的序号, 同一时间内(精确到秒)可能有多张图片, 从0开始
        /// </summary>
        public byte                     byImageIndex;                     
        /// <summary>
        /// snap flags(by bit),0bit:"*",1bit:"Timing",2bit:"Manual",3bit:"Marked",4bit:"Event",5bit:"Mosaic",6bit:"Cutout"
        /// 抓图标志(按位),具体见NET_RESERVED_COMMON
        /// </summary>
        public uint                     dwSnapFlagMask;	                    
        /// <summary>
        /// the source device's index,-1 means data in invalid
        /// 事件源设备上的index,-1表示数据无效
        /// </summary>
	    public int                      nSourceIndex;                      
        /// <summary>
        /// the source device's sign(exclusive),field said local device does not exist or is empty
        /// 事件源设备唯一标识,字段不存在或者为空表示本地设备
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	    public string                   szSourceDevice;                      
        /// <summary>
        /// event trigger accumilated times
        /// 事件触发累计次数
        /// </summary>
        public uint                     nOccurrenceCount;                    
        /// <summary>
        /// intelli comm info
        /// 智能事件公共信息
        /// </summary>
  	    public NET_EVENT_COMM_INFO      stuIntelliCommInfo;                 
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 616)]
	    public byte[]				    bReserved;				             
    } 
	
    /// <summary>
    /// event type  EVENT_IVS_TRAFFIC_OVERLINE(traffic-Overline)corresponding data block description info
    /// 交通-压线事件对应的数据块描述信息
    /// </summary>
    public struct NET_DEV_EVENT_TRAFFIC_OVERLINE_INFO
    {
        /// <summary>
        /// channel ID
        /// 通道号
        /// </summary>
        public int					nChannelID;			                    
        /// <summary>
        /// event name
        /// 事件名称
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string               szName;                                 
        /// <summary>
        /// byte alignment
        /// 字节对齐
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	    public byte[]               bReserved1;                             
        /// <summary>
        /// PTS(ms)
        /// 时间戳(单位是毫秒)
        /// </summary>
        public double				PTS;				                    
        /// <summary>
        /// the event happen time
        /// 事件发生的时间
        /// </summary>
        public NET_TIME_EX			UTC;				                    
        /// <summary>
        /// event ID
        /// 事件ID
        /// </summary>
        public int					nEventID;			                    
        /// <summary>
        /// Corresponding Lane number
        /// 对应车道号
        /// </summary>
        public int					nLane;				                    
        /// <summary>
        /// have being detected object
        /// 车牌信息
        /// </summary>
        public NET_MSG_OBJECT		stuObject;			                    
        /// <summary>
        /// vehicle info
        /// 车身信息
        /// </summary>
        public NET_MSG_OBJECT       stuVehicle;                             
        /// <summary>
        /// event file info
        /// 事件对应文件信息
        /// </summary>
        public NET_EVENT_FILE_INFO  stuFileInfo;                            
        /// <summary>
        /// snap index,such as 3,2,1,1 means the last one,0 means there has some exception and snap stop
        /// 表示抓拍序号,如3,2,1,1表示抓拍结束,0表示异常结束
        /// </summary>
        public int                  nSequence;                             
        /// <summary>
        /// speed,km/h
        /// 车辆实际速度,Km/h
        /// </summary>
        public int                  nSpeed;                                
        /// <summary>
        /// Event operation.0=pulse event,1=begin of the durative event,2=end of the durative event
        /// 事件动作,0表示脉冲事件,1表示持续性事件开始,2表示持续性事件结束
        /// </summary>
        public byte                 bEventAction;                            
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[]               byReserved;
        /// <summary>
        /// Serial number of the picture, in the same time (accurate to seconds) may have multiple images, starting from 0
        /// 图片的序号, 同一时间内(精确到秒)可能有多张图片, 从0开始
        /// </summary>
        public byte                 byImageIndex;                           
        /// <summary>
        /// flag(by bit),see NET_RESERVED_COMMON
        /// 抓图标志(按位),具体见NET_RESERVED_COMMON 
        /// </summary>
        public uint                 dwSnapFlagMask;	                        
        /// <summary>
        /// picture resolution
        /// 对应图片的分辨率
        /// </summary>
        public NET_RESOLUTION_INFO  stuResolution;
        /// <summary>
        /// GPS info
        /// GPS信息
        /// </summary>
        public NET_GPS_INFO         stuGPSInfo;            	
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 968)]
	    public byte[]               bReserved;                              
        /// <summary>
        /// Traffic vehicle info
        /// 交通车辆信息
        /// </summary>
        public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stTrafficCar;          
        /// <summary>
        /// public info 
        /// 公共信息
        /// </summary>
        public NET_EVENT_COMM_INFO   stCommInfo;                            
    }

    /// <summary>
    /// event type  EVENT_IVS_TRAFFIC_OVERYELLOWLINE(traffic-OverYellowLine)corresponding data block description info
    /// 交通违章-压黄线对应的数据块描述信息
    /// </summary>
    public struct NET_DEV_EVENT_TRAFFIC_OVERYELLOWLINE_INFO
    {
        /// <summary>
        /// channel ID
        /// 通道号
        /// </summary>
        public int					nChannelID;			                    
        /// <summary>
        /// event name
        /// 事件名称
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string               szName;                                 
        /// <summary>
        /// byte alignment
        /// 字节对齐
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	    public byte[]               bReserved1;                             
        /// <summary>
        /// PTS(ms)
        /// 时间戳(单位是毫秒)
        /// </summary>
        public double				PTS;				                    
        /// <summary>
        /// the event happen time
        /// 事件发生的时间
        /// </summary>
        public NET_TIME_EX			UTC;				                    
        /// <summary>
        /// event ID
        /// 事件ID
        /// </summary>
        public int					nEventID;			                    
        /// <summary>
        /// have being detected object
        /// 检测到的物体
        /// </summary>
        public NET_MSG_OBJECT		stuObject;						        
        /// <summary>
        /// vehicle info
        /// 车身信息
        /// </summary>
	    public NET_MSG_OBJECT       stuVehicle;                             
        /// <summary>
        /// Corresponding Lane number
        /// 对应车道号
        /// </summary>
	    public int					nLane;							        
        /// <summary>
        /// event file info
        /// 事件对应文件信息
        /// </summary>
	    public NET_EVENT_FILE_INFO  stuFileInfo;                                  
        /// <summary>
        /// Event operation.0=pulse event,1=begin of the durative event,2=end of the durative event
        /// 事件动作,0表示脉冲事件,1表示持续性事件开始,2表示持续性事件结束
        /// </summary>
	    public byte                 bEventAction;                           
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[]               byReserved;
        /// <summary>
        /// Serial number of the picture, in the same time (accurate to seconds) may have multiple images, starting from 0
        /// 图片的序号, 同一时间内(精确到秒)可能有多张图片, 从0开始
        /// </summary>
        public byte                 byImageIndex;                           
        /// <summary>
        /// speed,km/h
        /// 车辆实际速度,km/h
        /// </summary>
	    public int                  nSpeed;                                 
        /// <summary>
        /// flag(by bit),see NET_RESERVED_COMMON
        /// 抓图标志(按位),具体见NET_RESERVED_COMMON 
        /// </summary>
        public uint                 dwSnapFlagMask;	                        
        /// <summary>
        /// picture resolution
        /// 对应图片的分辨率
        /// </summary>
	    public NET_RESOLUTION_INFO  stuResolution;                          
        /// <summary>
        /// true:corresponding alarm recording; false: no corresponding alarm recording
        /// True:有对应的报警录像; false:无对应的报警录像
        /// </summary>
	    public int                  bIsExistAlarmRecord;                    
        /// <summary>
        /// Video size
        /// 录像大小
        /// </summary>
	    public uint                 dwAlarmRecordSize;                      
        /// <summary>
        /// Video Path
        /// 录像路径
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	    public byte[]               szAlarmRecordPath;                      
        /// <summary>
        /// intelli comm info
        /// 智能事件公共信息
        /// </summary>
	    public NET_EVENT_INTELLI_COMM_INFO     stuIntelliCommInfo;          
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 532)]
	    public byte[]				bReserved;					            
        /// <summary>
        /// Traffic vehicle info
        /// 交通车辆信息
        /// </summary>
	    public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stTrafficCar;          
	    /// <summary>
        /// Acme amount of the rule detect zone 
        /// 规则检测区域顶点数
	    /// </summary>
	    public int                  nDetectNum;				                
        /// <summary>
        /// Rule detect zone
        /// 规则检测区域
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public NET_POINT[]          DetectRegion;                           
	    /// <summary>
        /// public info 
        /// 公共信息
	    /// </summary>
        public NET_EVENT_COMM_INFO  stCommInfo;                             
    }

    /// <summary>
    /// event type EVENT_IVS_TRAFFIC_RETROGRADE corresponding data block description info
    /// 交通-逆行事件对应的数据块描述信息
    /// </summary>
    public struct NET_DEV_EVENT_TRAFFIC_RETROGRADE_INFO
    {
        /// <summary>
        /// channel ID
        /// 通道号
        /// </summary>
        public int					nChannelID;			                    
        /// <summary>
        /// event name
        /// 事件名称
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string               szName;                                 
        /// <summary>
        /// byte alignment
        /// 字节对齐
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	    public byte[]               bReserved1;                             
        /// <summary>
        /// PTS(ms)
        /// 时间戳(单位是毫秒)
        /// </summary>
        public double				PTS;				                    
        /// <summary>
        /// the event happen time
        /// 事件发生的时间
        /// </summary>
        public NET_TIME_EX			UTC;				                    
        /// <summary>
        /// event ID
        /// 事件ID
        /// </summary>
        public int					nEventID;			                    
        /// <summary>
        /// Corresponding Lane number
        /// 对应车道号
        /// </summary>
        public int					nLane;				                    
        /// <summary>
        /// have being detected object
        /// 车牌信息
        /// </summary>
        public NET_MSG_OBJECT		stuObject;			                    
        /// <summary>
        /// vehicle info
        /// 车身信息
        /// </summary>
        public NET_MSG_OBJECT       stuVehicle;                             
        /// <summary>
        /// event file info
        /// 事件对应文件信息
        /// </summary>
        public NET_EVENT_FILE_INFO  stuFileInfo;                            
        /// <summary>
        /// snap index,such as 3,2,1,1 means the last one,0 means there has some exception and snap stop
        /// 表示抓拍序号,如3,2,1,1表示抓拍结束,0表示异常结束
        /// </summary>
        public int                  nSequence;                              
        /// <summary>
        /// speed,km/h
        /// 车辆实际速度,Km/h
        /// </summary>
        public int                  nSpeed;                                  
        /// <summary>
        /// Event operation.0=pulse event,1=begin of the durative event,2=end of the durative event
        /// 事件动作,0表示脉冲事件,1表示持续性事件开始,2表示持续性事件结束
        /// </summary>
        public byte                 bEventAction;                           
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[]               byReserved;
        /// <summary>
        /// Serial number of the picture, in the same time (accurate to seconds) may have multiple images, starting from 0
        /// 图片的序号, 同一时间内(精确到秒)可能有多张图片, 从0开始
        /// </summary>
        public byte                 byImageIndex;                         
        /// <summary>
        /// flag(by bit),see NET_RESERVED_COMMON
        /// 抓图标志(按位),具体见NET_RESERVED_COMMON 
        /// </summary>
        public uint                 dwSnapFlagMask;	                         
        /// <summary>
        /// picture resolution
        /// 对应图片的分辨率
        /// </summary>
        public NET_RESOLUTION_INFO  stuResolution;                          
        /// <summary>
        /// true:corresponding alarm recording; false: no corresponding alarm recording
        /// True:有对应的报警录像; false:无对应的报警录像
        /// </summary>
	    public int                  bIsExistAlarmRecord;                   
        /// <summary>
        /// Video size
        /// 录像大小
        /// </summary>
	    public uint                 dwAlarmRecordSize;                   
        /// <summary>
        /// Video Path
        /// 录像路径
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	    public byte[]               szAlarmRecordPath;                     
        /// <summary>
        /// intelli comm info
        /// 智能事件公共信息
        /// </summary>
	    public NET_EVENT_INTELLI_COMM_INFO     stuIntelliCommInfo;
        /// <summary>
        /// GPS info
        /// GPS信息
        /// </summary>
        public NET_GPS_INFO                     stuGPSInfo;
        /// <summary>
        /// Reserved 
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 484)]
	    public byte[]				bReserved;					           
        /// <summary>
        /// Traffic vehicle info
        /// 交通车辆信息
        /// </summary>
	    public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stTrafficCar;    		
        /// <summary>
        /// Acme amount of the rule detect zone 
        /// 规则检测区域顶点数
        /// </summary>
	    public int                  nDetectNum;				               
        /// <summary>
        /// Rule detect zone
        /// 规则检测区域
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public NET_POINT[]          DetectRegion;                          	
        /// <summary>
        /// public info
        /// 公共信息
        /// </summary>
        public NET_EVENT_COMM_INFO  stCommInfo;                            
    }

    /// <summary>
    /// event type EVENT_IVS_TRAFFIC_WRONGROUTE corresponding data block description info
    /// 交通违章-不按车道行驶对应的数据块描述信息
    /// </summary>
    public struct NET_DEV_EVENT_TRAFFIC_WRONGROUTE_INFO
    {
        /// <summary>
        /// channel ID
        /// 通道号
        /// </summary>
        public int					nChannelID;			                   
        /// <summary>
        /// event name
        /// 事件名称
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string               szName;                                
        /// <summary>
        /// byte alignment
        /// 字节对齐
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	    public byte[]               bReserved1;                            
        /// <summary>
        /// PTS(ms)
        /// 时间戳(单位是毫秒)
        /// </summary>
        public double				PTS;				                   
        /// <summary>
        /// the event happen time
        /// 事件发生的时间
        /// </summary>
        public NET_TIME_EX			UTC;				                   
        /// <summary>
        /// event ID
        /// 事件ID
        /// </summary>
        public int					nEventID;			                   
        /// <summary>
        /// have being detected object
        /// 检测到的物体
        /// </summary>
        public NET_MSG_OBJECT		stuObject;						       
        /// <summary>
        /// vehicle info
        /// 车身信息
        /// </summary>
	    public NET_MSG_OBJECT       stuVehicle;                            
        /// <summary>
        /// Corresponding Lane number
        /// 对应车道号
        /// </summary>
	    public int					nLane;							       
        /// <summary>
        /// event file info  
        /// 事件对应文件信息
        /// </summary>
	    public NET_EVENT_FILE_INFO  stuFileInfo;                                 
        /// <summary>
        /// Event operation.0=pulse event,1=begin of the durative event,2=end of the durative event
        /// 事件动作,0表示脉冲事件,1表示持续性事件开始,2表示持续性事件结束
        /// </summary>
	    public byte                 bEventAction;                           
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[]               byReserved;
        /// <summary>
        /// Serial number of the picture, in the same time (accurate to seconds) may have multiple images, starting from 0
        /// 图片的序号, 同一时间内(精确到秒)可能有多张图片, 从0开始
        /// </summary>
        public byte                 byImageIndex;                          
        /// <summary>
        /// speed,km/h
        /// 车辆实际速度,km/h
        /// </summary>
	    public int                  nSpeed;                                
        /// <summary>
        /// flag(by bit),see NET_RESERVED_COMMON
        /// 抓图标志(按位),具体见NET_RESERVED_COMMON  
        /// </summary>
        public uint                 dwSnapFlagMask;	                       
        /// <summary>
        /// picture resolution
        /// 对应图片的分辨率
        /// </summary>
	    public NET_RESOLUTION_INFO  stuResolution;
        /// <summary>
        /// GPS info
        /// GPS信息
        /// </summary>
        public NET_GPS_INFO stuGPSInfo;                 
        /// <summary>
        /// Reserved 
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 972)]
        public byte[]				bReserved;				               
        /// <summary>
        /// Traffic vehicle info
        /// 交通车辆信息
        /// </summary>
        public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stTrafficCar;          
        /// <summary>
        /// public info 
        /// 公共信息
        /// </summary>
        public NET_EVENT_COMM_INFO  stCommInfo;                              
    }

    /// <summary>
    /// New audio detection alarm information 
    /// 新音频检测报警信息
    /// </summary>
    public struct NET_NEW_SOUND_ALARM_STATE
    {
        /// <summary>
        /// alarm channel count
        /// 报警的通道个数
        /// </summary>
        public int                                      channelcount;       
        /// <summary>
        /// sound alarm information
        /// 音频报警信息
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public NET_NEW_SOUND_ALARM_STATE1[]             SoundAlarmInfo;     
    }

    /// <summary>
    /// New audio detection alarm information
    /// 新音频检测报警信息
    /// </summary>
    public struct NET_NEW_SOUND_ALARM_STATE1
    {
        /// <summary>
        /// alarm channel number
        /// 报警通道号
        /// </summary>
        public int                                      channel;            
        /// <summary>
        /// Alarm type;0:Volume value is too low ,1:Volume value is too high
        /// 报警类型；0：音频值过低,1：音频值过高
        /// </summary>
        public int                                      alarmType;          
        /// <summary>
        /// Volume
        /// 音量值
        /// </summary>
        public uint                                     volume;             
        /// <summary>
        /// volume alarm state, 0: alarm appear, 1: alarm disappear
        /// 音频报警状态, 0: 音频报警出现, 1: 音频报警消失
        /// </summary>
        public byte                                     byState;           
        /// <summary>
        /// reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 255)]
        public byte[]                                   reserved;           
    }

    /// <summary>
    /// struct about audio anomaly alarm information
    /// 音频异常事件对应的数据描述信息
    /// </summary>
    public struct NET_ALARM_AUDIO_ANOMALY
    {
        /// <summary>
        /// struct size
        /// 结构体大小
        /// </summary>
        public uint                                     dwStructSize;       
        /// <summary>
        /// Event Action,0:Start, 1:Stop
        /// 事件动作, 0:Start, 1:Stop
        /// </summary>
        public uint                                     dwAction;           
        /// <summary>
        /// Audio Channel ID 
        /// 音频通道号
        /// </summary>
        public uint                                     dwChannelID;        
        /// <summary>
        /// Audio sensitivity
        /// 声音强度
        /// </summary>
        public int                                      nDecibel;           
        /// <summary>
        /// Audio frequency
        /// 声音频率
        /// </summary>
        public int                                      nFrequency;         
    }

    /// <summary>
    /// struct about audio mutation alarm information
    /// 声强突变事件对应的数据描述信息
    /// </summary>
    public struct NET_ALARM_AUDIO_MUTATION
    {
        /// <summary>
        /// StructSize
        /// 结构体大小
        /// </summary>
        public uint                                     dwStructSize;       
        /// <summary>
        /// Event Action,0:Start, 1:Stop
        /// 事件动作, 0:Start, 1:Stop
        /// </summary>
        public uint                                     dwAction;           
        /// <summary>
        /// Audio Channel ID
        /// 音频通道号
        /// </summary>
        public uint                                     dwChannelID;        
    }

    /// <summary>
    /// system ability
    /// 系统能力类型
    /// </summary>
    public enum EM_SYS_ABILITY
    {
        /// <summary>
        /// dynamic connect capacity
        /// 查询动态多连接能力
        /// </summary>
        DYNAMIC_CONNECT = 1,                                               
        /// <summary>
        /// Watermark configuration capacity
        /// 水印配置能力
        /// </summary>
        WATERMARK_CFG = 17,			                                       
        /// <summary>
        /// wireless  configuration capacity
        /// wireless配置能力
        /// </summary>
        WIRELESS_CFG = 18,			                                       
        /// <summary>
        /// Device capacity list 
        /// 设备的能力列表
        /// </summary>
        DEVALL_INFO = 26,			                                       
        /// <summary>
        /// Card number search capacity 
        /// 卡号查询能力
        /// </summary>
        CARD_QUERY = 0x0100,		                                       
        /// <summary>
        /// Multiple-window preview capacity 
        /// 多画面预览能力
        /// </summary>
        MULTIPLAY = 0x0101,			                                       
        /// <summary>
        /// Fast query configuration Capabilities
        /// 快速查询配置能力
        /// </summary>
        QUICK_QUERY_CFG = 0x0102,	                                       
        /// <summary>
        /// Wireless alarm capacity 
        /// 无线报警能力
        /// </summary>
        INFRARED = 0x0121,			                                       
        /// <summary>
        /// Alarm activation mode function 
        /// 报警输出触发方式能力
        /// </summary>
        TRIGGER_MODE = 0x0131,		                                       
        /// <summary>
        /// Network hard disk partition
        /// 网络硬盘分区能力
        /// </summary>
        DISK_SUBAREA = 0x0141,		                                       
        /// <summary>
        /// Query DSP Capabilities
        /// 查询DSP能力
        /// </summary>
        DSP_CFG = 0x0151,			                                       
        /// <summary>
        /// Query SIP,RTSP Capabilities
        /// 查询SIP,RTSP能力
        /// </summary>
        STREAM_MEDIA = 0x0161,		                                       
        /// <summary>
        /// Search intelligent track capability
        /// 查询智能跟踪能力
        /// </summary>
        INTELLI_TRACKER = 0x0171,                                          
    } 
	
    /// <summary>
    /// device enable information
    /// 设备使能信息
    /// </summary>
	public struct NET_DEV_ENABLE_INFO
    {
        /// <summary>
        /// Function list capacity set. Corresponding to the above mentioned enumeration. Use bit to represent sub-function
        /// 功能列表能力集,下标对应上述的枚举值,按位表示子功能
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
	    public uint[] IsFucEnable;			                                
    }
	
    /// <summary>
    /// query log type
    /// 查询日志类型
    /// </summary>
	public enum EM_LOG_QUERY_TYPE
    {
        /// <summary>
        /// All logs
        /// 所有日志
        /// </summary>
        ALL = 0,								                            
        /// <summary>
        /// System logs 
        /// 系统日志
        /// </summary>
        SYSTEM,								                                
        /// <summary>
        /// Configuration logs 
        /// 配置日志
        /// </summary>
        CONFIG,								                                
        /// <summary>
        /// Storage logs
        /// 存储相关
        /// </summary>
        STORAGE,								                            
        /// <summary>
        /// Alarm logs 
        /// 报警日志
        /// </summary>
        ALARM,								                                
        /// <summary>
        /// Record related
        /// 录象相关
        /// </summary>
        RECORD,								                                
        /// <summary>
        /// Account related
        /// 帐号相关
        /// </summary>
        ACCOUNT,								                            
        /// <summary>
        /// Clear log 
        /// 清除日志
        /// </summary>
        CLEAR,								                                
        /// <summary>
        /// Playback related 
        /// 回放相关
        /// </summary>
        PLAYBACK,								                            
        /// <summary>
        /// Concerning the front-end management and running
        /// 前端管理运行相关
        /// </summary>
        MANAGER                                                             
    }
	
    /// <summary>
    /// query device log prarm
    /// 查询设备日志参数
    /// </summary>
	public struct NET_QUERY_DEVICE_LOG_PARAM
    {
        /// <summary>
        /// Searched log type
        /// 查询日志类型
        /// </summary>
	    public EM_LOG_QUERY_TYPE	                emLogType;				
        /// <summary>
        /// The searched log start time
        /// 查询日志的开始时间
        /// </summary>
	    public NET_TIME			                    stuStartTime;			
        /// <summary>
        /// The searched log end time
        /// 查询日志的结束时间
        /// </summary>
	    public NET_TIME			                    stuEndTime;				
        /// <summary>
        /// The search begins from which log in one period. It shall begin with 0 if it is the first time search
        /// 在时间段中从第几条日志开始查询,开始第一次查询可设为0
        /// </summary>
	    public int				                    nStartNum;				
        /// <summary>
        /// The ended log serial number in one search,the max returning number is 1024
        /// 一次查询中到第几条日志结束,日志返回条数的最大值为1024
        /// </summary>
	    public int				                    nEndNum;				
        /// <summary>
        /// log struct type,0:NET_DEVICE_LOG_ITEM;1:NET_DEVICE_LOG_ITEM_EX
        /// 日志数据结构体类型,0:表示DH_DEVICE_LOG_ITEM；1:表示NET_DEVICE_LOG_ITEM_EX
        /// </summary>
	    public byte                                 nLogStuType;           
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	    public byte[]                               reserved;              
        /// <summary>
        /// Channel no. 0:Compatible with previous all channel numbers. The channel No. begins with 1.1: The first channel
        /// 通道号,0:兼容之前表示所有通道号,所以通道号从1开始; 1:第一个通道
        /// </summary>
	    public uint                                 nChannelID;             
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
	    public byte[]				                bReserved;              
    }
	
    /// <summary>
    /// device log content
    /// 日志信息
    /// </summary>
	public struct NET_DEVICE_LOG_ITEM
    {
        /// <summary>
        /// Log type 
        /// 日志类型
        /// </summary>
        public int                                  nLogType;				
        /// <summary>
        /// Date
        /// 日期
        /// </summary>
        public NETDEVTIME                           stuOperateTime;			
        /// <summary>
        /// Operator
        /// 操作者
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[]                               szOperator; 		    
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[]                               bReserved;              
        /// <summary>
        /// union structure type,0:szLogContext;1:stuOldLog
        /// union结构类型,0:szLogContext;1:stuOldLog
        /// </summary>
        public byte                                 bUnionType;				
        /// <summary>
        /// 0:Log content,1:Old log structure NET_OLDLOG
        /// 0:日志内容，1：老日志 结构体NET_OLDLOG
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[]                               szLogContext;           
        /// <summary>
        /// Detail operation
        /// 具体的操作内容
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[]                               reserved;               
    }
	
    /// <summary>
    /// device log content
    /// 设备日志内容
    /// </summary>
	public struct NET_DEVICE_LOG_ITEM_EX
    {
        /// <summary>
        /// Log type 
        /// 日志类型
        /// </summary>
        public int                                  nLogType;				
        /// <summary>
        /// Date
        /// 日期
        /// </summary>
        public NETDEVTIME                           stuOperateTime;			
        /// <summary>
        /// Operator
        /// 操作者
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[]                               szOperator; 		    
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[]                               bReserved;              
        /// <summary>
        /// union structure type,0:szLogContext;1:stuOldLog
        /// union结构类型,0:szLogContext;1:stuOldLog
        /// </summary>
        public byte                                 bUnionType;				
        /// <summary>
        /// 0:Log content,1:Old log structure NET_OLDLOG
        /// 0:日志内容，1：老日志 结构体NET_OLDLOG
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[]                               szLogContext;           
        /// <summary>
        /// Detail operation
        /// 具体的操作内容
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[]                               szOperation;            
        /// <summary>
        /// DetailContext
        /// 详细日志信息描述
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4 * 1024)]
        public byte[]                               szDetailContext;        
    }
	
    /// <summary>
    /// old log content
    /// 老日志内容
    /// </summary>
	public struct NET_OLDLOG
    {
        /// <summary>
        /// Old log
        /// 老日志
        /// </summary>
        public NET_LOG_ITEM                         stuLog;                  
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>         
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
        public byte[]                               bReserved;              
    }
	
    /// <summary>
    /// old log content
    /// 老日志内容
    /// </summary>
	public struct NET_LOG_ITEM
    {
        /// <summary>
        /// Date
        /// 日期
        /// </summary>
        public NETDEVTIME			                time;					
        /// <summary>
        /// Type
        /// 日志类型
        /// </summary>
        public ushort		                        type;					
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        public byte		                            reserved;				
        /// <summary>
        /// Data
        /// 数据
        /// </summary>
        public byte		                            data;					
        /// <summary>
        /// Content
        /// 内容
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[]		                        context;				
    }
	
    /// <summary>
    /// The time definition in the log information
    /// 时间结构体
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct NETDEVTIME
    {
        [FieldOffset(0)]
        private uint _value;

        /// <summary>
        /// Second 6bit
        /// 秒 6位
        /// </summary>
        public uint Second
        {
            set
            {
                _value = (value & 0x003f) | (_value & 0xffffffc0);
            }
            get
            {
                return _value & 0x003f;
            }
        }
 
        /// <summary>
        /// Minute 6bit
        /// 分 6位
        /// </summary>
        public uint Minute
        {
            set
            {
                _value = ((value & 0x003f) << 6) | (_value & 0xfffff03f);
            }
            get
            {
                return (_value >> 6) & 0x003f;
            }
        }

        /// <summary>
        /// Hour 5bit
        /// 小时 5位
        /// </summary>
        public uint Hour
        {
            set
            {
                _value = ((value & 0x001f) << 12) | (_value & 0xfffe0fff);
            }
            get
            {
                return (_value >> 12) & 0x001f;
            }
        }

        /// <summary>
        /// Day 5bit
        /// 天 5位
        /// </summary>
        public uint Day
        {
            set
            {
                _value = ((value & 0x001f ) << 17) | (_value & 0xffc3ffff);
            }
            get
            {
                return (_value >> 17) & 0x001f;
            }
        }

        /// <summary>
        /// Month 4bit
        /// 月 4位
        /// </summary>
        public uint Month
        {
            set
            {
                _value = ((value & 0x000f ) << 22) | (_value & 0xfc3fffff);
            }
            get
            {
                return (_value >> 22) & 0x000f;
            }
        }

        /// <summary>
        /// Year 6bit 2000-2063
        /// 年 6位 2000-2063
        /// </summary>
        public uint Year
        {
            set
            {
                _value = (((value - 2000) & 0x003f) << 26) | (_value & 0x3ffffff);
            }
            get
            {
                return ((_value >> 26) & 0x003f) + 2000;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}-{1}-{2} {3}:{4}:{5}", Year.ToString("D4"), Month.ToString("D2"), Day.ToString("D2"), Hour.ToString("D2"), Minute.ToString("D2"), Second.ToString("D2"));
        }
    }
	
    /// <summary>
    /// device enable type
    /// 设备支持功能列表
    /// </summary>
	public enum EM_DEV_ENABLE_TYPE
    {
        /// <summary>
        /// FTP bitwise, 1: send out record file;  2: Send out snapshot file
        /// FTP 按位,1：传送录像文件 2：传送抓图文件
        /// </summary>
	    FTP = 0,						                                    
        /// <summary>
        /// SMTP bitwise,1: alarm send out text mail 2: Alarm send out image3:support HealthMail
        /// SMTP 按位,1：报警传送文本邮件 2：报警传送图片 3:支持健康邮件功能
        /// </summary>
	    SMTP,						                                    
        /// <summary>
        /// NTP	 Bitwise:1:Adjust system time 
        /// NTP  按位：1：调整系统时间
        /// </summary>
	    NTP,							                                
        /// <summary>
        /// Auto maintenance  Bitwise:1:reboot 2:close  3:delete file
        /// 自动维护 按位：1：重启 2：关闭 3:删除文件
        /// </summary>
	    AUTO_MAINTAIN,				                                         
        /// <summary>
        /// Privacy mask Bitwise  :1:multiple-window privacy mask
        /// 区域遮挡 按位：1：多区域遮挡
        /// </summary>
	    VIDEO_COVER,					                                      
        /// <summary>
        /// Auto registration	Bitwise:1:SDK auto log in after registration 
        /// 主动注册 按位：1：注册后sdk主动登陆
        /// </summary>
	    AUTO_REGISTER,				                                        
        /// <summary>
        /// DHCP	Bitwise 1:DHCP
        /// DHCP 按位：1：DHCP
        /// </summary>
	    DHCP,						                                     
        /// <summary>
        /// UPNP	Bitwise 1:UPNP
        /// UPNP 按位：1：UPNP
        /// </summary>
	    UPNP,						                                     
        /// <summary>
        /// COM sniffer  Bitwise :1:CommATM
        /// 串口抓包 按位：1:CommATM
        /// </summary>
	    COMM_SNIFFER,				                                        
        /// <summary>
        /// Network sniffer Bitwise : 1:NetSniffer
        /// 网络抓包 按位： 1：NetSniffer
        /// </summary>
	    NET_SNIFFER,					                                  
        /// <summary>
        /// Burn function Bitwise 1:Search burn status 
        /// 刻录功能 按位：1：查询刻录状态
        /// </summary>
	    BURN,						                                       
        /// <summary>
        /// Video matrix Bitwise  1:Support video matrix or not 2:Support SPOT video matrix or not
        /// 视频矩阵 按位：1：是否支持视频矩阵 2:是否支持SPOT视频矩阵 3:是否支持HDMI视频矩阵
        /// </summary>
	    VIDEO_MATRIX,				                                       
        /// <summary>
        /// Video detection Bitwise :1:Support video detection or not 
        /// 音频检测 按位：1：是否支持音频检测
        /// </summary>
	    AUDIO_DETECT,				                                         
        /// <summary>
        /// Storage position Bitwise:1:Ftp server (Ips) 2:SBM 3:NFS 16:DISK 17:Flash disk
        /// 存储位置 按位：1：Ftp服务器(Ips) 2：SMB 3：NFS 4：ISCSI 16：DISK 17：U盘
        /// </summary>
	    STORAGE_STATION,				                                     
        /// <summary>
        /// IPS storage search  Bitwise  1:IPS storage search
        /// IPS存储查询 按位：1：IPS存储查询
        /// </summary>
	    IPSSEARCH,					                                          	
        /// <summary>
        /// Snapshot Bitwise  1:Resoluiton 2:Frame rate 3:Snapshoot  4:Snapshoot file image; 5:Image quality 
        /// 抓图  按位：1：分辨率2：帧率3：抓图方式4：抓图文件格式5：图画质量
        /// </summary>
	    SNAP,						                                       
        /// <summary>
        /// Search default network card search  Bitwise  1:Support
        /// 支持默认网卡查询 按位 1：支持
        /// </summary>
	    DEFAULTNIC,					                                       
        /// <summary>
        /// Image quality configuration time in CBR mode 1:support 
        /// CBR模式下显示画质配置项 按位 1:支持
        /// </summary>
	    SHOWQUALITY,					                                   
        /// <summary>
        /// Configuration import& emport function capacity.  Bitwise   1:support
        /// 配置导入导出功能能力 按位 1:支持
        /// </summary>
	    CONFIG_IMEXPORT,				                                  
        /// <summary>
        /// Support search log page by page or not. Bitwise 1:support 
        /// 是否支持分页方式的日志查询 按位 1：支持
        /// </summary>
	    LOG,							                                  
        /// <summary>
        /// Record setup capacity. Bitwise  1:Redandunce  2:Pre-record 3:Record period
        /// 录像设置的一些能力 按位 1:冗余 2:预录 3:录像时间段
        /// </summary>
	    SCHEDULE,					                                        
        /// <summary>
        /// Network type. Bitwise 1:Wire Network 2:Wireless Network 3:CDMA/GPRS,4:CDMA/GPRS multi network card
        /// 网络类型按位表示 1:以态网 2:无线局域 3:CDMA/GPRS 4:CDMA/GPRS多网卡配置
        /// </summary>
	    NETWORK_TYPE,				                                        
        /// <summary>
        /// Important record. Bitwise 1:Important record mark
        /// 标识重要录像 按位:1：设置重要录像标识
        /// </summary>
	    MARK_IMPORTANTRECORD,		                                        
        /// <summary>
        /// Frame rate control activities. Bitwise 1:support frame rate control activities;2:support timing alarm type activate frame rate control(it does not support dynamic detection), this ability mutually exclusive with ACF ability
        /// 活动帧率控制 按位：1：支持活动帧率控制, 2:支持定时报警类型活动帧率控制(不支持动检),该能力与ACF能力互斥
        /// </summary>
	    ACFCONTROL,					                                        
        /// <summary>
        /// Multiple-channel extra stream. Bitwise:1:support three channel extra stream
        /// 多路辅码流 按位：1：支持三路辅码流, 2:支持辅码流编码压缩格式独立设置
        /// </summary>
	    MULTIASSIOPTION,				                                    
        /// <summary>
        /// Component modules bitwise: 1.Separate processing the schedule 2.Standard I franme Interval setting
        /// 组件化模块 按位：1,时间表分开处理 2:标准I帧间隔设置
        /// </summary>
	    DAVINCIMODULE,				                                       
        /// <summary>
        /// GPS function bitwise:1:Gps locate function
        /// GPS功能 按位：1：Gps定位功能
        /// </summary>
	    GPS,                                                               
        /// <summary>
        /// Support multi net card query   bitwise: 1: support
        /// 支持多网卡查询 按位 1：支持
        /// </summary>
	    MULTIETHERNET,				                                       
        /// <summary>
        /// Login properties   bitwise: 1: support query login properties 
        /// Login属性 按位：1：支持Login属性查询
        /// </summary>
	    LOGIN_ATTRIBUTE,                                                   
        /// <summary>
        /// Recording associated  bitwise: 1:Normal recording; 2:Alarm recording;3:Motion detection recording;  4:Local storage; 5: Network storage ;6:Redundancy storage;  7:Local emergency storage
        /// 录像相关 按位：1,普通录像；2：报警录像；3：动态检测录像；4：本地存储；5：远程存储；6：冗余存储；7：本地紧急存储；8：支持区分主辅码流的远程存储
        /// </summary>
	    RECORD_GENERAL,				                                         					                                        
        /// <summary>
        /// Whether support Json configuration, bitwise: 1: support Json
        /// Json格式配置:按位：1支持Json格式, 2: 使用F6的NAS配置, 3: 使用F6的Raid配置, 4：使用F6的MotionDetect配置, 5：完整支持三代配置(V3),通过F6命令访问
        /// </summary>
	    JSON_CONFIG,					                                 
        /// <summary>
        /// Hide function:bitwise::1,hide PTZ function
        /// 屏蔽功能：按位：1,屏蔽PTZ云台功能, 2: 屏蔽3G的保活时段功能
        /// </summary>
	    HIDE_FUNCTION,				                                     
        /// <summary>
        /// Harddisk damage information support ability: bitwise:1,harddisk damage information
        /// 硬盘坏道信息支持能力: 按位：1,硬盘坏道信息查询支持能力
        /// </summary>
	    DISK_DAMAGE,                                                        
        /// <summary>
        /// Support playback network transmission speed control, bitwise::1 support playback acceleration
        /// 支持回放网传速度控制:按位:1,支持回放加速
        /// </summary>
	    PLAYBACK_SPEED_CTRL,			                                    
        /// <summary>
        /// Support holiday period setup : bitwise:1,Support holiday period setup
        /// 支持假期时间段配置:按位:1,支持假期时间段配置
        /// </summary>
	    HOLIDAYSCHEDULE,				                                   
        /// <summary>
        /// ATM fetch money overtime
        /// ATM取钱超时
        /// </summary>
	    FETCH_MONEY_TIMEOUT,			                                  
        /// <summary>
        /// Device backup support format. DAV, ASF
        /// 备份支持的格式,按位：1:DAV, 2:ASF
        /// </summary>
	    BACKUP_VIDEO_FORMAT,			                                  
        /// <summary>
        /// backup disk type query
        /// 支持硬盘类型查询
        /// </summary>
	    QUERY_DISK_TYPE,                                                   
        /// <summary>
        /// backup device output of display (such as VGA) configuration, by bit: 1: configuration on tour of frame segmentation 
        /// 支持设备显示输出（VGA等）配置,按位: 1:画面分割轮巡配置
        /// </summary>
	    CONFIG_DISPLAY_OUTPUT,                                             
        /// <summary>
        /// backup extra stream control configuration, by bit: 1-extra stream control configuration
        /// 支持扩展码流录像控制设置, 按位：1-辅码流录像控制设置
        /// </summary>
	    SUBBITRATE_RECORD_CTRL,                                            
        /// <summary>
        /// backup IPV6 configuration, by bit:1-IPV6 configuration
        /// 支持IPV6设置, 按位：1-IPV6配置
        /// </summary>
	    IPV6,                                                              
        /// <summary>
        /// SNMP
        /// SNMP（简单网络管理协议）
        /// </summary>
   	    SNMP,                                                              
        /// <summary>
        /// back up query device's URL info, by bit: 1-query device's config URL info
        /// 支持获取设备URL地址, 按位: 1-查询配置URL地址
        /// </summary>
	    QUERY_URL,                                                          
        /// <summary>
        /// ISCSI
        /// ISCSI（Internet小型计算机系统接口配置）
        /// </summary>
	    ISCSI,						                                       
        /// <summary>
        /// Raid
        /// 支持Raid功能
        /// </summary>
	    RAID,						                                       
        /// <summary>
        /// Support disk info query
        /// 支持磁盘信息查询
        /// </summary>
	    HARDDISK_INFO,				                                       
        /// <summary>
        /// support picture in pictu,by bit:1,set; 2,preview , record , query record , download record
        /// 支持画中画功能 按位:1,画中画设置; 2,画中画预览、录像存储、查询、下载;3,支持画中画编码配置,同时支持画中画通道查询
        /// </summary>
	    PICINPIC,                                                          
        /// <summary>
        /// same to EN_PLAYBACK_SPEED_CTRL
        /// 同 EN_PLAYBACK_SPEED_CTRL ,只为了兼容协议
        /// </summary>
	    PLAYBACK_SPEED_CTRL_SUPPORT,                                       
        /// <summary>
        /// support LF-X series of 24, 32, 64 channels, label their encode ability with sepcial calculation, by bit 1: able
        /// 支持24、32、64路LF-X系列,标注这类设备特殊的编码能力计算方式
        /// </summary>
	    LF_XDEV,						                                    
        /// <summary>
        /// support DSP encode
        /// DSP编码能力查询
        /// </summary>
	    DSP_ENCODE_CAP,				                                        
        /// <summary>
        /// support different multicast config for different channel
        /// 组播能力查询
        /// </summary>
	    MULTICAST,                                                           
        /// <summary>
        /// query the limit ability of net, bitwise,1-limit size of net send code stream
        /// 网络限制能力查询,按位,1-网络发送码流大小限制,2-支持用户操作数据加密,4-支持配置数据加密
        /// </summary>
	    NET_LIMIT,   				                                         
        /// <summary>
        /// serial port 422
        /// 串口422
        /// </summary>
	    COM422, 						                                    
        /// <summary>
        /// support three generations of framework agrement or not(need actualize listMethod(),listService()),by F6 to visit
        /// 是否支持三代协议框架（需要实现listMethod(),listService()）,通过F6命令访问
        /// </summary>
	    PROTOCAL_FRAMEWORK,			                                        
        /// <summary>
        /// write disk OSD overlying ,bitwise, 1-write disk OSD overlying configuration
        /// 刻录OSD叠加, 按位, 1-刻录OSD叠加配置
        /// </summary>
	    WRITE_DISK_OSD,				                                        
        /// <summary>
        /// dynamic multi-connect,bitise,1-request reply video data
        /// 动态多连接, 按位, 1-请求视频数据应答
        /// </summary>
	    DYNAMIC_MULTI_CONNECT,		                                        
        /// <summary>
        /// cloud service,bitwise,1- support private cloud service
        /// 云服务,按位,1-支持私有云服务
        /// </summary>
	    CLOUDSERVICE,  				                                         
        /// <summary>
        /// Video Information Report, by bit. 1-Active video information report, 2-Frame numbers inquiry support
        /// 录像信息上报, 按位, 1-录像信息主动上报, 2-支持录像帧数查询
        /// </summary>
	    RECORD_INFO,					                                    
        /// <summary>
        /// Active Register Support, by bit. 1- Dynamic active register support
        /// 主动注册能力,按位,1-支持动态主动注册, 2-主动注册动态多链接支持SDK发起IP,port填0的请求
        /// </summary>
	    DYNAMIC_REG,                                                        
        /// <summary>
        /// Multi-channel Preview and Playback, by bit. 1-Multi-channel preview and playback support
        /// 多通道预览回放,按为,1-支持多通道预览回放
        /// </summary>
	    MULTI_PLAYBACK,                                                    
        /// <summary>
        /// Encoding Channel, by bit. 1- Audio-only channel support
        /// 编码通道, 按位, 1-支持纯音频通道, 2-监视支持音视频分开获取
        /// </summary>
	    ENCODE_CHN,					                                       
        /// <summary>
        /// Record search, by bit, 1-support sync search record, 2-support 3rd generation protocol search record
        /// 录像查询, 按位, 1-支持异步查询录像, 2-支持三代协议查询录像
        /// </summary>
        SEARCH_RECORD,                                                      
        /// <summary>
        /// Support MD5 check after update file send finish，1- support MD5
        /// 支持升级文件传输完成后做MD5验证,1-支持MD5验证2-支持三代升级
        /// </summary>
        UPDATE_MD5,
        /// <summary>
        /// protocol3 to F6, 1-support log 2.restore config by configManager.deleteFile protocol
        /// 三代切F6,按位，1-Log日志功能2.DeleteFile 恢复默认配置支持使用configManager.deleteFile协议 
        /// </summary>
        PROTOCOL3ToF6,                                                     
    }
	
    /// <summary>
    /// log type
    /// 日志类型
    /// </summary>
	public enum EM_LOG_TYPE
    {
        /// <summary>
        /// Device reboot
        /// 设备重启
        /// </summary>
        REBOOT = 0x0000,						                            
        /// <summary>
        /// Shut down device
        /// 设备关机
        /// </summary>
        SHUT,								                                
        /// <summary>
        /// Report stop
        /// 报告停止
        /// </summary>
        REPORTSTOP,                                                         
        /// <summary>
        /// Rreport start
        /// 报告开始
        /// </summary>
        REPORTSTART,                                                        
        /// <summary>
        /// Device Upgrade
        /// 设备升级
        /// </summary>
        UPGRADE = 0x0004,				                                    
        /// <summary>
        /// system time update
        /// 系统时间更新
        /// </summary>
        SYSTIME_UPDATE = 0x0005,                                            
        /// <summary>
        /// GPS time update
        /// GPS时间更新
        /// </summary>
        GPS_TIME_UPDATE = 0x0006,			                                
        /// <summary>
        /// Voice intercom, true representative open, false on behalf of the closed
        /// 语音对讲, true代表开启,false代表关闭
        /// </summary>
        AUDIO_TALKBACK,	  					                                
        /// <summary>
        /// Transparent transmission, true representative open, false on behalf of the closed
        /// 透明传输, true代表开启,false代表关闭
        /// </summary>
        COMM_ADAPTER,						                               
        /// <summary>
        /// Net sync
        /// 网络校时
        /// </summary>
        NET_TIMING,                                                        
        /// <summary>
        /// NR
        /// NR
        /// </summary>
        TYPE_NR,                                                           
        /// <summary>
        /// Save configuration
        /// 保存配置
        /// </summary>
        CONFSAVE = 0x0100,					                               
        /// <summary>
        /// Read configuration 
        /// 读取配置
        /// </summary>
        CONFLOAD,							                               
        /// <summary>
        /// File system error
        /// 文件系统错误
        /// </summary>
        FSERROR = 0x0200,					                               
        /// <summary>
        /// HDD write error 
        /// 硬盘写错误
        /// </summary>
        HDD_WERR,							                               
        /// <summary>
        /// HDD read error
        /// 硬盘读错误
        /// </summary>
        HDD_RERR,							                               
        /// <summary>
        /// Set HDD type 
        /// 设置硬盘类型
        /// </summary>
        HDD_TYPE,							                               
        /// <summary>
        /// Format HDD
        /// 格式化硬盘
        /// </summary>
        HDD_FORMAT,							                               
        /// <summary>
        /// Current working HDD space is not sufficient
        /// 当前工作盘空间不足
        /// </summary>
        HDD_NOSPACE,							                           
        /// <summary>
        /// Set HDD type as read-write 
        /// 设置硬盘类型为读写盘
        /// </summary>
        HDD_TYPE_RW,							                           
        /// <summary>
        /// Set HDD type as read-only
        /// 设置硬盘类型为只读盘
        /// </summary>
        HDD_TYPE_RO,							                           
        /// <summary>
        /// Set HDD type as redundant 
        /// 设置硬盘类型为冗余盘
        /// </summary>
        HDD_TYPE_RE,							                           
        /// <summary>
        /// Set HDD type as snapshot
        /// 设置硬盘类型为快照盘
        /// </summary>
        HDD_TYPE_SS,							                           
        /// <summary>
        /// No HDD
        /// 无硬盘记录
        /// </summary>
        HDD_NONE,							                               
        /// <summary>
        /// No work HDD
        /// 无工作盘
        /// </summary>
        HDD_NOWORKHDD,						                               
        /// <summary>
        /// Set HDD type to backup HDD
        /// 设置硬盘类型为备份盘
        /// </summary>
        HDD_TYPE_BK,							                           
        /// <summary>
        /// Set HDD type to reserve subarea
        /// 设置硬盘类型为保留分区
        /// </summary>
        HDD_TYPE_REVERSE,					                               
        /// <summary>
        /// note the boot-strap's hard disk info
        /// 记录开机时的硬盘信息
        /// </summary>
        HDD_START_INFO = 0x20e,                                            
        /// <summary>
        /// note the disk number after the disk change
        /// 记录换盘后的工作盘号
        /// </summary>
        HDD_WORKING_DISK,                                                  
        /// <summary>
        /// note other errors of disk
        /// 记录硬盘其它错误
        /// </summary>
        HDD_OTHER_ERROR,                                                   
        /// <summary>
        /// there has some little errors on disk
        /// 硬盘存在轻微问题
        /// </summary>
        HDD_SLIGHT_ERR,						                               
        /// <summary>
        /// there has some serious errors on disk
        /// 硬盘存在严重问题
        /// </summary>
        HDD_SERIOUS_ERR,                                                   
        /// <summary>
        /// the end of the alarm that current disk has no space left
        /// 当前工作盘空间不足报警结束
        /// </summary>
        HDD_NOSPACE_END,                                                   
        /// <summary>
        /// Raid control
        /// Raid操作
        /// </summary>
        HDD_TYPE_RAID_CONTROL,                                             
        /// <summary>
        /// excess temperature
        /// 温度过高
        /// </summary>
        HDD_TEMPERATURE_HIGH,				                               
        /// <summary>
        /// lower die temperature
        /// 温度过低
        /// </summary>
        HDD_TEMPERATURE_LOW,					                           
        /// <summary>
        /// remove eSATA
        /// 移除eSATA
        /// </summary>
        HDD_ESATA_REMOVE,					                               
        /// <summary>
        /// External alarm begin 
        /// 外部输入报警开始
        /// </summary>
        ALM_IN = 0x0300,						                           
        /// <summary>
        /// Network alarm input 
        /// 网络报警输入
        /// </summary>
        NETALM_IN,							                               
        /// <summary>
        /// External input alarm stop 
        /// 外部输入报警停止
        /// </summary>
        ALM_END = 0x0302,					                               
        /// <summary>
        /// Video loss alarm begin
        /// 视频丢失报警开始
        /// </summary>
        LOSS_IN,								                           
        /// <summary>
        /// Video loss alarm stop
        /// 视频丢失报警结束
        /// </summary>
        LOSS_END,							                               
        /// <summary>
        /// Motion detection alarm begin
        /// 动态检测报警开始
        /// </summary>
        MOTION_IN,							                               
        /// <summary>
        /// Motion detection alarm stop
        /// 动态检测报警结束
        /// </summary>
        MOTION_END,							                               
        /// <summary>
        /// Annunciator alarm input
        /// 报警器报警输入
        /// </summary>
        ALM_BOSHI,							                               
        /// <summary>
        /// Network disconnected
        /// 网络断开
        /// </summary>
        NET_ABORT = 0x0308,					                               
        /// <summary>
        /// Network connection restore 
        /// 网络恢复
        /// </summary>
        NET_ABORT_RESUME,					                               
        /// <summary>
        /// Encoder error
        /// 编码器故障
        /// </summary>
        CODER_BREAKDOWN,						                           
        /// <summary>
        /// Encoder error restore 
        /// 编码器故障恢复
        /// </summary>
        CODER_BREAKDOWN_RESUME,				                               
        /// <summary>
        /// Camera masking
        /// 视频遮挡
        /// </summary>
        BLIND_IN,							                               
        /// <summary>
        /// Restore camera masking 
        /// 视频遮挡恢复
        /// </summary>
        BLIND_END,							                               
        /// <summary>
        /// High temperature 
        /// 温度过高
        /// </summary>
        ALM_TEMP_HIGH,						                               
        /// <summary>
        /// Low voltage
        /// 电压过低
        /// </summary>
        ALM_VOLTAGE_LOW,						                           
        /// <summary>
        /// Battery capacity is not sufficient 
        /// 电池容量不足
        /// </summary>
        ALM_BATTERY_LOW,						                           
        /// <summary>
        /// ACC power off 
        /// ACC断电
        /// </summary>
        ALM_ACC_BREAK,						                               
        /// <summary>
        /// ACC res
        /// ACC重置
        /// </summary>
        ALM_ACC_RES,                                                       
        /// <summary>
        /// GPS signal lost
        /// GPS无信号
        /// </summary>
        GPS_SIGNAL_LOST,						                           
        /// <summary>
        /// GPS signal resume
        /// GPS信号恢复
        /// </summary>
        GPS_SIGNAL_RESUME,					                               
        /// <summary>
        /// 3G signal lost
        /// 3G无信号
        /// </summary>
        LOG_3G_SIGNAL_LOST,						                           
        /// <summary>
        /// 3G signal resume
        /// 3G信号恢复
        /// </summary>
        LOG_3G_SIGNAL_RESUME,					                           
        /// <summary>
        /// IPC external alarms
        /// IPC外部报警
        /// </summary>
        ALM_IPC_IN,							                               
        /// <summary>
        /// IPC external alarms recovery
        /// IPC外部报警恢复
        /// </summary>
        ALM_IPC_END,							                           
        /// <summary>
        /// Broken network alarm
        /// 断网报警
        /// </summary>
        ALM_DIS_IN,							                               
        /// <summary>
        /// Broken network alarm recovery
        /// 断网报警恢复
        /// </summary>
        ALM_DIS_END,							                           
        /// <summary>
        /// UPS alarm 
        /// UPS告警
        /// </summary>
        ALM_UPS_IN, 				                                       
        /// <summary>
        /// UPS alarm resume 
        /// UPS告警恢复
        /// </summary>
        ALM_UPS_END, 				                                       
        /// <summary>
        /// NAS server abnormal alarm 
        /// NAS服务器异常报警
        /// </summary>
        ALM_NAS_IN,				                                           
        /// <summary>
        /// NAS server abnormal alarm resume 
        /// NAS服务器异常报警恢复
        /// </summary>
        ALM_NAS_END,				                                       
        /// <summary>
        /// Redundant power alarm 
        /// 冗余电源告警
        /// </summary>
        ALM_REDUNDANT_POWER_IN,                                            
        /// <summary>
        /// Redundant alarm resume 
        /// 冗余电源告警恢复
        /// </summary>
        ALM_REDUNDANT_POWER_END,                                           
        /// <summary>
        /// Record failure alarm 
        /// 录像失败告警
        /// </summary>
        ALM_RECORD_FAILED_IN,				                               
        /// <summary>
        /// Record failure alarm resume 
        /// 录像失败告警恢复
        /// </summary>
        ALM_RECORD_FAILED_END,			                                   
        /// <summary>
        /// Storage pool abnormal alarm
        /// 存储池异常报警
        /// </summary>
        ALM_VGEXCEPT_IN,				                                   
        /// <summary>
        /// Storage abnormal alarm resume 
        /// 存储池异常报警恢复
        /// </summary>
        ALM_VGEXCEPT_END,				                                   
	    /// <summary>
        /// Fan alarm starts
        /// 风扇报警开始
	    /// </summary>
        ALM_FANSPEED_IN,			                                       
        /// <summary>
        /// Fan alarm stops 
        /// 风扇报警结束
        /// </summary>
        ALM_FANSPEED_END,			                                       
        /// <summary>
        /// Frame loss alarm starts 
        /// 丢帧报警开始
        /// </summary>
        ALM_DROP_FRAME_IN,			                                       
        /// <summary>
        /// Frame loss alarm stops
        /// 丢帧报警结束
        /// </summary>
        ALM_DROP_FRAME_END,			                                       
        /// <summary>
        /// HDD pre-check tour alarm event log type 
        /// 磁盘预检巡检报警事件日志类型
        /// </summary>
        ALM_DISK_STATE_CHECK,		                                       
        /// <summary>
        /// HDCVI smoke alarm event
        /// 同轴烟感报警事件
        /// </summary>
        ALARM_COAXIAL_SMOKE,		                                       
        /// <summary>
        /// HDCVI temperature alarm event
        /// 同轴温度报警事件
        /// </summary>
        ALARM_COAXIAL_TEMP_HIGH,	                                       
        /// <summary>
        /// HDCVI external alarm event 
        /// 同轴外部报警事件
        /// </summary>
        ALARM_COAXIAL_ALM_IN,		                                       
        /// <summary>
        /// Wireless alarm begin 
        /// 无线报警开始
        /// </summary>
        INFRAREDALM_IN = 0x03a0,				                           
        /// <summary>
        /// Wireless alarm end 
        /// 无线报警结束
        /// </summary>
        INFRAREDALM_END,						                           
        /// <summary>
        /// IP conflict 
        /// IP冲突
        /// </summary>
        IPCONFLICT,							                               
        /// <summary>
        /// IP restore
        /// IP恢复
        /// </summary>
        IPCONFLICT_RESUME,					                               
        /// <summary>
        /// SD Card insert
        /// SD卡插入
        /// </summary>
        SDPLUG_IN,							                               
        /// <summary>
        /// SD Card Pull-out
        /// SD卡拔出
        /// </summary>
        SDPLUG_OUT,							                               
        /// <summary>
        /// Failed to bind port
        /// 网络端口绑定失败
        /// </summary>
        NET_PORT_BIND_FAILED,				                               
        /// <summary>
        /// Hard disk error beep reset 
        /// 硬盘错误报警蜂鸣结束
        /// </summary>
        HDD_BEEP_RESET,                                                    
        /// <summary>
        /// MAC conflict
        /// MAC冲突
        /// </summary>
        MAC_CONFLICT,                                                      
        /// <summary>
        /// MAC conflict resume
        /// MAC冲突恢复
        /// </summary>
        MAC_CONFLICT_RESUME,                                               
        /// <summary>
        /// alarm out
        /// 报警输出状态
        /// </summary>
        ALARM_OUT,							                               
        /// <summary>
        /// RAID state event  
        /// RAID状态变化事件
        /// </summary>
        ALM_RAID_STAT_EVENT,                                               
        /// <summary>
        /// Fire alarm, smoker or high temperature
        /// 火警报警,烟感或温度
        /// </summary>
        ABLAZE_ON,				                                           
        /// <summary>
        /// Fire alarm reset 
        /// 火警报警恢复
        /// </summary>
        ABLAZE_OFF,			                                               
        /// <summary>
        /// Intelligence pulse alarm
        /// 智能脉冲型报警
        /// </summary>
        INTELLI_ALARM_PLUSE,					                           
        /// <summary>
        /// Intelligence alarm start
        /// 智能报警开始
        /// </summary>
        INTELLI_ALARM_IN,					                               
        /// <summary>
        /// Intelligence alarm end
        /// 智能报警结束
        /// </summary>
        INTELLI_ALARM_END,					                               
        /// <summary>
        /// 3G signal scan
        /// 3G信号检测
        /// </summary>
        LOG_3G_SIGNAL_SCAN,						                           
        /// <summary>
        /// GPS signal scan
        /// GPS信号检测
        /// </summary>
        GPS_SIGNAL_SCAN,						                           
        /// <summary>
        /// Auto record
        /// 自动录像
        /// </summary>
        AUTOMATIC_RECORD = 0x0400,			                               
        /// <summary>
        /// Manual record 
        /// 手动录象
        /// </summary>
        MANUAL_RECORD = 0x0401,				                               
        /// <summary>
        /// Stop record
        /// 停止录象
        /// </summary>
        CLOSED_RECORD,						                               
        /// <summary>
        /// Log in
        /// 登录
        /// </summary>
        LOGIN = 0x0500,						                               
        /// <summary>
        /// Log off 
        /// 注销
        /// </summary>
        LOGOUT,								                               
        /// <summary>
        /// Add user
        /// 添加用户
        /// </summary>
        ADD_USER,							                               
        /// <summary>
        /// Delete user
        /// 删除用户
        /// </summary>
        DELETE_USER,							                           
        /// <summary>
        /// Modify user 
        /// 修改用户
        /// </summary>
        MODIFY_USER,							                           
        /// <summary>
        /// Add user group 
        /// 添加用户组
        /// </summary>
        ADD_GROUP,							                               
        /// <summary>
        /// Delete user group 
        /// 删除用户组
        /// </summary>
        DELETE_GROUP,						                               
        /// <summary>
        /// Modify user group 
        /// 修改用户组
        /// </summary>
        MODIFY_GROUP,						                               
        /// <summary>
        /// Network Login
        /// 网络用户登录
        /// </summary>
        NET_LOGIN = 0x0508,					                               
        /// <summary>
        /// Modify password
        /// 修改密码
        /// </summary>
        MODIFY_PASSWORD,						                           
        /// <summary>
        /// Clear log 
        /// 清除日志
        /// </summary>
        CLEAR = 0x0600,						                               
        /// <summary>
        /// Search log 
        /// 查询日志
        /// </summary>
        SEARCHLOG,							                               
        /// <summary>
        /// Search record
        /// 录像查询
        /// </summary>
        SEARCH = 0x0700,						                           
        /// <summary>
        /// Record download
        /// 录像下载
        /// </summary>
        DOWNLOAD,							                               
        /// <summary>
        /// Record playback
        /// 录像回放
        /// </summary>
        PLAYBACK,							                               
        /// <summary>
        /// Backup recorded file 
        /// 备份录像文件
        /// </summary>
        BACKUP,								                               
        /// <summary>
        /// Failed to backup recorded file
        /// 备份录像文件失败
        /// </summary>
        BACKUPERROR,							                           
        /// <summary>
        /// Real-time backup, that is, copy CD
        /// 实时备份,即光盘刻录
        /// </summary>
        BACK_UPRT,							                               
        /// <summary>
        /// CD copy
        /// 光盘复制
        /// </summary>
        BACKUPCLONE,							                           
        /// <summary>
        /// Manual changed
        /// 手动换盘
        /// </summary>
        DISK_CHANGED,						                               
        /// <summary>
        /// Image playback
        /// 图片回放
        /// </summary>
        IMAGEPLAYBACK,						                               
        /// <summary>
        /// Lock the video
        /// 锁定录像
        /// </summary>
        LOCKFILE,							                               
        /// <summary>
        /// Unlock the video
        /// 解锁录像
        /// </summary>
        UNLOCKFILE,							                               
        /// <summary>
        /// Add log superposition of ATM card number
        /// ATM卡号叠加添加日志
        /// </summary>
        ATMPOS,								                               
        /// <summary>
        /// Pause
        /// 暂停回放
        /// </summary>
        PLAY_PAUSE,								                           
        /// <summary>
        /// Start
        /// 正放
        /// </summary>
        PLAY_START,								                           
        /// <summary>
        /// Stop
        /// 停止回放
        /// </summary>
        PLAY_STOP,								                           
        /// <summary>
        /// Back
        /// 倒放
        /// </summary>
        PLAY_BACK,								                           
        /// <summary>
        /// Fast
        /// 快放
        /// </summary>
        PLAY_FAST,								                           
        /// <summary>
        /// Slow
        /// 慢放
        /// </summary>
        PLAY_SLOW,								                           
        /// <summary>
        /// Search
        /// 智能检索
        /// </summary>
        SMART_SEARCH,							                           
        /// <summary>
        /// Snap
        /// 录像抓图
        /// </summary>
        RECORD_SNAP,							                           
        /// <summary>
        /// Add tag
        /// 添加标签
        /// </summary>
        ADD_TAG,								                           
        /// <summary>
        /// Delete tag
        /// 删除标签
        /// </summary>
        DEL_TAG,								                           
        /// <summary>
        /// USB connected
        /// 发现USB设备
        /// </summary>
        USB_IN,									                           
        /// <summary>
        /// USB disconnected
        /// USB设备断开连接
        /// </summary>
        USB_OUT,								                           
        /// <summary>
        /// Backup file
        /// 文件备份
        /// </summary>
        BACKUP_FILE,							                           
        /// <summary>
        /// Backup log
        /// 日志备份
        /// </summary>
        BACKUP_LOG,								                           
        /// <summary>
        /// Backup config
        /// 配置备份
        /// </summary>
        BACKUP_CONFIG,							                           
        /// <summary>
        /// Time update
        /// 时间同步
        /// </summary>
        TIME_UPDATE = 0x0800,                                              
        /// <summary>
        /// remote diary 
        /// 远程日志
        /// </summary>
        REMOTE_STATE = 0x0850,                                             
        /// <summary>
        /// User define
        /// 用户定义
        /// </summary>
        USER_DEFINE = 0x0900,                                              
    } 

    /// <summary>
    /// event type EVENT_IVS_CROSSLINEDETECTION corresponding data block description info
    /// 警戒线事件对应的数据块描述信息
    /// </summary>
	public struct NET_DEV_EVENT_CROSSLINE_INFO
    {
        /// <summary>
        /// ChannelId
        /// 通道号
        /// </summary>
	    public int					        nChannelID;						
        /// <summary>
        /// event name
        /// 事件名称
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr,SizeConst = 128)]
	    public string				        szName;					      
        /// <summary>
        /// byte alignment
        /// 字节对齐
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray,SizeConst = 4)]
	    public byte[]                       bReserved1;                   
        /// <summary>
        /// PTS(ms)
        /// 时间戳(单位是毫秒)
        /// </summary>
	    public double				        PTS;							
        /// <summary>
        /// the event happen time
        /// 事件发生的时间
        /// </summary>
	    public NET_TIME_EX			        UTC;							
        /// <summary>
        /// event ID
        /// 事件ID
        /// </summary>
	    public int					        nEventID;						
        /// <summary>
        /// have being detected object
        /// 检测到的物体
        /// </summary>
	    public NET_MSG_OBJECT		        stuObject;						
        /// <summary>
        /// event file info
        /// 事件对应文件信息
        /// </summary>
	    public NET_EVENT_FILE_INFO          stuFileInfo;                    
        /// <summary>
        /// rule detect line
        /// 规则检测线
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray,SizeConst = 20)]
	    public NET_POINT[]                  DetectLine;                     
        /// <summary>
        /// rule detect line's point number
        /// 规则检测线顶点数
        /// </summary>
	    public int                          nDetectLineNum;                 
        /// <summary>
        /// object moveing track
        /// 物体运动轨迹
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray,SizeConst = 20)]
	    public NET_POINT[]                  TrackLine;                      
        /// <summary>
        /// object moveing track's point number
        /// 物体运动轨迹顶点数
        /// </summary>
	    public int                          nTrackLineNum;                  
        /// <summary>
        /// Event action,0 means pulse event,1 means continuous event's begin,2means continuous event's end
        /// 事件动作,0表示脉冲事件,1表示持续性事件开始,2表示持续性事件结束
        /// </summary>
	    public byte                         bEventAction;                   
        /// <summary>
        /// direction, 0-left to right, 1-right to left
        /// 表示入侵方向, 0-由左至右, 1-由右至左
        /// </summary>
	    public byte                         bDirection;                     
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray,SizeConst = 1)]
	    public byte[]                       byReserved;
        /// <summary>
        /// Serial number of the picture, in the same time (accurate to seconds) may have multiple images, starting from 0
        /// 图片的序号, 同一时间内(精确到秒)可能有多张图片, 从0开始
        /// </summary>
	    public byte				            byImageIndex;					
        /// <summary>
        /// flag(by bit),see NET_RESERVED_COMMON
        /// 抓图标志(按位),具体见NET_RESERVED_COMMON
        /// </summary>
	    public uint                         dwSnapFlagMask;	                
        /// <summary>
        /// the source device's index,-1 means data in invalid
        /// 事件源设备上的index,-1表示数据无效,-1表示数据无效
        /// </summary>
	    public int                          nSourceIndex;                    
        /// <summary>
        /// the source device's sign(exclusive),field said local device does not exist or is empty
        /// 事件源设备唯一标识,字段不存在或者为空表示本地设备
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr,SizeConst = 260)]
	    public string                       szSourceDevice;                 
        /// <summary>
        /// event trigger accumulated times
        /// 事件触发累计次数
        /// </summary>
        public uint                         nOccurrenceCount;               
        /// <summary>
        /// intelli comm info
        /// 智能事件公共信息
        /// </summary>
        public NET_EVENT_INTELLI_COMM_INFO  stuIntelliCommInfo;             
        /// <summary>
        /// reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray,SizeConst = 476)]
        public byte[]                       bReserved;	                     
    } 
	
    /// <summary>
    /// event type EVENT_IVS_CROSSREGIONDETECTION corresponding data block description info
    /// 警戒区事件对应的数据块描述信息
    /// </summary>
	public struct NET_DEV_EVENT_CROSSREGION_INFO
    {
        /// <summary>
        /// ChannelId
        /// 通道号
        /// </summary>
        public int					        nChannelID;						
        /// <summary>
        /// event name
        /// 事件名称
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr,SizeConst = 128)]
	    public string				        szName;					        
        /// <summary>
        /// byte alignment
        /// 字节对齐
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray,SizeConst = 4)]
	    public byte[]                       bReserved2;                     
        /// <summary>
        /// PTS(ms)
        /// 时间戳(单位是毫秒)
        /// </summary>
	    public double				        PTS;							
        /// <summary>
        /// the event happen time
        /// 事件发生的时间
        /// </summary>
	    public NET_TIME_EX			        UTC;							
        /// <summary>
        /// event ID
        /// 事件ID
        /// </summary>
	    public int					        nEventID;						
        /// <summary>
        /// have being detected object
        /// 检测到的物体
        /// </summary>
	    public NET_MSG_OBJECT		        stuObject;						
        /// <summary>
        /// event file info
        /// 事件对应文件信息
        /// </summary>
	    public NET_EVENT_FILE_INFO          stuFileInfo;                    
        /// <summary>
        /// rule detect region
        /// 规则检测区域
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray,SizeConst = 20)]
	    public NET_POINT[]                  DetectRegion;                   
        /// <summary>
        /// rule detect region's point number
        /// 规则检测区域顶点数
        /// </summary>
	    public int                          nDetectRegionNum;               
        /// <summary>
        /// object moving track
        /// 物体运动轨迹
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray,SizeConst = 20)]
	    public NET_POINT[]                  TrackLine;                      
        /// <summary>
        /// object moving track's point number
        /// 物体运动轨迹顶点数
        /// </summary>
	    public int                          nTrackLineNum;                  
        /// <summary>
        /// Event action,0 means pulse event,1 means continuous event's begin,2means continuous event's end
        /// 事件动作,0表示脉冲事件,1表示持续性事件开始,2表示持续性事件结束
        /// </summary>
	    public byte                         bEventAction;                   
        /// <summary>
        /// direction, 0-in, 1-out,2-apaer,3-leave
        /// 表示入侵方向, 0-进入, 1-离开,2-出现,3-消失
        /// </summary>
	    public byte                         bDirection;                     
        /// <summary>
        /// action type,0-appear 1-disappear 2-in area 3-cross area
        /// 表示检测动作类型,0-出现 1-消失 2-在区域内 3-穿越区域
        /// </summary>
	    public byte                         bActionType;                    
        /// <summary>
        /// Serial number of the picture, in the same time (accurate to seconds) may have multiple images, starting from 0
        /// 图片的序号, 同一时间内(精确到秒)可能有多张图片, 从0开始
        /// </summary>
	    public byte				            byImageIndex;					
        /// <summary>
        /// flag(by bit),see NET_RESERVED_COMMON
        /// 抓图标志(按位),具体见NET_RESERVED_COMMON  
        /// </summary>
        public uint                         dwSnapFlagMask;	               
        /// <summary>
        /// the source device's index,-1 means data in invalid
        /// 事件源设备上的index,-1表示数据无效
        /// </summary>
	    public int                          nSourceIndex;                  
        /// <summary>
        /// the source device's sign(exclusive),field said local device does not exist or is empty
        /// 事件源设备唯一标识,字段不存在或者为空表示本地设备
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr,SizeConst = 260)]
	    public string                       szSourceDevice;                 
        /// <summary>
        /// event trigger times
        /// 事件触发累计次数
        /// </summary>
        public uint                         nOccurrenceCount;               
        /// <summary>
        /// reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray,SizeConst = 536)]
	    public byte[]				        bReserved;					    
        /// <summary>
        /// Detect object amount
        /// 检测到的物体个数
        /// </summary>
	    public int                          nObjectNum;                     
        /// <summary>
        /// Detected object
        /// 检测到的物体
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray,SizeConst = 16)]
	    public NET_MSG_OBJECT[]		        stuObjectIDs;                   
        /// <summary>
        /// Locus amount(Corresponding to the detected object amount.)
        /// 轨迹数(与检测到的物体个数对应)
        /// </summary>
	    public int                          nTrackNum;                      
        /// <summary>
        /// Locus info(Corresponding to the detected object)
        /// 轨迹信息(与检测到的物体对应)
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray,SizeConst = 16)]
	    public NET_POLY_POINTS[]            stuTrackInfo;                   
        /// <summary>
        /// intelli comm info
        /// 智能事件公共信息
        /// </summary>
	    public NET_EVENT_INTELLI_COMM_INFO  stuIntelliCommInfo;             
    } 
	
    /// <summary>
    /// poly point information
    /// 区域或曲线顶点信息
    /// </summary>
	public struct NET_POLY_POINTS
    {
        /// <summary>
        /// point number
        /// 顶点数
        /// </summary>
	    public int                          nPointNum;                     
        /// <summary>
        /// point info
        /// 顶点信息
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray,SizeConst = 20)]
	    public NET_POINT[]                  stuPoints;                     
    }
	
    #region HARD DISK
    /// <summary>
    /// hard disk's basic information
    /// 硬盘的基本信息
    /// </summary>
    public struct NET_DEV_DEVICE_INFO
    {
        /// <summary>
        /// model
        /// 型号
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
    	public string              byModle;				   
        /// <summary>
        /// serial number
        /// 序列号
        /// </summary>
    	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string              bySerialNumber;			
        /// <summary>
        /// firmware no
        /// 固件号
        /// </summary>
    	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string              byFirmWare;				
        /// <summary>
        /// ATA protocol version no.
        /// ATA协议版本号
        /// </summary>
    	public int                 nAtaVersion;				
        /// <summary>
        /// smart information no.
        /// smart 信息数
        /// </summary>
    	public int                 nSmartNum ;				
        /// <summary>
        /// sectors
        /// 扇区
        /// </summary>
    	public long                Sectors;	
        /// <summary>
        /// disk state 0-normal 1-abnormal
        /// 磁盘状态 0-正常 1-异常
        /// </summary>
    	public int                 nStatus;				
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
    	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)]
        public int[]               nReserved; 
    } 
    
    /// <summary>
    /// smart information of harddisk, there may be many items up to more than 30
    /// 硬盘的smart信息,可能会有很多条,最多不超过30个
    /// </summary>
    public struct NET_DEV_SMART_VALUE
    {
        /// <summary>
        /// ID
        /// ID
        /// </summary>
    	public byte				    byId;					
        /// <summary>
        /// attribute values
        /// 属性值
        /// </summary>
    	public byte				    byCurrent;				
        /// <summary>
        /// maximum error value 
        /// 最大出错值
        /// </summary>
    	public byte				    byWorst;				
        /// <summary>
        /// threshold value 
        /// 阈值
        /// </summary>
    	public byte				    byThreshold;			
        /// <summary>
        /// property name
        /// 属性名
        /// </summary>
    	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string				szName;					
        /// <summary>
        /// actual value
        /// 实际值
        /// </summary>
    	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
        public string				szRaw;					
        /// <summary>
        /// state
        /// 状态
        /// </summary>
    	public int					nPredict;				
        /// <summary>
        /// reserved
        /// 保留
        /// </summary>
    	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[]				reserved;
    } 
    
    /// <summary>
    /// search hard disk smart information
    /// 硬盘smart信息查询
    /// </summary>
    public struct NET_DEV_SMART_HARDDISK
    {
        /// <summary>
        /// disk number
        /// 硬盘号
        /// </summary>
    	public byte                nDiskNum;                
        /// <summary>
        /// Raid sub disk, 0:single disk
        /// Raid子盘,0表示单盘
        /// </summary>
    	public byte                byRaidNO;                
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
    	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[]              byReserved;  
        /// <summary>
        /// device information
        /// 设备信息
        /// </summary>
    	public NET_DEV_DEVICE_INFO      deviceInfo;    
        /// <summary>
        /// smart information
        /// 硬盘smart信息
        /// </summary>
    	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
        public NET_DEV_SMART_VALUE[]    smartValue;
    } 
    #endregion
    #region <<Access Control>>

    /// <summary>
    /// Entrance Guard Record Information
    /// 门禁卡记录集信息
    /// </summary>
    public struct NET_RECORDSET_ACCESS_CTL_CARD
    {
        /// <summary>
        /// struct size
        /// 结构体大小
        /// </summary>
        public UInt32                                   dwSize;
        /// <summary>
        /// Record Number,Read-Only
        /// 记录集编号,只读
        /// </summary>
        public Int32                                    nRecNo;             
        /// <summary>
        /// Creat Time
        /// 创建时间
        /// </summary>
        public NET_TIME                                 stuCreateTime;      
        /// <summary>
        /// Card number
        /// 卡号
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[]                                   szCardNo;           
        /// <summary>
        /// User's ID
        /// 用户ID, 设备暂不支持
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[]                                   szUserID;           
        /// <summary>
        /// Card Stetue
        /// 卡状态
        /// </summary>
        public EM_ACCESSCTLCARD_STATE                   emStatus;           
        /// <summary>
        /// Card Type
        /// 卡类型
        /// </summary>
        public EM_ACCESSCTLCARD_TYPE                    emType;             
        /// <summary>
        /// Card Password
        /// 卡密码
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[]                                   szPsw;              
        /// <summary>
        /// Valid Door Number
        /// 有效的门数目
        /// </summary>
        public Int32                                    nDoorNum;           
        /// <summary>
        /// Privileged Door Number,That is CFG_CMD_ACCESS_EVENT Configure Array Subscript
        /// 有权限的门序号,即CFG_CMD_ACCESS_EVENT配置的数组下标
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public Int32[]                                  sznDoors;          
        /// <summary>
        /// the Number of Effective Open Time
        /// 有效的的开门时间段数目
        /// </summary>
        public Int32                                    nTimeSectionNum;   
        /// <summary>
        /// Open Time Segment Index,That is CFG_ACCESS_TIMESCHEDULE_INFO Array subscript
        /// 开门时间段索引,即CFG_ACCESS_TIMESCHEDULE_INFO的数组下标
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public Int32[]                                  sznTimeSectionNo;  
        /// <summary>
        /// Frequency of Use
        /// 使用次数,仅当来宾卡时有效
        /// </summary>
        public Int32                                    nUserTime;         
        /// <summary>
        /// Valid Start Time 
        /// 开始有效期, 设备暂不支持时分秒
        /// </summary>
        public NET_TIME                                 stuValidStartTime; 
        /// <summary>
        /// Valid End Time
        /// 结束有效期, 设备暂不支持时分秒
        /// </summary>
        public NET_TIME                                 stuValidEndTime;   
        /// <summary>
        /// Wether Valid,True =Valid,False=Invalid
        /// 是否有效,TRUE有效;FALSE无效
        /// </summary>
        public bool                                     bIsValid;          
        /// <summary>
        /// fingerprint data info (send only), DEPRECATED! use stuFingerPrintInfoEx instead
        /// 下发指纹数据信息，仅为兼容性保留，请使用 stuFingerPrintInfoEx
        /// </summary>
        public NET_ACCESSCTLCARD_FINGERPRINT_PACKET     stuFingerPrintInfo;
        /// <summary>
        /// has first card or not
        /// 是否拥有首卡权限
        /// </summary>
        public Int32                                    bFirstEnter;       
        /// <summary>
        /// card naming
        /// 卡命名
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[]                                   szCardName;        
        /// <summary>
        /// VTO link position
        /// 门口机关联位置
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[]                                   szVTOPosition;     
        /// <summary>
        /// Card for handicap, TRUE:yes, FALSE:no
        /// 是否为残疾人卡
        /// </summary>
        public Int32                                    bHandicap;         
        /// <summary>
        /// Enabled member stuFingerPrintInfoEx
        /// 启用成员 stuFingerPrintInfoEx
        /// </summary>
        public Int32                                    bEnableExtended;   
        /// <summary>
        /// fingerprint data info structure
        /// 指纹数据信息
        /// </summary>
        public NET_ACCESSCTLCARD_FINGERPRINT_PACKET_EX  stuFingerPrintInfoEx;  
    }

    /// <summary>
    /// fingerprint data, for sending only
    /// 指纹数据，只用于下发信息
    /// </summary>
    public struct NET_ACCESSCTLCARD_FINGERPRINT_PACKET
    {
        /// <summary>
        /// struct size
        /// 结构体大小
        /// </summary>
        public UInt32                                   dwSize;
        /// <summary>
        /// length of a finger print packet, unit: byte
        /// 单个数据包长度,单位字节
        /// </summary>
        public Int32                                    nLength;            
        /// <summary>
        /// packet count 
        /// 包个数
        /// </summary>
        public Int32                                    nCount;             
        /// <summary>
        /// all fingerprint packet in a single buffer, allocated and filled by user, nLength*nCount bytes
        /// 所有指纹数据包，用户申请内存并填充，长度为 nLength*nCount
        /// </summary>
        public IntPtr                                   pPacketData;        
    }

    /// <summary>
    /// fingerprint data, for sending and receiving
    /// 指纹数据扩展，可用于下发和获取信息
    /// </summary>
    public struct NET_ACCESSCTLCARD_FINGERPRINT_PACKET_EX
    {
        /// <summary>
        /// length of a finger print packet, unit: byte
        /// 单个数据包长度,单位字节
        /// </summary>
        public Int32                                    nLength;           
        /// <summary>
        /// packet count 
        /// 包个数
        /// </summary>
        public Int32                                    nCount;            
        /// <summary>
        /// all fingerprint packet in a single buffer, allocated by user
        /// 所有指纹数据包, 用户申请内存,大小至少为nLength * nCount
        /// </summary>
        public IntPtr                                   pPacketData;       
        /// <summary>
        /// pPacketData buffer length, set by user
        /// 指向内存区的大小，用户填写
        /// </summary>
        public Int32                                    nPacketLen;        
        /// <summary>
        /// The actual fingerprint size returned to the user, equal to nLength*nCount
        /// 返回给用户实际指纹总大小
        /// </summary>
        public Int32                                    nRealPacketLen;     
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
        public byte[]                                   byReverseed;        
    }

    /// <summary>
    /// Entrance Guard Event
    /// 门禁事件
    /// </summary>
    public struct NET_ALARM_ACCESS_CTL_EVENT_INFO
    {
        /// <summary>
        /// struct size
        /// 结构体大小
        /// </summary>
        public UInt32                                   dwSize;
        /// <summary>
        /// Door Channel Number  
        /// 门通道号
        /// </summary>
        public Int32                                    nDoor;               
        /// <summary>
        /// Entrance Guard Name
        /// 门禁名称
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[]                                   szDoorName;         
        /// <summary>
        /// Alarm Event Triggered Time
        /// 报警事件发生的时间
        /// </summary>
        public NET_TIME                                 stuTime;            
        /// <summary>
        /// Entrance Guard Event Type
        /// 门禁事件类型
        /// </summary>
        public EM_ACCESS_CTL_EVENT_TYPE                 emEventType;        
        /// <summary>
        /// Swing Card Result,True is Success,False is Fail
        /// 刷卡结果,TRUE表示成功,FALSE表示失败
        /// </summary>
        public Int32                                    bStatus;            
        /// <summary>
        /// Card Type
        /// 卡类型
        /// </summary>
        public EM_ACCESSCTLCARD_TYPE                    emCardType;         
        /// <summary>
        /// Open The Door Method
        /// 开门方式
        /// </summary>
        public EM_ACCESS_DOOROPEN_METHOD                emOpenMethod;       
        /// <summary>
        /// Card Number
        /// 卡号
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[]                                   szCardNo;           
        /// <summary>
        /// Password
        /// 密码
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[]                                   szPwd;              
        /// <summary>
        /// Reader ID
        /// 门读卡器ID
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[]                                   szReaderID;         
        /// <summary>
        /// unlock user
        /// 开门用户
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[]                                   szUserID;           
        /// <summary>
        /// snapshot picture storage address
        /// 抓拍照片存储地址
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[]                                   szSnapURL;          
        /// <summary>
        /// Reason of unlock failure, only because it is valid when bStatus is FALSE:0x00 no error,0x10 unauthorized,0x11 card lost or cancelled,0x12 no door right,0x13 unlock mode error,0x14 valid period error,0x15 anti sneak into mode
        /// 0x16 forced alarm not unlocked,0x17 door NC status,0x18 AB lock status,0x19 patrol card,0x1A device is under intrusion alarm status,0x20 period error,0x21 unlock period error in holiday period,0x30 first card right check required,0x40 card correct, input password error
        /// 0x41 card correct, input password timed out,0x42 card correct, input fingerprint error,0x43 card correct, input fingerprint timed out,0x44 fingerprint correct, input password error,0x45 fingerprint correct, input password timed out,0x50 group unlock sequence error,0x51 test required for group unlock,0x60 test passed, control unauthorized
        /// 开门失败的原因,仅在bStatus为FALSE时有效：0x00 没有错误，0x10 未授权，0x11 卡挂失或注销，0x12 没有该门权限，0x13 开门模式错误，0x14 有效期错误，0x15 防反潜模式，0x16 胁迫报警未打开，0x17 门常闭状态，0x18 AB互锁状态，0x19 巡逻卡，0x1A 设备处于闯入报警状态，0x20 时间段错误
        /// 0x21 假期内开门时间段错误，0x30 需要先验证有首卡权限的卡片，0x40 卡片正确,输入密码错误，0x41 卡片正确,输入密码超时，0x42 卡片正确,输入指纹错误，0x43 卡片正确,输入指纹超时，0x44 指纹正确,输入密码错误，0x45 指纹正确,输入密码超时，0x50 组合开门顺序错误，0x51 组合开门需要继续验证，0x60 验证通过,控制台未授权
        /// </summary>
        public Int32                                    nErrorCode;          
        /// <summary>
        /// punching record number
        /// 刷卡记录集中的记录编号
        /// </summary>
        public Int32                                    nPunchingRecNo;      
    }

    /// <summary>
    /// Access control status event
    /// 门禁状态事件
    /// </summary>
    public struct NET_ALARM_ACCESS_CTL_STATUS_INFO
    {
        /// <summary>
        /// struct size
        /// 结构体大小
        /// </summary>
        public UInt32                                   dwSize;
        /// <summary>
        /// Door channel no.
        /// 门通道号
        /// </summary>
        public int                                      nDoor;             
        /// <summary>
        /// Event time
        /// 事件发生的时间
        /// </summary>
        public NET_TIME                                 stuTime;           
        /// <summary>
        /// Access control status
        /// 门禁状态
        /// </summary>
        public EM_ACCESS_CTL_STATUS_TYPE                emStatus;          
    };

    /// <summary>
    /// Record New Operation (Insert)Parameter
    /// 记录集新增操作(插入)参数
    /// </summary>
    public struct NET_CTRL_RECORDSET_INSERT_PARAM
    {
        /// <summary>
        /// struct size
        /// 结构体大小
        /// </summary>
        public UInt32                                   dwSize;
        /// <summary>
        /// Record Information(User Write)
        /// 记录集信息(用户填写)
        /// </summary>
        public NET_CTRL_RECORDSET_INSERT_IN             stuCtrlRecordSetInfo;     
        /// <summary>
        /// Record Information(the Device Come Back)
        /// 记录集信息(设备返回)
        /// </summary>
        public NET_CTRL_RECORDSET_INSERT_OUT            stuCtrlRecordSetResult;   
    }

    /// <summary>
    /// New Record Set Operation(Insert)Parameter
    /// 记录集新增操作(插入)输入参数
    /// </summary>
    public struct NET_CTRL_RECORDSET_INSERT_IN
    {
        /// <summary>
        /// struct size
        /// 结构体大小
        /// </summary>
        public UInt32                                   dwSize;
        /// <summary>
        /// Record Information Type
        /// 记录集信息类型
        /// </summary>
        public EM_NET_RECORD_TYPE                       emType;             
        /// <summary>
        /// Record Information Cache,The EM_NET_RECORD_TYPE Note is Details
        /// 记录集信息缓存,详见EM_NET_RECORD_TYPE注释，由用户申请内存
        /// </summary>
        public IntPtr                                   pBuf;               
        /// <summary>
        /// Record Information Cache Size
        /// 记录集信息缓存大小,大小参照记录集信息类型对应的结构体
        /// </summary>
        public Int32                                    nBufLen;            
    }

    /// <summary>
    /// Record New Operation(Insert) Parameter
    /// 记录集新增操作(插入)输出参数
    /// </summary>
    public struct NET_CTRL_RECORDSET_INSERT_OUT
    {
        /// <summary>
        /// struct size
        /// 结构体大小
        /// </summary>
        public UInt32                                   dwSize;
        /// <summary>
        /// Record Number(The Device Come Back When New Insert )
        /// 记录编号(新增插入时设备返回)
        /// </summary>
        public Int32                                    nRecNo;             
    }

    /// <summary>
    /// Entrance Guard Control Ability
    /// 门禁控制能力
    /// </summary>
    public struct CFG_CAP_ACCESSCONTROL
    {
        /// <summary>
        /// Class Number of Entrance Guard
        /// 门禁组数
        /// </summary>
        public Int32                                    nAccessControlGroups;   
    }

    /// <summary>
    /// Record Operation Parameter
    /// 记录集操作参数
    /// </summary>
    public struct NET_CTRL_RECORDSET_PARAM
    {
        /// <summary>
        /// struct size
        /// 结构体大小
        /// </summary>
        public uint                                     dwSize;
        /// <summary>
        /// Record Information Type
        /// 记录集信息类型
        /// </summary>
        public EM_NET_RECORD_TYPE                       emType;            
        /// <summary>
        /// New/Renew/Inquire,It is Record Information Cache,the EM_NET_RECORD_TYPE Note is Details),Delete,It is Record Number(Int type)
        /// 新增\更新\查询\导入时,为记录集信息缓存,详见EM_NET_RECORD_TYPE注释,由用户申请内存，长度为nBufLen,删除时,为记录编号(int型)
        /// </summary>
        public IntPtr                                   pBuf;               
        /// <summary>
        /// Record Information Cache Size
        /// 记录集信息缓存大小,大小参照记录集信息类型对应的结构体
        /// </summary>
        public int                                      nBufLen;    
    }

    /// <summary>
    /// Card Status
    /// 卡状态
    /// </summary>
    public enum EM_ACCESSCTLCARD_STATE
    {
        /// <summary>
        /// Unknow
        /// 未知
        /// </summary>
        UNKNOWN                                         = -1,
        /// <summary>
        /// Normal
        /// 正常
        /// </summary>
        NORMAL                                          = 0,                
        /// <summary>
        /// Lose
        /// 挂失
        /// </summary>
        LOSE                                            = 0x01,             
        /// <summary>
        /// Logoff
        /// 注销
        /// </summary>
        LOGOFF                                          = 0x02,             
        /// <summary>
        /// Freeze
        /// 冻结
        /// </summary>
        FREEZE                                          = 0x04,             
        /// <summary>
        /// Arrears
        /// 欠费
        /// </summary>
        ARREARAGE                                       = 0x08,             
        /// <summary>
        /// Overdue
        /// 逾期
        /// </summary>
        OVERDUE                                         = 0x10,             
        /// <summary>
        /// Pre-Arrears(still can open the door)
        /// 预欠费(还是可以开门,但有语音提示)
        /// </summary>
        PREARREARAGE                                    = 0x20,             
    }

    /// <summary>
    /// Card Type
    /// 卡类型
    /// </summary>
    public enum EM_ACCESSCTLCARD_TYPE
    {
        /// <summary>
        /// unknow
        /// 未知
        /// </summary>
        UNKNOWN = -1,
        /// <summary>
        /// General Card
        /// 一般卡
        /// </summary>
        GENERAL,                                        
        /// <summary>
        /// VIP Card
        /// VIP卡
        /// </summary>
        VIP,                                            
        /// <summary>
        /// Guest Card
        /// 来宾卡
        /// </summary>
        GUEST,                                          
        /// <summary>
        /// Patrol Card
        /// 巡逻卡
        /// </summary>
        PATROL,                                         
        /// <summary>
        /// Blacklist Card
        /// 黑名单卡
        /// </summary>
        BLACKLIST,                                      
        /// <summary>
        /// Corce Card
        /// 胁迫卡
        /// </summary>
        CORCE,                                          
        /// <summary>
        /// Polling Card
        /// 巡检卡
        /// </summary>
        POLLING,                                        
        /// <summary>
        /// Mother Card
        /// 母卡
        /// </summary>
        MOTHERCARD = 0xff,                              
    }

    /// <summary>
    /// Entrance Guard Event Type
    /// 门禁事件类型
    /// </summary>
    public enum EM_ACCESS_CTL_EVENT_TYPE
    {
        /// <summary>
        /// Unknow
        /// 未知
        /// </summary>
        UNKNOWN = 0,
        /// <summary>
        /// Get In
        /// 进门
        /// </summary>
        ENTRY,                                         
        /// <summary>
        /// Get Out
        /// 出门
        /// </summary>
        EXIT,                                          
    }

    /// <summary>
    /// Door Open Method(Entrance Guard Event,Entrance Guard get In/Out Record，Actual Open Door Method)
    /// 开门方式(门禁事件,门禁出入记录,实际的开门方式)
    /// </summary>
    public enum EM_ACCESS_DOOROPEN_METHOD
    {
        /// <summary>
        /// Unknow
        /// 未知
        /// </summary>
        UNKNOWN = 0,
        /// <summary>
        /// Password
        /// 密码开锁
        /// </summary>
        PWD_ONLY,                                      
        /// <summary>
        /// Card
        /// 刷卡开锁
        /// </summary>
        CARD,                                          
        /// <summary>
        /// First Card Then Password
        /// 先刷卡后密码开锁
        /// </summary>
        CARD_FIRST,                                    
        /// <summary>
        /// First Password Then Card 
        /// 先密码后刷卡开锁
        /// </summary>
        PWD_FIRST,                                     
        /// <summary>
        /// Long-Range Open,Such as Through theIndoor Unit or Unlock the Door Machine Platform
        /// 远程开锁,如通过室内机或者平台对门口机开锁
        /// </summary>
        REMOTE,                                       
        /// <summary>
        /// Open Door Button
        /// 开锁按钮进行开锁
        /// </summary>
        BUTTON,                                       
        /// <summary>
        /// fingerprint lock
        /// 指纹开锁
        /// </summary>
        FINGERPRINT,                                  
        /// <summary>
        /// password+swipe card+fingerprint combination unlock
        /// 密码+刷卡+指纹组合开锁
        /// </summary>
        PWD_CARD_FINGERPRINT,                           
        /// <summary>
        /// password+fingerprint combination unlock
        /// 密码+指纹组合开锁
        /// </summary>
        PWD_FINGERPRINT = 10,                           
        /// <summary>
        /// swipe card+fingerprint combination unlock
        /// 刷卡+指纹组合开锁
        /// </summary>
        CARD_FINGERPRINT = 11,                          
        /// <summary>
        /// multi-people unlock
        /// 多人开锁
        /// </summary>
        PERSONS = 12,                                   
        /// <summary>
        /// Key
        /// 钥匙开门
        /// </summary>
        KEY = 13,                                       
        /// <summary>
        /// Use force password to open the door 
        /// 胁迫密码开门
        /// </summary>
        COERCE_PWD = 14,
        /// <summary>
        /// face recogniton to open the door
        /// 人脸识别开门
        /// </summary>
        FACE_RECOGNITION = 16,                
    }

    /// <summary>
    /// record type
    /// 记录类型
    /// </summary>
    public enum EM_NET_RECORD_TYPE
    {
        /// <summary>
        /// Unknow
        /// 未知
        /// </summary>
        UNKNOWN,
        /// <summary>
        /// Traffic white list account record.search criteria corresponding to FIND_RECORD_TRAFFICREDLIST_CONDITION structure,record info corresponding to NET_TRAFFIC_LIST_RECORD structure
        /// 交通白名单账户记录.查询条件对应 FIND_RECORD_TRAFFICREDLIST_CONDITION 结构体,记录信息对应 NET_TRAFFIC_LIST_RECORD 结构体
        /// </summary>
        TRAFFICREDLIST,                                  
        /// <summary>
        /// Traffic black list account record.search criteria corresponding to FIND_RECORD_TRAFFICREDLIST_CONDITION structure,record info corresponding to NET_TRAFFIC_LIST_RECORD structure
        /// 交通白名单账户记录.查询条件对应 FIND_RECORD_TRAFFICREDLIST_CONDITION 结构体,记录信息对应 NET_TRAFFIC_LIST_RECORD 结构体
        /// </summary>
        TRAFFICBLACKLIST,                                
        /// <summary>
        /// burning case record.search criteria corresponding to FIND_RECORD_BURN_CASE_CONDITION structure,record info corresponding to NET_BURN_CASE_INFO structure 
        /// 刻录案件记录.查询条件对应 FIND_RECORD_BURN_CASE_CONDITION 结构体,记录信息对应 NET_BURN_CASE_INFO 结构体
        /// </summary>                                         
        BURN_CASE,                                       
        /// <summary>
        /// access control card,search criteria corresponding to FIND_RECORD_ACCESSCTLCARD_CONDITION structure,record info corresponding to NET_RECORDSET_ACCESS_CTL_CARD structure
        /// 门禁卡.查询条件对应 FIND_RECORD_ACCESSCTLCARD_CONDITION 结构体,记录信息对应 NET_RECORDSET_ACCESS_CTL_CARD 结构体
        /// </summary>
        ACCESSCTLCARD,                                   
        /// <summary>
        /// access control password.search criteria corresponding to FIND_RECORD_ACCESSCTLPWD_CONDITION structure,record info corresponding to NET_RECORDSET_ACCESS_CTL_PWD
        /// 门禁密码.查询条件对应 FIND_RECORD_ACCESSCTLPWD_CONDITION 结构体,记录信息对应 NET_RECORDSET_ACCESS_CTL_PWD
        /// </summary>          
        ACCESSCTLPWD,
        /// <summary>
        /// access control in/out record.search criteria corresponding to FIND_RECORD_ACCESSCTLCARDREC_CONDITION structure,record info corresponding to
        /// 门禁出入记录（必须同时按卡号和时间段查询,建议用NET_RECORD_ACCESSCTLCARDREC_EX查询.查询条件对应 FIND_RECORD_ACCESSCTLCARDREC_CONDITION 结构体,记录信息对应 NET_RECORDSET_ACCESS_CTL_CARDREC 结构体
        /// </summary>                                                               
        ACCESSCTLCARDREC,                             
        /// <summary>
        /// holiday record set.search criteria corresponding to FIND_RECORD_ACCESSCTLHOLIDAY_CONDITION structure,record info corresponding to NET_RECORDSET_HOLIDAY
        /// 假日记录集.查询条件对应 FIND_RECORD_ACCESSCTLHOLIDAY_CONDITION 结构体,记录信息对应 NET_RECORDSET_HOLIDAY 结构体
        /// </summary>
        ACCESSCTLHOLIDAY,                                                                                   
        /// <summary>
        /// search Traffic flow record.search criteria corresponding to FIND_RECORD_TRAFFICFLOW_CONDITION structure,record info corresponding to NET_RECORD_TRAFFIC_FLOW_STATE structure
        /// 查询交通流量记录.查询条件对应 FIND_RECORD_TRAFFICFLOW_CONDITION 结构体,记录信息对应 NET_RECORD_TRAFFIC_FLOW_STATE 结构体
        /// </summary>
        TRAFFICFLOW_STATE,                                                                     
        /// <summary>
        /// call record.search criteria corresponding to FIND_RECORD_VIDEO_TALK_LOG_CONDITION structure,record info corresponding to NET_RECORD_VIDEO_TALK_LOG structure 
        /// 通话记录.查询条件对应 FIND_RECORD_VIDEO_TALK_LOG_CONDITION 结构体,记录信息对应 NET_RECORD_VIDEO_TALK_LOG 结构体
        /// </summary>                                       
        VIDEOTALKLOG,                                                                  
        /// <summary>
        /// status record.search criteria corresponding to FIND_RECORD_REGISTER_USER_STATE_CONDITION structure,record info corresponding to NET_RECORD_REGISTER_USER_STATE structure
        /// 状态记录.查询条件对应 FIND_RECORD_REGISTER_USER_STATE_CONDITION 结构体,记录信息对应 NET_RECORD_REGISTER_USER_STATE 结构体
        /// </summary>
        REGISTERUSERSTATE,                                                                             
        /// <summary>
        /// contact record.search criteria corresponding to FIND_RECORD_VIDEO_TALK_CONTACT_CONDITION structure,record info corresponding to NET_RECORD_VIDEO_TALK_CONTACT structure
        /// 联系人记录.查询条件对应 FIND_RECORD_VIDEO_TALK_CONTACT_CONDITION 结构体,记录信息对应 NET_RECORD_VIDEO_TALK_CONTACT 结构体
        /// </summary>                                 
        VIDEOTALKCONTACT,                                                                                
        /// <summary>
        /// annoinncement record.search criteria corresponding to FIND_RECORD_ANNOUNCEMENT_CONDITION structure,record info corresponding to NET_RECORD_ANNOUNCEMENT_INFO structure
        /// 公告记录.查询条件对应 FIND_RECORD_ANNOUNCEMENT_CONDITION 结构体,记录信息对应 NET_RECORD_ANNOUNCEMENT_INFO 结构体
        /// </summary>
        ANNOUNCEMENT,				                                                                    
        /// <summary>
        /// alarm record.search criteria corresponding to FIND_RECORD_ALARMRECORD_CONDITION structure,record info corresponding to NET_RECORD_ALARMRECORD_INFO structure
        /// 报警记录.查询条件对应 FIND_RECORD_ALARMRECORD_CONDITION 结构体,记录信息对应 NET_RECORD_ALARMRECORD_INFO 结构体
        /// </summary>
        ALARMRECORD,				                                                                   
        /// <summary>
        /// commodity notice record.search criteria corresponding to FIND_RECORD_COMMODITY_NOTICE_CONDITION structure,record info corresponding to NET_RECORD_COMMODITY_NOTICE structure
        /// 下发商品记录.查询条件对应 FIND_RECORD_COMMODITY_NOTICE_CONDITION 结构体,记录信息对应 NET_RECORD_COMMODITY_NOTICE 结构体
        /// </summary>
        COMMODITYNOTICE,                                
        /// <summary>
        /// healthcare notice.search criteria corresponding to FIND_RECORD_HEALTH_CARE_NOTICE_CONDITION structure,record info corresponding to NET_RECORD_HEALTH_CARE_NOTICE structure
        /// 就诊信息记录.查询条件对应 FIND_RECORD_HEALTH_CARE_NOTICE_CONDITION 结构体,记录信息对应 NET_RECORD_HEALTH_CARE_NOTICE 结构体
        /// </summary>
        HEALTHCARENOTICE,                                
        /// <summary>
        /// A&C entry-exit record(can select some critera to search. Please replace NET_RECORD_ACCESSCTLCARDREC).Search criteria corresponding to strcture FIND_RECORD_ACCESSCTLCARDREC_CONDITION_EX,Record info corresponding to structre NET_RECORDSET_ACCESS_CTL_CARDREC
        /// 门禁出入记录(可选择部分条件查询,建议替代NET_RECORD_ACCESSCTLCARDREC).查询条件对应 FIND_RECORD_ACCESSCTLCARDREC_CONDITION_EX 结构体,记录信息对应 NET_RECORDSET_ACCESS_CTL_CARDREC 结构体
        /// </summary>
        ACCESSCTLCARDREC_EX,                                                                            
        /// <summary>
        /// GPS position information reocrd, support import and clear only.Record info corresponding to structure NET_RECORD_GPS_LOCATION_INFO
        /// GPS位置信息记录, 只实现import和clear.记录信息对应 NET_RECORD_GPS_LOCATION_INFO 结构体
        /// </summary>
        GPS_LOCATION,
        /// <summary>
        /// public rental tenants record. search criteria corresponding to FIND_RECORD_RESIDENT_CONDTION structure,record info corresponding to NET_RECORD_RESIDENT_INFO structure
        /// 公租房租户信息.查询条件对应 FIND_RECORD_RESIDENT_CONDTION结构体,记录信息对应 NET_RECORD_RESIDENT_INFO 结构体
        /// </summary>
        RESIDENT,                               
        /// <summary>
        /// sensor record. search criteria corresponding to FIND_RECORD_SENSORRECORD_CONDITION structure,record info corresponding to NET_RECORD_SENSOR_RECORD structure
        /// 监测量数据记录.查询条件对应 FIND_RECORD_SENSORRECORD_CONDITION 结构体,记录信息对应 NET_RECORD_SENSOR_RECORD 结构体
        /// </summary>
        SENSORRECORD,                            
        /// <summary>
        /// AccessQRCode record. record info corresponding to NET_RECORD_ACCESSQRCODE_INFO structure
        /// 开门二维码记录集.记录信息对应 NET_RECORD_ACCESSQRCODE_INFO结构体
        /// </summary>
        ACCESSQRCODE,							
        /// <summary>
        /// electronic tag info record.Search criteria corresponding to structure FIND_RECORD_ELECTRONICSTAG_CONDITION,Record info corresponding to NET_RECORD_ELECTRONICSTAG_INFO
        /// 电子车牌查询.查询条件对应FIND_RECORD_ELECTRONICSTAG_CONDITION 结构体,记录信息对应NET_RECORD_ELECTRONICSTAG_INFO 结构体
        /// </summary>
        ELECTRONICSTAG,							
        /// <summary>
        /// Access blue tooth record.Search blue tooth access record corresponding to structure FIND_RECORD_ACCESS_BLUETOOTH_INFO_CONDITION,Record info corresponding to structure NET_RECORD_ACCESS_BLUETOOTH_INF
        /// 蓝牙开门记录集.查询条件对应 FIND_RECORD_ACCESS_BLUETOOTH_INFO_CONDITION 结构体,记录信息对应 NET_RECORD_ACCESS_BLUETOOTH_INFO 结构体
        /// </summary>
        ACCESS_BLUETOOTH,						                
    }

    /// <summary>
    /// Access Control Status Type
    /// 门禁状态类型
    /// </summary>
    public enum EM_ACCESS_CTL_STATUS_TYPE
    {
        /// <summary>
        /// Unknow
        /// 未知
        /// </summary>
        UNKNOWN = 0,
        /// <summary>
        /// Open
        /// 开门
        /// </summary>
        OPEN,		                                  
        /// <summary>
        /// Close
        /// 关门
        /// </summary>
        CLOSE,		                                  
        /// <summary>
        /// Abnormal
        /// 异常
        /// </summary>
        ABNORMAL,                                     
    }

    /// <summary>
    /// Entrance Guard Record  Information
    /// 门禁密码记录集信息
    /// </summary>
    public struct NET_RECORDSET_ACCESS_CTL_PWD
    {
        /// <summary>
        /// struct size
        /// 结构体大小
        /// </summary>
        public uint                         dwSize;
        /// <summary>
        /// Record Number,Read-Only
        /// 记录集编号,只读
        /// </summary>
        public int                          nRecNo;                              
        /// <summary>
        /// Create Time
        /// 创建时间
        /// </summary>
        public NET_TIME                     stuCreateTime;                       
        /// <summary>
        /// User's ID
        /// 用户ID
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[]                       szUserID;                            
        /// <summary>
        /// Open Password
        /// 开门密码
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]   
        public byte[]                       szDoorOpenPwd;                       
        /// <summary>
        /// Alarm Password
        /// 报警密码
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[]                       szAlarmPwd;                          
        /// <summary>
        /// Valid Door Number
        /// 有效的的门数目
        /// </summary>
        public int                          nDoorNum;                            
        /// <summary>
        /// Privileged Door Number,That is CFG_CMD_ACCESS_EVENT Configure Array Subscript
        /// 有权限的门序号，即CFG_CMD_ACCESS_EVENT配置CFG_ACCESS_EVENT_INFO的数组下标
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public int[]                        sznDoors;                             
        /// <summary>
        /// VTO link position
        /// 门口机关联位置
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[]                       szVTOPosition;                        
    }

    /// <summary>
    /// CLIENT_FindRecord    Interface Input Parameters 
    /// CLIENT_FindRecord接口输入参数
    /// </summary>
    public struct NET_IN_FIND_RECORD_PARAM
    {
        /// <summary>
        ///  Structure Size 
        /// 结构体大小
        /// </summary>
        public uint                       dwSize;           
        /// <summary>
        /// The record type to query
        /// 待查询记录类型
        /// </summary>
        public EM_NET_RECORD_TYPE         emType;           
        /// <summary>
        /// Query types corresponding to the query conditions,the space application by the user,according to query condition type,find corresponding structure,then ensure memory size
        /// 查询类型对应的查询条件,由用户申请内存，根据查询记录类型，找到查询条件对应的结构体，进而确定内存大小
        /// </summary>
        public IntPtr                     pQueryCondition;       
    }
    
    /// <summary>
    /// CLIENT_FindRecord  Interface Output Parameters 
    /// CLIENT_FindRecord接口输出参数
    /// </summary>
    public struct NET_OUT_FIND_RECORD_PARAM
    {
        /// <summary>
        /// Structure Size
        /// 结构体大小
        /// </summary>
        public uint                      dwSize;           
        /// <summary>
        /// Query Log Handle,Uniquely identifies a certain query
        /// 查询记录句柄,唯一标识某次查询
        /// </summary>
        public IntPtr                    lFindeHandle;      
    }
    
    /// <summary>
    /// CLIENT_FindNextRecord  Interface Input Parameters 
    /// CLIENT_FindNextRecord接口输入参数
    /// </summary>
    public struct NET_IN_FIND_NEXT_RECORD_PARAM
    {
        /// <summary>
        /// Structure Size 
        /// 结构体大小
        /// </summary>
        public uint                      dwSize;           
        /// <summary>
        /// Query Log Handle
        /// 查询句柄
        /// </summary>
        public IntPtr                    lFindeHandle;     
        /// <summary>
        /// The current number of records  need query 
        /// 当前想查询的记录条数
        /// </summary>
        public int                       nFileCount;       
    }

    /// <summary>
    /// CLIENT_FindNextRecord  Interface Output Parameters
    /// CLIENT_FindNextRecord接口输出参数
    /// </summary>
    public struct NET_OUT_FIND_NEXT_RECORD_PARAM
    {
        /// <summary>
        /// Structure Size 
        /// 结构体大小
        /// </summary>
        public uint                     dwSize;             
        /// <summary>
        /// Record List, the user allocates memory, ensure structure by query record type(EM_NET_RECORD_TYPE) of NET_IN_FIND_RECORD_PARAM,then ensure memory size
        /// 记录列表,用户分配内存,根据NET_IN_FIND_RECORD_PARAM中的查询类型EM_NET_RECORD_TYPE，确定对应结构体，进入确定内存大小
        /// </summary>
        public IntPtr                   pRecordList;        
        /// <summary>
        /// Max list Record Number 
        /// 最大查询列表记录数
        /// </summary>
        public int                      nMaxRecordNum;     
        /// <summary>
        /// Query to the number of records, when the query to the article number less than want to query the number, end
        /// 查询到的记录条数,当查询到的条数小于想查询的条数时,查询结束
        /// </summary>
        public int                      nRetRecordNum;       
    }

    /// <summary>
    /// CLIENT_QueryRecordCount port input parameter
    /// CLIENT_QueryRecordCount接口输入参数
    /// </summary>
    public struct NET_IN_QUEYT_RECORD_COUNT_PARAM
    {
        /// <summary>
        /// structure size
        /// 结构体大小
        /// </summary>
        public uint                         dwSize;               
        /// <summary>
        /// search handle
        /// 查询句柄
        /// </summary>
        public IntPtr                       lFindeHandle;         
    }

    /// <summary>
    /// CLIENT_QueryRecordCount port output parameter
    /// CLIENT_QueryRecordCount接口输出参数
    /// </summary>
    public struct NET_OUT_QUEYT_RECORD_COUNT_PARAM
    {
        /// <summary>
        /// structure size
        /// 结构体大小
        /// </summary>
        public uint                         dwSize;                
        /// <summary>
        /// device return record item
        /// 设备返回的记录条数
        /// </summary>
        public int                          nRecordCount;          
    }

    /// <summary>
    /// Access Control card Record Information
    /// 门禁刷卡记录记录集信息
    /// </summary>
    public struct NET_RECORDSET_ACCESS_CTL_CARDREC
    {
        /// <summary>
        /// struct size
        /// 结构体大小
        /// </summary>
        public uint                         dwSize;
        /// <summary>
        /// Record Number,Read-Only
        /// 记录集编号,只读
        /// </summary>
        public int                          nRecNo;               
        /// <summary>
        /// Card Number
        /// 卡号
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[]                       szCardNo;        
        /// <summary>
        /// Password
        /// 密码
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[]                       szPwd;           
        /// <summary>
        /// Swing Card Time
        /// 刷卡时间
        /// </summary>
        public NET_TIME                     stuTime;         
        /// <summary>
        /// Swing Card Result,True is Success,False is Fail
        /// 刷卡结果,TRUE表示成功,FALSE表示失败
        /// </summary>
        public bool                         bStatus;         
        /// <summary>
        /// Open Door Method
        /// 开门方式
        /// </summary>
        public EM_ACCESS_DOOROPEN_METHOD    emMethod;        
        /// <summary>
        /// Door Number,That is CFG_CMD_ACCESS_EVENT Configure Array Subscript
        /// 门号,即CFG_CMD_ACCESS_EVENT配置CFG_ACCESS_EVENT_INFO的数组下标
        /// </summary>
        public int                          nDoor;                
        /// <summary>
        /// user ID
        /// 用户ID
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]     
        public byte[]                       szUserID;             
        /// <summary>
        /// card reader ID (abandoned)
        /// 读卡器ID (废弃,不再使用)
        /// </summary>
        public int                          nReaderID;            
        /// <summary>
        /// unlock snap upload ftp url
        /// 开锁抓拍上传的FTP地址
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
    	public byte[]			            szSnapFtpUrl;         
        /// <summary>
        /// card reader ID
        /// 读卡器ID
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]     
    	public byte[]                       szReaderID;    	      
        /// <summary>
        /// Card Type
        /// 卡类型
        /// </summary>
    	public EM_ACCESSCTLCARD_TYPE        emCardType;           
        /// <summary>
        /// Reason of unlock failure, only because it is valid when bStatus is FALSE:
        /// 0x00 no error,0x10 unauthorized,0x11 card lost or cancelled,0x12 no door right,0x13 unlock mode error,0x14 valid period error,0x15 anti sneak into mode,0x16 forced alarm not unlocked
        /// 0x17 door NC status,0x18 AB lock status,0x19 patrol card,0x1A device is under intrusion alarm status,0x20 period error,0x21 unlock period error in holiday period,0x30 first card right check required
        /// 0x40 card correct, input password error,0x41 card correct, input password timed out,0x42 card correct, input fingerprint error,0x42 card correct, input fingerprint error,0x43 card correct, input fingerprint timed out
        /// 0x44 fingerprint correct, input password error, 0x45 fingerprint correct, input password timed out,0x50 group unlock sequence error,0x51 test required for group unlock,0x60 test passed, control unauthorized
        /// 开门失败的原因,仅在bStatus为FALSE时有效:
        /// 0x00 没有错误,0x10 未授权,0x11 卡挂失或注销,0x12 没有该门权限,0x13 开门模式错误,0x14 有效期错误,0x15 防反潜模式,0x16 胁迫报警未打开,0x17 门常闭状态,0x18 AB互锁状态,0x19 巡逻卡,0x1A 设备处于闯入报警状态
        /// 0x20 时间段错误,0x21 假期内开门时间段错误,0x30 需要先验证有首卡权限的卡片,0x40 卡片正确,输入密码错误,0x41 卡片正确,输入密码超时,0x42 卡片正确,输入指纹错误,0x43 卡片正确,输入指纹超时
        /// 0x44 指纹正确,输入密码错误,0x45 指纹正确,输入密码超时,0x50 组合开门顺序错误,0x51 组合开门需要继续验证,0x60 验证通过,控制台未授权
        /// </summary>
        public int                          nErrorCode;             
    }

    /// <summary>
    /// fingerprint collection (corresponding to EM_CtrlType.CAPTURE_FINGER_PRINT command)
    /// 指纹采集(对应EM_CtrlType.CAPTURE_FINGER_PRINT命令)
    /// </summary>
    public struct NET_CTRL_CAPTURE_FINGER_PRINT
    {
        /// <summary>
        /// struct size
        /// 结构体大小
        /// </summary>
        public uint                     dwSize;
        /// <summary>
        /// access control no.(start from 0)
        /// 门禁序号(从0开始)
        /// </summary>
        public int                      nChannelID;                      
        /// <summary>
        /// card reader ID
        /// 读卡器ID
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[]                   szReaderID;  
    }

    /// <summary>
    /// get fingerprint event(corresponding to EM_ALARM_TYPE.ALARM_FINGER_PRINT)
    /// 获取指纹事件(对应DH_ALARM_FINGER_PRINT类型)
    /// </summary>
    public struct NET_ALARM_CAPTURE_FINGER_PRINT_INFO
    {
        /// <summary>
        /// struct size
        /// 结构体大小
        /// </summary>
        public uint                 dwSize;
        /// <summary>
        /// door channel no.( from 0)
        /// 门通道号(从0开始)
        /// </summary>
        public int                  nChannelID;                         
        /// <summary>
        /// event time
        /// 事件时间
        /// </summary>
        public NET_TIME             stuTime;                           
        /// <summary>
        /// card reader ID
        /// 门读卡器ID
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray,SizeConst = 32)]
        public byte[]               szReaderID;                        
        /// <summary>
        /// single fingerprint data length
        /// 单个指纹数据包长度
        /// </summary>
        public int                  nPacketLen;                        
        /// <summary>
        /// fingerprint data number
        /// 指纹数据包个数
        /// </summary>
        public int                  nPacketNum;                        
        /// <summary>
        /// fingerprint data(data total length as nPacketLen*nPacketNum)
        /// 指纹数据(数据总长度即nPacketLen*nPacketNum)
        /// </summary>
        public IntPtr               szFingerPrintInfo;                 
    }
    #endregion


    #region <<Number State>>
    /// <summary>
    /// interface(StartFindNumberStat)'s input param
    /// StartFindNumberStat输入参数
    /// </summary>
    public struct NET_IN_FINDNUMBERSTAT
    {
        /// <summary>
        /// struct size
        /// 结构体大小
        /// </summary>
        public	uint				dwSize;					
        /// <summary>
        /// channel ID
        /// 要进行查询的通道号
        /// </summary>
	    public  int                 nChannelID;           
        /// <summary>
        /// start time
        /// 开始时间 
        /// </summary>
	    public  NET_TIME			stStartTime;			
        /// <summary>
        /// end time
        /// 结束时间
        /// </summary>
	    public  NET_TIME			stEndTime;				
        /// <summary>
        /// granularity type, 0:minute,1:hour,2:day,3:week,4:month,5:quarter,6:year
        /// 查询粒度0:分钟,1:小时,2:日,3:周,4:月,5:季,6:年
        /// </summary>
	    public  int                 nGranularityType;     
        /// <summary>
        /// wait time
        /// 等待接收数据的超时时间
        /// </summary>
	    public  int					nWaittime;		
        /// <summary>
        /// Plan ID,Speed Dome use,start from 1
        /// 计划ID,仅球机有效,从1开始
        /// </summary>
		public uint                 nPlanID;                   
    }

    /// <summary>
    /// StartFindNumberStat's output param
    /// StartFindNumberStat输出参数
    /// </summary>
    public struct NET_OUT_FINDNUMBERSTAT
    {
        /// <summary>
        /// struct size
        /// 结构体大小
        /// </summary>
    	public uint				    dwSize;				
	    /// <summary>
        /// total count
        /// 符合此次查询条件的结果总条数
	    /// </summary>
    	public uint                 dwTotalCount;           
    }

    /// <summary>
    /// DoFindNumberStat's input param
    /// 接口(DoFindNumberStat)输入参数
    /// </summary>
    public struct NET_IN_DOFINDNUMBERSTAT
    {
        /// <summary>
        /// struct size
        /// 结构体大小
        /// </summary>
	    public uint				dwSize;			
		/// <summary>
        /// [0, totalCount-1]
        /// [0, totalCount-1], 查询起始序号,表示从beginNumber条记录开始,取count条记录返回
		/// </summary>
	    public uint             nBeginNumber;               
        /// <summary>
        /// count
        /// 每次查询的流量统计条数
        /// </summary>
	    public uint             nCount;					    
        /// <summary>
        /// wait time
        /// 等待接收数据的超时时间
        /// </summary>
	    public int              nWaittime;				    
    }

    /// <summary>
    /// DoFindNumberStat's ouput param
    /// 接口(DoFindNumberStat)输出参数
    /// </summary>
    public struct NET_OUT_DOFINDNUMBERSTAT
    {
        /// <summary>
        /// struct size
        /// 结构体大小
        /// </summary>
        public uint             dwSize;
        /// <summary>
        /// count
        /// 查询返回人数统计信息个数
        /// </summary>
        public int              nCount;                             
        /// <summary>
        /// state array, the space application by the user(NET_NUMBERSTAT)
        /// 返回人数统计信息数组(NET_NUMBERSTAT)，由用户申请内存，大小为nBufferLen
        /// </summary>
        public IntPtr           pstuNumberStat;                     
        /// <summary>
        /// the space application yb the user, the length unit is the dwsize of NET_NUMBERSTAT
        /// 用户申请的内存大小,以NET_NUMBERSTAT中的dwsize大小为单位
        /// </summary>
        public int              nBufferLen;                        
    }

    /// <summary>
    /// number stat
    /// 数字统计
    /// </summary>
    public struct NET_NUMBERSTAT
    {
        /// <summary>
        /// struct size
        /// 结构体大小
        /// </summary>
    	public uint             dwSize;
        /// <summary>
        /// channel id
        /// 统计通道号
        /// </summary>
    	public int              nChannelID;                           
        /// <summary>
        /// rule name
        /// 规则名称
        /// </summary>
    	[MarshalAs(UnmanagedType.ByValArray,SizeConst = 32)]
        public byte[]           szRuleName;                           
        /// <summary>
        /// start time
        /// 开始时间
        /// </summary>
    	public NET_TIME         stuStartTime;                         
        /// <summary>
        /// end time
        /// 结束时间
        /// </summary>
    	public NET_TIME         stuEndTime;                           
        /// <summary>
        /// entered total
        /// 进入人数小计
        /// </summary>
        public int              nEnteredSubTotal;                     
        /// <summary>
        /// entered total
        /// 出去人数小计
        /// </summary>
    	public int              nExitedSubtotal;                    
        /// <summary>
        /// average number inside
        /// 平均保有人数(除去零值)
        /// </summary>
        public int              nAvgInside;                         
        /// <summary>
        /// max number inside
        /// 最大保有人数
        /// </summary>
    	public int              nMaxInside;                         
        /// <summary>
        /// people enter with helmet count
        /// 戴安全帽进入人数小计
        /// </summary>
        public int              nEnteredWithHelmet;                 
        /// <summary>
        /// people enter without helmet count
        /// 不戴安全帽进入人数小计
        /// </summary>
        public int              nEnteredWithoutHelmet;              
        /// <summary>
        /// people exit with helmet count
        /// 戴安全帽出去人数小计
        /// </summary>
        public int              nExitedWithHelmet;                  
        /// <summary>
        /// people exit without helmet count
        /// 不戴安全帽出去人数小计
        /// </summary>
        public int              nExitedWithoutHelmet;               
    }

    /// <summary>
    /// input param for AttachVideoStatSummary
    /// AttachVideoStatSummary 入参
    /// </summary>
    public struct NET_IN_ATTACH_VIDEOSTAT_SUM
    {
        /// <summary>
        /// struct size
        /// 结构体大小
        /// </summary>
        public uint                     dwSize;
        /// <summary>
        /// video channel ID    
        /// 视频通道号
        /// </summary>
        public int                      nChannel;                    
        /// <summary>
        /// video statistical summary callback
        /// 视频统计摘要信息回调
        /// </summary>
        public fVideoStatSumCallBack    cbVideoStatSum;              
        /// <summary>
        /// user data
        /// 用户数据
        /// </summary>
        public IntPtr                   dwUser;                        
    }

    /// <summary>
    /// output param for AttachVideoStatSummary
    /// AttachVideoStatSummary 出参
    /// </summary>
    public struct NET_OUT_ATTACH_VIDEOSTAT_SUM
    {
        /// <summary>
        /// struct size
        /// 结构体大小
        /// </summary>
        public uint                     dwSize;
    } 

    /// <summary>
    /// video statistical subtotal
    /// 视频统计小计信息
    /// </summary>
    public struct NET_VIDEOSTAT_SUBTOTAL
    {
        /// <summary>
        /// count since device operation
        /// 设备运行后人数统计总数
        /// </summary>
        public int                      nTotal;                        
        /// <summary>
        /// count in the last hour
        /// 小时内的总人数
        /// </summary>
        public int                      nHour;                         
        /// <summary>
        /// count for today
        /// 当天的总人数, 不可手动清除
        /// </summary>
        public int                      nToday;                        
        /// <summary>
        /// count for today, on screen display 
        /// 统计人数, 用于OSD显示, 可手动清除
        /// </summary>
        public int                      nOSD;      
        /// <summary>
        /// reserved
        /// 保留字节
        /// </summary>   
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 252)]
        public byte[]                   reserved;
    }

    /// <summary>
    /// video statistical summary
    /// 视频统计摘要信息
    /// </summary>
    public struct NET_VIDEOSTAT_SUMMARY
    {
        /// <summary>
        /// channel ID 
        /// 通道号
        /// </summary>
        public int nChannelID;                                         
        /// <summary>
        /// rule name
        /// 规则名称
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] szRuleName;                                      
        /// <summary>
        /// time of this statistics
        /// 统计时间
        /// </summary>
        public NET_TIME_EX stuTime;                                    
        /// <summary>
        /// subtotal for the entered
        /// 进入小计
        /// </summary>
        public NET_VIDEOSTAT_SUBTOTAL stuEnteredSubtotal;              
        /// <summary>
        /// subtotal for the exited
        /// 出去小计
        /// </summary>
        public NET_VIDEOSTAT_SUBTOTAL stuExitedSubtotal;               
        /// <summary>
        /// reserved
        /// 保留字节
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
        public byte[] reserved;
    }
    #endregion Number state

    #region <<Face Module>>
    /// <summary>
    /// the describe of EVENT_IVS_FACEDETECT's data
    /// 人脸检测事件对应的数据块描述信息
    /// </summary>
    public struct NET_DEV_EVENT_FACEDETECT_INFO
    {
        /// <summary>
        /// channel ID
        /// 通道号
        /// </summary>
        public int					nChannelID;						   
        /// <summary>
        /// event name
        /// 事件名称
        /// </summary>
	    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string				szName;					           
        /// <summary>
        /// byte alignment
        /// 字节对齐
        /// </summary>
	    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[]               bReserved1;                        
        /// <summary>
        /// PTS(ms)
        /// 时间戳(单位是毫秒)
        /// </summary>
	    public double				PTS;						    	
        /// <summary>
        /// the event happen time
        /// 事件发生的时间
        /// </summary>
	    public NET_TIME_EX			UTC;						       
        /// <summary>
        /// event ID
        /// 事件ID
        /// </summary>
	    public int					nEventID;					       
        /// <summary>
        /// have being detected object
        /// 检测到的物体
        /// </summary>
	    public NET_MSG_OBJECT		stuObject;						   
        /// <summary>
        /// event file info
        /// 事件对应文件信息
        /// </summary>
	    public NET_EVENT_FILE_INFO  stuFileInfo;					   
        /// <summary>
        /// Event action: 0 means pulse event,1 means continuous event's begin,2means continuous event's end
        /// 事件动作,0表示脉冲事件,1表示持续性事件开始,2表示持续性事件结束
        /// </summary>
	    public byte                 bEventAction;                      
        /// <summary>
        /// reserved
        /// 保留字节
        /// </summary>
	    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[]               reserved;                          
        /// <summary>
        /// Serial number of the picture, in the same time (accurate to seconds) may have multiple images, starting from 0
        /// 图片的序号, 同一时间内(精确到秒)可能有多张图片, 从0开始
        /// </summary>
        public byte                 byImageIndex;                      
        /// <summary>
        /// detect region point number
        /// 规则检测区域顶点数
        /// </summary>
	    public int                  nDetectRegionNum;				   
        /// <summary>
        /// detect region
        /// 规则检测区域
        /// </summary>
	    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public NET_POINT[]          DetectRegion;                      
        /// <summary>
        /// flag(by bit),see NET_RESERVED_COMMON
        /// 抓图标志(按位),具体见NET_RESERVED_COMMON  
        /// </summary>
        public uint                 dwSnapFlagMask;	                   
        /// <summary>
        /// snapshot current face device address
        /// 抓拍当前人脸的设备地址
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string               szSnapDevAddress;                  
        /// <summary>
        /// event trigger accumilated times 
        /// 事件触发累计次数
        /// </summary>
        public uint                 nOccurrenceCount;                  
        /// <summary>
        /// sex type
        /// 性别
        /// </summary>
        public EM_DEV_EVENT_FACEDETECT_SEX_TYPE emSex;                 
        /// <summary>
        /// age, invalid if it is -1
        /// 年龄,-1表示该字段数据无效
        /// </summary>
        public int        			nAge;                              
        /// <summary>
        /// invalid number in array emFeature
        /// 人脸特征数组有效个数,与 emFeature 结合使用
        /// </summary>
        public uint                 nFeatureValidNum;                  
        /// <summary>
        /// human face features
        /// 人脸特征数组,与 nFeatureValidNum 结合使用
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public EM_DEV_EVENT_FACEDETECT_FEATURE_TYPE[]    emFeature;    
        /// <summary>
        /// number of stuFaces
        /// 指示stuFaces有效数量
        /// </summary>
        public int                  nFacesNum;                         
        /// <summary>
        /// when nFacesNum > 0, stuObject invalid
        /// 多张人脸时使用,此时没有Object
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public NET_FACE_INFO[]      stuFaces;                          
        /// <summary>
        /// public info 
        /// 智能事件公共信息
        /// </summary>
        public NET_EVENT_INTELLI_COMM_INFO     stuIntelliCommInfo;
        /// <summary>
        /// race
        /// 种族
        /// </summary>
        public EM_RACE_TYPE                     emRace;								
        /// <summary>
        /// eyes state
        /// 眼睛状态
        /// </summary>
        public EM_EYE_STATE_TYPE                emEye;								
        /// <summary>
        /// mouth state
        /// 嘴巴状态
        /// </summary>
        public EM_MOUTH_STATE_TYPE              emMouth;							
        /// <summary>
        /// mask state
        /// 口罩状态
        /// </summary>
        public EM_MASK_STATE_TYPE               emMask;								
        /// <summary>
        /// beard state
        /// 胡子状态
        /// </summary>
        public EM_BEARD_STATE_TYPE              emBeard;							
        /// <summary>
        /// Attractive value, -1: invalid, 0:no disringuish,range: 1-100, the higher value, the higher charm
        /// 魅力值, -1表示无效, 0未识别，识别时范围1-100,得分高魅力高
        /// </summary>
        public int                              nAttractive;						
        /// <summary>
        /// Reserved
        /// 保留字节
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 868)]
        public byte[]               bReserved;                   		
    }

    /// <summary>
    /// race type
    /// 种族类型
    /// </summary>
    public enum EM_RACE_TYPE
    {
        /// <summary>
        /// unknown
        /// 未知 
        /// </summary>
	    UNKNOWN,			
        /// <summary>
        /// no disringuish
        /// 未识别
        /// </summary>
	    NODISTI,			
        /// <summary>
        /// yellow
        /// 黄种人
        /// </summary>
	    YELLOW,				
        /// <summary>
        /// black
        /// 黑人
        /// </summary>
	    BLACK,				
        /// <summary>
        /// white
        /// 白人
        /// </summary>
	    WHITE,				
    } 

    /// <summary>
    /// eyes state
    /// 眼睛状态
    /// </summary>
    public enum EM_EYE_STATE_TYPE
    {
        /// <summary>
        /// unknown
        /// 未知
        /// </summary>
	    UNKNOWN,		
        /// <summary>
        /// no disringuish
        /// 未识别
        /// </summary>
	    NODISTI,		
        /// <summary>
        /// close eyes
        /// 闭眼
        /// </summary>
	    CLOSE,			
        /// <summary>
        ///open eyes 
        /// 睁眼
        /// </summary>
	    OPEN,			
    }

    /// <summary>
    /// mouth state
    /// 嘴巴状态
    /// </summary>
    public enum EM_MOUTH_STATE_TYPE
    {
        /// <summary>
        /// unknown
        /// 未知
        /// </summary>
	    UNKNOWN,		
        /// <summary>
        /// no disringuish
        /// 未识别
        /// </summary>
	    NODISTI,		
        /// <summary>
        /// close mouth
        /// 闭嘴
        /// </summary>
	    CLOSE,		 
        /// <summary>
        /// open nouth
        /// 张嘴
        /// </summary>
	    OPEN,		
    } 

    /// <summary>
    /// mask state
    /// 口罩状态
    /// </summary>
    public enum EM_MASK_STATE_TYPE
    {
        /// <summary>
        /// unknown
        /// 未知
        /// </summary>
	    UNKNOWN,		
        /// <summary>
        /// no disringuish
        /// 未识别
        /// </summary>
	    NODISTI,		 
        /// <summary>
        /// no mask
        /// 没戴口罩
        /// </summary>
	    NOMASK,		
        /// <summary>
        /// wearing mask
        /// 戴口罩
        /// </summary>
	    WEAR,			
    } 

    /// <summary>
    /// beard state
    /// 胡子状态
    /// </summary>
    public enum EM_BEARD_STATE_TYPE
    {
        /// <summary>
        /// unknown
        /// 未知
        /// </summary>
	    UNKNOWN,		
        /// <summary>
        /// no disringuish
        /// 未识别
        /// </summary>
	    NODISTI,	
        /// <summary>
        /// no beard
        /// 没胡子
        /// </summary>
	    NOBEARD,		
        /// <summary>
        /// have beard
        /// 有胡子
        /// </summary>
	    HAVEBEARD,	
    } 

    /// <summary>
    /// sex type of dectected human face
    /// 人脸检测对应性别类型
    /// </summary>
    public enum EM_DEV_EVENT_FACEDETECT_SEX_TYPE
    {
        /// <summary>
        /// unknown
        /// 未知
        /// </summary>
        UNKNOWN,                                                            
        /// <summary>
        /// male
        /// 男性
        /// </summary>
        MAN,                                                               
        /// <summary>
        /// female
        /// 女性
        /// </summary>
        WOMAN,                                                             
    }

    /// <summary>
    /// feature type of detected human face
    /// 人脸检测对应人脸特征类型
    /// </summary>
    public enum EM_DEV_EVENT_FACEDETECT_FEATURE_TYPE
    {
        /// <summary>
        /// unknown
        /// 未知
        /// </summary>
        UNKNOWN,                                                           
        /// <summary>
        /// wearing glasses
        /// 戴眼镜
        /// </summary>
        WEAR_GLASSES,                                                      
        /// <summary>
        /// smile
        /// 微笑
        /// </summary>
        SMILE,                                                             
        /// <summary>
        /// anger
        /// 愤怒
        /// </summary>
	    ANGER,                                                             
        /// <summary>
        /// sadness
        /// 悲伤
        /// </summary>
        SADNESS,                                                           
        /// <summary>
        /// disgust
        /// 厌恶
        /// </summary>
        DISGUST,                                                           
        /// <summary>
        /// fear
        /// 害怕
        /// </summary>
        FEAR,                                                              
        /// <summary>
        /// surprise
        /// 惊讶
        /// </summary>
        SURPRISE,                                                          
        /// <summary>
        /// neutral
        /// 正常
        /// </summary>
        NEUTRAL,                                                           
        /// <summary>
        /// laugh
        /// 大笑
        /// </summary>
        LAUGH,                                                             
        /// <summary>
        /// not wear glasses
        /// 没戴眼镜
        /// </summary>
        NOGLASSES,
        /// <summary>
        /// happy
        /// 高兴
        /// </summary>
        HAPPY,					
        /// <summary>
        /// confused
        /// 困惑
        /// </summary>
        CONFUSED,				
        /// <summary>
        /// scream
        /// 尖叫
        /// </summary>
        SCREAM,
        /// <summary>
        /// wearing sun glasses
        /// 戴太阳眼镜
        /// </summary>
        WEAR_SUNGLASSES,                               
    }

    /// <summary>
    /// multi faces detect info
    /// 多人脸检测信息
    /// </summary>
    public struct NET_FACE_INFO
	{
        /// <summary>
        /// object id
        /// 物体ID,每个ID表示一个唯一的物体
        /// </summary>
	    public int                      nObjectID;                         
        /// <summary>
        /// object type
        /// 物体类型
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string                   szObjectType;                      
        /// <summary>
        /// same with the source picture id
        /// 这张人脸抠图所属的大图的ID
        /// </summary>
        public int                      nRelativeID;                       
        /// <summary>
        /// bounding box
        /// 包围盒
        /// </summary>
        public NET_RECT                 BoundingBox;                       
        /// <summary>
        /// object center
        /// 物体型心
        /// </summary>
        public NET_POINT                Center;                            
	}
	
    /// <summary>
    /// the describe of EVENT_IVS_FACERECOGNITION's data
    /// 人脸识别对应的数据块描述信息
    /// </summary>
	public struct NET_DEV_EVENT_FACERECOGNITION_INFO
    {
        /// <summary>
        /// ChannelId
        /// 通道号
        /// </summary>
	    public int					        nChannelID;						
        /// <summary>
        /// event name
        /// 事件名称
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	    public string				        szName;					        
        /// <summary>
        /// event ID
        /// 事件ID
        /// </summary>
        public int                          nEventID;                       
        /// <summary>
        /// the event happen time
        /// 事件发生的时间
        /// </summary>
	    public NET_TIME_EX			        UTC;							
        /// <summary>
        /// have being detected object
        /// 检测到的物体
        /// </summary>
	    public NET_MSG_OBJECT		        stuObject;						
        /// <summary>
        /// candidate number
        /// 当前人脸匹配到的候选对象数量
        /// </summary>
	    public int                          nCandidateNum;                  
        /// <summary>
        /// candidate info
        /// 当前人脸匹配到的候选对象信息
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
        public NET_CANDIDATE_INFO[]         stuCandidates;                  
        /// <summary>
        /// Event action,0 means pulse event,1 means continuous event's begin,2means continuous event's end
        /// 事件动作,0表示脉冲事件,1表示持续性事件开始,2表示持续性事件结束
        /// </summary>
	    public byte                         bEventAction;                   
        /// <summary>
        /// Serial number of the picture, in the same time (accurate to seconds) may have multiple images, starting from 0
        /// 图片的序号, 同一时间内(精确到秒)可能有多张图片, 从0开始
        /// </summary>
        public byte                         byImageIndex;                  
        /// <summary>
        /// reserved
        /// 对齐
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	    public byte[]				        byReserved1;				   
        /// <summary>
        /// The existence panorama
        /// 全景图是否存在
        /// </summary>
	    public bool                         bGlobalScenePic;               
        /// <summary>
        /// Panoramic Photos
        /// 全景图片信息
        /// </summary>
	    public NET_PIC_INFO                 stuGlobalScenePicInfo;         
        /// <summary>
        /// Snapshot current face aadevice address
        /// 抓拍当前人脸的设备地址
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string                       szSnapDevAddress;              
        /// <summary>
        /// event trigger accumilated times 
        /// 事件触发累计次数
        /// </summary>
        public uint                         nOccurrenceCount;              
        /// <summary>
        /// intelligent things info
        /// 智能事件公共信息
        /// </summary>
        public NET_EVENT_INTELLI_COMM_INFO  stuIntelliCommInfo;
        /// <summary>
        /// face data
        /// 人脸数据
        /// </summary>
        public NET_FACE_DATA                stuFaceData;								 
        /// <summary>
        /// Reserved
        /// 保留字节
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 300)]
        public byte[]                       bReserved;                     
    }

    /// <summary>
    /// face data
    /// 人脸数据
    /// </summary>
    public struct NET_FACE_DATA
    {
        /// <summary>
        /// sex type
        /// 性别
        /// </summary>
	    public EM_DEV_EVENT_FACEDETECT_SEX_TYPE 		        emSex;						
        /// <summary>
        /// age, invalid if it is -1
        /// 年龄,-1表示该字段数据无效
        /// </summary>
	    public int        								        nAge;						
        /// <summary>
        /// invalid number in array emFeature
        /// 人脸特征数组有效个数,与 emFeature 结合使用
        /// </summary>
        public uint        					                    nFeatureValidNum;           
        /// <summary>
        /// human face features
        /// 人脸特征数组,与 nFeatureValidNum 结合使用
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public EM_DEV_EVENT_FACEDETECT_FEATURE_TYPE[]           emFeature;   
        /// <summary>
        /// race
        /// 种族
        /// </summary>
	    public EM_RACE_TYPE							            emRace;						
        /// <summary>
        /// eyes state
        /// 眼睛状态
        /// </summary>
	    public EM_EYE_STATE_TYPE						        emEye;						
        /// <summary>
        /// mouth state
        /// 嘴巴状态
        /// </summary>
	    public EM_MOUTH_STATE_TYPE						        emMouth;					
        /// <summary>
        /// mask state
        /// 口罩状态
        /// </summary>
	    public EM_MASK_STATE_TYPE 						        emMask;						
        /// <summary>
        /// beard state
        /// 胡子状态
        /// </summary>
	    public EM_BEARD_STATE_TYPE						        emBeard;					
        /// <summary>
        /// Attractive value, -1: invalid, 0:no disringuish,range: 1-100, the higher value, the higher charm
        /// 魅力值, -1表示无效, 0未识别，识别时范围1-100,得分高魅力高
        /// </summary>
	    public int										        nAttractive;				
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[]                					        bReserved;             
    }
	
    /// <summary>
    /// cadidate person info
    /// 候选人员信息
    /// </summary>
	public struct NET_CANDIDATE_INFO
    {
        /// <summary>
        /// person info
        /// 人员信息
        /// </summary>
	    public NET_FACERECOGNITION_PERSON_INFO  stPersonInfo;             
        /// <summary>
        /// similarity
        /// 和查询图片的相似度
        /// </summary>
	    public byte                             bySimilarity;             
        /// <summary>
        /// Range officer's database, see EM_FACE_DB_TYPE
        /// 人员所属数据库范围,详见EM_FACE_DB_TYPE
        /// </summary>
	    public byte                             byRange;                  
        /// <summary>
        /// Reserved
        /// 字节对齐
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	    public byte[]                           byReserved1;
        /// <summary>
        /// When byRange historical database effectively, which means that the query time staff appeared
        /// 当byRange为历史数据库时有效,表示查询人员出现的时间
        /// </summary>
	    public NET_TIME                         stTime;                     
        /// <summary>
        /// When byRange historical database effectively, which means that people place a query appears
        /// 当byRange为历史数据库时有效,表示查询人员出现的地点 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	    public string                           szAddress;                  
        /// <summary>
        /// Is hit, means the result face has compare result in database
        /// 是否有识别结果,指这个检测出的人脸在库中有没有比对结果
        /// </summary>
	    public bool                             bIsHit;                     
        /// <summary>
        /// Scene Image
        /// 人脸全景图
        /// </summary>
	    public NET_PIC_INFO_EX3                 stuSceneImage;   
        /// <summary>
        /// channel id
        /// 通道号
        /// </summary>
        public int 							    nChannelID;			     
        /// <summary>
        /// Reserved
        /// 保留字节
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[]                           byReserved;                 
    }
	
    /// <summary>
    /// person info
    /// 人员信息
    /// </summary>
	public struct NET_FACERECOGNITION_PERSON_INFO
    {
        /// <summary>
        /// name
        /// 姓名
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	    public string                           szPersonName;		        
        /// <summary>
        /// birth year
        /// 出生年,作为查询条件时,此参数填0,则表示此参数无效
        /// </summary>
	    public ushort				                wYear;						
        /// <summary>
        /// birth month
        /// 出生月,作为查询条件时,此参数填0,则表示此参数无效
        /// </summary>
	    public byte				                byMonth;					
        /// <summary>
        /// birth day
        /// 出生日,作为查询条件时,此参数填0,则表示此参数无效
        /// </summary>
	    public byte				                byDay;						
        /// <summary>
        /// the unicle ID for the person
        /// 人员唯一标示(身份证号码,工号,或其他编号)
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	    public string                           szID;			            
        /// <summary>
        /// importance level,1~10,the higher value the higher level
        /// 人员重要等级,1~10,数值越高越重要,作为查询条件时,此参数填0,则表示此参数无效
        /// </summary>
	    public byte                             bImportantRank;				
        /// <summary>
        /// sex, 1-man, 2-female
        /// 性别,1-男,2-女,作为查询条件时,此参数填0,则表示此参数无效
        /// </summary>
	    public byte                             bySex;						
        /// <summary>
        /// picture number
        /// 图片张数
        /// </summary>
	    public ushort                           wFacePicNum;				
        /// <summary>
        /// picture info
        /// 当前人员对应的图片信息
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
	    public NET_PIC_INFO[]                   szFacePicInfo;              
        /// <summary>
        /// Personnel types, see EM_PERSON_TYPE
        /// 人员类型,详见 EM_PERSON_TYPE
        /// </summary>
	    public byte                             byType;                     
        /// <summary>
        /// Document types, see EM_CERTIFICATE_TYPE
        /// 证件类型,详见 EM_CERTIFICATE_TYPE
        /// </summary>
	    public byte                             byIDType;                   
        /// <summary>
        /// Byte alignment
        /// 字节对齐
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	    public byte[]                           bReserved1;                 
        /// <summary>
        /// province
        /// 省份
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	    public string                           szProvince;                 
        /// <summary>
        /// city
        /// 城市
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	    public string                           szCity;                     
        /// <summary>
        /// Name, the name is too long due to the presence of 16 bytes can not be Storage problems, the increase in this parameter
        /// 姓名,因存在姓名过长,16字节无法存放问题,故增加此参数
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	    public string                           szPersonNameEx;	           
        /// <summary>
        /// person unique ID
        /// 人员唯一标识符,首次由服务端生成,区别于ID字段,修改,删除操作时必填
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string                           szUID;                     
        /// <summary>
        /// country
        /// 国籍
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
	    public string				            szCountry;					
        /// <summary>
        /// using person type: 0 using byType, 1 using szPersonName
        /// 人员类型是否为自定义
        /// </summary>
	    public byte				                byIsCustomType;				
        /// <summary>
        /// comment info
        /// 备注信息
        /// </summary>
	    public IntPtr				            pszComment;
        /// <summary>
        /// Group ID
        /// 人员所属组ID
        /// </summary>
        public IntPtr                           pszGroupID;									
        /// <summary>
        /// Group Name
        /// 人员所属组名
        /// </summary>
        public IntPtr                           pszGroupName;								
        /// <summary>
        /// the face feature
        /// 人脸特征
        /// </summary>
        public IntPtr                           pszFeatureValue;							
        /// <summary>
        /// len of pszGroupID
        /// pszGroupID的长度
        /// </summary>
        public byte                             bGroupIdLen;								
        /// <summary>
        /// len of pszGroupName
        /// pszGroupName的长度
        /// </summary>
        public byte                             bGroupNameLen;								
        /// <summary>
        /// len of pszFeatureValue
        /// pszFeatureValue的长度
        /// </summary>
        public byte                             bFeatureValueLen;							
        /// <summary>
        /// reserved
        /// 保留字段
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public byte[]                           bReserved;                 
    }

    /// <summary>
    /// picture info
    /// 物体对应图片文件信息
    /// </summary>
    public struct NET_PIC_INFO_EX3
    {
        /// <summary>
        /// current picture file's offset in the binary file, byte
        /// 文件在二进制数据块中的偏移位置, 单位:字节
        /// </summary>
	    public uint                             dwOffSet;                   
        /// <summary>
        /// current picture file's size, byte
        /// 文件大小, 单位:字节
        /// </summary>
	    public uint                             dwFileLenth;                
        /// <summary>
        ///  picture width, pixel
        /// 图片宽度, 单位:像素
        /// </summary>
	    public ushort                           wWidth;                     
        /// <summary>
        /// picture high, pixel
        /// 图片高度, 单位:像素
        /// </summary>
	    public ushort                           wHeight;                    
        /// <summary>
        /// File path
        /// 文件路径
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
 	    public string                           szFilePath;                 
        /// <summary>
        /// When submit to the server, the algorithm has checked the image or not 
        /// 图片是否算法检测出来的检测过的提交识别服务器时，则不需要再时检测定位抠图,1:检测过的,0:没有检测过
        /// </summary>
        public byte            	                bIsDetected;			  
        /// <summary>
        /// Reserved
        /// 保留
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 11)]
        public byte[]            	            bReserved;					
    }
	
    #endregion

    /// <summary>
    /// Control type    Corresponding to ControlDevice 
    /// 控制类型,对应ControlDevice接口
    /// </summary>
    public enum EM_CtrlType
    {
        /// <summary>
        /// Reboot device
        /// 重启设备
        /// </summary>
        REBOOT = 0,							                             
        /// <summary>
        /// Shut down device
        /// 关闭设备
        /// </summary>
        SHUTDOWN,							                             
        /// <summary>
        /// HDD management
        /// 硬盘管理
        /// </summary>
        DISK,								                             
        /// <summary>
        /// Network keyboard
        /// 网络键盘
        /// </summary>
        KEYBOARD_POWER = 3,						                         
        /// <summary>
        /// KEYBOARD_ENTER
        /// 键盘回车键
        /// </summary>
        KEYBOARD_ENTER,
        /// <summary>
        /// KEYBOARD_ESC
        /// 键盘退出键
        /// </summary>
        KEYBOARD_ESC,
        /// <summary>
        /// KEYBOARD_UP
        /// 键盘向上键
        /// </summary>
        KEYBOARD_UP,
        /// <summary>
        /// KEYBOARD_DOWN
        /// 键盘向下键
        /// </summary>
        KEYBOARD_DOWN,
        /// <summary>
        /// KEYBOARD_LEFT
        /// 键盘向左键
        /// </summary>
        KEYBOARD_LEFT,
        /// <summary>
        /// KEYBOARD_RIGHT
        /// 键盘向右键
        /// </summary>
        KEYBOARD_RIGHT,
        /// <summary>
        /// KEYBOARD_BTN0
        /// 键盘BTN0键
        /// </summary>
        KEYBOARD_BTN0,
        /// <summary>
        /// KEYBOARD_BTN1
        /// 键盘BTN1键
        /// </summary>
        KEYBOARD_BTN1,
        /// <summary>
        /// KEYBOARD_BTN2
        /// 键盘BTN2键
        /// </summary>
        KEYBOARD_BTN2,
        /// <summary>
        /// KEYBOARD_BTN3
        /// 键盘BTN3键
        /// </summary>
        KEYBOARD_BTN3,
        /// <summary>
        /// KEYBOARD_BTN4
        /// 键盘BTN4键
        /// </summary>
        KEYBOARD_BTN4,
        /// <summary>
        /// KEYBOARD_BTN5
        /// 键盘BTN5键
        /// </summary>
        KEYBOARD_BTN5,
        /// <summary>
        /// KEYBOARD_BTN6
        /// 键盘BTN6键
        /// </summary>
        KEYBOARD_BTN6,
        /// <summary>
        /// KEYBOARD_BTN7
        /// 键盘BTN7键
        /// </summary>
        KEYBOARD_BTN7,
        /// <summary>
        /// KEYBOARD_BTN8
        /// 键盘BTN8键
        /// </summary>
        KEYBOARD_BTN8,
        /// <summary>
        /// KEYBOARD_BTN9
        /// 键盘BTN9键
        /// </summary>
        KEYBOARD_BTN9,
        /// <summary>
        /// KEYBOARD_BTN10
        /// 键盘BTN10键
        /// </summary>
        KEYBOARD_BTN10,
        /// <summary>
        /// KEYBOARD_BTN11
        /// 键盘BTN11键
        /// </summary>
        KEYBOARD_BTN11,
        /// <summary>
        /// KEYBOARD_BTN12
        /// 键盘BTN12键
        /// </summary>
        KEYBOARD_BTN12,
        /// <summary>
        /// KEYBOARD_BTN13
        /// 键盘BTN13键
        /// </summary>
        KEYBOARD_BTN13,
        /// <summary>
        /// KEYBOARD_BTN14
        /// 键盘BTN14键
        /// </summary>
        KEYBOARD_BTN14,
        /// <summary>
        /// KEYBOARD_BTN15
        /// 键盘BTN15键
        /// </summary>
        KEYBOARD_BTN15,
        /// <summary>
        /// KEYBOARD_BTN16
        /// 键盘BTN16键
        /// </summary>
        KEYBOARD_BTN16,
        /// <summary>
        /// KEYBOARD_SPLIT
        /// 键盘分割键
        /// </summary>
        KEYBOARD_SPLIT,
        /// <summary>
        /// KEYBOARD_ONE
        /// 键盘ONE键
        /// </summary>
        KEYBOARD_ONE,
        /// <summary>
        /// KEYBOARD_NINE
        /// 键盘NINE键
        /// </summary>
        KEYBOARD_NINE,
        /// <summary>
        /// KEYBOARD_ADDR
        /// 键盘ADDR键
        /// </summary>
        KEYBOARD_ADDR,
        /// <summary>
        /// KEYBOARD_INFO
        /// 键盘INFO键
        /// </summary>
        KEYBOARD_INFO,
        /// <summary>
        /// KEYBOARD_REC
        /// 键盘REC键
        /// </summary>
        KEYBOARD_REC,
        /// <summary>
        /// KEYBOARD_FN1
        /// 键盘FN1键
        /// </summary>
        KEYBOARD_FN1,
        /// <summary>
        /// KEYBOARD_FN2
        /// 键盘FN2键
        /// </summary>
        KEYBOARD_FN2,
        /// <summary>
        /// KEYBOARD_PLAY
        /// 键盘PLAY键
        /// </summary>
        KEYBOARD_PLAY,
        /// <summary>
        /// KEYBOARD_STOP
        /// 键盘STOP键
        /// </summary>
        KEYBOARD_STOP,
        /// <summary>
        /// KEYBOARD_SLOW
        /// 键盘SLOW键
        /// </summary>
        KEYBOARD_SLOW,
        /// <summary>
        /// KEYBOARD_FAST
        /// 键盘FAST键
        /// </summary>
        KEYBOARD_FAST,
        /// <summary>
        /// KEYBOARD_PREW
        /// 键盘PREW键
        /// </summary>
        KEYBOARD_PREW,
        /// <summary>
        /// KEYBOARD_NEXT
        /// 键盘NEXT键
        /// </summary>
        KEYBOARD_NEXT,
        /// <summary>
        /// KEYBOARD_JMPDOWN
        /// 键盘JMPDOWN键
        /// </summary>
        KEYBOARD_JMPDOWN,
        /// <summary>
        /// KEYBOARD_JMPUP
        /// 键盘JMPUP键
        /// </summary>
        KEYBOARD_JMPUP,
        /// <summary>
        /// KEYBOARD_10PLUS
        /// 键盘10PLUS键
        /// </summary>
        KEYBOARD_10PLUS,
        /// <summary>
        /// KEYBOARD_SHIFT
        /// 键盘SHIFT键
        /// </summary>
        KEYBOARD_SHIFT,
        /// <summary>
        /// KEYBOARD_BACK
        /// 键盘BACK键
        /// </summary>
        KEYBOARD_BACK,
        /// <summary>
        /// KEYBOARD_LOGIN
        /// 键盘LOGIN键
        /// </summary>
        KEYBOARD_LOGIN,                                                    
        /// <summary>
        /// KEYBOARD_CHNNEL
        /// 键盘CHNNEL键
        /// </summary>
        KEYBOARD_CHNNEL,                                                   
        /// <summary>
        /// Activate alarm input
        /// 触发报警输入
        /// </summary>
        TRIGGER_ALARM_IN = 100,					                            
        /// <summary>
        /// Activate alarm output 
        /// 触发报警输出
        /// </summary>
        TRIGGER_ALARM_OUT,						                           
        /// <summary>
        /// Matrix control 
        /// 矩阵控制
        /// </summary>
        MATRIX,								                                
        /// <summary>
        /// SD card control(for IPC series). Please refer to HDD control
        /// SD卡控制(IPC产品)参数同硬盘控制
        /// </summary>
        SDCARD,								                                
        /// <summary>
        /// Burner control:begin burning
        /// 刻录机控制,开始刻录
        /// </summary>
        BURNING_START,							                            
        /// <summary>
        /// Burner control:stop burning 
        /// 刻录机控制,结束刻录
        /// </summary>
        BURNING_STOP,							                            
        /// <summary>
        /// Burner control:overlay password(The string ended with '\0'. Max length is 8 bits. )
        /// 刻录机控制,叠加密码(以'\0'为结尾的字符串,最大长度8位)
        /// </summary>
        BURNING_ADDPWD,							                           
        /// <summary>
        /// Burner control:overlay head title(The string ended with '\0'. Max length is 1024 bytes. Use '\n' to Enter.)
        /// 刻录机控制,叠加片头(以'\0'为结尾的字符串,最大长度1024字节,支持分行,行分隔符'\n')
        /// </summary>
        BURNING_ADDHEAD,							                        
        /// <summary>
        /// Burner control:overlay dot to the burned information(No parameter) 
        /// 刻录机控制,叠加打点到刻录信息(参数无)
        /// </summary>
        BURNING_ADDSIGN,							                        
        /// <summary>
        /// Burner control:self-defined overlay (The string ended with '\0'. Max length is 1024 bytes. Use '\n' to Enter)
        /// 刻录机控制,自定义叠加(以'\0'为结尾的字符串,最大长度1024字节,支持分行,行分隔符'\n')
        /// </summary>
        BURNING_ADDCURSTOMINFO,					                            
        /// <summary>
        /// restore device default setup 
        /// 恢复设备的默认设置
        /// </summary>
        RESTOREDEFAULT,						                                
        /// <summary>
        /// Activate device snapshot
        /// 触发设备抓图
        /// </summary>
        CAPTURE_START,						                                
        /// <summary>
        /// Clear log
        /// 清除日志
        /// </summary>
        CLEARLOG,							                                
        /// <summary>
        /// Activate wireless alarm (IPC series)
        /// 触发无线报警(IPC产品)
        /// </summary>
        TRIGGER_ALARM_WIRELESS = 200,			                            
        /// <summary>
        /// Mark important record
        /// 标识重要录像文件
        /// </summary>
        MARK_IMPORTANT_RECORD,					                            
        /// <summary>
        /// Network hard disk partition	
        /// 网络硬盘分区
        /// </summary>
        DISK_SUBAREA, 						                                
        /// <summary>
        /// Annex burning
        /// 刻录机控制,附件刻录
        /// </summary>
        BURNING_ATTACH,							                            
        /// <summary>
        /// Burn Pause
        /// 刻录暂停
        /// </summary>
        BURNING_PAUSE,							                            
        /// <summary>
        /// Burn Resume
        /// 刻录继续
        /// </summary>
        BURNING_CONTINUE,						                            
        /// <summary>
        /// Burn Postponed
        /// 刻录顺延
        /// </summary>
        BURNING_POSTPONE,						                            
        /// <summary>
        /// OEM control
        /// 报停控制
        /// </summary>
        OEMCTRL,							                                
        /// <summary>
        /// Start to device backup
        /// 设备备份开始
        /// </summary>
        BACKUP_START,							                            
        /// <summary>
        /// Stop to device backup
        /// 设备备份停止
        /// </summary>
        BACKUP_STOP,								                        
        /// <summary>
        /// Add WIFI configuration manually for car device
        /// 车载手动增加WIFI配置
        /// </summary>
        VIHICLE_WIFI_ADD,						                            
        /// <summary>
        /// Delete WIFI configuration manually for car device
        /// 车载手动删除WIFI配置
        /// </summary>
        VIHICLE_WIFI_DEC,						                            
        /// <summary>
        /// Start to buzzer control 
        /// 蜂鸣器控制开始
        /// </summary>
        BUZZER_START,                                                       
        /// <summary>
        /// Stop to buzzer control
        /// 蜂鸣器控制结束
        /// </summary>
        BUZZER_STOP,                                                        
        /// <summary>
        /// Reject User
        /// 剔除用户
        /// </summary>
        REJECT_USER,                                                        
        /// <summary>
        /// Shield User
        /// 屏蔽用户
        /// </summary>
        SHIELD_USER,                                                        
        /// <summary>
        /// Rain Brush
        /// 智能交通, 雨刷控制
        /// </summary>
        RAINBRUSH,                                                          
        /// <summary>
        /// manual snap (struct NET_MANUAL_SNAP_PARAMETER)
        /// 智能交通, 手动抓拍 (对应结构体NET_MANUAL_SNAP_PARAMETER)
        /// </summary>
        MANUAL_SNAP,                                                        
        /// <summary>
        /// manual ntp time adjust
        /// 手动NTP校时
        /// </summary>
        MANUAL_NTP_TIMEADJUST,                                              
        /// <summary>
        /// navigation info and note
        /// 导航信息和短消息
        /// </summary>
        NAVIGATION_SMS,                                                    
        /// <summary>
        /// route info
        /// 路线点位信息
        /// </summary>
        ROUTE_CROSSING,                                                     
        /// <summary>
        /// backup device format
        /// 格式化备份设备
        /// </summary>
        BACKUP_FORMAT,							                            
        /// <summary>
        /// local preview split
        /// 控制设备端本地预览分割
        /// </summary>
        DEVICE_LOCALPREVIEW_SLIPT,                                          
        /// <summary>
        /// RAID init
        /// RAID初始化
        /// </summary>
        INIT_RAID,							                                
        /// <summary>
        /// RAID control
        /// RAID操作
        /// </summary>
        RAID,								                                
        /// <summary>
        /// sapredisk control
        /// 热备盘操作
        /// </summary>
        SAPREDISK,							                                
        /// <summary>
        /// wifi connect
        /// 手动发起WIFI连接
        /// </summary>
        WIFI_CONNECT,							                            
        /// <summary>
        /// wifi disconnect
        /// 手动断开WIFI连接
        /// </summary>
        WIFI_DISCONNECT,							                        
        /// <summary>
        /// Arm/disarm operation
        /// 布撤防操作
        /// </summary>
        ARMED,                                                              
        /// <summary>
        /// IP modify
        /// 修改前端IP
        /// </summary>
        IP_MODIFY,                                                          
        /// <summary>
        /// wps connect wifi
        /// wps连接wifi
        /// </summary>
        WIFI_BY_WPS,                                                        
        /// <summary>
        /// format pattion
        /// 格式化分区
        /// </summary>
        FORMAT_PATITION,					                                
        /// <summary>
        /// eject storage device
        /// 手动卸载设备
        /// </summary>
        EJECT_STORAGE,						                                
        /// <summary>
        /// load storage device
        /// 手动装载设备
        /// </summary>
        LOAD_STORAGE,						                                
        /// <summary>
        /// close burner
        /// 关闭刻录机光驱门
        /// </summary>
        CLOSE_BURNER,                                                       
        /// <summary>
        /// eject burner
        /// 弹出刻录机光驱门
        /// </summary>
        EJECT_BURNER,                                                       
        /// <summary>
        /// alarm elimination
        /// 消警
        /// </summary>
        CLEAR_ALARM,						                                
        /// <summary>
        /// TV wall information display
        /// 电视墙信息显示
        /// </summary>
        MONITORWALL_TVINFO,					                                
        /// <summary>
        /// start Intelligent VIDEO analysis
        /// 开始视频智能分析
        /// </summary>
        START_VIDEO_ANALYSE,                                                
        /// <summary>
        /// STOP intelligent VIDEO analysis
        /// 停止视频智能分析
        /// </summary>
        STOP_VIDEO_ANALYSE,                                                 
        /// <summary>
        /// Controlled start equipment upgrades, independently complete the upgrade process by the equipment do not need to upgrade file
        /// 控制启动设备升级,由设备独立完成升级过程,不需要传输升级文件
        /// </summary>
        UPGRADE_DEVICE,                                                     
        /// <summary>
        /// Multi-channel preview playback channel switching
        /// 切换多通道预览回放的通道
        /// </summary>
        MULTIPLAYBACK_CHANNALES,                                            
        /// <summary>
        /// Turn on the switch power supply timing device output
        /// 电源时序器打开开关量输出口
        /// </summary>
        SEQPOWER_OPEN,						                                
        /// <summary>
        /// Close the switch power supply timing device output
        /// 电源时序器关闭开关量输出口
        /// </summary>
        SEQPOWER_CLOSE,						                                
        /// <summary>
        /// Power timing group open the switch quantity output
        /// 电源时序器打开开关量输出口组
        /// </summary>
        SEQPOWER_OPEN_ALL,					                                
        /// <summary>
        /// Power sequence set close the switch quantity output
        /// 电源时序器关闭开关量输出口组
        /// </summary>
        SEQPOWER_CLOSE_ALL,					                                
        /// <summary>
        /// PROJECTOR up
        /// 投影仪上升
        /// </summary>
        PROJECTOR_RISE,						                                
        /// <summary>
        /// PROJECTOR drop
        /// 投影仪下降
        /// </summary>
        PROJECTOR_FALL,						                                
        /// <summary>
        /// PROJECTOR stop
        /// 投影仪停止
        /// </summary>
        PROJECTOR_STOP,						                                
        /// <summary>
        /// INFRARED buttons
        /// 红外按键
        /// </summary>
        INFRARED_KEY,						                                
        /// <summary>
        /// Device START playback of audio file
        /// 设备开始播放音频文件
        /// </summary>
        START_PLAYAUDIO,					                                
        /// <summary>
        /// Equipment stop playback of audio file
        /// 设备停止播放音频文件
        /// </summary>
        STOP_PLAYAUDIO,						                                
        /// <summary>
        /// open the warning signal
        /// 开启警号
        /// </summary>
        START_ALARMBELL,					                                
        /// <summary>
        /// Close the warning signal
        /// 关闭警号
        /// </summary>
        STOP_ALARMBELL,						                                
        /// <summary>
        /// OPEN ACCESS control
        /// 门禁控制-开门
        /// </summary>
        ACCESS_OPEN,						                                
	    /// <summary>
        /// BYPASS function
        /// 设置旁路功能
	    /// </summary>
        SET_BYPASS,							                                
        /// <summary>
        /// Add records to record set number
        /// 添加记录,获得记录集编号
        /// </summary>
        RECORDSET_INSERT,					                                
        /// <summary>
        /// Update a record of the number
        /// 更新某记录集编号的记录
        /// </summary>
        RECORDSET_UPDATE,					                                
        /// <summary>
        /// According to the record set number to delete a record
        /// 根据记录集编号删除某记录
        /// </summary>
        RECORDSET_REMOVE,					                                
        /// <summary>
        /// Remove all RECORDSET information
        /// 清除所有记录集信息
        /// </summary>
        RECORDSET_CLEAR,					                                
        /// <summary>
        /// Entrance guard control - CLOSE
        /// 门禁控制-关门
        /// </summary>
        ACCESS_CLOSE,						                                
        /// <summary>
        /// Alarm sub system activation setup
        /// 报警子系统激活设置
        /// </summary>
        ALARM_SUBSYSTEM_ACTIVE_SET,			                                
        /// <summary>
        /// Disable device open gateway
        /// 禁止设备端开闸
        /// </summary>
        FORBID_OPEN_STROBE,                                                 
        /// <summary>
        /// Enable gateway(corresponding to structure  NET_CTRL_OPEN_STROBE)
        /// 开启道闸(对应结构体 NET_CTRL_OPEN_STROBE)
        /// </summary>
        OPEN_STROBE,                                                        
        /// <summary>
        /// Talk no response
        /// 对讲拒绝接听
        /// </summary>
        TALKING_REFUSE,                                                     
        /// <summary>
        /// arm-disarm operation
        /// 布撤防操作
        /// </summary>
        ARMED_EX,                                                           
        /// <summary>
        /// Remote talk control
        /// 远程对讲控制
        /// </summary>
        REMOTE_TALK,                                                        
        /// <summary>
        /// Net keyboard control
        /// 网络键盘控制
        /// </summary>
        NET_KEYBOARD = 400,                                                 
        /// <summary>
        /// Open air conditioner
        /// 打开空调
        /// </summary>
        AIRCONDITION_OPEN,                                                  
        /// <summary>
        /// Close air-conditioner
        /// 关闭空调
        /// </summary>
        AIRCONDITION_CLOSE,                                                 
        /// <summary>
        /// Set temperature
        /// 设定空调温度
        /// </summary>
        AIRCONDITION_SET_TEMPERATURE,                                       
        /// <summary>
        /// Adjust temperature
        /// 调节空调温度
        /// </summary>
        AIRCONDITION_ADJUST_TEMPERATURE,                                    
        /// <summary>
        /// Set air work mode
        /// 设置空调工作模式
        /// </summary>
        AIRCONDITION_SETMODE,                                               
        /// <summary>
        /// Set fan mode
        /// 设置空调送风模式
        /// </summary>
        AIRCONDITION_SETWINDMODE,                                           
        /// <summary>
        /// Recover device default and set new protocol
        /// 恢复设备的默认设置新协议
        /// </summary>
        RESTOREDEFAULT_EX,                                                 
        /// <summary>
        /// send event to device
        /// 向设备发送事件
        /// </summary>
        NOTIFY_EVENT,                                                       
        /// <summary>
        /// mute alarm setup
        /// 无声报警设置
        /// </summary>
        SILENT_ALARM_SET,                                                   
        /// <summary>
        /// device start sound report
        /// 设备开始语音播报
        /// </summary>
        START_PLAYAUDIOEX,                                                  
        /// <summary>
        /// device stop sound report
        /// 设备停止语音播报
        /// </summary>
        STOP_PLAYAUDIOEX,                                                   
        /// <summary>
        /// close gateway
        /// 关闭道闸
        /// </summary>
        CLOSE_STROBE,                                                       
        /// <summary>
        /// set parking reservation status
        /// 设置车位预定状态
        /// </summary>
        SET_ORDER_STATE,                                                    
        /// <summary>
        /// add fingerprint record, get record no.
        /// 添加指纹记录,获得记录集编号
        /// </summary>
        RECORDSET_INSERTEX,                                                 
        /// <summary>
        /// update finger print record
        /// 更新指纹记录集编号的记录
        /// </summary>
        RECORDSET_UPDATEEX,                                                 
        /// <summary>
        /// fingerprint collection
        /// 指纹采集
        /// </summary>
        CAPTURE_FINGER_PRINT,                                               
        /// <summary>
        /// Parking lot entrance/exit controller LED setup
        /// 停车场出入口控制器LED设置
        /// </summary>
        ECK_LED_SET,                                                        
        /// <summary>
        /// Intelligent parking system in/out device IC card info import
        /// 智能停车系统出入口机IC卡信息导入
        /// </summary>
        ECK_IC_CARD_IMPORT,                                                 
        /// <summary>
        /// Intelligent parking system in/out device IC card info sync command, receive this command, device will delete original IC card info
        /// 智能停车系统出入口机IC卡信息同步指令,收到此指令后,设备删除原有IC卡信息
        /// </summary>
        ECK_SYNC_IC_CARD,                                                   
        /// <summary>
        /// Delete specific wireless device
        /// 删除指定无线设备
        /// </summary>
        LOWRATEWPAN_REMOVE,                                                 
        /// <summary>
        /// Modify wireless device info
        /// 修改无线设备信息
        /// </summary>
        LOWRATEWPAN_MODIFY,                                                 
        /// <summary>
        /// Set up the vehicle spot information of the machine at the passageway of the intelligent parking system
        /// 智能停车系统出入口机设置车位信息
        /// </summary>
        ECK_SET_PARK_INFO,                                                  
        /// <summary>
        /// hang up the video phone
        /// 挂断视频电话
        /// </summary>
        VTP_DISCONNECT,                                                     
        /// <summary>
        /// the update of the remote multimedia files
        /// 远程投放多媒体文件更新
        /// </summary>
        UPDATE_FILES,                                                       
        /// <summary>
        /// Save up the relationship between the hyponymy matrixes
        /// 保存上下位矩阵输出关系
        /// </summary>
        MATRIX_SAVE_SWITCH,                                                 
        /// <summary>
        /// recover the relationship between the hyponymy matrixes
        /// 恢复上下位矩阵输出关系
        /// </summary>
        MATRIX_RESTORE_SWITCH,                                              
        /// <summary>
        /// video talk phone divert ack
        /// 呼叫转发响应
        /// </summary>
        VTP_DIVERTACK,                                                      
        /// <summary>
        /// Rain-brush brush one time, efficient when set as manual mode
        /// 雨刷来回刷一次,雨刷模式配置为手动模式时有效
        /// </summary>
        RAINBRUSH_MOVEONCE,                                                 
        /// <summary>
        /// Rain-brush brush cyclic, efficient when set as manal mode
        /// 雨刷来回循环刷,雨刷模式配置为手动模式时有效
        /// </summary>
        RAINBRUSH_MOVECONTINUOUSLY,                                         
        /// <summary>
        /// Rain-brush stop, efficient when set as manal mode
        /// 雨刷停止刷,雨刷模式配置为手动模式时有效
        /// </summary>
        RAINBRUSH_STOPMOVE,                                                 
        /// <summary>
        /// affirm the alarm event
        /// 报警事件确认
        /// </summary>
        ALARM_ACK,                                                          
        /// <summary>
        /// Batch import record set info
        /// 批量导入记录集信息
        /// </summary>
        RECORDSET_IMPORT,                                                    
        /// <summary>
        /// Enable or disable thermal shutter
        /// 设置热成像快门启用/禁用
        /// </summary>
        THERMO_GRAPHY_ENSHUTTER = 0x10000,                                  
        /// <summary>
        /// set the OSD of the temperature measurement item to be highlighted
        /// 设置测温项的osd为高亮
        /// </summary>
        RADIOMETRY_SETOSDMARK,                                               
        /// <summary>
        /// Enable audio record and get audio name
        /// 开启音频录音并得到录音名
        /// </summary>
        AUDIO_REC_START_NAME,                                               
        /// <summary>
        /// Close audio file and return file name
        /// 关闭音频录音并返回文件名称
        /// </summary>
        AUDIO_REC_STOP_NAME,                                                
        /// <summary>
        /// Manual snap
        /// 即时抓图
        /// </summary>
        SNAP_MNG_SNAP_SHOT,                                                 
        /// <summary>
        /// Forcedly sync buffer data to the database and close the database
        /// 强制同步缓存数据到数据库并关闭数据库
        /// </summary>
        LOG_STOP,                                                           
        /// <summary>
        /// Resume database
        /// 恢复数据库
        /// </summary>
        LOG_RESUME,                                                         
        /// <summary>
        /// Add a POS device
        /// 增加一个Pos设备
        /// </summary>
        POS_ADD,                                                            
        /// <summary>
        /// Del a POS device
        /// 删除一个Pos设备
        /// </summary>
        POS_REMOVE,                                                         
        /// <summary>
        /// Del several POS device
        /// 批量删除Pos设备
        /// </summary>
        POS_REMOVE_MULTI,                                                   
        /// <summary>
        /// Modify a POS device
        /// 修改一个Pos设备
        /// </summary>
        POS_MODIFY,                                                         
        /// <summary>
        /// Trigger alarm with sound
        /// 触发有声报警
        /// </summary>
        SET_SOUND_ALARM,                                                    
        /// <summary>
        /// audiomatrix silence
        /// 音频举证一键静音控制
        /// </summary>
        AUDIO_MATRIX_SILENCE,				                                
        /// <summary>
        /// manual upload picture
        /// 设置手动上传
        /// </summary>
        MANUAL_UPLOAD_PICTURE,                                              
        /// <summary>
        /// reboot network decoding device
        /// 重启网络解码设备
        /// </summary>
        REBOOT_NET_DECODING_DEV,                                            
        /// <summary>
        /// ParkingControl about setting IC Sender 
        /// ParkingControl 设置发卡设备
        /// </summary>
        SET_IC_SENDER,						                                
        /// <summary>
        /// set the media type ,e.g. audio only,video only , audio & video
        /// 设置监视码流组成,如仅音频,仅视频,音视频
        /// </summary>
        SET_MEDIAKIND,                                                      
        /// <summary>
        /// Add wireless device info
        /// 增加无线设备信息
        /// </summary>
        LOWRATEWPAN_ADD,                                                    
        /// <summary>
        /// remove all the wireless device info
        /// 删除所有的无线设备信息
        /// </summary>
        LOWRATEWPAN_REMOVEALL,                                              
        /// <summary>
        /// Set the work mode of door
        /// 设置门锁工作模式
        /// </summary>
        SET_DOOR_WORK_MODE,                                                 
        /// <summary>
        /// Test Mail
        /// 测试邮件
        /// </summary>
        TEST_MAIL,
        /// <summary>
        /// Control smart switch
        /// 控制智能开关
        /// </summary>
        CONTROL_SMART_SWITCH,                  
        /// <summary>
        /// Set the work mode of the detector
        /// 设置探测器的工作模式 
        /// </summary>
        LOWRATEWPAN_SETWORKMODE,          	                                      
    }

    /// <summary>
    /// Manual snap parameter sturct
    /// 手动抓拍参数
    /// </summary>
    public struct NET_MANUAL_SNAP_PARAMETER
    {
        /// <summary>
        /// snap channel,start with 0
        /// 抓图通道,从0开始
        /// </summary>
        public int nChannel;                                              
        /// <summary>
        /// snap sequence string
        /// 抓图序列号字符串
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string bySequence;	                                      
        /// <summary>
        /// reserved
        /// 保留字段
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 60)]
        public byte[] byReserved;                                         
    }
    #region<<Monitor Wall>>
    /// <summary>
    /// Matrix sub card list
    /// 矩阵子卡列表
    /// </summary>
    public struct NET_MATRIX_CARD_LIST
    {
        /// <summary>
        /// struct size
        /// 结构体大小
        /// </summary>
        public uint dwSize;                                               
        /// <summary>
        /// count
        /// 子卡数量
        /// </summary>
        public int nCount;                                                
        /// <summary>
        /// card info
        /// 子卡列表
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public NET_MATRIX_CARD[] stuCards;                                
    }

    /// <summary>
    /// Matrix sub card info
    /// 矩阵子卡信息
    /// </summary>
    public struct NET_MATRIX_CARD
    {
        /// <summary>
        /// struct size
        /// 结构体大小
        /// </summary>
        public  uint				dwSize;
        /// <summary>
        /// Valid or not
        /// 是否有效
        /// </summary>
        public	bool				bEnable;					           
        /// <summary>
        /// Sub card type
        /// 子卡类型
        /// </summary>
        public	uint				dwCardType;					           
        /// <summary>
        /// Signal interface type, "CVBS", "VGA", "DVI"...
        /// 信号接口类型, "CVBS", "VGA", "DVI"...
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public	string		    	szInterface;	                       
        /// <summary>
        /// Device IP or domain name. The sub card that has no network conneciton can be null
        /// 设备ip或域名, 无网络接口的子卡可以为空
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public	string		    	szAddress;	                            
        /// <summary>
        /// Port No. The sub card that has no network conneciton can be 0
        /// 端口号, 无网络接口的子卡可以为0
        /// </summary>
        public	int			    	nPort;						            
        /// <summary>
        /// Definition. 0=standard definition. 1=High definition
        /// 清晰度, 0=标清, 1=高清
        /// </summary>
        public	int					nDefinition;				            
        /// <summary>
        /// Video input channel amount
        /// 视频输入通道数
        /// </summary>
        public	int					nVideoInChn;				            
        /// <summary>
        /// Audio input channel amount
        /// 音频输入通道数
        /// </summary>
        public	int					nAudioInChn;				            
        /// <summary>
        /// Video output channel amount
        /// 视频输出通道数
        /// </summary>
        public	int					nVideoOutChn;				            
        /// <summary>
        /// Audio output channel amount
        /// 音频输出通道数
        /// </summary>
        public	int				    nAudioOutChn;				            
        /// <summary>
        /// Video encode channel amount
        /// 视频编码通道数
        /// </summary>
        public	int			    	nVideoEncChn;				            
        /// <summary>
        /// Audio encode channel amount
        /// 音频编码通道数
        /// </summary>
        public	int				    nAudioEncChn;				            
        /// <summary>
        /// Video decode channel amount
        /// 视频解码通道数
        /// </summary>
        public	int			    	nVideoDecChn;				            
        /// <summary>
        /// Audio decode channel amount
        /// 音频解码通道数
        /// </summary>
        public	int			    	nAudioDecChn;				            
        /// <summary>
        /// Status: 0-OK, 1-no respond, 2-network disconnection, 3-conflict, 4-upgrading now
        /// 状态: -1-未知, 0-正常, 1-无响应, 2-网络掉线, 3-冲突, 4-正在升级, 5-链路状态异常, 6-子板背板未插好, 7-程序版本出错
        /// </summary>
        public	int					nStauts;					             
        /// <summary>
        /// COM amount
        /// 串口数
        /// </summary>
        public	int					nCommPorts;					             
        /// <summary>
        /// Video input channel min value
        /// 视频输入通道号最小值
        /// </summary>
        public	int					nVideoInChnMin;				             
        /// <summary>
        /// Video input channel max value
        /// 视频输入通道号最大值
        /// </summary>
        public	int					nVideoInChnMax;				             
        /// <summary>
        /// Audio input channel min value
        /// 音频输入通道号最小值
        /// </summary>
        public	int					nAudioInChnMin;				             
        /// <summary>
        /// Audio input channel max value
        /// 音频输入通道号最大值
        /// </summary>
        public	int					nAudioInChnMax;				             
        /// <summary>
        /// Video output channel min value
        /// 视频输出通道号最小值
        /// </summary>
        public	int					nVideoOutChnMin;			             
        /// <summary>
        /// Video output channel max value
        /// 视频输出通道号最大值
        /// </summary>
        public	int					nVideoOutChnMax;			             
        /// <summary>
        /// Audio output channel min value
        /// 音频输出通道号最小值
        /// </summary>
        public	int					nAudioOutChnMin;			             
        /// <summary>
        /// Audio output channel max value
        /// 音频输出通道号最大值
        /// </summary>
        public	int					nAudioOutChnMax;			             	
        /// <summary>
        /// Video encode channel min value
        /// 视频编码通道号最小值
        /// </summary>
        public	int					nVideoEncChnMin;			             
        /// <summary>
        /// Video encode channel max value
        /// 视频编码通道号最大值
        /// </summary>
        public	int					nVideoEncChnMax;			             
        /// <summary>
        /// Audio encode channel min value
        /// 音频编码通道号最小值
        /// </summary>
        public	int					nAudioEncChnMin;			             
        /// <summary>
        /// Audio encode channel max value
        /// 音频编码通道号最大值
        /// </summary>
        public	int					nAudioEncChnMax;			             
        /// <summary>
        /// Video decode channel min value
        /// 视频解码通道号最小值
        /// </summary>
        public	int					nVideoDecChnMin;			             
        /// <summary>
        /// Video decode channel max value
        /// 视频解码通道号最大值
        /// </summary>
        public	int					nVideoDecChnMax;			             
        /// <summary>
        /// Audio decode channel min value
        /// 音频解码通道号最小值
        /// </summary>
        public	int					nAudioDecChnMin;			             
        /// <summary>
        /// Audio decode channel max value
        /// 音频解码通道号最大值
        /// </summary>
        public	int					nAudioDecChnMax;			             
        /// <summary>
        /// number of cascade channel
        /// 级联通道数
        /// </summary>
        public	int					nCascadeChannels;			             
        /// <summary>
        /// cascade channel bitrate (Mbps)
        /// 级联通道带宽, 单位Mbps
        /// </summary>
        public	int					nCascadeChannelBitrate;		             
        /// <summary>
        /// Alarm input channel number 
        /// 报警输入通道数
        /// </summary>
        public	int					nAlarmInChnCount;			             
        /// <summary>
        /// Alarm input channel number minimum value
        /// 报警输入通道号最小值
        /// </summary>
        public	int					nAlarmInChnMin;				              
        /// <summary>
        /// Alarm input channel number maximum value
        /// 报警输入通道号最大值
        /// </summary>
        public	int					nAlarmInChnMax;				              
        /// <summary>
        /// Alarm output channel number 
        /// 报警输出通道数
        /// </summary>
        public	int					nAlarmOutChnCount;			             
        /// <summary>
        /// Alarm output channel number minimum value
        /// 报警输入通道号最小值
        /// </summary>
        public	int					nAlarmOutChnMin;			             
        /// <summary>
        /// Alarm output channel number maximum value
        /// 报警输入通道号最大值
        /// </summary>
        public	int					nAlarmOutChnMax;			             
        /// <summary>
        /// Intelligent analysis of channel number 
        /// 智能分析通道数
        /// </summary>
        public	int					nVideoAnalyseChnCount;		             
        /// <summary>
        /// Intelligent analysis of channel number minimum value
        /// 智能分析通道号最小值
        /// </summary>
        public	int					nVideoAnalyseChnMin;		             
        /// <summary>
        /// Intelligent analysis of channel number maximum value
        /// 智能分析通道号最大值
        /// </summary>
        public	int					nVideoAnalyseChnMax;		             
        /// <summary>
        /// minimum value of serial port number
        /// 串口号最小值
        /// </summary>
        public	int					nCommPortMin;				               
        /// <summary>
        /// maximum value of serial port number
        /// 串口号最大值
        /// </summary>
        public	int					nCommPortMax;				             
        /// <summary>
        /// Version info
        /// 版本信息
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public  string              szVersion;                               
        /// <summary>
        /// compile time
        /// 编译时间
        /// </summary>
        public  NET_TIME            stuBuildTime;                            
        /// <summary>
        /// BIOS Version
        /// BIOS版本号
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public  string              szBIOSVersion;                           
        /// <summary>
        /// MAC address
        /// MAC地址
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public  string				szMAC;					                 
    }

    /// <summary>
    /// composite screen channel information
    /// 融合屏通道信息
    /// </summary>
    public struct NET_COMPOSITE_CHANNEL
    {
        /// <summary>
        /// struct size
        /// 结构体大小
        /// </summary>
	    public  uint 				dwSize;
        /// <summary>
        /// monitor wall name
        /// 电视墙名称
        /// </summary>
	    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public  string				szMonitorWallName;	                    
        /// <summary>
        /// composite ID
        /// 融合屏ID
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public  string				szCompositeID;		                   
        /// <summary>
        /// virtual channel
        /// 虚拟通道号
        /// </summary>
	    public  int					nVirtualChannel;						
    }

    /// <summary>
    /// Split mode
    /// 分割模式
    /// </summary>
    public enum EM_SPLIT_MODE
    {
        /// <summary>
        /// 1-window
        /// 1画面
        /// </summary>
    	SPLIT_1 = 1,						                                
        /// <summary>
        /// 2-window
        /// 2画面
        /// </summary>
    	SPLIT_2 = 2, 						                                
        /// <summary>
        /// 4-window
        /// 4画面
        /// </summary>
    	SPLIT_4 = 4, 						                                
        /// <summary>
        /// 6-window
        /// 6画面
        /// </summary>
    	SPLIT_6 = 6, 						                                
        /// <summary>
        /// 8-window
        /// 8画面
        /// </summary>
    	SPLIT_8 = 8, 						                                
        /// <summary>
        /// 9-window
        /// 9画面
        /// </summary>
    	SPLIT_9 = 9, 						                                
        /// <summary>
        /// 12-window
        /// 12画面
        /// </summary>
    	SPLIT_12 = 12, 						                                
        /// <summary>
        /// 16-window
        /// 16画面
        /// </summary>
    	SPLIT_16 = 16, 						                                
        /// <summary>
        /// 20-window
        /// 20画面
        /// </summary>
    	SPLIT_20 = 20, 						                                
        /// <summary>
        /// 25-window
        /// 25画面
        /// </summary>
    	SPLIT_25 = 25, 						                                
        /// <summary>
        /// 36-window
        /// 36画面
        /// </summary>
    	SPLIT_36 = 36, 						                                
        /// <summary>
        /// 64-window
        /// 64画面
        /// </summary>
    	SPLIT_64 = 64, 						                                
        /// <summary>
        /// 144-window
        /// 144画面
        /// </summary>
    	SPLIT_144 = 144, 					                                
        /// <summary>
        /// PIP mode.1-full screen+1-small window
        /// 画中画模式, 1个全屏大画面+1个小画面窗口
        /// </summary>
    	PIP_1 = 1000 + 1,		                                            
        /// <summary>
        /// PIP mode.1-full screen+3-small window
        /// 画中画模式, 1个全屏大画面+3个小画面窗口
        /// </summary>
    	PIP_3 = 1000 + 3,		                                            
        /// <summary>
        /// free open window mode,are free to create,close, window position related to the z axis
        /// 自由开窗模式,可以自由创建、关闭窗口,自由设置窗口位置和Z轴次序
        /// </summary>
    	SPLIT_FREE = 1000 * 2,	                                          
        /// <summary>
        /// integration of a split screen
        /// 融合屏成员1分割
        /// </summary>
    	COMPOSITE_SPLIT_1 = 1000 * 3 + 1,	                              
        /// <summary>
        /// fusion of four split screen
        /// 融合屏成员4分割
        /// </summary>
    	COMPOSITE_SPLIT_4 = 1000 * 3 + 4,	                              
        /// <summary>
        /// 3-window
        /// 3画面
        /// </summary>
    	SPLIT_3  = 10,                                                    
        /// <summary>
        /// 3-window(bottom) 
        /// 3画面倒品
        /// </summary>
    	SPLIT_3B = 11,						                              
    }

    /// <summary>
    /// split display type
    /// 分割显示类型
    /// </summary>
    public enum EM_SPLIT_DISPLAY_TYPE
    {
        /// <summary>
        /// Common display types
        /// 普通显示类型
        /// </summary>
        GENERAL=1,                                                          
        /// <summary>
        /// PIP Display Type
        /// 画中画显示类型
        /// </summary>
        PIP=2,                                                              
        /// <summary>
        /// Custom Display Type
        /// 自由组合分割模式
        /// </summary>
        CUSTOM=3,                                                           
    }

    /// <summary>
    /// Split capability
    /// 分割能力
    /// </summary>
    public struct NET_SPLIT_CAPS
    {
        /// <summary>
        /// struct size
        /// 结构体大小
        /// </summary>
        public uint				    dwSize;
        /// <summary>
        /// The split amount supported
        /// 支持的分割模式数量
        /// </summary>
	    public int					nModeCount;				               
        /// <summary>
        /// The split mode supported
        /// 支持的分割模式
        /// </summary>
	    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public EM_SPLIT_MODE[]		emSplitMode;	                       
        /// <summary>
        /// Max display source allocation amount
        /// 最大显示源配置数
        /// </summary>
	    public int				    nMaxSourceCount;		               
        /// <summary>
        /// count of free window support
        /// 支持的最大自由开窗数目
        /// </summary>
	    public int					nFreeWindowCount;		               
        /// <summary>
        /// support collection
        /// 是否支持区块收藏
        /// </summary>
	    public bool				    bCollectionSupported;	               
        /// <summary>
        /// mask means multiple display types, see EM_SPLIT_DISPLAY_TYPE, under each mode in note , displayed content depends on "PicInPic", each mode displayed content by NVD old rule, as depending on DisChntext, Compatible, no this item, default is normal display type as"General"
        /// 掩码表示多个显示类型,具体见EM_SPLIT_DISPLAY_TYPE（注释各模式下显示内容由"PicInPic"决定, 各模式下显示内容按NVD旧有规则决定（即DisChn字段决定）。兼容,没有这一个项时,默认为普通显示类型,即"General"）
        /// </summary>
        public uint                 dwDisplayType;                         
        /// <summary>
        /// PIP support split mode quantity
        /// 画中画支持的分割模式数量
        /// </summary>
        public int                  nPIPModeCount;                         
        /// <summary>
        /// PIP supported split mode
        /// 画中画支持的分割模式
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public EM_SPLIT_MODE[]      emPIPSplitMode;                        
        /// <summary>
        /// supported input channel
        /// 支持的输入通道
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public int[]                nInputChannels;                        
        /// <summary>
        /// supported input channel quantity, 0 means no input channel limit
        /// 支持的输入通道个数, 0表示没有输入通道限制
        /// </summary>
        public int                  nInputChannelCount;                    
        /// <summary>
        /// enable split mode quantity
        /// 启动分割模式数量
        /// </summary>
        public int                  nBootModeCount;                        
        /// <summary>
        /// support enable default video split mode
        /// 支持的启动默认画面分割模式
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public EM_SPLIT_MODE[]      emBootMode;                            
    }

    /// <summary>
    /// Split mode info
    /// 一屏幕的分割模式信息
    /// </summary>
    public struct NET_SPLIT_MODE_INFO
    {
        /// <summary>
        /// struct size
        /// 结构体大小
        /// </summary>
        public uint dwSize;                                                
        /// <summary>
        /// Split mode
        /// 分割模式
        /// </summary>
        public EM_SPLIT_MODE emSplitMode;			                       
        /// <summary>
        /// Group SN
        /// 分组序号
        /// </summary>
        public int nGroupID;				                               
        /// <summary>
        /// display type, see EM_SPLIT_DISPLAY_TYPE, under each mode in note , displayed content depends on "PicInPic", each mode displayed content by NVD old rule, as depending on DisChntext, . Compatible, no this item, default is normal display type as"General"
        /// 显示类型；具体见EM_SPLIT_DISPLAY_TYPE（注释各模式下显示内容由"PicInPic"决定, 各模式下显示内容按NVD旧有规则决定（即DisChn字段决定）。兼容,没有这一个项时,默认为普通显示类型,即"General"）
        /// </summary>
        public uint dwDisplayType;                                        
    }

    /// <summary>
    /// OpenSplitWindow's interface input param(open window)
    /// OpenSplitWindow接口输入参数(开窗)
    /// </summary>
    public struct NET_IN_SPLIT_OPEN_WINDOW
    {
        /// <summary>
        /// struct size
        /// 结构体大小
        /// </summary>
        public uint     dwSize;
        /// <summary>
        /// channel no.
        /// 通道号(屏号)
        /// </summary>
        public int      nChannel;					                       
        /// <summary>
        /// windon position, 0~8192
        /// 窗口位置, 0~8192
        /// </summary>
        public NET_RECT stuRect;					                       
        /// <summary>
        /// coordinate whether meet the confitions
        /// 坐标是否满足直通条件, 直通是指拼接屏方式下,此窗口区域正好为物理屏区域
        /// </summary>
        public bool     bDirectable;				                       
    }

    /// <summary>
    /// OpenSplitWindow's interface output param(open window)
    /// OpenSplitWindow接口输出参数(开窗)
    /// </summary>
    public struct NET_OUT_SPLIT_OPEN_WINDOW
    {
        /// <summary>
        /// struct size
        /// 结构体大小
        /// </summary>
        public uint		dwSize;                                             
        /// <summary>
        /// window ID
        /// 窗口序号
        /// </summary>
	    public uint		nWindowID;					                        
        /// <summary>
        /// window order
        /// 窗口次序
        /// </summary>
	    public uint		nZOrder;					                        
    }

    /// <summary>
    /// MatrixGetCameras's interface input param
    /// MatrixGetCameras接口的输入参数
    /// </summary>
    public struct NET_IN_MATRIX_GET_CAMERAS
    {
        /// <summary>
        /// struct size 
        /// 结构体大小
        /// </summary>
        public uint     dwSize;                                             
    }

    /// <summary>
    /// MatrixGetCameras's interface output param
    /// MatrixGetCameras接口的输出参数
    /// </summary>
    public struct NET_OUT_MATRIX_GET_CAMERAS
    {
        /// <summary>
        /// struct size 
        /// 结构体大小
        /// </summary>
        public uint			dwSize;
        /// <summary>
        /// size of source array,the space application by the user,apply to sizeof(NET_MATRIX_CAMERA_INFO)*nMaxCameraCount
        /// 显示源信息数组, 用户分配内存,大小为sizeof(NET_MATRIX_CAMERA_INFO)*nMaxCameraCount
        /// </summary>
	    public IntPtr       pstuCameras;		                           
        /// <summary>
        /// count
        /// 显示源数组大小
        /// </summary>
	    public int			nMaxCameraCount;	                            
        /// <summary>
        /// return count
        /// 返回的显示源数量
        /// </summary>
	    public int			nRetCameraCount;	                           
    }

    /// <summary>
    /// available according to the source of information
    /// 可用的显示源信息
    /// </summary>
    public struct NET_MATRIX_CAMERA_INFO
    {
        /// <summary>
        /// struct size 
        /// 结构体大小
        /// </summary>
	    public uint				    dwSize;                                 
        /// <summary>
        /// name
        /// 名称
        /// </summary>
	    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string				szName;		                            
        /// <summary>
        /// device ID
        /// 设备ID
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	    public string				szDevID;		                      
        /// <summary>
        /// control ID
        /// 控制ID
        /// </summary>
	    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]	    
        public string				szControlID;	                      
        /// <summary>
        /// channel ID, DeviceID is unique
        /// 通道号, DeviceID设备内唯一
        /// </summary>
	    public int					nChannelID;						      
        /// <summary>
        /// unique channel
        /// 设备内统一编号的唯一通道号
        /// </summary>
	    public int					nUniqueChannel;					      
        /// <summary>
        /// support remote device or not
        /// 是否远程设备
        /// </summary>
	    public bool				    bRemoteDevice;					      
        /// <summary>
        /// info of remote device
        /// 远程设备信息
        /// </summary>
	    public NET_REMOTE_DEVICE	stuRemoteDevice;				      
        /// <summary>
        /// stream type
        /// 视频码流类型
        /// </summary>
	    public EM_STREAM_TYPE       emStreamType;                         
        /// <summary>
        /// Channel Types 
        /// 通道类型
        /// </summary>
        public EM_LOGIC_CHN_TYPE    emChannelType;                          
    }

    /// <summary>
    /// video stream type
    /// 视频码流类型
    /// </summary>
    public enum EM_STREAM_TYPE
    {
        /// <summary>
        /// Others
        /// 其它
        /// </summary>
        ERR,                                                               
        /// <summary>
        /// Main stream
        /// 主码流
        /// </summary>
        MAIN,					                                           
        /// <summary>
        /// Extra stream 1
        /// 辅码流1
        /// </summary>
        EXTRA_1,				                                           
        /// <summary>
        /// Extra stream 2
        /// 辅码流2
        /// </summary>
        EXTRA_2,				                                           
        /// <summary>
        /// Extra stream 3
        /// 辅码流3
        /// </summary>
        EXTRA_3,				                                           
        /// <summary>
        /// Snap bit stream
        /// 抓图码流
        /// </summary>
        SNAPSHOT,				                                           
        /// <summary>
        /// Object stream
        /// 物体流
        /// </summary>
        OBJECT,				                                               
        /// <summary>
        /// Auto
        /// 自动选择合适码流
        /// </summary>
        AUTO,                                                              
        /// <summary>
        /// Preview
        /// 预览裸数据码流
        /// </summary>
        PREVIEW,                                                           
        /// <summary>
        /// No video stream (audio only)
        /// 无视频码流(纯音频)
        /// </summary>
        NONE,					                                           
    }

    /// <summary>
    /// logic chnnel type
    /// 逻辑通道类型
    /// </summary>
    public enum EM_LOGIC_CHN_TYPE
    {
        /// <summary>
        /// Unknow
        /// 未知
        /// </summary>
        UNKNOWN,                                                           
        /// <summary>
        /// Local channel 
        /// 本地通道
        /// </summary>
        LOCAL,                                                             
        /// <summary>
        /// Remote access channel 
        /// 远程通道
        /// </summary>
        REMOTE,                                                            
        /// <summary>
        /// Synthesis of channel, for the judicial equipment contains picture in picture channel and mixing channel
        /// 合成通道, 对于庭审设备包含画中画通道和混音通道
        /// </summary>
        COMPOSE,                                                           
        /// <summary>
        /// matrix channel, including analog matrix and digital matrix
        /// 模拟矩阵通道
        /// </summary>
        MATRIX,                                                            
        /// <summary>
        /// cascading channel
        /// 级联通道
        /// </summary>
        CASCADE,                                                           
    }

    /// <summary>
    /// remote device
    /// 远程设备
    /// </summary>
    public struct NET_REMOTE_DEVICE
    {
        /// <summary>
        /// struct size 
        /// 结构体大小
        /// </summary>
 	    public uint				dwSize;
        /// <summary>
        /// enable
        /// 使能
        /// </summary>
	    public bool				bEnable;							      
        /// <summary>
        /// IP
        /// IP
        /// </summary>
	    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string			    szIp;		                          
        /// <summary>
        /// username
        /// 用户名
        /// </summary>
	    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
        public string			    szUser;	                              
        /// <summary>
        /// password
        /// 密码
        /// </summary>
	    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
        public string			    szPwd;	    	                      
        /// <summary>
        /// port
        /// 端口
        /// </summary>
	    public int			    	nPort;							      
        /// <summary>
        /// definition. 0-standard definition, 1-high definition
        /// 清晰度, 0-标清, 1-高清
        /// </summary>
	    public int				    nDefinition;					      
        /// <summary>
        /// protocol type
        /// 协议类型
        /// </summary>
	    public EM_DEVICE_PROTOCOL  emProtocol;							  
        /// <summary>
        /// device name
        /// 设备名称
        /// </summary>
	    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string			    szDevName;		                      
        /// <summary>
        /// count channel of video input
        /// 视频输入通道数
        /// </summary>
	    public int					nVideoInputChannels;				  
        /// <summary>
        /// count channel of audio input
        /// 音频输入通道数
        /// </summary>
	    public int					nAudioInputChannels;				  
        /// <summary>
        /// device type, such as IPC, DVR, NVR
        /// 设备类型
        /// </summary>
	    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string				szDevClass;		                      
        /// <summary>
        /// device type, such as IPC-HF3300
        /// 设备具体型号
        /// </summary>
	    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string				szDevType;			                  
        /// <summary>
        /// Http port
        /// Http端口
        /// </summary>
	    public int					nHttpPort;							  
        /// <summary>
        /// max count of video input
        /// 视频输入通道最大数
        /// </summary>
	    public int					nMaxVideoInputCount;				  
        /// <summary>
        /// return count
        /// 返回实际通道个数
        /// </summary>
	    public int					nRetVideoInputCount;				  
        /// <summary>
        /// max count of video input, user malloc the memory,apply to sizeof(NET_VIDEO_INPUTS)*nMaxVideoInputCount
        /// 视频输入通道信息,由用户申请内存，大小为sizeof(NET_VIDEO_INPUTS)*nMaxVideoInputCount
        /// </summary>
	    public IntPtr	pstuVideoInputs;					               
        /// <summary>
        /// machine address
        /// 设备部署地
        /// </summary>
	    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string				szMachineAddress;	                   
        /// <summary>
        /// serial no.
        /// 设备序列号
        /// </summary>
	    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 48)]
        public string				szSerialNo;		                       
        /// <summary>
        /// Rtsp Port
        /// Rtsp端口
        /// </summary>
        public int                 nRtspPort;                              
        /// <summary>
        /// username
        /// 用户名
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string                szUserEx;                             
        /// <summary>
        /// password  
        /// 密码
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string                szPwdEx;                              
    }

    /// <summary>
    /// Device protocol type
    /// 设备协议类型
    /// </summary>
    public enum EM_DEVICE_PROTOCOL
    {
        /// <summary>
        /// private 2nd protocol
        /// 私有2代协议
        /// </summary>
        PRIVATE2,					                                       
        /// <summary>
        /// private 3rd protocol
        /// 私有3代协议
        /// </summary>
        PRIVATE3,					                                       
        /// <summary>
        /// Onvif
        /// Onvif
        /// </summary>
        ONVIF,						                                       
        /// <summary>
        /// virtual network computer
        /// 虚拟网络计算机
        /// </summary>
        VNC,						                                       
        /// <summary>
        /// Standard TS
        /// 标准TS
        /// </summary>
        TS,                                                                
        /// <summary>
        /// private protocol of private 
        /// 私有协议
        /// </summary>
        PRIVATE = 100,                                                     
        /// <summary>
        /// aebell
        /// 美电贝尔
        /// </summary>
        AEBELL,                                                            
        /// <summary>
        /// panasonic
        /// 松下
        /// </summary>
        PANASONIC,                                                         
        /// <summary>
        /// sony
        /// 索尼
        /// </summary>
        SONY,                                                              
        /// <summary>
        /// Dynacolor
        /// Dynacolor
        /// </summary>
        DYNACOLOR,                                                         
        /// <summary>
        /// tcsw
        /// 天城威视
        /// </summary>
        TCWS,						                                         
        /// <summary>
        /// samsung
        /// 三星
        /// </summary>
        SAMSUNG,                                                            
        /// <summary>
        /// YOKO
        /// YOKO
        /// </summary>
        YOKO,                                                              
        /// <summary>
        /// axis
        /// 安讯视
        /// </summary>
        AXIS,                                                              
        /// <summary>
        /// sanyo
        /// 三洋
        /// </summary>
        SANYO,						                                       
     	/// <summary>
        /// Bosch
        /// Bosch
     	/// </summary>
        BOSH,						                                       
        /// <summary>
        /// Peclo
        /// Peclo
        /// </summary>
        PECLO,						                                       
	    /// <summary>
        /// Provideo
        /// Provideo
	    /// </summary>
        PROVIDEO,					                                       
        /// <summary>
        /// ACTi
        /// ACTi
        /// </summary>
        ACTI,						                                       
        /// <summary>
        /// Vivotek
        /// Vivotek
        /// </summary>
        VIVOTEK,					                                       
	    /// <summary>
        /// Arecont
        /// Arecont
	    /// </summary>
        ARECONT,					                                       
        /// <summary>
        /// PrivateEH
        /// PrivateEH
        /// </summary>
        PRIVATEEH,			                                               
	    /// <summary>
        /// IMatek
        /// IMatek
	    /// </summary>
        IMATEK,					                                             
        /// <summary>
        /// Shany
        /// Shany
        /// </summary>
        SHANY,                                                               
        /// <summary>
        /// videotrec
        /// 动力盈科
        /// </summary>
        VIDEOTREC,                                                           
        /// <summary>
        /// Ura
        /// Ura
        /// </summary>
        URA,						                                         
        /// <summary>
        /// Bticino
        /// Bticino
        /// </summary>
        BITICINO,                                                             
        /// <summary>
        /// Onvif's protocol type, same to NET_PROTOCOL_ONVIF
        /// Onvif协议类型, 同NET_PROTOCOL_ONVIF
        /// </summary>
        ONVIF2,                                                            
        /// <summary>
        /// shepherd
        /// 视霸
        /// </summary>
        SHEPHERD,                                                            
        /// <summary>
        /// yaan
        /// 亚安
        /// </summary>
        YAAN,                                                              
        /// <summary>
        /// Airpop
        /// Airpop
        /// </summary>
        AIRPOINT,					                                         
        /// <summary>
        /// TYCO
        /// TYCO
        /// </summary>
        TYCO,                                                                
        /// <summary>
        /// xunmei
        /// 讯美
        /// </summary>
        XUNMEI,                                                            
        /// <summary>
        /// hikvision
        /// 海康
        /// </summary>
        HIKVISION,                                                           
        /// <summary>
        /// LG
        /// LG
        /// </summary>
        LG,                                                                  
        /// <summary>
        /// aoqiman
        /// 奥奇曼
        /// </summary>
        AOQIMAN,					                                       
        /// <summary>
        /// baokang
        /// 宝康
        /// </summary>
        BAOKANG,                                                             
        /// <summary>
        /// Watchnet
        /// Watchnet
        /// </summary>
        WATCHNET,                                                          
        /// <summary>
        /// Xvision
        /// Xvision
        /// </summary>
        XVISION,                                                           
        /// <summary>
        /// fusitsu
        /// 富士通
        /// </summary>
        FUSITSU,                                                           
        /// <summary>
        /// Canon
        /// Canon
        /// </summary>
        CANON,						                                       
        /// <summary>
        /// GE
        /// GE
        /// </summary>
        GE,							                                       
        /// <summary>
        /// basler
        /// 巴斯勒
        /// </summary>
        Basler,						                                       
        /// <summary>
        /// patro
        /// 帕特罗
        /// </summary>
        Patro,						                                       
        /// <summary>
        /// CPPLUS K series
        /// CPPLUS K系列 
        /// </summary>
        CPKNC,						                                       
	    /// <summary>
        /// CPPLUS R series
        /// CPPLUS R系列  
	    /// </summary>
        CPRNC,						                                       
	    /// <summary>
        /// CPPLUS U series		
        /// CPPLUS U系列  
	    /// </summary>
        CPUNC,						                                       
        /// <summary>
        /// CPPLUS IPC	
        /// CPPLUS IPC
        /// </summary>
        CPPLUS,						                                       
        /// <summary>
        ///  xunmeis,protocal is Onvif	
        /// 讯美s,实际协议为Onvif
        /// </summary>
        XunmeiS,					                                       
	    /// <summary>
        /// GDDW
        /// 广东电网
	    /// </summary>
        GDDW,						                                       
        /// <summary>
        /// PSIA
        /// PSIA
        /// </summary>
        PSIA,                                                                
        /// <summary>
        /// GB2818
        /// GB2818
        /// </summary>
        GB2818,                                                               
        /// <summary>
        /// GDYX
        /// GDYX
        /// </summary>
        GDYX,                                                                
        /// <summary>
        /// others
        /// 由用户自定义
        /// </summary>
        OTHER,                                                             
    }

    /// <summary>
    /// channel info of video input
    /// 视频输入通道信息
    /// </summary>
    public struct NET_VIDEO_INPUTS
    {
        /// <summary>
        /// struct size 
        /// 结构体大小
        /// </summary>
        public 	uint				dwSize;
        /// <summary>
        /// channel name
        /// 通道名称
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public	string				szChnName;		                      
        /// <summary>
        /// enable
        /// 使能
        /// </summary>
        public	bool				bEnable;							  
        /// <summary>
        /// control ID
        /// 控制ID
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public	string				szControlID;		                  
        /// <summary>
        /// main stream url 
        /// 主码流url地址
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public	string				szMainStreamUrl;			          
        /// <summary>
        /// extra stream url
        /// 辅码流url地址
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public	string				szExtraStreamUrl;			          
        /// <summary>
        /// spare main stream address quantity
        /// 备用主码流地址数量
        /// </summary>
        public  int                 nOptionalMainUrlCount;                
        /// <summary>
        /// spare main stream address list. byte[] is 8*260
        /// 备用主码流地址列表
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8 * 260)]
        public  byte[]                szOptionalMainUrls;                 
        /// <summary>
        /// spare sub stream address quantity
        /// 备用辅码流地址数量
        /// </summary>
        public  int                 nOptionalExtraUrlCount;               
        /// <summary>
        /// spare substream address list. byte[] is 8*260   
        /// 备用辅码流地址列表
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8 * 260)]
        public  byte[]                szOptionalExtraUrls;                
    }

    /// <summary>
    /// Display source
    /// 显示源
    /// </summary>
    public struct NET_SPLIT_SOURCE
    {
        /// <summary>
        /// struct size 
        /// 结构体大小
        /// </summary>
	    public uint				dwSize;
        /// <summary>
        /// Enable
        /// 使能
        /// </summary>
	    public bool			    bEnable;						           
        /// <summary>
        /// IP, null means there is no setup.
        /// IP, 空表示没有设置
        /// </summary>
	    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string			    szIp;		                           
        /// <summary>
        /// User name
        /// 用户名, 建议使用szUserEx
        /// </summary>
	    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
        public string			    szUser;	                               
        /// <summary>
        /// Password
        /// 密码, 建议使用szPwdEx
        /// </summary>
	    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
        public string			    szPwd;	    	                       
        /// <summary>
        /// Port
        /// 端口
        /// </summary>
	    public int			    	nPort;							       
        /// <summary>
        /// Channel No.
        /// 通道号
        /// </summary>
	    public int				    nChannelID;						       
        /// <summary>
        /// Video bit stream. -1-auto, 0-main stream, 1-extra stream 1, 2-extra stream 2, 3-extra stream 3
        /// 视频码流, -1-自动, 0-主码流, 1-辅码流1, 2-辅码流2, 3-辅码流3, 4-snap, 5-预览
        /// </summary>
	    public int				    nStreamType;					        
        /// <summary>
        /// Definition, 0-standard definition, 1-high definition
        /// 清晰度, 0-标清, 1-高清
        /// </summary>
	    public int				    nDefinition;					        
        /// <summary>
        /// Protocol type
        /// 协议类型
        /// </summary>
	    public EM_DEVICE_PROTOCOL  emProtocol;							    
        /// <summary>
        /// Device name
        /// 设备名称
        /// </summary>
	    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string			    szDevName;		                        
        /// <summary>
        /// Video input channel amount
        /// 视频输入通道数
        /// </summary>
	    public int					nVideoChannel;						    
        /// <summary>
        /// Audio input channel amount,For decoder only
        /// 音频输入通道数
        /// </summary>
	    public int					nAudioChannel;						    
        /// <summary>
        /// Decoder or not.
        /// 是否是解码器
        /// </summary>
	    public bool				bDecoder;							        
        /// <summary>
        /// 0:TCP;1:UDP;2:multicast
        /// -1: auto, 0：TCP；1：UDP；2：组播
        /// </summary>
	    public byte				byConnType;							        
        /// <summary>
        /// 0:connect directly; 1:transfer
        /// 0：直连；1：转发
        /// </summary>
	    public byte				byWorkMode;							        
        /// <summary>
        /// isten port, valid with transfer; when byConnType is multicast, it is multiport
        /// 指示侦听服务的端口,转发时有效; byConnType为组播时,则作为多播端口
        /// </summary>
	    public short			wListenPort;						       
        /// <summary>
        /// szDevIp extension, front DVR Ip address (enter domain name)
        /// szDevIp扩展,前端DVR的IP地址(可以输入域名)
        /// </summary>
	    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string				szDevIpEx;                             
        /// <summary>
        /// snapshot mode (valid when nStreamType==4) 0: request for single frame, 1: sechdule sending request
        /// 抓图模式(nStreamType==4时有效) 0：表示请求一帧,1：表示定时发送请求
        /// </summary>
	    public byte				bySnapMode;                                   
        /// <summary>
        /// Target device manufacturer. Refer to EM_IPC_TYPE for detailed information.
        /// 目标设备的生产厂商, 具体参考EM_IPC_TYPE类
        /// </summary>
	    public byte				byManuFactory;						       
        /// <summary>
        /// target device type, 0:IPC
        /// 目标设备的设备类型, 0:IPC
        /// </summary>
	    public byte				byDeviceType;                              
        /// <summary>
        /// target device decode policy, 0:compatible with previous,1:real time level high 2: real time level medium,3: real time level low 4: default level 
        /// 5: fluency level high 6: fluency level medium,7: fluency level low
        /// 目标设备的解码策略, 0:兼容以前,1:实时等级高 2:实时等级中,3:实时等级低 4:默认等级,5:流畅等级高 6:流畅等级中,7:流畅等级低
        /// </summary>
	    public byte				byDecodePolicy;                            
        /// <summary>
        /// Http port number, 0-65535
        /// Http端口号, 0-65535
        /// </summary>
	    public uint				dwHttpPort;                                
        /// <summary>
        /// Rtsp port number, 0-65535
        /// Rtsp端口号, 0-65535
        /// </summary>
	    public uint				dwRtspPort;                                
        /// <summary>
        /// Remote channel name, modifiable only when name read is not vacant
        /// 远程通道名称, 只有读取到的名称不为空时才可以修改该通道的名称
        /// </summary>
	    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string				szChnName;		                       
        /// <summary>
        /// Multicast IP address. Valid only when byConnType is multicast
        /// 多播IP地址, byConnType为组播时有效
        /// </summary>
	    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string				szMcastIP;                             
        /// <summary>
        /// device ID, ""-null, "Local"  "Remote"
        /// 设备ID, ""-null, "Local"-本地通道, "Remote"-远程通道, 或者填入具体的RemoteDevice中的设备ID
        /// </summary>
	    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string				szDeviceID;		                       
        /// <summary>
        /// is remote channel or not(read only)
        /// 是否远程通道(只读)
        /// </summary>
	    public bool				bRemoteChannel;						       
        /// <summary>
        /// remote channel ID (read only), effective when bRemoteChannel=TRUE
        /// 远程通道ID(只读), bRemoteChannel=TRUE时有效
        /// </summary>
	    public uint		nRemoteChannelID;					               
        /// <summary>
        /// type of device, such as IPC, DVR, NVR and so on
        /// 设备类型, 如IPC, DVR, NVR等
        /// </summary>
	    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string				szDevClass;		                       
        /// <summary>
        /// device specific type, such as IPC-HF3300
        /// 设备具体型号, 如IPC-HF3300
        /// </summary>
	    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string				szDevType;			                   
        /// <summary>
        /// main stream url, effective when byManuFactory =D H_IPC_OTHER
        /// 主码流url地址, byManuFactory为DH_IPC_OTHER时有效
        /// </summary>
	    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string				szMainStreamUrl;			           
        /// <summary>
        /// extra stream url, effective when byManuFactory =D H_IPC_OTHER
        /// 辅码流url地址, byManuFactory为NET_IPC_OTHER时有效
        /// </summary>
	    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string				szExtraStreamUrl;			           
        /// <summary>
        /// unique channel ID, read only
        /// 设备内统一编号的唯一通道号, 只读
        /// </summary>
	    public int					nUniqueChannel;						   
        /// <summary>
        /// ssascade authemyication, effective when device ID = "Local/Cascade/SerialNo",  SerialNo is device seral no.
        /// 级联认证信息, 设备ID为"Local/Cascade/SerialNo"时有效, 其中SerialNo是设备序列号
        /// </summary>
	    public NET_CASCADE_AUTHENTICATOR stuCascadeAuth;				    
        /// <summary>
        /// 0-normal video source, 1- alarm video source
        /// 0-普通视频源, 1-报警视频源
        /// </summary>
        public int                 nHint;                                   
        /// <summary>
        /// back main stream address quantity
        /// 备用主码流地址数量
        /// </summary>
        public int                 nOptionalMainUrlCount;                   
        /// <summary>
        /// backup main stream address list
        /// 备用主码流地址列表
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8 * 260)]
        public byte[]                szOptionalMainUrls;                    
        /// <summary>
        /// backup sub stream address quantity
        /// 备用辅码流地址数量
        /// </summary>
        public int                 nOptionalExtraUrlCount;                  
        /// <summary>
        /// backup sub stream address list
        /// 备用辅码流地址列表
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8 * 260)]
        public byte[]                szOptionalExtraUrls;                   
        /// <summary>
        /// tour time intertval	unit:second
        /// 轮巡时间间隔   单位：秒
        /// </summary>
        public int                 nInterval;                               
        /// <summary>
        /// user name
        /// 用户名
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string                szUserEx;                              
        /// <summary>
        /// password
        /// 密码
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string                szPwdEx;                               
        /// <summary>
        /// type of pushstream,effective when byConnType is TCP-Push or UDP-Push
        /// 推流方式的码流类型,只有byConnType为TCP-Push或UDP-Push才有该字段
        /// </summary>
        public EM_SRC_PUSHSTREAM_TYPE  emPushStream;                                 
    }

    /// <summary>
    /// even the authentication information
    /// 级联权限验证信息
    /// </summary>
    public struct NET_CASCADE_AUTHENTICATOR
    {
        /// <summary>
        /// struct size 
        /// 结构体大小
        /// </summary>
        public uint			    	dwSize;
        /// <summary>
        /// user name
        /// 用户名
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]               
        public string				szUser;		                            
        /// <summary>                                                       
        /// passwd                                                          
        /// 密码                                                                
        /// </summary>                                                      
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]               
        public string				szPwd;			                        
        /// <summary>                                                       
        /// serial no.                                                      
        /// 设备序列号                                                                
        /// </summary>                                                      
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 48)]                
        public string				szSerialNo;                             
    }

    /// <summary>
    /// src push stream type
    /// </summary>
    public enum EM_SRC_PUSHSTREAM_TYPE
    {
        /// <summary>
        /// device automatic recognition according to bit stream head, default
        /// 设备端根据码流头自动识别，默认值
        /// </summary>
        AUTO,                                                                
        /// <summary>
        /// Hikvision private bit stream
        /// 海康私有码流
        /// </summary>
        HIKVISION,                                                        
        /// <summary>
        /// PS
        /// PS流
        /// </summary>
        PS,                                                                 
        /// <summary>
        /// TS
        /// TS流
        /// </summary>
        TS,                                                                 
        /// <summary>
        /// SVAC
        /// SVAC码流
        /// </summary>
        SVAC,                                                                   
    }

    /// <summary>
    /// SetSplitSourceEx  The input parameters of the interface 
    /// SetSplitSourceEx 接口的输入参数
    /// </summary>
    public struct NET_IN_SET_SPLIT_SOURCE
    {
        /// <summary>
        /// struct size 
        /// 结构体大小
        /// </summary>
        public uint                   dwSize;
        /// <summary>
        /// Video output control method 
        /// 视频输出控制方式
        /// </summary>
        public EM_VIDEO_OUT_CTRL_TYPE  emCtrlType;                         
        /// <summary>
        /// Video output logical channel number,when the emCtrlType is EM_VIDEO_OUT_CTRL_CHANNEL effective
        /// 视频输出逻辑通道号, emCtrlType为EM_VIDEO_OUT_CTRL_CHANNEL时有效
        /// </summary>
        public int                     nChannel;                             
        /// <summary>
        /// Splicing screen ID, when the emCtrlType is EM_VIDEO_OUT_CTRL_CHANNEL effective
        /// 拼接屏ID, emCtrlType为EM_VIDEO_OUT_CTRL_COMPOSITE_ID时有效
        /// </summary>
        public IntPtr             pszCompositeID;                           
        /// <summary>
        /// winder number, -1 means all windows of the current segmentation mode 
        /// 窗口号, -1表示当前分割模式下的所有窗口
        /// </summary>
        public int                     nWindow;                            
        /// <summary>
        /// pointer to NET_SPLIT_SOURCE. Video source information, when nWindow=-1, Video source is an array, and the number and the window number,the space application by the user,applt to sizeof(NET_SPLIT_SOURCE)*nSourceCount
        /// 视频源信息, 当nWindow=-1时, 视频源是个数组, 且数量与窗口数一致,由用户申请内存，大小为sizeof(NET_SPLIT_SOURCE)*nSourceCount
        /// </summary>
        public IntPtr pstuSources;                                          
        /// <summary>
        /// Video source number
        /// 视频源数量
        /// </summary>
	    public int                     nSourceCount;                              
    }

    /// <summary>
    /// Video output control method
    /// 视频输出控制方式
    /// </summary>
    public enum EM_VIDEO_OUT_CTRL_TYPE
    {
        /// <summary>
        /// Logical channel number control mode,effective for physical screen and splicing screen 
        /// 逻辑通道号控制方式, 对物理屏和拼接屏都有效
        /// </summary>
        CHANNEL,                                                            
        /// <summary>
        /// Splice screen ID control mode, applies to splice screen only 
        /// 拼接屏ID控制方式, 只对拼接屏有效
        /// </summary>
        COMPOSITE_ID,                                                       
    }

    /// <summary>
    /// Set the return result of video source  
    /// 设置视频源的返回结果
    /// </summary>
    public struct NET_SET_SPLIT_SOURCE_RESULT
    {
        /// <summary>
        /// struct size 
        /// 结构体大小
        /// </summary>
        public uint         dwSize;
        /// <summary>
        /// Monitor Port Number of Push Flow Pattern Equipment
        /// 推流模式的设备端监听端口号
        /// </summary>
        public int          nPushPort;                                      
    }

    /// <summary>
    /// SetSplitSourceEx output parameters of the interface 
    /// SetSplitSourceEx 接口的输出参数
    /// </summary>
    public struct NET_OUT_SET_SPLIT_SOURCE
    {
        /// <summary>
        /// struct size 
        /// 结构体大小
        /// </summary>
        public uint                    dwSize;
        /// <summary>
        /// pointer to NET_SET_SPLIT_SOURCE_RESULT. returned value after successful setting , corresponding the window array in NET_IN_SET_SPLIT_SOURCE, user allocates memory , apply to sizeof(NET_SET_SPLIT_SOURCE_RESULT)*nMaxResultCount,If don't need can be NULL 
        /// 设置成功后的返回值, 对应NET_IN_SET_SPLIT_SOURCE中的窗口数组, 用户分配内存,大小为sizeof(NET_SET_SPLIT_SOURCE_RESULT)*nMaxResultCount, 如果不需要可以为NULL
        /// </summary>
        public IntPtr                  pstuResults;                       
        /// <summary>
        /// The size of the pstuResults array
        /// pstuResults数组的大小
        /// </summary>
        public int                     nMaxResultCount;                   
        /// <summary>
        /// The Number Of Return
        /// 返回的数量
        /// </summary>
        public int                     nRetCount;                            
    }
    #endregion

    /// <summary>
    /// event type EVENT_IVS_TRAFFIC_PEDESTRAINPRIORITY corresponding data block description info
    /// 斑马线行人优先事件对应的数据块描述信息
    /// </summary>
    public struct NET_DEV_EVENT_TRAFFIC_PEDESTRAINPRIORITY_INFO
    {
        /// <summary>
        /// Channel No.
        /// 通道号
        /// </summary>
        public int nChannelID;                                            
        /// <summary>
        /// Event name
        /// 事件名称
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string szName;                                             
        /// <summary>
        /// byte alignment
        /// 字节对齐
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] bReserved1;                                         
        /// <summary>
        /// Time stamp(ms)
        /// 时间戳(单位是毫秒)
        /// </summary>
        public double PTS;                                                 
        /// <summary>
        /// Event occurred time
        /// 事件发生的时间
        /// </summary>
        public NET_TIME_EX UTC;                                            
        /// <summary>
        /// Event ID
        /// 事件ID
        /// </summary>
        public int nEventID;                                               
        /// <summary>
        /// Detected object
        /// 检测到的物体
        /// </summary>
        public NET_MSG_OBJECT stuObject;                                   
        /// <summary>
        /// Vehicle body info
        /// 车身信息
        /// </summary>
        public NET_MSG_OBJECT stuVehicle;                                  
        /// <summary>
        /// The corresponding file info of the event
        /// 事件对应文件信息
        /// </summary>
        public NET_EVENT_FILE_INFO stuFileInfo;                            
        /// <summary>
        /// Corresponding lane No.
        /// 对应车道号
        /// </summary>
        public int nLane;                                                  
        /// <summary>
        /// Event initial UTC time 	UTC is the second of the event UTC (1970-1-1 00:00:00)
        /// 事件初始UTC时间    UTC为事件的UTC (1970-1-1 00:00:00)秒数
        /// </summary>
        public double dInitialUTC;                                          
        /// <summary>
        /// Event operation.0=pulse event,1=begin of the durative event,2=end of the durative event
        /// 事件动作,0表示脉冲事件,1表示持续性事件开始,2表示持续性事件结束
        /// </summary>
        public byte bEventAction;                                           
        /// <summary>
        /// reserved
        /// 保留字段，对齐用
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] byReserved;
        /// <summary>
        /// Serial number of the picture, in the same time (accurate to seconds) may have multiple images, starting from 0
        /// 图片的序号, 同一时间内(精确到秒)可能有多张图片, 从0开始
        /// </summary>
        public byte byImageIndex;                                          
        /// <summary>
        /// Snap flag(by bit),please refer to NET_RESERVED_COMMON
        /// 抓图标志(按位),具体见NET_RESERVED_COMMON
        /// </summary>
        public uint dwSnapFlagMask;                                        
        /// <summary>
        /// The record of the database of the traffic vehicle
        /// 表示交通车辆的数据库记录
        /// </summary>
        public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stTrafficCar;         
        /// <summary>
        /// picture resolution
        /// 对应图片的分辨率
        /// </summary>
        public NET_RESOLUTION_INFO  stuResolution;
        /// <summary>
        /// GPS info
        /// GPS信息
        /// </summary>
        public NET_GPS_INFO         stuGPSInfo;                                              
        /// <summary>
        /// Reserved
        /// 保留字节
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 984)]
        public byte[] bReserved;                                           
        /// <summary>
        /// public info
        /// 公共信息
        /// </summary>
        public NET_EVENT_COMM_INFO stCommInfo;                             
    }

    /// <summary>
    /// open strobe information
    /// 打开道闸信息
    /// </summary>
    public struct NET_CTRL_OPEN_STROBE
    {
        /// <summary>
        /// struct size
        /// 结构体大小
        /// </summary>
        public uint                 dwSize;
        /// <summary>
        /// channel number
        /// 通道号
        /// </summary>
        public int                  nChannelId;                             
        /// <summary>
        /// plate number
        /// 车牌号码
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string               szPlateNumber;                           
    }

    /// <summary>
    /// the describe of EVENT_IVS_TRAFFIC_UTURN's data
    /// 违章调头事件对应的数据块描述信息
    /// </summary>
    public struct NET_DEV_EVENT_TRAFFIC_UTURN_INFO 
    {
        /// <summary>
        /// channel ID
        /// 通道号
        /// </summary>
        public int                      nChannelID;                                 
        /// <summary>
        /// event name
        /// 事件名称
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[]                   szName;          
        /// <summary>
        /// byte alignment
        /// 字节对齐
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[]                   bReserved1;                              
        /// <summary>
        /// PTS(ms)
        /// 时间戳(单位是毫秒)
        /// </summary>
        public double                   PTS;                                        
        /// <summary>
        /// the event happen time
        /// 事件发生的时间
        /// </summary>
        public NET_TIME_EX              UTC;                                        
        /// <summary>
        /// event ID
        /// 事件ID
        /// </summary>
        public int                      nEventID;                                   
        /// <summary>
        /// Corresponding Lane number
        /// 对应车道号
        /// </summary>
        public int                      nLane;                                      
        /// <summary>
        /// have being detected object
        /// 检测到的物体
        /// </summary>
        public NET_MSG_OBJECT           stuObject;                                  
        /// <summary>
        /// vehicle info
        /// 车身信息
        /// </summary>
        public NET_MSG_OBJECT           stuVehicle;                                 
        /// <summary>
        /// event file info
        /// 事件对应文件信息
        /// </summary>
        public NET_EVENT_FILE_INFO      stuFileInfo;                                
        /// <summary>
        /// snap index: such as 3,2,1,1 means the last one,0 means there has some exception and snap stop
        /// 表示抓拍序号,如3,2,1,1表示抓拍结束,0表示异常结束
        /// </summary>
        public int                      nSequence;                                  
        /// <summary>
        /// speed,km/h
        /// 车辆实际速度,Km/h
        /// </summary>
        public int                      nSpeed;                                     
        /// <summary>
        /// Event action,0 means pulse event,1 means continuous event's begin,2means continuous event's end
        /// 事件动作,0表示脉冲事件,1表示持续性事件开始,2表示持续性事件结束
        /// </summary>
        public byte                     bEventAction;                               
        /// <summary>
        /// byte alignment
        /// 字节对齐
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[]                   byReserved;
        /// <summary>
        /// Serial number of the picture, in the same time (accurate to seconds) may have multiple images, starting from 0
        /// 图片的序号, 同一时间内(精确到秒)可能有多张图片, 从0开始
        /// </summary>
        public byte                     byImageIndex;                               
        /// <summary>
        /// flag(by bit),see NET_RESERVED_COMMON
        /// 抓图标志(按位),具体见NET_RESERVED_COMMON 
        /// </summary>
        public uint                     dwSnapFlagMask;                             
        /// <summary>
        /// picture resolution
        /// 对应图片的分辨率
        /// </summary>
        public NET_RESOLUTION_INFO      stuResolution;                              
        /// <summary>
        /// GPS info ,use in mobile DVR/NVR
        /// GPS信息 车载定制
        /// </summary>
        public NET_GPS_INFO             stuGPSInfo;        
        /// <summary>
        /// Reserved
        /// 保留字节
        /// </summary> 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 968)]
        public byte[]                   bReserved;                             
        /// <summary>
        /// Traffic vehicle info
        /// 交通车辆信息
        /// </summary>
        public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stTrafficCar;                 
        /// <summary>
        /// public info
        /// 公共信息
        /// </summary>
        public NET_EVENT_COMM_INFO      stCommInfo;                                 
    }

    /// <summary>
    /// GPS Infomation
    /// GPS信息
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)] 
    public struct NET_GPS_INFO
    {
        /// <summary>
        /// Longitude(unit:1/1000000 degree) west Longitude: 0 - 180000000  practical value = 180*1000000 - dwLongitude,east Longitude: 180000000 - 360000000    practical value = dwLongitude - 180*1000000. eg: Longitude:300168866  (300168866 - 180*1000000)/1000000  equal east Longitude 120.168866 degree
        /// 经度(单位是百万分之一度) 西经：0 - 180000000 实际值应为: 180*1000000 – dwLongitude,东经：180000000 - 360000000		实际值应为: dwLongitude – 180*1000000. 如: 300168866应为（300168866 - 180*1000000）/1000000 即东经120.168866度
        /// </summary>
        public uint                             nLongitude;         	
        /// <summary>
        /// Latidude(unit:1/1000000 degree)
        /// 纬度(单位是百万分之一度)
        /// </summary>
        public uint					            nLatidude;              
        /// <summary>
        /// altitude,unit:m
        /// 高度,单位为米
        /// </summary>
        public double                           dbAltitude;              
        /// <summary>
        /// Speed,unit:km/H
        /// 速度,单位km/H
        /// </summary>
        public double                           dbSpeed;                 
        /// <summary>
        /// Bearing,unit:°
        /// 方向角,单位:°
        /// </summary>
        public double                           dbBearing;               
        /// <summary>
        /// Reserved bytes
        /// 保留字段 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	    public byte[]                           bReserved;           
    }

    /// <summary>
    /// the describe of EVENT_IVS_TRAFFIC_PARKING's data
    /// 交通违章停车事件对应的数据块描述信息
    /// </summary>
    public struct NET_DEV_EVENT_TRAFFIC_PARKING_INFO 
    {
        /// <summary>
        /// channel ID
        /// 通道号
        /// </summary>
        public int                          nChannelID;                                
        /// <summary>
        /// event name
        /// 事件名称
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[]                       szName;                               
        /// <summary>
        /// byte alignment
        /// 字节对齐
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[]                       bReserved1;                           
        /// <summary>
        /// PTS(ms)
        /// 时间戳(单位是毫秒)
        /// </summary>
        public double                       PTS;                                  
        /// <summary>
        /// the event happen time
        /// 事件发生的时间
        /// </summary>
        public NET_TIME_EX                  UTC;                                  
        /// <summary>
        /// event ID
        /// 事件ID
        /// </summary>
        public int                          nEventID;                             
        /// <summary>
        /// have being detected object
        /// 检测到的物体
        /// </summary>
        public NET_MSG_OBJECT               stuObject;                               
        /// <summary>
        /// vehicle info
        /// 车身信息
        /// </summary>
        public NET_MSG_OBJECT               stuVehicle;                              
        /// <summary>
        /// Corresponding Lane number
        /// 对应车道号
        /// </summary>
        public int                          nLane;                                   
        /// <summary>
        /// event file info 
        /// 事件对应文件信息
        /// </summary>
        public NET_EVENT_FILE_INFO          stuFileInfo;                             
        /// <summary>
        /// Event action,0 means pulse event,1 means continuous event's begin,2means continuous event's end
        /// 事件动作,0表示脉冲事件,1表示持续性事件开始,2表示持续性事件结束
        /// </summary>
        public byte                         bEventAction;                            
        /// <summary>
        /// Reserved bytes
        /// 保留字节
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[]                       reserved;                              
        /// <summary>
        /// Serial number of the picture, in the same time (accurate to seconds) may have multiple images, starting from 0
        /// 图片的序号, 同一时间内(精确到秒)可能有多张图片, 从0开始
        /// </summary>
        public byte                         byImageIndex;                          
        /// <summary>
        /// the time of starting parking
        /// 开始停车时间
        /// </summary>
        public NET_TIME_EX                  stuStartParkingTime;                   
        /// <summary>
        /// snap index: such as 3,2,1,1 means the last one,0 means there has some exception and snap stop(this param work when bEventAction=2) 
        /// 表示抓拍序号,如3,2,1,1表示抓拍结束,0表示异常结束(bEventAction=2时此参数有效)
        /// </summary>
        public int                          nSequence;                                  
        /// <summary>
        /// interval time of alarm(s) (this is a continuous event,if the interval time of recieving next event go beyond this param, we can judge that this event is over with exception)
        /// 报警时间间隔,单位:秒。(此事件为连续性事件,在收到第一个此事件之后,若在超过间隔时间后未收到此事件的后续事件,则认为此事件异常结束了)
        /// </summary>
        public int                          nAlarmIntervalTime;                        
        /// <summary>
        /// the time of legal parking
        /// 允许停车时长,单位：秒
        /// </summary>
        public int                          nParkingAllowedTime;                       
        /// <summary>
        /// detect region point number
        /// 规则检测区域顶点数
        /// </summary>
        public int                          nDetectRegionNum;                          
        /// <summary>
        /// detect region point number
        /// 规则检测区域
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public NET_POINT[]                  DetectRegion;     
        /// <summary>
        /// flag(by bit),see NET_RESERVED_COMMON
        /// 抓图标志(按位),具体见NET_RESERVED_COMMON
        /// </summary>
        public uint                         dwSnapFlagMask;                             
        /// <summary>
        /// picture resolution
        /// 对应图片的分辨率
        /// </summary>
        public NET_RESOLUTION_INFO          stuResolution;                            
        /// <summary>
        /// true:corresponding alarm recording; false: no corresponding alarm recording
        /// true:有对应的报警录像; false:无对应的报警录像
        /// </summary>
        public bool                         bIsExistAlarmRecord;                      
        /// <summary>
        /// Video size
        /// 录像大小
        /// </summary>
        public uint                         dwAlarmRecordSize;                        
        /// <summary>
        /// Video Path
        /// 录像路径
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[]                       szAlarmRecordPath;    
        /// <summary>
        /// FTP path
        /// FTP路径
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[]                       szFTPPath;            
        /// <summary>
        /// intelli comm info
        /// 智能事件公共信息
        /// </summary>
        public NET_EVENT_INTELLI_COMM_INFO  stuIntelliCommInfo;                 
        /// <summary>
        /// weather is PreAlarm event,0 :traffic parking event,1 :preAlarm event
        /// 是否为违章预警图片,0 违章停车事件1 预警事件(预警触发后一定时间，车辆还没有离开，才判定为违章)由于此字段会导致事件含义改变，必须和在平台识别预警事件后，才能有此字段, 
        /// </summary>
	    public byte				            byPreAlarm;									
        /// <summary>
        /// Reserved
        /// 保留字节,留待扩展
        /// </summary>
	    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[]                       bReserved2;                            
        /// <summary>
        /// GPS info ,use in mobile DVR/NVR
        /// GPS信息 车载定制
        /// </summary>
        public NET_GPS_INFO                 stuGPSInfo;                            
        /// <summary>
        /// Reserved
        /// 保留字节
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 228)]
        public byte[]                       bReserved;                             
        /// <summary>
        /// Traffic vehicle info
        /// 交通车辆信息
        /// </summary>
        public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stTrafficCar;                 
        /// <summary>
        /// public info
        /// 公共信息
        /// </summary>
        public NET_EVENT_COMM_INFO          stCommInfo;                            
    } 

    /// <summary>
    /// the describe of EVENT_IVS_TRAFFIC_CROSSLANE's data
    /// 交通违章-违章变道对应的数据块描述信息
    /// </summary>
    public struct NET_DEV_EVENT_TRAFFIC_CROSSLANE_INFO 
    {
        /// <summary>
        /// channel ID
        /// 通道号
        /// </summary>
        public int                              nChannelID;                              
        /// <summary>
        /// event name
        /// 事件名称
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[]                           szName;                                
        /// <summary>
        /// byte alignment
        /// 字节对齐
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[]                           bReserved1;                             
        /// <summary>
        /// PTS(ms)
        /// 时间戳(单位是毫秒)
        /// </summary>
        public double                           PTS;                                        
        /// <summary>
        /// the event happen time
        /// 事件发生的时间
        /// </summary>
        public NET_TIME_EX                      UTC;                                       
        /// <summary>
        /// event ID
        /// 事件ID
        /// </summary>
        public int                              nEventID;                                   
        /// <summary>
        /// have being detected object
        /// 检测到的物体
        /// </summary>
        public NET_MSG_OBJECT                   stuObject;                                 
        /// <summary>
        /// vehicle info
        /// 车身信息
        /// </summary>
        public NET_MSG_OBJECT                   stuVehicle;                                 
        /// <summary>
        /// Corresponding Lane number
        /// 对应车道号
        /// </summary>
        public int                              nLane;                                      
        /// <summary>
        /// event file info 
        /// 事件对应文件信息
        /// </summary>
        public NET_EVENT_FILE_INFO              stuFileInfo;                                
        /// <summary>
        /// Event action,0 means pulse event,1 means continuous event's begin,2means continuous event's end
        /// 事件动作,0表示脉冲事件,1表示持续性事件开始,2表示持续性事件结束
        /// </summary>
        public byte                             bEventAction;                               
        /// <summary>
        /// Reserved
        /// 保留字节
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[]                           byReserved;       
        /// <summary>
        /// Serial number of the picture, in the same time (accurate to seconds) may have multiple images, starting from 0
        /// 图片的序号, 同一时间内(精确到秒)可能有多张图片, 从0开始
        /// </summary>
        public byte                             byImageIndex;                               
        /// <summary>
        /// speed,km/h
        /// 车辆实际速度,km/h
        /// </summary>
        public int                              nSpeed;                                     
        /// <summary>
        /// flag(by bit),see NET_RESERVED_COMMON
        /// 抓图标志(按位),具体见NET_RESERVED_COMMON
        /// </summary>
        public uint                             dwSnapFlagMask;                             
        /// <summary>
        /// picture resolution
        /// 对应图片的分辨率
        /// </summary>
        public NET_RESOLUTION_INFO              stuResolution;                              
        /// <summary>
        /// intelli comm info
        /// 智能事件公共信息
        /// </summary>
	    public NET_EVENT_INTELLI_COMM_INFO      stuIntelliCommInfo;                 
        /// <summary>
        /// GPS info ,use in mobile DVR/NVR
        /// GPS信息 车载定制
        /// </summary>
        public NET_GPS_INFO                     stuGPSInfo;                                 
        /// <summary>
        /// Reserved
        /// 保留字节
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 836)]
	    public byte[]                           bReserved;                             
        /// <summary>
        /// traffic vehicle info
        /// 交通车辆信息
        /// </summary>
        public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stuTrafficCar;                
        /// <summary>
        /// public info
        /// 公共信息
        /// </summary>
        public NET_EVENT_COMM_INFO              stCommInfo;                                 
    }

    /// <summary>
    /// the describe of EVENT_IVS_TRAFFIC_YELLOWPLATEINLANE's data
    /// 交通违章-黄牌车占道事件对应的数据块描述信息
    /// </summary>
    public struct NET_DEV_EVENT_TRAFFIC_YELLOWPLATEINLANE_INFO
    {
         /// <summary>
        /// channel ID
        /// 通道号
        /// </summary>
        public int                              nChannelID;                              
        /// <summary>
        /// event name
        /// 事件名称
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[]                           szName;                                
        /// <summary>
        /// byte alignment
        /// 字节对齐
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[]                           bReserved1;                             
        /// <summary>
        /// PTS(ms)
        /// 时间戳(单位是毫秒)
        /// </summary>
        public double                           PTS;                                        
        /// <summary>
        /// the event happen time
        /// 事件发生的时间
        /// </summary>
        public NET_TIME_EX                      UTC;                                       
        /// <summary>
        /// event ID
        /// 事件ID
        /// </summary>
        public int                              nEventID;                                   
        /// <summary>
        /// have being detected object
        /// 检测到的物体
        /// </summary>
        public NET_MSG_OBJECT                   stuObject;                                 
        /// <summary>
        /// vehicle info
        /// 车身信息
        /// </summary>
        public NET_MSG_OBJECT                   stuVehicle;                                 
        /// <summary>
        /// Corresponding Lane number
        /// 对应车道号
        /// </summary>
        public int                              nLane;                                      
        /// <summary>
        /// event file info 
        /// 事件对应文件信息
        /// </summary>
        public NET_EVENT_FILE_INFO              stuFileInfo;                                
        /// <summary>
        /// Event action,0 means pulse event,1 means continuous event's begin,2means continuous event's end
        /// 事件动作,0表示脉冲事件,1表示持续性事件开始,2表示持续性事件结束
        /// </summary>
        public byte                             bEventAction;                               
        /// <summary>
        /// Reserved
        /// 保留字节
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[]                           byReserved;       
        /// <summary>
        /// Serial number of the picture, in the same time (accurate to seconds) may have multiple images, starting from 0
        /// 图片的序号, 同一时间内(精确到秒)可能有多张图片, 从0开始
        /// </summary>
        public byte                             byImageIndex;                               
        /// <summary>
        /// speed,km/h
        /// 车辆实际速度,km/h
        /// </summary>
        public int                              nSpeed;                                     
        /// <summary>
        /// flag(by bit),see NET_RESERVED_COMMON
        /// 抓图标志(按位),具体见NET_RESERVED_COMMON
        /// </summary>
        public uint                             dwSnapFlagMask;                             
        /// <summary>
        /// picture resolution
        /// 对应图片的分辨率
        /// </summary>
        public NET_RESOLUTION_INFO              stuResolution;                                                             
        /// <summary>
        /// Reserved
        /// 保留字节
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1016)]
	    public byte[]                           bReserved;                             
        /// <summary>
        /// traffic vehicle info
        /// 交通车辆信息
        /// </summary>
        public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stuTrafficCar;                
        /// <summary>
        /// public info
        /// 公共信息
        /// </summary>
        public NET_EVENT_COMM_INFO              stCommInfo;       
    }

    /// <summary>
    /// the describe of EVENT_IVS_TRAFFIC_VEHICLEINROUTE's data
    /// 有车占道事件对应的数据块描述信息
    /// </summary>
    public struct NET_DEV_EVENT_TRAFFIC_VEHICLEINROUTE_INFO
    {
        /// <summary>
        /// channel id
        /// 通道号
        /// </summary>
        public int                              nChannelID;                              
        /// <summary>
        /// event name
        /// 事件名称
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[]                           szName;                                
        /// <summary>
        /// byte alignment
        /// 字节对齐
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[]                           bReserved1;                             
        /// <summary>
        /// PTS(ms)
        /// 时间戳(单位是毫秒)
        /// </summary>
        public double                           PTS;                                      
        /// <summary>
        /// the event happen time
        /// 事件发生的时间
        /// </summary>
        public NET_TIME_EX                      UTC;                                      
        /// <summary>
        /// event ID
        /// 事件ID
        /// </summary>
        public int                              nEventID;                                 
        /// <summary>
        /// have being detected object
        /// 检测到的物体
        /// </summary>
        public NET_MSG_OBJECT                   stuObject;                               
        /// <summary>
        /// vehicle info
        /// 车身信息
        /// </summary>
        public NET_MSG_OBJECT                   stuVehicle;                              
        /// <summary>
        /// Corresponding Lane number
        /// 对应车道号
        /// </summary>
        public int                              nLane;                                  
        /// <summary>
        /// snap index
        /// 抓拍序号
        /// </summary>
        public int                              nSequence;                              
        /// <summary>
        /// speed
        /// 车速
        /// </summary>
        public int                              nSpeed;                                 
        /// <summary>
        /// TrafficCar info
        /// 表示交通车辆的数据库记录
        /// </summary>
        public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stTrafficCar;         
        /// <summary>
        /// event file info
        /// 事件对应文件信息
        /// </summary>
        public NET_EVENT_FILE_INFO              stuFileInfo;                           
        /// <summary>
        /// Event action,0 means pulse event,1 means continuous event's begin,2means continuous event's end
        /// 事件动作,0表示脉冲事件,1表示持续性事件开始,2表示持续性事件结束
        /// </summary>
        public byte                             bEventAction;                           
        /// <summary>
        /// Reserved
        /// 保留字节
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[]                           byReserved0;
        /// <summary>
        /// Serial number of the picture, in the same time (accurate to seconds) may have multiple images, starting from 0
        /// 图片的序号, 同一时间内(精确到秒)可能有多张图片, 从0开始
        /// </summary>
        public byte                             byImageIndex;                             
        /// <summary>
        /// flag(by bit),see NET_RESERVED_COMMON
        /// 抓图标志(按位),具体见NET_RESERVED_COMMON
        /// </summary>
        public uint                             dwSnapFlagMask;                            
        /// <summary>
        /// picture resolution
        /// 对应图片的分辨率
        /// </summary>
        public NET_RESOLUTION_INFO              stuResolution;                           
        /// <summary>
        /// intelli comm info
        /// 智能事件公共信息
        /// </summary>
        public NET_EVENT_INTELLI_COMM_INFO     stuIntelliCommInfo;           
        /// <summary>
        /// Reserved
        /// 保留字节
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 884)]
        public byte[]                           byReserved;           
        /// <summary>
        /// public info
        /// 公共信息
        /// </summary>
        public NET_EVENT_COMM_INFO              stCommInfo;                           
    }

    /// <summary>
    /// the describe of EVENT_IVS_TRAFFIC_VEHICLEINBUSROUTE's data
    /// 占用公交车道事件对应的数据块描述信息
    /// </summary>
    public struct NET_DEV_EVENT_TRAFFIC_VEHICLEINBUSROUTE_INFO
    {
        /// <summary>
        /// channel ID
        /// 通道号
        /// </summary>
        public int                              nChannelID;                             
        /// <summary>
        /// event name
        /// 事件名称
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[]                           szName;                                
        /// <summary>
        /// byte alignment
        /// 字节对齐
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[]                           bReserved1;                            
        /// <summary>
        /// Time stamp(ms)
        /// 时间戳(单位是毫秒)
        /// </summary>
        public double                           PTS;                                     
        /// <summary>
        /// Event occurred time
        /// 事件发生的时间
        /// </summary>
        public NET_TIME_EX                      UTC;                                     
        /// <summary>
        /// Event ID
        /// 事件ID
        /// </summary>
        public int                              nEventID;                                
        /// <summary>
        /// Detected object
        /// 检测到的物体
        /// </summary>
        public NET_MSG_OBJECT                   stuObject;                              
        /// <summary>
        /// Vehicle body info
        /// 车身信息
        /// </summary>
        public NET_MSG_OBJECT                   stuVehicle;                                
        /// <summary>
        /// The corresponding file info of the event
        /// 事件对应文件信息
        /// </summary>
        public NET_EVENT_FILE_INFO              stuFileInfo;                               
        /// <summary>
        /// Corresponding lane No
        /// 对应车道号
        /// </summary>
        public int                              nLane;                                      
        /// <summary>
        /// snap index
        /// 抓拍序号
        /// </summary>
        public int                              nSequence;                                  
        /// <summary>
        /// speed km/h
        /// 车速,km/h
        /// </summary>
        public int                              nSpeed;                                     
        /// <summary>
        /// Event operation.0=pulse event,1=begin of the durative event,2=end of the durative event
        /// 事件动作,0表示脉冲事件,1表示持续性事件开始,2表示持续性事件结束
        /// </summary>
        public byte                             bEventAction;                               
        /// <summary>
        /// reserved
        /// 保留字节
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[]                           byReserved;
        /// <summary>
        /// Serial number of the picture, in the same time (accurate to seconds) may have multiple images, starting from 0
        /// 图片的序号, 同一时间内(精确到秒)可能有多张图片, 从0开始
        /// </summary>
        public byte                             byImageIndex;                            
        /// <summary>
        /// Snap flag(by bit),please refer to NET_RESERVED_COMMON
        /// 抓图标志(按位),具体见NET_RESERVED_COMMON
        /// </summary>
        public uint                             dwSnapFlagMask;                           
        /// <summary>
        /// The record of the database of the traffic vehicle 
        /// 表示交通车辆的数据库记录
        /// </summary>
        public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stTrafficCar;          
        /// <summary>
        /// picture resolution
        /// 对应图片的分辨率
        /// </summary>
        public NET_RESOLUTION_INFO              stuResolution;                          
        /// <summary>
        /// GPS info ,use in mobile DVR/NVR
        /// GPS信息 车载定制
        /// </summary>
        public NET_GPS_INFO                     stuGPSInfo;                              
        /// <summary>
        /// reserved
        /// 保留字节
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 980)]
        public byte[]                           bReserved;                             
        /// <summary>
        /// public info
        /// 公共信息
        /// </summary>
        public NET_EVENT_COMM_INFO              stCommInfo;                          
    }

    /// <summary>
    /// the describe of EVENT_IVS_TRAFFIC_BACKING's data
    /// 违章倒车事件对应的数据块描述信息
    /// </summary>
    public struct NET_DEV_EVENT_IVS_TRAFFIC_BACKING_INFO
    {
        /// <summary>
        /// channel ID
        /// 通道号
        /// </summary>
        public int                              nChannelID;                            
        /// <summary>
        /// event name
        /// 事件名称
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[]                           szName;                                
        /// <summary>
        /// byte alignment
        /// 字节对齐
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[]                           bReserved1;                            
        /// <summary>
        /// Time stamp(ms)
        /// 时间戳(单位是毫秒)
        /// </summary>
        public double                           PTS;                                   
        /// <summary>
        /// Event occurred time
        /// 事件发生的时间
        /// </summary>
        public NET_TIME_EX                      UTC;                                   
        /// <summary>
        /// Event ID
        /// 事件ID
        /// </summary>
        public int                              nEventID;                              
        /// <summary>
        /// Detected object
        /// 检测到的物体
        /// </summary>
        public NET_MSG_OBJECT                   stuObject;                             
        /// <summary>
        /// Vehicle body info
        /// 车身信息
        /// </summary>
        public NET_MSG_OBJECT                   stuVehicle;                            
        /// <summary>
        /// The corresponding file info of the event
        /// 事件对应文件信息
        /// </summary>
        public NET_EVENT_FILE_INFO              stuFileInfo;                           
        /// <summary>
        /// Corresponding lane No.
        /// 对应车道号
        /// </summary>
        public int                              nLane;                                 
        /// <summary>
        /// snap index
        /// 抓拍序号
        /// </summary>
        public int                              nSequence;                             
        /// <summary>
        /// speed km/h
        /// 车速,km/h
        /// </summary>
        public int                              nSpeed;                                
        /// <summary>
        /// Event operation.0=pulse event,1=begin of the durative event,2=end of the durative event
        /// 事件动作,0表示脉冲事件,1表示持续性事件开始,2表示持续性事件结束
        /// </summary>
        public byte                             bEventAction;                          
        /// <summary>
        /// reserved
        /// 保留字节
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[]                           byReserved;
        /// <summary>
        /// Serial number of the picture, in the same time (accurate to seconds) may have multiple images, starting from 0
        /// 图片的序号, 同一时间内(精确到秒)可能有多张图片, 从0开始
        /// </summary>
        public byte                             byImageIndex;                          
        /// <summary>
        /// Snap flag(by bit),please refer to NET_RESERVED_COMMON
        /// 抓图标志(按位),具体见NET_RESERVED_COMMON
        /// </summary>
        public uint                             dwSnapFlagMask;                        
        /// <summary>                                                              
        /// The record of the database of the traffic vehicle                                                                    
        /// 表示交通车辆的数据库记录                                               
        /// </summary>                                                             
        public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stTrafficCar;                 
        /// <summary>                                                              
        /// picture resolution                                                                       
        /// 对应图片的分辨率                                                       
        /// </summary>                                                             
        public NET_RESOLUTION_INFO              stuResolution;                     
        /// <summary>                                                              
        /// intelli comm info                                                                       
        /// 智能事件公共信息                                                       
        /// </summary>                                                             
        public NET_EVENT_INTELLI_COMM_INFO      stuIntelliCommInfo;                
        /// <summary>                                                              
        /// GPS info ,use in mobile DVR/NVR                                                                       
        /// GPS信息 车载定制                                                       
        /// </summary>                                                             
        public NET_GPS_INFO                     stuGPSInfo;                        
        /// <summary>                                                              
        /// reserved                                                                       
        /// 保留字节                                                               
        /// </summary>                                                             
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 848)]                     
        public byte[]                           bReserved;                         
        /// <summary>                                                              
        /// public info                                                                       
        /// 公共信息                                                               
        /// </summary>                                                             
        public NET_EVENT_COMM_INFO              stCommInfo;                        
    }

    /// <summary>
    /// the describe of EVENT_IVS_TRAFFIC_WITHOUT_SAFEBELT's data
    /// 未系安全带事件事件对应的数据块描述信息
    /// </summary>
    public struct  NET_DEV_EVENT_TRAFFIC_WITHOUT_SAFEBELT
    {
        /// <summary>
        /// channel no.
        /// 通道号
        /// </summary>
        public int                              nChannelID;                   
        /// <summary>
        /// event name
        /// 事件名称
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[]                           szName;      
        /// <summary>
        /// TriggerType:trigger type , 0 vehicle detector, 1 radar, 2 video
        /// TriggerType:触发类型,0车检器,1雷达,2视频
        /// </summary>
        public int                              nTriggerType;                 
        /// <summary>
        /// time stamp(unit is ms)
        /// 时间戳(单位是毫秒)
        /// </summary>
        public uint                             PTS;                          
        /// <summary>
        /// event occurred time
        /// 事件发生的时间
        /// </summary>
        public NET_TIME_EX                      UTC;                          
        /// <summary>
        /// event ID
        /// 事件ID
        /// </summary>
        public int                              nEventID;                     
        /// <summary>
        /// means snaoshot no.
        /// 表示抓拍序号
        /// </summary>
        public int                              nSequence;                   
        /// <summary>
        /// event  motion , 0 means pulse event ,1 means  continuity  event  start ,2 means  continuity  event end
        /// 事件动作,0表示脉冲事件,1表示持续性事件开始,2表示持续性事件结束
        /// </summary>
        public byte                             byEventAction;               
        /// <summary>
        /// picture no., same time(accurate to second)may have multiple pictures , start from 0 
        /// 图片的序号, 同一时间内(精确到秒)可能有多张图片, 从0开始
        /// </summary>
        public byte                             byImageIndex;                
        /// <summary>
        /// reserved
        /// 保留字节
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[]                           byReserved1;
        /// <summary>
        /// event corresponding to file info 
        /// 事件对应文件信息
        /// </summary>
        public NET_EVENT_FILE_INFO              stuFileInfo;                 
        /// <summary>
        /// corresponding to lane no.
        /// 对应车道号
        /// </summary>
        public int                              nLane;                       
        /// <summary>
        /// bottom generated trigger snapshot frame mark
        /// 底层产生的触发抓拍帧标记
        /// </summary>
        public int                              nMark;                          
        /// <summary>
        /// video analysis frame no.
        /// 视频分析帧序号
        /// </summary>
        public int                              nFrameSequence;            
        /// <summary>
        /// video analysis data source address
        /// 视频分析的数据源地址
        /// </summary>
        public int                              nSource;                   
        /// <summary>
        /// detection object 
        /// 检测到的物体
        /// </summary>
        public NET_MSG_OBJECT                   stuObject;                 
        /// <summary>
        /// body info 
        /// 车身信息
        /// </summary>
        public NET_MSG_OBJECT                   stuVehicle;                
        /// <summary>
        /// Traffic vehicle info 
        /// 交通车辆信息
        /// </summary>
        public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stuTrafficCar;        
        /// <summary>
        /// vehicle actual speed,Km/h
        /// 车辆实际速度,Km/h
        /// </summary>
        public int                              nSpeed;                    
        /// <summary>
        /// main driver seat belt status 
        /// 主驾驶座位安全带状态
        /// </summary>
        public EM_SAFEBELT_STATE                emMainSeat;                
        /// <summary>
        /// co-drvier seat belt status
        /// 副驾驶座位安全带状态
        /// </summary>
        public EM_SAFEBELT_STATE                emSlaveSeat;               
        /// <summary>
        /// snapshot mark(by bit), see NET_RESERVED_COMMON  
        /// 抓图标志(按位),具体见NET_RESERVED_COMMON
        /// </summary>
        public uint                             dwSnapFlagMask;               
        /// <summary>
        /// corresponding to picture resolution
        /// 对应图片的分辨率
        /// </summary>
        public NET_RESOLUTION_INFO              stuResolution;             
        /// <summary>
        /// GPS info ,use in mobile DVR/NVR
        /// GPS信息 车载定制
        /// </summary>
        public NET_GPS_INFO                     stuGPSInfo;                
        /// <summary>
        /// reserved
        /// 保留字节
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 984)]
        public byte[]                           byReserved;                
        /// <summary>
        /// public info 
        /// 公共信息
        /// </summary>
        public NET_EVENT_COMM_INFO              stCommInfo;                
    }

}
