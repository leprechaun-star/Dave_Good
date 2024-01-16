using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DaveRifle : MonoBehaviour
{
    [Header("Gun Stuff")]
    public float Damage;
    public float FireRate;
    public float Distance;

    private float nextTimeToFire = 0f;

    [Space]

    public bool CanShot;

    [Space]

    public Transform CamPoint;
    public Transform MuzzlePoint;

    [Space]

    public GameObject FireParticle;
    public GameObject HitParticle;

    [Space]

    public PlayerMoevementActions Playercontrolls;
    public InputAction Fire;


    private void Awake()
    {
        Playercontrolls = new PlayerMoevementActions();
    }

    private void OnEnable()
    {
        Fire = Playercontrolls.Player.Fire;
        Fire.Enable();
    }

    private void OnDisable()
    {
        Fire.Disable();
    }

    void Update()
    {
        if (GameManager.instance.RifleCurAmmo <= 0)
        {
            CanShot = false;
        }
        else
        {
            CanShot = true;
        }


        if (Fire.IsPressed() && Time.time >= nextTimeToFire)
        {
            if (CanShot)
            {
                nextTimeToFire = Time.time + 1f / FireRate;

                Shot();
            }
        }
    }


    public void Shot()
    {


        RaycastHit hit;

        GameManager.instance.RifleCurAmmo -= 1;

        if (Physics.Raycast(CamPoint.position, transform.TransformDirection(Vector3.forward), out hit, Distance))
        {
            Debug.DrawRay(CamPoint.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);

            if (hit.collider.gameObject.TryGetComponent(out BetterEnemy hitinfo))
            {
                hitinfo.TakeDamge(Damage);
                Debug.Log(hitinfo.curHp);
            }

            Instantiate(FireParticle, MuzzlePoint.position, Quaternion.identity);
            Instantiate(HitParticle, hit.point, Quaternion.identity);
        }
    }
}

