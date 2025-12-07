using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    // Velocidad de avance/retroceso en unidades por segundo
    [Header("Parámetros de movimiento")]
    public float velocidadMovimiento = 5f;

    // Velocidad de giro en grados por segundo
    public float velocidadGiro = 120f;

    // Referencia al CharacterController
    private CharacterController characterController;

    private void Start()
    {
        // Obtenemos el componente CharacterController que está en la misma cápsula
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // 1. Leer la entrada del jugador
        // Horizontal: A/D o cursores izquierda/derecha (giro)
        float inputHorizontal = Input.GetAxis("Horizontal");

        // Vertical: W/S o cursores arriba/abajo (avance/retroceso)
        float inputVertical = Input.GetAxis("Vertical");

        // 2. Calcular el giro
        // Queremos que el giro sea independiente de los FPS, por eso multiplicamos por Time.deltaTime
        float anguloGiro = inputHorizontal * velocidadGiro * Time.deltaTime;

        // Giramos al personaje alrededor del eje Y (arriba/abajo)
        transform.Rotate(0f, anguloGiro, 0f);

        // 3. Calcular el vector de movimiento en espacio local
        // Movemos al personaje hacia delante/atrás según el eje vertical
        Vector3 movimientoLocal = new Vector3(0f, 0f, inputVertical * velocidadMovimiento);

        // 4. Convertir de espacio local a espacio global (world space)
        Vector3 movimientoMundo = transform.TransformDirection(movimientoLocal);

        // 5. Multiplicar por deltaTime para que la velocidad no dependa de los FPS
        movimientoMundo *= Time.deltaTime;

        // 6. Aplicar el movimiento usando el CharacterController
        characterController.Move(movimientoMundo);
    }
}
