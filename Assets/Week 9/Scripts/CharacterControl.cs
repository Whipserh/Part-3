using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class CharacterControl : MonoBehaviour
{
    public Text insert;
    public static CharacterControl Instance; 
   void Start()
    {
        Instance = this;
        selectedVillagerUI = insert;
    }

    public static Text selectedVillagerUI { get; set; }
    public static Villager SelectedVillager { get; private set; }
    public static void SetSelectedVillager(Villager villager)
    {
            

        if(SelectedVillager != null)
        {
            SelectedVillager.Selected(false);
        }   
        SelectedVillager = villager;
        SelectedVillager.Selected(true);
        

        //update the UI to show what you have selected
        if (SelectedVillager.GetType() == typeof(Archer))//if they are a archer
        {
            selectedVillagerUI.text = "Selected: Archer";
        }
        else if (SelectedVillager.GetType() == typeof(Thief))//if they are a thief
        {
            selectedVillagerUI.text = "Selected: Thief";
        }
        else if (SelectedVillager.GetType() == typeof(Merchant))//if they are a merchant
        {
            selectedVillagerUI.text = "Selected: Merchant";
        }
        else //they are just a regular villager
        {
            selectedVillagerUI.text = "Selected: Villager";
        }

    }
}
