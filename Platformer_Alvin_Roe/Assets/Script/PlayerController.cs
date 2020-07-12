using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private Rigidbody2D rb;
    private Animator anim;
    
    private enum State {idle, running, jump, falling};
    private State state=State.idle;
    private Collider2D coll;
    [SerializeField]private LayerMask ground;


    private void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        coll=GetComponent<Collider2D>();
    }

    
    private void Update()
    {
        
        float hdirection=Input.GetAxis("Horizontal");
        float vdirection=Input.GetAxis("Vertical");        
        if(hdirection<0){
            rb.velocity=new Vector2(-5,rb.velocity.y);
            transform.localScale= new Vector2(-1, 1);
            
        }else if(hdirection>0){
            rb.velocity=new Vector2(5,rb.velocity.y);
            transform.localScale= new Vector2(1, 1);
            
        }
       else
       {
           
       }
        
        //Jump
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground)){
             rb.velocity=new Vector2(rb.velocity.x, 18f);
             state=State.jump;
        }

        VelocityStateSwitch();
        anim.SetInteger("state", (int)state);
    }

    private void VelocityStateSwitch()
    {
        if(state == State.jump)
        {
            if(rb.velocity.y<0.1f)
            {
                state=State.falling;
            }

        }
        else if(state==State.falling)
        {
            if(coll.IsTouchingLayers(ground))
            {
                state=State.idle;
            }
        }
        else if(Mathf.Abs(rb.velocity.x)>2f)
        {
            //Going right
            state =State.running;
        }
        else{
            state=State.idle;
        }
        

    }


}
