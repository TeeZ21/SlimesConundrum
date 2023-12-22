using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Container : MonoBehaviour
{
    [SerializeField] private ESlimeTypes _containerTypes = ESlimeTypes.BLACK;
    public ESlimeTypes ContainerTypes
    {
        get 
        { 
            return _containerTypes; 
        }
    }
}
