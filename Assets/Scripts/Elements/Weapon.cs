using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Material trajectoryLoadedMaterial;
    public Material trajectoryUnloadedMaterial;
    public List<MeshRenderer> trajectoryMeshRenderers;

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
            mr.transform.localScale = new Vector3 (1, 1, .17f);
        }
    }
}
