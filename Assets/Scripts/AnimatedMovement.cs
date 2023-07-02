using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedMovement : MonoBehaviour
{
    public AnimationCurve curve;
    public Vector3 direction = Vector3.up;
    public float duration = 1;
    public float amplitude = 1;

    void Update()
    {
        transform.position += direction * ((curve.Evaluate(Time.timeSinceLevelLoad / duration) - 0.5f) * amplitude);
    }
}
