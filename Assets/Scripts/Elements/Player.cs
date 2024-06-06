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

    public void StartPlayer()
    {
        _curHealth = startHealth;
        gameDirector.healthBarUI.SetPlayerHealthBar(1);
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
