using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameDirector gameDirector;
    public Settings settings;

    public Weapon weapon;

    public Rigidbody playerRb;
    public Transform playerMesh;

    public float recoilForce;

    public float speedMultiplier;

    public int startHealth;
    private int _curHealth;

    public bool isTouchingGround;

    public ObjectDetector objectDetector;

    public void StartPlayer()
    {
        _curHealth = startHealth;
        gameDirector.healthBarUI.SetPlayerHealthBar(1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Heal"))
        {
            GetHealed();
            collision.gameObject.SetActive(false);
            gameDirector.fxManager.PlayHealCollectedFX(collision.transform.position);
            gameDirector.audioManager.PlayHealSFX();
        }
    }

    private void GetHealed()
    {
        _curHealth += Mathf.RoundToInt(startHealth * .5f);
        if (_curHealth > startHealth)
        {
            _curHealth = startHealth;
        }
        gameDirector.healthBarUI.SetPlayerHealthBar(GetHealthRatio());
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("MapObjects"))
        {
            isTouchingGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("MapObjects"))
        {
            isTouchingGround = false;
        }
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
        gameDirector.healthBarUI.SetPlayerHealthBar(GetHealthRatio());
        gameDirector.getHitUI.ShowDamageEffect();
        gameDirector.healthBarUI.FlashBorder();
    }
    public float GetHealthRatio()
    {
        return (float)_curHealth / startHealth;
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
        transform.position += direction * settings.playerSpeed * Time.deltaTime * speedMultiplier;
    }
    public void MakePlayerJump()
    {
        playerRb.AddForce(new Vector3(0, 1, 0) * settings.jumpPower);
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
