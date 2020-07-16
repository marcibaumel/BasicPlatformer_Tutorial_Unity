using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    //Start() Variables
    private Rigidbody2D rb;
    private Animator anim;
    
    
    //FSM
    private enum State {idle, running, jump, falling, hurt};
    private State state=State.idle;
    private Collider2D coll;

    //Inspector Variables
    [SerializeField]private LayerMask ground;
    [SerializeField] private float speed=7f;
    [SerializeField] private float jumpForce=10f;
    [SerializeField] private int cherries=0;
    [SerializeField] private Text cherryText; 
    [SerializeField] private float hurtForce=10f;


    private void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        coll=GetComponent<Collider2D>();
    }

    
    private void Update()
    {

        if(state != State.hurt)
        {
            Movement();
        }
        AnimationState();
        anim.SetInteger("state", (int)state);

    }

     private void OnTriggerEnter2D(Collider2D collision) //Trigger for Collectables
    {
        if(collision.tag == "Collectable")
        {
            Destroy(collision.gameObject); //Cherry destroy
            cherries += 1;
            cherryText.text = cherries.ToString();

        }
    }

     private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag =="Enemy")
        {
            Enemy enemy=other.gameObject.GetComponent<Enemy>();
            if(state==State.falling)
            {
                enemy.JumpedOn();
                Jump();
            }
            else
            {
                state=State.hurt;
                if(other.gameObject.transform.position.x>transform.position.x)
                {
                    rb.velocity=new Vector2(-hurtForce, rb.velocity.y);
                }
                else
                {
                    rb.velocity=new Vector2(hurtForce, rb.velocity.y);
                }
            }
        }
    }

    private void Movement()
    {
        float hdirection=Input.GetAxis("Horizontal");
        float vdirection=Input.GetAxis("Vertical");    

        if(hdirection<0)
        {
            rb.velocity=new Vector2(-speed,rb.velocity.y);
            transform.localScale= new Vector2(-1, 1);
            
        }
        else if(hdirection>0)
        {
            rb.velocity=new Vector2(speed,rb.velocity.y);
            transform.localScale= new Vector2(1, 1);  
        }
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground)){
             Jump();
        }
    }
    private void Jump()
    {
        rb.velocity=new Vector2(rb.velocity.x, jumpForce);
        state=State.jump;
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
        else if(state==State.hurt)
        {
            if(Mathf.Abs(rb.velocity.x)<0.1f)
            {
                state=State.idle;
            }
        }
        else if(Mathf.Abs(rb.velocity.x)>2f)
        {
            state =State.running;
        }
        else{
            state=State.idle;
        }
    }
}
