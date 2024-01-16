using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickUp : MonoBehaviour
{
    [Header("Bobbing")]
    public float rotateSpeed;
    public float bobSpeed;
    public float bobHieght;

    public Vector3 startPos;
    private bool bobbingUp;

    void Update()
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
    
}
