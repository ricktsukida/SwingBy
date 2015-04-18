﻿using UnityEngine;
using System.Collections;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

using UnityEngine.UI;

// Change the material when certain poses are made with the Myo armband.
// Vibrate the Myo armband when a fist pose is made.
public class cameraOriantation : MonoBehaviour
{
	// Myo game object to connect with.
	// This object must have a ThalmicMyo script attached.
	public GameObject myo = null;
	public float fSpeed;
	GameObject rotObj;
	private Pose _lastPose = Pose.Unknown;
	GameObject sun;
	SunRay sunRay;
	GameObject light;
	Light lightComp;
	GameObject lightTxt;
	Text   lightText;

	void Start(){
		rotObj = GameObject.Find("RotCamera");
		sun    = GameObject.Find("Sun2");
		sunRay = sun.GetComponent<SunRay>();
		light  = GameObject.Find("Spotlight");
		lightComp = light.GetComponent<Light>();

		lightTxt = GameObject.Find("LightText");
		lightText= lightTxt.GetComponent<Text>();

	
	}
	
	// Update is called once per frame.
	void Update ()
	{
		// Access the ThalmicMyo component attached to the Myo game object.
		ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();
		
		// Check if the pose has changed since last update.
		// The ThalmicMyo component of a Myo game object has a pose property that is set to the
		// currently detected pose (e.g. Pose.Fist for the user making a fist). If no pose is currently
		// detected, pose will be set to Pose.Rest. If pose detection is unavailable, e.g. because Myo
		// is not on a user's arm, pose will be set to Pose.Unknown.
		if (thalmicMyo.pose != _lastPose && sunRay.sRay()) {
			_lastPose = thalmicMyo.pose;
			
			// Vibrate the Myo armband when a fist is made.
			if (thalmicMyo.pose == Pose.Fist) {
				thalmicMyo.Vibrate (VibrationType.Medium);
				Debug.Log("grab");

				Vector3 forwar = Camera.mainCamera.transform.TransformDirection( Vector3.forward );
				var moveDirection = 1.0f * forwar ;
				moveDirection *= fSpeed;
				rigidbody.AddForce(moveDirection);
				
				ExtendUnlockAndNotifyUserAction (thalmicMyo);
				
				// Change material when wave in, wave out or double tap poses are made.
			} else if (thalmicMyo.pose == Pose.FingersSpread) {
				Debug.Log("spread");

				if(!lightComp.enabled){
					lightComp.enabled = true;
					lightText.text = "light: on";
				}else{
					lightComp.enabled = false;
					lightText.text = "light: off";
				}

				ExtendUnlockAndNotifyUserAction (thalmicMyo);
			} 
		}
	}
	
	// Extend the unlock if ThalmcHub's locking policy is standard, and notifies the given myo that a user action was
	// recognized.
	void ExtendUnlockAndNotifyUserAction (ThalmicMyo myo)
	{
		ThalmicHub hub = ThalmicHub.instance;
		
		if (hub.lockingPolicy == LockingPolicy.Standard) {
			myo.Unlock (UnlockType.Timed);
		}
		
		myo.NotifyUserAction ();
	}
}
