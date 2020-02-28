/*
 * (Levi Schoof)
 * (EnemySpawner)
 * (Assignment 6)
 * (Will spawn an enemy at a random one of the spawn locations every few seconds)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject leftSpawn;
    public GameObject rightSpawn;

    public GameObject enemy;
    // Update is called once per fram

    private void Start()
    {
        StartCoroutine("Spawner");
    }

    private void SpawnEnemy()
    {
        float num = Random.Range(0, 100);
        GameObject temp = Instantiate(enemy); 
        if(num >= 50)
        {
            temp.transform.position = leftSpawn.transform.position;
        }

        else
        {
            temp.transform.position = rightSpawn.transform.position;
        }

        StartCoroutine("Spawner");
    }

    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(1.5f);
        SpawnEnemy();
    }
}
