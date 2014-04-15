using UnityEngine;
using System.Collections;

public class PlacaScore : MonoBehaviour {

	public TextMesh texto;

	// Use this for initialization
	void Start () {
		if(JogoManager.i.telaAtual == Tela.INGAME){
			GetComponent<Animator>().SetTrigger("ComecouPartida");
		}
		else {

			GetComponent<Animator>().SetTrigger("ComecouGameOver");
		}

	}
	
	// Update is called once per frame
	void Update () {

		if(JogoManager.i.telaAtual == Tela.INGAME){
			string textoVelho = texto.text;
			texto.text = JogoManager.i.score.ToString();
			if(textoVelho != texto.text) GetComponent<Animator>().SetTrigger("Aumentou");
			if(JogoManager.i.gameOver) GetComponent<Animator>().SetTrigger("AcabouPartida");
		}
		else {
			texto.text = JogoManager.i.score.ToString();
			if(Input.GetKey(KeyCode.Return)){
				GetComponent<Animator>().SetTrigger("AcabouGameOver");
			}
		}
	}

	public void AcabaInGame()
	{
		JogoManager.i.TrocaTela();
	}
}
