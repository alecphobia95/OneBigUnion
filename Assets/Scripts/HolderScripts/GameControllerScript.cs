using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public static GameControllerScript instance;

    public List<OrgClass> govtAgenciesList = new List<OrgClass>();
    public OrgClass usGovt;
    public List<CharacterClass> charList = new List<CharacterClass>();
    [HideInInspector]
    public string[] firstMaleNames = new string[100];
    [HideInInspector]
    public string[] firstFemaleNames = new string[100];
    [HideInInspector]
    public string[] LastNames = new string[100];

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

        LoadNames();

        CreateStartingGovtAgencies();
    }

    private void CreateStartingGovtAgencies()
    {



    }

    private void LoadNames()
    {
        StreamReader maleRead = new StreamReader("./Assets/TxtFiles/FirstNamesMale.txt");
        //string info = read.ReadLine();
        for (int x = 0; x < firstMaleNames.Length; x++)
        {
            firstMaleNames[x] = maleRead.ReadLine();
        }
        maleRead.Close();

        StreamReader femaleRead = new StreamReader("./Assets/TxtFiles/FirstNamesFemale.txt");
        //string info = read.ReadLine();
        for (int x = 0; x < firstMaleNames.Length; x++)
        {
            firstMaleNames[x] = femaleRead.ReadLine();
        }
        femaleRead.Close();

        StreamReader lastRead = new StreamReader("./Assets/TxtFiles/LastNames.txt");
        //string info = read.ReadLine();
        for (int x = 0; x < firstMaleNames.Length; x++)
        {
            firstMaleNames[x] = lastRead.ReadLine();
        }
        lastRead.Close();
    }

}
