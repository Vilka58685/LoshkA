using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class монетка : MonoBehaviour
{
    public int значение;
    private монетки монетки;
    public float скорость_поворота=4;
    private void Start()
    {
        монетки = FindObjectOfType<монетки>(); //ищет скрипт с компонентом монетки
    }
    private void OnTriggerEnter(Collider Other)
    {
        if (Other.gameObject.CompareTag("Player")) 
        {
            Destroy(gameObject);
            монетки.Изменение_счёта(значение);
        }
    }
    private void Update()
    {
        transform.Rotate(Vector3.up * скорость_поворота * Time.deltaTime);
    }
}

