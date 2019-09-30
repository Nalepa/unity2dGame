using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D playerRB;
    Animator animator;
    bool isGrounded;
    bool isWalking;
    public float jumpPower;
    public float walkSpeed;
    public GameObject bulletPattern;
    float time = 0.0f;
    public float bulletPeriodTime;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    private void Update()
    {
        if (!isGrounded && playerRB.velocity.y == 0)
        {
            isGrounded = true;
            animator.SetBool("IsGrounded", isGrounded);
        }
        else if (isGrounded && playerRB.velocity.y != 0)
        {
            //TODO animacja zeskoku
            isGrounded = false;
        }
    }
    void FixedUpdate()
    {
        time += Time.deltaTime;
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)) && isGrounded )
        {
            isGrounded = false;
            animator.SetBool("IsGrounded", isGrounded);
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpPower);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            isWalking = true;
            animator.SetBool("IsWalking", isWalking);
            transform.Translate(Vector2.left * walkSpeed * Time.deltaTime);
            if (transform.localScale.x > 0)
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            isWalking = true;
            animator.SetBool("IsWalking", isWalking);
            transform.Translate(Vector2.right * walkSpeed * Time.deltaTime);
            if (transform.localScale.x < 0)
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
        else
        {
            isWalking = false;
            animator.SetBool("IsWalking", isWalking);
        }
        if (Input.GetKey(KeyCode.RightShift))
        {
            if ( !isWalking && time >= bulletPeriodTime || isWalking && time >= walkSpeed * bulletPeriodTime)
            {
                time = 0.0f;
                NewShot();
            }
        }
    }
    void NewShot()
    {
        Vector2 position = new Vector2(transform.position.x + transform.localScale.x / 1.9f, transform.position.y);
        if (transform.localScale.x > 0)
            Instantiate(bulletPattern, position, Quaternion.identity).SendMessage("SetDirection", true);
        else
            Instantiate(bulletPattern, position, Quaternion.identity).SendMessage("SetDirection", false);
    }
    void BigJump(float trampolinePower)
    {
        isGrounded = false;
        // TODO add animation to big jump
        animator.SetBool("IsGrounded", isGrounded);
        //reset previous velocity
        playerRB.velocity = Vector2.zero;
        playerRB.velocity = new Vector2(playerRB.velocity.x,  jumpPower * trampolinePower);
    }
}
