using UnityEngine;
using System.Collections;

public class PlacaScore : MonoBehaviour {

	public TextMesh texto;

	// Use this for initialization
	void Start () {
		GetComponent<Animator>().SetTrigger("ComecouPartida");
	}
	
	// Update is called once per frame
	void Update () {
		string textoVelho = texto.text;
		texto.text = JogoManager.i.score.ToString();
		if(textoVelho != texto.text) GetComponent<Animator>().SetTrigger("Aumentou");
		if(JogoManager.i.gameOver) GetComponent<Animator>().SetTrigger("AcabouPartida");
	}
}
