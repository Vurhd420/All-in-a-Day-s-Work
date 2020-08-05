using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class RoomUIoff : MonoBehaviourPunCallbacks
{
    public int roomamount = 4;
    public Button CreateRoom;
    public IConnectionCallbacks MyClient;
    // Start is called before the first frame update
    void Start()
    {
        CreateRoom = GameObject.Find("CreateRoom").GetComponent<Button>();
        CreateRoom.onClick.AddListener(delegate(){ TaskOnClick("urdumb"); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    void TaskOnClick(string debug)
    {
        Debug.Log(debug);
        GameObject.Find("RoomUI").SetActive(false);
    }
}
