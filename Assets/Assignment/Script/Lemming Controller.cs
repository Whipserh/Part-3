using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemmingController : MonoBehaviour
{
    
    
    public static lemming SelectedLemming { get; private set; }
    public static void SetSelectedLemming(lemming lem)
    {
        if (SelectedLemming != null)
        {
            SelectedLemming.Selected(false);
        }
        SelectedLemming = lem;
        SelectedLemming.Selected(true);

    }

    public static void deSelectLemming()
    {
        if (SelectedLemming != null)
        {
            SelectedLemming.Selected(false);
        }
    }
}
