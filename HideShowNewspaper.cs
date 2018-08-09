using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideShowNewspaper : MonoBehaviour {

	private GameObject newspaper;

	// Use this for initialization
	void Start () {
		newspaper = GameObject.Find("NewspaperCanvas");
		newspaper.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		OVRInput.Controller activeController = OVRInput.GetActiveController();

		if( OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) ) {
			if (newspaper.activeSelf) {
      			newspaper.SetActive(false);
 			}
 			else {
 				newspaper.SetActive(true);
 			}
		}
	}
}
