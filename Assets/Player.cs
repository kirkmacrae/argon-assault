using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 6f;
    [Tooltip("In ms^-1")][SerializeField] float ySpeed = 6f;

    [SerializeField] float xMax = 4.5f;
    [SerializeField] float yMax = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float yOffset = yThrow * ySpeed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        float rawYPos = transform.localPosition.y + yOffset;

        float newX = Mathf.Clamp(rawXPos, -xMax, xMax);
        float newY = Mathf.Clamp(rawYPos, -yMax, yMax);

        transform.localPosition = new Vector3(newX,newY,transform.localPosition.z);
        
    }
}
