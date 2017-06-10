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
            }
        }
        
 

        //teamSet.GetComponent<teamSetPage>().teamDetails[0].UnitImage[0].sprite = playerData.Static.teamDetails[0, 0].smallPic.GetComponent<Image>().sprite;
        //teamSet.GetComponent<teamSetPage>().teamDetails[0].UnitImage[1].sprite = playerData.Static.teamDetails[0, 1].smallPic.GetComponent<Image>().sprite;
        //teamSet.GetComponent<teamSetPage>().teamDetails[0].UnitImage[2].sprite = playerData.Static.teamDetails[0, 2].smallPic.GetComponent<Image>().sprite;
        //playerData.Static.teamDetails[0.1];

    }
    public int selectedIndex;
   public  void selectTeamMember(int memberIndex)
    {
        selectedIndex = memberIndex;

        //teamSet.GetComponent<teamSetPage>().teamDetails[0].UnitImage[memberIndex].sprite = playerData.Static.playerCardData[memberIndex].smallPic.GetComponent<Image>().sprite;
        //playerData.Static.teamDetails[0, memberIndex] = playerData.Static.playerCardData[memberIndex];
    }



}
