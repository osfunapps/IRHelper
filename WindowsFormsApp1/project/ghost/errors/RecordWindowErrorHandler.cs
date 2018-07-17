using System;
using System.Threading;
using WindowsFormsApp1.project.ghost;
using WindowsFormsApp1.project.ghost.inputssimulator;

namespace WindowsFormsApp1
{
    internal class RecordWindowErrorHandler
    {

        //callback
        private IRecordWindowCallback recordWindowCallback;

        //params
        private int MAX_CYCLES_TO_WAIT = 3;
        private int TIME_BETWEEN_CYCLES = 400;
        private int CLOSE_WINDOW_WAIT_TIME = 1500;
        private string CLOSE_WINDOW_TITLE = "EventGhost";

        public RecordWindowErrorHandler(IRecordWindowCallback recordWindowCallback)
        {
            this.recordWindowCallback = recordWindowCallback;
        }


        internal void NotifySuccessfulClose()
        {
            int cycles = 0;
            while (StillInRecordWindow())
            {
                cycles++;

                if (cycles > MAX_CYCLES_TO_WAIT) { 
                    return;
                }


                Thread.Sleep(TIME_BETWEEN_CYCLES);
            }


        }

        private bool StillInRecordWindow()
        {
            return ExeWindowTitleReader.GetActiveWindowTitle().Equals(KeyboardMouseSimulator.WINDOW_TITLE_LEARN_IR_CODE);
        }

        internal void CloseWindowsTryToFixWindow()
        {

        }

        internal void CheckForClosingDialog()
        {
            Console.WriteLine("sleeping");
            Thread.Sleep(CLOSE_WINDOW_WAIT_TIME);
            ActionSimulator.ClickOnBtn(WindowsInput.Native.VirtualKeyCode.SPACE);
            ActionSimulator.ClickOnBtn(WindowsInput.Native.VirtualKeyCode.SPACE);
            Console.WriteLine("waking! window: " + ExeWindowTitleReader.GetActiveWindowTitle());
            Console.WriteLine("is it close window? : " + ExeWindowTitleReader.GetActiveWindowTitle().Equals(CLOSE_WINDOW_TITLE));
            /*if (ExeWindowTitleReader.GetActiveWindowTitle().Equals(CLOSE_WINDOW_TITLE))
            {
                Console.WriteLine("clicking space");
                ActionSimulator.ClickOnBtn(WindowsInput.Native.VirtualKeyCode.SPACE);
            }*/
        }
    }

    public interface IRecordWindowCallback
    {
    }
}