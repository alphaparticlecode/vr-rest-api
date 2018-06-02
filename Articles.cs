using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Linq;
using System.Linq.Expressions;

public class Articles : MonoBehaviour {
	void Start() {
		StartCoroutine(GetArticle());
	}

	IEnumerator GetArticle() {
		
	}
}