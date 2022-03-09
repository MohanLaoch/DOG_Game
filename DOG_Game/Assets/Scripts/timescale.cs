using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class timescale : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public TMPro.TMP_Text timetext;

    public void Start()
    {
        ChangeScale();
        timetext = GameObject.Find("TimeText").GetComponent<TMP_Text>();

    }

    public void Update()
    {
        ChangeScale();
        timetext.text = "Time Multiplier: X" + slider.value;

    }

    // Sets slider to max happiness
    public void ChangeScale()
    {
        Time.timeScale = slider.value;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
