using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Tilemaps;

public class LOUDS : MonoBehaviour
{

    public Light2D lit;
    public float louds;
    public float loudthreshold = 20;
    public float appearRange = 20f;
    public bool appear;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        loudthreshold = lit.GetComponent<ScaleFromMicrophone>().highMinimum;
        appearRange = lit.GetComponent<ScaleFromMicrophone>().highReveal;
        louds = lit.GetComponent<ScaleFromMicrophone>().loudness;
        if (louds < loudthreshold)
        {
            louds = 0;
        }
        if (louds < loudthreshold)
        {
            this.gameObject.GetComponent<TilemapCollider2D>().enabled = false;
        }
        if (louds > loudthreshold)
        {
            this.gameObject.GetComponent<TilemapCollider2D>().enabled = true;
        }

        this.gameObject.GetComponent<Tilemap>().color = new Color(1, 0, 0, Mathf.Max(0, (louds-loudthreshold) / (appearRange)));
        
    }
}
