using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.EventSystems;


public class ButtonImg : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Sprite normal;
    public Sprite clicked;
    public Button btn;

    public void OnPointerDown(PointerEventData data)
    {
        btn.image.sprite = clicked;
    }

    public void OnPointerUp(PointerEventData data)
    {
        btn.image.sprite = normal;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
