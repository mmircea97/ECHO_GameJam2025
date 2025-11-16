using UnityEngine;

public class RemoveDarkness : MonoBehaviour
{
    [SerializeField]
    private GameObject gameObject;

    [SerializeField]
    private GameObject darknessLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            Destroy(darknessLayer);
        }

    }
}
