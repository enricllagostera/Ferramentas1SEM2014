using UnityEngine;
using System.Collections;

public class Jogador2 : MonoBehaviour {

	public float velocidadeX;
	float direcao;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		// indo pra direita
		if(Input.GetAxis("Horizontal") > 0){
			direcao = velocidadeX;
		}
		else if(Input.GetAxis("Horizontal") < 0) {
			direcao = -velocidadeX;
		}
		else {
			direcao = 0;
		}
	}

	void FixedUpdate () {
		rigidbody2D.AddForce(new Vector2(direcao, 0));
	}
}











