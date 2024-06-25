using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform leftDoor;
    public Transform rightDoor;
    public void Open()
    {
        leftDoor.DOLocalMoveZ(1, .3f);
        rightDoor.DOLocalMoveZ(-2.5f, .3f);
    }
}