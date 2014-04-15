using UnityEngine;
using System.Collections;

public enum Estado {
	Vivo,
	Morto
}

public class Maca : MonoBehaviour {

	public Estado estado = Estado.Vivo;
	public Olhar olhar = Olhar.Esquerda;
	public float velocidadeX;
	public float forcaPulo;
	private Vector3 escala;
	public Transform sensorChao;
	public bool estaNoChao;
	public bool querPular;
	public bool vaiPular;
	private BoxCollider2D colliderSensor;
	public float cooldownPulo;
	public float timerPulo;
	Animator animator;

	// Use this for initialization
	void Start () {
		estado = Estado.Vivo;
		olhar = Olhar.Esquerda;
		escala = transform.localScale;
		timerPulo = 0;
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(timerPulo >= 0) timerPulo -= Time.deltaTime;
		transform.localScale = new Vector3(-(int)olhar * escala.x, escala.y, escala.z);
		// FIXME debug flip
		if(Input.GetKeyDown(KeyCode.P)){
			olhar = (olhar == Olhar.Direita)? Olhar.Esquerda : Olhar.Direita;
		}
		// TODO adicionar animacoes
		if(estado == Estado.Vivo){
			rigidbody2D.fixedAngle = true;
			SegueJogador();
			//animator.SetBool("EstaNoChao", estaNoChao);
			if(estaNoChao && querPular){
				vaiPular = true;
			}
			if(!estaNoChao) vaiPular = false;

		}
		else {
			rigidbody2D.fixedAngle = false;
		}
	}

	void FixedUpdate()
	{
		if(estado == Estado.Vivo && vaiPular && estaNoChao){
			animator.SetTrigger("Pulando");
			timerPulo = cooldownPulo;
			vaiPular = false;
			rigidbody2D.AddForce(new Vector2(velocidadeX * rigidbody2D.mass * (int)olhar, 
			                                 forcaPulo * rigidbody2D.mass));
		}
	}

	void SegueJogador()
	{
		Transform jogador = GameObject.FindWithTag("Player").transform;
		// fazer int. art.
		if(jogador.position.x > transform.position.x){
			olhar = Olhar.Direita;
		}
		else {
			olhar = Olhar.Esquerda;
		}
		querPular = (timerPulo <= 0)? true : false;
	}

	void OnCollisionEnter2D(Collision2D col)
	{

		if(col.gameObject.CompareTag("Chao") && col.transform.position.y < transform.position.y){
			estaNoChao = true;
		}
	}

	public void MataMaca()
	{
		if(estado == Estado.Vivo){
			estado = Estado.Morto;
			JogoManager.i.score++;
			animator.SetTrigger("Morrendo");
		}
	}

	void OnDestroy()
	{
		if(estado == Estado.Vivo) JogoManager.i.score++;
		ObjectPool.Recycle(this);
	}
}

