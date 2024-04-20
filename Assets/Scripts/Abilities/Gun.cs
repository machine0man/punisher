using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
	[SerializeField] float m_fireIntervalSec = 1f;
	[SerializeField] float m_bulletSpeed = 10f;
	[SerializeField] PlayerBullet m_prefBullet;

	float m_curTime = 0f;

	private void Update()
	{
		m_curTime += Time.deltaTime;

		if (m_curTime > m_fireIntervalSec)
		{
			Fire();
			m_curTime = 0f;
		}
	}
	void Fire()
	{
		PlayerBullet l_bullet = GetBullet();
		l_bullet.transform.position = transform.position;
		l_bullet.SetData(m_bulletSpeed);
	}
	PlayerBullet GetBullet()
	{
		return Instantiate(m_prefBullet);
	}
}
