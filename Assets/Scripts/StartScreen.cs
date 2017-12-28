using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour {

    float levelLoadDelay = 2f;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        Invoke("LoadFirstScene", levelLoadDelay);
    }

    void LoadFirstScene()

    {
        SceneManager.LoadScene(1);
    }
}
