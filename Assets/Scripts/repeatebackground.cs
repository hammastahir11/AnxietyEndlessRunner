using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repeatebackground : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Destroy(collision.gameObject);
        if (collision.gameObject.tag.Equals("Player"))
        {
            collision.gameObject.transform.position =  new Vector3(-9.23f, -3.86f, 0);

        }
    }
}
