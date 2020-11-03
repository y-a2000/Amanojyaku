using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//NavMeshAgent使うときに必要
using UnityEngine.AI;

//オブジェクトにNavMeshAgentコンポーネントを設置
[RequireComponent(typeof(NavMeshAgent))]

public class Monitoring : MonoBehaviour
{

    [SerializeField] int destPoint = 0;
    private NavMeshAgent agent;

    
    //Character1_Headをセットする,unityちゃんの首振り代用可能
    [SerializeField] GameObject head;
    [SerializeField] float headAngle;
    [SerializeField] Vector3 startHeadAngle;
    bool neckSwitch = true;

    [SerializeField] float quitRange = 5f;
    [SerializeField] bool tracking = false;

    Vector3 playerPos;
    GameObject player;
    float distance;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;

        player = GameObject.Find("Player");

        startHeadAngle = head.transform.localEulerAngles;
    }

    void LateUpdate()
    {
        playerPos = player.transform.position;
        distance = Vector3.Distance(this.transform.position, playerPos);

        //頭から前方3mにRayを出す
        //それにPlayerが当たるとtrueになる
        if (Physics.Raycast(head.transform.position, head.transform.up * 3, 3))
        {
            tracking = true;
        }


        if (tracking)
        {
            //Agentを動かす
            agent.isStopped = false;
            //追跡の時、quitRangeより距離が離れたら中止
            if (distance > quitRange)
                tracking = false;

            //Playerを目標とする
            agent.destination = playerPos;
        }
        else
        {
            //Agentを止める
            agent.isStopped = true;

            //首を左右どちらに動かすか
            if (headAngle >= 45)
            {
                neckSwitch = false;
            }
            else if (headAngle <= -45)
            {
                neckSwitch = true;
            }

            //首の角度に加える数値を増減させる
            if (neckSwitch)
            {
                headAngle += Time.deltaTime * 10;
            }
            else
            {
                headAngle -= Time.deltaTime * 10;
            }

            //首のローカルの角度に初期角度とX軸の首の傾きの数値を加える
            head.transform.localEulerAngles = new Vector3(
                startHeadAngle.x + headAngle,
                startHeadAngle.y, startHeadAngle.z);
        }
    }

    void OnDrawGizmosSelected()
    {
        //頭から出ているRayの線を赤いワイヤーフレームで示す
        Gizmos.color = Color.red;
        Vector3 direction = head.transform.position + head.transform.up * 3;
        Gizmos.DrawLine(head.transform.position, direction);

        //quitRangeの範囲を青いワイヤーフレームで示す
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, quitRange);
    }
}
