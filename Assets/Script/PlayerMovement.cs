using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
       public float swipeSpeed;
        private float _initalX = 0;
        private float startX;
        public float sensitive;
        public float roadSize = 10;
        float currentPos;
        public bool move;
    
        private void Update()
        {
            if (move)
            {
                MovePlayerWithExactLocation();
            }
          
        }
    
        void MovePlayerWithExactLocation()
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
    
                float newX = startX + (roadSize / 2) * (screenPos - _initalX)*swipeSpeed;
                currentPos = screenPos-_initalX;
                transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(newX, transform.localPosition.y, transform.localPosition.z), sensitive * Time.deltaTime);
                var localPos = transform.localPosition;
                localPos.x = Mathf.Clamp(localPos.x, -roadSize / 2, roadSize / 2);
                transform.localPosition = localPos;
    
                currentPos = Camera.main.ScreenToViewportPoint(Input.mousePosition).x;
            }
            if (Input.GetMouseButtonUp(0))
            {
                
            }
        }
    
}
