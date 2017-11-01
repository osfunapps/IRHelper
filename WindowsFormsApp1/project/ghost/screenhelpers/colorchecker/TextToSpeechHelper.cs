using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.project.ghost.screenhelpers.colorchecker
{
    class TextToSpeechHelper
    {
        private SpeechSynthesizer speechSynthesizerObj;
        public string EXIT_MSG = "haha! daba daba dab dab!";

        public TextToSpeechHelper()
        {
            speechSynthesizerObj = new SpeechSynthesizer();
            speechSynthesizerObj.SetOutputToDefaultAudioDevice();
        }

        public void SayBtn(string btnName)
        {
            // Initialize a new instance of the SpeechSynthesizer.
            
            //Asynchronously speaks the contents present in RichTextBox1   
            speechSynthesizerObj.Speak(btnName);
            // Configure the audio output. 
            //speechSynthesizerObj.Pause();
        }
    }
}
