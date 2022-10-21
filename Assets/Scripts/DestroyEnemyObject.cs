using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemyObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag.Equals("enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}
