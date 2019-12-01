using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Sm : MonoBehaviour {

    public GameObject block;
    
    public Color blockColor;
    private int r;

    public SpriteRenderer colorSample;
    public TextMesh nextNum;

    private bool isActive = false;
    private float startX = 0;

    private void Start()
    {
        BlockSetting();
        Debug.Log("Q,W,E,R,T 로 발사합니다.");
    }

    //0.18
    void Update () {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            startX = -1.6f;
            isActive = true;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            startX = -0.8f;
            isActive = true;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            startX = 0f;
            isActive = true;
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            startX = 0.8f;
            isActive = true;
        }
        if (Input.GetKeyUp(KeyCode.T))
        {
            startX = 1.6f;
            isActive = true;
        }

        if (isActive) // 블록 발사
        {
            block.transform.position = new Vector3(startX, -3.5f, 0);
            Instantiate(block);
            BlockSetting();
            isActive = false;
        }
    }

    void BlockSetting()
    {
        r = Random.Range(1, 6);
        block.name = r  +1 +"";

        switch (r)
        {
            case 0:
                colorSample.color = Color.yellow;
                break;

            case 1:
                colorSample.color = Color.red;
                break;

            case 2:
                colorSample.color = Color.blue;
                break;

            case 3:
                colorSample.color = Color.green;
                break;

            case 4:
                colorSample.color = Color.gray;
                break;

            case 5:
                colorSample.color = Color.cyan;
                break;
        }

        block.GetComponent<SpriteRenderer>().color = colorSample.color;
        nextNum.text = block.name;
    }

}
