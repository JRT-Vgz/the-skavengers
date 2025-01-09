
using _2___Servicios.Interfaces;
using _2___Servicios.Services;
using NAudio.Wave;

namespace _3_SoundSystem
{
    public class SoundSystem : ISoundSystem
    {
        private readonly ConfigurationService _configuration;
        public SoundSystem(ConfigurationService configuration)
        {
            _configuration = configuration;
        }

        public async Task PlaySound(string soundFileConstant)
        {
            var appPath = AppContext.BaseDirectory;
            var dirPath = _configuration.Configuration["Constants:_SOUNDS_DIRECTORY"];

            string soundFilePath = Path.Combine(appPath, dirPath, soundFileConstant);

            using (var reader = new WaveFileReader(soundFilePath))
            {
                using (var soundDevice = new WaveOutEvent())
                {
                    soundDevice.Init(reader);
                    soundDevice.Volume = 0.04f;
                    soundDevice.Play();

                    while (soundDevice.PlaybackState == PlaybackState.Playing) { await Task.Delay(10); }
                }
            }
        }
    }
}
