using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunfollow : MonoBehaviour
{
    public GameObject yourcamera;


    // Update is called once per frame
    void Update()
    {
        transform.rotation = yourcamera.transform.rotation;
    }
}
