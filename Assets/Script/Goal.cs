using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public bool HavingKey;
    // Start is called before the first frame update
    void Start()
    {
        HavingKey = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Goal" && HavingKey == true)
        {
            SceneManager.LoadScene("GameClear");
        }
    }
}
