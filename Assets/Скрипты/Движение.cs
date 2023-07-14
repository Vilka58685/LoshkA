using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Движение : MonoBehaviour
{
    public float скорость = 2;
    public float вертикально;
    public float горизонтально;
    public float скорость_поворота = 4;
    public float скорость_прыжка = 4;
    public bool поле_прыжка;
    public Rigidbody Физика;
    public Animator аниматор;
    // Start is called before the first frame update
    void Start()
    {
        Физика = GetComponent<Rigidbody>();
        аниматор = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = transform.position + new Vector3(1, 0, 1)*Time.deltaTime;
        вертикально = Input.GetAxis("Vertical"); //клавиши вперёд назад
        transform.Translate(Vector3.forward * скорость * вертикально * Time.deltaTime); //смена позиции,движение
        горизонтально = Input.GetAxis("Horizontal"); //клавиши вправо влево
        transform.Rotate(Vector3.up * скорость_поворота * горизонтально * Time.deltaTime); //поворот
        //if (прыжок !=0)
        //{
        //    аниматор.SetBool("прыжок", true);
        //    return;
        //}
        if (Input.GetKey(KeyCode.Space) && поле_прыжка == true)
          
        {
            Физика.AddForce(Vector3.up * скорость_прыжка, ForceMode.Impulse);
            поле_прыжка = false;
            аниматор.SetBool("прыжок", true);
            return;
        }
        // Физика.AddForce(Vector3.up * скорость_прыжка * прыжок,ForceMode.Impulse);
        if (вертикально != 0 || горизонтально != 0)
        {
            аниматор.SetBool("ходьба", true);
            аниматор.SetBool("прыжок", false);
            return;
        }
        аниматор.SetBool("ходьба", false);
        аниматор.SetBool("прыжок", false);

    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("корги"))
        {
            Debug.Log("Ты коснулся земли");
            поле_прыжка = true;
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("корги"))
        {
            поле_прыжка = false;
        }
    }
}