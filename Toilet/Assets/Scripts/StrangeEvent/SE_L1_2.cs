using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SE_L1_2", menuName = "StrangeEvent/SE_L1_2")]
public class SE_L1_2 : StrangeEvent
{
    public override void OnMapStarted(Transform items)
    {
        base.OnMapStarted(items);

        var obj = Helpers.TransformFinder.FindChild(items, "SE_L1_2");

        obj.GetComponent<MeshRenderer>().material.color = Color.red;
    }
}
