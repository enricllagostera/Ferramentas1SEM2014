using UnityEngine;
using System.Collections;

public class Flecha : MonoBehaviour {

	public void CravaFlecha(Transform pai)
	{
		Debug.Log ("crava flecha");
		rigidbody2D.velocity = Vector2.zero;
		Destroy (rigidbody2D);
		Destroy (collider2D);
		transform.parent = pai;
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		CravaFlecha(coll.gameObject.transform);
		if(coll.gameObject.transform.CompareTag("Inimigo")){
			coll.gameObject.GetComponent<Maca>().MataMaca();
		}
	}
}
