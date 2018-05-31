using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class RewardPortal : MonoBehaviour, IReward, ITarget, ICallsObjectPool, IAnimateGeneric<IEnumerator,Vector3, Vector3>, INeedsPlaneReference
{
    public RewardTypes Type;

    protected float BaseReward = 0.1f;
    protected float reward = 0.10f;
    protected int randomRewardMultiplier = 1;
    protected Text displayReward;
    protected bool randomizeReward = true;

    public float AnimateSwingRange = 10;
    public float AnimationSpeed=0.5f;
    private Vector3 currentposition;
    private Vector3 swingrightposition;
    private Vector3 swingleftposition;
    private bool animatecycle = true;


    public virtual void SetupReward(RewardTypes _rewardType, bool _randomizeReward, float _baseReward, Text _displayReward)
    {
        Type = _rewardType;
        displayReward = _displayReward;
        randomizeReward = _randomizeReward;
        BaseReward = _baseReward;
    }

    public virtual void InitializeReward()
    {
        if (randomizeReward)
        {
            randomRewardMultiplier = UnityEngine.Random.Range(1, 10);
        }
        reward = BaseReward * randomRewardMultiplier;
        displayReward.text = ((int)(reward * 100)).ToString();
        animatecycle = true;

    }

    public void CallPool()
    {
        //Invole creation of another Reward after a certain delay
        ArtifactPooler[] PoolSearch = (ArtifactPooler[])GameObject.FindObjectsOfType<ArtifactPooler>();
        foreach (ArtifactPooler pool in PoolSearch)
        {
            if (Type.CastATortifact<RewardTypes>()==pool.PoolerType)                                                     //casting all different types of artifacts to a generic artifactstype enum to select right artifacts pool
            {
                pool.PoolingLogic();
            }
        }
    }

    public virtual void Reset()
    {
        StopAllCoroutines();
        reward = BaseReward;
        randomRewardMultiplier = 1;
        CallPool();
    }

    public virtual void AfterHit(GameObject hitObject)
    {
        foreach (var disabler in Enum.GetValues(typeof(DisablesReward)))
        {
            if (hitObject.tag == disabler.ToString())
            {
                gameObject.SetActive(false);
                Debug.Log("RewardPortal Entered");
            }
        }
    }

    public virtual void GiveReward(GameObject candidate)
    {
        if (candidate.GetComponentInParent<IReceivesReward<float>>() != null)
        {
            candidate.GetComponentInParent<IReceivesReward<float>>().ReceiveReward(Type, reward);
        }
    }

    public virtual void BeforeHit()
    {
        currentposition = this.transform.position;
        swingleftposition = currentposition - new Vector3(UnityEngine.Random.Range(0,AnimateSwingRange),0,0);
        swingrightposition = currentposition + new Vector3(UnityEngine.Random.Range(0, AnimateSwingRange),0,0);
        Vector3[] tmp = {new Vector3(20,0,10)};
        StartCoroutine(Animate(swingrightposition,swingleftposition));
    }

    public virtual IEnumerator Animate(Vector3 targetR, Vector3 targetL)
    {
        Debug.Log("Reward Animate Coroutine Started");
        while (Mathf.Abs(transform.position.x-targetL.x)>.2)
        {
            transform.position = Vector3.Lerp(transform.position, targetL, 0.5f * Time.deltaTime);
            AddPlaneReference(this.gameObject);
            yield return null;
        }
        while (Mathf.Abs(transform.position.x - targetR.x) > .2)
        {
            transform.position = Vector3.Lerp(transform.position, targetR, 0.5f * Time.deltaTime);
            AddPlaneReference(this.gameObject);
            yield return null;
        }
        Debug.Log("Reward Animate Coroutine Ended");
        BeforeHit();
    }

    [PlaneReferenceProvider(PlaneType = PlaneTypes.Terrain)]
    public GameObject AddPlaneReference(GameObject objectonPlane)
    {
        objectonPlane.AdjustTerrainHeight();
        return null;
    }
}
