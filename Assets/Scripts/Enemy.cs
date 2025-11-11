using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Poolable
{
	[SerializeField] float m_health = 100f;
	[SerializeField] float m_damagePerSecond = 1f;
	[SerializeField] float m_damageRange = 1f;
	[SerializeField] EnemyController m_controller;
	private void Update()
	{
		if (Vector3.Distance(Gameplay.Player.Position, transform.position) < m_damageRange)
		{
			float a_damage = m_damagePerSecond * Time.deltaTime;
			Gameplay.Player.AddDamage(a_damage);
		}
	}
	public void AddDamage(float a_damageAmt)
	{
		m_health = Mathf.Max(0f, m_health - a_damageAmt);

		if (m_health <= 0f)
		{
			EnemySpawner.DestroyEnemy_s(this);
		}
	}
	public void SetFFSpeedMultiplier(float m_ffSpeedMultiplier)
	{
		m_controller.FfSpeedMultiplier = m_ffSpeedMultiplier;
	}
}
