using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    public float checkRate = 0.05f;
    private float lastCkTime;
    public float maxCkDistance;
    public LayerMask layerMask;


    public GameObject curInteractGameObject;
    private IInteractable curInteractable;  

    public TextMeshProUGUI promptText;
    private Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastCkTime > checkRate)
        {
            lastCkTime = Time.time;
            Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit,maxCkDistance, layerMask)) 
            {
                if (hit.collider.gameObject != curInteractGameObject)
                {
                    curInteractGameObject = hit.collider.gameObject;  
                    curInteractable = hit.collider.GetComponent<IInteractable>();
                    SetpromptText();  
                }
            }
            else  
            {
                curInteractGameObject = null;             
                curInteractable = null;
                promptText.gameObject.SetActive(false);
            }
        }
    }

    private void SetpromptText()
    {
        promptText.gameObject.SetActive(true);
        promptText.text = curInteractable.GetInteractPrompt();

    }
    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && curInteractable != null)
        {
            curInteractable.OnInteract();
            curInteractGameObject = null;
            curInteractable = null;
            promptText.gameObject.SetActive(false);
        }
    }

   
}


