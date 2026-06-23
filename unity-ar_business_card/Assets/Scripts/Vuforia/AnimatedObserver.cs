using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ARBusinessCardHandler : DefaultObserverEventHandler
{
    // HANDLES
    private RectTransform _baseTransform;
    private List<(RectTransform handle, Vector2 finalPosition)> _toAnimate;
    // ANIMATION
    public float speed = 0.0f;
    public float acceleration = 1f;
    bool mIsAnimating = false;

    protected override void Start()
    {
        base.Start();
        _baseTransform = this.GetComponentInChildren<RectTransform>();
        _toAnimate = new();

        foreach (RectTransform child in _baseTransform.transform)
            _toAnimate.Add((child, child.anchoredPosition));
    }

    void Update()
    {
        if (!mIsAnimating) return;

        speed += acceleration * Time.deltaTime;

        foreach(var child in _toAnimate)
            child.handle.anchoredPosition = Vector2.MoveTowards(child.handle.anchoredPosition, child.finalPosition, speed);
    }

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        speed = 0;
        foreach(var child in _toAnimate)
            child.handle.anchoredPosition = _baseTransform.anchoredPosition;
        mIsAnimating = true;
    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        mIsAnimating = false;
    }
}