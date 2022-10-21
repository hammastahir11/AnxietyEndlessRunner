using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemyObject : MonoBehaviour
{

    int bubble=0;
    int notBubble = 0;
    ComplexityFlags flags;
    private void Start()
    {
       flags = FindObjectOfType<ComplexityFlags>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       //Destroy all the enemy game objects
        if (other.gameObject.tag.Equals("enemy"))
        {

            SpriteRenderer enemy = other.gameObject.GetComponent<SpriteRenderer>();
            if (!enemy.sprite.name.Contains("safe"))
            {
                notBubble++;
            FindObjectOfType<PlayerMovement>().Hurt();
                Destroy(other.gameObject);
                if (notBubble == 10)
                {
                    flags.AddFlag();
                    notBubble = 0;
                }
            }
            if (enemy.sprite.name.Contains("safe"))
            {
                bubble++;
                
                Destroy(other.gameObject);
                if (bubble == 20)
                {
                    flags.RemoveFlag();
                    bubble = 0;
                }
            }
        }
    }
}
