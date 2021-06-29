using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameLevels : MonoBehaviour
{

    public void LoadRandomScene()
    {
        int index = Random.Range(1, 4);
        SceneManager.LoadScene(index);
        Debug.Log("Scene Loaded");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;

        if(collisionGameObject.name == "Player")
        {
            LoadRandomScene();
        }
    }
}
