using UnityEngine;

public class Bala : MonoBehaviour
{
    public float danoBala = 10f, velocidadeBala = 100f;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            if (other.CompareTag("enemy"))
            {
                Inimigos inimigo = other.gameObject.GetComponent<Inimigos>();

                if (inimigo != null)
                    if (inimigo.CausaDanos(danoBala) <= 0)
                        Destroy(inimigo.gameObject);
            }

            if (!other.gameObject.name.Equals("Arma"))
                Destroy(gameObject);
        }
    }
}
