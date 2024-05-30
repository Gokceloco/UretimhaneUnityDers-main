using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyManager enemyManager;
    public Transform playerTransform;

    public float enemySpeed;

    public bool isEnemyStarted;

    public Transform leftWheel;
    public Transform rightWheel;

    public float wheelRotationSpeed;

    public int startHealth;
    private int _curHealth;

    private Rigidbody _rb;

    public void StartEnemy(Transform pTransform, EnemyManager eManager)
    {
        playerTransform = pTransform;
        enemyManager = eManager;
        _curHealth = startHealth;
        _rb = GetComponent<Rigidbody>();
    }

    public void StartMoving()
    {
        isEnemyStarted = true;
    }    

    public float GetHealthRatio()
    {
        return (float)_curHealth / startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnemyStarted)
        {
            var direction = playerTransform.position - transform.position;
            var directionNormalized = direction.normalized;
            transform.position += directionNormalized * enemySpeed * Time.deltaTime;
            transform.LookAt(playerTransform.position);
            rightWheel.Rotate(0, -wheelRotationSpeed, 0);
            leftWheel.Rotate(0, wheelRotationSpeed, 0);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            ReduceHealth(1);
        }
    }

    public void EnemyGotHit(int damage, Vector3 pushDirection, float pushPower)
    {
        ReduceHealth(damage);
        PushEnemy(pushDirection, pushPower);
        enemyManager.gameDirector.audioManager.PlayMetalImpactSFX();
    }
    private void PushEnemy(Vector3 pushDirection, float pushPower)
    {
        _rb.AddForce(pushDirection * pushPower);
    }
    private void ReduceHealth(int damage)
    {
        _curHealth -= damage;
        if (_curHealth <= 0)
        {
            KillEnemy();
        }
        print(GetHealthRatio());
    }
    private void KillEnemy()
    {
        enemyManager.EnemyDied(this);
        gameObject.SetActive(false);
    }
}
