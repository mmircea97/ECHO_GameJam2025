using System;
using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField] 
    private Rigidbody2D rb;

    [SerializeField] 
    private float bounciness;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("LOLLLLL");
    }
}
