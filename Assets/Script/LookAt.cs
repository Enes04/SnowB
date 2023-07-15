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
          
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
            //transform.GetChild(0).transform.rotation = Quaternion.Euler(0, 90,15);
        }
    }
}
