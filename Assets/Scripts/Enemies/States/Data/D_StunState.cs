﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newStunStateData", menuName = "Data/State Data/Stun State")]

public class D_StunState : ScriptableObject
{
    public float stunTime = 3f;

    public float stunKnockBackTime = 0.2f;
    public float stunKockbackSpeed = 20f;
    public Vector2 stunKnockbackAngle;
}
