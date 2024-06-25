using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource shotgunReloadAS;
    public AudioSource shotgunShootAS;
    public AudioSource metalImpactAS;
    public AudioSource healAS;

    public void PlayShotgunReloadSFX()
    {
        shotgunReloadAS.Play();
    }
    public void StopShotgunReloadSFX()
    {
        shotgunReloadAS.Stop();
    }
    public void PlayShotgunShootSFX()
    {
        shotgunShootAS.Play();
    }
    public void PlayMetalImpactSFX()
    {
        metalImpactAS.Play();
    }
    public void PlayHealSFX()
    {
        healAS.Play();
    }
}
