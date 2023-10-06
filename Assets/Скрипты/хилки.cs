using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class хилки : MonoBehaviour
{
    private хэпе_ученика хэпе_Ученика;
    public int значение;
    public float скорость_поворота = 4;
    public int проценты;
    // Start is called before the first frame update
    void Start()
    {
       хэпе_Ученика = FindObjectOfType<хэпе_ученика>();
    }
    private void OnTriggerEnter(Collider Other)
    {
        if (Other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            хэпе_Ученика.izmenenie_Slidera(проценты);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * скорость_поворота * Time.deltaTime);
    }
}
