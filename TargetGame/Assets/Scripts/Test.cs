using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {


    public float PlayerMoveSpeed = 10;
    public float PlayerRotateSpeed = 10;
    // Use this for initialization
    void Start () {
        Debug.Log("Getting Started");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(this.transform.forward * PlayerMoveSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(-this.transform.forward * PlayerMoveSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Rotate(this.transform.up, PlayerRotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Rotate(-this.transform.up, PlayerRotateSpeed * Time.deltaTime);
        }
    }
}
