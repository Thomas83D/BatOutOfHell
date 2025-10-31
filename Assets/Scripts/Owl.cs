using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Owl : MonoBehaviour
{

    public Light2D lit;
    // Start is called before the first frame update
    public float louds;
    public float speed = 3f;
    public float total;
    public int kill;
    public GameObject game;
    public bool umad;
    public SpriteRenderer hoot;
    public Sprite hoo;
    public Sprite hoo2;
    public float shakeashake = 3;
    public Vector2 startPos = new Vector2 (-5.7f, 4.8f);
    public Transform playerTransform;

    public void Start()
    {
        umad = false;
    }

    // Update is called once per frame
    void Update()
    {
        louds = lit.GetComponent<ScaleFromMicrophone>().loudness;
        OwlDetection();
    }

    public void OwlDetection()
    {
        total = Mathf.Max(total + ((louds - 2.5f) * Time.deltaTime), 0);
        if (total > kill / 2)
        {
            hoot.sprite = hoo2;
        }
        else if (total < kill / 2)
        {
            hoot.sprite = hoo;
            
            if (louds > 1f)
            {
                FollowPlayer();
            }
            else
            {
                transform.position = transform.position;
            }
        }

        if (total > kill)
        {
            game.GetComponent<ResetGame>().ResetScene();
        }
    }

    public void FollowPlayer()
    {
        Vector3 moveTo = playerTransform.position - transform.position;
        moveTo = moveTo.normalized;
        transform.Translate(moveTo * Time.deltaTime * (louds / 2));
    }
}
