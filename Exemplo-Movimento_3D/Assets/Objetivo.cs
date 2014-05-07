using UnityEngine;
using System.Collections;

public class Objetivo : MonoBehaviour {

	// quando algum objeto estiver tocando o trigger
	void OnTriggerStay (Collider outro){
		// se o objeto tiver a tag player
		if(outro.CompareTag("Player")){
			// muda a cor de fundo da camera
			Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor, Color.white, 0.3f);
		}
	}
}
