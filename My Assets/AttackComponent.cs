using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class AttackComponent : IComponentData
{
    public float atkDamage;
    public float atkUse;
    public String specialAtkName;
    public String specialAtkType;
    public float specialAtkUse;
    public float specialAtkDamage;
    public String atkName;
    public String atkType;
}
