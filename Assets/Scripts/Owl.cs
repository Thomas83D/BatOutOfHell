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

    public void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        louds = lit.GetComponent<ScaleFromMicrophone>().loudness;
        total = Mathf.Max(total + louds - 1.5f, 0);
        if (total > kill)
        {
            game.GetComponent<ResetGame>().ResetScene();
        }
    }
}
