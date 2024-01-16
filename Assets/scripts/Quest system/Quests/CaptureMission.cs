using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CaptureMission : MonoBehaviour
{
    [Header("Mission Info")]
    public bool isActive;
    public bool canDo;

    public float Area;

    public string QName;
    public string QInfo;

    public TMP_Text QNameText;
    public TMP_Text QInfoText;

    void FixedUpdate()
    {
        if (isActive)
        {
            QNameText.text = QName;
            QInfoText.text = QInfo;
        }
        else
        {

        }
    }

    public void CapQuest()
    {
        if (canDo)
        {
            isActive = !isActive;
        }
    }
}
