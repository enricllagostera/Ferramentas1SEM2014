using UnityEngine;
using System.Collections;

public class MoveJogador : MonoBehaviour {

	public float velocidade = 1;
	Vector3 dirInput;
	
	void Update () {
		if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0){
			dirInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			transform.forward = dirInput.normalized;
		}
		else {
			dirInput = Vector3.zero;
		}
	}

	void FixedUpdate () {
		float x = 0, z = 0;
		if(dirInput != Vector3.zero){
			x = transform.forward.x * rigidbody.mass * velocidade * Time.fixedDeltaTime;
			z = transform.forward.z * rigidbody.mass * velocidade * Time.fixedDeltaTime;
		}
		rigidbody.velocity = new Vector3(x, rigidbody.velocity.y, z);
	}
}
