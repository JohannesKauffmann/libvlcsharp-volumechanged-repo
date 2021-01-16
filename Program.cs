using System;
using System.Threading.Tasks;
using LibVLCSharp.Shared;

namespace libvlcsharpvolumechangedrepo
{
    class Program
    {
        static int volume_cb_count = 0;
        static MediaPlayer mp;

        static void Main(string[] args)
        {
            Core.Initialize();

            using var libVLC = new LibVLC(enableDebugLogs: false);
            using var media = new Media(libVLC, new Uri("http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4"));
            mp = new MediaPlayer(media);
            mp.Playing += Mp_Playing; ;
            mp.VolumeChanged += Mp_VolumeChanged;
            mp.Play();
            Console.ReadKey();
            Console.WriteLine(String.Format("Volume callback fired {0} times!", volume_cb_count));
        }

        static async void Mp_Playing(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                mp.Volume = 100;
            });
        }

        static void Mp_VolumeChanged(object sender, MediaPlayerVolumeChangedEventArgs e)
        {
            volume_cb_count++;
            Console.WriteLine(String.Format("New volume: {0}", e.Volume));
        }
    }
}
