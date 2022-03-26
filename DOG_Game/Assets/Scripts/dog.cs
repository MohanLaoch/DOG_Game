using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class dog : MonoBehaviour
{
    public string dogName;
    public GameObject inputField;
    public GameObject namingCanvas;
    public GameObject name;

    public int maxHappiness = 100;
    public float currentHappiness;

    public HappinessBar happinessBar;
    private Slider hslider;
    public GameObject treasureObj;

    //public string favToy;
    //public string favFood;

    public int treasureChance;
    public string[] allTreasure;
    public string currentTreasure;
    private int index;

    public bool stray;
    public bool adoptable;
    public GameObject adoptUI;

    public int apptime; //time since start of thingy

    public float treasureTimer = 0.0f;
    public float treasureTime; //wait time
    public bool hasTreasure;

    [Header("Timer Information")]
    public float foodTime; //wait time

    public float petTimer = 0.0f;
    public float petTime; //wait time
    public bool canBePet = true;

    public float happinessTimer = 0.0f;
    public float happinessTime; //wait time
    public bool happinessDown;

    public float baseHT;

    public int XP = 0;
    public int Level = 1;

    public string[] barkArray = { "bark1", "bark2", "bark3", "bark4" };


    public void Start()
    {
        hslider = GetComponentInChildren<Slider>();
        treasureObj = transform.Find("Treasure").gameObject;

        // Sets happiness at the beginning of the scene
        currentHappiness = (int)hslider.value;
        happinessBar.SetMaxHappiness(maxHappiness);
    }

    public void Update()
    {
        if (currentHappiness > maxHappiness)
        {
            currentHappiness = maxHappiness;
        }
        else if (currentHappiness < 0)
        {
            currentHappiness = 0;
        }

        Timers();

    }

    void FixedUpdate()
    {
        happinessBar.SetHappiness(currentHappiness);
      //apptime = (int)GameObject.Find("DogManager").GetComponent<dogManager>().timeNow;
        ManageHappiness();

    }

    void ManageHappiness()
    {
        if (happinessDown)
        {
            currentHappiness = currentHappiness - 1;
            happinessDown = false;
        }

    }

    public void ManageStray()
    {
        bool maxdogs = GameObject.Find("DogManager").GetComponent<dogManager>().maxReached;

        if (stray)
        {
            if (currentHappiness >= 50)
            {
                adoptable = true;
            }
        }
        else if (!stray)
        {
            if (currentHappiness <= 15)
            {
                RunAway();
            }
        }

        if(adoptable && !maxdogs)
        {
            SetName();
        }
    }


    void ManageLevel(int XPgain)
    {
        XP = XP + XPgain;

        if (XP == 1000 * Level && Level != 5)
        {
            Level++;
            maxHappiness = maxHappiness * Level / 2;
            XP = 0;
        }
    }

    void Timers()
    {
        treasureTimer += Time.deltaTime;
        petTimer += Time.deltaTime;
        happinessTimer += Time.deltaTime;

        if (treasureTimer > treasureTime)
        {
            treasureTimer = treasureTimer - treasureTime;
            hasTreasure = true;
            treasureObj.SetActive(true);
        }

        if (petTimer > petTime)
        {
            petTimer = petTimer - petTime;
            canBePet = true;
        }

        if (happinessTimer > happinessTime)
        {
            happinessTimer = happinessTimer - happinessTime;
            happinessDown = true;
        }
    }

    public void GetPet()
    {
        Debug.Log("gotpet");

        if (canBePet)
        {
            Debug.Log("gothappiness");
            currentHappiness += 10;
            canBePet = false;

            ManageLevel(15);
        }

        FindObjectOfType<AudioManager>().Play(barkArray[Random.Range(0, barkArray.Length)]);
    }

    public void GetTreasure()
    {

        index = Random.Range(0, allTreasure.Length);
        currentTreasure = allTreasure[index];

        if (hasTreasure)
        {
            Debug.Log("got Treasure");
            hasTreasure = false;
            treasureObj.SetActive(false);

            ManageLevel(50);

            FindObjectOfType<AudioManager>().Play("bell");

        }
    }

    public void SetName()
    {
        dogName = inputField.GetComponent<Text>().text;
        stray = false;
        name.SetActive(true);
        namingCanvas.SetActive(false);
    }

    public void RunAway() //unfinished
    {
        dogName = "";
        stray = true;
        name.SetActive(false);
    }
}


