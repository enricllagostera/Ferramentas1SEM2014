using UnityEngine;
using System.Collections;

public class LavaTrigger : MonoBehaviour {

	// assim que um objeto com collider tocar esse trigger
	void OnTriggerEnter (Collider outro) {
		// pega o objeto do collider e o destroi
		Destroy(outro.gameObject);
	}
}
