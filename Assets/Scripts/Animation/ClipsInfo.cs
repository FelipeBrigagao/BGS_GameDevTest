using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ClipsInfo
{
    public AnimationState AnimationState;
    public AnimationDirection AnimationDirection;
    public AnimationClip AnimationClip;
}

public enum AnimationState
{
    Idle,
    Walk
}

public enum AnimationDirection
{
    Up,
    Down, 
    Left,
    Right
}
