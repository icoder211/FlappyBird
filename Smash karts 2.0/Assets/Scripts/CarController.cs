using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    public void GetInput() {
        horInput = Input.GetAxis("Horizontal");
        verInput = Input.GetAxis("Vertical");

    }
    public void Steer(){
        steerAngle = maxSteerAngle * horInput;
        rightFront.steerAngle = steerAngle;
        leftFront.steerAngle = steerAngle;
    }
    public void Accelerate() {
        rightFront.motorTorque = verInput*motorTorque;
        leftFront.motorTorque = verInput*motorTorque;
        if(is4wheel) rightBack.motorTorque = verInput*motorTorque;
        if(is4wheel) leftBack.motorTorque = verInput*motorTorque;
    }
    public void UpdateWheelPoses(){
        UpdateWheelPose(rightBack, rightBackT);
        UpdateWheelPose(leftBack, leftBackT);
        UpdateWheelPose(leftFront, leftFrontT);
        UpdateWheelPose(rightFront, rightFrontT);
    }
    public void UpdateWheelPose(WheelCollider _col, Transform _t) {
        Vector3 _pos = _t.position;
        Quaternion _quat = _t.rotation;

        _col.GetWorldPose(out _pos, out _quat);
        _t.position = _pos;
        _t.rotation = _quat;
    }

    private void FixedUpdate() {
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPoses();
    }

    
    public bool is4wheel = false;
    private float horInput, verInput;
    private float steerAngle;
    public WheelCollider leftBack, leftFront, rightBack, rightFront;
    public Transform leftBackT, leftFrontT, rightBackT, rightFrontT;

    public float maxSteerAngle = 30;
    public float motorTorque = 50;
}
