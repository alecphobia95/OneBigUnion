using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControllerScript : MonoBehaviour
{
    public static UIControllerScript instance;

    public Text cashText;
    public Text membersText;
    public Text militancyText;
    public Text unityText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void OnSubsidiariesClick()
    {

    }

    public void OnMembershipClick()
    {

    }

    public void OnLeadershipClick()
    {

    }

    public void OnTacticsClick()
    {

    }

}
