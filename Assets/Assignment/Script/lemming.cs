using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lemming : MonoBehaviour
{

    public GameObject selectionIcon;
    public void Select()
    {
        //set the selection icon to turn on
        selectionIcon.SetActive(!selectionIcon.activeInHierarchy);


    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
