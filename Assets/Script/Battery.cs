using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public int BatteryAmount; //バッテリー量
    public float CountTime; //タイマー
    public float Decrease; //1％減るまでの時間
    // Start is called before the first frame update
    void Start()
    {
        //初期設定
        Decrease = 10;
        BatteryAmount = 100;
        CountTime = Decrease;
    }

    // Update is called once per frame
    void Update()
    {
        CountTime -= Time.deltaTime; //時間で減る
        //0秒を下回ったら1％減る。減るまでの時間がリセット
        if (CountTime < 0)
        {
            BatteryAmount -= 1;
            CountTime = Decrease;
        }
    }
    public void BatteryCharge() //充電スポットに触れた時に発動
    {
        BatteryAmount = 100; //再び100％に
        CountTime = Decrease;
    }
}
