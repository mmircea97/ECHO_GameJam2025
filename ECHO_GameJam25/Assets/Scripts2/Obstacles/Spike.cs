using System;
using UnityEditor;
using UnityEngine;

public class Spike : MonoBehaviour
{ 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        EditorApplication.ExitPlaymode();
    }
}
