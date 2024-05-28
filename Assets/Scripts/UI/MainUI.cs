using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
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

    public void StartGameButtonPressed()
    {
        Hide();
        gameDirector.StartGame();
    }
}
