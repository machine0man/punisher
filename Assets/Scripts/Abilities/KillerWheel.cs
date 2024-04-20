using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerWheel : MonoBehaviour
{
	[SerializeField] float m_damage = 100f;
	[SerializeField] LayerMask m_hittableLayer;
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (m_hittableLayer == (m_hittableLayer | (1 << collision.gameObject.layer)))
		{
			collision.gameObject.GetComponent<Enemy>().AddDamage(m_damage);
		}
	}

}
