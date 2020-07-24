using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playervar : MonoBehaviour
{
    public float offx;
    public float offy;
    public int location;
    public GameObject[] waypoints;
    public Vector2 offlocation;
    public Vector2 cposition;
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        location = 0;
        cposition = transform.position;
        offx = transform.position.x - waypoints[location].transform.position.x;
        offy = transform.position.y - waypoints[location].transform.position.y;
    }
    public 
    // Update is called once per frame
    void Update()
    {

        offlocation = new Vector2(waypoints[location].transform.position.x, waypoints[location].transform.position.y)  + new Vector2(offx, offy); 
        if ((transform.position.x != waypoints[location].transform.position.x + offx) && (transform.position.y != waypoints[location].transform.position.y + offy))    
        {

            cposition = Vector2.MoveTowards(cposition, offlocation, speed * Time.deltaTime);
            transform.position = new Vector3(cposition.x, cposition.y, transform.position.z);

        }
    }
}
