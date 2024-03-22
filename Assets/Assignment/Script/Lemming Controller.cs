using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemmingController : MonoBehaviour
{

    public static lemming SelectedLemming { get; private set; }

    public static void SelectLemming(lemming selection)
    {
        //deselect the last lemming 
        if(SelectedLemming != null)
        {
            SelectedLemming.Select();
        }

        //set the new lemming to be new selection
        SelectedLemming = selection;
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
