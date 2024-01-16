using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] public Slider HealthBarSlider;
    [SerializeField] public TMP_Text AmmoText;

    void Update()
    {
        HealthBarSlider.value = GameManager.instance.MainPlayer.GetComponent<Player>().curHp;

        AmmoText.text = GameManager.instance.PistolCurAmmo.ToString() + "/" + GameManager.instance.PistolAmmoBag.ToString();
    }
}
