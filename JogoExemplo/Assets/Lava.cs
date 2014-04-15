using UnityEngine;
using System.Collections;

public class Lava : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col) 
	{
		// mata
		StartCoroutine(Queima(col.gameObject.transform));
	}

	public IEnumerator Queima(Transform objeto)
	{
		foreach (var render in objeto.GetComponentsInChildren<SpriteRenderer>()) {
			render.material.color = Color.red;
		}
		yield return new WaitForSeconds(0.5f);
		Destroy(objeto.gameObject);
	}
}
