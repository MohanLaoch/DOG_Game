using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class dog : MonoBehaviour
{
    public string dogName;
    public GameObject inputField;
    public GameObject namingCanvas;
    public GameObject name;
    public GameObject adoptButton;

    public int maxHappiness = 100;
    public float currentHappiness;

    [HideInInspector] public HappinessBar happinessBar;
    [HideInInspector] private Slider hslider;
    [HideInInspector] public GameObject treasureObj;

    public int treasureChance;
    public string[] allTreasure;
    public string currentTreasure;
    private int index;

    public bool stray;
    public bool adoptable;
    //public GameObject adoptUI;

    public int XP = 0;
    public int Level = 1;

    private string[] barkArray = { "bark1", "bark2", "bark3", "bark4" };

    [Header("Timer Information")]

    public int apptime; //time since start of thingy

    private float treasureTimer = 0.0f;
    public float treasureTime; //wait time
    private bool hasTreasure;

    private float foodTimer; 
    public float foodTime; //wait time
    private bool hungry;

    private float petTimer = 0.0f;
    public float petTime; //wait time
    private bool canBePet = true;

    private float happinessTimer = 0.0f;
    public float happinessTime; //wait time
    private bool happinessDown;

    
    public void Start()
    {
        hslider = GetComponentInChildren<Slider>();
        treasureObj = transform.Find("Treasure").gameObject;

        index = Random.Range(0, allTreasure.Length); //get a random start treasure
        currentTreasure = allTreasure[index];

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
        ManageStray();
        dogName = inputField.GetComponent<Text>().text;

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

        if (foodTimer > foodTime)
        {
            foodTimer = foodTimer - foodTime;
            hungry = true;
        }
    }

    public void GetPet()
    {
        Debug.Log("gotpet");

        if (canBePet)
        {
            Debug.Log("gothappiness");
            currentHappiness += 20;
            canBePet = false;

            FindObjectOfType<UIManager>().ManageExp(2);
            ManageLevel(50);
        }

        FindObjectOfType<AudioManager>().Play(barkArray[Random.Range(0, barkArray.Length)]);
    }

    public void GetFed()
    {
        Debug.Log("gotfed");
        FindObjectOfType<UIManager>().ManageExp(5);

        if (hungry)
        {
            Debug.Log("gothappiness");
            currentHappiness += 10;
            hungry = false;

            ManageLevel(15);
        }

        //play sound on feeding, make new array
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
            FindObjectOfType<UIManager>().ManageExp(15);

            GameObject.Find("UII").GetComponent<UIManager>().addTreasure(Random.Range(0, 5));

            ManageLevel(50);

            FindObjectOfType<AudioManager>().Play("bell");

        }
    }

    public void SetName()
    {
        bool maxdogs = GameObject.Find("DogManager").GetComponent<dogManager>().maxReached; //use this for max dogs if u want


        if (adoptable && stray)
        {
            FindObjectOfType<UIManager>().ManageExp(40);
            //dogName = inputField.GetComponent<Text>().text;

            Debug.Log("ADOPT ATTEP");
            stray = false;
            name.SetActive(true);
            namingCanvas.SetActive(true);
        }
        else
        {
            GameObject.Find("DogManager").GetComponent<dogManager>().SetTooltip("Can't Adopt!");
            Debug.Log("Cannot adopt this dog");
        }
    }

    public void RunAway() //unfinished
    {
        dogName = "";
        stray = true;
        name.SetActive(false);
    }
}


