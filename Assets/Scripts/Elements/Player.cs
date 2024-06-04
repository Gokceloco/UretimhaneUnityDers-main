using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameDirector gameDirector;

    public Weapon weapon;

    public float playerSpeed;
    public float jumpForce;
    public Rigidbody playerRb;
    public Transform playerMesh;

    public float recoilForce;

    public float speedMultiplier;

    public int startHealth;
    private int _curHealth;

    public void StartPlayer()
    {
        _curHealth = startHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayerGotHit(1);
        }
    }

    public void PlayerGotHit(int damage)
    {
        ReduceHealth(damage);
    }

    void ReduceHealth(int damage)
    {
        _curHealth -= damage;
        if (_curHealth <= 0)
        {
            gameDirector.LevelFailed();
        }
    }

    public void MovePlayer(Vector3 direction)
    {
        transform.position += direction * playerSpeed * Time.deltaTime * speedMultiplier;
    }
    public void MakePlayerJump()
    {
        playerRb.AddForce(new Vector3(0, 1, 0) * jumpForce);
    }

    public void RotatePlayer(Vector2 turn)
    {
        var mouseSensitivity = gameDirector.inputManager.mouseSensitivity;
        playerMesh.localRotation = Quaternion.Euler(-turn.y * mouseSensitivity, turn.x * mouseSensitivity, 0);
    }
    public void PushPlayerBack()
    {
        playerRb.AddForce(-playerMesh.transform.forward * recoilForce);
    }
}
