/*
 * (Levi Schoof)
 * (Enemy)
 * (Assignment 6)
 * (Handles The creation and behavior of the enemies)
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool close;
    public Color pink;
    public Color green;
    Vector3 newPos;

    private PlayerScript player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerScript>();
        float num = Random.Range(0, 100);
        if(num > 50)
        {
            close = true;
            this.GetComponent<MeshRenderer>().material.color = green;
        }

        else
        {
            close = false;
            this.GetComponent<MeshRenderer>().material.color = pink;
        }
    }

    // Update is called once per frame
    void Update()
    {
        newPos = this.transform.position;
        newPos.z -= 5 * Time.deltaTime;
        //newPos *= Time.deltaTime;

        this.transform.position = newPos;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Monster>())
        {
            if(other.GetComponent<LeftClose>() || other.GetComponent<RightClose>())
            {
                if (close)
                {
                    Destroy(other.gameObject);
                    Destroy(this.gameObject);
                }
            }

            else
            {
                if (!close)
                {
                    Destroy(other.gameObject);
                    Destroy(this.gameObject);
                }
            }
        }

        if (other.gameObject.CompareTag("Line"))
        {
            player.TakeDamage();
            Destroy(this.gameObject);
        }
    }
}
