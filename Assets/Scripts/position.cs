using UnityEngine;
using System.Collections;

public class position : MonoBehaviour {
	public float positionZ;
	public GameObject obj;

	// Use this for initialization
	void Start () {
		//var num = this.transform.position.z;
		//num = num/positionZ;
		//this.transform.position.z = num;
		this.transform.position = new Vector3(this.transform.position.x,
		                                      this.transform.position.y,
		                                      Mathf.Log(this.transform.position.z));
		this.transform.localScale = new Vector3(Mathf.Log (this.transform.localScale.x),
		                                        Mathf.Log (this.transform.localScale.y),
		                                        Mathf.Log (this.transform.localScale.z));
	}
	// Update is called once per frame
	void Update () {
	
	}
}
