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
        }else if(Input.GetKey(KeyCode.LeftArrow )){
            rb.velocity=new Vector2(-5,rb.velocity.y);
        }else if(Input.GetKey(KeyCode.D)){
            rb.velocity=new Vector2(5,rb.velocity.y);
        }else if(Input.GetKey(KeyCode.RightArrow)){
            rb.velocity=new Vector2(5,rb.velocity.y);
        }
        
        //Jump
        if (Input.GetKeyDown(KeyCode.Space)){
            rb.velocity=new Vector2(rb.velocity.x, 10f);
        }
    }
}
