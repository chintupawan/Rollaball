using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;
    private int pickUpCount;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        winText.text = "";
        setCountText(false);
    }

    /// <summary>
    /// This will be called just before applying any physics animation
    /// </summary>
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 directionV3 = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(directionV3 * speed, ForceMode.Force);
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Pickups") || other.gameObject.CompareTag("DoublePointsPickups"))
        {
            pickUpCount++;
            other.gameObject.SetActive(false);
            var tag = other.gameObject.tag;
            if (tag == "DoublePointsPickups")
            {

                count = count > 0 ? count * 2 : 2;
            }
            else
            {
                count++;
            }

            setCountText(pickUpCount==7);
        }
    }

    void setCountText(bool won)
    {
        if (!won)
            countText.text = string.Format("Count {0}", count);
        else
        {
            winText.text = "You won!";
            GetComponent<Collider>().gameObject.SetActive(false);
        }

    }
}
