using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public abstract class CharactorInput : MonoBehaviour
{
    protected Subject<string> _DownKey = new Subject<string>();
    protected Subject<float> _isDownHorizontal = new Subject<float>();

    public IObservable<string> OnDownKey { get { return _DownKey; } }
    public IObservable<float> OnDownHorizontalKey { get { return _isDownHorizontal; } }
}
