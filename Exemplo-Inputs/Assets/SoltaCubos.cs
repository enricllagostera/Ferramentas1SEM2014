using UnityEngine;
using System.Collections;

public class SoltaCubos : MonoBehaviour {

	public Transform prefabCubo;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Solta")){
			Instantiate(prefabCubo, transform.position, Quaternion.identity);
		}
	}
}
