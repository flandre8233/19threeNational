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


    public GameObject canvasNormalBag;
    public GameObject cardDetailsObject;

    public Text HPText;
    public Text attackText;
    public Text ResilienceText;
    public Text nameText;

    public Text curLevelText;

    public Image bigImage;

    public GameObject bigImageObject;

    bool openCardDetails = false;

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
        openCardDetails = !openCardDetails;
        canvasNormalBag.SetActive(!openCardDetails);
        cardDetailsObject.SetActive(openCardDetails);


        if (cardDetailsObject.activeSelf)
        {
            displayCardDetail();
        }

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
        CardData displayCardData = ButtonEventData.selectedObject.transform.parent.GetComponent<CardData>();
        // CardData displayCardData = ButtonEventData.selectedObject.GetComponentInParent<CardData>();

        bigImage.sprite = displayCardData.bigPic.GetComponent<Image>().sprite;
        bigImage.SetNativeSize();

        nameText.text = displayCardData.cardName;
        HPText.text = displayCardData.HP.ToString();
        attackText.text = displayCardData.ATK.ToString();
        ResilienceText.text = displayCardData.restone.ToString();

        curLevelText.text = displayCardData.level.ToString();
    }

}
