﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*Any Game Object that is a target should implement this interface*/
public interface ITarget
{
    void BeforeHit();                       // behavior before it is hit
    void AfterHit(GameObject hitObjecct);   // behavior after it is hit - subjective to what hits it
}

