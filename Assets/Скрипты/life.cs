using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life : MonoBehaviour
{
    private хэпе_ученика хэпе_Ученика;
    public int значение;
    public float скорость_поворота = 4;
    // Start is called before the first frame update
    void Start()
    {
        хэпе_Ученика = FindObjectOfType<хэпе_ученика>();
    }
    private void OnTriggerEnter(Collider Other)
    {
        if (Other.gameObject.CompareTag("Player") && хэпе_Ученика.Live < хэпе_Ученика.Ограничения)
        {
            Destroy(gameObject); // исчезновение
            хэпе_Ученика.изменение_жизней(значение);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * скорость_поворота * Time.deltaTime);
    } 
}
