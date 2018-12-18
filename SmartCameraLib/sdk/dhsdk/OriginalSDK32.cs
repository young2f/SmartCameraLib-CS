
// if the OS is linux open this define when compile the library.﻿ and if the OS is linux 64bit open define LINUX_X64 in the NetSDKStruct.cs file.
// 如果系统是Linux请打开下面的宏,如果是Linux 64位,请把NetSDKStruct.cs中的宏也打开.
//#define LINUX  
﻿
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using NetSDKCS32;

namespace NetSDKCS
{
    internal static class OriginalSDK32
    {
#if(LINUX)
        const string LIBRARYNETSDK = "libdhnetsdk.so";
        const string LIBRARYCONFIGSDK = "libdhconfigsdk.so";
#else
        const string LIBRARYNETSDK = @"\.\dhsdk32\dhnetsdk.dll";
        const string LIBRARYCONFIGSDK = @"\.\dhsdk32\dhconfigsdk.dll";
#endif

        [DllImport(LIBRARYNETSDK)]
		public static extern int CLIENT_GetLastError();

        [DllImport(LIBRARYNETSDK)]
		public static extern bool CLIENT_InitEx(fDisConnectCallBack cbDisConnect, IntPtr dwUser, IntPtr lpInitParam);

        [DllImport(LIBRARYNETSDK)]
		public static extern void CLIENT_Cleanup();

        [DllImport(LIBRARYNETSDK)]
		public static extern IntPtr CLIENT_LoginEx2(string pchDVRIP, ushort wDVRPort, string pchUserName, string pchPassword, EM_LOGIN_SPAC_CAP_TYPE emSpecCap, IntPtr pCapParam, ref NET_DEVICEINFO_Ex lpDeviceInfo, ref int error);

        [DllImport(LIBRARYNETSDK)]
		public static extern bool CLIENT_Logout(IntPtr lLoginID);

        [DllImport(LIBRARYNETSDK)]
		public static extern void CLIENT_SetAutoReconnect(fHaveReConnectCallBack cbAutoConnect, IntPtr dwUser);

        [DllImport(LIBRARYNETSDK)]
		public static extern void CLIENT_SetNetworkParam(IntPtr pNetParam);

        [DllImport(LIBRARYNETSDK)]
		public static extern IntPtr CLIENT_StartRealPlay(IntPtr lLoginID, int nChannelID, IntPtr hWnd, EM_RealPlayType rType, fRealDataCallBackEx cbRealData, fRealPlayDisConnectCallBack cbDisconnect, IntPtr dwUser, uint dwWaitTime);

        [DllImport(LIBRARYNETSDK)]
		public static extern bool CLIENT_StopRealPlayEx(IntPtr lRealHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_RealPlayEx(IntPtr lLoginID, int nChannelID, IntPtr hWnd, EM_RealPlayType rType);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SetRealDataCallBackEx2(IntPtr lRealHandle, fRealDataCallBackEx2 cbRealData, IntPtr dwUser, uint dwFlag);

        [DllImport(LIBRARYNETSDK)]
		public static extern bool CLIENT_SaveRealData(IntPtr lRealHandle, string pchFileName);

        [DllImport(LIBRARYNETSDK)]
		public static extern bool CLIENT_StopSaveRealData(IntPtr lRealHandle);

        [DllImport(LIBRARYNETSDK)]
		public static extern void CLIENT_SetSnapRevCallBack(fSnapRevCallBack OnSnapRevMessage, IntPtr dwUser);

        [DllImport(LIBRARYNETSDK)]
		public static extern bool CLIENT_SnapPictureEx(IntPtr lLoginID, ref NET_SNAP_PARAMS par, IntPtr reserved);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SnapPictureToFile(IntPtr lLoginID, ref NET_IN_SNAP_PIC_TO_FILE_PARAM inParam, ref NET_OUT_SNAP_PIC_TO_FILE_PARAM outParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
		public static extern IntPtr CLIENT_PlayBackByTimeEx2(IntPtr lLoginID, int nChannelID, ref NET_IN_PLAY_BACK_BY_TIME_INFO pstNetIn, ref NET_OUT_PLAY_BACK_BY_TIME_INFO pstNetOut);

        [DllImport(LIBRARYNETSDK)]
		public static extern bool CLIENT_QueryRecordFile(IntPtr lLoginID, int nChannelId, int nRecordFileType, ref NET_TIME tmStart, ref NET_TIME tmEnd, string pchCardid, IntPtr nriFileinfo, int maxlen, ref int filecount, int waittime, bool bTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_GetPlayBackOsdTime(IntPtr lPlayHandle, ref NET_TIME lpOsdTime, ref NET_TIME lpStartTime, ref NET_TIME lpEndTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_CapturePictureEx(IntPtr hPlayHandle, string pchPicFileName, EM_NET_CAPTURE_FORMATS eFormat);

        [DllImport(LIBRARYNETSDK)]
		public static extern bool CLIENT_StopPlayBack(IntPtr lPlayHandle);

        [DllImport(LIBRARYNETSDK)]
		public static extern IntPtr CLIENT_DownloadByTimeEx(IntPtr lLoginID, int nChannelId, int nRecordFileType, ref NET_TIME tmStart, ref NET_TIME tmEnd, string sSavedFileName,
			fTimeDownLoadPosCallBack cbTimeDownLoadPos, IntPtr dwUserData,
			fDataCallBack fDownLoadDataCallBack, IntPtr dwDataUser, IntPtr pReserved);

        [DllImport(LIBRARYNETSDK)]
		public static extern bool CLIENT_StopDownload(IntPtr lFileHandle);

        [DllImport(LIBRARYNETSDK)]
		public static extern bool CLIENT_GetDownloadPos(IntPtr lFileHandle, ref int nTotalSize, ref int nDownLoadSize);

        [DllImport(LIBRARYNETSDK)]
		public static extern bool CLIENT_DHPTZControlEx2(IntPtr lLoginID, int nChannelID, uint dwPTZCommand, int lParam1, int lParam2, int lParam3, bool dwStop, IntPtr param4);

        [DllImport(LIBRARYNETSDK)]
		public static extern bool CLIENT_OpenSound(IntPtr hPlayHandle);

        [DllImport(LIBRARYNETSDK)]
		public static extern bool CLIENT_CloseSound();

        [DllImport(LIBRARYNETSDK)]
		public static extern bool CLIENT_PausePlayBack(IntPtr lPlayHandle, bool bPause);

        [DllImport(LIBRARYNETSDK)]
		public static extern bool CLIENT_FastPlayBack(IntPtr lPlayHandle);

        [DllImport(LIBRARYNETSDK)]
		public static extern bool CLIENT_SlowPlayBack(IntPtr lPlayHandle);

        [DllImport(LIBRARYNETSDK)]
		public static extern bool CLIENT_NormalPlayBack(IntPtr lPlayHandle);

        [DllImport(LIBRARYNETSDK)]
		public static extern bool CLIENT_SetDeviceMode(IntPtr lLoginID, EM_USEDEV_MODE emType, IntPtr pValue);

        [DllImport(LIBRARYNETSDK)]
		public static extern void CLIENT_SetDVRMessCallBackEx1(fMessCallBackEx cbMessage, IntPtr dwUser);

        [DllImport(LIBRARYNETSDK)]
		public static extern bool CLIENT_StartListenEx(IntPtr lLoginID);

        [DllImport(LIBRARYNETSDK)]
		public static extern bool CLIENT_StopListen(IntPtr lLoginID);

        [DllImport(LIBRARYNETSDK)]
		public static extern IntPtr CLIENT_RealLoadPictureEx(IntPtr lLoginID, int nChannelID, uint dwAlarmType, bool bNeedPicFile, fAnalyzerDataCallBack cbAnalyzerData, IntPtr dwUser, IntPtr reserved);

        [DllImport(LIBRARYNETSDK)]
		public static extern bool CLIENT_StopLoadPic(IntPtr lAnalyzerHandle);

        [DllImport(LIBRARYNETSDK)]
		public static extern bool CLIENT_QuerySystemInfo(IntPtr lLoginID, int nSystemType, IntPtr pSysInfoBuffer, int maxlen, ref int nSysInfolen, int waittime);

        [DllImport(LIBRARYNETSDK)]
		public static extern bool CLIENT_QueryDeviceLog(IntPtr lLoginID, ref NET_QUERY_DEVICE_LOG_PARAM pQueryParam, IntPtr pLogBuffer, int nLogBufferLen, ref int pRecLogNum, int waittime);

        [DllImport(LIBRARYNETSDK)]
		public static extern IntPtr CLIENT_StartTalkEx(IntPtr lLoginID, fAudioDataCallBack pfcb, IntPtr dwUser);

        [DllImport(LIBRARYNETSDK)]
		public static extern bool CLIENT_StopTalkEx(IntPtr lTalkHandle);

        [DllImport(LIBRARYNETSDK)]
		public static extern bool CLIENT_RecordStartEx(IntPtr lLoginID);

        [DllImport(LIBRARYNETSDK)]
		public static extern bool CLIENT_RecordStopEx(IntPtr lLoginID);

        [DllImport(LIBRARYNETSDK)]
		public static extern int CLIENT_TalkSendData(IntPtr lTalkHandle, IntPtr pSendBuf, uint dwBufSize);

        [DllImport(LIBRARYNETSDK)]
		public static extern void CLIENT_AudioDec(IntPtr pAudioDataBuf, uint dwBufSize);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_ControlDevice(IntPtr lLoginID, EM_CtrlType type, IntPtr param, int waittime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_QueryDevState(IntPtr lLoginID, int nType, IntPtr pBuf, int nBufLen, ref int pRetLen, int waittime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_QueryNewSystemInfo(IntPtr lLoginID, string szCommand, Int32 nChannelID, IntPtr szOutBuffer, UInt32 dwOutBufferSize, ref UInt32 error, Int32 waittime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_FindRecord(IntPtr lLoginID, ref NET_IN_FIND_RECORD_PARAM pInParam, ref NET_OUT_FIND_RECORD_PARAM pOutParam, int waittime);

        [DllImport(LIBRARYNETSDK)]
        public static extern int CLIENT_FindNextRecord(ref NET_IN_FIND_NEXT_RECORD_PARAM pInParam, ref NET_OUT_FIND_NEXT_RECORD_PARAM pOutParam, int waittime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_QueryRecordCount(ref NET_IN_QUEYT_RECORD_COUNT_PARAM pInParam, ref NET_OUT_QUEYT_RECORD_COUNT_PARAM pOutParam, int waittime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_FindRecordClose(IntPtr lFindHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_StartFindNumberStat(IntPtr lLoginID, ref NET_IN_FINDNUMBERSTAT pstInParam, ref NET_OUT_FINDNUMBERSTAT pstOutParam);

        [DllImport(LIBRARYNETSDK)]
        public static extern int CLIENT_DoFindNumberStat(IntPtr lFindHandle, ref NET_IN_DOFINDNUMBERSTAT pstInParam, ref NET_OUT_DOFINDNUMBERSTAT pstOutParam);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_StopFindNumberStat(IntPtr lFindHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_AttachVideoStatSummary(IntPtr lLoginID, ref NET_IN_ATTACH_VIDEOSTAT_SUM pInParam, ref NET_OUT_ATTACH_VIDEOSTAT_SUM pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_DetachVideoStatSummary(IntPtr lAttachHandle);

        [DllImport(LIBRARYNETSDK)]
        public static extern IntPtr CLIENT_CreateTransComChannel(IntPtr lLoginID, int TransComType, uint baudrate, uint databits, uint stopbits, uint parity, fTransComCallBack cbTransCom, IntPtr dwUser);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SendTransComData(IntPtr lTransComChannel, IntPtr pBuffer, uint dwBufSize);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_DestroyTransComChannel(IntPtr  lTransComChannel);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SetSecurityKey(IntPtr lPlayHandle, string szKey, uint nKeyLen);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_QueryMatrixCardInfo(IntPtr lLoginID, ref NET_MATRIX_CARD_LIST pstuCardList, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SetNewDevConfig(IntPtr lLoginID, string szCommand, int nChannelId, IntPtr szInBuffer, uint dwInBufferSize, ref int error, ref int restart, int waittime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_GetNewDevConfig(IntPtr lLoginId, string szCommand, int nChannelId, IntPtr szOutBUffer, uint dwOutBufferSize, out int error, int nwaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_GetSplitCaps(IntPtr lLoginId, int nChannel, ref NET_SPLIT_CAPS pstuCaps, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SetSplitMode(IntPtr lLoginID, int nChannel, ref NET_SPLIT_MODE_INFO pstuSplitInfo, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_OpenSplitWindow(IntPtr lLoginID, ref NET_IN_SPLIT_OPEN_WINDOW pInParam, ref NET_OUT_SPLIT_OPEN_WINDOW pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_MatrixGetCameras(IntPtr lLoginID, ref NET_IN_MATRIX_GET_CAMERAS pInParam, ref NET_OUT_MATRIX_GET_CAMERAS pOutParam, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SetSplitSource(IntPtr lLoginID, int nChannel, int nWindow, IntPtr pstuSplitSrc, int nSrcCount, int nWaitTime);

        [DllImport(LIBRARYNETSDK)]
        public static extern bool CLIENT_SetSplitSourceEx(IntPtr lLoginID, ref NET_IN_SET_SPLIT_SOURCE pInparam, ref NET_OUT_SET_SPLIT_SOURCE pOutParam, int nWaitTime);

        [DllImport(LIBRARYCONFIGSDK)]
        public static extern bool CLIENT_ParseData(string szCommand, IntPtr szInBuffer, IntPtr lpOutBuffer, UInt32 dwOutBufferSize, IntPtr pReserved);

        [DllImport(LIBRARYCONFIGSDK)]
        public static extern bool CLIENT_PacketData(string szCommand, IntPtr lpInBuffer, uint dwInBufferSize, IntPtr szOutBuffer, uint dwOutFufferSize);
		
    }
}
