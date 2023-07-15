using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public TextMeshProUGUI playerSpeed;
  public Rigidbody playerRigidBody;


  private void Update()
  {
    playerSpeed.text ="KMH:"+playerRigidBody.velocity.magnitude.ToString("N0");
  }
}
