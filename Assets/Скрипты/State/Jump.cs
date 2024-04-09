using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : Base_State
{
    public Jump(Data_State data_State) : base(data_State) //если мы хотим зайти в скрипт оставив(*) то он не пропустит так как нужен скрипт с даными игрока
    { }
    public override void EnEtEr()
    {
        data.Animator.CrossFadeInFixedTime("Jumping", 0);
        Debug.Log("you jump");
        data.axis = new Vector3(data.axis.x, data.axis.y+data.Force_jump, data.axis.z); 
    }
    public override void ExIt()
    {
       
    }
    public override void TiK()
    {
        ApplyGravity(data.Gravity_force);
        if (data.axis.y <= 0)
        {
            data.change_sta_te(new Fall(data));
        }
        camera_move();
        turn();
        move();
    }
}
