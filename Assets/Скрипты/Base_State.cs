using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_State : State
{
    public Data_State data;
    public Base_State(Data_State data_State)
    {
        data = data_State;
    }

    public override void EnEtEr()
    { }

    public override void ExIt()
    { }

    public override void TiK()
    { }
    public void move()
    {
        data.Controller.Move(data.axis* Time.deltaTime);
    }
    public void camera_move()
    {
        Vector3 camera_forward = new (data.Camere.forward.x,0,data.Camere.forward.z);
        Vector3 camera_right = new (data.Camere.right.x, 0, data.Camere.right.z);
        Vector3 move_direction = camera_forward.normalized * data.Vvod.Movement.y + camera_right.normalized * data.Vvod.Movement.x;
        data.axis.z = move_direction.z * data.Speed;
        data.axis.x = move_direction.x * data.Speed;
    }
    public void turn() 
    {
        Vector3 turn_direction = new(data.axis.x, 0, data.axis.z);
        if (turn_direction == Vector3.zero)
        {
            return;
        }
        data.transform.rotation = Quaternion.Slerp(data.transform.rotation, Quaternion.LookRotation(turn_direction), data.Speed_turn * Time.deltaTime);
    }
    protected void ApplyGravity(float gravityModifier) 
    {
        if (data.axis.y > Physics.gravity.y)
        {
            data.axis.y += Physics.gravity.y * Time.deltaTime * gravityModifier;
        }
    }
}
