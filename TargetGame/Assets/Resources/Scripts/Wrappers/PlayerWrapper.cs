using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is a Player manager class. 
//Irrespective of the Player behavior internal implementation - this script can operate on any IPlayer type of game object.
//This hides the internal Player implementation in a model/prefab/game object and works in a generic way.

public class PlayerWrapper : PlayerRelaxedMan
{
    public PlayerTypes PlayerType = PlayerTypes.ManRelax;
    private void Awake()
    {
        base.Type = PlayerType;
    }

    void Start ()
    {
            base.InitializePlayer();
	}
	
	void Update ()
    {

            base.Play();
	}

    private void OnTriggerEnter(Collider other)
    {
        base.GetKilled(other.gameObject);
    }


}
