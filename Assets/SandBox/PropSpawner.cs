using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropSpawner : MonoBehaviour
{
    [Header("Spawn Location")]
    public GameObject SpawnLoc;
    public GameObject Parent;

    [Header("Props for player")]
    public GameObject BeanOBJ;


    public void SpawnBean()
    {
        Instantiate(BeanOBJ.transform, SpawnLoc.transform.position, transform.rotation, Parent.transform);
    }
}
