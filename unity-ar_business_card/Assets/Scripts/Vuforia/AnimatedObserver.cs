using UnityEngine;
using Vuforia;

public class ARBusinessCardHandler : DefaultObserverEventHandler
{
    [Header("Animation")]
    public Transform OrbitingObject;  // l'objet qui tourne autour
    public float OrbitRadius = 0.1f;  // rayon de l'orbite
    public float OrbitSpeed = 90f;    // degrés par seconde

    bool mIsTracked = false;
    float mCurrentAngle = 0f;

    void Update()
    {
        if (!mIsTracked || OrbitingObject == null) return;

        mCurrentAngle += OrbitSpeed * Time.deltaTime;
        float rad = mCurrentAngle * Mathf.Deg2Rad;

        Vector3 offset = new Vector3(
            Mathf.Cos(rad) * OrbitRadius,
            0f,
            Mathf.Sin(rad) * OrbitRadius
        );

        OrbitingObject.localPosition = offset;
    }

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        mIsTracked = true;
    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        mIsTracked = false;
    }
}