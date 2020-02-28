/*
 * (Levi Schoof)
 * (Game Manager)
 * (Assignment 6)
 * (Manages and keeps track of the in game stats)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    PlayerScript player;
    public GameObject loseScreen;
    public GameObject winScreen;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        loseScreen.SetActive(false);
        winScreen.SetActive(false);
        player = FindObjectOfType<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale < 1 & (player.health > 0 || player.timer > 0))
        {
            if (Input.GetKey(KeyCode.Tab))
            {
                Time.timeScale = 1;
            }
        }
        if(player.health <= 0)
        {
            Time.timeScale = 0;
            loseScreen.SetActive(true);
        }

        if(player.timer <= 0)
        {
            Time.timeScale = 0;
            winScreen.SetActive(true);
        }

        if(loseScreen.activeSelf || winScreen.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
