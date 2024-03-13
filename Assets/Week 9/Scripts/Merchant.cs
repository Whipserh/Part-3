using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : Villager
{
    protected override void Attack()
    {
        base.Attack();
    }


    public override ChestType CanOpen()
    {
        return ChestType.Merchant;
    }
}
