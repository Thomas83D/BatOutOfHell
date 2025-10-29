using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class AudioLoudnessDetection : MonoBehaviour
{

    public int sampleWindow = 64;
    private AudioClip microphoneClip;
    public Scrollbar uiScrollBar;
    public Light2D liit;
    public float unit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MicrophoneToAudioClip();

        if (uiScrollBar == null)
        {
            Debug.LogError("UI not assigned!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        unit = liit.GetComponent<ScaleFromMicrophone>().loudness;
        if (uiScrollBar != null)
        {
            uiScrollBar.size = unit / 10;
            Debug.Log("Audio Detected to Scroll Bar");
        }
    }

    public void MicrophoneToAudioClip()
    {
        string microphoneName = Microphone.devices[0];
        microphoneClip = Microphone.Start(microphoneName, true, 20, AudioSettings.outputSampleRate);
    }

    public float GetLoudnessFromMicrophone()
    {
        return GetLoudnessFromAudioClip(Microphone.GetPosition(Microphone.devices[0]), microphoneClip);
    }

    public float GetLoudnessFromAudioClip(int clipPosition, AudioClip clip)
    {
        int startPosition = clipPosition - sampleWindow;

        if (startPosition < 0)
        {
            return 0;
        }

        float[] waveData = new float[sampleWindow];
        clip.GetData(waveData, startPosition);

        float totalLoudness = 0;
        for (int i = 0; i < sampleWindow; i++)
        {
            totalLoudness += Mathf.Abs(waveData[i]);
        }
        return totalLoudness / sampleWindow;
    }
}
