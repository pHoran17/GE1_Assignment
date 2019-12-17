using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class AudioHandler : MonoBehaviour
{
    //Class used to replace AudioSpectrum class in order to utilise various bands of sound file effectively
    AudioSource a;
    public AudioClip song;
    public static int frameSize = 512;
    public float[] spectrum;
    public float[] bands;
    public float[] bandBuffer;
    private float[] bufferDecrease;
    public float binWid;
    public float sampleRate;
    public AudioMixerGroup master;

    /*
         *22050 hz /512 bands = 43hz per sample
         * 
         * 20-60hz 
         * 60-250 hz
         * 250-500hz
         * 500-2000hz
         * 2000-4000hz
         * 4000-6000hz
         * 6000-20000hz
         */

    // Start is called before the first frame update
    void Start()
    {
        sampleRate = AudioSettings.outputSampleRate;
        binWid = AudioSettings.outputSampleRate / 2 / frameSize;
    }
    private void Awake()
    {
        a = GetComponent<AudioSource>();
        spectrum = new float[frameSize];
        bands = new float[(int)Mathf.Log(frameSize, 2)];
        bandBuffer = new float[(int)Mathf.Log(frameSize, 2)];
        bufferDecrease = new float[(int)Mathf.Log(frameSize, 2)];
        a.clip = song;
        a.outputAudioMixerGroup = master;
        a.Play();

    }
    void BandBuffer()
    {
        for (int i = 0; i < bands.Length; i++)
        {
            if (bands[i] > bandBuffer[i])
            {
                bandBuffer[i] = bands[i];
                bufferDecrease[i] = 0.005f;
            }
            if (bands[i] < bandBuffer[i])
            {
                bandBuffer[i] -= bufferDecrease[i];
                bufferDecrease[i] *= 1.2f;
            }
        }
    }
    void getFreqBands()
    {
        for (int i = 0; i < bands.Length; i++)
        {
            float average = 0;
            int start = (int)Mathf.Pow(2, i) - 1;
            int width = (int)Mathf.Pow(2, i);
            int end = start + width;
            for (int j = 0; j < end; j++)
            {
                average += spectrum[j] * (j * 1);
            }
            average /= (float)width;
            bands[i] = average * 10;
        }
    }
    // Update is called once per frame
    void Update()
    {
        a.GetSpectrumData(spectrum, 0, FFTWindow.Blackman);
        getFreqBands();
        BandBuffer();
    }
}
