using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveforce = 10f;
    public float jumpforce = 22f;
    public float movmentX;
    public float nextJumpTime;
    public float JumpFrequency = 0.1f;
    //public bool isGrounded;
    private Rigidbody2D myBody;
    private SpriteRenderer sf;
    private Animator anim;
    private string WALK_ANIMATION = "walk";

    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;

    public bool isGrounded = false;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        sf = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();


    }

    void Update()
    {
        PlayerMoveKeyboard();
        OnGroundCheck();
        PlayerJump();
    }
    void PlayerMoveKeyboard()
    {
        movmentX = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movmentX, 0f, 0f) * moveforce * Time.deltaTime;
    }

    void PlayerJump()
    {


        if (Input.GetButtonDown("Jump") && isGrounded && (nextJumpTime < Time.timeSinceLevelLoad))
        {
            nextJumpTime = Time.timeSinceLevelLoad + JumpFrequency;
            myBody.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Impulse);

        }
    }
    void AnimatePlayer()
    {
        if (movmentX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sf.flipX = false;
        }
        else if (movmentX < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sf.flipX = true;
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

   private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    void OnGroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer);
    }
}


