using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This is a reward manager class to be attached to a reward type game object. 
//This class is like a builder that sits on top that calls relevant methods for different Unity Event Handlers and methods.

public class RewardWrapper : RewardPortal
{
    public RewardTypes RewardType = RewardTypes.SizeUp;
    public float RewardValue = 0.10f;
    public bool RandomizeReward = true;
    public Text DisplayReward;

    private void Awake()
    {
        base.SetupReward(RewardType, RandomizeReward, RewardValue, DisplayReward);

    }

    void Start()
    {
        base.InitializeReward();
        base.BeforeHit();
    }

    void OnEnable()
    {
        base.InitializeReward();
    }

    public void OnTriggerEnter(Collider other)
    {
        base.GiveReward(other.gameObject);
        base.AfterHit(other.gameObject);
    }

    void OnDisable()
    {
        base.Reset();
    }
}
