using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pearl : Poolable
{

	[SerializeField] float m_xp = 10f;
	[SerializeField] float m_collectableRange = 1f;
	[SerializeField] LayerMask m_hittableLayer;
	private void Update()
	{
		if (Vector3.Distance(Gameplay.Player.Position, transform.position) < m_collectableRange)
		{
			XPManager.AddXp_s(m_xp);
			EnemySpawner.DestroyPearl_s(this);
		}
	}


	//Collision detection is so heavier than 
	//private void OnCollisionEnter2D(Collision2D collision)
	//{
	//	if (m_hittableLayer == (m_hittableLayer | (1 << collision.gameObject.layer)))
	//	{
	//		XPManager.AddXp_s(m_xp);
	//		Destroy(gameObject);
	//	}
	//}
}
