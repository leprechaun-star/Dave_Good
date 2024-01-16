using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEmeies : MonoBehaviour
{
    [Header("Kill enemy quest")]
    public GameObject QuestBase;
    public string QuestName;
    public string QuestInfo;

    void Update()
    {
        if(QuestBase.GetComponent<QuestBase>().DoingQuest)
        {
            QuestBase.GetComponent<QuestBase>().QuestName.text = QuestName;
            QuestBase.GetComponent<QuestBase>().QuestInfo.text = QuestInfo;
        }
    }
}
