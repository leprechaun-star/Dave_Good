using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Clock : MonoBehaviour
{
    [Header("clock")]
    [SerializeField] public float clock;
    [SerializeField] public TMP_Text clocktext;

    void Start()
    {
        clocktext.text = clock.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        clocktext.text = clock.ToString();

        clock = Time.deltaTime;
    }
}
