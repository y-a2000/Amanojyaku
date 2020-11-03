using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door: MonoBehaviour
{
    public bool IsLocked = false;  //ドアに鍵がかかっているか
    public bool DoorClosed = true;  //ドアが現在閉まっているか
    public float OpenRotationAmount = 90;  //ドアが何度開くか(90で直角に開く)
    public float RotationSpeed = 1f;  //ドアが開く速度
    public float MaxDistance = 3.0f;  //ドアからどれほど離れていても開けられるか
    private Collider DoorCollider;  //ドアのコライダー(DoorCollider.enabled = falseで当たり判定消失)
    private GameObject Player;  //ドアを開けるプレイヤーのGameObject
    private Camera Cam;  //メインカメラ

    float StartAngle = 0;
    float EndAngle = 0;
    float LerpTime = 1f;  //ドアを開ける際にかかる時間
    float CurrentLerpTime = 0;  //ドアを開ける際の現在の移動時間
    bool Rotating;

    void Start()
    {
        DoorCollider = GetComponent<BoxCollider>();
        Player = GameObject.FindGameObjectWithTag("Player");
        Cam = Camera.main;
    }
    void Update()
    {
        if (Rotating)
        {
            Rotate();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            TryToOpen();
        }
    }

    void TryToOpen()
    {
        if (Mathf.Abs(Vector3.Distance(transform.position, Player.transform.position)) <= MaxDistance)
        {
            Ray ray = Cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            RaycastHit hit;
            if (DoorCollider.Raycast(ray, out hit, MaxDistance))
            {
                if (IsLocked == false)
                {
                    if (DoorClosed)
                        Open();
                    else
                        Close();
                }
            }
        }
    }

    void Rotate()
    {
        CurrentLerpTime += Time.deltaTime * RotationSpeed;
        if (CurrentLerpTime > LerpTime)
        {
            CurrentLerpTime = LerpTime;
        }
        float _Perc = CurrentLerpTime / LerpTime;  //今全体の何割進んでいるか
        float _Angle = Clerp(StartAngle, EndAngle, _Perc);  //今現在の角度
        transform.localEulerAngles = new Vector3(transform.eulerAngles.x, _Angle, transform.eulerAngles.z);
        if (CurrentLerpTime == LerpTime)
        {  //回転し終えたら
            Rotating = false;
            DoorCollider.enabled = true;
        }
    }

    void Open()
    {
        DoorCollider.enabled = false;  //コライダーを無効化
        DoorClosed = false;
        StartAngle = transform.localEulerAngles.y;
        EndAngle = transform.localEulerAngles.y + OpenRotationAmount;
        CurrentLerpTime = 0;
        Rotating = true;
    }

    void Close()
    {
        DoorCollider.enabled = false;
        DoorClosed = true;
        StartAngle = transform.localEulerAngles.y;
        EndAngle = transform.localEulerAngles.y - OpenRotationAmount;
        CurrentLerpTime = 0;
        Rotating = true;
    }

    public static float Clerp(float start, float end, float value)
    {
        float min = 0.0f;
        float max = 360.0f;
        float half = Mathf.Abs((max - min) / 2.0f);//half the distance between min and max
        float retval = 0.0f;
        float diff = 0.0f;
        if ((end - start) < -half)
        {
            diff = ((max - start) + end) * value;
            retval = start + diff;
        }
        else if ((end - start) > half)
        {
            diff = -((max - end) + start) * value;
            retval = start + diff;
        }
        else retval = start + (end - start) * value;
        return retval;
    }
}
