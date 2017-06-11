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

public class bagManager : MonoBehaviour
{
    public static bagManager Static;
    public boardData[,] bagDataArray;

    public Canvas gameCanvas;
    public GameObject emptyObject;


    Vector2 boardSize; //背包總大小 pixel
    Vector2 cardSmallPicSize;
    public Vector2 boardStartPoint;
    public Vector2 boardSizeNumber; // 橫 直 有幾多粒


    int sizeDeltaY = 0;

    void setBoard(int boardWidthNumber, int boardHeightNumber) {
        bagDataArray = new boardData[boardWidthNumber, boardHeightNumber];



        for (int i = 0; i < (boardHeightNumber); i++) {
            for (int J = 0; J < (boardWidthNumber); J++) {

                Debug.Log(i + "/" + J);
                boardData item = new boardData();
                //item.position = new Vector2(J * (boardSize.x / boardWidthNumber) + (int)((boardStartPoint.x / 100) * Screen.width), -i * (boardSize.y / boardHeightNumber) - (int)((boardStartPoint.y / 100) * Screen.height));
                item.position = new Vector2(J * (boardSize.x / boardWidthNumber), -i * (boardSize.x / boardWidthNumber) ) ;
                Debug.Log(item.position);
                item.positionCenter = item.position;
                item.positionCenter.x += (boardSize.x / boardWidthNumber) / 2;
                //item.positionCenter.y -= (boardSize.y / boardHeightNumber) / 2;

                item.positionCenter.y = 0;
               // item.positionCenter.y -= (boardSize.y / boardHeightNumber) / 2;

                item.index = new Vector2(J, i);
                bagDataArray[J, i] = item;

            }
        }
        //cardSmallPicSize = new Vector2((boardSize.x / boardWidthNumber) - 20, (boardSize.y / boardHeightNumber) - 20 );
        cardSmallPicSize = new Vector2((boardSize.x / boardWidthNumber) - 20, (boardSize.x / boardWidthNumber) - 20 );
        sizeDeltaY = (int)((boardSize.x / boardWidthNumber) - 20) ;
    }

    public GameObject displayObject;
    
    void serializeBag() {
        boardSizeNumber.y = Mathf.RoundToInt(playerData.Static.playerCardData.Count / boardSizeNumber.x) + 1  ; //<----
        setBoard((int)boardSizeNumber.x, (int)boardSizeNumber.y);
        List<boardData> totalEmptyGridIndex = getTotalEmptyGridIndex(bagDataArray);

        int i = 0;
        for (int y = 0; y < (boardSizeNumber.y); y++)
        {
            GameObject row = Instantiate(emptyObject, bagContent.transform);
            for (int x = 0; x < (boardSizeNumber.x);x++)
            {
                if ((int)((y * boardSizeNumber.x) + x) >= playerData.Static.playerCardData.Count )
                {
                    break;
                }
                if (playerData.Static.playerCardData[(int)( (y*boardSizeNumber.x) +x)] == null)
                {
                    continue;
                }
                CardData item = playerData.Static.playerCardData[(int)(y * boardSizeNumber.x + x)] ;

                GameObject card = createCard(row,totalEmptyGridIndex[0], item.smallPic.GetComponent<Image>().sprite, item, i);
                //createCard(allCharData.Static.allCardData[item.GetComponent<CardData>().Index], totalEmptyGridIndex[0]);
                Debug.Log(totalEmptyGridIndex.Count + "/" + totalEmptyGridIndex[0].positionCenter);
                totalEmptyGridIndex.RemoveAt(0);

                i++;

            }
            
            row.GetComponent<RectTransform>().sizeDelta = new Vector2(0, sizeDeltaY);
        }


    }

    public GameObject bagContent;

    GameObject createCard( GameObject parent, boardData boardData,Sprite image,CardData objectCardData,int inBagIndex) {
        GameObject go = Instantiate(displayObject, parent.transform);
        bagDisplayData displayData = go.GetComponent<bagDisplayData>();
        //GameObject go = Instantiate(spawnObject, bagContent.transform);
        boardData.haveBead = go;
        displayData.inBagIndex = boardData.index;
        go.GetComponent<RectTransform>().pivot = new Vector2(0.5f,0.5f);
        go.GetComponent<RectTransform>().anchoredPosition = boardData.positionCenter;
        go.GetComponent<RectTransform>().sizeDelta = cardSmallPicSize;

        propertyData.Static.addProperty(go, objectCardData.Type);
        /*
        go.GetComponent<CardData>().smallPic.GetComponent<RectTransform>().sizeDelta = cardSmallPicSize;
        go.GetComponent<CardData>().smallPic.SetActive(true);
        go.GetComponent<CardData>().smallPic.GetComponent<Button>().onClick.AddListener(bagCanvas.Static.cardButton); //加入 onclick listener
         */
        go.GetComponent<Button>().onClick.AddListener(bagCanvas.Static.cardButton); //加入 onclick listener;
        go.GetComponent<Image>().sprite = image;
        deepCopy(inBagIndex,ref displayData, objectCardData);

        return go;
    }



    void deepCopy(int inBagIndex, ref bagDisplayData deepCopyTarget, CardData objectCardData)
    {
        deepCopyTarget.Index = objectCardData.Index;
        deepCopyTarget.inPlayerCardDataListIndex = inBagIndex;
        deepCopyTarget.level = objectCardData.level;
        deepCopyTarget.Type = objectCardData.Type;
        deepCopyTarget.cardName = objectCardData.cardName;
        deepCopyTarget.HP = objectCardData.HP;
        deepCopyTarget.ATK = objectCardData.ATK;
        deepCopyTarget.restone = objectCardData.restone;
        deepCopyTarget.skill = objectCardData.skillCD;
        deepCopyTarget.Probability = objectCardData.Probability;
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
    void Start () {
        //boardSize = new Vector2(Screen.width, Screen.height * 0.5f);
        boardSize = new Vector2( (Screen.width- 100), 0 );
        serializeBag();

    }
	


	// Update is called once per frame
	void Update () {
		
	}
}
