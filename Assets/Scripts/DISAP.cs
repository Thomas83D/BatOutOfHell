using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Tilemaps;

public class DISAP : MonoBehaviour
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
        loudthreshold = lit.GetComponent<ScaleFromMicrophone>().highMinimum / 2;
        appearRange = lit.GetComponent<ScaleFromMicrophone>().highReveal;
        louds = lit.GetComponent<ScaleFromMicrophone>().loudness;
        if (louds > loudthreshold)
        {
            louds = 10;
        }
        if (louds > loudthreshold)
        {
            this.gameObject.GetComponent<TilemapCollider2D>().enabled = false;
        }
        if (louds < loudthreshold)
        {
            this.gameObject.GetComponent<TilemapCollider2D>().enabled = true;
        }

        this.gameObject.GetComponent<Tilemap>().color = new Color(0, 1, 0, Mathf.Max(0, (loudthreshold - louds) / (appearRange)));

    }
}
