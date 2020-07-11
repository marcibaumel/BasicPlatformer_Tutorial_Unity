using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public Rigidbody2D rb;

    void Start()
    {
        
        
    }

    
    private void Update()
    {
        

        //Moving with A and D in the horizontal area
        if(Input.GetKey(KeyCode.A  )){
            rb.velocity=new Vector2(-5,rb.velocity.y);
            transform.localScale= new Vector2(-1, 1);
        }else if(Input.GetKey(KeyCode.LeftArrow )){
            rb.velocity=new Vector2(-5,rb.velocity.y);
            transform.localScale= new Vector2(-1, 1);
        }else if(Input.GetKey(KeyCode.D)){
            rb.velocity=new Vector2(5,rb.velocity.y);
            transform.localScale= new Vector2(1, 1);
        }else if(Input.GetKey(KeyCode.RightArrow)){
            rb.velocity=new Vector2(5,rb.velocity.y);
            transform.localScale= new Vector2(1, 1);
        }
        
        //Jump
        if (Input.GetKeyDown(KeyCode.Space)){
             rb.velocity=new Vector2(rb.velocity.x, 18f);
        }else if(Input.GetKeyDown(KeyCode.UpArrow)){
           rb.velocity=new Vector2(rb.velocity.x, 18f); 
        } 
    }
}
