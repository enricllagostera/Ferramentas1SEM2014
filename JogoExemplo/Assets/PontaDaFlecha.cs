using UnityEngine;
using System.Collections;

public class PontaDaFlecha : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D coll)
	{
		transform.parent.GetComponent<Flecha>().CravaFlecha(coll.gameObject.transform);
		if(coll.gameObject.transform.CompareTag("Inimigo")){
			coll.gameObject.GetComponent<Maca>().MataMaca();
		}
		Destroy (gameObject);
	}
}
