using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class buttonScript : MonoBehaviour {
    
    public void changeLevel(string levelName) {
        SceneManager.LoadScene(levelName);
    }

}
