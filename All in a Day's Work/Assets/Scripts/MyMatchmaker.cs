using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;

public class MyMatchmaker : IMatchmakingCallbacks
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public void OnFriendListUpdate(List<FriendInfo> friends)
    {

    }
    public void OnCreatedRoom()
    {
        Debug.Log("yay");
    }
    public void OnCreateRoomFailed(short shorterror, string error)
    {
        Debug.LogError("close but no cigar - old people");
    }
    public void OnJoinedRoom()
    {
        Debug.Log("alsoyay");
    }
    public void OnJoinRandomFailed(short urheight, string error)
    {
        Debug.LogError("UGHHH - random old people");
    }
    public void OnJoinRoomFailed(short urheight, string error)
    {
        Debug.LogError("UGHHH - maybe old people");
    }
    public void OnLeftRoom()
    {

    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
