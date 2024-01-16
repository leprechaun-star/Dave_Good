using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerGun : MonoBehaviour
{
    [Header("Gun Proamators")]
    [SerializeField] public float GunRange;

    [Header("player object")]
    [SerializeField] public GameObject Player;
    RaycastHit hit;

    // Update is called once per frame
    public void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, GunRange))
        {
            Debug.DrawLine(ray.origin, hit.point);
        }
    }

    public void Gun()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            Debug.DrawRay(ray.origin, hit.point);
        }
        /*if (Input.GetButtonDown("Fire1"))
        {
            
            if(CompareTag("Enemy"))
            {
                Player.GetComponent<BetterEnemy>().curHp -= 10;
            }
        }*/
    }

    void OnDrawGizmos()
    {
        //Gizmos.color = Color.yellow;
        //Gizmos.DrawLine()
    }
}
