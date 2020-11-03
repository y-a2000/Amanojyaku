using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubBatteryText : MonoBehaviour
{
    public Battery subBattery;
    public int SubBatteryRemain;
    public GameObject[] BatteryIcons;
    // Start is called before the first frame update
    void Start()
    {
        SubBatteryRemain = subBattery.SubBattery;
    }

    // Update is called once per frame
    void Update()
    {
        SubBatteryRemain = subBattery.SubBattery;
        ChangeIcons();
    }
    void ChangeIcons()
    {
        for (int i = 0; i < BatteryIcons.Length; i++)
        {
            if (SubBatteryRemain <= i)
            {
                BatteryIcons[i].SetActive(false);
            }
            else
            {
                BatteryIcons[i].SetActive(true);
            }
        }
    }
}
