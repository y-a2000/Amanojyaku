using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeHead : MonoBehaviour
{
    //Inspectorでユニティちゃんの
    //Character1_Headをセットする
    [SerializeField] GameObject head;
    [SerializeField] float headAngle;
    [SerializeField] Vector3 startHeadAngle;
    bool neckSwitch = true;

    void Start()
    {
        //元からの首の位置を記録しておく
        startHeadAngle = head.transform.localEulerAngles;
    }

    //Updateだとアニメーションクリップに入れると首が動かない
    void LateUpdate()
    {
        //首を45度まで動かしたらfalse
        //-45度まで動かしたらtrue
        if (headAngle >= 45)
        {
            neckSwitch = false;
        }
        else if (headAngle <= -45)
        {
            neckSwitch = true;
        }

        //首を少しずつ動かすための数値を時間で増やす
        //trueで足しfalseで引く、を繰り返す
        if (neckSwitch)
        {
            headAngle += Time.deltaTime * 10;
        }
        else
        {
            headAngle -= Time.deltaTime * 10;
        }

        //頭のローカルの角度に、最初の角度に変数を加える
        //ユニティちゃんの場合、首を左右に振るならX軸で動かす
        head.transform.localEulerAngles = new Vector3(
            startHeadAngle.x + headAngle, startHeadAngle.y, startHeadAngle.z);
    }
}