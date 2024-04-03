using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class lemming : MonoBehaviour
{

    public GameObject selectionIcon;
    Rigidbody2D rb;
    Animator animator;
    bool clickingOnSelf;
    bool isSelected;
    



    protected Vector2 destination;
    Vector2 movement;
    protected bool movingLeft = true;
    public float speed = 3;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        destination = transform.position;
        Selected(false);
    }
    public void Selected(bool value)
    {
        isSelected = value;
        selectionIcon.SetActive(isSelected);
    }
    

    private void OnMouseDown()
    {
        LemmingController.SetSelectedLemming(this);
        clickingOnSelf = true;
    }
    

    private void OnMouseUp()
    {
        clickingOnSelf = false;
    }

    private void FixedUpdate()
    {
        movement = destination - (Vector2)transform.position;

        //flip the x direction of the game object & children to face the direction we're walking
        if (movement.x > 0)
        {
            transform.localScale = new Vector3(-1 , 1, 1);
            movingLeft = false;
        }
        else if (movement.x < 0)
        {
            transform.localScale = new Vector3(1,1,1);
            movingLeft = true;
        }

        
        if (movement.magnitude < 0.1)//stop moving if we are too close to our destination
        {
            movement = Vector2.zero;
            speed = 3;
            //stop walking
            animator.SetBool("walking", false);
        }
        else//we have a desitiation that we need to get to so we move towards it
        {
            Debug.Log("I am moving");
            animator.SetBool("working", false);//if we were working then stop
            animator.SetBool("walking", true);//move 
        }

        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);

    }

    protected void Update()
    {
        //left click: move to the click location
        if (Input.GetMouseButtonDown(0) && isSelected && !clickingOnSelf)
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        animator.SetFloat("Movement", movement.magnitude);

       }

    protected virtual void interact()
    {
        animator.SetBool("working", true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        movement = Vector2.zero;
    }
}
