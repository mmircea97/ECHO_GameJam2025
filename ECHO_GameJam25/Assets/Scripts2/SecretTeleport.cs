using UnityEngine;

public class SecretTeleport : MonoBehaviour
{
    [SerializeField]
    private GameObject door;
    
    [SerializeField]
    private GameObject player;
    
    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag("Player")){ 
            player.transform.position = door.transform.position;
        }
    }
}
