using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyOne : MonoBehaviour
{
    [Header("Door information")]
    [SerializeField] public GameObject Door;
    [SerializeField] public GameObject questGame;

    void OnTriggerEnter(Collider Key)
    {

            if (Key.CompareTag("Player"))
            {
                Door.GetComponent<UnlockingDoor>().Keyone = true;
                //questGame.GetComponent<QuestBase>().KeyNum += 1;
                Destroy(gameObject);
            }
    }
}
