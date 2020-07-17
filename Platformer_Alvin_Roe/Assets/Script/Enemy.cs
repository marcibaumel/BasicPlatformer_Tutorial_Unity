using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    protected Animator anim;
    protected Rigidbody2D rb;
    protected AudioSource death;
    protected virtual void Start()
    {
        anim= GetComponent<Animator>();
        //ide valami kell
        rb=GetComponent<Rigidbody2D>();
        death=GetComponent<AudioSource>();
    }

    
    void Update()
    {
        
    }
     public void JumpedOn()
    {
        
        anim.SetTrigger("Death");
        death.Play();
        //rb.velocity=new Vector2(0,0);
        
    }
    private void Death()
    {
        Destroy(this.gameObject);
    }   
}
