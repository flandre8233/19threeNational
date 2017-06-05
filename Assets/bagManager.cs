using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum type
{
    fire,
    water,
    wind,
    restone,
    hurt


}

public class bagManager : MonoBehaviour {
    public static bagManager Static;
    public boardData[,] bagDataArray;

    public Canvas gameCanvas;

    Vector2 screenSize;
    Vector2 boardSize; //背包總大小 pixel
    Vector2 cardSmallPicSize;
    public Vector2 boardStartPoint;
    public Vector2 boardSizeNumber; // 橫 直 有幾多粒

    void setBoard(int boardWidthNumber, int boardHeightNumber) {
        bagDataArray = new boardData[boardWidthNumber, boardHeightNumber];



        for (int i = 0; i < (boardHeightNumber); i++) {
            for (int J = 0; J < (boardWidthNumber); J++) {
                Debug.Log(i + "/" + J);
                boardData item = new boardData();
                //item.position = new Vector2(J * (boardSize.x / boardWidthNumber) + (int)((boardStartPoint.x / 100) * Screen.width), -i * (boardSize.y / boardHeightNumber) - (int)((boardStartPoint.y / 100) * Screen.height));
                item.position = new Vector2(J * (boardSize.x / boardWidthNumber) + (int)((boardStartPoint.x / 100) * Screen.width), -i * (boardSize.x / boardWidthNumber) - (int)((boardStartPoint.y / 100) * Screen.height));
                item.positionCenter = item.position;
                item.positionCenter.x += (boardSize.x / boardWidthNumber) / 2;
                //item.positionCenter.y -= (boardSize.y / boardHeightNumber) / 2;
                item.positionCenter.y -= (boardSize.y / boardHeightNumber) / 2;

                item.index = new Vector2(J, i);
                bagDataArray[J, i] = item;

            }
        }
        //cardSmallPicSize = new Vector2((boardSize.x / boardWidthNumber) - 20, (boardSize.y / boardHeightNumber) - 20 );
        cardSmallPicSize = new Vector2((boardSize.x / boardWidthNumber) - 40, (boardSize.x / boardWidthNumber) - 40 );
    }


    
    void serializeBag() {
        boardSizeNumber.y = Mathf.RoundToInt(playerData.Static.playerCardData.Count / boardSizeNumber.x) + 1  ; //<----
        setBoard((int)boardSizeNumber.x, (int)boardSizeNumber.y);
        List<boardData> totalEmptyGridIndex = getTotalEmptyGridIndex(bagDataArray);

        foreach (var item in playerData.Static.playerCardData) {
            createCard(allCharData.Static.allCardData[item.GetComponent<CardData>().Index], totalEmptyGridIndex[0]);
            Debug.Log(totalEmptyGridIndex.Count + "/" + totalEmptyGridIndex[0].positionCenter);
            totalEmptyGridIndex.RemoveAt(0);
        }

    }



    void createCard(GameObject spawnObject, boardData boardData) {
        GameObject go = Instantiate(spawnObject, bagCanvas.Static.canvasNormalBag.transform);
        boardData.haveBead = go;
        go.GetComponent<RectTransform>().anchoredPosition = boardData.positionCenter;
        go.GetComponent<RectTransform>().sizeDelta = cardSmallPicSize;
        go.GetComponent<CardData>().smallPic.GetComponent<RectTransform>().sizeDelta = cardSmallPicSize;
        go.GetComponent<CardData>().smallPic.SetActive(true);
        go.GetComponent<CardData>().smallPic.GetComponent<Button>().onClick.AddListener(bagCanvas.Static.cardButton);
    }
    


    public List<boardData> getTotalEmptyGridIndex(boardData[,] boardDataArray) {
        List<boardData> totalEmptyGridIndex = new List<boardData>();
        for (int i = 0; i < ((int)boardSizeNumber.y); i++) {
            for (int j = 0; j < ((int)boardSizeNumber.x); j++) {
                if (boardDataArray[j,i].haveBead == null) {
                    totalEmptyGridIndex.Add(boardDataArray[j,i] );
                }
            }
        }
        return totalEmptyGridIndex;
    }

    // Use this for initialization
    void Start () {
        if (Static != null) {
            Destroy(this);
        }
        else {
            Static = this;
        }
        screenSize = new Vector2(Screen.width, Screen.height);
        //boardSize = new Vector2(Screen.width, Screen.height * 0.5f);
        boardSize = new Vector2(Screen.width, 4000 );
        serializeBag();



    }
	


	// Update is called once per frame
	void Update () {
		
	}
}
