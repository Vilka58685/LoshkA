using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class хэпе_ученика : MonoBehaviour
{
    public int live, bubble = 6, puzirik = 6, ограничения = 3;
    public bool nepodberashka;
    private Slider polocka_life;
    public GameObject картинка, панелька, kartinka_puzirik, панелька2;
    public List<GameObject> life_ui = new();
    private List<GameObject> puzirik_ui = new();
    private void Start()
    {
        polocka_life = FindObjectOfType<Slider>();
        изменение_жизней(1);
    }
    public void изменение_жизней(int плюс_к_счёту)
    {
        if (live < ограничения)
        {
            live = live + плюс_к_счёту;
            if (плюс_к_счёту>0)
            {
                GameObject heart = Instantiate(картинка);  // создаёт картинки при подборе префаба
                life_ui.Add(heart);
                life_ui[life_ui.Count-1].transform.SetParent(панелька.transform); // преобразует картинки в указыною панель
            }
            else
            {
                Destroy(life_ui[0]);
                life_ui.Remove(life_ui[0]);
            }
        }
        else 
        {
            nepodberashka = true;
        }
    }
    public void izmenenie_Slidera(int плюс_к_счёту) //izmenenie_percent
    {
        if (live <=0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            return;
        }
        polocka_life.value = polocka_life.value + плюс_к_счёту;
        if (polocka_life.value==0)
        {
            изменение_жизней(-1);
            polocka_life.value = polocka_life.maxValue;
        }
    }
    public void изменение_bubble(int bye_bubble) 
    {
        if (bubble==0)
        {
            izmenenie_Slidera(-7);
            return;
        }
        if (bubble <= puzirik)
        {
            if (bubble == puzirik)
            {
                for (int i = 0; i < bubble; i++)
                {
                    Debug.Log("you drowning");
                    GameObject bubble2 = Instantiate(kartinka_puzirik);
                    puzirik_ui.Add(bubble2);
                    puzirik_ui[i].transform.SetParent(панелька2.transform);
                }
            }
            if (bubble>0)
            {
                bubble = bubble - bye_bubble;
                Destroy(puzirik_ui[0]);
                puzirik_ui.Remove(puzirik_ui[0]);
            }
        }
    }
}
