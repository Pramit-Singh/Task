using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonManagerScript : MonoBehaviourPunCallbacks
{
    public GameObject player;
    public GameObject canvas;

    void Start()
    {
        canvas.SetActive(true);
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void Connect()
    {
        if (PhotonNetwork.IsConnected)
        {
            Debug.Log("Connect");
            PhotonNetwork.JoinRoom("TestRoom1");
        }
        else
        {
            print("FAiled");
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster()
    {
        print("Connected To master");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        print("Lobby");

        RoomOptions newRoomOptions = new RoomOptions();
        newRoomOptions.IsOpen = true;
        newRoomOptions.IsVisible = true;
        newRoomOptions.MaxPlayers = 2;

        PhotonNetwork.JoinOrCreateRoom("TestRoom1", newRoomOptions, TypedLobby.Default);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        print(message);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Room Joined" + PhotonNetwork.PlayerList.Length);

        PhotonNetwork.Instantiate("player",new Vector3(Random.Range(-5,5),1,0), Quaternion.identity);
        canvas.SetActive(false);
    }

}
