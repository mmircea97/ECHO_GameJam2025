using System.Collections;
using UnityEngine;

public class Dissapear : MonoBehaviour
{
    [Header("Settings")]
    public float disappearDelay = 1f;    
    public float reappearDelay = 3f;     

    private Rigidbody2D rb;
    private Collider2D col;
    private SpriteRenderer sr;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(FadeAndRespawn());
        }
    }

    private IEnumerator FadeAndRespawn()
    {
        
        yield return new WaitForSeconds(disappearDelay);

        
        if (sr != null) sr.enabled = false;
        if (col != null) col.enabled = false;
        if (rb != null) rb.isKinematic = true;

       
        yield return new WaitForSeconds(reappearDelay);

       
        if (sr != null) sr.enabled = true;
        if (col != null) col.enabled = true;
        if (rb != null) rb.isKinematic = false;
    }
}
