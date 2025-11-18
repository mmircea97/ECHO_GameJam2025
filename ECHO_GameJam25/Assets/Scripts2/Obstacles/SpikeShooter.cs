using UnityEditor;
using UnityEngine;

public class SpikeShooter : MonoBehaviour
{ 

    [SerializeField]
    private GameObject spike;

    [SerializeField]
    private float cooldown;

    private float currentCD;

    private void Start()
    {
        currentCD = cooldown+1f;
    }

    private void Update()
    {
        currentCD += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && currentCD > cooldown)
        {
            Debug.Log("Reached shooter trigger");
            GameObject spawnedSpike = Instantiate(spike, this.transform.position, Quaternion.Euler(0f, 0f, 180f));
            spawnedSpike.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
            currentCD = 0;
        }
            
    }
}
