using UnityEngine;

public class LightFade : MonoBehaviour
{
    [SerializeField]
    private GameObject gameObject;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            StartCoroutine(FadeSprite());
    }

    private System.Collections.IEnumerator FadeSprite()
    {
        float elapsedTime = 0f;

        while (elapsedTime < 1.5f)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, Mathf.Lerp(1f, 0f, elapsedTime/1.5f));

            elapsedTime += Time.deltaTime;

            yield return null;
        }

    }
}
