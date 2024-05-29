using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PalyerController : MonoBehaviour
{
    public float moveSpeed;
    public float Jumppower;
    public Vector3 curMovementInput;
    public LayerMask groundLayerMask;


    private Rigidbody _rigidbody;

   public Transform cameraContainer;
    public float MinLook;
    public float MaxLook;
    public float camCurXRot;
    public float lookSencitvity;
    private Vector2 mouseDelta;
   
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;   
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        CameraLook();
    }
    public void Move()
    {
        Vector3 dir = transform.forward *curMovementInput.y+ transform.right *curMovementInput.x;
        dir*=moveSpeed;
        dir.y =_rigidbody.velocity.y;    
        _rigidbody.velocity = dir;   
    }
    void CameraLook()
    {
        camCurXRot += mouseDelta.y * lookSencitvity;
         camCurXRot =Mathf.Clamp(camCurXRot, MinLook,MaxLook);
        cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);

        transform.eulerAngles += new Vector3(0,mouseDelta.x*lookSencitvity,0);

    }
    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput =Vector2.zero;
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDelta =context.ReadValue<Vector2>();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log("¶Ç¾ÈµÊ");
        if (context.phase == InputActionPhase.Started && IsGrounded())
        {
            Debug.Log("???");
            _rigidbody.AddForce(Vector2.up * Jumppower, ForceMode.Impulse);
        }
    }
    bool IsGrounded()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position + (transform.up * 0.01f), Vector3.down, out hit); 
        Debug.Log(hit.transform.name);
        Debug.Log("¿Ö¾ÈµÊ");
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) +(transform.up * 0.01f), Vector3.down)
        };

        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.1f, groundLayerMask))
            {
                Debug.Log("true");
                return true;
            }
        }

        return false;
    }
}
