using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
public class MyClient : IConnectionCallbacks
{
    private LoadBalancingClient loadBalancingClient;
    public GameObject CreateRoom;

    public MyClient()
    {
        this.loadBalancingClient = new LoadBalancingClient();
        this.SubscribeToCallbacks();
    }

    ~MyClient()
    {
        this.Disconnect();
        this.UnsubscribeFromCallbacks();
    }

    public void SubscribeToCallbacks()
    {
        this.loadBalancingClient.AddCallbackTarget(this);
    }

    public void UnsubscribeFromCallbacks()
    {
        this.loadBalancingClient.RemoveCallbackTarget(this);
    }

    void Disconnect()
    {
        if (this.loadBalancingClient.IsConnected)
        {
            this.loadBalancingClient.Disconnect();
        }
    }
    public void MyCreateRoom(string roomName, byte maxPlayers)
    {
        EnterRoomParams enterRoomParams = new EnterRoomParams();
        enterRoomParams.RoomName = roomName;
        enterRoomParams.RoomOptions = new RoomOptions();
        enterRoomParams.RoomOptions.MaxPlayers = maxPlayers;
        PhotonNetwork.CreateRoom(roomName, enterRoomParams.RoomOptions, TypedLobby.Default);
    }

    void IConnectionCallbacks.OnConnected()
    {

    }
    void IConnectionCallbacks.OnDisconnected(DisconnectCause cause)
    {

    }
    // call this to connect to Photon
    public void Connect()
    {
        this.loadBalancingClient.AppId = "<a9cb2597-69ea-4044-b13d-c7d55d24ed1f>";  // set your app id here
        this.loadBalancingClient.AppVersion = "0.6";  // set your app version here
        Debug.Log("connecting");
        
        // "eu" is the European region's token
        if (!this.loadBalancingClient.ConnectToRegionMaster("us")) // can return false for errors
        {
            Debug.LogError("?");
        }
    }
    void IConnectionCallbacks.OnRegionListReceived(RegionHandler regionHandler)
    {

    }
    void IConnectionCallbacks.OnCustomAuthenticationFailed(string debugMessage)
    {
        Debug.Log(debugMessage);
    }
    void IConnectionCallbacks.OnCustomAuthenticationResponse(Dictionary<string, object> data)
    {

    }
    void IConnectionCallbacks.OnConnectedToMaster() 
    {
        CreateRoom.GetComponent<RoomUI>().OnConnectedToMaster();
        Debug.Log("ConnectedToMAster");
    }

    // [...]
   
}
