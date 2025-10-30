using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Tilemaps;

public class QUIET : MonoBehaviour
{
    public Light2D lit;
    public float quiet;
    public float quietthreshold1 = 5;
    public float quietthreshold2 = 25;
    public float qappearRange = 10f;
    public int reveal;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        quietthreshold1 = lit.GetComponent<ScaleFromMicrophone>().lowCenter - lit.GetComponent<ScaleFromMicrophone>().lowRange;
        quietthreshold2 = lit.GetComponent<ScaleFromMicrophone>().lowCenter + lit.GetComponent<ScaleFromMicrophone>().lowRange;
        qappearRange = lit.GetComponent<ScaleFromMicrophone>().lowReveal;
        reveal = lit.GetComponent<ScaleFromMicrophone>().loud;
        quiet = lit.GetComponent<ScaleFromMicrophone>().loudness;
        if (quiet < quietthreshold1)
        {
            quiet = 0;
            reveal = 1;
        }
        if (quiet > quietthreshold2)
        {
            quiet = 0;
            reveal = 1;
        }
        if (quiet > quietthreshold2 || quiet < quietthreshold1)
        {
            if (reveal == 1)
            {
                this.gameObject.GetComponent<TilemapCollider2D>().enabled = false;
            }
        }
        if (quietthreshold1 < quiet && quiet < quietthreshold2 && reveal == 0)
        {
            this.gameObject.GetComponent<TilemapCollider2D>().enabled = true;
        }

        if (reveal == 0)
        {
            this.gameObject.GetComponent<Tilemap>().color = new Color(0, 0, 1, Mathf.Max(0, ((quiet - quietthreshold1) / qappearRange) * (quietthreshold2 - quiet) / qappearRange));
        }
        else
        {
            this.gameObject.GetComponent<Tilemap>().color = new Color(0, 0, 0, 0);
        }
    }
}
