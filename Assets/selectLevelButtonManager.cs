using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class selectLevelButtonManager : MonoBehaviour {

    public void goLevel(int selectLevelIndex)
    {
        SceneManager.LoadScene("aa");
        playerData.Static.enterLevel = selectLevelIndex;

    }

}
