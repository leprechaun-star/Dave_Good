using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrel : MonoBehaviour
{

    [Header("explotion")]
    [SerializeField] private float Explostionradius;
    [SerializeField] private float Explostionforce;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, Explostionradius);
        foreach (Collider collider in colliders)
        {
            Rigidbody rb = GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(Explostionforce, explosionPos, Explostionradius, 3.0f);
            }
        }
    }
}
