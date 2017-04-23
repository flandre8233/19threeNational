using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    Vector2 boardSize;
    Vector2 cardSmallPicSize;
    public Vector2 boardStartPoint;
    public Vector2 boardSizeNumber;




    void setBoard(int boardWidthNumber, int boardHeightNumber) {
        bagDataArray = new boardData[boardWidthNumber, boardHeightNumber];
        for (int i = 0; i < (boardHeightNumber); i++) {
            for (int J = 0; J < (boardWidthNumber); J++) {
                Debug.Log(i + "/" + J);
                boardData item = new boardData();
                item.position = new Vector2(J * (boardSize.x / boardWidthNumber) + (int)((boardStartPoint.x / 100) * Screen.width), -i * (boardSize.y / boardHeightNumber) - (int)((boardStartPoint.y / 100) * Screen.height));
                item.positionCenter = item.position;
                item.positionCenter.x += (boardSize.x / boardWidthNumber) / 2;
                item.positionCenter.y -= (boardSize.y / boardHeightNumber) / 2;
                item.index = new Vector2(J, i);
                bagDataArray[J, i] = item;

            }
        }
        cardSmallPicSize = new Vector2((boardSize.x / boardWidthNumber), (boardSize.y / boardHeightNumber));
    }



    public List<GameObject> allCardData;
    void serializeBag() {
        setBoard((int)boardSizeNumber.x, (int)boardSizeNumber.y);
        List<boardData> totalEmptyGridIndex = getTotalEmptyGridIndex(bagDataArray);

        foreach (var item in playerData.Static.playerCardData) {
            createCard(allCardData[item.GetComponent<CardData>().Index], totalEmptyGridIndex[0]);
            Debug.Log(totalEmptyGridIndex.Count + "/" + totalEmptyGridIndex[0].positionCenter);
            totalEmptyGridIndex.RemoveAt(0);
        }

    }

    void createCard(GameObject spawnObject, boardData boardData) {
        GameObject go = Instantiate(spawnObject, gameCanvas.transform);
        boardData.haveBead = go;
        go.GetComponent<RectTransform>().anchoredPosition = boardData.positionCenter;
        go.GetComponent<RectTransform>().sizeDelta = cardSmallPicSize;
        go.GetComponent<CardData>().smallPic.GetComponent<RectTransform>().sizeDelta = cardSmallPicSize;
        go.GetComponent<CardData>().smallPic.SetActive(true);

    }

    public List<boardData> getTotalEmptyGridIndex(boardData[,] boardDataArray) {
        List<boardData> totalEmptyGridIndex = new List<boardData>();
        for (int i = 0; i < ((int)boardSizeNumber.x); i++) {
            for (int j = 0; j < ((int)boardSizeNumber.y); j++) {
                if (boardDataArray[j,i].haveBead == null) {
                    totalEmptyGridIndex.Add(boardDataArray[j,i] );
                }
            }
        }
        foreach (var item in boardDataArray) {
            
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
        boardSize = new Vector2(Screen.width, Screen.height * 0.5f);
        serializeBag();

        

    }
	


	// Update is called once per frame
	void Update () {
		
	}
}
