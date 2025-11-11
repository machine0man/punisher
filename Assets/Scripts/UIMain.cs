using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMain : UIBase
{
	static UIMain s_instance;

	[SerializeField] Image m_imgXpFill;
 
	#region Unity Methods
	private void Awake()
	{
		s_instance = this;
	}
	private void OnDestroy()
	{
		s_instance = null;
	}
	#endregion

	public static void SetXpValue(float a_fillAmount)
	{
		s_instance.m_imgXpFill.fillAmount = a_fillAmount;
	}
}
