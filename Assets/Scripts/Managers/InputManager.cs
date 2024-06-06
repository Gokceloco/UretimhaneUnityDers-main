using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    public GameDirector gameDirector;
    public Transform playerMesh;

    public float mouseSensitivity;

    public Vector2 turn;

    // Update is called once per frame
    void Update()
    {
        if(!gameDirector.ingameControlsLocked)
        {
            if (gameDirector.isGameStarted)
            {
                turn.x += Input.GetAxis("Mouse X");
                turn.y += Input.GetAxis("Mouse Y");
                turn.y = Mathf.Clamp(turn.y, -15f, 25f);
                gameDirector.playerHolder.RotatePlayer(turn);
            }
            if (Input.GetKey(KeyCode.S))
            {
                var direction = -playerMesh.forward;
                direction.y = 0;
                gameDirector.playerHolder.MovePlayer(direction);
            }
            if (Input.GetKey(KeyCode.W))
            {
                var direction = playerMesh.forward;
                direction.y = 0;
                gameDirector.playerHolder.MovePlayer(direction);
            }
            if (Input.GetKey(KeyCode.A))
            {
                var direction = -playerMesh.right;
                direction.y = 0;
                gameDirector.playerHolder.MovePlayer(direction);
            }
            if (Input.GetKey(KeyCode.D))
            {
                var direction = playerMesh.right;
                direction.y = 0;
                gameDirector.playerHolder.MovePlayer(direction);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameDirector.playerHolder.MakePlayerJump();
            }
            if (Input.GetMouseButtonDown(0))
            {
                gameDirector.playerHolder.weapon.StartLoadingShotgun();
            }
            if (Input.GetMouseButtonUp(0))
            {
                gameDirector.playerHolder.weapon.StopLoadShotgunCoroutine();
                gameDirector.playerHolder.weapon.TrySpawnBullets();
            }
            if (Input.GetKeyDown(KeyCode.F1))
            {
                gameDirector.mainUI.Show();
                Cursor.lockState = CursorLockMode.None;
            }
            if (Input.GetKeyDown(KeyCode.F5))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Cursor.lockState = CursorLockMode.None;
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                gameDirector.enemyManager.SpawnWave();
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                gameDirector.playerHolder.speedMultiplier = 1.6f;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                gameDirector.playerHolder.speedMultiplier = 1f;
            }
        }        
    }
}
