using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMechanics : MonoBehaviour
{

    public float motorForce;
    public float turningForce;
    public float breakingForce;

    private float hozInput;
    private float verInput;
    private bool isBreaking;

    public WheelCollider leftFront;
    public WheelCollider leftRear;
    public WheelCollider rightFront;
    public WheelCollider rightRear;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        GetInput();
        MoveMotors();
        SteerVehicle();
    }


    private void GetInput()
    {
        verInput = Input.GetAxis("Vertical");
        hozInput = Input.GetAxis("Horizontal");
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void MoveMotors()
    {


        float forwardForce = verInput * motorForce * -1;

        leftFront.motorTorque = forwardForce;
        rightFront.motorTorque = forwardForce;


        float breakTorque = isBreaking ? breakingForce : 0;

        leftFront.brakeTorque = breakTorque;
        leftRear.brakeTorque = breakTorque;
        rightFront.brakeTorque = breakTorque;
        rightRear.brakeTorque = breakTorque;
    }

    private void SteerVehicle()
    {
        float steerAngle = hozInput * turningForce;
        leftFront.steerAngle = steerAngle;
        rightFront.steerAngle = steerAngle;
    }


}
