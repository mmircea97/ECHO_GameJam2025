using UnityEngine;

public class ProjectileSpike : MonoBehaviour
{
    [SerializeField]
    private float fallSpeed;
    [SerializeField]
    private float acceleration;

    private void Update()
    {
        fallSpeed += acceleration * Time.deltaTime;
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
