using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BetterEnemy : MonoBehaviour
{
    private enum State
    {
        Idle,
        Chasing,
        Attacking,
        Looking,
    }

    private State _currentState;


    [Header("Enemy LookRadius")]
    [SerializeField] public float HealthBarRadius = 15f;
    [SerializeField] public float LookRadius = 10f;
    [SerializeField] public float FireRadius = 5f;

    [Header("Enemy Health")]
    [SerializeField] public float curHp;
    [SerializeField] public float maxHp;
    [SerializeField] public Slider HealthBar;
    [SerializeField] public GameObject CanBar;

    [Header("Enemy Hands")]
    [SerializeField] public GameObject Hands;
    [Header("its gonna be like 0.05 or something")]
    [SerializeField] public float TurnSpeed;

    [Header("Quest")]
    [SerializeField] public GameObject UIplayer;

    Pistiol weapon;

    Transform target;
    NavMeshAgent agent;
    Vector3 Direction;
    Quaternion rotPlayer;


    private void Awake()
    {
        _currentState = State.Idle;
    }

    void Start()
    {
        //get the components
        weapon = GetComponent<Pistiol>();

        //AI movement
        target = GameManager.instance.Player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        _Idle();

        float player = Vector3.Distance(target.position, transform.position);

        CanBar.transform.LookAt(target);

        HealthBar.value = curHp;

        if (player < LookRadius)
        {
            //Smoothening
            Direction = (target.position - transform.position).normalized;
            rotPlayer = Quaternion.LookRotation(Direction);
            transform.rotation = Quaternion.Slerp(Hands.transform.rotation, rotPlayer, TurnSpeed); 
            
        }

        if(player < HealthBarRadius)
        {
            CanBar.SetActive(true);
        }
        else
        {
            CanBar.SetActive(false);
        }
    }

    public void TakeDamge(float damage)
    {
        curHp -= damage;

        if (curHp <= 0)
        {
            Die();           
        }
    }
    void Die()
    {
        GameManager.instance.Score += 20;
        GameManager.instance.CoinAmount += 5;
        //GameManager.instance.Quest.GetComponent<QuestBase>().EnemyNum += 1;
        
        Destroy(gameObject);
    }

    //AI States
    private void _Idle()
    {
        float distance = Vector3.Distance(target.position, transform.position);

            if (_currentState == State.Idle)
            {

                if (distance <= LookRadius)
                {
                    _Chasing();
                }
            }
    }

    void _Chasing()
    {
        agent.SetDestination(target.position);

        float distance = Vector3.Distance(target.position, transform.position);

        //Chasing the player
        if (distance <= FireRadius)
        {
            _Attacking();
        }

        if (distance <= LookRadius)
        {
            _Looking();
        }
    }

    private void _Attacking()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        //shooting the player when in this state
        weapon.Shoot();
        if (distance >= FireRadius)
        {
            _Chasing();
        }
    }

    private void _Looking()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        //Looking for the player after the player leaves its viewing distances
        //agent.SetDestination(target.position);
        agent.SetDestination(target.gameObject.transform.position);
        if (LookRadius <= distance)
        {
            _Idle();
        }

    }

    //casting the spheres in editor and game
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, LookRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, FireRadius);
    }
}
