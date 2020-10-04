using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueScript : MonoBehaviour
{
    float xAngle, yAngle, zAngle;
    public float rotationSpeed;

    float totalPower = 0;
    float chargeRate = 1;
    public GameObject cueBall;

    // Start is called before the first frame update
    void Start()
    {
        xAngle = 0;
        yAngle = 0;
        zAngle = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.A))
        {
            
            yAngle += rotationSpeed * Time.deltaTime;
            transform.Rotate(xAngle, yAngle, zAngle);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            yAngle = 0;
        }
        

        if (Input.GetKey(KeyCode.D))
        {            
            yAngle -= rotationSpeed * Time.deltaTime;
            transform.Rotate(xAngle, yAngle, zAngle);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            yAngle = 0;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            totalPower += chargeRate * Time.deltaTime;
            Debug.Log(totalPower);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            cueBall.GetComponent<Rigidbody>().AddForce(-totalPower, 0, 0, ForceMode.Impulse);
            totalPower = 0;
        }

    }
}
