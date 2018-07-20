using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.IO;
using SimpleJSON;

public class Article : MonoBehaviour {

	// Use this for initialization
	void Start () {
		string headline = GetTopArticle();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private string GetTopArticle() {
		HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://dailyprophet.alphaparticle.com/wp-json/wp/v2/posts?per_page=1");
		HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();

        var article = JSON.Parse(jsonResponse);
        string headline = article[0]["title"]["rendered"].Value;

        return headline;
	}
}
