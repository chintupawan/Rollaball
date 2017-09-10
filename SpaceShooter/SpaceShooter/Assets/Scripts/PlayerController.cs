using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
public class PlayerController : MonoBehaviour
{

    public float Speed;
    public float Tilt;

    public Boundary Boundary;
    public GameObject Shot;
    public Transform ShotSpawn;
    private Rigidbody rg;
    private AudioSource audio;

    private float nextFire;
    public float FireRate;

    void Start()
    {
        rg = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();

    }

    void FixedUpdate()
    {

        float moveHorizontal = Input.acceleration.x;//== 0.0f ? Input.acceleration.x : Input.GetAxis("Horizontal");
        float moveVertical = Input.acceleration.y;//> 0.0f ? Input.acceleration.y : Input.GetAxis("Vertical");

        var movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rg.velocity = movement * Speed;

        rg.position = new Vector3(Mathf.Clamp(rg.position.x, Boundary.xMin, Boundary.xMax),
                                  0.0f,
                                  Mathf.Clamp(rg.position.z, Boundary.zMin, Boundary.zMax));
        rg.rotation = Quaternion.Euler(0.0f, 0.0f, rg.velocity.x * -Tilt);
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = nextFire + FireRate;
            Instantiate(Shot, ShotSpawn.position, ShotSpawn.rotation);
            audio.Play();
        }
    }
}
