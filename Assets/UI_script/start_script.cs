using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_script : MonoBehaviour {
    public static start_script Static;
    public RectTransform scene_first;
    public RectTransform scene_second;

    float timer = 0;
    // Use this for initialization
    void Start () {
        if(playerData.Static.first_scene_lock == true)
        {
            scene_first.gameObject.SetActive(true);
            playerData.Static.first_scene_lock = false;
        }

    }
	
	// Update is called once per frame
	void Update () {
        if (playerData.Static.lock_start == true)
        {
            timer += Time.deltaTime;
            //Debug.Log(timer);
            if (timer >= 5.0f)
            {
                scene_first.gameObject.SetActive(false);
                scene_second.gameObject.SetActive(false);
            }
        }
    }
    public void start_game()
    {
        scene_second.gameObject.SetActive(true);
        playerData.Static.lock_start = true;
    }
}
