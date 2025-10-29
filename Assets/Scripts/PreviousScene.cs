using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreviousScene : MonoBehaviour
{
    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            LoadPreviousScene();
        }
    }

    void LoadPreviousScene()
    {
        Vector3 newPosition = new Vector3(10f, -2.96f, 0f);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int previousSceneIndex = currentSceneIndex - 1;

        if (previousSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadSceneAsync(previousSceneIndex);
            previousSceneIndex = currentSceneIndex;
            playerTransform.position = newPosition;
        }
    }
}
