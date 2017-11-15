using LayoutProject.program;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using WindowsFormsApp1.program.tools;
using WindowsFormsApp1.project;
using WindowsFormsApp1.project.ghost;
using Remotes_App_Translation_Project.tools;

namespace WindowsFormsApp1
{
    public partial class AppForm : Form
    {
        //instances
        private AppCoordinator appCoordinator;

        //outside params!
        private static string xmlPathStr;
        private static string eventGohstPath;
        internal static bool startOver;
        internal static int cyclesToWait;
        private static string userPauseBtnName;
        private static bool textToSpeech;


        public AppForm()
        {
            SetInstances();
            InitializeComponent();
            SetCBItems();
            LoadPrefs();

        }

        private void LoadPrefs()
        {
            textToSpeechCB.Checked = UserSettings.getIntance().GetTxtToSpeech();
            evenGohstPathTB.Text = UserSettings.getIntance().GetEventGhostPath();
        }


        private void SetInstances()
        {
            appCoordinator = new AppCoordinator();
        }

        private void Go_Clicked(object sender, EventArgs e)
        {
            userPauseBtnName = pauseBtnCB.SelectedItem.ToString();
            cyclesToWait = cyclesWaitScroller.Value;
            startOver = startOverCB.Checked;
            goBtn.Enabled = false;
            xmlPathStr = xmlPathTB.Text;
            eventGohstPath = evenGohstPathTB.Text;
            RegistryHandler.DisableWindowsErrorReporting(true);
            UserSettings.getIntance().SaveSettings(evenGohstPathTB.Text, textToSpeechCB.Checked);
            textToSpeech = textToSpeechCB.Checked;
            appCoordinator.WaitForRightClickOnBar();

        }

        internal static string GetXmlPath()
        {
            return xmlPathStr;
        }


        internal static string GetEventGohstPath()
        {
            return eventGohstPath;
        }

        internal static string GetUserPauseBtnName()
        {
            return userPauseBtnName;
        }


        //getters
        private void Browse_Xml_Path_clicked(object sender, EventArgs e){xmlPathDialog.ShowDialog();}
        private void Browse_Remote_Pic_Path_clicked(object sender, EventArgs e){remotePicDialog.ShowDialog();}
        private string TitleExporter(string fileLongStr) { return fileLongStr.ToString().Substring(fileLongStr.ToString().IndexOf("FileName: ") + 10); }

        //dialog clicks
        private void RemotePicDialog_FileOk(object sender, CancelEventArgs e){evenGohstPathTB.Text = TitleExporter(sender.ToString());}

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            xmlPathTB.Text = TitleExporter(sender.ToString());
        }


        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            cyclesToWait = cyclesWaitScroller.Value;
            Console.WriteLine("cycles to wait changed to: "+cyclesToWait);
        }

        protected void SetCBItems()
        {
            foreach (string btnName in Enum.GetNames(typeof(VirtualKeyCode)))
                this.pauseBtnCB.Items.Add(btnName);

            pauseBtnCB.SelectedItem = VirtualKeyCode.LeftShift.ToString();
        }

        private void DragEnterHandler(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }


        private void EventGohstPathDropHandler(object sender, DragEventArgs e)
        {
            evenGohstPathTB.Text = ((string[])e.Data.GetData(DataFormats.FileDrop, false))[0];
        }

        private void XmlPathDropHandler(object sender, DragEventArgs e)
        {
            xmlPathTB.Text = ((string[])e.Data.GetData(DataFormats.FileDrop, false))[0];
        }

        private void LogBtn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(Logger.GetTxt(), Logger.TITLE);
        }

     
        private void ActionsBtn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(ActionsTxt.GetTxt(), ActionsTxt.TITLE);
        }

        private void evenGohstPathTB_TextChanged(object sender, EventArgs e)
        {

        }

        public static bool TextToSpeech
        {
            get => textToSpeech;
            set => textToSpeech = value;
        }
    }
}
