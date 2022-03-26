using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class dog : MonoBehaviour
{
    [SerializeField] public string dogName;

    //[Range(0, 100)]
    //public float dogHappiness;

    public int maxHappiness = 100;
    public int dogLevel = 1;
    public int currentHappiness;
    public HappinessBar happinessBar;
    private Slider hslider;

    public int gotPetHappiness = 10;

    public string favToy;
    public string favFood;

    public string[] allTreasure;
    public string currentTreasure;
    private int index;

    public bool stray;
    public bool adoptable;

    public bool hasTreasure;
    public int treasureChance;

    public int apptime; //time since start of thingy
    public float timer = 0.0f;
    public float petTimer = 0.0f;
    public float sinceLastTreasure; //timer ig
    public float treasureTime; //wait time
    public float petTime; //wait time
    public float foodTime; //wait time
    public bool canBePet = true;

    public int XP = 0;
    public int Level = 0;



    public string[] barkArray = { "bark1", "bark2", "bark3", "bark4" };

    public GameObject treasure;

    public void Start()
    {
        hslider = GetComponentInChildren<Slider>();
        treasure = transform.Find("Treasure").gameObject;

        // Sets happiness at the beginning of the scene
        currentHappiness = (int)hslider.value;
        happinessBar.SetMaxHappiness(maxHappiness);
    }

    public void Update()
    {
        if (currentHappiness > 100)
        {
            currentHappiness = 100;
        }
        else if (currentHappiness < 0)
        {
            currentHappiness = 0;
        }

        Timers();

        CalculateHappiness();

    }

    void FixedUpdate()
    {
        happinessBar.SetHappiness(currentHappiness);
        apptime = (int)GameObject.Find("DogManager").GetComponent<dogManager>().timeNow;

    }

    void CalculateHappiness()
    {

    }

    public void ManageStray()
    {
        if (stray)
        {
            if(currentHappiness >= 50)
            {
                adoptable = true;
            }
        }
        else if (!stray)
        {
            if (currentHappiness <= 15)
            {

            }
        }
    }


    void ManageLevel(int XPgain)
    {
        XP = XP + XPgain;

        if(XP == 1000 * Level && Level != 5)
        {
            Level++;
            XP = 0;
        }
    }

    void Timers()
    {
        timer += Time.deltaTime;
        petTimer += Time.deltaTime;

        if (timer > treasureTime)
        {
            //Debug.Log("thefuck");
            timer = timer - treasureTime;
            hasTreasure = true;
            treasure.SetActive(true);
            sinceLastTreasure += 1;

            currentHappiness -= 30;

        }

        if (petTimer > petTime)
        {
            //Debug.Log("thefuck");
            petTimer = petTimer - petTime;
            canBePet = true;
        }

    }

    public void GetPet()
    {
        Debug.Log("gotpet");

        if (canBePet)
        {
            Debug.Log("gothappiness");
            currentHappiness += gotPetHappiness;
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
            currentHappiness += gotPetHappiness;
            hasTreasure = false;
            treasure.SetActive(false);
            sinceLastTreasure = 0;

            ManageLevel(50);

            FindObjectOfType<AudioManager>().Play("bell");

        }
    }
}


