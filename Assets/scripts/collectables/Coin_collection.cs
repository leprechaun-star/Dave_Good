using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class Coin_collection : MonoBehaviour
{

    [Header("Coin")]
    [SerializeField] public int CoinAmount;
    [SerializeField] public TMP_Text AmountOfCoinsText;
    [Header("Amounts that the coin bag give you")]
    [SerializeField] public int GiveCoinAmount;

    public void OnTriggerEnter(Collider other)
    {
        //coin
        if (other.gameObject.tag == "Coin")
        {
            AddCoin();
            Destroy(other.gameObject);
        }
    }

    void Start()
    {
        AmountOfCoinsText.text = CoinAmount.ToString();
        GiveCoinAmount = 15;
    }

    void Update()
    {
        AmountOfCoinsText.text = CoinAmount.ToString();    
    }

    public void AddCoin()
    {
        CoinAmount += GiveCoinAmount;
        GameManager.instance.Score += 5;
        AmountOfCoinsText.text = CoinAmount.ToString();
    }
}
