using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject myplayer;
    public Animator anim;
    // Use this for initialization

    void Start()
    {
        myplayer = GameObject.Find("Man relax");
        anim = myplayer.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", 5.0f);

        
    }
}
