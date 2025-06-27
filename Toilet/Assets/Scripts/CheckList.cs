using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "CheckList", menuName = "ScriptableObjects/CheckList", order = 1)]
public class CheckList : ScriptableObject
{
    public List<CheckListItem> Items;
}
