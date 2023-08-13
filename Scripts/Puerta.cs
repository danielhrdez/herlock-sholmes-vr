using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using TMPro;

public class Puerta : MonoBehaviour, IUsable
{
    [SerializeField]
    private TextMeshProUGUI texto;

    [SerializeField]
    private TextMeshProUGUI cursor;

    public bool eligiendoOpciones = false;
    private bool opcionesFinales = false;
    private bool opcionesFinalesFinales = false;
    private int opcion = 0;

    [SerializeField]
    private InputActionReference padUp, padDown, accept;

    private int MAX_OPCIONES = 3;

    private void Start()
    {
        padUp.action.performed += OpcionUp;
        padDown.action.performed += OpcionDown;
        accept.action.performed += FinishGame;
    }

    private void PrintCursor()
    {
        string cursorText = "";
        for (int i = 0; i < opcion; i++)
        {
            cursorText += "\n";
        }
        cursorText += ">";
        cursor.text = cursorText;
    }

    private void OpcionUp(InputAction.CallbackContext obj)
    {
        if (opcionesFinales && opcion > 0)
        {
            opcion--;
            PrintCursor();
        }
    }
    private void OpcionDown(InputAction.CallbackContext obj)
    {
        if (opcionesFinales && opcion < MAX_OPCIONES)
        {
            opcion++;
            PrintCursor();
        }
    }

    public void Use(GameObject actor)
    {
        // actor.GetComponent<Player>().AddHealth(healthBoost);
        texto.text = "Bienvenido a tu examen, " +
            "no soy una puerta, soy Herlock Sholmes y " +
            "se ha encontrado aquí el cadáver de un oficinista.\n" +
            "Debes averiguar que ha sucedido sin acceso al cuerpo ni a su estudio forense.\n\n" +
            "Cuando estés listo para decirme que has encontrado, ven a verme, estaré esperando tras la puerta.";
    }
    public void SeMovio()
    {
        texto.text = "Esperando respuesta...";
    }

    public void Opciones()
    {
        texto.text = "Pulse Y si cree que fue un suicidio\n" +
            "Pulse X si cree que fue un asesinato";
        eligiendoOpciones = true;
    }

    public void Suicidio()
    {
        texto.text = "Te has equivocado. " +
            "O eres despistado, estúpido o una combinación de las anteriores.\n\n" +
            "Fuera de aquí.";
    }

    public void Asesinato()
    {
        texto.text = "¿Quién le mató?\n" +
            "(Seleccione con Up-Down)\n\n" +
            "Su hermano\n" +
            "Su cliente\n" +
            "Riera\n" +
            "Yo\n\n" +
            "Pulse A para continuar";
        
        opcionesFinales = true;
        cursor.gameObject.SetActive(true);
        PrintCursor();
    }

    private void FinishGame(InputAction.CallbackContext obj)
    {
        if (opcionesFinales)
        {
            if (!opcionesFinalesFinales)
            {
                Respuesta();
            }
            else
            {
                RespuestaFinal();
            }
        }
    }

    private void Respuesta()
    {
        switch (opcion)
        {
            case 0:
                texto.text = "No, no tienes como haber descubierto eso.";
                break;
            case 1:
                PreguntaFinal();
                break;
            case 2:
                texto.text = "Los cojones le mató Riera.\nFuera de aquí.";
                break;
            case 3:
                texto.text = "Don Comedia el tío este.\nFuera de aquí.";
                break;
        }
    }

    private void PreguntaFinal()
    {
        texto.text = " Es correcto. ¿Cómo le ha matado?\n" +
            "(Seleccione con Up-Down)\n\n" +
            "Le disparó con un arma de fuego\n" +
            "Le atacó con un arma blanca\n" +
            "Le lanzó algo a la cabeza\n\n" +
            "Pulse A para continuar";
        
        opcion = 0;
        MAX_OPCIONES = 2;
        opcionesFinalesFinales = true;
        PrintCursor();
    }
    private void RespuestaFinal()
    {
        switch (opcion)
        {
            case 0:
                texto.text = "Así es, buen trabajo.\nHas aprobado, bienvenido.";
                break;
            case 1:
                texto.text = "Incorrecto.";
                break;
            case 2:
                texto.text = "Je, más o menos, pero no.";
                break;
        }
        cursor.gameObject.SetActive(false);
    }
}
