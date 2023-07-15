using System;
using UnityEngine;

public class DetectCollider : MonoBehaviour
{
    private CameraShake _cameraShake;
    private Animator playerAnimator;
    private Rigidbody rb;
    private void Start()
    {
        playerAnimator = GetComponentInChildren<Animator>();
        _cameraShake = FindObjectOfType<CameraShake>();
        rb = GetComponent<Rigidbody>();
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
            playerAnimator.SetBool("balance", true);
            FindObjectOfType<SnowBoard>().speed = 10;
            FindObjectOfType<PlayerMovement>().move = false;
            FindObjectOfType<LookAtObjectMovement>().move = false;
        }

        if (other.CompareTag("FinishJump"))
        {
            FindObjectOfType<SnowBoard>().enabled = false;
            rb.isKinematic = false;
            rb.AddForce(Vector3.up*6000,ForceMode.Force);
            rb.AddForce(Vector3.forward*6000,ForceMode.Force);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("balance"))
        {
            playerAnimator.SetBool("balance", false);
            FindObjectOfType<SnowBoard>().speed = 30;
            FindObjectOfType<PlayerMovement>().move = true;
            FindObjectOfType<LookAtObjectMovement>().move = true;
        }
    }
}