using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New Enemy", menuName = "EnemyAtr")]
public class ScriptObj : ScriptableObject
{
    public int health;
    public int speed;
    public int strength;
    public float distanceBetween;
}
