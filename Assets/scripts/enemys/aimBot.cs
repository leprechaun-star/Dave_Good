using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimBot : MonoBehaviour
{
    public BetterEnemy Mine;
    public float TurnSpeed;

    Transform target;

    Vector3 Direction;
    Quaternion rotPlayer;

    void Start()
    {
        //AI movement
        target = GameManager.instance.Player.transform;
    }

    void Update()
    {
        float player = Vector3.Distance(target.position, transform.position);

        if (player < Mine.LookRadius)
        {
            //Smoothening
            Direction = (target.position - transform.position).normalized;
            rotPlayer = Quaternion.LookRotation(Direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotPlayer, TurnSpeed);
        }
    }
}
