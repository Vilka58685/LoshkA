using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kortochki : Base_State
{
   public Kortochki(Data_State data_State):base(data_State) //если мы хотим зайти в скрипт оставив(*) то он не пропустит так как нужен скрипт с даными игрока 
   { }
    public override void EnEtEr()
    {
        base.EnEtEr();
    }
    public override void ExIt()
    {
        base.ExIt();
    }
    public override void TiK()
    {
        base.TiK();
    }
}
