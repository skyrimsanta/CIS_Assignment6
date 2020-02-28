
/*
 * (Levi Schoof)
 * (Monster)
 * (Assignment 6)
 * (The Abstract Class that gets created by the factories)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    public Color color;


    public void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * 700);
        StartCoroutine("KillThis");
    }


    IEnumerator KillThis()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
}
