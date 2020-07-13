using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Start() Variables
    private Rigidbody2D rb;
    private Animator anim;
    public int cherries=0;
    
    //FSM
    private enum State {idle, running, jump, falling};
    private State state=State.idle;
    private Collider2D coll;

    //Inspector Variables
    [SerializeField]private LayerMask ground;
    [SerializeField] private float speed=7f;
    [SerializeField] private float jumpForce=10f;


    private void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        coll=GetComponent<Collider2D>();
    }

    
    private void Update()
    {

        Movement();
        AnimationState();
        anim.SetInteger("state", (int)state);
    }

     private void OnTriggerEnter2D(Collider2D collision) //Trigger for Collectables
    {
        if(collision.tag == "Collectable")
        {
            Destroy(collision.gameObject); //Cherry destroy
            cherries += 1;
        }
    }

    private void Movement(){
        float hdirection=Input.GetAxis("Horizontal");
        float vdirection=Input.GetAxis("Vertical");        
        if(hdirection<0){
            rb.velocity=new Vector2(-speed,rb.velocity.y);
            transform.localScale= new Vector2(-1, 1);
            
        }else if(hdirection>0){
            rb.velocity=new Vector2(speed,rb.velocity.y);
            transform.localScale= new Vector2(1, 1);  
        }
       
        //Jump
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground)){
             rb.velocity=new Vector2(rb.velocity.x, jumpForce);
             state=State.jump;
        }
    }

    private void AnimationState()
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
