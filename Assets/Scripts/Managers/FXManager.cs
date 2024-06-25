using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour
{
    public ParticleSystem explosionPSPrefab;

    public ParticleSystem healCollectedPSPrefab;

    public void PlayExplosionFX(Vector3 pos)
    {
        var newPS = Instantiate(explosionPSPrefab);
        newPS.transform.position = pos;
    }
    public void PlayHealCollectedFX(Vector3 pos)
    {
        var newPS = Instantiate(healCollectedPSPrefab);
        newPS.transform.position = pos;
    }
}
