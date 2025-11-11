using UnityEngine;

public class UIBase : MonoBehaviour
{
	[SerializeField] GameObject m_screen;
	void Show()
	{
		m_screen.SetActive(true);
	}
	void Hide()
	{
		m_screen.SetActive(false);
	}
}