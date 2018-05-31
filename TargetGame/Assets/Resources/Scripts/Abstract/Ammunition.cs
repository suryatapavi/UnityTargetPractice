using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public abstract class Ammunition : MonoBehaviour, IAmmunition
{
    protected float lifetime = 10f;
    protected float destroytime = 1f;

    public virtual void setup()
    { }
    private void disable()
    {
        gameObject.SetActive(false);
    }
    public virtual void OnFire()
    {
        Invoke("disable",lifetime);
    }

    public abstract void OnHitTarget(GameObject target);

    public virtual void SelfDestroy()
    {
        Invoke("disable", destroytime);
    }

}