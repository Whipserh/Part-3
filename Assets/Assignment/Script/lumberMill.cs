using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lumberMill : buildings
{


    protected override void lemmingInteraction(GameObject currLem)
    {
        //swap out the currLemming for a new lemming
        Instantiate(base.lemming, currLem.transform.position, currLem.transform.rotation);
        Destroy(currLem);
    }
}
