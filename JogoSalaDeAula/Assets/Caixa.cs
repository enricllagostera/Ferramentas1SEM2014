using UnityEngine;
using System.Collections;

public class Caixa : MonoBehaviour {

	public float idade;

	void Start(){
	}

	void OnDestroy(){



		///GameObject.Find("gJogo").GetComponent<GerenciadorJogo>().score += Mathf.FloorToInt(idade);

		//GerenciadorJogo.instancia.score += Mathf.FloorToInt(idade);

	}

	void Update(){
		idade += Time.deltaTime;
	}
}






