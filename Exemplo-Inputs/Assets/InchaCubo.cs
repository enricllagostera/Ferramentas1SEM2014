using UnityEngine;
using System.Collections;

public class InchaCubo : MonoBehaviour {

	bool ativo;
	public float fatorInchaco;
	public Material matAtivo;
	public Material matInativo;
	
	void Start () {
		ativo = true;
		transform.rigidbody.useGravity = false;
	}

	void Update () {





		if(Input.GetButton("Solta") && ativo) {
			transform.localScale = transform.localScale * fatorInchaco;
			transform.renderer.material = matAtivo;
		}
		if(Input.GetButtonUp("Solta") && ativo){
			transform.rigidbody.useGravity = true;
			ativo = false;
			transform.renderer.material = matInativo; 
		}
	}
}
