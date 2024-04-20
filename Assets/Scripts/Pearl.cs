using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pearl : MonoBehaviour
{

	[SerializeField] float m_xp = 10f;
	[SerializeField] float m_collectableRange = 1f;
	
	private void Update()
	{
		if (Vector3.Distance(Gameplay.Player.Position, transform.position) < m_collectableRange)
		{
			XPManager.AddXp_s(m_xp);
			Destroy(gameObject);
		}
	}
}
