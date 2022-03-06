using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogManager : MonoBehaviour
{
    public GameObject[] Dogs; //all dogs that exis
    public GameObject[] GardenAreas; //where dogs can be placed
    public GameObject[] IndoorAreas;
    public GameObject[] KitchenAreas;
    public int maxDogs;

    public float extraTime = 0;
    public float timeNow;

    //check what food and toys have been put out, how much time has elapsed since food, how many dogs are there and where they are in the level,
    //world timer, etc etc

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        WorldTimer();
    }

    void WorldTimer()
    {
        timeNow = Time.realtimeSinceStartup + extraTime;
    }
}
