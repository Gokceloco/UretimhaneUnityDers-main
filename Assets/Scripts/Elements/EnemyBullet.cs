using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [Header("Properties")]
    public float bulletSpeed;
    public float bulletTime;
    public int damage;

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
        gameObject.SetActive(false);
        Destroy(gameObject, 2f);
    }
    void Move()
    {
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().PlayerGotHit(damage);
            DestroyBullet();
        }
        if (other.CompareTag("MapObjects"))
        {
            DestroyBullet();
        }
    }
}
