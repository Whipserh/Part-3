using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Camera_controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float speed = 2;
    public Transform snapBack;
    // Update is called once per frame
    void Update()
    {

        //move the camera using wsad
        transform.Translate(Input.GetAxis("Horizontal")*speed*Time.deltaTime, Input.GetAxis("Vertical")*speed*Time.deltaTime, 0);
        if (Input.GetKeyDown(KeyCode.F))
        {
            transform.position = snapBack.position;
        }
        
    }
}
