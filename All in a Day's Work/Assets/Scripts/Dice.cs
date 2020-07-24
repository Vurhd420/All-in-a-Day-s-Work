using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour
{

    public Sprite[] diceSides;
    private SpriteRenderer rend;
    public int whosTurn = 0;
    public bool coroutineAllowed = true;
    public GameObject[] players;
    public int randomDiceSide;
    public int elsecount = 0;
    public GameObject[] waypoints;
    public bool[] playeraff;
    public int moveamount;
    public int f;
    // Use this for initialization
    private void Start()
    {
        waypoints = players[0].GetComponent<Playerscript1>().waypoints;
        
        Debug.Log(waypoints.Length);
        rend = GetComponent<SpriteRenderer>();
        playeraff = waypoints[players[0].GetComponent<Playerscript1>().location].GetComponent<Waypointvar>().player;
        rend.sprite = diceSides[5];
       
    }
    private void OnMouseDown()
    {
        if (coroutineAllowed)
            StartCoroutine("RollTheDice");
    }

    private IEnumerator RollTheDice()
    {
        coroutineAllowed = false;
        randomDiceSide = 0;
        for (int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(0, 6);
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
        }
        players[whosTurn].GetComponent<Playerscript1>().move = true;
        players[whosTurn].GetComponent<Playerscript1>().location += 1;
        players[whosTurn].GetComponent<Playerscript1>().movedistance = randomDiceSide;


    }
    public void DoneMoving(int whosmoving)
    {
        if (players[whosmoving].GetComponent<Playerscript1>().movedistance != 0)
        {
            players[whosmoving].GetComponent<Playerscript1>().location += 1;
            if (players[whosmoving].GetComponent<Playerscript1>().movedistance > 0)
            {
                players[whosmoving].GetComponent<Playerscript1>().movedistance--;
            }
            else
            {
                players[whosmoving].GetComponent<Playerscript1>().movedistance++;
            }
        }
       else
        {

            players[whosmoving].GetComponent<Playerscript1>().move = false;
            coroutineAllowed = true;
            if (whosTurn == whosmoving)
            {
                whosTurn = ((whosTurn + 1) % 4);
            }
            BoardCheck(whosmoving);
            
        }

    }
    public void BoardCheck(int whosdone)
    {
        Debug.Log(whosdone);
        Debug.Log(waypoints[players[whosdone].GetComponent<Playerscript1>().location]);
        playeraff = waypoints[players[whosdone].GetComponent<Playerscript1>().location].GetComponent<Waypointvar>().player;
        moveamount = waypoints[players[whosdone].GetComponent<Playerscript1>().location].GetComponent<Waypointvar>().move;
        if (playeraff[0])
        {
            players[whosdone].GetComponent<Playerscript1>().move = true;
            if (moveamount > 0)
            {
                players[whosdone].GetComponent<Playerscript1>().location++;
            }
            else
            {
                players[whosdone].GetComponent<Playerscript1>().location--;
            }
            players[whosdone].GetComponent<Playerscript1>().movedistance = CloserTo0(moveamount);
        }
        else
        {
            for (int i = 1; i < playeraff.Length; i++)
            {
                players[i - 1].GetComponent<Playerscript1>().move = playeraff[i];
                if (playeraff[i])
                {
                    players[i - 1].GetComponent<Playerscript1>().movedistance = CloserTo0(moveamount);
                    if (moveamount > 0)
                    {
                        players[i - 1].GetComponent<Playerscript1>().location++;
                    }
                    else
                    {
                        players[i - 1].GetComponent<Playerscript1>().location--;
                    }
                }
            }
            Debug.Log("adrianbad");
        }
        
    }
    public int CloserTo0(int i)
    {
        if (i > 0)
        {
            return i - 1;
        }
        else if (i < 0)
        {
            return i + 1;
        }
        else
        {
            return 0;
        }
    }
    private void Update()
    {
        
        
    }
}
