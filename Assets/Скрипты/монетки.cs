using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class монетки : MonoBehaviour
{
    public TextMeshProUGUI текст;
    public int счёт=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void Изменение_счёта(int плюс_к_счёту)
    {
        счёт = счёт + плюс_к_счёту;
        текст.text = счёт.ToString();
    }    
}
