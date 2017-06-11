using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class propertyData : MonoBehaviour
{
    public static propertyData Static;
    public Sprite[] propertyDataList;
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
        propertyDataList = Resources.LoadAll<Sprite>("property");
    }

    public void addProperty(GameObject parentImage, type type)
    {
        GameObject go = Instantiate(new GameObject(), parentImage.transform);
        Image objectImage = go.AddComponent<Image>();
        switch (type)
        {
            case type.fire:
                objectImage.sprite = propertyDataList[0];
                break;
            case type.water:
                objectImage.sprite = propertyDataList[1];
                break;
            case type.wind:
                objectImage.sprite = propertyDataList[2];
                break;
        }
        go.GetComponent<RectTransform>().sizeDelta = parentImage.GetComponent<RectTransform>().sizeDelta;
        objectImage.raycastTarget = false;
    }


}
