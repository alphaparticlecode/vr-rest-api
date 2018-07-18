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

public class Newspaper : MonoBehaviour
{
	public class BoolMonitor
	{
		public delegate bool BoolGenerator();

		private string m_name = "";
		private BoolGenerator m_generator;
		private bool m_prevValue = false;
		private bool m_currentValue = false;
		private bool m_currentValueRecentlyChanged = false;
		private float m_displayTimeout = 0.0f;
		private float m_displayTimer = 0.0f;

		public BoolMonitor(string name, BoolGenerator generator, float displayTimeout = 0.5f)
		{
			m_name = name;
			m_generator = generator;
			m_displayTimeout = displayTimeout;
		}

		public void Update()
		{
			m_prevValue = m_currentValue;
			m_currentValue = m_generator();

			if (m_currentValue != m_prevValue)
			{
				m_currentValueRecentlyChanged = true;
				m_displayTimer = m_displayTimeout;
			}

			if (m_displayTimer > 0.0f)
			{
				m_displayTimer -= Time.deltaTime;

				if (m_displayTimer <= 0.0f)
				{
					m_currentValueRecentlyChanged = false;
					m_displayTimer = 0.0f;
				}
			}
		}

		public void AppendToStringBuilder(ref StringBuilder sb)
		{
			sb.Append(m_name);

			if (m_currentValue && m_currentValueRecentlyChanged)
				sb.Append(": *True*\n");
			else if (m_currentValue)
				sb.Append(":  True \n");
			else if (!m_currentValue && m_currentValueRecentlyChanged)
				sb.Append(": *False*\n");
			else if (!m_currentValue)
				sb.Append(":  False \n");
		}
	}

	public Text uiText;
	private List<BoolMonitor> monitors;
	private StringBuilder data;
	public Renderer rend;

	void Start()
	{
		if (uiText != null)
		{
			uiText.supportRichText = false;
		}

		data = new StringBuilder(2048);
	}
	
	void Update()
	{
		// data.Length = 0;

		// Debug.Log(data.ToString());

		// if (uiText != null)
		// {
		// 	uiText.text = data.ToString();
		// }
	}
}

