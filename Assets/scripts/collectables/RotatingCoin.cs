using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCoin : MonoBehaviour
{
    [Header("Rotating")]
    [SerializeField] public float speed = 5f; 
 
     public void Update()
    {
        transform.Rotate(Vector3.down * Time.deltaTime * speed);
    }
}
