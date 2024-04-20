using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] Joystick m_joystick;

	[SerializeField] float m_playerMoveSens = 1f;

	private void Update()
	{
		//Vector3 l_atttackDir = m_joystick.Dir;
		//transform.position += m_playerMoveSens * Time.deltaTime * l_atttackDir;

		//Vector3 l_movementDir = Vector3.zero;
		//if (Input.GetKey(KeyCode.W))
		//{
		//	l_movementDir +=  Vector3.up;
		//}
		//if (Input.GetKey(KeyCode.S))
		//{
		//	l_movementDir += Vector3.down;
		//}
		//if (Input.GetKey(KeyCode.A))
		//{
		//	l_movementDir += Vector3.left;
		//}
		//if (Input.GetKey(KeyCode.D))
		//{
		//	l_movementDir += Vector3.right;
		//}
		//l_movementDir.Normalize();


		Vector3 l_movementDir = m_joystick.Dir;
		transform.position += m_playerMoveSens * Time.deltaTime * l_movementDir;
	}



}
