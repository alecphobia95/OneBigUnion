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
        int congressEcon = Random.Range(7, 11);
        float congressMilLevel = Random.Range(3, 8);
        float congressUnity = Random.Range(70, 95);
        govtAgenciesList.Add(new OrgClass("Government","US Congress", "Legislation", "US Govt", 550, congressEcon, 8, 9, 10000, 100, congressMilLevel, congressUnity));
        
        int ciaEcon = Random.Range(8, 11);
        float ciaMilLevel = Random.Range(6, 8);
        float ciaUnity = Random.Range(85, 100);
        govtAgenciesList.Add(new OrgClass("Government", "CIA", "Espionage", "US Govt", 1000, ciaEcon, 8, 9, 100000, 90, ciaMilLevel, ciaUnity));

        usGovt = new OrgClass(govtAgenciesList, "US Govt", "Government");

        Debug.Log("US Congress has " + govtAgenciesList[0].membershipNumber + " Members and " + govtAgenciesList[0].charList.Count + " Leaders");
        Debug.Log("CIA has " + govtAgenciesList[1].membershipNumber + " Members and " + govtAgenciesList[1].charList.Count + " Leaders");
        Debug.Log("US Government has " + usGovt.membershipNumber + " Members and " + usGovt.charList.Count + " Leaders");
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
