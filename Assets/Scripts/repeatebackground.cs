using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repeatebackground : MonoBehaviour
{
    [SerializeField] float timer = 1f;
    TimeSpan time;

    [SerializeField] List<GameObject> maps;
    int mapnumber = 0;

    private void Start()
    {
        time = DateTime.Now.TimeOfDay;
        
    }

    private void Update()
    {
        float minutes = DateTime.Now.TimeOfDay.Minutes-time.Minutes;
        //Debug.Log(DateTime.Now.TimeOfDay.Minutes+"      "+time.Minutes);
        if (DateTime.Now.TimeOfDay.Minutes==time.Minutes+1)
        {
            ChangeMap();
        }
    }

    public void ChangeMap()
    {   time = DateTime.Now.TimeOfDay;
        Debug.Log("ON : " + (mapnumber + 1) % 4 + "  OFF : "+mapnumber % 4);
        maps[(mapnumber+1) % 4].SetActive(true);
        maps[mapnumber % 4].SetActive(false);
        mapnumber++;
        
    }
}
