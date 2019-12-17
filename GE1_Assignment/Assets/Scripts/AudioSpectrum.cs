using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent (typeof(AudioSource))]
public class AudioSpectrum : MonoBehaviour
{
    public float[] audSpec = new float[512];
    public static float[] freqBand = new float[8];
    public  float[] bandBuffer = new float[8];
    private float[] bufferDecrease = new float[8];

    float[] freqBandHighest = new float[8];
    public float[] audioBand = new float[8];
    public float[] audioBandBuffer = new float[8];
    AudioSource aSource;

    public float amplitude, amplitudeBuffer;
    float amplitudeHighest;
    //public static float specValue { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        //audSpec = new float[512];
        aSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //AudioListener.GetSpectrumData();
        /*if (audSpec != null && audSpec.Length > 0)
        {
            specValue = audSpec[0] * 100;//100 used to normalize spectrum data
        }
        */
        getSpectrumAudioSource();
        makeFrequencyBands();
        BandBuffer();
        createAudioBands();
        getAmplitude();
    }
    //Causing many an issue, audio bands = infinite so amp doesnt do anything
    void getAmplitude()
    {
        float currentAmplitude = 0;
        float currentAmpBuffer = 0;
        for (int i = 0; i < 8; i++)
        {
            currentAmplitude += audioBand[i];
            currentAmpBuffer += audioBandBuffer[i];
            if (currentAmplitude > amplitudeHighest)
            {
                amplitudeHighest = currentAmplitude;
            }
            amplitude = currentAmplitude / amplitudeHighest;
            amplitudeBuffer = currentAmpBuffer / amplitudeHighest;
        }
    }
    void getSpectrumAudioSource()
    {
        aSource.GetSpectrumData(audSpec, 0, FFTWindow.Blackman);
    }
    void BandBuffer()
    {
        for (int f = 0; f < 8; f++)
        {
            if (freqBand[f] > bandBuffer[f])
            {
                bandBuffer[f] = freqBand[f];
                bufferDecrease[f] = 0.005f;
            }
            if (freqBand[f] < bandBuffer[f])
            {
                bandBuffer[f] -= bufferDecrease[f];
                bufferDecrease[f] *= 1.2f;
            }
        }
    }
    void createAudioBands()
    {
        for (int i = 0; i < 8; i++)
        {
            if (freqBand[i] < freqBandHighest[i])
            {
                freqBandHighest[i] = freqBand[i];
            }
            audioBand[i] = freqBand[i] / freqBandHighest[i];
            audioBandBuffer[i] = bandBuffer[i] / freqBandHighest[i];
        }
    }
    void makeFrequencyBands()
    {
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
         * 
         * 0 = 2 samples (86hz)
         * 1 = 4 samples (172hz -> 87 - 258hz)
         * 2 = 8 samples (344hz -> 259 - 602hz)
         * 3 = 16 samples (688 hz -> 603 - 1290hz)
         * 4 = 32 samples (1376hz -> 1291 - 2666hz)
         * 5 = 64 samples (2752hz -> 2667 - 5418hz)
         * 6 = 128 samples (5504hz -> 5419 - 10922hz
         * 7 = 256 samples (11008hz -> 10923 - 21930hz)
         */
        //use nested for loop

        int count = 0;
        for (int i = 0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;
            if (i == 7)
            {
                sampleCount += 2;
            }
            for (int j = 0; j < sampleCount; j++)
            {
                average += audSpec[count] * (count + 1);
                count++;
            }
            average /= count;
            freqBand[i] = average * 10;
            


        }
    }
}
