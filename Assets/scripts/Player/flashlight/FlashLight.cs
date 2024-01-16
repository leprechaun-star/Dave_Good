using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField] public Light flashLight;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            flashLight.enabled = true;
        }
        else
        {
            flashLight.enabled = false;
        }

    }
}
