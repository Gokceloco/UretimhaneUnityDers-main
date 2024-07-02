using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameDirector gameDirector;
    public List<LevelParent> levels;
    public LevelParent curLevel;
    public void ClearCurrentLevel()
    {
        if (curLevel != null)
        {
            Destroy(curLevel.gameObject);
        }
    }
    public void CreateLevel(int levelNo)
    {
        curLevel = Instantiate(levels[levelNo - 1]);
        curLevel.StartLevel(gameDirector);
    }
}
