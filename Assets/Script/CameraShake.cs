using System;
using System.Collections;
using Cinemachine;
using UnityEngine;
using Random = UnityEngine.Random;
using DG.Tweening;

public class CameraShake : MonoBehaviour
{
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private CinemachineTransposer vcam;
    private Vector3 baseOffset;
    private float currentTime, endTime;
    private float baseX, baseY, baseZ;
    public float posX, posY, posZ;
    public bool jump;
    private void Awake()
    {
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        vcam = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>();
        baseOffset = vcam.m_FollowOffset;
        posX = vcam.m_FollowOffset.x;
        posY = vcam.m_FollowOffset.y;
        posZ = vcam.m_FollowOffset.z;
        baseX = vcam.m_FollowOffset.x;
        baseY = vcam.m_FollowOffset.y;
        baseZ = vcam.m_FollowOffset.z;
        endTime = 1;
    }

    private void Update()
    {
        if (!jump)
        {
            currentTime += Time.deltaTime;
            if (currentTime > endTime)
            {
                currentTime = 0;
                ShakeCam();
            }
        }
        else
        {
            vcam.m_FollowOffset = new Vector3(posX, posY,
                posZ);
        }
       
    }

    public void ShakeCam()
    {
        StartCoroutine(Shake(endTime, .01f));
    }

    public void ShakeBoss()
    {
        StartCoroutine(Shake(2f, 2f));
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            float z = Random.Range(-1f, 1f) * magnitude;

            posX += x;
            posY += y;
            posZ += z;
            
            vcam.m_FollowOffset = new Vector3(posX, posY,
                posZ);
            elapsed += Time.deltaTime;
            yield return 0;

            posX = Mathf.Clamp(posX, baseX - 2, baseX + 2);
            posY = Mathf.Clamp(posY, baseY - 2, baseY + 2);
            posZ = Mathf.Clamp(posZ, baseZ - 2, baseZ + 2);
        }
      
    }

    public void JumpEffect()
    {
        StopCoroutine(Shake(endTime,0.1f));
        jump = true;
        transform.DOKill();
        DOTween.To(() => posY, x => posY = x, posY+3, .5f).OnComplete(() =>
        {
            DOTween.To(() => posY, x => posY = x, posY - 3, .5f).OnComplete(() =>
            {
                jump = false;
            });
        });
       
    }
}