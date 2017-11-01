using EventHook;
using System.Windows.Forms;
using WindowsInput;
using System;
using System.Threading;
using WindowsFormsApp1.project.ghost;
using WindowsInput.Native;
using WindowsFormsApp1.project.ghost.inputssimulator;
using WindowsFormsApp2.project.mouse;

namespace WindowsFormsApp1
{
    internal class KeyboardMouseSimulator : IWindowChangedListener
    {

        //callback
        private IOnInputSimulateCallback onInputSimulateCallback;


        public static string WINDOW_TITLE_LEARN_IR_CODE = "Learn IR Code";
        internal static string WINDOW_TITLE_HEX_CODE = "Action Item Settings";

        //window titles params


        private static bool hexCopied;
        public KeyboardMouseSimulator(IOnInputSimulateCallback onInputSimulateCallback)
        {
            this.onInputSimulateCallback = onInputSimulateCallback;
        }

        //1) on first launch of the program, select the bottom item and click on it
        public void Select_USB_UIRT_InMenu()
        {
            Thread.Sleep(1000);
            ActionSimulator.ClickOnBtn(VirtualKeyCode.UP);
            ActionSimulator.ClickOnBtn(VirtualKeyCode.DOWN);
            ActionSimulator.ClickOnBtn(VirtualKeyCode.DOWN);
            ActionSimulator.ClickOnBtn(VirtualKeyCode.DOWN);
            ActionSimulator.ClickOnBtn(VirtualKeyCode.RETURN);
            WaitForWindowTitle(WINDOW_TITLE_HEX_CODE, this);
            //WaitForWindowTitle(WINDOW_TITLE_HEX_CODE, true, this);

        }

        //2) click on "learn an ir code"
        public void ClickOnLearnIrCode()
        {
            Console.WriteLine("clicking tab");
            ActionSimulator.ClickOnBtn(VirtualKeyCode.TAB);
            Console.WriteLine("clicking tab");
            ActionSimulator.ClickOnBtn(VirtualKeyCode.TAB);
            Console.WriteLine("clicking tab");
            ActionSimulator.ClickOnBtn(VirtualKeyCode.TAB);
            Console.WriteLine("clicking tab");
            ActionSimulator.ClickOnBtn(VirtualKeyCode.TAB);
            Console.WriteLine("clicking tab");
            ActionSimulator.ClickOnBtn(VirtualKeyCode.TAB);
            Console.WriteLine("clicking return");
            ActionSimulator.ClickOnBtn(VirtualKeyCode.RETURN);
            Console.WriteLine("waiting for window title");
            WaitForWindowTitle(WINDOW_TITLE_LEARN_IR_CODE, this);
            //WaitForWindowTitle(WINDOW_TITLE_LEARN_IR_CODE, true, this);

        }


        //3) After the green screen will be filled, close the window and go back
        public void CloseRecordWindow()
        {
            if (!ExeWindowTitleReader.GetActiveWindowTitle().Equals(WINDOW_TITLE_LEARN_IR_CODE))
            {
                onInputSimulateCallback.OnBackToMainScreenError();
                return;
            }

            ActionSimulator.ClickOnBtn(VirtualKeyCode.TAB);
            ActionSimulator.ClickOnBtn(VirtualKeyCode.TAB);
            ActionSimulator.ClickOnBtn(VirtualKeyCode.RETURN);
            //WaitForWindowTitle(WINDOW_TITLE_HEX_CODE, false, this);
            onInputSimulateCallback.OnTryingToCloseRecordWindow();
        }


        //4) Copy the hex you got inside the box
        public void CopyHexInBox()
        {
            hexCopied = false;
            StartClipboardListin();
            SelectAll();
            Copy();
        }

        private void SelectAll()
        {

            ActionSimulator.ClickRightMouseBtn();
            ActionSimulator.ClickOnBtn(VirtualKeyCode.DOWN);
            ActionSimulator.ClickOnBtn(VirtualKeyCode.DOWN);
            ActionSimulator.ClickOnBtn(VirtualKeyCode.DOWN);
            ActionSimulator.ClickOnBtn(VirtualKeyCode.DOWN);
            ActionSimulator.ClickOnBtn(VirtualKeyCode.DOWN);
            ActionSimulator.ClickOnBtn(VirtualKeyCode.DOWN);
            ActionSimulator.ClickOnBtn(VirtualKeyCode.RETURN);
        }

        private void Copy()
        {
            ActionSimulator.HoldDownOnBtn(VirtualKeyCode.CONTROL);
            ActionSimulator.ClickOnBtn(VirtualKeyCode.VK_C);
            ActionSimulator.ReleaseBtn(VirtualKeyCode.CONTROL);
            Console.WriteLine("released clicked!");
        }

        private void StartClipboardListin()
        {
            ClipboardWatcher.OnClipboardModified += new EventHandler<ClipboardEventArgs>(ClipboardListener);
            ClipboardWatcher.Start();
        }

        private void ClipboardListener(object sender, ClipboardEventArgs e)
        {
            if (hexCopied)
            {
              //  releaseCtrl();
                return;
            }


            hexCopied = true; 
            Thread.Sleep(150);
            //releaseCtrl();
            SendHexBack();
        }

    /*    internal void releaseCtrl()
        {
            ActionSimulator.ReleaseBtn(VirtualKeyCode.RCONTROL);
            ActionSimulator.ReleaseBtn(VirtualKeyCode.CONTROL);
            ActionSimulator.ReleaseBtn(VirtualKeyCode.LCONTROL);
        }*/

        internal void CloseWindowsTryToFixWindow()
        {
            //releaseCtrl();
            ActionSimulator.ClickLeftMouseBtn();
            ActionSimulator.ClickOnBtn(VirtualKeyCode.RETURN);
        }

        private void SendHexBack()
        {
            var hexCopied = Clipboard.GetText(TextDataFormat.Text);
            ClipboardWatcher.Stop();
            onInputSimulateCallback.OnCopyBoxDone(hexCopied);
        }

        private void WaitForWindowTitle(string windowTitle, IWindowChangedListener windowChangedListener)
        //private void WaitForWindowTitle(string windowTitle, bool firstVisit, IWindowChangedListener windowChangedListener)
        {
            var windowDidntChangeYet = true;
            while (windowDidntChangeYet)
            {
                Thread.Sleep(250);
                if (ExeWindowTitleReader.GetActiveWindowTitle() == null || CursorIcon.IsCursorType(Cursors.WaitCursor.Handle))
                {
                    onInputSimulateCallback.OnBackToMainScreenError();
                    return;
                }
                if (ExeWindowTitleReader.GetActiveWindowTitle().Equals(windowTitle))
                    windowDidntChangeYet = false;
            }

            //windowChangedListener.OnWindowChanged(windowTitle, firstVisit);
            windowChangedListener.OnWindowChanged(windowTitle);
        }


        public void OnWindowChanged(string currentWindowTitle)
        //public void OnWindowChanged(string currentWindowTitle, bool firstVisit)
        {
            //open hex code box
            if (currentWindowTitle.Equals(WINDOW_TITLE_HEX_CODE))
            //if (currentWindowTitle.Equals(WINDOW_TITLE_HEX_CODE) && firstVisit)
                onInputSimulateCallback.On_USBUIRT_ItemSelected();

            //open learn ir code
            else if (currentWindowTitle.Equals(WINDOW_TITLE_LEARN_IR_CODE))
                onInputSimulateCallback.OnLearnIrCodeClicked();

            //close learn ir code and go back to hex box code
/*            else if (currentWindowTitle.Equals(WINDOW_TITLE_HEX_CODE) && !firstVisit)
                onInputSimulateCallback.OnTryingToCloseRecordWindow();
                */
        }
    }

    public interface IOnInputSimulateCallback
    {
        //1
        void On_USBUIRT_ItemSelected();

        //2
        void OnLearnIrCodeClicked();

        //3
        void OnTryingToCloseRecordWindow();

        //4
        void OnCopyBoxDone(string txtCopied);
        void OnBackToMainScreenError();
    }

    internal interface IWindowChangedListener
    {
        void OnWindowChanged(string windowTitle);
        //void OnWindowChanged(String windowTitle, bool firstVisit);
    }
}