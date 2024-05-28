using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondManager : MonoBehaviour
{
    public GameDirector gameDirector;

    public Transform diamondPlaceholdersParent;

    public Diamond diamondPrefab;

    private void Start()
    {
        foreach (Transform ph in diamondPlaceholdersParent)
        {
            ph.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    public void SpawnDiamonds()
    {
        foreach (Transform ph in diamondPlaceholdersParent)
        {
            var newDiamond = Instantiate(diamondPrefab);
            newDiamond.transform.position = ph.position;
            newDiamond.StartDiamond(gameDirector);
        }
    }
}
