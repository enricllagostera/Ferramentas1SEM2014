using UnityEngine;
using System.Collections;

// enumerador para variavel de controle
public enum Telas {
	Primeira,
	Segunda,
	Terceira,
	Quarta
}

/// <summary>
/// Esse componente controla as principais variaveis 
/// globais do jogo, como tela atual, score, etc. Essa classe eh um Singleton,
/// ou seja, so pode existir uma instancia dela em cada cena.
/// </summary>
public class GerenciadorJogo : MonoBehaviour {

	public static GerenciadorJogo instancia;
	public Telas telaAtual;
	public int score;

	// na primeira inicializacao do componente
	void Awake() {
		// garante que apenas uma instancia desse componente exista
		if(GerenciadorJogo.instancia != null) {
			Destroy(gameObject);
		}
		else {
			instancia = this; // guarda uma referencia a essa instancia na classe estatica
			DontDestroyOnLoad(transform.gameObject); // evita que esse objeto seja destruido quando troca de cena
		}
	}

	// a cada frame do jogo
	void Update(){
		// se o jogador pressionar a tecla de espaco
		if (Input.GetKeyDown(KeyCode.Space)){
			// dependendo de qual eh a tela atual, carrega uma Cena diferente
			switch (telaAtual) {
			case Telas.Primeira : 
				telaAtual = Telas.Segunda; // muda a variavel de controle
				Application.LoadLevel("SegundaCena"); // carrega proxima tela
				break;
			case Telas.Segunda : 
				telaAtual = Telas.Primeira;
				Application.LoadLevel("PrimeiraCena");
				break;
			}
		}
	}
}





