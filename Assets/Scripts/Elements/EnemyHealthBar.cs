using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    private GameDirector _gameDirector;

    public Transform fillParent;
    public GameObject healthBarBG;

    public void StartEnemyHealthBar(GameDirector gameDirector)
    {
        _gameDirector = gameDirector;
    }

    private void LateUpdate()
    {
        transform.LookAt(_gameDirector.cameraTransform.position);
    }
    public void Show()
    {
        healthBarBG.SetActive(true);
    }
    public void Hide()
    {
        healthBarBG.SetActive(false);
    }
    public void SetHealthRatio(float ratio)
    {
        fillParent.localScale = new Vector3(ratio, 1, 1);
    }
}
