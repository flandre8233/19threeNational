using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class bagCanvas : MonoBehaviour////(1)
, IPointerEnterHandler
, IEventSystemHandler
{
    public static bagCanvas Static;

    public GameObject bagContect;
    public GameObject canvasNormalBag;
    public GameObject cardDetailsObject;
    public GameObject teamSetObject;

    public Text HPText;
    public Text attackText;
    public Text ResilienceText;
    public Text nameText;

    public Text curLevelText;

    public Image bigImage;

    public GameObject bigImageObject;

    bool openCardDetails = false;
    bool openTeamSet = false;

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


    public void cardButton()
    {
        if (openTeamSet)
        {
            int index = bagTeamSettingManager.Static.selectedIndex;
            bagDisplayData displayCardData = ButtonEventData.selectedObject.GetComponent<bagDisplayData>();
            playerData.Static.teamDetails[0, index] = playerData.Static.playerCardData[ displayCardData.inPlayerCardDataListIndex];

            Debug.Log("diu");
            bagTeamSettingManager.Static.updataTeamData();
        }
        else
        {
            openCardDetails = !openCardDetails;
            canvasNormalBag.SetActive(!openCardDetails);
            bagContect.SetActive(!openCardDetails);
            cardDetailsObject.SetActive(openCardDetails);


            if (cardDetailsObject.activeSelf)
            {
                displayCardDetail();
            }

        }

    }

    public void openTeamSetButton()
    {
        openTeamSet = !openTeamSet;
        canvasNormalBag.SetActive(!openTeamSet);
        bagContect.SetActive(!openTeamSet);
        teamSetObject.SetActive(openTeamSet);

        /*
        if (cardDetailsObject.activeSelf)
        {
            displayCardDetail();
        }
        */

    }

    PointerEventData ButtonEventData;

    public void OnPointerEnter(PointerEventData eventData)
    {
        ButtonEventData = eventData;
        Debug.Log("Enter");
    }

    public void displayCardDetail()
    {
        Debug.Log(ButtonEventData.selectedObject);
        //Debug.Log(ButtonEventData.selectedObject.GetComponentInParent<Transform>().name );
        bagDisplayData displayCardData = ButtonEventData.selectedObject.GetComponent<bagDisplayData>();
        // CardData displayCardData = ButtonEventData.selectedObject.GetComponentInParent<CardData>();

        bigImage.sprite = allCharData.Static.allCardData[displayCardData.Index].GetComponent<CardData>().bigPic.GetComponent<Image>().sprite;
        bigImage.SetNativeSize();

        nameText.text = displayCardData.cardName;
        HPText.text = displayCardData.HP.ToString();
        attackText.text = displayCardData.ATK.ToString();
        ResilienceText.text = displayCardData.restone.ToString();

        curLevelText.text = displayCardData.level.ToString();
    }

}
