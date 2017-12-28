using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    [Tooltip("In m/s")][SerializeField] float speed = 10f;
    [SerializeField] float clampFactor = 4f;
    [SerializeField] float pitchFactor = -5f;
    [SerializeField] float yawFactor = 5f;
    [SerializeField] float positionPitchFactor = 1f;
    [SerializeField] float controlPitchFactor = 5f;

    float xThrow;
    float yThrow;

	void Start () {
		
	}
	
	
	void Update ()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * pitchFactor + yThrow;
        float yaw = transform.localPosition.x * yawFactor;
        float roll = transform.localPosition.x * positionPitchFactor;

        transform.localRotation = Quaternion.Euler(pitch , yaw, roll);
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
}
