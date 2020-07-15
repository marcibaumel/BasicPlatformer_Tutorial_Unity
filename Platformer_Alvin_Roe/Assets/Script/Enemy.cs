using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    protected Animator anim;

    protected virtual void Start()
    {
        anim= GetComponent<Animator>();
        //ide valami kell
        
    }

    
    void Update()
    {
        
    }
     public void JumpedOn()
    {
        anim.SetTrigger("Death");
        
    }
    private void Death()
    {
        Destroy(this.gameObject);
    }   
}
