using UnityEngine;
using System.Collections;

public enum Olhar {
	Direita = 1,
	Esquerda = -1
}

public enum Acao {
	Parado = 0,
	Andando = 1,
	Atirando = 2,
	Pulando = 3
}

public class Jogador : MonoBehaviour {

	public Acao acaoAtual;
	public Olhar olhar;

	public Transform visual;

	Animator animator;

	// Use this for initialization
	void Start () {
		acaoAtual = Acao.Parado;
		olhar = Olhar.Direita;
		offsetMira = mira.position - transform.position;
		escala = transform.localScale;
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		inputX = Input.GetAxis("Horizontal");

		if(acaoAtual != Acao.Atirando){
			arco.right = (olhar == Olhar.Direita)? transform.right : -transform.right;
			ControlaMovimento();
		}
		ControlaTiros();
		visual.localScale = new Vector3((int)olhar * escala.x, escala.y, escala.z);
		animator.SetFloat("VelocidadeX", Mathf.Abs(transform.rigidbody2D.velocity.x));
		//float mod = (olhar == Olhar.Esquerda)? -escala.x : escala.x;
	}

	#region Movimento

	public float velocidadeX;
	private float inputX;
	private Vector3 escala;
	public Transform sensorChao;
	public bool estaNoChao;
	public float forcaPulo;
	private bool pular = false;
	
	void ControlaMovimento(){
		
		if(inputX == 0){
			acaoAtual = Acao.Parado;
		}
		else {
			acaoAtual = Acao.Andando;
			if(inputX > 0){
				olhar = Olhar.Direita;
			}
			else {
				olhar = Olhar.Esquerda;
			}
		}

		estaNoChao = Physics2D.Linecast(transform.position, sensorChao.position, 
		                                1<<LayerMask.NameToLayer("Chao"));
		animator.SetBool("EstaNoChao", estaNoChao);
		if(estaNoChao && Input.GetButtonDown("Jump")){
			pular = true;
		}
		if(!estaNoChao) pular = false;
	}

	void FixedUpdate(){
		float novaVelocidade = inputX * velocidadeX;
		if(acaoAtual == Acao.Atirando){
			novaVelocidade = 0;
		}
		transform.rigidbody2D.velocity = new Vector2(novaVelocidade, 
		                                             transform.rigidbody2D.velocity.y);
		if(pular){
			pular = false;
			animator.SetTrigger("Pulando");
			transform.rigidbody2D.AddForce(new Vector2(0, forcaPulo * rigidbody2D.mass));
		}

	}
	
	#endregion

	#region Flechas

	public Transform projetilPrefab;
	public Transform maoFlecha;
	public Transform arco;
	public float forcaFlecha = 100f;
	public Transform mira;
	public float velocidadeMira;
	private Vector2 offsetMira;
	private Transform projetil;
	
	void ControlaTiros (){
		
		// quando acabou de pressionar o botao de tiro
		if(Input.GetButtonDown("Fire1") && acaoAtual != Acao.Atirando){
			animator.SetTrigger("AtirarFlecha");
			acaoAtual = Acao.Atirando;
			//animacao.state.SetAnimation(0, "Idle", true);
			//motor.canControl = false;
			mira.gameObject.SetActive(true);
			
			if(olhar == Olhar.Direita) {
				mira.position = transform.position + new Vector3(offsetMira.x, offsetMira.y);
			}
			else {
				mira.position = transform.position + new Vector3(-offsetMira.x, offsetMira.y);
			}
			projetil = ObjectPool.Spawn(
				projetilPrefab, 
				maoFlecha.position,
				Quaternion.identity
				);
			projetil.GetChild(0).tag = "Untagged"; 
			projetil.rigidbody2D.isKinematic = true;
			projetil.collider2D.isTrigger = true;
		}
		
		// quando esta segurando o botao de tiro
		if(Input.GetButton("Fire1") && acaoAtual == Acao.Atirando){
			float novoAnguloMira = 0f;
			
			float anguloAnterior = 
				Mathf.Atan2(mira.position.y-transform.position.y, 
				            mira.position.x-transform.position.x) * 180 / Mathf.PI;

			projetil.position = maoFlecha.position;

			Vector3 mousePos = Input.mousePosition;
			mousePos.z = Vector3.Distance(Camera.main.transform.position, transform.position); //The distance from the camera to the player object
			Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePos);
			lookPos = lookPos - transform.position;
			float anguloMira = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;

			mira.RotateAround(arco.position, arco.forward, anguloMira-anguloAnterior);
			Vector3 targetDir = mira.position - arco.position;
			float angulo = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
			mira.rotation = Quaternion.AngleAxis(angulo, Vector3.forward);
			projetil.right = mira.right;
			arco.right = projetil.right;
		}
		
		// quando solta o botao de tiro
		if(Input.GetButtonUp("Fire1") && acaoAtual == Acao.Atirando){
			projetil.GetChild(0).tag = "Flechas";
			projetil.rigidbody2D.isKinematic = false;
			projetil.collider2D.isTrigger = false;
			projetil.rigidbody2D.AddForce(projetil.right*forcaFlecha*100);
			mira.gameObject.SetActive(false);
			animator.SetTrigger("DisparouFlecha");
			StartCoroutine(DesarmarArco());
		}
	}

	public IEnumerator DesarmarArco()
	{
		yield return new WaitForSeconds(0.15f);
		acaoAtual = Acao.Parado;
		arco.right = (olhar == Olhar.Direita)? transform.right : -transform.right; // FIXME meio tosco
	}
	#endregion

	public void OnDestroy()
	{
		JogoManager.i.gameOver = true;
		Debug.Log("Jogo acabou");
	}
}
