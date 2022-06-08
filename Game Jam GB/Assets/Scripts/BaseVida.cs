using UnityEngine;
using UnityEngine.UI;

public class BaseVida : MonoBehaviour
{
    public Slider barraVida;
    public float vida = 100f;

    private float vidaAtual;

    private void Start()
    {
        vidaAtual = vida;
    }

    public float CausaDanos(float dano)
    {
        vidaAtual -= dano;

        if (vidaAtual > 0)        
            barraVida.value = vidaAtual / vida;

        return vidaAtual;
    }
}
