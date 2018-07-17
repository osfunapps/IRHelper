using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.project.hexwindow
{
    public partial class HexWindow : Form
    {
        private Task t;
        private IntPtr handle;

        public HexWindow()
        {
            InitializeComponent();
        }


        public void SetKeyAndHex(string key, string hex)
        {
            hexRTB.Invoke(new MethodInvoker(delegate { hexRTB.AppendText(key + "  " + hex+"\n"); }));
            focusBtn.Invoke(new MethodInvoker(delegate { focusBtn.Focus(); }));
        }


        public void Show()
        {
            t = Task.Run(() =>
            {
                ShowDialog();
                BringToFront();
                TopMost = true;
            });
        }



        private const UInt32 WM_HSCROLL = 0x0114;
        private const UInt32 SB_LEFT = 0x055;

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool PostMessage(IntPtr hWnd, UInt32 Msg,
            IntPtr wParam, IntPtr lParam);

        private void HandleRichTextBoxAdjustScroll(Object sender,
            EventArgs e)
        {
            PostMessage(handle, WM_HSCROLL, (IntPtr)SB_LEFT, IntPtr.Zero);
        }

    }


}
