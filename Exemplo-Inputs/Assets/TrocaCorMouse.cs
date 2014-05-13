using UnityEngine;
using System.Collections;

public class TrocaCorMouse : MonoBehaviour {
	public Material[] mats;
	int indMat;

	// Use this for initialization
	void Start () {
		indMat = 0;
		renderer.material = mats[indMat];
	}
	
	void OnMouseDown () {
		indMat++;
		if(indMat >= mats.Length) indMat = 0;
		renderer.material = mats[indMat];
	}
}
