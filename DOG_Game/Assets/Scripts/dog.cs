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
    public int currentHappiness;
    public HappinessBar happinessBar;
    private Slider hslider;

    public int petHappiness;

    public string favToy;
    public string favFood;
    public string leastToy;
    public string leastFood;

    public string[] allTreasure;
    private string currentTreasure;
    private int index;

    public bool stray;
    public bool adoptable;

    public bool hasTreasure;
    public int treasureChance;

    public int apptime; //time since start of thingy
    public float timer = 0.0f;
    public float sinceLastTreasure; //timer ig
    public float treasureTime; //wait time
    public float foodTime; //wait time


    public string[] barkArray = {"bark1", "bark2", "bark3", "bark4" };

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

        Timerr();

        CalculateHappiness();

    }

    void FixedUpdate()
    {
        happinessBar.SetHappiness(currentHappiness);
        apptime = (int)GameObject.Find("DogManager").GetComponent<dogManager>().timeNow;
       

        if (currentHappiness >= 50 && stray) //if happy and still a stray, make adoptable
        {
            adoptable = true;
        }
        else                             //otherwise if unhappy and a stray or, unadoptable
        {
            adoptable = false;
        }

    }

    void CollectTreasure() //make dog shiny, if clicked on when shiny then give treasure
    {
        index = Random.Range(0, allTreasure.Length);
        currentTreasure = allTreasure[index];
        FindObjectOfType<AudioManager>().Play("bell");
        hasTreasure = false;
        treasure.SetActive(false);
        sinceLastTreasure = 0;
    }

    void CalculateHappiness()
    {

    }

    void OnMouseDown()
    {
        if (hasTreasure)
        {
            CollectTreasure();
        }
    }

    void Timerr()
    {
        timer += Time.deltaTime;

        if(timer > treasureTime)
        {
            //Debug.Log("thefuck");
            timer = timer - treasureTime;
            hasTreasure = true;
            treasure.SetActive(true);
            sinceLastTreasure += 1;

            currentHappiness -= 30;

        }



    }

    public void GetPet()
    {
        currentHappiness += petHappiness;
        FindObjectOfType<AudioManager>().Play(barkArray[Random.Range(0, barkArray.Length)]);
 
    }
}


