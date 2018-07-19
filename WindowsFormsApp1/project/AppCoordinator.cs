using EventHook;
using LayoutProject.program;
using LayoutProject.program.values;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using WindowsFormsApp1.program.valuesparser;
using WindowsFormsApp1.project.ghost;
using WindowsFormsApp1.project.ghost.mouselistener;
using WindowsFormsApp1.project.ghost.screenhelpers.colorchecker;
using WindowsFormsApp1.project.hexwindow;
using WindowsFormsApp1.project.newnewnew;
using WindowsFormsApp1.project.tools;
using WindowsFormsApp2.project.mouse;
using static LayoutProject.program.XMLModifier;
using static WindowsFormsApp1.project.ghost.mouselistener.MouseEventListener;
using static WindowsFormsApp1.project.ghost.ProgramExe;
using static WindowsFormsApp2.project.mouse.CursorIconManager;
using static WindowsFormsApp2.project.mouse.ScreenColorManager;

namespace WindowsFormsApp1
{
    internal class AppCoordinator : IProgramExeCallback, IOnInputSimulateCallback, ICursorIconCallback, IXMLModifierCallback, IFindMouseBarPositionCallback, IRecordWindowCallback, IUserCommandsListener, IHexListenerCallback, IHexWindowCallback
    {

        //instances
        private KeyboardMouseSimulator keyboardMouseSimulator;
        private CursorIconManager cursorIconManager;
        private MouseEventListener mouseEventListener;
        private XMLModifier xmlModifier;
        private MouseCoordinator mouseCoordinator;
        private RecordWindowErrorHandler recordWindowErrorHandler;
        private HexListener hexListener;
        private UserCommandsListener userCommandsListener;
        private TextToSpeechHelper textToSpeech;
        private bool exitCalled;
        private AppForm _appForm;
        private Task readHexTask;
        private JavaKiller javaKiller;
        private HexWindow hexWindow;
        private string nextNodeName;

        public AppCoordinator(AppForm appForm)
        {
            _appForm = appForm;
            keyboardMouseSimulator = new KeyboardMouseSimulator(this);
            cursorIconManager = new CursorIconManager(this);
            xmlModifier = new XMLModifier(this);
            hexListener = new HexListener(this);
            userCommandsListener = new UserCommandsListener(this);
            mouseEventListener = new MouseEventListener(this);
            mouseCoordinator = new MouseCoordinator();
            recordWindowErrorHandler = new RecordWindowErrorHandler(this);
            this.textToSpeech = new TextToSpeechHelper();
            javaKiller = new JavaKiller();
            hexWindow = new HexWindow(this);
        }

        internal void StartSequence()
        {
            javaKiller.KillAllJavaProcessess();
            hexWindow.Show();


            //show mouse dialog
            mouseCoordinator.ShowDialog();

            hexListener.OpenHexListener();
            ReadXmlPath(AppForm.startOver);
        }

        private void ReadXmlPath(bool runOverValues)
        {
            xmlModifier.ReadXMLPath(AppForm.GetXmlPath(), runOverValues);
            PrepareForNextHex();
        }


        public void PrepareForNextHex()
        {
            nextNodeName = xmlModifier.GetNextValName();
            mouseCoordinator.ShowMouseNotification(nextNodeName);
            HandleTextToSpeech(nextNodeName);
            userCommandsListener.ListinToUserCommands();
            readHexTask = Task.Run(() =>
            {
                hexListener.ListenToHex();
            });

        }

        public void OnHexReturned(string hexCode)
        {
            mouseCoordinator.SetMouseNotificationColor(FloatingMouseWindow.MOUSE_NOTIFICATION_ON_COLOR);
            hexWindow.SetKeyAndHex(nextNodeName, hexCode);
            Thread.Sleep(FreezeConverter.GetFreezeTime());
            mouseCoordinator.SetMouseNotificationColor(FloatingMouseWindow.MOUSE_NOTIFICATION_IDLE_COLOR);
            xmlModifier.SetNextNodeVal(hexCode);
        }

        public void OnNodeValSet()
        {
            Console.WriteLine("on node val ssat");
            PrepareForNextHex();
        }


        public void OnAllNodesSet(XmlDocument document)
        {
            /*   NodesValidator nodesValidator = new NodesValidator();
               if (nodesValidator.AreAllNodesValidated(document))
                   OnAllNodesValidated();
               else
                   ReadXmlPath();
           */
            mouseCoordinator.ShowMouseNotification("");
            hexWindow.ToggleValidateBtnEnabled(true);
            hexWindow.ToggleValidateBtnText();
        }

        public void OnValidateClicked(List<string> corruptNodes)
        {
            if (corruptNodes.Count != 0)
            {
                xmlModifier.ClearCorruptNodesFromValues(corruptNodes);
                ReadXmlPath(false);
            }
            else
                OnAllNodesValidated();
        }


        public void OnAllNodesValidated()
        {
            if (exitCalled) return;
            exitCalled = true;
            Console.WriteLine("ion all nodes sat");
            if (AppForm.TextToSpeech)
                textToSpeech.SayBtn(textToSpeech.EXIT_MSG);
            hexListener.KillListener();
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
            Application.Exit();
            try
            {
                Environment.Exit(1);
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }

        public void OnBackToMainScreenError()
        {
        }

        private void HandleTextToSpeech(string nextNodeName)
        {
            if (!AppForm.TextToSpeech) return;
            Task t = Task.Run(() =>
            {
                textToSpeech.SayBtn(nextNodeName);
            });
        }

        public void OnUndo()
        {
            xmlModifier.ClearPreviousVal();
            nextNodeName = xmlModifier.GetNextValName();
            mouseCoordinator.ShowMouseNotification(nextNodeName);
            HandleTextToSpeech(nextNodeName);
            hexWindow.ClearLastRow();
        }


        public void OnUserSkipped()
        {
            Console.WriteLine("on user skipped");
            var finished = xmlModifier.SkipNextValAndFinish();
            nextNodeName = xmlModifier.GetNextValName();
            if (AppForm.TextToSpeech)
                textToSpeech.SayBtn(nextNodeName);
            if (!finished)
            {
                mouseCoordinator.ShowMouseNotification(nextNodeName);
            }
    }


        public void OnUserPaused(bool paused)
        {
            Console.WriteLine("on user paused");
            mouseCoordinator.ShowUserPausedNotif(paused);
            if (!AppForm.TextToSpeech) return;
            if (paused)
                textToSpeech.SayBtn(UserCommandsListener.PAUSED);
            else
                textToSpeech.SayBtn(UserCommandsListener.CONTINUED);
        }

    }
}