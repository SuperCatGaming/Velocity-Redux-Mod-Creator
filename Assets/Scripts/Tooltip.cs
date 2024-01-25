using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject tooltipText;

    void Start() {
        tooltipText.SetActive(false);
        tooltipText.GetComponent<TextMeshProUGUI>().SetText(gameObject.GetComponent<TextMeshProUGUI>().text);
    }

    public void OnPointerEnter(PointerEventData eventData) {
        tooltipText.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData) {
        tooltipText.SetActive(false);
    }
}
