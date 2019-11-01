using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhasePanel : MonoBehaviour
{

	public Text PhaseDisplay;

	private Animator _anims;

	private void Awake()
	{
		_anims = GetComponent<Animator>();
		Utilities._onPhaseChange += PopPhaseUI;
		PhaseDisplay.text = Utilities.currentPhase.ToString() + " Phase";
		
	}

	public void PopPhaseUI()
	{
		PhaseDisplay.text = Utilities.currentPhase.ToString() + " Phase";
		_anims.SetTrigger("Pop");
	}
}
