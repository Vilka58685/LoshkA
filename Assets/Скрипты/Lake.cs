using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lake : MonoBehaviour
{
    private ����_������� ����_�������;
    public int ��������;
    public GameObject head;
    public razdelialka ozero;
    public enum razdelialka
    {
        lava_lake,
        water_lake
    }
    void Start()
    {
        ����_������� = FindObjectOfType<����_�������>();
    }
    private void OnTriggerEnter(Collider Other)
    {
        if (Other.gameObject.CompareTag("Player")&& ozero ==razdelialka.lava_lake )
        {
            InvokeRepeating("time_to_die", 0, 3);
        }
        if (Other.gameObject.CompareTag("Player") && ozero == razdelialka.water_lake)
        {
            InvokeRepeating("Bye_bubble", 0, 1);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && ozero == razdelialka.water_lake)
        {
            CancelInvoke("Bye_bubble");
        }
        if (other.gameObject.CompareTag("Player") && ozero == razdelialka.lava_lake)
        {
            CancelInvoke("time_to_die");
        }
    }
    void Bye_bubble()
    {
        ����_�������.���������_bubble(1);
    }
    void time_to_die()
    {
        ����_�������.izmenenie_Slidera(��������);
    }    
}
