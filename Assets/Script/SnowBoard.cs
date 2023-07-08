using UnityEngine;

public class SnowBoard : MonoBehaviour
{
    public float speed;
    private Rigidbody _rigidbody;
    

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void LateUpdate()
    {
        Snowwing();
    }

    public void Snowwing()
    {
        _rigidbody.AddForce(Vector3.forward*speed);
        _rigidbody.maxLinearVelocity = speed/2;
    }
}
