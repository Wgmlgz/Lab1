using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{

    public Vector3 offset;
    public float speed;

    public float delay;

    float currentT;

    float climbTime;
    Vector3 originalPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        climbTime = (offset.magnitude / speed);
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentT += Time.fixedDeltaTime;

        var newPosition = originalPosition;
        if (currentT < delay)
        {
        }
        else if (currentT < delay + climbTime)
        {
            newPosition += ((currentT - delay) / climbTime) * offset;
        }
        else if (currentT < delay * 2 + climbTime)
        {
            newPosition += offset;
        }
        else if (currentT < delay * 2 + climbTime * 2)
        {
            newPosition += (1 - (currentT - delay * 2 - climbTime) / climbTime) * offset;
        }
        else
        {
            currentT = 0;
        }
        transform.position = newPosition;
    }
}