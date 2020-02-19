using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    public GameObject[] waypoints;
    int current = 0; //states which waypoint the object is moving towards
    public float speed; // determines speed of gameobject
    float WPradius = 1; //prevents gameobject from missing the waypoint

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime); // rotates yellow blocks
   
        // checks distance between waypoint and position of the gameobject
        if (Vector3.Distance(waypoints[current].transform.position, transform.position) < WPradius)
        {
            current++; // adds 1
            if (current >= waypoints.Length) // checks if int value of current is larger than value of gameobject
            {
                current = 0; //returns to start, loops
            }
        }
        // moves object to waypoint's position in the world
        transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
    }
}
