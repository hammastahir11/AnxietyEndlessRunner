using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnxietyObjects : MonoBehaviour
{
    [SerializeField] List<GameObject> anxietyObjects;

    [SerializeField] Transform PlayerTransform;
    [SerializeField] int timer = 4;
 
    TimeSpan time;
  
    private void Start()
    {
        time = DateTime.Now.TimeOfDay;

    }

    private void Update()
    {
        //Debug.Log(((DateTime.Now.TimeOfDay.Seconds % 60) % timer));
        //(DateTime.Now.TimeOfDay.Seconds) > (time.Seconds + timer)
        if (((DateTime.Now.TimeOfDay.Seconds%60)%timer)==0 && time.Seconds!=DateTime.Now.TimeOfDay.Seconds)
        {
            SpawnAxietyObjects();
        }
    }
    public void SpawnAxietyObjects()
    {
        time = DateTime.Now.TimeOfDay;
        System.Random rnd = new System.Random();
        int chooseAnxietyObjectFromList = rnd.Next(0,anxietyObjects.Count);
        
        anxietyObjects[chooseAnxietyObjectFromList].transform.position = new Vector3(PlayerTransform.position.x+13.8061f, PlayerTransform.position.y+2f, PlayerTransform.position.z);

        Instantiate(anxietyObjects[chooseAnxietyObjectFromList]);
    }

}
