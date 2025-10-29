using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RevealAudioClip : MonoBehaviour
{

    public AudioSource source;
    public Light2D sight;
    public float minSize;
    public float maxSize;
    public AudioLoudnessDetection detector;

    public float loudnessSensibility = 100;
    public float threshold = 0.1f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        sight.intensity = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        float loudness = detector.GetLoudnessFromAudioClip(source.timeSamples, source.clip) * loudnessSensibility;

        if (loudness < threshold)
        {
            loudness = 0;
        }

        sight.intensity = Mathf.Lerp(minSize,maxSize, loudness);
    }
}
