using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ResetScene();
        }
    }
    public void ResetScene()
    {
        int resetScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(resetScene);
    }
}
