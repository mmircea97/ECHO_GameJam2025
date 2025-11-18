using UnityEngine;

public class RemoveDarkness : MonoBehaviour
{
    [SerializeField]
    private GameObject playerHalo;

    [SerializeField]
    private GameObject darknessLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(playerHalo);
            Destroy(darknessLayer);
            gameObject.SetActive(false);
        }
    }
}
