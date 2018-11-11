using AC.Droid;
using AC.Services;
using Android.Speech.Tts;
using Xamarin.Forms;

[assembly: Dependency(typeof(TextToSpeechImplementation))]
namespace AC.Droid
{
    class TextToSpeechImplementation : Java.Lang.Object, ITextToSpeech, TextToSpeech.IOnInitListener
    {
        TextToSpeech speaker;
        string toSpeak;

        public void Speak(string text)
        {
            toSpeak = text;
            if (speaker == null)
            {
                speaker = new TextToSpeech(MainActivity.Instance, this, "com.google.android.tts");
            }
            else
            {
                speaker.Speak(toSpeak, QueueMode.Flush,null,null);
            }
        }

        public void OnInit(OperationResult status)
        {
            if (status.Equals(OperationResult.Success))
            {
                speaker.Speak(toSpeak, QueueMode.Flush, null, null);
            }
        }
    }
}