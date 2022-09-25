using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using DG.Tweening;

public class InfoOnHoverScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI text;

    public void OnPointerEnter(PointerEventData eventData) {
        text.DOFade(1, 0.3f);
    }

    public void OnMouseEnter() {
        text.DOFade(1, 0.3f);
    }

    public void OnPointerExit(PointerEventData eventData) {
        text.DOFade(0, 0.3f);
    }

    public void OnMouseExit() {
        text.DOFade(0, 0.3f);
    }
}
