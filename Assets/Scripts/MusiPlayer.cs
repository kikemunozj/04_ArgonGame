using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusiPlayer : MonoBehaviour {

    private void Awake()
    {
        int numbMusicPlayer = FindObjectsOfType<MusiPlayer>().Length;
        if (numbMusicPlayer > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        
    }
}
