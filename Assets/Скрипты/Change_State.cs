using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_State : MonoBehaviour
{
    private State state; // ������ �� ����������� ������
    void Update()
    {
        state.TiK(); //���������� � ���������

    }
    public void change_sta_te(State state_now )
    {
        state?.ExIt(); //����� �� ���������
        state = state_now; //������ ���������
        state.EnEtEr(); //����� � ���������

    }
}
