using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    [Header("Managers")]
    public InputManager inputManager;
    public EnemyManager enemyManager;
    public DiamondManager diamondManager;
    public AudioManager audioManager;
    public FXManager fxManager;
    public Settings settings;
    public Player playerHolder;

    [Header("UI")]
    public MainUI mainUI;
    public WinUI winUI;
    public FailUI failUI;
    public HealthBarUI healthBarUI;
    public GetHitUI getHitUI;    
    public MessageUI messageUI;

    public bool isGameStarted;
    public bool ingameControlsLocked;
    public Transform cameraTransform;

    public int desiredLevel;

    private void Start()
    {
        var curLevel = SceneManager.GetActiveScene().buildIndex;
        
        if (curLevel != desiredLevel)
        {
            SceneManager.LoadScene(desiredLevel);
        }
        
        ingameControlsLocked = true;
        mainUI.Show();
        winUI.Hide();
        failUI.Hide();
    }

    public void StartGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        isGameStarted = true;
        enemyManager.SpawnWave();
        ingameControlsLocked = false;
        playerHolder.StartPlayer();
        healthBarUI.Show();
    }    
    public void LevelCompleted()
    {
        ingameControlsLocked = true;
        Cursor.lockState = CursorLockMode.None;
        winUI.Show();
        healthBarUI.Hide();
        desiredLevel += 1;
    }

    public void LevelFailed()
    {
        ingameControlsLocked = true;
        Cursor.lockState = CursorLockMode.None;
        failUI.Show();
        healthBarUI.Hide();
    }

    public void DiamondCollected()
    {
        LevelCompleted();        
    }
}
