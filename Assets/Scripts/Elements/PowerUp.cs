using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private Player _player;
    public Transform heartMesh;
    public void StartPowerUp(Player player)
    {
        _player = player;
        heartMesh.DOScale(1.5f, .3f).SetLoops(-1, LoopType.Yoyo);
    }
    private void Update()
    {
        var lookPos = _player.transform.position;
        lookPos.y = transform.position.y;
        transform.LookAt(lookPos);
    }
}
