using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerWheels : MonoBehaviour
{
	[SerializeField] float m_wheelSpeed = 1f ;
	[SerializeField] KillerWheel m_prefKillerWheel;
	private void Update()
	{
		transform.Rotate(new Vector3(0f,0f, 360f * m_wheelSpeed * Time.deltaTime));
	}
}
