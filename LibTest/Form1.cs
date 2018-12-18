using SmartCameraLib;
using SmartCameraLib.entity;
using SmartCameraLib.impl;
using SmartCameraLib.player;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LibTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }
        private delegate string runDelegate();
        List<ICameraPlay> playerList = new List<ICameraPlay>();
        private void Form1_Load(object sender, EventArgs e)
        {
            LogHelper.SetConfig();
            LogHelper.WriteLog("start");

            ICameraPlay play1 = new DHPlayer32();            
            playerList.Add(play1);
            CameraEntity entity1 = GetEntity(2);
            entity1.pHandle = pic1.Handle;
            play1.AsyncPlay(entity1, Callback);
         
            ICameraPlay play3 = new HKPlayer32();
            playerList.Add(play3);
            CameraEntity entity2 = GetEntity(1);
            entity2.pHandle = pic2.Handle;
            play3.AsyncPlay(entity2, Callback);

            ICameraPlay play2 = new DHPlayer32();
            playerList.Add(play2);
            CameraEntity entity3 = GetEntity(2);
            entity3.pHandle = pic3.Handle;
            play2.AsyncPlay(entity3, Callback);

            ICameraPlay play4 = new HKPlayer32();
            playerList.Add(play4);
            CameraEntity entity4 = GetEntity(1);
            entity4.pHandle = pic4.Handle;
            play4.AsyncPlay(entity4, Callback);


        }
        private void button1_Click(object sender, EventArgs e)
        {
            //  Test(MethodCallback);
            CameraEntity entity = GetEntity(2);
            entity.pHandle = GetHandle(0);
            ICameraPlay player =new  DHPlayer32();
            player.AsyncPlay(entity, Callback);
        }

        private void Test(AsyncCallback callback)
        {
            MyMethod my = method;
            IAsyncResult asyncResult = my.BeginInvoke(3, 300, callback, my);
            Console.WriteLine("任务开始");

        }
        private delegate int MyMethod(int second, int millisecond);
        //线程执行方法
        private int method(int second, int millisecond)
        {
            Console.WriteLine("线程休眠" + (second * 1000 + millisecond) + "毫秒");
            Thread.Sleep(second * 1000 + millisecond);
            Random random = new Random();
            return random.Next(10000);
        }
        //回调方法
        private void MethodCallback(IAsyncResult asyncResult)
        {
            if (asyncResult == null || asyncResult.AsyncState == null)
            {
                Console.WriteLine("回调失败！！！");
                return;
            }
            int result = (asyncResult.AsyncState as MyMethod).EndInvoke(asyncResult);
            Console.WriteLine("任务完成，结果：" + result);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(testThread);
            thread.IsBackground = true;
            thread.Start();
            button2.Enabled = false;
        }
        ICameraPlay player = null;
        private void testThread()
        {
            while (true)
            {
               
                for (int i = 0; i < 4; i++)
                {
                    ICameraPlay v = playerList[i];
                    int brand = GetNum();
                    Console.WriteLine("brand: " + brand);
                   // v.Stop();
                    if (v.GetCameraBrand() != brand)
                    {
                        v = GetCamera(brand);
                        playerList[i] = v;
                    }
                    CameraEntity entity = GetEntity(brand);
                    entity.pHandle = GetHandle(i);
                    v.AsyncPlay(entity, Callback);

                }
                Thread.Sleep(1000 * 5);

            }
        }
        private IntPtr GetHandle(int num)
        {
            switch (num)
            {
                case 0:
                    return pic1.Handle;
                case 1:
                    return pic2.Handle;
                case 2:
                    return pic3.Handle;
                case 3:

                    return pic4.Handle;
                default:
                    return pic4.Handle;
            }
        }
        private ICameraPlay GetCamera(int brand)
        {
            switch (brand)
            {
                case 1:
                    return new HKPlayer32();

                case 2: return new DHPlayer32();
                default:
                    return null;

            }

        }
        private CameraEntity GetEntity(int brand)
        {
            switch (brand)
            {
                case 1:
                    CameraEntity entity = new CameraEntity();
                    entity.IpAddress = "192.168.1.17";
                    entity.Port = 8000;
                    entity.UserName = "admin";
                    entity.Password = "admin123";
                    entity.Channel = 1;
                    return entity;
                case 2:
                    entity = new CameraEntity();
                    entity.IpAddress = "192.168.1.67";
                    entity.Port = 37777;
                    entity.UserName = "admin";
                    entity.Password = "admin";
                    entity.Channel = 1;
                    return entity;
                default:
                    return null;

            }

        }

        private void Play(PictureBox pic, CameraEntity entity)
        {
            if (player == null)
            {
                player = new HKPlayer32();
            }
         //   player.Stop();
            pic.BackColor = Color.Gray;
            pic.Refresh();

            entity.pHandle = pic.Handle;
            player.AsyncPlay(entity, Callback);
            LogHelper.WriteLog("play start");
        }
        List<IntPtr> loginList = new List<IntPtr>();
        List<IntPtr> playList = new List<IntPtr>();
        private void Callback(IAsyncResult asyncResult)
        {
            LoginResult playResult = (asyncResult.AsyncState as AsyncPlayDelegate).EndInvoke(asyncResult);

            if (playResult.isOk)
            {
                loginList.Add(playResult.loginId);
                playList.Add(playResult.playId);
                LogHelper.WriteLog(playResult.message + "-->" + playResult.camera.IpAddress);
            }
            else
            {
                LogHelper.WriteErrorLog(playResult.message + "-->" + playResult.camera.IpAddress);
            }
        }
        public int GetNum()
        {
            Random rd = new Random();
            return rd.Next(1, 3);
        }
    }
}
