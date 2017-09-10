using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public float Speed;

    private Rigidbody rg;

	// Use this for initialization
	void Start () {
        rg = GetComponent<Rigidbody>();
        rg.velocity = transform.forward * Speed;
	}
	
}
