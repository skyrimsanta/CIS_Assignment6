/*
 * (Levi Schoof)
 * (RightLaneCreator)
 * (Assignment 6)
 * (Handles The creation of Right lane bullets)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightLaneCreator :  MonsterCreator
{
    public override void CreatorMonster(MonsterType type)
    {
        if (type == MonsterType.close)
        {
            bullet = Instantiate(close/*, spawnPos.transform*/);
        }

        else if (type == MonsterType.ranged)
        {
            bullet = Instantiate(ranged/*, spawnPos.transform*/);
        }

        Vector3 newPos = spawnPos.transform.position;
        newPos += transform.forward * 10;
        bullet.transform.position = newPos;
    }
}
