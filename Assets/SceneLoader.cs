using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && this.CompareTag("StartBtn"))
        {
            int index = Random.Range(1, 4);
            SceneManager.LoadScene(index);
            Debug.Log("Scene Loaded");
        }
        else if (other.CompareTag("Player") && this.CompareTag("QuitBtn"))
        {
            Debug.Log("Quit!");
        }
    }
}
