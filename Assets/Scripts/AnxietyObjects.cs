using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnxietyObjects : MonoBehaviour
{
    [SerializeField] List<GameObject> anxietyObjects;

    [SerializeField] Transform PlayerTransform;

    [SerializeField] Transform SkeltonTransform;
    [SerializeField] int timer = 4;

    float yAxixSpawn;



    TimeSpan time;
  
    private void Start()
    {
        time = DateTime.Now.TimeOfDay;
        yAxixSpawn = PlayerTransform.position.y;
    }

    public Transform getSkeltonTransform()
    {
        Transform tr = SkeltonTransform;
        return tr;
    }



    private void Update()
    {
      
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

        int location = rnd.Next(0, 7);
        anxietyObjects[chooseAnxietyObjectFromList].transform.position = new Vector3(PlayerTransform.position.x+13.8061f, yAxixSpawn + location, PlayerTransform.position.z);

        Instantiate(anxietyObjects[chooseAnxietyObjectFromList]);
    }

}
