using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	[SerializeField] float m_moveSpeed = 1f;
	private void Update()
	{
		Move();
	}

	void Move()
	{
		if (Vector3.Distance(Gameplay.Player.Position, transform.position) > .5f)
		{
			Vector3 l_dir = (Gameplay.Player.Position - transform.position).normalized;
			transform.position += m_moveSpeed * Time.deltaTime * l_dir;
		}
	}
}
