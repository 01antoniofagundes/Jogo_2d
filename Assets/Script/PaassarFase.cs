using UnityEngine;
using UnityEngine.SceneManagement;

public class PassaarFase : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Porta"))
        { 
            SceneManager.LoadScene("Vitoria");
        }
    }

}