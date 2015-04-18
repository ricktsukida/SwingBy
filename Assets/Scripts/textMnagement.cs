using UnityEngine;
using System.Collections;

public class textMnagement : MonoBehaviour {
	GameObject sun;
	SunRay sunRay;

	// Use this for initialization
	void Start () {
		sun = GameObject.Find("Sun2");
		sunRay = sun.GetComponent<SunRay>();
	
	}
	
	// Update is called once per frame
	void Update () {
		//if(sunRay.sRay()){

		//}
	
	}
}
