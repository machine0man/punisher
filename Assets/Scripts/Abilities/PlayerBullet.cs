using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
	[SerializeField] float m_damage = 100f;
	[SerializeField] LayerMask m_hittableLayer;
	float m_speed;
	Vector3 m_dir;
	private void Start()
	{
		m_dir = GetClosestEnemyDir();
	}
	public void SetData(float m_bulletSpeed)
	{
		m_speed = m_bulletSpeed;
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (m_hittableLayer == (m_hittableLayer | (1 << collision.gameObject.layer)))
		{
			collision.gameObject.GetComponent<Enemy>().AddDamage(m_damage);
			Destroy(gameObject);
		}
	}
	private void Update()
	{
		transform.position += m_speed * Time.deltaTime * m_dir;
		AutoDestroy();
	}
	Vector3 GetClosestEnemyDir()
	{
		Enemy l_closestEnemy = EnemySpawner.GetClosestEnemy_s();
		if (l_closestEnemy == null)
		{
			return Random.insideUnitCircle.normalized;
		}
		else
			return (l_closestEnemy.transform.position - Gameplay.Player.Position).normalized;
	}
	void AutoDestroy()
	{
		if (Vector3.Distance(Gameplay.Player.Position, transform.position) > 20f)
			Destroy(gameObject);
	}
}
