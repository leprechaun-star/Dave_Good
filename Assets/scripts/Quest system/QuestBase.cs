using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestBase : MonoBehaviour
{
    [Header("Quest Base")]
    public TMP_Text QuestName;
    public TMP_Text QuestInfo;
    public bool DoingQuest;

    public static QuestBase instance;

    void Awake()
    {
        //set the instance to this script
        instance = this;
    }

    void Update()
    {
        if (QuestName.text == null)
        {
            DoingQuest = false;
        }
        else
        {
            DoingQuest = true;
        }
    }
}
