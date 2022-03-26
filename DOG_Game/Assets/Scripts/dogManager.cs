using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class dogManager : MonoBehaviour
{
    public GameObject[] Dogs; //all dogs that exis
    public GameObject[] GardenAreas; //where dogs can be placed
    public GameObject[] KitchenAreas;
    public GameObject[] BedroomAreas;
    public int maxDogs;
    public bool maxReached = false;

    public GameObject timeDisplay;
    public int hour;
    public int mins;
    public int seconds;

    public int currency1;
    public int currency2;

    //check what food and toys have been put out, how much time has elapsed since food, how many dogs are there and where they are in the level,
    //world timer, etc etc

    void Start()
    {
        FindObjectOfType<AudioManager>().Play("bckgmusic");
    }

    void FixedUpdate()
    {
        DisplayTime();

    }

    void DisplayTime()
    {
        hour = System.DateTime.Now.Hour;
        mins = System.DateTime.Now.Minute;
        seconds = System.DateTime.Now.Second;
        timeDisplay.GetComponent<Text>().text = hour + ":" + mins + ":" + seconds;
    }
}
