using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skills : MonoBehaviour
{
    [Header("player skills")]
    [SerializeField] public GameObject gamemanager;
    [SerializeField] public GameObject PlayerUpdate;
    [SerializeField] public GameObject PlayerBullets;

    [Header("skill tree stuff")]
    [SerializeField] public float speedIncrease;
    [SerializeField] public float JumpIncrease;
    [SerializeField] public int damageIncrease;

    [Header("Buttons")]
    [SerializeField] public Button speed1;
    [SerializeField] public Button speed2;
    [SerializeField] public Button speed3;

    public void SpeedSkillOne()
    {
        if(gamemanager.GetComponent<GameManager>().PPoints >= 1)
        {
            PlayerUpdate.GetComponent<Player>().WalkSpeed += speedIncrease;
            PlayerUpdate.GetComponent<Player>().SprintSpeed += speedIncrease;
            gamemanager.GetComponent<GameManager>().PPoints -= 1;
            speed1.interactable = false;
            speed2.interactable = true;
        }
    }

    public void SpeedSkillTwo()
    {
        if (gamemanager.GetComponent<GameManager>().PPoints >= 2)
        {
            PlayerUpdate.GetComponent<Player>().WalkSpeed += speedIncrease;
            PlayerUpdate.GetComponent<Player>().SprintSpeed += speedIncrease;
            gamemanager.GetComponent<GameManager>().PPoints -= 2;
            speed2.interactable = false;
            speed3.interactable = true;
        }
    }

    public void SpeedSkillThree()
    {
        if (gamemanager.GetComponent<GameManager>().PPoints >= 3)
        {
            PlayerUpdate.GetComponent<Player>().WalkSpeed += speedIncrease;
            PlayerUpdate.GetComponent<Player>().SprintSpeed += speedIncrease;
            gamemanager.GetComponent<GameManager>().PPoints -= 3;
            speed3.interactable = false;
        }
    }

    public void JumpSkill()
    {
        if(gamemanager.GetComponent<GameManager>().PPoints >= 1)
        {
            PlayerUpdate.GetComponent<Player>().Jumpforce += JumpIncrease;
            gamemanager.GetComponent<GameManager>().PPoints -= 1;
        }
    }

    public void DamageSkill()
    {
        PlayerBullets.GetComponent<PlayerBullet>().damage += damageIncrease;
    }
}
