using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1 : MonoBehaviour
{
   [SerializeField] private Power power;
   [SerializeField] private UISkills UIskills;
    void Start()
    {
        UIskills.setPlayerskills(power.getAbility());
    }

   
}
