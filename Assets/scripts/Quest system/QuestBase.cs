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
