using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void CerrarJuego()
    {
        Debug.Log("Cerrando juego...");

        Application.Quit();

        // Esto SOLO es para que funcione también en el Editor:
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
