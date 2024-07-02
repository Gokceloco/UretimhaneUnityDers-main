using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdminUI : MonoBehaviour
{
    public GameDirector gameDirector;
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void ResetProgressButtonPressed()
    {
        Hide();
        PlayerPrefs.SetInt("LastLevelReached", 0);
        SceneManager.LoadScene(0);
    }
}
