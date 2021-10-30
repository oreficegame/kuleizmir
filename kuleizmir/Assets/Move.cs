using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveforce = 10f;
    public float jumpforce = 22f;
    public float movmentX;
    //public bool isGrounded;
    private Rigidbody2D myBody;
    private SpriteRenderer sf;
    private Animator anim;
    private string WALK_ANIMATION = "walk";

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        sf = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();


    }

    void Update()
    {
        PlayerMoveKeyboard();
        PlayerJump();
    }
    void PlayerMoveKeyboard()
    {
        movmentX = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movmentX, 0f, 0f) * moveforce * Time.deltaTime;
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
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
}



//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("Ground"))
//        {
//            isGrounded = true;
//        }
//        else
//        {
//            isGrounded = false;
//        }
//    }
//}
