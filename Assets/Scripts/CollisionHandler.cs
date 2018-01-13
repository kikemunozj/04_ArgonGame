using System;
using System.Collections;using System.Collections.Generic;using UnityEngine;using UnityEngine.SceneManagement;public class CollisionHandler : MonoBehaviour {    [SerializeField] float levelOfDelay = 2f;    [SerializeField] GameObject deathFX;    void OnTriggerEnter(Collider other)    {        StartDeathSequence();        deathFX.SetActive(true);        Invoke("loadScene", levelOfDelay);    }

    private void loadScene()
    {
        SceneManager.LoadScene(1);
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
    }}