using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Friend_NPC : MonoBehaviour
{
    public enum State
    {
        Idle,
        Roaming,
        Running,
        Scared
    }

    [Header("Friendly AI")]

    NavMeshAgent Self;

    public float RunAwayArea;

    public State _currentMode;

    [Range(0.0f, 360.0f)] public float direction;


    // Start is called before the first frame update
    void Start()
    {
        _currentMode = State.Idle;
        _Idle();
    }

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTrigger(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            _Running();
        }
    }

    public void _Idle()
    {
        _currentMode = State.Idle;
    }

    public void _Roaming()
    {
        _currentMode = State.Roaming;
    }

    public void _Running()
    {
        _currentMode = State.Running;
        Debug.Log("Fart");
    }

    public void _Scared()
    {
        _currentMode = State.Scared;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, RunAwayArea);
    }
}
