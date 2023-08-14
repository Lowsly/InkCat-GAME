using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySelection : MonoBehaviour
{
     public delegate void AbilityDelegate();

    // Evento que se dispara cuando se activa una habilidad
    public event AbilityDelegate OnAbilityActivated;

    // Método de una habilidad
    public void ActivateAbility()
    {
        if (OnAbilityActivated != null)
        {
            OnAbilityActivated();
        }
    }

    private void SetSpace1()
    {
        // Llamar al evento al presionar la tecla "A"
        if (Input.GetKeyDown(KeyCode.A))
        {
            ActivateAbility();
        }
    }    
}
