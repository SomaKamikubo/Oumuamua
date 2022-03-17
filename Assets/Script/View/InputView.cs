using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UniRx;
using UniRx.Triggers;

public class InputView : MonoBehaviour
{
    [SerializeField] Animator animator;
    public event Action<bool> OnSKeyPressedListener;
    public event Action OnSpaceKeyPressedListener;
    public event Action<bool> OnShiftKeyPressedListener;
    public event Action OnKKeyPressedListener;

    public event Action OnButtonClickedLitener;
    //bool isKeyDownS;

    Subject<bool> _isPressSKey = new Subject<bool>();
    Subject<float> _isPressHorizontal = new Subject<float>();
    //ReactiveProperty<bool> _isPressSKey = new ReactiveProperty<bool>(false);
    ReactiveProperty<bool> _isPressSpaceKey = new ReactiveProperty<bool>(false);
    ReactiveProperty<float> _horizontalAmount = new ReactiveProperty<float>(0);

    public IObservable<bool> OnPressSKey { get { return _isPressSKey; } }
    public IObservable<float> OnPressHorizontalKey { get { return _isPressHorizontal; } }
    public IReadOnlyReactiveProperty<bool> OnPressSpaceKey { get { return _isPressSpaceKey; } }
    public IReadOnlyReactiveProperty<float> OnMove { get { return _horizontalAmount; } }


    void Start()
    {
        this.UpdateAsObservable()
            .Select(_ => Input.inputString)
            .Where(_ => Input.anyKeyDown)
            .Subscribe(key => PressKey(key));


        this.UpdateAsObservable()
            .Where(_ => Input.GetKeyDown(KeyCode.Space))
            .Subscribe(_ => PressKey("Space"));

        this.UpdateAsObservable()
            .Where(_ => Input.GetKeyDown(KeyCode.S) || Input.GetKeyUp(KeyCode.S))
            .Subscribe(_ => PressingKey("s", Input.GetKeyDown(KeyCode.S)));
        this.UpdateAsObservable()
            .Where(_ => Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.LeftShift))
            .Subscribe(_ => PressingKey("LeftShift", Input.GetKeyDown(KeyCode.LeftShift)));


        this.UpdateAsObservable()
            .Subscribe(_ => { _isPressHorizontal.OnNext(Input.GetAxis("Horizontal")); });
    }

    void PressKey(string key)
    {
        switch (key)
        {
            //case "s":
            //   OnSKeyPressedListener?.Invoke();
            //    break;

            case "k":
                break;

            case "Space":
                OnSpaceKeyPressedListener?.Invoke();
                break;
        }
    }

    void PressingKey(string key, bool pressing)
    {
        switch (key)
        {
            case "s":
                OnSKeyPressedListener?.Invoke(pressing);
                break;
            case "LeftShift":
                OnShiftKeyPressedListener?.Invoke(pressing);
                break;


        }
    }


    public void SetAnimetor(string bool_name,bool isActing)
    {
        animator.SetBool(bool_name, isActing);
    }

    
}
