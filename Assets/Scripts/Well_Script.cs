using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Well_Script : MonoBehaviour
{
    public GameObject enterText;
    private bool isReady = false;

    // Start is called before the first frame update
    void Start()
    {
        enterText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            enterText.SetActive(false);
            //Go to Game scene
            SceneManager.LoadScene("GameScene");
            Debug.Log("Go to NEXT LEVEL!");
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            isReady = true;
            enterText.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enterText.SetActive(false);
        }
    }
}
