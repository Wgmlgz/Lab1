using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public Rigidbody rigidBody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        // print(other.name);
        if (other.CompareTag("Player"))
        {
            rigidBody.isKinematic = false;
        }
    }
}
