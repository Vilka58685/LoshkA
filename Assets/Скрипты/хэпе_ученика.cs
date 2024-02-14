using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class хэпе_ученика : MonoBehaviour
{
    private int live, bubble = 6, puzirik = 6, ограничения = 3; //PUZIRIK-максимальное число, bubble-текущее
    private int puzirik_remove = 0;
    public bool nepodberashka;
    private Slider polocka_life;
    public GameObject картинка, box_heart, kartinka_puzirik, box_bubble;
    public List<GameObject> life_ui = new();
    private List<GameObject> puzirik_ui = new();
    [SerializeField] private List<GameObject> puziriki_ui; // SerializeField - открывает строку для инспектора,но не открывает для других скриптов
    [SerializeField] private List<GameObject> puziriki_static;
    private void Start()
    {
       // puziriki_static = puziriki_ui;
        polocka_life = FindObjectOfType<Slider>();
        изменение_жизней(1);
    }
    public void изменение_жизней(int плюс_к_счёту)
    {
        if (live < ограничения)
        {
            live = live + плюс_к_счёту;
            if (плюс_к_счёту > 0)
            {
                GameObject heart = Instantiate(картинка);  // создаёт картинки при подборе префаба
                life_ui.Add(heart);
                life_ui[life_ui.Count - 1].transform.SetParent(box_heart.transform); // преобразует картинки в указыною панель
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
        if (live <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            return;
        }
        polocka_life.value = polocka_life.value + плюс_к_счёту;
        if (polocka_life.value == 0)
        {
            изменение_жизней(-1);
            polocka_life.value = polocka_life.maxValue;
        }
    }
    public void изменение_bubble(int bye_bubble)
    {
        if (bubble == 0)
        {
            izmenenie_Slidera(-7);
            return;
        }
        if (bubble <= puzirik)
        {
            if (bubble == puzirik)
            {
                for (int i = 0; i < bubble -1; i++) //i=0, меньше бубле,i +1
                {
                    //Debug.Log("you drowning");
                    //GameObject bubble2 = Instantiate(kartinka_puzirik);
                    //puzirik_ui.Add(bubble2);
                    //puzirik_ui[i].transform.SetParent(box_bubble.transform);

                    // box_bubble.transform.GetChild(0).gameObject.SetActive(true);
                    if ( !puziriki_ui[i >= 0 && i <= 5 ? i : 0].activeInHierarchy)
                    {
                        puziriki_ui[i].SetActive(true);
                    }
                }
            }
            if (bubble > 0)
            {
                bubble = bubble - 1;
                //Destroy(puziriki_ui[0]);
                if (puziriki_ui.Count!=0)
                {
                    puziriki_ui[puzirik_remove].SetActive(false);
                    puzirik_remove++;
                    //puziriki_ui.Remove(puziriki_ui[0]);
                }
            }
        }
    }
    public IEnumerator add_bubble()
    {
       
        for (int i = bubble - 1; i < puzirik - 1; i++)
        {
            if (bubble < puzirik)
            {
                bubble = bubble + 1;
            }
            Debug.Log("you resurrected");
            // GameObject bubble2 = Instantiate(kartinka_puzirik);
            //puziriki_ui.Add(puziriki_static[i]);
            //puziriki_ui[i] = puziriki_static[i];
            puziriki_ui[i].SetActive(true);
            // puzirik_ui.Add(bubble2);
            // puzirik_ui[i].transform.SetParent(box_bubble.transform);
            yield return new WaitForSeconds(1);
        }
        puziriki_ui.ForEach(puzirik2 => puzirik2.SetActive(false));
        //puziriki_ui.Clear();
        //Destroy(puzirik_ui[0]);
        bubble = 6;
    }

}
