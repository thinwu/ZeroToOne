﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
[SerializeField]


public struct UserInput: IComponentData
{
    public float CameraRayMaxLength;
    public LayerMask CameraRayHitLayer;
}