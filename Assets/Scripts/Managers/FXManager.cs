using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour
{
    public ParticleSystem explosionPSPrefab;

    public void PlayExplosionFX(Vector3 pos)
    {
        var newPS = Instantiate(explosionPSPrefab);
        newPS.transform.position = pos;
    }
}
