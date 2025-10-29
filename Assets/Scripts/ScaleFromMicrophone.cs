using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ScaleFromMicrophone : MonoBehaviour
{
    public AudioSource source;
    public Light2D sight;
    public float minSize;
    public float maxSize;
    public AudioLoudnessDetection detector;
    public float loudness = 1;

    public float loudnessSensibility = 100;
    public float threshold = 1f;
    public float remove = 0.1f;
    public float lowCenter = 25;
    public float highMinimum = 40f;
    public float lowRange = 10;
    public float lowReveal = 20;
    public float highReveal = 20;
    public int loud = 0;
    public float lightColorInstense;
    public float expand;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        float loudnessCheck = detector.GetLoudnessFromMicrophone() * loudnessSensibility;

        if (loudnessCheck < threshold)
        {
            expand = 0;
            loudnessCheck = 0;
        }
        if (loudness > highMinimum)
        {
            loud = 1;
        }
        if (loudnessCheck < loudness)
        {
            if (loud == 1)
            {
                remove += remove * 1.01f * Time.deltaTime;
                loudness = Mathf.Max(loudnessCheck, loudness - remove);
            }
            if (loud == 0)
            {
                remove += remove * 1.001f * Time.deltaTime;
                loudness = Mathf.Max(loudnessCheck, loudness - remove);
            }
        }
        else
        {
  
            loudness += (loudnessCheck - loudness) * 0.5f;
            remove = 0.01f;
            if (loudness < highMinimum)
            {
                loud = 0;
            }
        }
       
    if (loudness > maxSize)
        {
            loudness = maxSize - 0.1f;
        }
            sight.pointLightOuterRadius = Mathf.Lerp(minSize, maxSize, loudness / maxSize) * 2;
        if (loud == 1)
        {

           sight.color = new Color(1, Mathf.Abs(-1 + Mathf.Clamp((loudness - highMinimum) / highReveal, 0, 1)), Mathf.Abs(-1 + Mathf.Clamp((loudness - highMinimum) / highReveal, 0, 1)), 1 / lightColorInstense);
        }
        if (loud == 0)
        {


            sight.color = new Color(Mathf.Abs(-1 + Mathf.Clamp((loudness + lowRange - lowCenter) / lowReveal * (lowCenter + lowRange - loudness) / lowReveal, 0, 1)), Mathf.Clamp(Mathf.Abs(-1 + (loudness - highMinimum) / highReveal), 0, 1) * Mathf.Abs(-1 + Mathf.Clamp((loudness + lowRange - lowCenter) / lowReveal * (lowCenter + lowRange - loudness) / lowReveal, 0, 1)), Mathf.Abs(-1 + Mathf.Clamp((loudness - highMinimum) / highReveal, 0, 1)), 1/lightColorInstense);
        }
    }
}
