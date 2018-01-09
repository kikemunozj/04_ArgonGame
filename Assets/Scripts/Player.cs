using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [Tooltip("In m/s")][SerializeField] float speed = 10f;
    [SerializeField] float clampFactor = 4f;
    [SerializeField] float positionPitchFactor = -10f;
    [SerializeField] float positionYawFactor = 11f;
    [SerializeField] float positionRollFactor = 5f;
    [SerializeField] float controlPitchFactor = 15f;
    [SerializeField] float controlRollFactor = -30f;


    float xThrow;
    float yThrow;

	void Start () {
		
	}
	
	
	void Update ()
    {
        ProcessTranslation();
        ProcessRotation();
    }

   
    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * speed * Time.deltaTime;
        float rawNewXPos = transform.localPosition.x + xOffset;
        float newXPos = Mathf.Clamp(rawNewXPos, -clampFactor, clampFactor);

        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = -yThrow * speed * Time.deltaTime;
        float rawNewYPos = transform.localPosition.y + yOffset;
        float newYPos = Mathf.Clamp(rawNewYPos, -clampFactor * 0.6f, clampFactor * 0.6f);

        transform.localPosition = new Vector3(newXPos, newYPos, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = transform.localPosition.x * positionRollFactor+ xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

}
