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

    public List<Vector2> alreadySelectedIndexArray;

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

    bool checkAlreadySelected(Vector2 v2)
    {
        foreach (var item in alreadySelectedIndexArray)
        {
            if (item == v2)
            {
                return true;
            }
        }
        return false;
    }

    void setColorInTeamCanvas()
    {
        resetColor();

        foreach (var item in bagManager.Static.bagDataArray)
        {
            foreach (var items in alreadySelectedIndexArray)
            {
                if (item.index == items)
                {
                    item.haveBead.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f,1);
                }

            }
        }

    }

    void resetColor()
    {
        foreach (var item in bagManager.Static.bagDataArray)
        {
            if (item.haveBead != null)
            {
                item.haveBead.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
        }
    }

    public void cardButton()
    {
        if (openTeamSet)
        {
            int index = bagTeamSettingManager.Static.selectedIndex;
            bagDisplayData displayCardData = ButtonEventData.selectedObject.GetComponent<bagDisplayData>();
            if (!checkAlreadySelected(displayCardData.inBagIndex) )
            {
                playerData.Static.teamDetails[0, index] = playerData.Static.playerCardData[displayCardData.inPlayerCardDataListIndex];
                alreadySelectedIndexArray[index] = displayCardData.inBagIndex;
            }
            bagTeamSettingManager.Static.updataTeamData();
            setColorInTeamCanvas();
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
        bagContect.SetActive(true);
        teamSetObject.SetActive(openTeamSet);
        if (openTeamSet)
        {
            setColorInTeamCanvas();
        }
        else
        {
            resetColor();
        }

    }

    PointerEventData ButtonEventData;

    public void OnPointerEnter(PointerEventData eventData)
    {
        ButtonEventData = eventData;
        //Debug.Log("Enter");
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
