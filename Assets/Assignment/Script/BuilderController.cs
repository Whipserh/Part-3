using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderController : MonoBehaviour
{
    public GameObject minePrefab;
    public GameObject housePrefab;
    public GameObject lumberPrefab;
    public static GameObject SelectedBuilding { get; private set; }
        
    
    public void CreateHouse()
    {
        //if we have a lemming currently selected then we'll deselect
        LemmingController.deSelectLemming();

        //if we have a building already selected that is in build mode then we deselect and destroy
        if(SelectedBuilding != null)
        {
            Destroy(SelectedBuilding);
        }
        //create new building
        SelectedBuilding = Instantiate(housePrefab);

    }

    public void CreateLumberMill()
    {
        //if we have a lemming currently selected then we'll deselect
        LemmingController.deSelectLemming();
        //if we have a building already selected that is in build mode then we deselect and destroy
        if (SelectedBuilding != null)
        {
            Destroy(SelectedBuilding);
        }
        //create new building
        SelectedBuilding = Instantiate(lumberPrefab);
    }


    public void CreateMine()
    {
        //if we have a lemming currently selected then we'll deselect
        LemmingController.deSelectLemming();
        //if we have a building already selected that is in build mode then we deselect and destroy
        if (SelectedBuilding != null)
        {
            Destroy(SelectedBuilding);
        }
        //create new building
        SelectedBuilding = Instantiate(minePrefab);
    }

    public static void deselectBuilding()
    {

        SelectedBuilding = null;
    }

}
