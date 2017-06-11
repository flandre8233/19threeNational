using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boardData
{
    public Vector2 index;
    public GameObject haveBead;
    public Vector2 position;
    public Vector2 positionCenter;


}

public class boardManager : MonoBehaviour {
    public static boardManager Static;
    public CanvasScaler canvasScaler;

    public boardData[,] boardDataArray;

    Vector2 screenSize;
    Vector2 boardSize;
    Vector2 beadSize;
    public Vector2 boardStartPoint;
    public Vector2 boardSizeNumber;
    public Canvas gameCanvas;
    public GameObject test;
    [Range(0.1f,10.0f)]
    public float spawnCDTime;

    private void Awake() {
        if (Static != null) {
            Destroy(this);
        }
        else {
            Static = this;
        }
        

        //screenSize = new Vector2(Screen.width, Screen.height);
        screenSize = new Vector2(canvasScaler.referenceResolution.x, canvasScaler.referenceResolution.y);
        //boardSize = new Vector2(Screen.width,Screen.height*0.6f ); 4x4
        //boardSize = new Vector2(Screen.width, Screen.height * 0.5f); //6x5 5x4

        boardSize = new Vector2(canvasScaler.referenceResolution.x, canvasScaler.referenceResolution.y * 0.5f); //6x5 5x4

        setBoard( (int)boardSizeNumber.x, (int)boardSizeNumber.y);
        //createTest();
    }

    private void Update() {
        if (gamemanager.Static.isWin || gamemanager.Static.isLoss) {
            return;
        }


        if (Input.GetKeyUp(KeyCode.A) ) {
            randomBoardBeadSpawn();
        }
        if (!inSpawnCD) {
            StartCoroutine(Example());
        }
    }

    bool inSpawnCD = false;
    IEnumerator Example() {
        inSpawnCD = true;
        //randomBoardBeadSpawn();
        multipleSpawnRandomBoardBeadSpawn(2);
        yield return new WaitForSeconds(spawnCDTime);
        inSpawnCD = false;
    }

    void setBoard(int boardWidthNumber,int boardHeightNumber) {
        boardDataArray = new boardData[boardWidthNumber , boardHeightNumber ];
        for (int i = 0; i < (boardHeightNumber ) ; i++) {
            for (int J = 0; J < (boardWidthNumber ) ; J++) {
                //Debug.Log(i+"/"+J );
                boardData item = new boardData();
                item.position = new Vector2(J * (boardSize.x / boardWidthNumber) + (int)((boardStartPoint.x / 100) * canvasScaler.referenceResolution.x), -i * (boardSize.y / boardHeightNumber) - (int)((boardStartPoint.y / 100) * canvasScaler.referenceResolution.y));
                item.positionCenter = item.position;
                item.positionCenter.x += (boardSize.x / boardWidthNumber) / 2;
                item.positionCenter.y -= (boardSize.y / boardHeightNumber) / 2;
                
                item.index = new Vector2(J,i);
                boardDataArray[J, i] = item;

            }
        }
        //beadSize = new Vector2((boardSize.x / boardWidthNumber), (boardSize.y / boardHeightNumber));
        //beadSize = new Vector2((boardSize.x / boardWidthNumber), (boardSize.x / boardWidthNumber) );
        beadSize = new Vector2((boardSize.y / boardHeightNumber) , (boardSize.y / boardHeightNumber));

        //Debug.Log(boardDataArray[0,0].position);

    }



    public void createBead(GameObject spawnObject, Vector2 position) {
        GameObject go = Instantiate(spawnObject, gameCanvas.transform);
        boardDataArray[(int)position.x, (int)position.y].haveBead = go;
        go.GetComponent<RectTransform>().anchoredPosition = boardDataArray[(int)position.x, (int)position.y].positionCenter;
        go.GetComponent<RectTransform>().sizeDelta = beadSize;
        go.GetComponent<beadScript>().boardIndex = boardDataArray[(int)position.x, (int)position.y].index;
    }

    void createBead(GameObject spawnObject, boardData boardData) {
        GameObject go = Instantiate(spawnObject, gameCanvas.transform);
        boardData.haveBead = go;
        go.GetComponent<RectTransform>().anchoredPosition = boardData.positionCenter;
        go.GetComponent<beadScript>().boardIndex = boardData.index;
    }

    public List<Vector2> getTotalEmptyGridIndex(boardData[,] boardDataArray) {
        List<Vector2> totalEmptyGridIndex = new List<Vector2>();
        foreach (var item in boardDataArray) {
            if (item.haveBead == null) {
                totalEmptyGridIndex.Add(item.index);
            }
        }
        return totalEmptyGridIndex;
    }

    void randomBoardBeadSpawn() {
        List<Vector2> totalEmptyGridIndex = getTotalEmptyGridIndex(boardDataArray);
        if (totalEmptyGridIndex.Count <= 0) {
            return;
        }

        int randomIndex = Random.Range(0,totalEmptyGridIndex.Count);
        createBead(randomTypeBead(), totalEmptyGridIndex[randomIndex] );

    }

    void multipleSpawnRandomBoardBeadSpawn(short time) {
        for (int i = 0; i < time; i++) {
            randomBoardBeadSpawn();
        }
    }

    public GameObject[] canSpawnType;
    GameObject randomTypeBead() {
        if (canSpawnType.Length <= 0) {
            return test;
        }
        return canSpawnType[Random.Range(0,canSpawnType.Length)];
    }

    void createTest() {
        foreach (var item in boardDataArray) {
            createBead(test,item);
        }
    }

    public void delDataObject(Vector2 index) {
        boardData data = boardDataArray[(int)index.x, (int)index.y];
        Destroy(data.haveBead);
        data.haveBead = null;
        
    }

    //boardManager.Static.findBead();
    public boardData findBead(Vector2 v2) { //末實測
        if (v2.x < boardStartPoint.x || v2.x > boardSize.x + boardStartPoint.x || v2.y < boardStartPoint.y || v2.y > - boardSize.y + boardStartPoint.y) {
            return null;
        }
        Debug.Log("hit");
        return null;
    }


}
