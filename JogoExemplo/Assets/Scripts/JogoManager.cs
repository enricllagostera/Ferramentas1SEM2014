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
	}
	#endregion

	public void Start()
	{
		ObjectPool.CreatePool<Flecha>(flechaPrefab);
		ObjectPool.CreatePool<Maca>(macaPrefab);
	}

	public void Update()
	{
		telaAtual = (Tela)Application.loadedLevel;
		// Avanca as telas - FIXME corrigir o input
		if(Input.GetKey(KeyCode.Escape)){
			TrocaTela();
		}
	}

	public void TrocaTela()
	{
		switch (telaAtual) {
		case Tela.TITULO : 
			telaAtual = Tela.INGAME;
			Application.LoadLevel("Ingame");
			break;
		case Tela.INGAME : 
			if(gameOver){
				telaAtual = Tela.GAMEOVER;
				ObjectPool.Clear();
				Application.LoadLevel("GameOver");
				gameOver = false;
			}
			else {
				telaAtual = Tela.TITULO;
				Application.LoadLevel("Titulo");
			}
			break;
		case Tela.GAMEOVER : 
			telaAtual = Tela.TITULO;
			Application.LoadLevel("Titulo");
			break;
		default:
			break;
		}
	}

	void OnDestroy()
	{

	}
}
