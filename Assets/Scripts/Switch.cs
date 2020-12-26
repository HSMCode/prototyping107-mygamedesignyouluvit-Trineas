using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject dayTime, nightTime; //references to the day and nighttime gameobjects which i had to create and put the enemys as children

    public int IsRunning = 1;       //while isRunning is "1", run script; while it is set to "0", do not do it
    public int NumberofSeconds;     //how long it takes until the script switches


    void Update()
    {
        if (IsRunning == 1)
        {
            StartCoroutine(Wait());
        }
    }

    public IEnumerator Wait()
    {
        //wait number of seconds
        IsRunning = 0;
        yield return new WaitForSeconds(NumberofSeconds);  

        //switch light
        LightswitchOnOff();
        SoundScript.PlaySound();

        //reset
        IsRunning = 1;
    }
   
    public void LightswitchOnOff()
   {
        if (dayTime.activeInHierarchy) //if daytime is active and three seconds pass, disable daytime and enable nighttime
        {
            dayTime.SetActive(false);
            nightTime.SetActive(true);
        }
        else //if daytime is inactive and three seconds pass, enable daytime and disable nighttime
        {
            dayTime.SetActive(true);
            nightTime.SetActive(false);
        }
    }

    //just copied that code from dannys gdd and hey, it worked

}
