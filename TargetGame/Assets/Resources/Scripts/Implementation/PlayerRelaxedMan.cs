using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRelaxedMan : HumanPlayer, IUserControlled, IhasShootDevice, IReceivesReward<float>, IAnimatorHandler<string, float>, IAnimate<float>
{
    protected PlayerTypes Type;

    //Motion Related
    public float TranslateSpeed = 10;
    public float TranslateAcceleration = 1.0f;
    public float TurnSpeed = 5;
    public float RotateSpeed = 10;

    //Rewards Related
    public float Score = 0.0f;
    public float PowerFactor = 1.0f;
    public float SizeFactor = 1.0f;
    public float MaxSizeFactor = 4;
    public float MaxPowerFactor = 1000;

    //Ammunition Related
    public GameObject AmmunitionPrefab;
    public int AmmunitionCount = 20;
    public bool hasAmmunitionReserve = true;
    public int AmmunitionReserveCount = 50;
    ShootDevice shootDevice;

    //Animation Related
    public float AnimatorSpeed = 0;
    private Animator RelaxedMan;
    private int hashAnimatorSpeed;
    float[] rewards;


    public void SetupAnimatorHandle()
    {
        RelaxedMan = this.GetComponentInChildren<Animator>();
        hashAnimatorSpeed = Animator.StringToHash("Speed");
    }


    public void AnimatorHandle(string conditionParameter, float conditionValue)
    {
        if (conditionParameter == "Speed")
        {
            RelaxedMan.SetFloat(hashAnimatorSpeed, conditionValue);
        }
    }

    public void Animate(float sizeFactor)
    {
        this.transform.localScale *= SizeFactor;
        loadShootDevice();
    }
 
    //Reward Portals will Initialize the function on Collision Enter if the type Signature has IReceivesReward
    public void ReceiveReward(RewardTypes Rewardtype, float RewardValue)
    {
        switch (Rewardtype)
        { 
            case RewardTypes.SizeUp:
                if (SizeFactor < MaxSizeFactor)
                {
                    SizeFactor = (1 + RewardValue) * SizeFactor;
                    Animate(RewardValue);
                }
                break;
            case RewardTypes.PowerUp:
                if (PowerFactor < MaxPowerFactor)
                {
                    PowerFactor = (1 + RewardValue) * PowerFactor;
                }
                break;
        }
        rewards = new float[]{ Score, PowerFactor, SizeFactor };
        ScoreBoard.scoreBoard.UpdateText("", rewards);
    }


    public void loadShootDevice()
    {
        shootDevice.Load(AmmunitionPrefab, AmmunitionCount, hasAmmunitionReserve, AmmunitionReserveCount);
    }
    public void UserControlHandler()
    {
        if (DesktopContollerA.Controls.ForwardControl())
        {
            TranslateSpeed = TranslateSpeed + TranslateAcceleration * Time.deltaTime;
            MoveForward(TranslateSpeed);
        }
        if (DesktopContollerA.Controls.BackwardControl())
        {
            TranslateSpeed = TranslateSpeed + TranslateAcceleration * Time.deltaTime;
            MoveBackward(TranslateSpeed);
        }
        if (DesktopContollerA.Controls.RightControl())
        {
            MoveRight(TurnSpeed);
        }
        if (DesktopContollerA.Controls.LeftControl())
        {
            MoveLeft(TurnSpeed);
        }
        if (DesktopContollerA.Controls.YawBackwardControl())
        {
            MoveYawBackward(RotateSpeed);
        }
        if (DesktopContollerA.Controls.YawForwardControl())
        {
            MoveYawForward(RotateSpeed);
        }
    }
    public override void InitializePlayer()
    {
        shootDevice = this.GetComponentInChildren<ShootDevice>();
        SetupAnimatorHandle();
        loadShootDevice();
        rewards = new float[] { Score, PowerFactor, SizeFactor };
        ScoreBoard.scoreBoard.UpdateText("", rewards);
    }
    public override void Play()
    {
        float currentposition = this.transform.position.magnitude;
        UserControlHandler();
        float previousposition = this.transform.position.magnitude;
        AnimatorSpeed = Mathf.Abs(currentposition - previousposition)/Time.deltaTime;
        AnimatorHandle("Speed", AnimatorSpeed);
    }


    public override void GetKilled(GameObject killer)
    {
        //iteraction over all Player killers cast to Artifact Types and compared to the type of this killer

         //  gameObject.SetActive(false);
    }     

}
