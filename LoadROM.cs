﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using System.IO.Ports;
using Microsoft.Win32;

namespace Multi_IAP_Application
{
    public partial class LoadROM : Form
    {
        public string ROM_Path;
        public string romVer;
        public string ROM_Path2;
        public string romVer2;

        public string ROMLB3_3_Path;
        public string ROMLB_3_3_Ver;
        public string ROMLB3_4_Path;
        public string ROMLB_3_4_Ver;


        int ROMLB_3_3_Bin_Size;
        BinaryReader ROMLB_3_3_bin_read;
        byte[] ROMLB_3_3_bytes;


        int ROMLB_3_4_Bin_Size;
        BinaryReader ROMLB_3_4_bin_read;
        byte[] ROMLB_3_4_bytes;



        public LoadROM()
        {
            InitializeComponent();

            ROMLB3_3_Path = Properties.Settings.Default.LB3_3_FilePath;
            ROMLB3_4_Path = Properties.Settings.Default.LB3_4_FilePath;


            textBox1.Text = ROMLB3_3_Path;
            textBox3.Text = ROMLB3_4_Path;


            listView1.Items[0].SubItems[1].Text = Path.GetFileName(ROMLB3_3_Path);
            listView1.Items[1].SubItems[1].Text = Path.GetFileName(ROMLB3_4_Path);

            if (ROMLB3_3_Path != "")
            {
                FileInfo info1 = new FileInfo(ROMLB3_3_Path);
                int size1 = (int)info1.Length;
                ROMLB_3_3_Bin_Size = size1;
                FileStream fs1 = new FileStream(ROMLB3_3_Path, FileMode.Open, FileAccess.Read);
                ROMLB_3_3_bin_read = new BinaryReader(fs1);
                ROMLB_3_3_bytes = new byte[ROMLB_3_3_Bin_Size];
                ROMLB_3_3_bytes = ROMLB_3_3_bin_read.ReadBytes(ROMLB_3_3_Bin_Size);
                ROMLB_3_3_bin_read.Close();
                fs1.Close();
            }

            if (ROMLB3_4_Path != "")
            {
                FileInfo info2 = new FileInfo(ROMLB3_4_Path);
                int size2 = (int)info2.Length;
                ROMLB_3_4_Bin_Size = size2;
                FileStream fs2 = new FileStream(ROMLB3_4_Path, FileMode.Open, FileAccess.Read);
                ROMLB_3_4_bin_read = new BinaryReader(fs2);
                ROMLB_3_4_bytes = new byte[ROMLB_3_4_Bin_Size];
                ROMLB_3_4_bytes = ROMLB_3_4_bin_read.ReadBytes(ROMLB_3_4_Bin_Size);
                ROMLB_3_4_bin_read.Close();
                fs2.Close();
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "E:\\";
            openFileDialog.Filter = "Bin文件(*.bin)|*.bin";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            openFileDialog.Multiselect = true;//允许同时选择多个文件
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                ROMLB3_3_Path = openFileDialog.FileName;
                listView1.Items[0].SubItems[1].Text = Path.GetFileName(ROMLB3_3_Path);

                textBox1.Text = ROMLB3_3_Path;
                Properties.Settings.Default.LB3_3_FilePath = ROMLB3_3_Path;
                Properties.Settings.Default.Save();  // save 文件路径

                if (ROMLB3_3_Path != "")
                {
                    FileInfo info1 = new FileInfo(ROMLB3_3_Path);
                    int size1 = (int)info1.Length;
                    ROMLB_3_3_Bin_Size = size1;
                    FileStream fs1 = new FileStream(ROMLB3_3_Path, FileMode.Open, FileAccess.Read);
                    ROMLB_3_3_bin_read = new BinaryReader(fs1);
                    ROMLB_3_3_bytes = new byte[ROMLB_3_3_Bin_Size];
                    ROMLB_3_3_bytes = ROMLB_3_3_bin_read.ReadBytes(ROMLB_3_3_Bin_Size);
                    ROMLB_3_3_bin_read.Close();
                    fs1.Close();
                }



                ROM_Path = openFileDialog.FileName;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
                romVer = textBox2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "E:\\";
            openFileDialog.Filter = "Bin文件(*.bin)|*.bin";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            openFileDialog.Multiselect = true;//允许同时选择多个文件
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                ROMLB3_4_Path = openFileDialog.FileName;
                listView1.Items[1].SubItems[1].Text = Path.GetFileName(ROMLB3_4_Path);

                textBox3.Text = ROMLB3_4_Path;

                Properties.Settings.Default.LB3_4_FilePath = ROMLB3_4_Path;
                Properties.Settings.Default.Save();  // save 文件路径
                string tPath = Properties.Settings.Default.LB3_4_FilePath;

                if (ROMLB3_4_Path != "")
                {
                    FileInfo info2 = new FileInfo(openFileDialog.FileName);
                    int size2 = (int)info2.Length;
                    ROMLB_3_4_Bin_Size = size2;
                    FileStream fs2 = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);
                    ROMLB_3_4_bin_read = new BinaryReader(fs2);
                    ROMLB_3_4_bytes = new byte[ROMLB_3_4_Bin_Size];
                    ROMLB_3_4_bytes = ROMLB_3_4_bin_read.ReadBytes(ROMLB_3_4_Bin_Size);
                    ROMLB_3_4_bin_read.Close();
                    fs2.Close();
                }
                ROM_Path2 = openFileDialog.FileName;

            }
        }
    }
}
