using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class PlayerMover : MonoBehaviour
{

    public Rigidbody2D rb;

    public SpriteRenderer sr;

    Color playerColor;

    

    public float speed = 10;

    void Start()
    {
       StartCoroutine( WaitCoroutine() );
       StartCoroutine( ColorCoroutine());
    }

    
    IEnumerator WaitCoroutine()
    {
       Vector2 velocity = rb.velocity;


    int i = 0;
        while (i < 5) 
        {
            rb.velocity = Vector2.zero;
            Vector3 right = new Vector3(1,0,0);
            rb.AddForce(right * 5, ForceMode2D.Impulse);
            
            yield return new WaitForSeconds(0.5f); 
            rb.velocity = Vector2.zero;

            
            Vector3 left = new Vector3(-1,0,0);
            rb.AddForce(left * 5, ForceMode2D.Impulse);
            //velocity.x = speed;

            yield return new WaitForSeconds(0.5f); 

            i++;
        
        }
    }

     IEnumerator ColorCoroutine()
    {

        for(float j = 0; j < 1; j += 0.1f)
        {
  
            sr.color = new Vector4(1f-j, j , 0f, 1f);
            yield return new WaitForSeconds(0.5f); 
        }
        
    }
}


