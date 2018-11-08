using System;
using System.Collections.Generic;
using System.Text;

namespace AC.Services
{
    public interface ITextToSpeech
    {
        void Speak(string text);
    }
}
