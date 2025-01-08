
using _2___Servicios.Interfaces;
using NAudio.Wave;

namespace _3_SoundSystem
{
    public class SoundSystem : ISoundSystem
    {
        public async Task PlaySound(string file)
        {
            using (var reader = new WaveFileReader(file))
            {
                using (var soundDevice = new WaveOutEvent())
                {
                    soundDevice.Init(reader);
                    soundDevice.Volume = 0.05f;
                    soundDevice.Play();

                    while (soundDevice.PlaybackState == PlaybackState.Playing) { await Task.Delay(10); }
                }
            }
        }
    }
}
