using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Gunner : MonoBehaviour
{
    public float TurnSpeed;

    public GameObject GunHead;
    public GameObject Cam;
    public GameObject Player;

    public Transform target;
    private Vector2 PlayerMouseInput;
    Vector3 Direction;
    Quaternion rotPlayer;
    float xRot;

    void Update()
    {
        PlayerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        MovePlayerCamera();
        
    }

    public void GunTur()
    {
        //Smoothening
        Direction = (target.position - transform.position).normalized;
        rotPlayer = Quaternion.LookRotation(Direction);
        transform.rotation = Quaternion.Slerp(GunHead.transform.rotation, rotPlayer, TurnSpeed);
    }

    private void MovePlayerCamera()
    {
        xRot -= PlayerMouseInput.y * Player.GetComponent<Player>().Sensitivity;

        transform.Rotate(0f, PlayerMouseInput.x * Player.GetComponent<Player>().Sensitivity, 0f);
        xRot = Mathf.Clamp(xRot, -90f, 90f);
        Cam.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
    }
}
