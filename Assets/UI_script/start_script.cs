using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_script : MonoBehaviour {

    public RectTransform scene_first;
    public RectTransform scene_second;
    public bool lock_start = false;
    float timer = 0;
    // Use this for initialization
    void Start () {
        scene_first.gameObject.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
        if (lock_start == true)
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
        lock_start = true;
    }
}
