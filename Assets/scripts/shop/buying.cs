using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class buying : MonoBehaviour
{
    [Header("Shop UI and costings")]
    [SerializeField] public GameObject Wallet;
    [SerializeField] public GameObject ParentHand;
    [Header("Weapon Objects")]
    [SerializeField] public GameObject Gun1;
    [Header("Buttons to disable")]
    [SerializeField] public Button ButtonGun1;

    public void BuyAmmo()
    {
        if (GameManager.instance.CoinAmount >= 5)
        {
            GameManager.instance.CoinAmount -= 5;
            GameManager.instance.PistolAmmoBag += 10;
        }
        else
        {
            return;
        }
    }

    public void BuyGun()
    {
        if(GameManager.instance.CoinAmount >= 5)
        {
            GameManager.instance.CoinAmount -= 5;
            Instantiate(Gun1.transform, ParentHand.transform.position, ParentHand.transform.rotation, ParentHand.transform);
            ButtonGun1.enabled = false;
        }

        else
        {
            return;
        }
    }
}
