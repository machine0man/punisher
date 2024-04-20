using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldForce : MonoBehaviour
{

	[SerializeField] SpriteRenderer m_spriteRender;
	[SerializeField] float m_damagePerSec = 25f;
	[SerializeField] LayerMask m_hittableLayer;
	[SerializeField] float m_forceFieldRadius;

	private void Start()
	{
		m_forceFieldRadius = m_spriteRender.bounds.size.x * .5f;
	}
	void Update()
	{
		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, m_forceFieldRadius);

		foreach (Collider2D collision in colliders)
		{
			if (m_hittableLayer == (m_hittableLayer | (1 << collision.gameObject.layer)))
			{
				collision.gameObject.GetComponent<Enemy>().AddDamage(m_damagePerSec * Time.deltaTime);
			}
		}
	}
}
