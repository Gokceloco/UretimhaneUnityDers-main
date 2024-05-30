using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Properties")]
    public float bulletSpeed;
    public float bulletTime;
    public int damage;
    public float pushPower;

    private float _bulletStartTime;

    [Header("Elements")]
    public MeshRenderer bulletMesh;
    public SphereCollider sphereCollider;

    private void Start()
    {
        _bulletStartTime = Time.time;
    }

    private void Update()
    {
        if (Time.time - _bulletStartTime > bulletTime)
        {
            DestroyBullet();
        }
        else
        {
            Move();
        }
    }

    void DestroyBullet()
    {
        bulletMesh.enabled = false;
        sphereCollider.enabled = false;
        Destroy(gameObject, 2f);
    }

    void Move()
    {
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) 
        {
            other.GetComponent<Enemy>().EnemyGotHit(damage, transform.forward, pushPower);
            DestroyBullet();
        }
        else if (other.CompareTag("MapObjects"))
        {
            DestroyBullet();
        }
    }
}
