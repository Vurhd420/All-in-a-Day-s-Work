using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;

public class MyClient : IConnectionCallbacks
{
    private LoadBalancingClient loadBalancingClient;

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

    private void SubscribeToCallbacks()
    {
        this.loadBalancingClient.AddCallbackTarget(this);
    }

    private void UnsubscribeFromCallbacks()
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
    void MyCreateRoom(string roomName, byte maxPlayers)
    {
        EnterRoomParams enterRoomParams = new EnterRoomParams();
        enterRoomParams.RoomName = roomName;
        enterRoomParams.RoomOptions = new RoomOptions();
        enterRoomParams.RoomOptions.MaxPlayers = maxPlayers;
        this.loadBalancingClient.OpCreateRoom(enterRoomParams);

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
        this.loadBalancingClient.AppVersion = "0.5";  // set your app version here

        // "eu" is the European region's token
        if (!this.loadBalancingClient.ConnectToRegionMaster("eu")) // can return false for errors
        {
            // log error
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
        // client is now connected to Photon Master Server and ready to create or join rooms
    }

    // [...]
   
}
