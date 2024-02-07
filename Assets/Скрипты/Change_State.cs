using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_State : MonoBehaviour
{
    private State state; // ссылка на Абстрактный скрипт
    void Update()
    {
        state.TiK(); //Нахождение в состояние

    }
    public void change_sta_te(State state_now )
    {
        state?.ExIt(); //Выйти из состояния
        state = state_now; //Обнова состояния
        state.EnEtEr(); //Зайти в состояние

    }
}
