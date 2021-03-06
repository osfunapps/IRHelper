﻿using EventHook;
using System;
using System.Threading;
using System.Windows.Forms;
using WindowsFormsApp1;
using WindowsFormsApp1.project.ghost;
using WindowsFormsApp1.project.ghost.inputssimulator;
using WindowsFormsApp1.project.ghost.screenhelpers.colorchecker;

namespace WindowsFormsApp2.project.mouse
{
    public class UserCommandsListener : IScreenColorManagerCallback
    {

        public static string PAUSED = "paused";
        public static string CONTINUED = "continued";

        //params
        private string ESC_KEY = "Escape";
        private int CLICK_SAFETY_WAIT_MILLIS = 2000;
        private string WAVE_BTN = "Oem3";

        //instances
        private ScreenColorManager screenColorManager;

        //callback
        private IUserCommandsListener userCommandsListener;

        //variables
        private long lastTimeClicked;
        public static bool isAllowedToReadPixel;
        private TextToSpeechHelper textToSpeech;

        public UserCommandsListener(IUserCommandsListener userCommandsListener)
        {
            this.userCommandsListener = userCommandsListener;
            this.screenColorManager = new ScreenColorManager(this);
        }

        internal void ListinToUserCommands()
        {
            KeyboardWatcher.Start();
            SetKeyboardListener();
        }

        private void SetKeyboardListener()
        {
            KeyboardWatcher.OnKeyInput += (s, e) =>
            {
                Console.WriteLine(e.KeyData.Keyname);

                if (ClickedOnEscBtn(e))
                {
                    userCommandsListener.OnExit();
                    return;
                }

                if (ClickedOnUndoBtn(e) && ClickLegal())
                {
                    lastTimeClicked = TimeUtils.CurrentTimeMillis();
                    userCommandsListener.OnUndo();
                }


                if (ClickedOnSkipBtn(e) && ClickLegal())
                {
                    lastTimeClicked = TimeUtils.CurrentTimeMillis();
                    userCommandsListener.OnUserSkipped();
                }


                if (ClickedOnPauseBtn(e) && ClickLegal())
                {
                    lastTimeClicked = TimeUtils.CurrentTimeMillis();

                    //if running
                    if (isAllowedToReadPixel)
                    {
                        userCommandsListener.OnUserPaused(true);
                        isAllowedToReadPixel = false;

                    }
                    else
                    {
                        //if paused
                        isAllowedToReadPixel = true;
                        userCommandsListener.OnUserPaused(false);
                        LookForAColor().Start();
                    }

                }

            };

        }

        private bool ClickedOnUndoBtn(KeyInputEventArgs e)
        {
            return e.KeyData.Keyname.Equals(AppForm.undoBtn) && e.KeyData.EventType.Equals(EventHook.KeyEvent.up);
        }

        private bool WindowClosed()
        {
            return ExeWindowTitleReader.GetActiveWindowTitle().Equals(KeyboardMouseSimulator.WINDOW_TITLE_HEX_CODE);
        }

        private bool ClickedOnSkipBtn(KeyInputEventArgs e)
        {
            return e.KeyData.Keyname.Equals(WAVE_BTN) && e.KeyData.EventType.Equals(EventHook.KeyEvent.up);
        }

        public Thread LookForAColor()
        {
            return new Thread(delegate ()
            {
                screenColorManager.LookForGreenColor();
            });

        }

        private bool ClickLegal()
        {
            return TimeUtils.CurrentTimeMillis() - lastTimeClicked > CLICK_SAFETY_WAIT_MILLIS;
        }

        private bool ClickedOnEscBtn(KeyInputEventArgs e)
        {
            return e.KeyData.Keyname.Equals(ESC_KEY) && e.KeyData.EventType.Equals(EventHook.KeyEvent.down);
        }

        private bool ClickedOnPauseBtn(KeyInputEventArgs e)
        {
            return e.KeyData.Keyname.Equals(AppForm.GetUserPauseBtnName()) && e.KeyData.EventType.Equals(EventHook.KeyEvent.up);
        }

        public void OnRecordBarRaised()
        {
            KeyboardWatcher.Stop();
        }

        //do not think anything about this method! it is useless!! 
        public void OnUserPaused(bool paused)
        { Console.WriteLine("weird method called"); }

    }


    public interface IUserCommandsListener
    {
        void OnExit();
        void OnUserSkipped();
        void OnUserPaused(bool paused);
        void OnUndo();
    }


}