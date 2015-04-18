using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {
	public GameObject planet;
	public float coefficient;
	public float vertex;
	public float p;
	// Use this for initialization
	void Start () {
		vertex *= vertex;
		var sita = 2*(Mathf.Atan((planet.rigidbody.mass)*coefficient/(p*vertex)));
		Debug.Log("sita is = " + sita);
		rigidbody.AddForce(Vector3.back * vertex);
	
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Translate(Vector3.back * vertex * Time.deltaTime);
	
	}
}
