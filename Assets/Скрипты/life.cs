using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life : MonoBehaviour
{
    private ����_������� ����_�������;
    public int ��������;
    public float ��������_�������� = 4;
    // Start is called before the first frame update
    void Start()
    {
        ����_������� = FindObjectOfType<����_�������>();
    }
    private void OnTriggerEnter(Collider Other)
    {
        if (Other.gameObject.CompareTag("Player") && ����_�������.Live < ����_�������.�����������)
        {
            Destroy(gameObject); // ������������
            ����_�������.���������_������(��������);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * ��������_�������� * Time.deltaTime);
    } 
}
