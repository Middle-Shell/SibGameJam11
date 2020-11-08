using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transfer : MonoBehaviour
{
    public void Start()
    {
    	InvokeRepeating("Play", 25.0f, 25.0f);
        
    }

    void Play()
    {
        SceneManager.LoadScene("HandGenerator");
        Destroy (this.gameObject);
    }
}
