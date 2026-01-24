using UnityEngine;
using UnityEngine.InputSystem;

public class RayCast : MonoBehaviour
{
    Camera mainCamera;
    public Door door;
    public float maxDistance = 10f;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    RaycastHit hit;
    void Update()
    {
        if(Mouse.current.leftButton.isPressed)
        {

            Ray ray= mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            Debug.Log(Mouse.current.position.ReadValue());
            Debug.DrawRay(ray.origin, ray.direction * 20f, Color.royalBlue);

            if(Physics.Raycast(ray,out hit,maxDistance))
            {
               if(hit.collider.CompareTag("OpenDoor"))
                {
                    Debug.Log("Puerta abierta");
                    
                    Renderer rend=hit.collider.GetComponent<Renderer>();
                    if(rend!=null)
                    {
                        rend.material = new Material(rend.material);
                        rend.material.color = Color.green;
                    }

                    if(door!=null)
                    door.TriggerOpen();


                }
            }
        }
    }
}
