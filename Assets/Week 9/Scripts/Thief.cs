using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : Villager
{

    public GameObject knife;
    public Transform sp1, sp2;

    protected override void Attack()
    {
        base.Attack();

        if (movingLeft)
        {
            transform.position += new Vector3(-2, 0, 0);
        }
        else 
        {
            transform.position += new Vector3(2, 0, 0);
        }
        

        destination = transform.position;
        Instantiate(knife, sp1.position, sp1.rotation);
        Instantiate(knife, sp2.position, sp2.rotation);
    }

}
