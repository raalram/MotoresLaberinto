using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("Movement")]
    public float down = 3f;
    public float speed = 2f;
    public float time = 2f;

    Vector3 startPos;
    Vector3 targetPos;

    private Coroutine routine;
    public bool isMoving;
    void Start()
    {
        startPos = transform.position;
        targetPos = startPos+Vector3.down*down; 
    }

    public void TriggerOpen()
    {
        if (routine!=null)
        {
            StopCoroutine(routine);
            routine = StartCoroutine(OpenCloseRoutine());
        }
    }
    public IEnumerator
        OpenCloseRoutine()
        {
        yield return MoveTo(targetPos);
        yield return new WaitForSeconds(time);
        yield return MoveTo(startPos);

        routine = null;
        }
    public IEnumerator MoveTo(Vector3 target)
        {
        isMoving = true;
        while((transform.position-target).sqrMagnitude>0.0001f)
        {
            transform.position=Vector3.MoveTowards(transform.position,target,speed*Time.deltaTime);
            yield return null;
        }

        transform.position = target;
        isMoving = false;

        }
}
