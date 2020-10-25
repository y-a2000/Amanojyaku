using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryText : MonoBehaviour
{
    public Battery battery;
    public int BatteryRemain;
    // Start is called before the first frame update
    void Start()
    {
        BatteryRemain = battery.BatteryAmount;
    }

    // Update is called once per frame
    void Update()
    {
        BatteryRemain = battery.BatteryAmount;
        GetComponent<Text>().text = "現在のバッテリー残量: " + BatteryRemain + "%";
    }
}
