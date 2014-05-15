using UnityEngine;
using System.Collections;

// modelo usado : http://opengameart.org/content/animated-knight

public class Cavaleiro : MonoBehaviour {
	Animator animator;
	Vector3 dirInput;
	public float velocidade = 1;

	void Start () {
		animator = GetComponentInChildren<Animator>();
	}
	

	void Update () {
		dirInput = new Vector3(-Input.GetAxis("Horizontal"), 0, -Input.GetAxis("Vertical"));
		if(dirInput != Vector3.zero){
			animator.SetBool("Andando", true);
		}
		else {
			animator.SetBool("Andando", false);
		}
		transform.forward = dirInput;
	}

	void FixedUpdate () {
		if(dirInput != Vector3.zero)
			rigidbody.velocity = transform.forward * velocidade;
	}
}
