using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMouse : MonoBehaviour
{
    public Transform mouseBox;
    
    void Update()
    {
        mouseBox.position = Input.mousePosition;
    }
}
