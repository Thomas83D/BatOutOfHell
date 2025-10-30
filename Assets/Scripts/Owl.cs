using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Owl : MonoBehaviour
{

    public Light2D lit;
    // Start is called before the first frame update
    public float louds;
    public float total;
    public int kill;
    public GameObject game;
    public bool umad;
    public SpriteRenderer hoot;
    public Sprite hoo;
    public Sprite hoo2;

    public void Start()
    {
        umad = false;
    }

    // Update is called once per frame
    void Update()
    {
        

        louds = lit.GetComponent<ScaleFromMicrophone>().loudness;
        total = Mathf.Max(total + ((louds - 1.5f) * Time.deltaTime), 0);
        if (total > kill / 2) {
            hoot.sprite = hoo2;
        }
        if (total < kill / 2)
        {
            hoot.sprite = hoo;
        }

        if (total > kill)
        {
            game.GetComponent<ResetGame>().ResetScene();
        }
    }
}
