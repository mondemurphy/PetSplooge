using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

    public float walkSpeed = 1.5f;

    Animator anim;
    Rigidbody2D rb2d;
    Vector3 target;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        target = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
            anim.SetBool("WalkRight", false);
            anim.SetBool("WalkLeft", false);
            anim.SetBool("WalkUp", false);
            anim.SetBool("WalkDown", false);
        }
        transform.position = Vector3.MoveTowards(transform.position, target, walkSpeed * Time.deltaTime);

        if (target == transform.position)
        {
            anim.SetBool("WalkRight", false);
            anim.SetBool("WalkLeft", false);
            anim.SetBool("WalkUp", false);
            anim.SetBool("WalkDown", false);
        }
        if (target.x - transform.position.x > 0)
        {
            if ((target.x - transform.position.x) - Mathf.Abs(target.y - transform.position.y) > 0)
            {
                anim.SetBool("WalkRight", true);
            }
            else
            {
                if (target.y > 0)
                {
                    anim.SetBool("WalkUp", true);
                }
                else
                {
                    anim.SetBool("WalkDown", true);
                }
            }
        }
        else if (target.x - transform.position.x < 0)
        {
            if ((Mathf.Abs(target.x - transform.position.x)) - Mathf.Abs(target.y - transform.position.y) > 0) {
                anim.SetBool("WalkLeft", true);
            }
            else
            {
                if (target.y > 0)
                {
                    anim.SetBool("WalkUp", true);
                }
                else
                {
                    anim.SetBool("WalkDown", true);
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        target = transform.position;
    }
}
