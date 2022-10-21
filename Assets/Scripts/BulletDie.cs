using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDie : MonoBehaviour
{

    public float dieTime;


    [SerializeField] Sprite speaker;
    [SerializeField] Sprite sensation;
    [SerializeField] Sprite ccamear;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("enemy"))
        {
            SpriteRenderer enemy = other.gameObject.GetComponent<SpriteRenderer>();
            if (enemy.sprite.name.Equals("camera"))
            {
                enemy.sprite = ccamear;
                Destroy(gameObject);
            }
            else if (enemy.sprite.name.Equals("people"))
            {
                enemy.sprite = sensation;
                Destroy(gameObject);
            }
            else if (enemy.sprite.name.Equals("speaker"))
            {
                enemy.sprite = speaker;
                Destroy(gameObject);
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject collisionGameObject= other.gameObject;
        if (collisionGameObject.name!="Player")
        {
           // Die();
        }


    }

    IEnumerator Timer(){
        yield return new WaitForSeconds(dieTime);
        Die();
    }

     void Die(){
        Destroy(gameObject);
            
    }
}
