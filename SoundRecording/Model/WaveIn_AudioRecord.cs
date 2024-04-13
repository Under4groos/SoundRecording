using NAudio.Wave;
using System.IO;

namespace SoundRecording.Model
{
    internal class WaveIn_AudioRecord
    {
        public bool IsRecording
        {
            get; set;
        } = false;
        private void waveMaxSample(WaveInEventArgs e, Action<float> handler)
        {
            if (waveWriter != null) //Aliving waveWrter(filewriter), write all bytes in buffer
            {
                waveWriter.Write(e.Buffer, 0, e.BytesRecorded);
                waveWriter.Flush();
            }

            float maxRecorded = 0.0f;
            for (int i = 0; i < e.BytesRecorded; i += 2) //loop for bytes
            {
                //convert to float
                short sample = (short)((e.Buffer[i + 1] << 8) |
                                e.Buffer[i + 0]);
                float sample32 = sample / 32768f;

                if (sample32 < 0) sample32 = -sample32; // alter to absolute value 
                if (sample32 > maxRecorded) maxRecorded = sample32; //update maximum 
            }

            handler(maxRecorded); //pass the handle
        }
        private void OnRecordingStopped(object sender, StoppedEventArgs e)
        {
            if (waveWriter != null)
            {
                waveWriter.Close();
                memoryStream.Close();
                using (FileStream fileStream = new FileStream("tesat.wav", FileMode.Create, FileAccess.Write))
                {
                    memoryStream.CopyTo(fileStream);
                }
                waveWriter.Dispose();
            }
        }

        public WaveIn wave = new WaveIn();
        private WaveFileWriter waveWriter;//opening memoryStream and write in dataavailable event
        public Stream memoryStream; //for save 

        public WaveIn_AudioRecord(int device, Action<float> dataAvailableHandler, int sampleRate = 8000, int channels = 8)
        {
            int waveInDevices = WaveIn.DeviceCount;
            if (waveInDevices < 1)
            {
                throw new Exception("there's no connectable devices in computer : AudioRecord constructor");
            }


            wave.DeviceNumber = device;
            wave.DataAvailable += (sender, e) =>
            {
                waveMaxSample(e, dataAvailableHandler);
            };
            wave.RecordingStopped += OnRecordingStopped;

            wave.WaveFormat = new WaveFormat(sampleRate, channels, 1);

        }


        public void Start()
        {
            memoryStream = new MemoryStream();
            //WaveFileWriter with ignoredisposesream memorystream
            waveWriter = new WaveFileWriter(memoryStream, wave.WaveFormat);
            wave.StartRecording();

            IsRecording = true;
        }
        public void Stop()
        {
            if (waveWriter == null || memoryStream == null) return;

            wave.StopRecording();

            IsRecording = false;

        }
    }


    public class Recor
    {
        public Recor()
        {


        }
    }
}
