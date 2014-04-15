using UnityEngine;
using System.Collections;

public class SpawnObjetos : MonoBehaviour {

	public float intervalo;
	public Maca prefab;
	public bool ativo = true;

	// Use this for initialization
	void Start () {
		StartCoroutine(Spawn());
	}

	void OnEnable()
	{
		ativo = true;
	}

	void OnDisable()
	{
		ativo = false;
	}
	
	IEnumerator Spawn(){
		while(true){
			if(ativo){
				ObjectPool.Spawn(prefab, transform.position, Quaternion.identity);
			}
			yield return new WaitForSeconds(intervalo);
		}
	}
}
