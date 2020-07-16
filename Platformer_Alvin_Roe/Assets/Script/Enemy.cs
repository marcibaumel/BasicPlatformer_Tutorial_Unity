using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    protected Animator anim;
    protected Rigidbody2D rb;
    protected virtual void Start()
    {
        anim= GetComponent<Animator>();
        //ide valami kell
        rb=GetComponent<Rigidbody2D>();
        
    }

    
    void Update()
    {
        
    }
     public void JumpedOn()
    {
        anim.SetTrigger("Death");
        //rb.velocity=new Vector2(0,0);
        
    }
    private void Death()
    {
        Destroy(this.gameObject);
    }   
}
