using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Turret : MonoBehaviour
{
    [Header("Enemy Stuff")]
    [SerializeField] public float LookRadius = 10f;
    [SerializeField] public float FireRadius = 5f;
    [SerializeField] public bool Alive;

    [Header("Enemy Hands")]
    [SerializeField] public GameObject Head;
    [SerializeField] public GameObject deadspot;
    [SerializeField] public float TurnSpeed;
    public GameObject QuestIngs;

    Pistiol weapon;

    Transform target;
    Vector3 Direction;
    Quaternion rotPlayer;

    void Start()
    {
        target = GameManager.instance.Player.transform;

        //get the components
        weapon = GetComponent<Pistiol>();
    }

    private void Update()
    {
        turret();
        if(!Alive)
        {
            //QuestIngs.GetComponent<QuestBase>().TurretNum += 1;
            this.gameObject.GetComponent<Turret>().enabled = false;
        }
    }

    void turret()
    {
        float player = Vector3.Distance(target.position, transform.position);

        if (Alive)
        {
            if (player < LookRadius)
            {
                //Smoothening
                Direction = (target.position - transform.position).normalized;
                rotPlayer = Quaternion.LookRotation(Direction);
                transform.rotation = Quaternion.Slerp(Head.transform.rotation, rotPlayer, TurnSpeed);
            }

            if (player < FireRadius)
            {
                weapon.Shoot();
            }
        }
        else
        {
            return;
            
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, LookRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, FireRadius);
    }
}
