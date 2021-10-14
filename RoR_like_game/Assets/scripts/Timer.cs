using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeStart;
    public Text tText;

    void Start(){
        tText.text = timeStart.ToString("F2");
    }
    void Update(){
        timeStart += Time.deltaTime;
        tText.text = timeStart.ToString("F2");
    }
}
