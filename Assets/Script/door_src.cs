using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_src : MonoBehaviour
{
    public GameObject door;//Hingjointを付けている子オブジェクトをセットする
    Rigidbody rb;

    void Start()
    {
        rb = door.GetComponent<Rigidbody>();
    }

    public void Open()
    {
        //ドアを開ける
        rb.isKinematic = false;
    }
}