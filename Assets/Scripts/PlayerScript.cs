/*
 * (Levi Schoof)
 * (PlayerScript)
 * (Assignment 6)
 * (The Clien Class that creates the monsters)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    MonsterCreator monsterCreator;
    private bool isLeft;
    public GameObject leftSpawn;
    public GameObject rightSpawn;
    public GameObject cannon;

    private bool canFire = true;

    [HideInInspector] public int health;
    public Text healthText;

    public Text timerText;
     [HideInInspector]  public int timer = 30;

    private void Start()
    {
        health = 4;
        healthText.text = "Health " + health;

        timerText.text = "Time Left: " + timer;

        monsterCreator = FindObjectOfType<LeftLanecCreator>();
        isLeft = true;
        cannon.transform.position = leftSpawn.transform.position;

        StartCoroutine("Timer");
    }

    private void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isLeft)
            {
                monsterCreator = FindObjectOfType<RightLaneCreator>();
                cannon.transform.position = rightSpawn.transform.position;
                isLeft = false;
            }

            else
            {
                monsterCreator = FindObjectOfType<LeftLanecCreator>();
                cannon.transform.position = leftSpawn.transform.position;
                isLeft = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) & canFire)
        {
            StartCoroutine("Fire");
            monsterCreator.CreatorMonster(MonsterCreator.MonsterType.close);
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2) & canFire)
        {
            StartCoroutine("Fire");
            monsterCreator.CreatorMonster(MonsterCreator.MonsterType.ranged);
        }
    }

    IEnumerator Fire()
    {
        canFire = false;
        yield return new WaitForSeconds(.5f);
        canFire = true;
    }

    IEnumerator Timer()
    {
        while(timer > 0)
        {
            yield return new WaitForSeconds(1);
            timer--;
            timerText.text = "Time Left: " + timer;
        }
    }

    public void TakeDamage()
    {
        health--;
        healthText.text = "Health " + health;
    }
}
