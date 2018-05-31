﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*Any Game Object that shows Players Score/Life/... should implement this interface*/
public interface IScoreboard
{
    void UpdateText(string updateText, float[] Score);            // how the information is updated on the board
}
