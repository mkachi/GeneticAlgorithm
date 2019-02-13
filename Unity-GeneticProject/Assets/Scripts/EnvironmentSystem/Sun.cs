using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sun
    : MonoBehaviour
{
    [SerializeField]
    private Time _time = null;

    private void Awake()
    {
        _time.HourEventHandler += MoveSun;
    }

    private void MoveSun()
    {
        float angle = (_time.Hour / 24.0f) * 180.0f;
        transform.localRotation = Quaternion.AngleAxis(angle, Vector3.right);
    }
}