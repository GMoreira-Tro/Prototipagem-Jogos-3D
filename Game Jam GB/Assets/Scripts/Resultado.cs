using UnityEngine;
using TMPro;

public class Resultado : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TextMeshPro txt = gameObject.transform.Find("txtFimDeJogo").GetComponent<TextMeshPro>();
        txt.text = PlayerPrefs.GetString("resultado");        
    }

}
