using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    [Header("KillZone")]
    [SerializeField] public GameObject Player;
    [SerializeField] public int Damage;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player.GetComponent<Player>().curHp -= Damage;
        }
    }
}
