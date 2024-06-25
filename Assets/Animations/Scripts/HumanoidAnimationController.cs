using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanoidAnimationController : MonoBehaviour
{
    public GameDirector gameDirector;
    public bool isRunning;
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.A))
            {
                SetTriggerRunning(.125f);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                SetTriggerRunning(.875f);
            }
            else
            {
                SetTriggerRunning(0);
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.A))
            {
                SetTriggerRunning(.375f);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                SetTriggerRunning(.625f);
            }
            else
            {
                SetTriggerRunning(.5f);
            }            
        }
        else
        {
            if (Input.GetKey(KeyCode.A))
            {
                SetTriggerRunning(.25f);
            }
            if (Input.GetKey(KeyCode.D))
            {
                SetTriggerRunning(.75f);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && gameDirector.playerHolder.isTouchingGround)
        {
            animator.SetTrigger("Jump");
        }
        if (!isRunning)
        {
            animator.ResetTrigger("Run");
            animator.SetTrigger("Idle");
        }
    }
    public void SetTriggerRunning(float dir)
    {
        animator.ResetTrigger("Idle");
        animator.SetTrigger("Run");
        isRunning = true;
        animator.SetFloat("RunDirectionBlend", dir);
    }
    private void LateUpdate()
    {
        isRunning = false;
    }
}
