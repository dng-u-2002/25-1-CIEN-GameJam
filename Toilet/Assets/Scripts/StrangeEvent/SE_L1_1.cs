using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helpers;

[CreateAssetMenu(fileName = "SE_L1_1", menuName = "StrangeEvent/SE_L1_1")]
public class SE_L1_1 : StrangeEvent
{
    public override void OnMapStarted(Transform items)
    {
        base.OnMapStarted(items);


        var target = TransformFinder.FindChild(items, "SE_L1_1");

        var renderer = target.GetComponent<MeshRenderer>();
        renderer.material.color = Color.blue;
    }
}
