using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleporter : MonoBehaviour
{
    public GameObject Player;
    public GameObject Teleporter;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player.transform.position = Teleporter.transform.position;
            Player.transform.rotation = Teleporter.transform.rotation;
        } 
    }
}
