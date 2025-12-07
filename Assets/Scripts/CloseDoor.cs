using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    public GameObject Door;
    public Cronometro cronometro;

    private void OnTriggerEnter(Collider other)
    {
        // Comprobamos que el objeto que entra es el jugador
        if (other.CompareTag("Player"))
        {
            // Activamos la puerta
            Door.SetActive(true);

            // Inicia el cronómetro
            cronometro.IniciarCronometro();

            // Desactivamos el trigger para que no se repita
            GetComponent<Collider>().enabled = false;
        }
    }
}

