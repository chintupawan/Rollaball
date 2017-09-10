using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 8f, maxVelocity = 4f;

    private Rigidbody2D playerBody;
    private Animator animator;

    void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame where as FixedUpdate is not
	void FixedUpdate () {
        PlayerMoveKeyboard();
	}

    void PlayerMoveKeyboard()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(playerBody.velocity.x);

        //Get -1 left 0 none 1 right
        float h = Input.GetAxisRaw("Horizontal");

        //Going right
        if (h > 0)
        {
            if (vel < maxVelocity)
            {
                forceX = speed;
            }
            Vector3 temp = transform.localScale;
            temp.x = 1.3f;
            transform.localScale = temp;

            animator.SetBool("Walk", true);
        }
        else if(h<0)
        {
            if(vel < maxVelocity)
            {
                forceX = -speed;
            }

            Vector3 temp = transform.localScale;
            temp.x = -1.3f;
            transform.localScale = temp;
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }

        playerBody.AddForce(new Vector2(forceX, 0));
    }
}
