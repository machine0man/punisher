using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Joystick : MonoBehaviour
{
	[SerializeField] bool AutoHideJoystick;
	[SerializeField] bool AutoResetJoystick;
	[SerializeField] bool DynamicJoystick;
	[SerializeField] float m_knobReach = 20f;
	[SerializeField] Vector2 m_dir;
	[SerializeField] Image m_imgJoystickcKnob;
	[SerializeField] GameObject m_uiJoystick;
	[SerializeField] GameObject m_uiJoystickKnob;
	[SerializeField] Transform m_transDefJoystickPos;

	Vector2 m_startPos;
	Vector2 m_endPos;
	Touch m_touch;

	bool m_wasKnobClicked =false;

	public Vector2 Dir { get => m_dir; }
	private void Start()
	{
		m_uiJoystick.SetActive(!AutoHideJoystick);
		m_uiJoystick.transform.position = m_transDefJoystickPos.position;
	}
	private void Update()
	{
		HandleMouseInput();
	}
	void HandleMouseInput()
	{
		if (Input.GetMouseButtonDown(0))
		{
			m_startPos = Input.mousePosition;

			if (DynamicJoystick)
			{
				m_uiJoystick.transform.position = Input.mousePosition;
				m_wasKnobClicked = true;
			}
			else
			{
				//for static joystick, do movement only if knob was clicked

				m_wasKnobClicked = IsClickedOnImage(m_imgJoystickcKnob);
			}
			m_uiJoystick.SetActive(true);
		}
		else
		{
			m_dir = Vector2.zero;
		}

		if (Input.GetMouseButton(0))
		{
			if (m_wasKnobClicked)
			{
				Vector2 l_curPos = Input.mousePosition;

				m_dir = (l_curPos - m_startPos).normalized;
				float m_mag = (l_curPos - m_startPos).magnitude;

				if (m_mag > m_knobReach)
				{
					m_uiJoystickKnob.transform.position = m_uiJoystick.transform.position + new Vector3(m_dir.x, m_dir.y) * m_knobReach;
				}
				else
				{
					m_uiJoystickKnob.transform.position = l_curPos;
				}
			}
		}
		else
		{
			//dont do any calculation
		}
		if (Input.GetMouseButtonUp(0))
		{
			m_uiJoystickKnob.transform.position = m_uiJoystick.transform.position;
			if (AutoHideJoystick) m_uiJoystick.SetActive(false);
			if (AutoResetJoystick) m_uiJoystick.transform.position = m_transDefJoystickPos.transform.position;
			m_wasKnobClicked = false;
		}
	}
	void HandleTouchInput()
	{
		if (Input.touchCount > 0)
		{
			m_touch = Input.GetTouch(0);

			switch (m_touch.phase)
			{
				case TouchPhase.Began:
					Debug.Log("Began");
					break;
				case TouchPhase.Moved:
					Debug.Log("Moved");
					break;
				case TouchPhase.Stationary:
					Debug.Log("Stationary");
					break;
				case TouchPhase.Ended:
					Debug.Log("Ended");
					break;
				case TouchPhase.Canceled:
					Debug.Log("Canceled");
					break;
				default:
					break;
			}

		}
		else
		{

		}
	}
	bool IsClickedOnImage(Image a_image)
	{
		RectTransform l_rectTransform = a_image.rectTransform;

		Vector2 l_localPoint = Input.mousePosition;

		if (RectTransformUtility.RectangleContainsScreenPoint(l_rectTransform, l_localPoint))
		{
			return true;
		}
		else
		{
			return false;
		}

	}
}
