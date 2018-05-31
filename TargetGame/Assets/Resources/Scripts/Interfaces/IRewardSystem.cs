using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



/*Any Game Object that gives a Reward should implement this interface*/
public interface IReward
{
    void SetupReward(RewardTypes _rewardType, bool _randomizeReward, float _baseReward, Text _displayReward);     // how to setup the reward system
    void InitializeReward();                                                                                  //how to initialize the reward value
    void GiveReward(GameObject candidate);                                                                    // how to give the reward - subject to who the candidate for the reward is
    void Reset();                                                                                             // how to reset the reward system
}


//Collection of types that can disable a reward system
public enum DisablesReward
{
    Player,
}


/*Any Game Object that receives a Reward should implement this interface */

public interface IReceivesReward<T>
{
    void ReceiveReward(RewardTypes Rewardtype, T RewardValue);                    // how the object will receive the reward
}

