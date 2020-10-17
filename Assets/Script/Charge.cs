using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : MonoBehaviour
{
    public Battery battery;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        //プレイヤータグのオブジェクトに触れたら「BatteryCharge」関数を起動
        if (collision.gameObject.CompareTag("Player"))
        {
            battery.BatteryCharge();
        } 
    }
}
