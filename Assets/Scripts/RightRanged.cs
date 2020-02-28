/*
 * (Levi Schoof)
 * (RightClose)
 * (Assignment 6)
 * (Derives The Monster class and is part of the Right Factory)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightRanged : Monster
{
    new private void Start()
    {
        base.Start();
        this.gameObject.GetComponent<MeshRenderer>().material.color = color;
    }
}
