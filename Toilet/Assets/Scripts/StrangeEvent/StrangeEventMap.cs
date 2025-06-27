using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;

public class StrangeEventMap : BaseObject
{
    [SerializeField] CheckList List;

    [SerializeField] Transform ItemContainer;

    [SerializeField] CheckListUIDrawer ListDrawer;



    private void Start()
    {
        for (int i = 0; i < List.Items.Count; i++)
        {
            List.Items[i].OnMapStarted(ItemContainer);
        }

        ListDrawer.Initialize(List);
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    if (CheckIsPlayerSuccessed())
        //    {
        //        Debug.Log("Player Successed!");
        //    }
        //    else
        //    {
        //        Debug.Log("Player Failed!");
        //    }
        //}
    }


    public bool CheckIsPlayerSuccessed()
    {
        for(int i = 0; i < List.Items.Count; i++)
        {
            //����
            if(List.Items[i].IsChecked == ListDrawer.ItemDrawers[i].IsChecked)
            {

            }
            //����
            else
            {
                return false;
            }
        }
        return true;
    }
}
