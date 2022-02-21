using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BURGER : MonoBehaviour
{
  
    public Rigidbody rb;   
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine( BurgerMover() );
    }
    IEnumerator BurgerMover()
    {

        for(int i = 0; i <= 75; i++)
        {
            rb.AddTorque(0,10,0);

            yield return new WaitForSeconds(2f);
            
            rb.AddTorque(0,-10,0);
            rb.AddRelativeForce(Vector3.forward * 10);


            yield return new WaitForSeconds(1f);

            rb.velocity = Vector3.zero;
            
        
            yield return new WaitForSeconds(1f);

        }
        yield return null;
    }
  }
