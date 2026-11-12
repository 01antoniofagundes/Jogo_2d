using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class MenuScene : MonoBehaviour
{
    public GameObject pGameover;
    public GameObject pPause;

    bool pause = false;
    bool acabou = false;

    void Start()
    {
       pPause.SetActive(false);
        pGameover.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (pause)
            {
                Continuar();
            }
            else
            {
                Pausar();
            }

        }
    }

    public void Pausar()
    {
        if(acabou == false)
        {
            pause = true;
            pPause.SetActive (true);
            Time.timeScale = 0f;
        }
    }

    public void Continuar()
    {
        pause = false;
        pPause.SetActive(false);
        Time.timeScale = 1f;
    }

    public void MostrarGameOver()
    {
        acabou = true;
        pGameover.SetActive (true);
        Time.timeScale = 0f;
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("menu");
        Time.timeScale = 1f;
    }
}


