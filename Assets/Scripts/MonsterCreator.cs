/*
 * (Levi Schoof)
 * (MonsterCreator)
 * (Assignment 6)
 * (The Abstract factory that creates monsters)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonsterCreator : MonoBehaviour
{
    public GameObject close;
    public GameObject ranged;
    public GameObject spawnPos;

    [HideInInspector] public GameObject bullet;

    public enum MonsterType {ranged, close };
    public abstract void CreatorMonster(MonsterType type);
}
