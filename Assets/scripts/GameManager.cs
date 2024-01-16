using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Player states and other")]
    [SerializeField] public int Score;
    [SerializeField] public int Level;
    [SerializeField] public int PPoints;
    [SerializeField] public float ScoreNeeded;

    [Space]

    [Header("HUB")]
    public TMP_Text PlayerLevel;
    public TMP_Text PlayerPoints;
    public Slider XpBar;

    [Space]

    [Header("Ammo For Player")]
    public int PistolAmmoBag;
    public int PistolMaxMag;
    public int PistolCurAmmo;

    public int RifleMaxAmmo;
    public int RifleCurAmmo;

    [Space]

    [Header("Coin")]
    [SerializeField] public int CoinAmount;
    [SerializeField] public TMP_Text AmountOfCoinsText;

    [Space]
    [Space]

    public GameObject Player;
    public GameObject MainPlayer;
    public GameObject Quest;

    public static GameManager instance;


    public void Update()
    {
        AmountOfCoinsText.text = CoinAmount.ToString();

        XpBar.value = Score;

        PlayerPoints.text = PPoints.ToString();
        PlayerLevel.text = Level.ToString();

        if (PistolAmmoBag <= 0)
        {
            PistolAmmoBag = 0;
        }

        if (Score >= ScoreNeeded)
        {
            Score = 0;
            Level += 1;
            PPoints += 1;
            ScoreNeeded += 20.005f;
            XpBar.maxValue = ScoreNeeded;
        }
    }

    void Awake ()
    {
        //set the instance to this script
        instance = this;
    }
}
