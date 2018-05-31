using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeDemon : Demon, IPlayerCanKill, IAnimate, INeedsPlaneReference
{
    protected DemonTypes Type;
    private Animator treeDemon;
    private int hashAnimatorHeight;
    private int hashAnimatorDie;

    protected Transform Threat;
    public override void InitializeDemon()
    {

    }

    public void SetupAnimatorHandle()
    {
    }

    public void Animate()
    {

    }

    public override void BeforeHit()
    {

        MoveLookAt(Threat, 2f);
    }

    public override void AfterHit(GameObject hitObjecct)
    {
        Die();
    }

    public void OnReceiveKill()
    { }
    

    public override void Attack()
    {
        //Randomized Sequence of Animate and AnimatorHandle
    }

    public override void Die()
    {
        this.gameObject.SetActive(false);
    }


    [PlaneReferenceProvider(PlaneType = PlaneTypes.Terrain)]
    public GameObject AddPlaneReference(GameObject obj)
    {
        return null;
    }
}
