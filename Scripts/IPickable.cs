using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickable
{
    bool KeepWorldPosition { get; }
    bool encontrado { get; set; }
    
    GameObject PickUp();
}
