using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A demon manager is to be attached to a Demon. 
// Different types of demons can be child of this class or attached as game objects having their internal implementation. 
// The implementations are hidden here and method calls are generic for all possible demons for Unity Events and Functions.

public class DemonWrapper : TreeDemon
{
    public DemonTypes DemonType = DemonTypes.TreeDemon;
    public Transform PlayerThreat;

    private void Awake()
    {
        base.Threat = PlayerThreat;
        base.Type = DemonType;
    }
    void Start ()
    {
         base.InitializeDemon();
         base.Attack();
    }
	
    void OnDisable()
    {
         base.Die();
    }

    private void Update()
    {
        base.BeforeHit();
    }
}
