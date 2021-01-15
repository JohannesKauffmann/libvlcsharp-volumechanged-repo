using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Timers;
using LibVLCSharp.Shared;

namespace LibVLCSharp.NetCore.Sample
{
    class Program
    {
        static readonly Timer timer = new Timer(1 * 1000) { AutoReset = false };
        static MediaPlayer mp;

        static void Main(string[] args)
        {
            timer.Elapsed += Timer_Elapsed;

            Core.Initialize();

            using var libVLC = new LibVLC(enableDebugLogs: true);
            using var media = new Media(libVLC, new Uri("http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ElephantsDream.mp4"));
            mp = new MediaPlayer(media);
            mp.Playing += Mp_Playing; ;
            mp.VolumeChanged += Mp_VolumeChanged;
            mp.Play();
            Console.ReadKey();
        }

        static async void Mp_Playing(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                mp.Volume = 50;
            });
            timer.Start();
        }

        static void Mp_VolumeChanged(object sender, MediaPlayerVolumeChangedEventArgs e)
        {
            Debug.WriteLine(String.Format("New volume: {0}", e.Volume));
        }

        static async void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            await Task.Run(() =>
            {
                mp.Volume = 100;
            });
        }
    }
}
