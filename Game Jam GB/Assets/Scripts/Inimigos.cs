using UnityEngine;
using UnityEngine.AI;
using System.Linq;

[RequireComponent(typeof(NavMeshAgent))]
public class Inimigos : MonoBehaviour
{
    public float ataque = 20f;
    public bool alvoPlayer = false;

    private GameObject player, torre;
    private NavMeshAgent navMesh;    
    private float tempo = 0f;
    private BaseVida objDano;    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        torre = GameObject.FindWithTag("torre");
        navMesh = GetComponent<NavMeshAgent>();

        if (PlayerPrefs.GetString("modo").Equals("fácil"))
            navMesh.speed = 5.7F;
    }

    // Update is called once per frame
    void Update()
    {
        if ((navMesh != null) && (player != null) && (torre != null))
        {
            if (alvoPlayer)
                navMesh.destination = player.transform.position;
            else
                navMesh.destination = torre.transform.position;

            if (objDano != null)
            {
                tempo += Time.deltaTime;

                if (tempo >= 1f)
                {
                    tempo %= 1f;

                    if (objDano.CausaDanos(ataque) <= 0)
                        ControleDoHeroi.FimDeJogo("Você perdeu!");
                }
            }
        }
    }    

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            if (new string[] { "Player", "torre" }.Any(s => other.gameObject.tag.Equals(s)))
            {
                objDano = other.gameObject.GetComponent<BaseVida>();
                tempo = 1f;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        objDano = null;
    }

    public float CausaDanos(float dano)
    {
        BaseVida objDanoInt = GetComponent<BaseVida>();

        if (objDanoInt != null)
        {
            alvoPlayer = true;
            return objDanoInt.CausaDanos(dano);
        }
        else
            return 0;
    }
}
