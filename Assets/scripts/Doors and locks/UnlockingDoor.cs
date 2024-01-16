using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockingDoor : MonoBehaviour
{
    [Header("Keys and the Door")]
    [SerializeField] public bool Keyone;
    [SerializeField] public bool KeyTwo;
    [SerializeField] public GameObject Door;

    [Header("Animation")]
    [SerializeField] public Animator DoorAnimator;
    [SerializeField] public string Animation;

    
}
