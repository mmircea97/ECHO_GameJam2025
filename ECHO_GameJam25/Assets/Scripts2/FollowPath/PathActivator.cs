using UnityEngine;

public class PathActivator : MonoBehaviour
{
    [SerializeField]
    private GameObject gameObject;
    void Start()
    {
        gameObject.GetComponent<Path>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            gameObject.GetComponent<Path>().enabled=true;
    }
}
