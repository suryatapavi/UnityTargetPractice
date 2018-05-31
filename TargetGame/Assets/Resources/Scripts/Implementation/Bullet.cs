using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A bullet is a special type of an ammunition.
// In the current context this bullet is an ammuntion for the Player.
// This script is to be attached to a bullet that the Player uses as ammunition.

public class Bullet : Ammunition
{
    public float LifeTime = 10f;
    public float DestroyTime = 1f;

    public override void OnHitTarget(GameObject target )
    {
        foreach (PlayerCanKill t in Enum.GetValues(typeof(PlayerCanKill)))
        {
            if (target.gameObject.tag == t.ToString())
            {
                target.SetActive(false);
                Debug.Log("Killed " + t.ToString());
            }
        }
    }

    public override void setup()
    {
        base.lifetime = LifeTime;
        base.destroytime = DestroyTime;
    }


    private void Start()
    {
        setup();
    }

    public void OnEnable()
    {
        base.OnFire();
    }

    public void OnCollisionEnter(Collision collision)
    {
        OnHitTarget(collision.gameObject);
        base.SelfDestroy();
    }

    public void OnTriggerEnter(Collider other)
    {
        OnHitTarget(other.gameObject);
        SelfDestroy();
    }
}
