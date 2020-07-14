using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogEnemy : MonoBehaviour
{
    [SerializeField]private float leftCap;
    [SerializeField]private float rightCap;

    [SerializeField] private float jumpLength;
    [SerializeField] private float jumpHeight;
    [SerializeField] private LayerMask ground;
    private Collider2D coll;
    private Rigidbody2D rb;
    private bool facingLeft=true;

    void Start()
    {
        coll=GetComponent<Collider2D>();
        rb=GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if(facingLeft)
        {
            
            if(transform.position.x > leftCap)
            {
                if(transform.localScale.x != 1)
                {
                    transform.localScale=new Vector3(1,1);
                }
                if(coll.IsTouchingLayers(ground))
                {
                    //Jump
                    rb.velocity=new Vector2(-jumpLength, jumpHeight);
                }
               
            }
            
            
            else
            {
                facingLeft=false;
            }
        }
        else
        {
           if(transform.position.x<rightCap)
            {
                if(transform.localScale.x!=-1)
                {
                    transform.localScale=new Vector3(-1,1);
                }
                if(coll.IsTouchingLayers(ground))
                {
                    //Jump
                    rb.velocity=new Vector2(jumpLength, jumpHeight);
                }
            }
            else
            {
                facingLeft=true;
            } 

        }
    }
    
}
