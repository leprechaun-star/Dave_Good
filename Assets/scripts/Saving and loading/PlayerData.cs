using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float currentHealth;
    public int currentAmmo;
    public int CoinCurretnAmount;
    public float[] position;

    public PlayerData(Player player, Pistiol pistol, Coin_collection coin)
    {
        currentHealth = player.curHp;
        currentAmmo = pistol.curAmmo;
        CoinCurretnAmount = coin.CoinAmount;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}
