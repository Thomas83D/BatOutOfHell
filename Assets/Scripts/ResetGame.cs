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
        ResetScene();
    }

    private void ResetScene()
    {
        int resetScene = SceneManager.GetActiveScene().buildIndex;

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadSceneAsync(resetScene);
        }
    }
}
