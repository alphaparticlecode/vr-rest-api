/************************************************************************************

Copyright   :   Copyright 2017 Oculus VR, LLC. All Rights reserved.

Licensed under the Oculus VR Rift SDK License Version 3.4.1 (the "License");
you may not use the Oculus VR Rift SDK except in compliance with the License,
which is provided at the time of installation or download, or which
otherwise accompanies this software in either electronic or hard copy form.

You may obtain a copy of the License at

https://developer.oculus.com/licenses/sdk-3.4.1

Unless required by applicable law or agreed to in writing, the Oculus VR SDK
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.

************************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System;
using UnityEngine.Networking;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.IO;
using SimpleJSON;

using System.IO.IsolatedStorage;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

using System.Text.RegularExpressions;

public class Newspaper : MonoBehaviour
{
	public Text uiText;
	private StringBuilder data;
	public Renderer rend;
	string first_paragraph;
	string rest_of_article;
	string article_body;
	public Sprite article_image;
	string headline;

	void Start()
	{
		if (uiText != null)
		{
			uiText.supportRichText = false;
		}

		GetTopArticle();
	}
	
	void Update()
	{
		transform.Find("Headline").gameObject.GetComponent<Text>().text = headline;
		transform.Find("First Paragraph").gameObject.GetComponent<Text>().text = first_paragraph;
		transform.Find("Article Body").gameObject.GetComponent<Text>().text = article_body;
		transform.Find("Article Image").gameObject.GetComponent<Image>().sprite = article_image;
	}

	// SEE THE WARNING BELOW
	private static bool TrustCertificate(object sender, X509Certificate x509Certificate, X509Chain x509Chain, SslPolicyErrors sslPolicyErrors) {
    	// all Certificates are accepted
    	return true;
	}

	private void GetTopArticle() {
		// IMPORTANT: DO NOT USE THIS NEXT LINE IN PRODUCTION
		// It implicitly trusts the certificate of whatever URL you're calling
		// and could leave your application vulnerable

		ServicePointManager.ServerCertificateValidationCallback = TrustCertificate;

		// IMPORTANT: REALLY DON'T USE THAT ^^
		// OK, on to the rest of the code...

		HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://dailyprophet.alphaparticle.com/wp-json/wp/v2/posts?per_page=1");
		HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();

        var article = JSON.Parse(jsonResponse);
        headline = article[0]["title"]["rendered"].Value;
        article_body = article[0]["content"]["rendered"].Value;

        var featured_image_url = article[0]["featured_image_url"];
        StartCoroutine(getFeaturedImage(featured_image_url));
       	
		var paragraphs = Regex.Split(article_body, @"<p>([\s\S]+?)<\/p>").Where(l => l != string.Empty).ToArray();
        first_paragraph = paragraphs[0];

        // Remove the first paragraph, because we've already used it
        article_body = Regex.Replace(article_body, "^<p>.*?</p>", "");

        // Strip out HTML tags from markup
        article_body = Regex.Replace(article_body, "<.*?>", String.Empty);   
	}

	IEnumerator getFeaturedImage(string api_url) {
    	WWW www = new WWW(api_url);
		yield return www;
		article_image = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));
 	}
}

