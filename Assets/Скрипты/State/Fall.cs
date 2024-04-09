using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : Base_State
{
    public Fall(Data_State data_State) : base(data_State) //если мы хотим зайти в скрипт оставив(*) то он не пропустит так как нужен скрипт с даными игрока.KonstryktoR
    { }
    public override void EnEtEr()
    {
        data.axis.y = 0;
        data.Animator.CrossFadeInFixedTime("Jumped", 0);
        Debug.Log("you fall");
    }
    public override void TiK()
    {
        ApplyGravity(data.Gravity_force);
        camera_move();
        turn();
        move();
        if (data.Controller.isGrounded)
        {
            data.change_sta_te(new Moment(data));
        }
    }
    public override void ExIt()
    {
       
    }
}
