using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public int damage;
    public float lifetime;
    private float fireTime;

    private void OnEnable()
    {
        fireTime = Time.time;
    }

    void Update()
    {
        //disable the bullet
        if(Time.time - fireTime >= lifetime)
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // did we hit the player???
        if (other.CompareTag("Enemy"))
            other.GetComponent<BetterEnemy>().TakeDamge(damage);
        else if (other.CompareTag("Untagged"))
            gameObject.SetActive(false);
        else if (other.CompareTag("Bullet"))
            gameObject.SetActive(true);
        else if (other.CompareTag("Turret"))
            other.GetComponent<Killswitch>().KillSwitch(damage);
        else if (other.CompareTag("Border"))
            gameObject.SetActive(gameObject);


        //disable the bullet
        gameObject.SetActive(false);
    }
}
