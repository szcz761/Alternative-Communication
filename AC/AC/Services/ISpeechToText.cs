using System;
using System.Collections.Generic;
using System.Text;

namespace AC.Services
{
    public interface ISpeechToText
    {
        void StartSpeechToText();
        void StopSpeechToText();
    }
}
