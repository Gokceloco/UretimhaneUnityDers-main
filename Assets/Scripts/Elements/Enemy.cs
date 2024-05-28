using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyManager enemyManager;
    public Transform playerTransform;

    public float enemySpeed;

    public bool isEnemyStarted;

    public void StartEnemy(Transform pTransform, EnemyManager eManager)
    {
        playerTransform = pTransform;
        enemyManager = eManager;
    }

    public void StartMoving()
    {
        isEnemyStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnemyStarted)
        {
            var direction = playerTransform.position - transform.position;
            var directionNormalized = direction.normalized;
            transform.position += directionNormalized * enemySpeed * Time.deltaTime;
        }
    }

    public void EnemyGotHit()
    {
        enemyManager.EnemyDied(this);

        enemyManager.gameDirector.audioManager.PlayMetalImpactSFX();

        gameObject.SetActive(false);        
    }
}
