using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField]
    private LayerMask pickableLayerMask;

    [SerializeField]
    private Transform playerCameraTransform;

    [SerializeField]
    private GameObject pickUpUI;

    [SerializeField]
    [Min(1)]
    private float hitRange = 3;

    [SerializeField]
    private Transform pickUpParent;

    [SerializeField]
    private GameObject inHandItem;

    [SerializeField]
    private InputActionReference interactionInput, dropInput, useInput;

    [SerializeField]
    private TextMeshProUGUI pistas;

    [SerializeField]
    private Puerta door;

    private int numeroPistas = 0;

    private RaycastHit hit;

    private bool inDoor = false;

    private bool seHaMovido = false;
    private Vector3 posicionInicial;
    private int MAX_PISTAS = 5;

    private void Start()
    {
        posicionInicial = this.transform.position;
        interactionInput.action.performed += PickUp;
        dropInput.action.performed += Drop;
        useInput.action.performed += Use;
    }

    private void Use(InputAction.CallbackContext obj)
    {
        if (hit.collider != null)
        {
            IUsable usable = hit.collider.GetComponent<IUsable>();
            if (usable != null)
            {
                if (!door.eligiendoOpciones)
                {
                    usable.Use(this.gameObject);
                    inDoor = true;
                    posicionInicial = this.transform.position;
                }
                else
                {
                    door.Suicidio();
                }
            }
        }
    }

    private void Drop(InputAction.CallbackContext obj)
    {
        if (hit.collider != null)
        {
            IUsable usable = hit.collider.GetComponent<IUsable>();
            if (usable != null && door.eligiendoOpciones)
            {
                door.Asesinato();
            }
        }
    }

    private void PickUp(InputAction.CallbackContext obj)
    {
        if(hit.collider != null && inHandItem == null)
        {
            IPickable pickableItem = hit.collider.GetComponent<IPickable>();
            if (pickableItem != null && !pickableItem.encontrado)
            {
                numeroPistas++;
                pickableItem.encontrado = true;
            }
        }
    }

    private void Update()
    {
        /**
        * 1 Tomas las coordenadas iniciales
        * 2 Tomas las coordenadas a una distancia predeterminada a la izquierda y otra vez hacia arriba, y a la derecha y hacia abajo (esquina superior derecha (A) e inferior izq (B))
        * 3 Si la coordenada X es menor que la componente X de A, o la Y es menor que la componente Y de A, o X es mayor que X de B, o Y es mayor que Y de B, se salió del cuadrado
        * 4 Lanza el evento de que se ha salido de la zona de lectura.
        */
        if (!seHaMovido)
        {
            float epsilon = 3f;
            Vector3 movement = this.transform.position - posicionInicial;
            bool aux = movement.x > epsilon || movement.y > epsilon || movement.z > epsilon;
            if (aux && inDoor)
            {
                seHaMovido = true;
                door.SeMovio();
            }
        }
        
        // Debug.DrawRay(playerCameraTransform.position, playerCameraTransform.forward * hitRange, Color.red);
        if (hit.collider != null)
        {
            hit.collider.GetComponent<Highlight>()?.ToggleHighlight(false);
            pickUpUI.SetActive(false);
        }

        if (inHandItem != null)
        {
            return;
        }

        if (Physics.Raycast(
            playerCameraTransform.position, 
            playerCameraTransform.forward, 
            out hit, 
            hitRange,
            pickableLayerMask))
        {
            IPickable pickableItem = hit.collider.GetComponent<IPickable>();
            IUsable usable = hit.collider.GetComponent<IUsable>();
            if (pickableItem != null && !pickableItem.encontrado)
            {
                hit.collider.GetComponent<Highlight>()?.ToggleHighlight(true);
                pickUpUI.SetActive(true);
                pickUpUI.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "A";
            }
            else if (usable != null && !inDoor)
            {
                hit.collider.GetComponent<Highlight>()?.ToggleHighlight(true);
                pickUpUI.SetActive(true);
                pickUpUI.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Y";
            }
            else if (!door.eligiendoOpciones && usable != null &&
                    inDoor && numeroPistas == MAX_PISTAS)
            {
                door.Opciones();
            }
        }

        pistas.text = numeroPistas.ToString();
    }
}
