using UnityEngine;
using System.Collections;

// tem que estar na mesma ordem que nos build settings do editor
public enum Tela {
	TITULO,
	INGAME,
	GAMEOVER
}

// essa classe eh um singleton
public class JogoManager : MonoBehaviour {

	public Tela telaAtual;
	public bool gameOver;

	public int score;

	public Maca macaPrefab;
	public Flecha flechaPrefab;

	#region Singleton
	private static JogoManager _instance;

	public static JogoManager i
	{
		get
		{
			if(_instance == null)
			{
				_instance = GameObject.FindObjectOfType<JogoManager>();
				//Tell unity not to destroy this object when loading a new scene!
				DontDestroyOnLoad(_instance.gameObject);
			}
			
			return _instance;
		}
	}
	
	void Awake() 
	{
		if(_instance == null)
		{
			//If I am the first instance, make me the Singleton
			_instance = this;
			DontDestroyOnLoad(this);
		}
		else
		{
			//If a Singleton already exists and you find
			//another reference in scene, destroy it!
			if(this != _instance)
				Destroy(this.gameObject);
		}
		ObjectPool.CreatePool<Flecha>(flechaPrefab);
		ObjectPool.CreatePool<Maca>(macaPrefab);
	}
	#endregion

	public void Update()
	{
		//telaAtual = (Tela)Application.loadedLevel;
	}

	public void TrocaTela()
	{
		switch (telaAtual) {
		case Tela.TITULO :
			Application.LoadLevel("Ingame");
			telaAtual = Tela.INGAME;
			score = 0;

			break;
		case Tela.INGAME : 
			if(gameOver){
				Application.LoadLevel("GameOver");
				ObjectPool.Clear();
				telaAtual = Tela.GAMEOVER;
				gameOver = false;
			}
			else {
				Application.LoadLevel("Titulo");
				telaAtual = Tela.TITULO;
				gameOver = false;
			}
			break;
		case Tela.GAMEOVER : 
			Application.LoadLevel("Titulo");
			telaAtual = Tela.TITULO;
			gameOver = false;
			break;
		default:
			break;
		}
	}

	void OnDestroy()
	{

	}
}
