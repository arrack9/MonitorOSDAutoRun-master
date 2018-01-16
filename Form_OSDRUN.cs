using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;


namespace MonitorOSDAutoRun
{
    public partial class Form_OSDRUN : Form
    {
        [DllImport("kernel32")]
        static extern uint GetTickCount();
        [DllImport("winmm")]
        static extern uint timeGetTime();
        [DllImport("winmm")]
        static extern void timeBeginPeriod(int t);
        [DllImport("winmm")]
        static extern void timeEndPeriod(int t);
        
        bool isPressStartButton = false;
        bool isFristLoop = true;
       
        Thread thd_OSDDisplayDirectly;
        //Thread thd_ReadFeedBackFromMNT;
        int menuIndex = 0;
        int menuKeylabel = 8;
        int menuIndexMAX = 62;
        int languageIndex = 0;
        int sendDataCounter = 0;
        int timerInterval = 0;
        int getMenuIndex = 0;
        

        FTDI FTDI = new FTDI();
                    
        //static int maxIntValue = 2147483647;  // Set maxIntValue to the maximum value for integers.  

         int[] Language = new int[11];
         static int LANGUAGE_TRACHINESE = 0x01;
         static int LANGUAGE_ENGLISH = 0x02;
         static int LANGUAGE_FRANCAIS = 0x03;
         static int LANGUAGE_DEUTSCH = 0x04;
         static int LANGUAGE_ITALIANO = 0x05;
         static int LANGUAGE_JAPAN = 0x06;
         static int LANGUAGE_PORTUGUESE = 0x08;
         static int LANGUAGE_ESPANOL = 0x0A;
         static int LANGUAGE_SIMCHINESE = 0x0D;
         static int LANGUAGE_NEDERLANDS = 0x14;
         static int LANGUAGE_MAX = 0xFF;
        private void InitialLanguage()
        {
         Language[0] = LANGUAGE_TRACHINESE;
         Language[1] = LANGUAGE_ENGLISH;
         Language[2] = LANGUAGE_FRANCAIS;
         Language[3] = LANGUAGE_DEUTSCH;
         Language[4] = LANGUAGE_ITALIANO;
         Language[5] = LANGUAGE_JAPAN;
         Language[6] = LANGUAGE_PORTUGUESE;
         Language[7] = LANGUAGE_ESPANOL;
         Language[8] = LANGUAGE_SIMCHINESE;
         Language[9] = LANGUAGE_NEDERLANDS;
         Language[10] = LANGUAGE_MAX;
        }
        /*
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.ShowInTaskbar = false; 
            this.Visible = false;
        }
        */
        public Form_OSDRUN()
        {
            InitializeComponent();
            InitialLanguage();
            menuIndex = menuKeylabel;
            MsgBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;  
			ReadDataTime.Tick += new System.EventHandler(ReadFeedBackFromMNT); 
        }

        private void PrintMenuIndex(int getMenuIndex)
        {
            MsgBox.Invoke(new Action(() =>
            {               
                MsgBox.AppendText("getMenuIndex " + getMenuIndex.ToString() + "\r\n");
                MsgBox.AppendText("Time :" + DateTime.Now + "\r\n");
            })); 
        }

        private void SetOSDLanguage(int languageIndex)
        {
        	FTDI.SetOSDLanguage(Language[languageIndex]);
        }

        private void OSDRUN()
        {
        	FTDI.SetOSDSisplayDirectly(menuIndex++);        
            MsgBox.Invoke(new Action(() =>
            {               
                MsgBox.AppendText("menuIndex " + menuIndex.ToString() + "\r\n");
                MsgBox.AppendText("Time :" + DateTime.Now + "\r\n");
            }));
            isFristLoop = false;  
        }

        private void ReadFeedBackFromMNT(object sender, EventArgs e)
        {
            getMenuIndex = FTDI.GetOSDMenuIndex();            
        }
        
        private void Btn_All_Lock(bool btnLock)
        {
            if (btnLock)
            {
                Btn_SaveTextFile.Enabled = false;
                Btn_ShowMenu.Enabled = false;
            }
            else
            {
                Btn_SaveTextFile.Enabled = true;
                Btn_ShowMenu.Enabled = true;
            }
        }
        private int CheckTimerInterval(bool isFristLoop)
        {
            if (isFristLoop == true)
                timerInterval = 3000;
            else
            {
                timerInterval = 6000;
            }

            if (thd_OSDDisplayDirectly.IsAlive && (Language[languageIndex] == Language[10]))
            {
                Btn_ShowMenu.Invoke(new Action(() => { Btn_All_Lock(false); }));
                thd_OSDDisplayDirectly.Abort();
                thd_OSDDisplayDirectly.Join();
                isPressStartButton = false;
                RunTime.Enabled = false;
                ReadDataTime.Enabled = false;
            }
            return timerInterval;
        }
        
        private void MsTimeCorrectionForOSDRun()  //減少timer誤差
        {
            timeBeginPeriod(1);
            uint start = timeGetTime();
            while (isPressStartButton == true)
            {
                uint now = timeGetTime();
                if ((now - start) >= CheckTimerInterval(isFristLoop))
                {
                    if ((menuIndex == menuIndexMAX)||(languageIndex == 0))
                    {                 
						SetOSDLanguage(languageIndex);
                        languageIndex++;                    	
                        MsgBox.Invoke(new Action(() => {
                        MsgBox.AppendText("OSDLanguage: " + languageIndex + "\r\n");
                        }));
                        menuIndex = menuKeylabel;
                    }
                    OSDRUN();
                    PrintMenuIndex(menuIndex);
                    start = now;
                }
                sendDataCounter++;                
            }
            timeEndPeriod(1);        
        }

        private void Btn_ShowMenu_Click(object sender, EventArgs e)
        {
            isPressStartButton = true;
            MsgBox.AppendText("StartTime :" + DateTime.Now + "\r\n");
            thd_OSDDisplayDirectly = new Thread(new ThreadStart(MsTimeCorrectionForOSDRun));
            thd_OSDDisplayDirectly.IsBackground = true;
            thd_OSDDisplayDirectly.Start();
            RunTime.Enabled = true;
            Btn_All_Lock(true);
        }

        private void Btn_SaveTextFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "txt files (*.txt)|*.txt|all files|*.*";
            sfd.FileName = "Log";
            sfd.DefaultExt = "txt";
            sfd.AddExtension = true;
            if (sfd.ShowDialog() == DialogResult.OK
                     && sfd.FileName.Length > 0)
            {
                MessageBox.Show("Save Path: " + sfd.FileName.ToString());  //印出儲存路徑
                File.Copy(@"D:\log.txt", @sfd.FileName.ToString());
            }
            MsgBox.Clear();
            File.Delete(@"D:\log.txt");
            Application.Exit();
        }
		void Btn_ReadClick(object sender, EventArgs e)
		{
			FTDI.SetOSDLanguage(Language[languageIndex++]);
			MsgBox.AppendText("Language: " + Language[9]);			
		}
    }
}
