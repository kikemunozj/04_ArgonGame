using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusiPlayer : MonoBehaviour {

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
