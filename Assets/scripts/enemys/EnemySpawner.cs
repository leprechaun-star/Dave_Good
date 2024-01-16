using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Object")]
    [SerializeField] public GameObject EnemyPrefab;
    [SerializeField] public float TimerLength;
    [SerializeField] public float Timer = 1f;
    [SerializeField] public float EnemySPRadius;
    [Header("Playerstuff")]
    [SerializeField] public float playerEnter;
    
    Transform Dave;


    public void Start()
    {
        SpawnEnemy();

        Dave = GameManager.instance.Player.transform;
    }

    public void FixedUpdate()
    {
        float enemyin = Vector3.Distance(transform.position, transform.position);
        float playerdistance = Vector3.Distance(Dave.position, transform.position);

        if (Timer <= 0.0f)
        {
            if (playerdistance <= playerEnter)
            {
                if (Physics.CheckSphere(transform.position, EnemySPRadius))
                {
                    return;
                }
                else
                {
                    SpawnEnemy();
                    Timer = TimerLength;
                }
            }
        }

        Timer -= Time.deltaTime;
    }

    public void SpawnEnemy()
    {
        Instantiate(EnemyPrefab.transform, transform.position, transform.rotation, transform.transform);
    }
    
    //public void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, EnemySPRadius);
    //
    //    Gizmos.color = Color.blue;
    //    Gizmos.DrawWireSphere(transform.position, playerEnter);
    //}
}