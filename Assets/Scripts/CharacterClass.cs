﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterClass
{
    public string characterName, affiliation, orgName, gender;
    public int economicIdeal, organizationIdeal, politicalIdeal;
    public float militancyLevel, contendednessLevel, experienceLevel, popularity;

    public List<string> traits;

    //Intializers

    //Unaffiliated characters
    public CharacterClass()
    {
        int genderOdds = Random.Range(0, 101);
        if(genderOdds < 49)
        {
            gender = "Male";
        }
        if(genderOdds == 49)
        {
            gender = "NonBinary";
        }
        else
        {
            gender = "Female";
        }
        //characterName
        characterName = GetName();

        affiliation = "Unaffiliated";
        orgName = "Unaffiliated";
        economicIdeal = Random.Range(0, 11);
        organizationIdeal = Random.Range(0, 11);
        politicalIdeal = Random.Range(0, 11);
        militancyLevel = Random.Range(0, 10);
        contendednessLevel = Random.Range(5, 10);
        experienceLevel = Random.Range(0, 2);
        popularity = Random.Range(0, 10);

        SayWhoYouAre();
    }

    //For fully constructed characters
    public CharacterClass(string afil, string org,
        int econIdeal, int orgIdeal, int polIdeal, 
        float milLevel)
    {
        int genderOdds = Random.Range(0, 101);
        if (genderOdds < 49)
        {
            gender = "Male";
        }
        if (genderOdds == 49)
        {
            gender = "NonBinary";
        }
        else
        {
            gender = "Female";
        }
        //character name
        characterName = GetName();

        affiliation = afil;
        orgName = org;
        economicIdeal = econIdeal;
        organizationIdeal = orgIdeal;
        politicalIdeal = polIdeal;
        militancyLevel = milLevel;
        contendednessLevel = Random.Range(5, 10);
        experienceLevel = Random.Range(0, 2);
        popularity = Random.Range(0, 10);

        SayWhoYouAre();
    }

    private string GetName()
    {
        int personalName = Random.Range(0, 100);
        int familyName = Random.Range(0, 100);

        string first = "Bob";
        if (gender == "Male")
        {
            first = GameControllerScript.instance.firstMaleNames[personalName];
        }
        else
        {
            first = GameControllerScript.instance.firstFemaleNames[personalName];
        }
        string last = GameControllerScript.instance.LastNames[familyName];
        string myName = first + " " + last;
        return (myName);
    }

    private void SayWhoYouAre()
    {
        Debug.Log("My name is " + characterName + ". I work for the  " + affiliation + " as part of the " + orgName +
            ".\nI have an economic ideal of " + economicIdeal + " a organizational ideal of " + organizationIdeal +
            " a political ideal of " + politicalIdeal + " and a militancy level of " + militancyLevel +
            ".\nI have a contendedness of " + contendednessLevel + " and a popularity of " + popularity + ".");
    }

}
