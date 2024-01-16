using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickupType
{
    Health,
    Ammo
}

public class Pickup : MonoBehaviour
{
    public PickupType type;
    public int Health;
    public int Ammo;

    [Header("Bobbing")]
    public float rotateSpeed;
    public float bobSpeed;
    public float bobHieght;

    private Vector3 startPos;
    private bool bobbingUp;

    void Start()
    {
        //set the start Position
        startPos = transform.position;
    }

    public void Update()
    {
        // rotating
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);

        // bobbing up and down
        Vector3 offset = (bobbingUp == true ? new Vector3(0, bobHieght / 2, 0) : new Vector3(0, -bobHieght / 2, 0));
        transform.position = Vector3.MoveTowards(transform.position, startPos + offset, bobSpeed * Time.deltaTime);

        //are we there yet
        if(transform.position == startPos + offset )
        {
            bobbingUp = !bobbingUp;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        //Health and Ammo
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            GameManager.instance.Score += 10;
            switch (type)
            {
                case PickupType.Health:
                    player.GiveHealth(Health);
                    break;
                case PickupType.Ammo:
                    break;
            }

            Destroy(gameObject);
        }
    }
}
