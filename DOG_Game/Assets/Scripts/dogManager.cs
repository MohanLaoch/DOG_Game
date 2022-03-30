using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class dogManager : MonoBehaviour
{
    public GameObject[] Strays; //all dogs at the beginning
    public GameObject[] Adopted; //all dogs that have been adopted in the game so far
    public GameObject[] GardenAreas; //where dogs can be placed
    public GameObject[] KitchenAreas;
    public GameObject[] BedroomAreas;
    public int maxDogs;
    public bool maxReached = false;

    public GameObject timeDisplay;
    public int hour;
    public int mins;
    public int seconds;

    public int currency1; //snacks and whatnot
    public int currency2;

    //check what food and toys have been put out, how many dogs are there and where they are in the level,
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
