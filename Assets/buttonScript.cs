using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class buttonScript : MonoBehaviour {
    
    public void changeLevel(string levelName) {
        gameStatus.Static.alreadyOpenTitle = true;
        SceneManager.LoadScene(levelName);
    }

}
