using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : Villager
{
    float timerValue;
    public float dashTimer = 2;
    public float dashSpeed = 3;
    bool isDashing;
    public GameObject knife;
    public Transform sp1, sp2;
    Coroutine dashing;

    protected override void Attack()
    {

        /**
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

        **/
        destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(dashing!= null)
        {
            StopCoroutine(dashing);
        }
        dashing = StartCoroutine(Dash());

    }

    IEnumerator Dash()
    {
        speed += dashSpeed;
        while (speed > 3)
        {
            yield return null; 
        }
        base.Attack();
        yield return new WaitForSeconds(0.1f);
        Instantiate(knife, sp1.position, sp1.rotation);
        yield return new WaitForSeconds(0.1f);
        Instantiate(knife, sp2.position, sp2.rotation);

        
    }
/**
    private void Update()
    {
        base.Update();
        if (isDashing)
        {
            Dash();
        }
    }
*/
    



    public override ChestType CanOpen()
    {
        return ChestType.Thief;
    }
}
