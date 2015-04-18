using UnityEngine;
using System.Collections;

public class PlanetGravity : MonoBehaviour {
    GameObject planet;	// 引力の発生する星
	public float coefficient;	// 万有引力係数
	public GameObject obj;
	float distanced = 0.0f;
	string name;

	void Start(){
		obj = GameObject.Find("Planets");
	}

	
	void FixedUpdate () {
		foreach (Transform child in obj.transform) {
			//child.Translate(0, 10, 0);
			float dis = Vector3.Distance(this.transform.position, child.transform.position);
			if(distanced == 0.0f ||  dis <= distanced ){
				//planet = child;
				//Debug.Log("planet name is" + child.name);
				 distanced = dis;
				name = child.name;
			}
		}
		distanced = 0.0f;
		// 星に向かう向きの取得
		planet = GameObject.Find(name);
		var direction = planet.transform.position - transform.position;
		// 星までの距離の２乗を取得
		var distance = direction.magnitude;
		distance *= distance;
		// 万有引力計算
		var gravity = coefficient * planet.rigidbody.mass * rigidbody.mass / distance;
		// 力を与える
		Debug.Log(gravity);
		//rigidbody.AddForce(gravity * direction.normalized, ForceMode.Force);
	}
}