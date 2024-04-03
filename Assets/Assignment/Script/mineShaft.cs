using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mineShaft : buildings
{

    protected override void lemmingInteraction(GameObject currLem)
    {
        Instantiate(base.lemming, currLem.transform.position, currLem.transform.rotation);
        Destroy(currLem);
    }
}
