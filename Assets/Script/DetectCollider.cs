using System;
using UnityEngine;

public class DetectCollider : MonoBehaviour
{
    private CameraShake _cameraShake;
    private Animator playerAnimator;

    private void Start()
    {
        playerAnimator = GetComponentInChildren<Animator>();
        _cameraShake = FindObjectOfType<CameraShake>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jump"))
        {
            playerAnimator.SetTrigger("jump");
            _cameraShake.JumpEffect();
        }

        if (other.CompareTag("balance"))
        {
            playerAnimator.SetBool("balance",true);
            FindObjectOfType<SnowBoard>().speed = 10;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("balance"))
        {
            playerAnimator.SetBool("balance",false);
            FindObjectOfType<SnowBoard>().speed = 30;
        }
    }
}
