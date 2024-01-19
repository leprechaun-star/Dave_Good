using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotoQuest : MonoBehaviour
{

    public GameObject Player;

    public float Distance;

    public GameObject Point;


    public bool Questings;

    private void Awake()
    {
        Questings = false;
    }

    public void Update()
    {
        GameManager.instance.Player = Player.gameObject;

        Distance = Vector3.Distance(Player.transform.position, Point.transform.position);

        if(Questings)
        {
            QuestBase.instance.QuestInfo.text = Distance.ToString("F2");
        }
    }

    public void StartQuest()
    {
        QuestBase.instance.QuestName.text = "Go To Quest Test";
        Questings = true;
    }
}
