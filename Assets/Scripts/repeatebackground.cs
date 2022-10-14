using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repeatebackground : MonoBehaviour
{

    [SerializeField] GameObject map;
    //[SerializeField] GameObject mapGenKey;
    Transform obj;
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Destroy(collision.gameObject);
        if (collision.gameObject.tag.Equals("Player"))
        {
            Vector3 newPosition = new Vector3(19.1599998f, 0, 0) + map.transform.position;
            obj = map.transform;
            obj.position = newPosition;
            Debug.Log(newPosition);
            Instantiate(gameObject,obj);

            Vector3 TempVec= new Vector3(gameObject.transform.position.x, 0, 0);
            gameObject.transform.position += TempVec ;



            //Destroy(collision.gameObject);
            //collision.gameObject.transform.position =  new Vector3(-9.23f, -3.86f, 0);

        }
    }
}
