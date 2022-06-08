using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleInterface : MonoBehaviour
{
    public void clicarBotaoIniciar()
    {    
        SceneManager.LoadScene(1);
    }    

    public void clicarRecomecar() 
    {
        SceneManager.LoadScene(1);
    }
    
    public void clicarBotaoSair()
    {
        Debug.Log("Sair");
        Application.Quit();
    }
}
