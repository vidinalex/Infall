using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public MainEventSystem MES;

    private void Start()
    {
        MES = GameObject.FindGameObjectWithTag("GameController").GetComponent<MainEventSystem>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        MES.ButtonEventDown(this.gameObject.name);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        MES.ButtonEventUp(this.gameObject.name);
    }
}
