using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Introaction : MonoBehaviour
{
    [Header("importent stuff")]
    public LayerMask Door;
    public LayerMask DoorOpened;
    public LayerMask Chest;
    public float range;
    public GameObject PlayerWallet;
    RaycastHit doorcheck;
    RaycastHit checstcheck;
    RaycastHit doornormalcheck;

    [Header("GameObjects")]
    public GameObject DoorManager;
    public GameObject interacttext;
    public GameObject ChestText;
    public GameObject EmptyText;
    public bool IsDoor;

    private PlayerMoevementActions Interaction;
    private InputAction Interact;

    private void Awake()
    {
        Interaction = new PlayerMoevementActions();
    }

    private void OnEnable()
    {
        Interact = Interaction.Player.interact;
        Interaction.Enable();
        Interact.Enable();
    }

    private void OnDisable()
    {
        Interaction.Disable();
        Interact.Disable();
    }

    public void Update()
    {
        //this is for doors
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out doorcheck, range, Door))
        {
            DoorOne();
        }
        else
        {
            interacttext.SetActive(false);
        }

        //Normal Doors
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out doornormalcheck, range, DoorOpened))
        {
            DoorOpen();
        }
        else
        {
            interacttext.SetActive(false);
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out doornormalcheck, range, DoorOpened))
        {
            DoorSecond();
        }
        else
        {
            interacttext.SetActive(false);
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out doornormalcheck, range, DoorOpened))
        {
            Doorthree();
        }
        else
        {
            interacttext.SetActive(false);
        }

        //this is for chest's
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out checstcheck, range, Chest))
        {
            ChestOpen();
        }
        else
        {
            ChestText.SetActive(false);
            EmptyText.SetActive(false);
        }
    }

    public void DoorOne()
    {
        if (DoorManager.GetComponent<UnlockingDoor>().Keyone)
        {
            if (Interact.WasPressedThisFrame())
            {
                DoorManager.GetComponent<UnlockingDoor>().DoorAnimator.SetBool("Open", IsDoor);
                IsDoor = !IsDoor;
                //DoorManager.GetComponent<UnlockingDoor>().Keyone = false;
                GameManager.instance.GetComponent<GameManager>().Score += 10;

            }
            interacttext.SetActive(true);
        }
        else
        {
            interacttext.SetActive(false);
        }
    }
    public void DoorOpen()
    {
        if(DoorManager.GetComponent<NormalDoor>())
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                DoorManager.GetComponent<NormalDoor>().Door.SetActive(false);
                GameManager.instance.GetComponent<GameManager>().Score += 10;

            }
            interacttext.SetActive(true);
        }
        else
        {
            interacttext.SetActive(false);
        }
    }

    public void DoorSecond()
    {
        if (DoorManager.GetComponent<NormalDoor>())
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                DoorManager.GetComponent<NormalDoor>().Doortwo.SetActive(false);
                GameManager.instance.GetComponent<GameManager>().Score += 10;
            }
            interacttext.SetActive(true);
        }
        else
        {
            interacttext.SetActive(false);
        }
    }
    public void Doorthree()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.white);

        if (DoorManager.GetComponent<NormalDoor>())
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                DoorManager.GetComponent<NormalDoor>().Doorthree.SetActive(false);
                GameManager.instance.GetComponent<GameManager>().Score += 10;
            }
            interacttext.SetActive(true);
        }
        else
        {
            interacttext.SetActive(false);
        }
    }

    public void ChestOpen()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.white);

        if (PlayerWallet.GetComponent<Coin_collection>().CoinAmount >= 10)
        {
            ChestText.SetActive(true);
        }
        if (PlayerWallet.GetComponent<Coin_collection>().CoinAmount <= 10)
        {
            EmptyText.SetActive(true);
        }
        else
        {
            ChestText.SetActive(false);
            EmptyText.SetActive(false);
        }
    }
}
