using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class shpere : MonoBehaviour
{
    [Header("sphere stuff")]
    public float sphereradius;
    public float power;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, sphereradius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, sphereradius, 3.0F);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sphereradius);

        //draw random shit
        //Gizmos.color = Color.red;
    }
}
