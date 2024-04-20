using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] float m_health = 100f;

	public Vector3 Position => transform.position;


	public void AddDamage(float a_damageAmt)
	{
		m_health = Mathf.Max(0f, m_health - a_damageAmt);
	}
}