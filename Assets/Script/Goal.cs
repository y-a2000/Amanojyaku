using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public bool HavingKey;
    public AudioClip CardOK;
    public AudioClip CardError;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        HavingKey = false;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Goal")
        {
            if (HavingKey == true)
            {
                
                SceneManager.LoadScene("GameClear");
            }
            else
            {
                audioSource.PlayOneShot(CardError);
            }
        }
        
    }
}
