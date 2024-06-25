using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Player player;
    public Settings settings;

    public Material trajectoryLoadedMaterial;
    public Material trajectoryUnloadedMaterial;
    public List<MeshRenderer> trajectoryMeshRenderers;

    public Bullet bulletPrefab;
    public Transform bulletSpawnPoint;

    private Coroutine _loadShotgunCoroutine;
    public bool isShotgunLoaded;

    public ParticleSystem muzzlePS;

    public Transform handTransform;

    public Vector3 handOffset;

    private void Update()
    {
        transform.position = handTransform.position + handOffset;
    }
    public void TrySpawnBullets()
    {
        if (isShotgunLoaded)
        {
            for (int i = 0;
            i < settings.bulletCount;
            i++)
            {
                SpawnBullet();
            }
            player.PushPlayerBack();
            if (settings.shootingAlarmEnemies)
            {
                player.gameDirector.enemyManager.AlarmEnemies();
            }
            muzzlePS.Play();
            player.gameDirector.audioManager.PlayShotgunShootSFX();
        }
        isShotgunLoaded = false;
        ChangeTrajectoryMaterialsToUnloaded();
    }

    public void StartLoadingShotgun()
    {
        _loadShotgunCoroutine = StartCoroutine(LoadShotgunCoroutine());
    }

    IEnumerator LoadShotgunCoroutine()
    {
        player.gameDirector.audioManager.PlayShotgunReloadSFX();
        yield return new WaitForSeconds(settings.gunLoadTime);
        isShotgunLoaded = true;
        ChangeTrajectoryMaterialsToLoaded();
    }

    public void StopLoadShotgunCoroutine()
    {
        if (_loadShotgunCoroutine != null)
        {
            StopCoroutine(_loadShotgunCoroutine);
        }
        player.gameDirector.audioManager.StopShotgunReloadSFX();
    }

    public void SpawnBullet()
    {
        var maxSpread = settings.maxSpread;
        var spread = new Vector3(
            Random.Range(-maxSpread, maxSpread),
            Random.Range(-maxSpread * .4f, maxSpread * .4f),
            Random.Range(-maxSpread, maxSpread));

        var newBullet = Instantiate(bulletPrefab);
        newBullet.transform.position = bulletSpawnPoint.position;
        newBullet.transform.LookAt(bulletSpawnPoint.position + bulletSpawnPoint.forward + spread);
    }

    public void ChangeTrajectoryMaterialsToLoaded()
    {
        foreach (var mr in trajectoryMeshRenderers)
        {
            mr.material = trajectoryLoadedMaterial;
            var startScale = mr.transform.localScale;
            mr.transform.DOScale(startScale * 1.5f, .5f).SetLoops(-1, LoopType.Yoyo);
        }
    }
    public void ChangeTrajectoryMaterialsToUnloaded()
    {
        foreach (var mr in trajectoryMeshRenderers)
        {
            mr.material = trajectoryUnloadedMaterial;
            mr.transform.DOKill();
            mr.transform.localScale = Vector3.one * .18f;
        }
    }
}
