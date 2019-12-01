using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Player_Sm : MonoBehaviour {

    [Range(0,10)]
    public float speed = 0;
    public Rigidbody2D rb;
    
    //자식 오브젝트
    public GameObject collider_Ch;

    //생성 시간Z
    public DateTime dt;

    public TextMesh txt;
    
	void Start ()
    {
        dt = DateTime.Now;

        collider_Ch.SetActive(false);
	}

	void Update () {
        rb.AddForce(Vector3.up * speed * Time.deltaTime);

        char sp = '(';
        string[] spName = transform.name.Split(sp);

        txt.text = spName[0];
	}

    private void OnCollisionEnter2D(Collision2D col)
    {
        collider_Ch.SetActive(true);
    }
}
