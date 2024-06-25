using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    [Header("Player Settings")]
    public bool shootingAlarmEnemies;
    public float playerSpeed;
    public float jumpPower;
    public float gunLoadTime;
    public int bulletCount;
    public float maxSpread;

    [Header("Powerup Settings")]
    public float healSpawnChance;
}
