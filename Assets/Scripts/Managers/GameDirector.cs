using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public InputManager inputManager;
    public EnemyManager enemyManager;
    public DiamondManager diamondManager;
    public AudioManager audioManager;

    public MainUI mainUI;
    public WinUI winUI;

    public Transform enemy;
    public Player playerHolder;
    public Rigidbody playerRb;

    public Vector2 turn;

    public Bullet bulletPrefab;
    public Transform bulletSpawnPoint;

    public bool isGameStarted;

    public int bulletCount;

    public float maxSpread;

    public bool ingameControlsLocked;

    public bool isShotgunLoaded;

    public float gunLoadTime;

    private Coroutine _loadShotgunCoroutine;

    public Transform cameraTransform;

    private void Start()
    {
        ingameControlsLocked = true;
        mainUI.Show();
        winUI.Hide();
    }

    public void StartGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        isGameStarted = true;
        enemyManager.SpawnWave();
        ingameControlsLocked = false;
    }
    void Update()
    {
        if (isGameStarted && !ingameControlsLocked)
        {
            turn.x += Input.GetAxis("Mouse X");
            turn.y += Input.GetAxis("Mouse Y");
            turn.y = Mathf.Clamp(turn.y, -7f, 25f);
            playerHolder.RotatePlayer(turn);            
        }        
    }

    public void StartLoadingShotgun()
    {
        _loadShotgunCoroutine = StartCoroutine(LoadShotgunCoroutine());
    }

    IEnumerator LoadShotgunCoroutine()
    {
        audioManager.PlayShotgunReloadSFX();
        yield return new WaitForSeconds(gunLoadTime);
        isShotgunLoaded = true;
    }

    public void StopLoadShotgunCoroutine()
    {
        if (_loadShotgunCoroutine != null)
        {
            StopCoroutine(_loadShotgunCoroutine);
        }
        audioManager.StopShotgunReloadSFX();
    }

    public void TrySpawnBullets()
    {
        if (isShotgunLoaded)
        {
            for (int i = 0;
            i < bulletCount;
            i++)
            {
                SpawnBullet();
            }
            playerHolder.PushPlayerBack();
            audioManager.PlayShotgunShootSFX();
        }
        isShotgunLoaded = false;
    }

    public void SpawnBullet()
    {
        var spread = new Vector3(
            Random.Range(-maxSpread,maxSpread),
            Random.Range(-maxSpread * .4f, maxSpread * .4f),
            Random.Range(-maxSpread, maxSpread));

        var newBullet = Instantiate(bulletPrefab);
        newBullet.transform.position = bulletSpawnPoint.position;
        newBullet.transform.LookAt(bulletSpawnPoint.position + bulletSpawnPoint.forward + spread);
    }
    public void LevelCompleted()
    {
        ingameControlsLocked = true;
        Cursor.lockState = CursorLockMode.None;
        winUI.Show();
    }

    public void DiamondCollected()
    {
        LevelCompleted();        
    }
}
