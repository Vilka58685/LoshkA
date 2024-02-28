using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lake : MonoBehaviour
{
    private ����_������� ����_�������;
    public int ��������;
    public ParticleSystem effekt, effekt_two;
    public GameObject head;
    public razdelialka ozero;
    public enum razdelialka
    {
        lava_lake,
        glubokoe_water_lake,
        NEglubokoe_water_lake
    }
    void Start()
    {
        ����_������� = FindObjectOfType<����_�������>();
    }
    private void OnTriggerEnter(Collider Other)
    {
        if (Other.gameObject.CompareTag("Player")&& ozero ==razdelialka.lava_lake )
        {
            Debug.Log("corim");
            effekt.Play();
            InvokeRepeating("time_to_die", 0, 3);
        }
        if (Other.gameObject.CompareTag("Player") && ozero != razdelialka.lava_lake)
        {
            Debug.Log("tishimsa");
            if (effekt.isPlaying)
            {
                StartCoroutine(fire(effekt_two,2));
                effekt.Stop();
            }
            if (ozero == razdelialka.glubokoe_water_lake)
            {
                ����_�������.���������_bubble();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && ozero == razdelialka.glubokoe_water_lake)
        {
            CancelInvoke("Bye_bubble");
            StartCoroutine( ����_�������.add_bubble());
        }
        if (other.gameObject.CompareTag("Player") && ozero == razdelialka.lava_lake)
        {
            CancelInvoke("time_to_die");
            StartCoroutine(fire(effekt,3));
        }
    }
    void time_to_die()
    {
        ����_�������.izmenenie_Slidera(��������);
    }
    IEnumerator fire(ParticleSystem delilka,float tima)
    {
        Debug.Log("korutina");
        delilka.Play();
        yield return new WaitForSeconds(tima);
        delilka.Stop();
    }
}
