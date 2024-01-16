using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using WebSocketSharp;

public class CaptureZone : MonoBehaviour
{
    [Header("capture zone settings")]
    public float Area = 45f;
    public string ZoneName;

    public List<GameObject> Enemys = new List<GameObject>();
    public bool IsAllEnemiesDead;


    void Update()
    { 
            if (Enemys.Count == 0)
            {
                IsAllEnemiesDead = !IsAllEnemiesDead;
                Debug.Log("all dead");
            }

    }

    void IsAllDead()
    {
        return;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Area);
    }
}
