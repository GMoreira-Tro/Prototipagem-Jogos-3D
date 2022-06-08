using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ControleDoHeroi : MonoBehaviour
{
    //Privados
    private Vector2 vec;
    private CharacterController charCtrl;
    private Transform spawnBala;

    //Públicos
    public float velocidade = 10.0f;
    public Bala bala;

    private void Start()
    {        
        charCtrl = GetComponent<CharacterController>();
        spawnBala = transform.Find("Arma").Find("spawnBala");
    }

    public void Mover(InputAction.CallbackContext context)
    {        
        vec = context.ReadValue<Vector2>();
    }

    public static void FimDeJogo(string mensagem) 
    {
        PlayerPrefs.SetString("resultado", mensagem);

        SceneManager.LoadScene(2);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        if (charCtrl != null)
        {
            Vector3 mv = new Vector3(vec.x, 0, vec.y) * velocidade;
            mv = transform.TransformDirection(mv);
            charCtrl.SimpleMove(mv);            
        }

        if (Input.GetKeyDown(KeyCode.Space))
            if (bala != null)
            {
                Bala instBala = Instantiate(bala, spawnBala.position, spawnBala.rotation);
                instBala.name = bala.name;
                bala.transform.Rotate(Vector3.left * 90);
                instBala.GetComponent<Rigidbody>().AddForce(transform.forward * bala.velocidadeBala);
                Destroy(instBala, 5f);
            }
    }    
}
