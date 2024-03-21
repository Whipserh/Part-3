using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Archer : Villager
{
    
    public GameObject arrowPrefab;
    public Transform SpawnPoint;

    protected override void Attack()
    {
        base.Attack();
        destination = transform.position;
        Instantiate(arrowPrefab, SpawnPoint.position,SpawnPoint.rotation);
        /**if we only have it as (arrow, spawnPoint) it will make the 
         * arrows a child (in the hierarchy) of the spawnpoint in the archer... 
         * not what we want.
        **/
    }

    public override ChestType CanOpen()
    {
        return ChestType.Archer;
    }
}
