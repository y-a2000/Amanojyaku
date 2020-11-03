using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key_src : MonoBehaviour
{
    public GameObject door;//対応するドアをセットする
    void OnTriggerEnter(Collider col)//衝突した瞬間
    {
        //プレイヤーが接触したら
        if (col.tag == "Player")
        {
            //ドアを開ける
            door.GetComponent<door_src>().Open();

            //キーは消す
            Destroy(this.gameObject, 1f);
        }
    }
} 
