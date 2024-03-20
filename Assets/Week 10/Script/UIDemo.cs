using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIDemo : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public SpriteRenderer spriteRenderer;
    public Color sr;
    public Color end;
    float interpolation;



    public void SliderValueChanged(Single value)//"Just like a float?"
    {
        Debug.Log(value);
        interpolation = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.color = Color.Lerp(sr, end, (interpolation/60));

    }


    public void DropDownHasChanged(int index) {
        Debug.Log(dropdown.options[index].text);
    }



}
