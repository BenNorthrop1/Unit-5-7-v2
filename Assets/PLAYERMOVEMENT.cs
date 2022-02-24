using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYERMOVEMENT : MonoBehaviour
{
    private Rigidbody2D rb;
    bool isGrounded;

    Animator m_Animation;

    public float speed = 10f;
    public float jumpheight = 10f;
    public float sprint = 12f;
    public float regular;


     
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        regular = speed;
        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        m_Animation = gameObject.GetComponent<Animator>();

        DoCollisons();
        DoJump();
        DoMove();

        
        

    }

    void DoCollisons()
    {
        float rayLength = 0.2f;


        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayLength);
   
        
        Color hitColor = Color.white;

        isGrounded = false;

        if (hit.collider != null)
        {


            if (hit.collider.tag == "Ground")
            {
                hitColor = Color.green;
                isGrounded = true;
            }
            
            Debug.DrawRay(transform.position, -Vector2.up * rayLength, hitColor);
        }

    }


        void DoJump()
        {
            Vector2 velocity = rb.velocity;

            // check for jump
            if (Input.GetKey("space") && isGrounded)
            {
                if (velocity.y < 0.01f)
                {
                    velocity.y = jumpheight;
                    m_Animation.SetTrigger("Jumping");
                }
            }

            rb.velocity = velocity;

        }

        void DoFaceLeft(bool faceleft)
        {
            if (faceleft == true)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }



        void DoMove()
        {
            Vector2 velocity = rb.velocity;

            // stop player sliding when not pressing left or right
            velocity.x = 0;

            // check for moving left
            if (Input.GetKey("a"))
            {
                velocity.x = -speed;
                m_Animation.SetBool("IsMoving", true);
            }

            // check for moving right
            else if (Input.GetKey("d"))
            {
                velocity.x = speed;
                m_Animation.SetBool("IsMoving", true);
            }
            else
            {
                m_Animation.SetBool("IsMoving", false);
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = sprint;
            }
            else
            {
                speed = regular;
            }


            if (velocity.x < -0.5f)
            {
                Helper.DoFaceLeft(gameObject, true);
            }
            if (velocity.x > 0.5f)
            {
                Helper.DoFaceLeft(gameObject, false);
            }



            rb.velocity = velocity;

        }

    
}