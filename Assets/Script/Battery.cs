using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Battery : MonoBehaviour
{
    public int BatteryAmount; //バッテリー量
    public float CountTime; //タイマー
    public float Decrease; //1％減るまでの時間
    public float ChargeTime; //1％チャージのためのタイマー
    public float ChargeCoolTime; //n秒で1％チャージできる
    // Start is called before the first frame update
    void Start()
    {
        //初期設定
        Decrease = 5;
        BatteryAmount = 100;
        CountTime = Decrease; //タイマーを1％減るまでの時間に設定
        ChargeCoolTime = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (BatteryAmount > 100)
        {
            BatteryAmount = 100;
        }
        CountTime -= Time.deltaTime; //時間で減る
        
        if (CountTime < 0) //0秒を下回ったら1％減り、減るまでの時間がリセット
        {
            BatteryAmount -= 1;
            CountTime = Decrease;
        }

        if (Input.GetKeyDown(KeyCode.Z) && BatteryAmount >= 20)
        {
            BatteryAmount -= 5;
        }

        if (BatteryAmount < 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
    public void BatteryCharge() //充電スポットに触れた時に発動
    {
        if (ChargeTime < 0) //再び100％に
        {
            BatteryAmount += 1;
            ChargeTime = ChargeCoolTime;
        } 
        CountTime = Decrease;
        ChargeTime -= Time.deltaTime;
    }
    void BatteryMax()
    {
        BatteryAmount = 100;
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "ChargeSpot")
        {
            BatteryCharge();
        }
    }
}
