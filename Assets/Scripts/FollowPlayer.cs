using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    Transform player;
    [SerializeField] float moveSpeed=2f;


    private void Start()
    {
        player = FindObjectOfType<AnxietyObjects>().getPlayerTransfrom();
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }
}
