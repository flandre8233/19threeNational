﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class damageDisplay : MonoBehaviour {
    public Image myImage;
    public Sprite[] mySprites;
    public Texture2D texture;
    public float textDistance = 0.75f;

    public Transform damageNumberParent;

    // Use this for initialization
    void Start () {

        //ChangeSprite(2,3);
        //spawnDamageDisplay(1345);

       // GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-1, 1) * 50, Random.Range(-1, 1) * 50, -350));
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-20000, 20000) , Random.Range(0, 35000) ));
    }

    public void spawnDamageDisplay(int damage,int type) {
        short digits = 0;
        if (damage != 0)
        {
            digits = (short)getDigits(damage, 0);
        }
        else
        {
            digits = 1;
        }
        float spawnXAxisLimit = ( (textDistance * digits)/ 2 )- (textDistance / 2);
        //Debug.Log(digits + " / " + damage);
        int number = damage;
        for (int i = 0; i < digits; i++) {
            //GameObject emptyGameObject = new GameObject();
            GameObject emptyGameObject = new GameObject();
            //Instantiate(emptyGameObject,.position,Quaternion.identity);
            myImage = emptyGameObject.AddComponent<Image>();
            myImage.color = new Color(myImage.color.r,myImage.color.b,myImage.color.a,0);
            emptyGameObject.transform.parent = damageNumberParent;
            emptyGameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(spawnXAxisLimit - (textDistance * i), 0);

            //emptyGameObject.transform.localPosition = new Vector3( spawnXAxisLimit-(textDistance * i ),0,0);
            //Debug.Log(emptyGameObject.transform.localPosition);
            ChangeSprite(number % 10, type );
            number  /= 10;


            emptyGameObject.transform.position -= emptyGameObject.transform.forward;
        }


    }

    public static int getDigits(int n1, int nodigits) {
        if (n1 == 0)
            return nodigits;

        return getDigits(n1 / 10, ++nodigits);
    }


public void ChangeSprite(int number , int type) {
        myImage.sprite = mySprites[ number+(type*10) ];
    }

    void allSpriteAlpha(float alpha) {

        foreach (var item in damageNumberParent.GetComponentsInChildren<Image>() ) {
            item.color = new Color(item.color.r, item.color.g, item.color.b, alpha);
        }
        
    }

    public float allSpriteAlphaFloat=0.0f;

    // Update is called once per frame
    void Update () {
        allSpriteAlpha(allSpriteAlphaFloat);
        //transform.rotation = Quaternion.LookRotation(-Camera.main.transform.forward);
        //transform.LookAt(Camera.main.transform.position, -Vector3.up);


    }

    public void aniDestroy() {
        //Debug.Log("saff");

        Destroy(gameObject);
    }

}
