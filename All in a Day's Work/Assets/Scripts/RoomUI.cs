using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Photon.Pun;
using System.Dynamic;
using JetBrains.Annotations;
using System;

public class RoomUI : MonoBehaviour
{
    public byte roomamount = 4;
    public Button CreateRoom;
    public Button JoinRoom;
    public MyClient MyClient = new MyClient();
    public string appId = "a9cb2597-69ea-4044-b13d-c7d55d24ed1f";
    bool buttonpressed;
    // true is create false is join
    public string roomname = "1111";
    public InputField JoinInput;
    public bool inputdone;
    public bool roomfull;
    public GameObject JoinGameInput;
    public GameObject roomnameobject;
    // Start is called before the first frame update
    void Start()
    {
        // finding and adding TaskOnClickCreate to the CreateButton
        CreateRoom = GameObject.Find("CreateRoom").GetComponent<Button>();
        CreateRoom.onClick.AddListener(delegate () { StartCoroutine(TaskOnClickCreate("urdumb")); });
        // finding and adding TaskOnClickJoin to the JoinButton
        JoinRoom = GameObject.Find("JoinRoom").GetComponent<Button>();
        JoinRoom.onClick.AddListener(delegate () { StartCoroutine(TaskOnClickJoin("JoinRoom")); });
        PhotonNetwork.ConnectUsingSettings();
        JoinInput.onEndEdit.AddListener(OnInputEnd);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnConnectedToMaster()
    {
        Debug.Log("cool");
        if (buttonpressed)
        {
            MyClient.MyCreateRoom(roomname, roomamount);
        }
        else
        {
            
            PhotonNetwork.JoinRoom(roomname);
            Debug.Log("roomjoinedithink");
        }
        
    }
    IEnumerator TaskOnClickCreate(string debug)
    {
        Debug.Log(debug);
        GameObject.Find("CreateRoom").SetActive(false);
        roomnameobject.SetActive(true);
        roomname = UnityEngine.Random.Range(1000, 9999).ToString();
        roomnameobject.GetComponent<Text>().text = roomname;
        buttonpressed = true;
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.JoinLobby();
        yield return new WaitForSeconds(10f);
        //yield return new WaitUntil(() => roomfull);
        GameObject.Find("RoomUI").SetActive(false);
        Debug.Log("roomcreatedithink");
       
       

        //Random.Range(1000, 9999)
    }
    IEnumerator TaskOnClickJoin(string debug)
    {
        Debug.Log(debug);
        JoinGameInput.SetActive(true);
        GameObject.Find("JoinRoom").SetActive(false);
        yield return new WaitWhile(() => !inputdone);
        
        GameObject.Find("RoomUI").SetActive(false);
        buttonpressed = false;
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.JoinLobby();
        

        
    }

   
    public void OnInputEnd(string input)
    {
        inputdone = true;
        Debug.Log(input);
        roomname = input;

    }

}
