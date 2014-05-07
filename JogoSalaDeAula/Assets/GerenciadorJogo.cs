using UnityEngine;
using System.Collections;

public class GerenciadorJogo : MonoBehaviour {

	public static GerenciadorJogo instancia;
	public int score = 0;

	// Use this for initialization
	void Awake () {
		instancia = this;
	}

	void Start() {
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(score);
	}
}

















