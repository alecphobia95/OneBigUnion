using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraitClass
{
    public string traitName;
    public float traitStrength;

    public TraitClass(string name)
    {
        traitName = name;
    }

    public TraitClass(string name, float strength)
    {
        traitName = name;
        traitStrength = strength;
    }
}

public class TraitList: MonoBehaviour
{
    TraitClass sociable = new TraitClass("sociable");
    
}
