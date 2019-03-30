using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

	public PlayerStatistics stats;
	public GameObject healthBarObject;
	public GameObject staminaBarObject;
	public Image healthBar;
	public Image staminaBar;
	public Text healthText;

	void Awake() {
		stats = GetComponent<PlayerStatistics>();
		healthBar = healthBarObject.GetComponent<Image>();
		staminaBar = staminaBarObject.GetComponent<Image>();
	}

	void Start () {
		
	}
	
	void Update () {
		healthBar.fillAmount = stats.health / stats.maxHealth;
		staminaBar.fillAmount = stats.stamina / stats.maxStamina;
		healthText.text = stats.health + "/" + stats.maxHealth;
	}
}
