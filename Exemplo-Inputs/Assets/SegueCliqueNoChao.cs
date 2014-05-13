using UnityEngine;
using System.Collections;

public class SegueCliqueNoChao : MonoBehaviour {
	Vector3 alvo;
	public float suave;
	
	void Start () {
		alvo = transform.position;
	}

	void Update () {
		if(Input.GetMouseButton(0)){
			RaycastHit contato;
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out contato)) {
				alvo = contato.point;
			}
		}
		rigidbody.MovePosition(Vector3.Lerp(transform.position, alvo, Time.deltaTime * suave));
	}
}
