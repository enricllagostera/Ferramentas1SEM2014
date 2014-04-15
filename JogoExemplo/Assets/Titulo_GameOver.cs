using UnityEngine;
using System.Collections;

public class Titulo_GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Animator>().SetTrigger("ComecouGameOver");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Return)){
			GetComponent<Animator>().SetTrigger("AcabouGameOver");
		}
	}

	void AcabaGameOver(){
		JogoManager.i.TrocaTela();
	}
}
