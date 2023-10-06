using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class спавнер : MonoBehaviour
{
    public GameObject[] монетка;
    public void спав_нер()
    {
        int рандомчик = Random.Range(0, монетка.Length);
        Instantiate(монетка[рандомчик]); // создздаёт копию объекта
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("спав_нер", 7, 3); // указывает через сколько появится объекты
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
