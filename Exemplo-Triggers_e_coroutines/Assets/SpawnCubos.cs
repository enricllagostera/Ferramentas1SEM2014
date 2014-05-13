using UnityEngine;
using System.Collections;

// olhar o site unitypatterns.com, artigo sobre coroutines

public class SpawnCubos : MonoBehaviour {

	public float intervalo;
	public Transform prefabCubo;
	
	void Start () {
		StartCoroutine(SoltaCubo()); // comeca a corotina
	}
	
	IEnumerator SoltaCubo(){
		// vai funcionar enquanto o objeto estiver ativo
		while (gameObject.activeSelf){
			// cria um novo cubo
			Transform temp = Instantiate(prefabCubo, transform.position, 
			                             Quaternion.identity) as Transform;
			// temp.parent = transform;
			// espera INTERVALO antes de continuar o fluxo
			yield return new WaitForSeconds(intervalo);
		}
	}
}







