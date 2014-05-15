using UnityEngine;
using System.Collections;

public class Personagem2D : MonoBehaviour {
	Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Horizontal") != 0){
			animator.SetBool("Andando", true);
		}
		else {
			animator.SetBool("Andando", false);
		}

		if(Input.GetAxis("Horizontal") < 0) {
			transform.localScale = new Vector3(-1,1,1);
		}
		else {
			transform.localScale = new Vector3(1,1,1);
		}
	}
}
