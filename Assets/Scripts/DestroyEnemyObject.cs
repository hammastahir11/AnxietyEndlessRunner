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

            SpriteRenderer enemy = other.gameObject.GetComponent<SpriteRenderer>();
            if (!enemy.sprite.name.Contains("safe"))
            {
               
            FindObjectOfType<PlayerMovement>().Hurt();
            }
            Destroy(other.gameObject);
        }
    }
}
