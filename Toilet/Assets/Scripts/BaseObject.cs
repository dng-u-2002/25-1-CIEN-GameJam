using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObject : MonoBehaviour
{
    Transform _ThisTransform;
    public Transform ThisTransform
    {
        get { return _ThisTransform; }
    }
    GameObject _ThisGameObject;
    public GameObject ThisGameObject
    {
        get { return _ThisGameObject; }
    }
    public Vector3 Position
    {
        get { return ThisTransform.position; }
        set { ThisTransform.position = value; }
    }
    public Quaternion Rotation
    {
        get { return ThisTransform.rotation; }
        set { ThisTransform.rotation = value; }
    }
    public Vector3 EulerAngle
    {
        get { return ThisTransform.eulerAngles; }
        set { ThisTransform.eulerAngles = value; }
    }
    public Vector3 LocalPosition
    {
        get { return ThisTransform.localPosition; }
        set { ThisTransform.localPosition = value; }
    }
    public Quaternion LocalRotation
    {
        get { return ThisTransform.localRotation; }
        set { ThisTransform.localRotation = value; }
    }
    public Vector3 LocalEulerAngle
    {
        get { return ThisTransform.localEulerAngles; }
        set { ThisTransform.localEulerAngles = value; }
    }
    //public Sector NowSector;
    //public float TimeMultiplier = 1;

    protected virtual void Awake()
    {
        InitializeInternal();
    }

    public virtual void InitializeInternal()
    {
        _ThisTransform = transform;
        _ThisGameObject = gameObject;
    }

    //public virtual void OnSectorEnter(Sector sector)
    //{
    //    //NowSector = sector;
    //}

    //public virtual void OnSectorExit(Sector sector)
    //{
    //    //NowSector = null;
    //}
}
