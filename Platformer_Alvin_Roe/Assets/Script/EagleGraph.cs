using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EagleGraph : MonoBehaviour
{
    public AIPath aIPath;

    // Update is called once per frame
    void Update()
    {
        if(aIPath.desiredVelocity.x >=0.01f)
        {
            transform.localScale=new Vector3(-1, 1, 1);
        }
        else if (aIPath.desiredVelocity.x<=-0.01f)
        {
            transform.localScale=new Vector3(1, 1, 1);
        }
    }
}
