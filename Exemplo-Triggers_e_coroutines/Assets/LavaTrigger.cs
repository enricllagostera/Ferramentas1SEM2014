using UnityEngine;
using System.Collections;

public class LavaTrigger : MonoBehaviour {

	public int cubosDestruidos = 0;

	void Update() {
		Physics.gravity = new Vector3(0, -10 + (cubosDestruidos*0.2f), 0);
	}

	// assim que um objeto com collider tocar esse trigger
	void OnTriggerEnter (Collider outro) {
		// pega o objeto do collider e o destroi
		Destroy(outro.gameObject);
		cubosDestruidos++;
	}
}
