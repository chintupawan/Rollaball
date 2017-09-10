using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

    public float MaxTumbleValue;

    public Rigidbody rigidbody;
	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.angularVelocity = Random.insideUnitSphere * MaxTumbleValue;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
