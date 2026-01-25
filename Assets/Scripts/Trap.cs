using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            transform.SetParent(null);
            DontDestroyOnLoad(this.gameObject);
            SceneManager.LoadScene("GameOver");
            Invoke("CargarEscena2", 3f);
        }
    }
    void CargarEscena2()
    {
        SceneManager.LoadScene("Scene2");
        Destroy(this.gameObject);
    }
}
