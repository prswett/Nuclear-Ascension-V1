using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RelicInformation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	public GameObject tooltip;
	public Text tooltipText;
	public string description;
	RectTransform rect;
	void Awake()
	{
		tooltipText = tooltip.GetComponentInChildren<Text>();
		rect = GetComponent<RectTransform>();
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		tooltip.transform.position = new Vector3(transform.position.x + rect.rect.width, transform.position.y + rect.rect.height / 1.5f);
		tooltipText.text = " " + description + " ";
		tooltip.SetActive(true);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tooltip.SetActive(false);
	}
}
