using UnityEngine;
using System.Collections;

public class Titulo : MonoBehaviour {

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Return)){
			GetComponent<Animator>().SetTrigger("ComecarJogo");
		}
	}

	void ComecarJogo(){
		JogoManager.i.TrocaTela();
	}
}
