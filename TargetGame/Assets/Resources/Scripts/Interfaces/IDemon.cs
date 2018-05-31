using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A Demon type game object should implement this interface

public interface IDemon
{
    void InitializeDemon();         // how to initialize a demon type
    void Attack();                  // how the demon type attacks
    void Die();                     // how a demon type dies/disable/exits game
}
