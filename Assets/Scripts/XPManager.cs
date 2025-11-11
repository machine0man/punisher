using UnityEngine;

public class XPManager : MonoBehaviour
{
	static XPManager s_instance;

	[SerializeField] float m_xp = 0f;

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

	public static void AddXp_s(float a_xp)
	{
		s_instance.AddXp(a_xp);
	}
	void AddXp(float a_xp)
	{
		m_xp += a_xp;


		float l_xpValueInUI = m_xp / 10f;
		UIMain.SetXpValue(l_xpValueInUI);
	}
}