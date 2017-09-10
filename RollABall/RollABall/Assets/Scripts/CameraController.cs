using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject Player;
    private Vector3 offSetValue;

	// Use this for initialization
	void Start () {
        offSetValue = transform.position - Player.transform.position;
	}
	
	
	void LateUpdate () {
        transform.position = Player.transform.position + offSetValue;
	}
}
