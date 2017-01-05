/*===============================================================
Product:   	 UI_FRAM
Developer:   tiki - tikicat@live.cn
Company:     ColaCat
Date:        04/01/2017 20:21
================================================================*/
 
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class AnimatedButton : UIBehaviour, IPointerDownHandler {

    [Serializable]
    public class ButtonClickedEvent : UnityEvent { }

    public bool interactable = true;

    [SerializeField]
    private ButtonClickedEvent _onClick = new ButtonClickedEvent();

    private Animator _animator;

    override protected void Start()
    {
        base.Start();
        _animator = GetComponent<Animator>();
        if(!_animator) 
        {
            Debug.LogError("animator is null");
        }
    }


    public ButtonClickedEvent onClick
    {
        get { return _onClick; }
        set { _onClick = value; }
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left || !interactable)
            return;
        Press();
    }

    private void Press()
    {
        if (!IsActive())
            return;
        _animator.SetTrigger("Pressed");
        Invoke("InvokeOnClickAction", 0.1f);
    }
    
    private void InvokeOnClickAction()
    {
        _onClick.Invoke();
    }
}
