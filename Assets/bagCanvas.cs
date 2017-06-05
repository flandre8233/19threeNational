using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bagCanvas : MonoBehaviour {
    public static bagCanvas Static;


    public GameObject canvasNormalBag;
    public GameObject cardDetailsObject;

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
    }
}
