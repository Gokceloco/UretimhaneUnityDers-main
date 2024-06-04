using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    private Enemy _enemy;
    public EnemyBullet enemyBulletPrefab;
    public List<Transform> shootPositions;
    public float attackRate;

    private float _lastShootTime;

    public void StartEnemyWeapon(Enemy enemy)
    {
        _enemy = enemy;
    }

    public void TryShoot()
    {
        if (Time.time - _lastShootTime > attackRate)
        {
            foreach (Transform sp in shootPositions)
            {
                var newBullet = Instantiate(enemyBulletPrefab);
                newBullet.transform.position = sp.position;
                newBullet.transform.LookAt(_enemy.playerTransform.position + Vector3.up * 1.5f);
            }
            _lastShootTime = Time.time;
        }       
    }
}
