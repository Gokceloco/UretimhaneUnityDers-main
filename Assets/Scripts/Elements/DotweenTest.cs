using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotweenTest : MonoBehaviour
{
    private void Start()
    {
        transform.localScale = Vector3.one * 2;
        transform.DOScale(2.5f, .5f).SetLoops(-1, LoopType.Yoyo);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
        }
    }
}
