using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHitUI : MonoBehaviour
{
    public void ShowDamageEffect()
    {
        var canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.DOKill();
        canvasGroup.alpha = 0;
        canvasGroup.DOFade(.3f, .1f).SetLoops(2, LoopType.Yoyo);
    }
}
