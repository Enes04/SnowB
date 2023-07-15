using UnityEngine;
using PathCreation;
using PathCreation.Examples;

public class SnowBoard : MonoBehaviour
{
    public float speed;
    private float distanceTravelled;
    private PathCreator _creator;
    public EndOfPathInstruction endOfPathInstruction;
    public int i;
    public float id;
    private void Start()
    {
        _creator = FindObjectOfType<PathCreator>();
    }

    private void LateUpdate()
    {
        Snowwing();
    }
    
    public void Snowwing()
    {
        if (_creator != null)
        {
            distanceTravelled += speed*Time.deltaTime;
            transform.position =Vector3.Lerp(transform.position,_creator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction),0.25f);
            transform.rotation =Quaternion.Lerp(transform.rotation,_creator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction),0.25f);
        }
    }
}
