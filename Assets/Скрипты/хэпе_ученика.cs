using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class хэпе_ученика : MonoBehaviour
{
    private int live, bubble = 5, puzirik = 5, ограничения = 3; //PUZIRIK-максимальное число, bubble-текущее
    private int puzirik_remove = 0;
    public bool timerOn, add_bubble_now;
    private Slider polocka_life;
    public GameObject картинка, box_heart, kartinka_puzirik, box_bubble;
    public List<GameObject> life_ui = new();
    private List<GameObject> puzirik_ui = new();
    [SerializeField] private List<GameObject> puziriki_ui; // SerializeField - открывает строку для инспектора,но не открывает для других скриптов
    [SerializeField] private List<GameObject> puziriki_static;
    public int Live => live;
    public int Ограничения => ограничения;
    public Slider Polocka_life => polocka_life;
    private void Start()
    {
        polocka_life = FindObjectOfType<Slider>();
        изменение_жизней(1);
    }
    public void изменение_жизней(int плюс_к_счёту)
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
    //public void изменение_bubble()
    //{
    //    if (bubble <= 0)
    //    {
    //        izmenenie_Slidera(-7);
    //        return;
    //    }
    //    if (bubble <= puzirik && !add_bubble_now)
    //    {
    //        if (bubble > 0)
    //        {
    //            StopAllCoroutines();
    //            StartCoroutine(remove_bubble());
    //        }
    //    }
    //}
    public IEnumerator add_bubble()
    {
        if(!add_bubble_now)
        {
            StopCoroutine(add_bubble());
        }
        add_bubble_now = true;
        foreach (var puzirik in puziriki_ui)
        {
            puzirik.SetActive(true);
            Debug.Log("coroutine add_bubble");
            yield return new WaitForSeconds(1);
        }
        puziriki_ui.ForEach(puzip => puzip.SetActive(false));
        bubble = 5;
        add_bubble_now = false;
    }
    public IEnumerator remove_bubble()
    {
        if (add_bubble_now )
        {
            StopCoroutine(remove_bubble());
        }
        puziriki_ui.ForEach(puzip => puzip.SetActive(true));
        foreach (var puzip in puziriki_ui)
        {
            yield return new WaitForSeconds(1);
            puzip.SetActive(false);
            Debug.Log("coroutine remove_bubble");
            bubble--;
        }
        for (int i = 0; i < 15; i++)
        {
            izmenenie_Slidera(-7);
            yield return new WaitForSeconds(1.7f);
        } 
    }
    //private void Update()
    //{
    //    if (add_bubble_now)
    //    {
    //        StopCoroutine(remove_bubble());
    //    }
    //    else
    //    {
    //        StopCoroutine(add_bubble());
    //    }
    //}
}
