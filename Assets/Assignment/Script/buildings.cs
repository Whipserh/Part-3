using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class buildings : MonoBehaviour
{


    public GameObject blueprint;
    public GameObject building;
    public GameObject lemming;
    public bool buildMode = false;

    // Start is called before the first frame update
    void Start()
    {
        SetUpBuildMode();    
    }


    private void SetUpBuildMode()
    {
        building.transform.localScale = new Vector3(1,0,1);
        buildMode = true;
    }


    private void OnMouseDown()
    {
        //the moment thet we are no longer in build mode then it should not be affected by the player
        if (!buildMode) return;

        //if the player clicks with the left mouse click, then confirm the build
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("left click");
            StartCoroutine(contructing());
            buildMode = false;
            BuilderController.deselectBuilding();
        }
        //on right click
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("right click");
            //if the player right clicks on building then canecel the build
            
            BuilderController.deselectBuilding();
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (buildMode)
        {
            Vector2 destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            gameObject.transform.position = destination;
        }
    }

    IEnumerator contructing()
    {
        while(building.transform.localScale.y < 1)
        {
            building.transform.localScale += new Vector3(0, 0.01f, 0);
            yield return null;//wait till the end of the frame to continue
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (buildMode) return;

        Debug.Log("a collision was detected");
        if(collision.gameObject.tag == "lemming"){
            lemmingInteraction(collision.gameObject);
        }
    }

    //what happens when a lemming touches the building
    protected virtual void lemmingInteraction(GameObject currLem)
    {
        //create a new lemming when a lemming touches the box
        Instantiate(lemming, currLem.transform.position + new Vector3(3,0,0), currLem.transform.rotation);
        Instantiate(lemming, currLem.transform.position, currLem.transform.rotation);
        Destroy(currLem );
    }
}
