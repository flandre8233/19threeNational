using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class bagTeamSettingManager : MonoBehaviour
{
    public static bagTeamSettingManager Static;

    public GameObject teamSet;

    int teamLength = 3;

    private void Awake()
    {
        if (Static != null)
        {
            Destroy(this);
        }
        else
        {
            Static = this;
        }
    }

    // Use this for initialization
    void Start()
    {
        updataTeamData();
    }

    public void updataTeamData()
    {
        
        for (int i = 0; i < playerData.Static.teamDetails.GetLength(0) ; i++) // <--依個要改
        {
            for (int j = 0; j < playerData.Static.teamDetails.GetLength(1); j++)
            {
                if (playerData.Static.teamDetails[i, j] == null)
                {
                    continue;
                }
                teamSet.GetComponent<teamSetPage>().teamDetails[i].UnitImage[j].sprite = playerData.Static.teamDetails[i,j].smallPic.GetComponent<Image>().sprite;
                switch (playerData.Static.teamDetails[i, j].Type)
                {
                    case type.fire:
                        teamSet.GetComponent<teamSetPage>().teamDetails[i].UnitPropertyImage[j].sprite = propertyData.Static.propertyDataList[0];
                        break;
                    case type.water:
                        teamSet.GetComponent<teamSetPage>().teamDetails[i].UnitPropertyImage[j].sprite = propertyData.Static.propertyDataList[1];
                        break;
                    case type.wind:
                        teamSet.GetComponent<teamSetPage>().teamDetails[i].UnitPropertyImage[j].sprite = propertyData.Static.propertyDataList[2];
                        break;
                }
                teamSet.GetComponent<teamSetPage>().teamDetails[i].UnitPropertyImage[j].gameObject.GetComponent<RectTransform>().sizeDelta = teamSet.GetComponent<teamSetPage>().teamDetails[i].UnitImage[j].gameObject.GetComponent<RectTransform>().sizeDelta;
            }
        }
        
    }
    public int selectedIndex;
   public  void selectTeamMember(int memberIndex)
    {
        selectedIndex = memberIndex;
    }



}
