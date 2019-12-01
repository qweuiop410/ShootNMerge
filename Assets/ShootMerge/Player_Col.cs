using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Player_Col : MonoBehaviour {

    private GameObject parentObj;

    private int colCount = 0;
    
    private List<GameObject> colObject = new List<GameObject>();

    private bool valueUp = false;
    private float upTimer = 0;

    void Start () {
        parentObj = transform.parent.gameObject;
    }

    void Update()
    {
        transform.position = parentObj.transform.position;

        if (valueUp)
        {
            if (upTimer > 0.1f)
            {
                char sp = '(';
                string[] spName = parentObj.name.Split(sp);
                parentObj.name = int.Parse(spName[0]) + colCount + "(Clone)";
                colCount = 0;

                valueUp = false;
            }
            else
            {
                upTimer += Time.deltaTime * 1;
            }
        }
        else
        {
            upTimer = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col != null && col.transform.tag == "Player" && col.transform.parent.name == parentObj.name)
        {
            if (parentObj.GetComponent<Player_Sm>().dt > col.transform.parent.GetComponent<Player_Sm>().dt)
            {
                valueUp = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col != null && col.transform.tag == "Player" && col.transform.parent.name == parentObj.name)
        {
            if (parentObj.GetComponent<Player_Sm>().dt > col.transform.parent.GetComponent<Player_Sm>().dt)
            {
                colCount++;
                valueUp = true;
                Destroy(col.transform.parent.gameObject);
            }
        }
    }
}
