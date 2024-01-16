using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    [Header("Weather")]
    
    [Space]
    
    [Header("Sun Settings")]
    public Light Sun;


    void Update()
    {
        
    }

    public void morning()
    {
        Sun.transform.rotation = Quaternion.Euler(1.9f, -28, 0);
        Sun.intensity = 0.5f;
    }

    public void Day()
    {
        Sun.transform.rotation = Quaternion.Euler(48, -28, 0);
        Sun.intensity = 130000;
    }
}
