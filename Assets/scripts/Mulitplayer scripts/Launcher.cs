using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.Rendering.HighDefinition;

public class Launcher : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_InputField roomNameInputField;
    [SerializeField] TMP_Text ErrorText;
    [SerializeField] TMP_Text RoomNameText;

    void Start()
    {
        Debug.Log("connecting to master");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        Debug.Log("Connected to Master server");
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Joined a lobby");
        MenuManager.Instance.OpenMenu("multimenu");
    }

    public void CreateRoom()
    {
        if (string.IsNullOrEmpty(roomNameInputField.text))
        {
            return;
        }
        PhotonNetwork.CreateRoom(roomNameInputField.text);
    }

    public override void OnJoinedRoom()
    {
        MenuManager.Instance.OpenMenu("RooMenu");
        RoomNameText.text = PhotonNetwork.CurrentRoom.Name;
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        MenuManager.Instance.OpenMenu("error");
        ErrorText.text = "Room creation failed: " + message;
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        MenuManager.Instance.OpenMenu("Loading");
    }

    public override void OnLeftRoom()
    {
        MenuManager.Instance.OpenMenu("multimenu");
    }
}
