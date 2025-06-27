using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "CheckListItem", menuName = "ScriptableObjects/CheckListItem", order = 1)]
public class CheckListItem : ScriptableObject
{
    public bool IsChecked;
    public string Text;

    public virtual void OnMapStarted(Transform items)
    {

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
