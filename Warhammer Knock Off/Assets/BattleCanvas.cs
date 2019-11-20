using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleCanvas : MonoBehaviour
{

	public static BattleCanvas instance;

	public Image playerImage, enemyImage;
	public Slider playerSlider, enemySlider;
	public Text playerNameUI, enemyNameUI;
	public GameObject highLightPanelPlayer, highLightPanelEnemy;

	private BattleSystem _battleSystem;
	private Animator _anim;
	
	

	//[HideInInspector]public Actor playerActorUI, enemyActorUI;

	private Actor _playerActor, _enemyActor;

	public Actor PlayerActor
	{
		get { return _playerActor; }
		set
		{
			_playerActor = value;
			InitPlayerUI(_playerActor);
		}
	}

	public Actor EnemyActor
	{
		get { return _enemyActor; }
		set
		{
			_enemyActor = value;
			InitEnemyUI(_enemyActor);
		}
	}

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(this.gameObject);
		}

		_battleSystem = FindObjectOfType<BattleSystem>();
		_anim = GetComponentInChildren<Animator>();

		Utilities._onPhaseChange += PopAnims;
	}

	private void Update()
	{
		highLightPanelPlayer.SetActive(_battleSystem.playerTurn);
		highLightPanelEnemy.SetActive(!_battleSystem.playerTurn);
	}

	public void InitPlayerUI(Actor _actor)
	{
		playerImage.sprite = _actor.actorStats.unitSprite;
		
		playerSlider.maxValue = _actor.actorStats.unitHP;
		playerSlider.value = _actor.Unit_HP;
		
		playerNameUI.text = _actor.Unit_Name;
	}

	public void InitEnemyUI(Actor _actor)
	{
		enemyImage.sprite = _actor.actorStats.unitSprite;
		
		enemySlider.maxValue = _actor.actorStats.unitHP;
		enemySlider.value = _actor.Unit_HP;
		
		enemyNameUI.text = _actor.Unit_Name;
	}

	public void UpdatePlayerHP(Actor _actor)
	{
		playerSlider.value = _actor.Unit_HP;
	}

	public void UpdateEnemyHP(Actor _actor)
	{
		enemySlider.value = _actor.Unit_HP;
	}


	public void PopAnims()
	{
		if (Utilities.currentPhase == Phase.Fight || Utilities.currentPhase == Phase.PlayerMovement)
		{
			_anim.SetTrigger("Pop");
			if (Utilities.currentPhase == Phase.PlayerMovement)
			{
				_enemyActor = null;
			}
		}
	}

		
	
}

