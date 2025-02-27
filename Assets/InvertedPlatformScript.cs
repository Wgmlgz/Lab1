using UnityEngine;

public class InvertedPlatformScript : MonoBehaviour
{

    public bool state = false;
    InvertedPlatformScript[] allPlatforms;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        allPlatforms = Resources.FindObjectsOfTypeAll<InvertedPlatformScript>();
        state = !state;
        Reload();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Reload()
    {
        state = !state;
        print(state);
        this.gameObject.SetActive(state);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (var platform in allPlatforms)
            {
                if (platform != this)
                {
                    platform.Reload();
                }
            }
        }
    }
}
