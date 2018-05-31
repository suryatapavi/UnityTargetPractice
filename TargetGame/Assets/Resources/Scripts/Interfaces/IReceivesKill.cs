using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Types that a player can kill - and the points for killing each type*/
public enum PlayerCanKill
{
    TreeDemon = 100,
    IceDemon = 200,
    FireDemon = 300,
    Monster = 50,
    Zombie = 30,
    Vampire = 20
}

/* types that can kill a player*/
public enum PlayerKillers
{
     TreeDemon,
     IceDemon,
     FireDemon,
     Monster
}

/*Any Game Object that can be killed should implement this interface*/

public interface IPlayerCanKill
{
    void OnReceiveKill();
}