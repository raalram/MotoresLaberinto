using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public GameObject jugador;
    float distancia;

    void Update()
    {
        distancia= Vector3.Distance(transform.position, jugador.transform.position);

        if (distancia<1)
        {
            // SceneManager.LoadScene("GameOver");
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
    

