using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pistiol : MonoBehaviour
{
    [Header("objects")]
    [SerializeField] public ObjectPool bulletPool;
    [SerializeField] public Transform Muzzle;

    [Header("Ammo")]
    [SerializeField] public int curAmmo;
    [SerializeField] public int maxAmmo;
    [SerializeField] public bool infiniteAmmo;

    [Header("bullet prop")]
    [SerializeField] public float bulletSpeed;
    [SerializeField] public float fireRate;
    [SerializeField] private float lastFireTime;
    [SerializeField] private bool isPlayer;
    [Space]
    [SerializeField] public float bulletDamage;

    void Start()
    {
        curAmmo = maxAmmo;
    }

    //can we shoot a bullet
    public bool CanShoot()
    {
        if(Time.time - lastFireTime >= fireRate)
        {
            if (curAmmo > 0 || infiniteAmmo == true)
                return true;
        }
        return false;
    }

    public void Shoot()
    {
        lastFireTime = Time.time;
        curAmmo--;

        GameObject bullet = bulletPool.GetObject();

        bullet.transform.position = Muzzle.position;
        bullet.transform.rotation = Muzzle.rotation;

        //set the velocity
        if(isPlayer)
        {
            bullet.GetComponent<Rigidbody>().velocity = (Muzzle.forward+Random.Range(-0.01f, 0.01f) * Muzzle.up + Random.Range(-0.01f, 0.01f) * Muzzle.right).normalized * bulletSpeed;
        }
        else
        {
        bullet.GetComponent<Rigidbody>().velocity = Muzzle.forward * bulletSpeed + (Random.Range(-0.08f, 0.08f) * Muzzle.up + Random.Range(-0.08f, 0.08f) * Muzzle.right)*bulletSpeed;
        }
    }
}
