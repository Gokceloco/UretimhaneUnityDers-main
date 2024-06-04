using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    private Enemy _enemy;
    public EnemyBullet enemyBulletPrefab;
    public List<Transform> shootPositions;

    public void StartEnemyWeapon(Enemy enemy)
    {
        _enemy = enemy;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        foreach (Transform sp in shootPositions)
        {
            var newBullet = Instantiate(enemyBulletPrefab);
            newBullet.transform.position = sp.position;
            newBullet.transform.LookAt(_enemy.playerTransform.position);
        }
    }
}
