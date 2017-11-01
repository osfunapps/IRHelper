using EventHook;
using LayoutProject.program;
using LayoutProject.program.values;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.program.valuesparser;
using WindowsFormsApp1.project.ghost;
using WindowsFormsApp1.project.ghost.mouselistener;
using WindowsFormsApp1.project.ghost.screenhelpers.colorchecker;
using WindowsFormsApp2.project.mouse;
using static LayoutProject.program.XMLModifier;
using static WindowsFormsApp1.project.ghost.mouselistener.MouseEventListener;
using static WindowsFormsApp1.project.ghost.ProgramExe;
using static WindowsFormsApp2.project.mouse.CursorIconManager;
using static WindowsFormsApp2.project.mouse.ScreenColorManager;

namespace WindowsFormsApp1
{
    internal class AppCoordinator : IProgramExeCallback, IOnInputSimulateCallback, ICursorIconCallback, IXMLModifierCallback, IFindMouseBarPositionCallback, IRecordWindowCallback, IUserCommandsListener
    {

        //instances
        private KeyboardMouseSimulator keyboardMouseSimulator;
        private CursorIconManager cursorIconManager;
        private MouseEventListener mouseEventListener;
        private XMLModifier xmlModifier;
        private MouseCoordinator mouseCoordinator;
        private RecordWindowErrorHandler recordWindowErrorHandler;
        private ProgramExe programExe;
        private UserCommandsListener userCommandsListener;
        private TextToSpeechHelper textToSpeech;
        private bool exitCalled;

        public AppCoordinator()
        {
            keyboardMouseSimulator = new KeyboardMouseSimulator(this);
            cursorIconManager = new CursorIconManager(this);
            xmlModifier = new XMLModifier(this);
            programExe = new ProgramExe();
            userCommandsListener = new UserCommandsListener(this);
            mouseEventListener = new MouseEventListener(this);
            mouseCoordinator = new MouseCoordinator();
            recordWindowErrorHandler = new RecordWindowErrorHandler(this);
            this.textToSpeech = new TextToSpeechHelper();
        }

        internal void WaitForRightClickOnBar()
        {
            Console.WriteLine("on wait for right click");
            //todo: currently not doing anything with the x and y positions of the green bar
            xmlModifier.ReadXMLPath(AppForm.GetXmlPath());

            //show mouse dialog
            mouseCoordinator.ShowDialog();
            mouseCoordinator.ShowMouseNotification(MouseCoordinator.FIRST_MOUSE_NOTIF);
            programExe.RunGohstExeNoCallback();
            mouseEventListener.AskForRightClickOnBar();

        }

        public void OnRightClickOnBar(int x, int y)
        {
            Console.WriteLine("on right click on bar");
            SetMousePoint(new Point(x, y));
            ClickOnEventGohstReset();
        }

        public void ClickOnEventGohstReset()
        {
            Console.WriteLine("on click on event gohst reset");
            programExe.RunGohstExe(this);
        }

        public void OnGhostWindowOpenAndFocused(){
            Console.WriteLine("on gohst window opened and focused");
            keyboardMouseSimulator.Select_USB_UIRT_InMenu();
        }

        public void On_USBUIRT_ItemSelected()
        {
            Console.WriteLine("on item selected");
            keyboardMouseSimulator.ClickOnLearnIrCode();
        }

        public void OnLearnIrCodeClicked()
        {
            Console.WriteLine("on learn ir clicked");
            var nextNodeName = xmlModifier.GetNextValName();
            mouseCoordinator.ShowMouseNotification(nextNodeName);
            HandleTextToSpeech(nextNodeName);
            userCommandsListener.ListinToUserCommands();
        }

        private void HandleTextToSpeech(string nextNodeName)
        {
            if(!AppForm.TextToSpeech)return;
            Task t = Task.Run(() => {
                textToSpeech.SayBtn(nextNodeName);
            });
        }

        public void OnUserSkipped()
        {
            Console.WriteLine("on user skipped");
            var finished = xmlModifier.SkipNextValAndFinish();
            var nextVal = xmlModifier.GetNextValName();
            if(AppForm.TextToSpeech)
                textToSpeech.SayBtn(nextVal);
            if (!finished) mouseCoordinator.ShowMouseNotification(nextVal);
        }


        public void OnUserPaused(bool paused)
        {
            Console.WriteLine("on user paused");
            mouseCoordinator.ShowUserPausedNotif(paused);
            if (!AppForm.TextToSpeech) return;
            if(paused)
                textToSpeech.SayBtn(UserCommandsListener.PAUSED);
            else
                textToSpeech.SayBtn(UserCommandsListener.CONTINUED);
        }


        public void OnRecordBarRaised()
        {
            Console.WriteLine("on record raised");
            keyboardMouseSimulator.CloseRecordWindow();
        }


        public void OnTryingToCloseRecordWindow()
        {
            Console.WriteLine("on trying to close record windwo");
            recordWindowErrorHandler.NotifySuccessfulClose();

        }

        public void OnRecordWindowClosed()
        {
            Console.WriteLine("onm record window closed");
            //keyboardMouseSimulator.releaseCtrl();
            cursorIconManager.NotifyWhenCursorChangedToBeam();
        }

        public void OnRecordWindowStillOpen()
        {
            Console.WriteLine("on record window still oipen");
            recordWindowErrorHandler.CheckForClosingDialog();
            ClickOnEventGohstReset();
        }


        public void OnCursorFrozenForAWhile()
        {
            Console.WriteLine("on cursed froze for a while");
            keyboardMouseSimulator.CloseWindowsTryToFixWindow();
            recordWindowErrorHandler.CheckForClosingDialog();
            ClickOnEventGohstReset();
        }


        public void OnCursorChanged()
        {
            Console.WriteLine("on cureser changed");
            keyboardMouseSimulator.CopyHexInBox();
        }


        public void OnCopyBoxDone(string txtCopied)
        {
            Console.WriteLine("on copy box done");
            xmlModifier.SetNextNodeVal(txtCopied);
        }

        public void OnNodeValSet()
        {
            Console.WriteLine("on node val ssat");
            keyboardMouseSimulator.ClickOnLearnIrCode();
        }



        public void OnAllNodesSet()
        {
            if (exitCalled) return;
            exitCalled = true;
            Console.WriteLine("ion all nodes sat");
            OnExit();
        }

        public void OnExit()
        {
            //keyboardMouseSimulator.releaseCtrl();

            ClipboardWatcher.Stop();
            KeyboardWatcher.Stop();
            MouseWatcher.Stop();
            Console.WriteLine("done!");
            RegistryHandler.DisableWindowsErrorReporting(false);
            textToSpeech.SayBtn(textToSpeech.EXIT_MSG);
            Application.Exit();
            Environment.Exit(1);
        }

        public void OnBackToMainScreenError()
        {
            Console.WriteLine("onb back to main screen errr");
            ClickOnEventGohstReset();
        }
    }
}