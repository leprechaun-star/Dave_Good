using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunpickup : MonoBehaviour
{
    [Header("Bobbing")]
    [SerializeField] public float rotateSpeed;
    [SerializeField] public float bobSpeed;
    [SerializeField] public float bobHieght;

    [Header("guns and the hand")]
    [SerializeField] public GameObject ParentObject;
    [SerializeField] public GameObject Gun;

    [SerializeField] public Vector3 startPos;
    private bool bobbingUp;

    private void Update()
    {
        // rotating
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);

        // bobbing up and down
        Vector3 offset = (bobbingUp == true ? new Vector3(0, bobHieght / 2, 0) : new Vector3(0, -bobHieght / 2, 0));
        transform.position = Vector3.MoveTowards(transform.position, startPos + offset, bobSpeed * Time.deltaTime);

        //are we there yet
        if (transform.position == startPos + offset)
        {
            bobbingUp = !bobbingUp;
        }
    }

    public void AddGun()
    {
        Instantiate(Gun.transform, ParentObject.transform.position, ParentObject.transform.rotation, ParentObject.transform);
    }

    public void OnTriggerEnter(Collider other)
    {
        //coin
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Coin Collected!!!");
            AddGun();
            Destroy(other.gameObject);
        }
    }

}
