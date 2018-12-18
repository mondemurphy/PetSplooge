using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlink : MonoBehaviour {

    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        StartCoroutine(Blink());
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    IEnumerator Blink()
    {
        yield return new WaitForSeconds(Random.Range(3, 6));
        anim.SetTrigger("PlayerBlink");
        StartCoroutine(Blink());
    }
}
