using UnityEngine;
using System.Collections;

public class orbitPlanet : MonoBehaviour {
	public float orb;
	public float orbitTime;
	public float offsetA;
	float aLength;
	float bLength;
	public float siita = 0;
	float offsetSpeed = 0.03f;

	void FixedUpdate () {
		if(siita >= 360) {siita = 0;}
		siita += Time.deltaTime * ( offsetSpeed / orbitTime);
		aLength = orb * Mathf.Cos(siita);
		bLength = orb * Mathf.Sin(siita);
		aLength += offsetA;

		this.transform.position = new Vector3(
			aLength,
			this.transform.position.y,
			bLength
			); 
	}

}
