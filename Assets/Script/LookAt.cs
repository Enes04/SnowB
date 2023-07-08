using UnityEngine;

public class LookAt : MonoBehaviour
{
    public GameObject target;
    public bool isLook;
    public float damping;
    void Start()
    {
        
    }

    void Update()
    {
        if(isLook)
        {
            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
        }
    }
}
