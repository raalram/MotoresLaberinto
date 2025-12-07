using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    public GameObject Door;
    public Cronometro cronometro;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Door.SetActive(true);
            cronometro.IniciarCronometro();

            // Desactivo el trigger 
            GetComponent<Collider>().enabled = false;
        }
    }
}

