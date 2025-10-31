using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
   // public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            LoadNextScene();
        }
    }

    public void LoadNextScene()
    {
        //Vector3 newPosition = transform.position + Vector3.right;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadSceneAsync(nextSceneIndex);
            nextSceneIndex = currentSceneIndex;
            //playerTransform.position = newPosition;
        }
        else if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadSceneAsync(0);
        }
    }
}
