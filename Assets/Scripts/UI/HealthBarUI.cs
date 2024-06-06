using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Image fillBar;
    public Image borderImage;
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void SetPlayerHealthBar(float healthRatio)
    {
        fillBar.fillAmount = healthRatio;
    }
    public void FlashBorder()
    {
        borderImage.DOKill();
        borderImage.color = Color.black;
        borderImage.DOColor(Color.red, .15f).SetLoops(2, LoopType.Yoyo);
    }
}
