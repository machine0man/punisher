using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
	static Gameplay s_instance;
	[SerializeField] Player m_player;

	public static Player Player { get => s_instance.m_player; }

	#region Unity Methods
	private void Awake()
	{
		s_instance = this;
	}
	private void OnDestroy()
	{
		s_instance = null;
	}
	#endregion





}
