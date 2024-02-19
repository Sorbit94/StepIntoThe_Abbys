using UnityEngine;

public class Elevator : MonoBehaviour
{
    private SliderJoint2D sliderJoint;
    private float motorSpeed = 1f;

    private void Awake()
    {
        sliderJoint = GetComponent<SliderJoint2D>();
    }

    private void Update()
    {
        if (sliderJoint.limitState == JointLimitState2D.LowerLimit)
        {
            motorSpeed = 1f;
        }
        else if (sliderJoint.limitState == JointLimitState2D.UpperLimit)
        {
            motorSpeed = -1f;
        }

        sliderJoint.useMotor = true;
        sliderJoint.motor = new JointMotor2D { motorSpeed = motorSpeed, maxMotorTorque = sliderJoint.motor.maxMotorTorque };
    }
}
