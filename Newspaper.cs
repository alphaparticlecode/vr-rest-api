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

public class Newspaper : MonoBehaviour
{
	public Text uiText;
	private StringBuilder data;
	public Renderer rend;
	string headline;

	void Start()
	{
		if (uiText != null)
		{
			uiText.supportRichText = false;
		}

		headline = GetTopArticle();
	}
	
	void Update()
	{
		if (uiText != null)
		{
			uiText.text = headline;
		}
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

