using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moment : Base_State
{
    public Moment(Data_State data_State):base(data_State) //если мы хотим зайти в скрипт оставив(*) то он не пропустит так как нужен скрипт с даными игрока.KonstryktoR
    { }
    public override void EnEtEr()
    {
        data.Animator.CrossFadeInFixedTime("smeshanie_animation", 0);
        data.axis.y = Physics.gravity.y;
        data.Vvod.on_jump += Jump;
    }
    public override void ExIt()
    {
        data.Vvod.on_jump -= Jump;
    }
    public override void TiK()
    {
       data.Animator.SetFloat("Blend",data.Vvod.Movement.sqrMagnitude>0?1:0,0.1f, Time.deltaTime);
        camera_move(); 
        turn();
        move();
    }
    void Jump()
    {
        data.change_sta_te(new Jump(data));
    }
}
