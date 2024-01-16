using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killswitch : MonoBehaviour
{
    public int Health;
    public GameObject turret;

    [Header("States")]
    [SerializeField] public GameObject StateOne;
    [SerializeField] public GameObject StateTwo;

    public void KillSwitch(int damage)
    {
        Health -= damage;

        if(Health < 0)
        {
            StateOne.SetActive(false);
            StateTwo.SetActive(true);
            turret.GetComponent<Turret>().Alive = false;
        }
    }
}
