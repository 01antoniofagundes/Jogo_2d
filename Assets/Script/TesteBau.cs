using UnityEngine;
using UnityEngine.SceneManagement;

public class Portao : MonoBehaviour
{
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Porta") && other.GetComponent<Player>().temChave == true)
        {
            SceneManager.LoadScene(1);
        }
    }

}