using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Entities;
using UnityEngine;

public class UserComponent : IComponentData
{
    public String email;
    public String displayName;
    [CanBeNull] public String password;
}
