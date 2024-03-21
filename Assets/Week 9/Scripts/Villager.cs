using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
public class Villager : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    public TextMeshProUGUI nameTag;
    bool clickingOnSelf;
    bool isSelected;
    public GameObject highlight;



    protected Vector2 destination;
    Vector2 movement;
    protected bool movingLeft = true;
    public float speed = 3;

    void Start()
    {
        nameTag.text = gameObject.name;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        destination = transform.position;
        Selected(false);
    }
    public void Selected(bool value)
    {
        isSelected = value;
        highlight.SetActive(isSelected);
    }
    /**
    private void OnMouseDown()
    {
        CharacterControl.SetSelectedVillager(this);
        clickingOnSelf = true;
    }
    **/

    private void OnMouseUp()
    {
        clickingOnSelf = false;
    }

    private void FixedUpdate()
    {
        movement = destination - (Vector2)transform.position;

        //flip the x direction of the game object & children to face the direction we're walking
        if(movement.x > 0)
        {
            Debug.Log("I am moving");
            transform.localScale = new Vector3(-1, 1, 1);
            movingLeft = false;
        }
        else if (movement.x < 0)
        {
            Debug.Log("I am moving");
            transform.localScale = new Vector3(1, 1, 1);
            movingLeft = true;
        }

        //stop moving if we're close enough to the target
        if (movement.magnitude < 0.1)
        {
            Debug.Log("I stopped");
            movement = Vector2.zero;
            speed = 3;
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

        //right click to attack
        if (Input.GetMouseButtonDown(1) && isSelected)
        {
            Attack();
        }
    }

    protected virtual void Attack()
    {
        animator.SetTrigger("Attack");
    }

    public virtual ChestType CanOpen()
    {
        return ChestType.Villager;
    }
}
