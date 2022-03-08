using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dog : MonoBehaviour
{
    [SerializeField] public string dogName;

    [Range(0, 100)]
    public float dogHappiness;

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


    private GameObject treasure;

    public void Start()
    {
        treasure = transform.Find("Treasure").gameObject;
    }

    public void Update()
    {
        if (dogHappiness > 100)
        {
            dogHappiness = 100;
        }
        else if (dogHappiness < 0)
        {
            dogHappiness = 0;
        }

        Timerr();
    }

    void FixedUpdate()
    {
        apptime = (int)GameObject.Find("DogManager").GetComponent<dogManager>().timeNow;
       

        if (dogHappiness >= 50 && stray) //if happy and still a stray, make adoptable
        {
            adoptable = true;
        }
        else                             //otherwise if unhappy and a stray or, unadoptable
        {
            adoptable = false;
        }

        if (sinceLastTreasure / treasureTime >= 1)
        {
            hasTreasure = true;
            treasure.SetActive(true);
        }

    }

    void CollectTreasure() //make dog shiny, if clicked on when shiny then give treasure
    {
        index = Random.Range(0, allTreasure.Length);
        currentTreasure = allTreasure[index];


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
            Debug.Log("thefuck");
            timer = timer - treasureTime;
            sinceLastTreasure += 1;
        }
    }
}


