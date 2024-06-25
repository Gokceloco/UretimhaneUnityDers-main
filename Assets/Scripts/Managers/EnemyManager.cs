using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameDirector gameDirector;
    public Transform placeHoldersParent;

    public Enemy enemyPrefab;

    public PowerUp healPowerUpPrefab;

    public List<Enemy> activeEnemies = new List<Enemy>();

    public void AlarmEnemies()
    {
        foreach (Enemy enemy in activeEnemies)
        {
            enemy.StartMoving();
        }
    }

    public void SpawnWaveDelayed(float delay)
    {
        Invoke(nameof(SpawnWave), delay);
    }

    public void SpawnWave()
    {
        foreach (Transform ph in placeHoldersParent)
        {
            SpawnEnemy(ph.position);
            ph.GetComponent<MeshRenderer>().enabled = false;
        }
    }
    public void SpawnEnemy(Vector3 position)
    {
        var newEnemy = Instantiate(enemyPrefab);
        newEnemy.transform.position = position;
        newEnemy.StartEnemy(gameDirector.playerHolder.transform, this);
        activeEnemies.Add(newEnemy);
    }

    public void EnemyDied(Enemy e)
    {
        activeEnemies.Remove(e);
        if (activeEnemies.Count == 0)
        {
            gameDirector.diamondManager.SpawnDiamonds();
        }
        if (Random.value < .5f)
        {
            SpawnPowerUp(e);
        }
    }

    private void SpawnPowerUp(Enemy e)
    {
        var newPowerUp = Instantiate(healPowerUpPrefab);
        newPowerUp.transform.position = e.transform.position + Vector3.up;
        newPowerUp.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-200,200), 200, Random.Range(-200, 200)));
    }
}
