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

    public int SubBattery; //予備バッテリー
    // Start is called before the first frame update
    void Start()
    {
        //初期設定
        Decrease = 10;
        BatteryAmount = 100;
        CountTime = Decrease; //タイマーを1％減るまでの時間に設定
        ChargeCoolTime = 0.5f;
        SubBattery = 2; //予備2つとメインひとつで計3つ
    }

    // Update is called once per frame
    void Update()
    {
        if (BatteryAmount > 100)
        {
            BatteryAmount = 100;
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftControl))
        {
            CountTime -= Time.deltaTime * 2; //時間で減る
        }
        else
        {
            CountTime -= Time.deltaTime; //時間で減る
        }
            
        
        if (CountTime < 0) //0秒を下回ったら1％減り、減るまでの時間がリセット
        {
            BatteryAmount--;
            CountTime = Decrease;
        }

        

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (BatteryAmount >= 20 || SubBattery != 0)
            {
                BatteryAmount -= 5;
            }
        }

        if (BatteryAmount < 1)
        {
            if (SubBattery > 0)
            {
                BatteryAmount = 100;
                SubBattery--;
            }
            else
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }
    public void BatteryCharge() //充電スポットに触れた時に発動
    {
        if (ChargeTime < 0) //再び100％に
        {
            BatteryAmount++;
            ChargeTime = ChargeCoolTime;
            if (BatteryAmount == 100 && SubBattery < 2)
            {
                BatteryAmount = 1;
                SubBattery++;
            }
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
        if (other.gameObject.name == "ChargeSpot") //ChargeSpotに触れたらBatterCharge関数を起動
        {
            BatteryCharge();
        }
    }
}
