using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	[SerializeField] float m_moveSpeed = 1f;
	float m_ffSpeedMultiplier = 1f;
	[SerializeField] Rigidbody2D m_rb;
	public float FfSpeedMultiplier { get => m_ffSpeedMultiplier; set => m_ffSpeedMultiplier = value; }

	private void Update()
	{
		Move();
	}

	void Move()
	{
		if (Vector3.Distance(Gameplay.Player.Position, transform.position) > .5f)
		{
			Vector3 l_dir = (Gameplay.Player.Position - transform.position).normalized;
			
			transform.position += m_moveSpeed * m_ffSpeedMultiplier * Time.deltaTime * l_dir;

			//m_rb.MovePosition(transform.position + m_moveSpeed * m_ffSpeedMultiplier * Time.deltaTime * l_dir);
		}
	}
}
