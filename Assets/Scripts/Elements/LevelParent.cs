using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelParent : MonoBehaviour
{
    private GameDirector _gameDirector;

    public GateTrigger gateTrigger;

    public Transform placeHoldersParent;
    public Transform diamondPlaceHoldersParent;

    public void StartLevel(GameDirector gameDirector)
    {
        _gameDirector = gameDirector;
        gateTrigger.enemyManager = _gameDirector.enemyManager;
        _gameDirector.diamondManager.diamondPlaceholdersParent = diamondPlaceHoldersParent;
        _gameDirector.enemyManager.placeHoldersParent = placeHoldersParent;
    }
}
