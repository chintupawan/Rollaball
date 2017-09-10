using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCollector : MonoBehaviour {

    void OnTriggerEnter2d(Collider2D other)
    {
        Console.WriteLine("trigger entered");
        if (other.tag == "Cloud" || other.tag == "Deadly")
        {
            other.gameObject.SetActive(false);
        }


    }
}
