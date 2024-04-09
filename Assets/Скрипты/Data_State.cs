using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data_State : Change_State
{
    private float speed_turn = 4;
    public Vector3 axis;
    private CharacterController controller;
    private Animator animator;
    private vvod vvod;
    private Transform camere;
    private float speed = 4;
    private float force_jump =23;
    private float gravity_force = 2;
    public float Gravity_force => gravity_force;
    public float Force_jump => force_jump;
    public float Speed_turn => speed_turn; 
    public float Speed => speed;
    public Transform Camere => camere;
    public CharacterController Controller => controller;
    public vvod Vvod => vvod;   
    public Animator Animator => animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        vvod = GetComponent<vvod>();
        controller = GetComponent<CharacterController>();
        camere = Camera.main.transform;
        speed = 4;
        speed_turn = 4;
        change_sta_te(new Moment(this));
    }
}
