using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SunRay : MonoBehaviour {
	public GameObject ikarosu;
	bool lookSun;
	GameObject txtsObj;
	Text text;

	// Use this for initialization
	void Start () {
		GameObject txtsObj = GameObject.Find("Text");
		text = txtsObj.GetComponent<Text>();
	
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		if (Physics.Raycast(transform.position, ikarosu.transform.position, out hit))
		{
			// positionから右方向に10進んだ先までにオブジェクトがあればtrueが返されるので、ここの処理が実行される。
			 // 架空の線と衝突したgameObject
			if(hit.transform.gameObject.name.Equals("OVRPlayerController")){
				lookSun = true;
				text.text = "Charging Solar Energy";
			}else{
				lookSun = false;
				text.text = "No Solar Energy";
			}
		}
	}

	public bool sRay(){
		return lookSun;
	}
}
