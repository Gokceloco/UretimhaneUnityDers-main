using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageUI : MonoBehaviour
{
    public TextMeshProUGUI openDoorMessage;
    public TextMeshProUGUI doorIsLockedMessage;

    public Image keyImage;

    private void Start()
    {
        HideOpenDoorMessage();
        HideDoorIsLockedMessage();
        HideKeyImage();
    }

    public void ShowOpenDoorMessage()
    {
        openDoorMessage.gameObject.SetActive(true);
    }
    public void HideOpenDoorMessage()
    {
        openDoorMessage.gameObject.SetActive(false);
    }
    public void ShowDoorIsLockedMessage()
    {
        doorIsLockedMessage.gameObject.SetActive(true);
    }
    public void HideDoorIsLockedMessage()
    {
        doorIsLockedMessage.gameObject.SetActive(false);
    }
    public void ShowKeyImage()
    {
        keyImage.gameObject.SetActive(true);
        keyImage.transform.localScale = Vector3.zero;
        keyImage.transform.DOScale(1, .3f).SetEase(Ease.OutBack);
    }
    public void HideKeyImage()
    {
        keyImage.gameObject.SetActive(false);
    }
}
