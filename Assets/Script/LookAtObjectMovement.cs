using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObjectMovement : MonoBehaviour
{
    [Header("Player Swipe Settings For PC")]
    public float roadSize = 10;

    public float swipeSpeed = 5;
    public float sensitive = 3;
    private float _initalX = 0;
    private float startX;
    public GameObject playersObj;
    public bool move;

    private void Update()
    {
        if (move)
            PlayerSwipe();
    }


    public void PlayerSwipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _initalX = Camera.main.ScreenToViewportPoint(Input.mousePosition).x;
            startX = transform.localPosition.x;
        }

        if (Input.GetMouseButton(0))
        {
            float screenPos = Camera.main.ScreenToViewportPoint(Input.mousePosition).x;
            screenPos = Mathf.Clamp(screenPos, 0, 1);

            float newX = startX + (roadSize / 2) * (screenPos - _initalX) * swipeSpeed;
            transform.localPosition = Vector3.Lerp(transform.localPosition,
                new Vector3(newX, transform.localPosition.y, transform.localPosition.z), sensitive * Time.deltaTime);

            var localPos = transform.localPosition;
            localPos.x = Mathf.Clamp(localPos.x, -roadSize / 2, roadSize / 2);
            transform.localPosition = localPos;
        }

        if (!Input.GetMouseButton(0))
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition,
                new Vector3(playersObj.transform.localPosition.x, transform.localPosition.y, transform.localPosition.z),
                0.025f);
        }
    }
}