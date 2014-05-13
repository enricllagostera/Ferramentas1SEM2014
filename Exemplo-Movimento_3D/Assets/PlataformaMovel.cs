using UnityEngine;
using System.Collections;

public class PlataformaMovel : MonoBehaviour {

	public Transform[] ancoras;
	public int proximaAncora;
	public float suavizacao;

	// Use this for initialization
	void Start () {
		transform.position = ancoras[0].position;
		proximaAncora = 1;
	}
	
	// Update is called once per frame
	void Update () {
		// interpola a posicao do objeto
		transform.position = Vector3.Lerp(transform.position, ancoras[proximaAncora].position, 
		                                  suavizacao * Time.deltaTime);

		// se chegou bem perto da proxima ancora
		if(Vector3.Distance(transform.position, ancoras[proximaAncora].position) < 0.2f) {
			proximaAncora++; // muda para proxima posicao no vetor de ancoras
			if(proximaAncora >= ancoras.Length) proximaAncora = 0; // se passou da maior posicao, volta a primeira
		}
	}
}
