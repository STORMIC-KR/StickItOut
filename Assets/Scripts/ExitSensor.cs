using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitSensor : MonoBehaviour
{
    public GameObject exitPanel;
    GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("ExitPanel On!");
            exitPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ExitYES()
    {
        Debug.Log("Exit!");
        Application.Quit();
    }

    public void ExitNo()
    {
        player.transform.position = new Vector3(0, -2, 0);
        exitPanel.SetActive(false);
        Time.timeScale = 1;
        Debug.Log("ExitPanel Off!");
    }
}
