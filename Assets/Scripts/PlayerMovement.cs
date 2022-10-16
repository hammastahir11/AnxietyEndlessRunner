using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
public float movePower = 10f;
        public float KickBoardMovePower = 15f;
        public float jumpPower = 20f; //Set Gravity Scale in Rigidbody2D Component to 5

        private Rigidbody2D rb;
        private Animator anim;
        Vector3 movement;
        private float direction = 1;
        bool isJumping = false;
        private bool alive = true;
        private bool isKickboard = false;


        // Start is called before the first frame update
        void Start()
        {
            isShooting=false;
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }

        private void Update()
        {
            Restart();
            if (alive)
            {
                Hurt();
                Die();
                Attack();
                Jump();
                KickBoard();
                Run();

            }
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
           anim.SetBool("isJump", false);
        }
        void KickBoard()
        {
            if (Input.GetKeyDown(KeyCode.Alpha4) && isKickboard)
            {
                isKickboard = false;
                anim.SetBool("isKickBoard", false);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4) && !isKickboard )
            {
                isKickboard = true;
                anim.SetBool("isKickBoard", true);
            }

        }

        void Run()
        {
            if (!isKickboard)
            {
                Vector3 moveVelocity = Vector3.zero;
                anim.SetBool("isRun", false);


                if (Input.GetAxisRaw("Horizontal") < 0)
                {
                    direction = -0.51586f;
                    moveVelocity = Vector3.left;

                    transform.localScale = new Vector3(direction, 0.51586f, 0.51586f);
                    if (!anim.GetBool("isJump"))
                        anim.SetBool("isRun", true);

                }
                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    direction = 0.51586f;
                    moveVelocity = Vector3.right;

                    transform.localScale = new Vector3(direction, 0.51586f, 0.51586f);
                    if (!anim.GetBool("isJump"))
                        anim.SetBool("isRun", true);

                }
                transform.position += moveVelocity * movePower * Time.deltaTime;

            }
            if (isKickboard)
            {
                Vector3 moveVelocity = Vector3.zero;
                if (Input.GetAxisRaw("Horizontal") < 0)
                {
                    direction = -0.51586f;
                    moveVelocity = Vector3.left;

                    transform.localScale = new Vector3(direction, 0.51586f, 0.51586f);
                }
                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    direction = 0.51586f;
                    moveVelocity = Vector3.right;

                    transform.localScale = new Vector3(direction, 0.51586f, 0.51586f);
                }
                transform.position += moveVelocity * KickBoardMovePower * Time.deltaTime;
            }
        }
        void Jump()
        {
            if ((Input.GetButtonDown("Jump") || Input.GetAxisRaw("Vertical") > 0)
            && !anim.GetBool("isJump"))
            {
                isJumping = true;
                anim.SetBool("isJump", true);
            }
            if (!isJumping)
            {
                return;
            }

            rb.velocity = Vector2.zero;

            Vector2 jumpVelocity = new Vector2(0, jumpPower);
            rb.AddForce(jumpVelocity, ForceMode2D.Impulse);

            isJumping = false;
        }


        public float shootSpeed, shootTimer;
        private bool isShooting;
        public Transform shootPosition;
        public GameObject Bullet;

        void Attack()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && !isShooting)
            {
                anim.SetTrigger("attack");
                StartCoroutine(Shoot());
            }
            IEnumerator Shoot(){
                int direction(){
                    if(transform.localScale.x < 0f){
                        return -1;
                    }
                    else{
                        return +1;
                    }
                }
                isShooting=true;
                GameObject newBullet= Instantiate(Bullet, shootPosition.position, Quaternion.identity);
                newBullet.GetComponent<Rigidbody2D>().velocity=new Vector2(shootSpeed*direction()*Time.fixedDeltaTime,0f);
                newBullet.transform.localScale=new Vector2(newBullet.transform.localScale.x * direction(), newBullet.transform.localScale.y);
                
                yield return new WaitForSeconds(shootTimer);
                isShooting= false;
            }
                
        }
        void Hurt()
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                anim.SetTrigger("hurt");
                if (direction == 1)
                    rb.AddForce(new Vector2(-5f, 1f), ForceMode2D.Impulse);
                else
                    rb.AddForce(new Vector2(5f, 1f), ForceMode2D.Impulse);
            }
        }
        void Die()
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                isKickboard = false;
                anim.SetBool("isKickBoard", false);
                anim.SetTrigger("die");
                alive = false;
            }
        }
        void Restart()
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                isKickboard = false;
                anim.SetBool("isKickBoard", false);
                anim.SetTrigger("idle");
                alive = true;
            }
        }
}
