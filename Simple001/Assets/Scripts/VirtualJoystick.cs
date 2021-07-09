using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{   
    [Header("Tweaks")]
    [SerializeField] private float joystickVisualDistance = 100;
    [Header("Logic")]
    private Image container;
    private Image joystick;
    private Vector3 direction;
    public Vector3 Direction { get {return direction; } }

    private void Start()
    {
        var imgs = GetComponentsInChildren<Image>();
        container = imgs[0];
        joystick = imgs[1];
    }

    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos = Vector2.zero;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(
            container.rectTransform , ped.position, ped.pressEventCamera,
            out pos))
        {
            pos.x = (pos.x / container.rectTransform.sizeDelta.x);
            pos.y = (pos.y / container.rectTransform.sizeDelta.y);
            Vector2 refPivot = new Vector2(0.5f, 0.5f);
            Vector2 p = container.rectTransform.pivot;
            pos.x += p.x - 0.5f;
            pos.y += p.y - 0.5f;
            float x = Mathf.Clamp(pos.x, -1, 1);
            float y = Mathf.Clamp(pos.y, -1, 1);
            direction = new Vector3(x, 0 , y).normalized;
            //Debug.Log(direction);
            joystick.rectTransform.anchoredPosition = new Vector3(direction.x * joystickVisualDistance, 
            direction.z * joystickVisualDistance);
        }
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }
    public virtual void OnPointerUp(PointerEventData eventData)
    {
        direction = default(Vector3);
        joystick.rectTransform.anchoredPosition = default(Vector3);
    }


}

