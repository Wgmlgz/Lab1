using UnityEngine;

public class TpPlatformScript : MonoBehaviour
{

    public TpPlatformScript other_platform;
    public bool ready = true;
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
        if (other.CompareTag("Player") && ready)
        {

            var tmp = other_platform.transform.position;
            tmp.y += 1;
            other.transform.position = tmp;

            other_platform.ready = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ready = true;
        }
    }
}
