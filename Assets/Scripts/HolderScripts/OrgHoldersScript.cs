using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrgHoldersScript : MonoBehaviour
{
    [HideInInspector]
    public List<UnionClass> unions = new List<UnionClass>();
    [HideInInspector]
    public List<BusinessClass> businesses = new List<BusinessClass>();
    [HideInInspector]
    public List<GovtClass> governments = new List<GovtClass>();

}
