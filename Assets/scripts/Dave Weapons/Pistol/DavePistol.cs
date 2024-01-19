using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DavePistol : MonoBehaviour
{
    [Header("Gun Stuff")]
    public float Damage;
    public float Distance;
    public float ReloadTime;
    public int AddAmount;

    [Space]

    public Animator ReloadAnim;
    public Animator ShotAnim;

    [Space]
    
    public bool CanShot;
    public bool CanReload;
    public bool isReloading;
    
    [Space]
    
    public Transform CamPoint;
    public Transform MuzzlePoint;

    [Space]

    public AudioSource ReloadSound;
    public AudioSource HitSound;

    [Space]

    public GameObject FireParticle;
    public GameObject HitParticle;
    public GameObject HitPoint;
    
    [Space]

    private PlayerMoevementActions Playercontrolls;
    private InputAction Fire;
    private InputAction Reload;


    private void Awake()
    {
        Playercontrolls = new PlayerMoevementActions();
    }

    private void OnEnable()
    {
        Fire = Playercontrolls.Player.Fire;
        Reload = Playercontrolls.Player.Reload;
        Fire.Enable();
        Reload.Enable();
    }

    private void OnDisable()
    {
        Fire.Disable();
        Reload.Disable();
    }

    void Update()
    {
        if (GameManager.instance.PistolAmmoBag < GameManager.instance.PistolMaxMag)
        {
            AddAmount = GameManager.instance.PistolAmmoBag;
        }
        else
        {
            AddAmount = (GameManager.instance.PistolMaxMag - GameManager.instance.PistolCurAmmo);
        }

        if (isReloading)
            return;

        if (GameManager.instance.PistolCurAmmo <= 0)
        {
            if (CanReload)
            {
                StartCoroutine(Reloading());
                return;
            }
            else
            {
                CanShot = false;
            }

            if(GameManager.instance.PistolAmmoBag >= 10)
            {
                if (Reload.WasPressedThisFrame())
                {
                    StartCoroutine(Reloading());
                }
            }
            
            CanShot = false;
        }
        else if(GameManager.instance.PistolAmmoBag <= 0)
        {
            CanReload = false;
        }
        else
        {
            CanShot = true;
            CanReload = true;
        }

        if(GameManager.instance.PistolCurAmmo < GameManager.instance.PistolMaxMag)
        {
            if (Reload.WasPressedThisFrame())
            {
                StartCoroutine(Reloading());
            }
        }

        if (Fire.WasPressedThisFrame())
        {
            if(CanShot)
            {
                Shot();
            }
        }
    }

    IEnumerator Reloading()
    {
        isReloading = true;
        CanShot = false;
        ReloadAnim.SetBool("Reloading", true);
        ReloadSound.Play();
        yield return new WaitForSeconds(ReloadTime);
        GameManager.instance.PistolCurAmmo += AddAmount;
        GameManager.instance.PistolAmmoBag -= AddAmount;
        ReloadAnim.SetBool("Reloading", false);
        CanShot = true;
        isReloading = false;
    }

    public void Shot()
    {
        RaycastHit hit;

        GameManager.instance.PistolCurAmmo--;

        ShotAnim.Play("PistolShot");

        Instantiate(FireParticle, MuzzlePoint.position, MuzzlePoint.rotation);

        if (Physics.Raycast(CamPoint.position, transform.TransformDirection(Vector3.forward), out hit, Distance))
        {
            if(hit.collider.gameObject.TryGetComponent(out BetterEnemy hitinfo))
            {
                hitinfo.TakeDamge(Damage);
            }

            Instantiate(HitPoint, hit.point, Quaternion.identity);
            Instantiate(HitParticle, hit.point, Quaternion.identity);
        }
    }
}
