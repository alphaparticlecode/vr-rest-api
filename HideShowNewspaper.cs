using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideShowNewspaper : MonoBehaviour {

	private GameObject newspaper_closeup;
	private GameObject table_newspaper;

	// Use this for initialization
	void Start () {
		newspaper_closeup = GameObject.Find("NewspaperCanvas");
		table_newspaper = GameObject.Find("newspaper");
		newspaper_closeup.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		OVRInput.Controller activeController = OVRInput.GetActiveController();

		if( OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) ) {
			if (newspaper_closeup.activeSelf) {
      			newspaper_closeup.SetActive(false);
      			table_newspaper.SetActive(true);
 			}
 			else {
 				newspaper_closeup.SetActive(true);
 				table_newspaper.SetActive(false);
 			}
		}
	}
}
