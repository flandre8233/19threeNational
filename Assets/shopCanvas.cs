using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class shopCanvas : MonoBehaviour {
    payButtonDetails[] payButtonArray = new payButtonDetails[6];
    public Text[] payButtonText = new Text[6];
    public Text magicStoneTotalText;

    public int randomCoinRangeMix;
    public int randomCoinRangeMax;

    int alreadySelectedType;

    public class payButtonDetails
    {
        public int costMoney { get; set; }
        public int magicStone { get; set; }
    }

    public GameObject menuObject;
    public void openClose(int number)
    {
        alreadySelectedType = number;
        menuObject.SetActive(!menuObject.activeSelf);
    }

    void SerializePayButton() {
        for (int i = 0; i < payButtonArray.Length; i++) {
            payButtonArray[i] = new payButtonDetails();
        }

        payButtonArray[0].magicStone = 1;
        payButtonArray[0].costMoney = 8;

        payButtonArray[1].magicStone = 6;
        payButtonArray[1].costMoney = 35;

        payButtonArray[2].magicStone = 12;
        payButtonArray[2].costMoney = 55;

        payButtonArray[3].magicStone = 30;
        payButtonArray[3].costMoney = 142;

        payButtonArray[4].magicStone = 60;
        payButtonArray[4].costMoney = 270;

        payButtonArray[5].magicStone = 85;
        payButtonArray[5].costMoney = 356;

        for (int i = 0; i < payButtonText.Length; i++) {
            payButtonText[i].text = payButtonArray[i].magicStone + "粒魔法石 " + payButtonArray[i].costMoney + "HKD";
        }

    }

    public void ADbutton() {
        //ad here
        playerData.Static.coin += Random.Range(randomCoinRangeMix,randomCoinRangeMax);
    }

    public void payButton() {
        switch (alreadySelectedType) {
            case 0:
                //8hkd
                playerData.Static.magicStone += payButtonArray[alreadySelectedType].magicStone;
                playerData.Static.moneyPayTotal += payButtonArray[alreadySelectedType].costMoney;
                break;
            case 1:
                //35hkd                
                playerData.Static.magicStone += payButtonArray[alreadySelectedType].magicStone;
                playerData.Static.moneyPayTotal += payButtonArray[alreadySelectedType].costMoney;
                break;
            case 2:
                playerData.Static.magicStone += payButtonArray[alreadySelectedType].magicStone;
                playerData.Static.moneyPayTotal += payButtonArray[alreadySelectedType].costMoney;
                //55hkd
                break;
            case 3:
                playerData.Static.magicStone += payButtonArray[alreadySelectedType].magicStone;
                playerData.Static.moneyPayTotal += payButtonArray[alreadySelectedType].costMoney;
                //142hkd
                break;
            case 4:
                playerData.Static.magicStone += payButtonArray[alreadySelectedType].magicStone;
                playerData.Static.moneyPayTotal += payButtonArray[alreadySelectedType].costMoney;
                //270hkd
                break;
            case 5:
                playerData.Static.magicStone += payButtonArray[alreadySelectedType].magicStone;
                playerData.Static.moneyPayTotal += payButtonArray[alreadySelectedType].costMoney;
                //356hkd
                break;
        }
        magicStoneTotalText.text = "你有" + playerData.Static.magicStone + "魔法石";
    }
    private void Awake() {
        SerializePayButton();
        magicStoneTotalText.text = "你有" + playerData.Static.magicStone + "粒魔法石";
    }
}
