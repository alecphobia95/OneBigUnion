﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrgClass
{
    public string orgName, affiliation, industry, parentOrg;
    public int membershipNumber, economicIdeal, organizationIdeal, politicalIdeal, orgCash, percentSkilled;
    public float militancyLevel, unityPercent;

    public List<CharacterClass> charList = new List<CharacterClass>();
    public List<OrgClass> subOrgs = new List<OrgClass>();

    //Creating a new group with random paramters
    public OrgClass(string whichSideAreYouOn, string whatTypeofJob, string parent)
    {
        parentOrg = parent;
        affiliation = whichSideAreYouOn;
        industry = whatTypeofJob;

        switch (affiliation)
        {
            case "Union":
                membershipNumber = Random.Range(50, 5001);
                orgCash = Random.Range(100, 1000);
                economicIdeal = Random.Range(0, 11);
                organizationIdeal = Random.Range(0, 11);
                politicalIdeal = Random.Range(0, 11);
                percentSkilled = Random.Range(20, 80);
                militancyLevel = Random.Range(0, 10);
                unityPercent = Random.Range(0, 100);
                break;
            case "Organized Crime":
                membershipNumber = Random.Range(20, 1001);
                orgCash = Random.Range(1000, 10000);
                economicIdeal = 5;
                organizationIdeal = 5;
                politicalIdeal = 5;
                percentSkilled = 50;
                militancyLevel = 8;
                unityPercent = Random.Range(40, 90);
                break;
            case "Action Group":
                membershipNumber = Random.Range(20, 1001);
                orgCash = Random.Range(100, 1000);
                economicIdeal = Random.Range(0, 11);
                organizationIdeal = Random.Range(0, 11);
                politicalIdeal = Random.Range(0, 11);
                percentSkilled = Random.Range(20, 50);
                militancyLevel = Random.Range(0, 10);
                unityPercent = Random.Range(40, 80);
                break;
            case "Capital":
                membershipNumber = Random.Range(10, 51);
                orgCash = Random.Range(1000, 10000);
                economicIdeal = Random.Range(7, 11);
                organizationIdeal = Random.Range(4, 11);
                politicalIdeal = Random.Range(7, 11);
                percentSkilled = Random.Range(20, 50);
                militancyLevel = Random.Range(0, 10);
                unityPercent = Random.Range(0, 100);
                break;
            default:
                Debug.Log("Uh oh");
                break;
        }

        CreateCharacters();

    }

    //Controlled organization sizes for events
    public OrgClass(string whichSideAreYouOn, int orgSize, string whatTypeofJob, string parent)
    {
        parentOrg = parent;
        affiliation = whichSideAreYouOn;
        industry = whatTypeofJob;
        affiliation = whichSideAreYouOn;

        switch (affiliation)
        {
            case "Union":
                membershipNumber = orgSize;
                orgCash = Random.Range(100, 1000);
                economicIdeal = Random.Range(0, 11);
                organizationIdeal = Random.Range(0, 11);
                politicalIdeal = Random.Range(0, 11);
                percentSkilled = Random.Range(20, 80);
                militancyLevel = Random.Range(0, 10);
                unityPercent = Random.Range(0, 100);
                break;
            case "Organized Crime":
                membershipNumber = orgSize;
                orgCash = Random.Range(1000, 10000);
                economicIdeal = 5;
                organizationIdeal = 5;
                politicalIdeal = 5;
                percentSkilled = 50;
                militancyLevel = 8;
                unityPercent = Random.Range(40, 90);
                break;
            case "Action Group":
                membershipNumber = orgSize;
                orgCash = Random.Range(100, 1000);
                economicIdeal = Random.Range(0, 11);
                organizationIdeal = Random.Range(0, 11);
                politicalIdeal = Random.Range(0, 11);
                percentSkilled = Random.Range(20, 50);
                militancyLevel = Random.Range(0, 10);
                unityPercent = Random.Range(40, 80);
                break;
            case "Capital":
                membershipNumber = orgSize;
                orgCash = Random.Range(1000, 10000);
                economicIdeal = Random.Range(7, 11);
                organizationIdeal = Random.Range(4, 11);
                politicalIdeal = Random.Range(7, 11);
                percentSkilled = Random.Range(20, 50);
                militancyLevel = Random.Range(0, 10);
                unityPercent = Random.Range(0, 100);
                break;
            default:
                Debug.Log("Uh oh");
                break;

        }

        CreateCharacters();
    }

    //Mostly used for govts, but can be used to make a custom group, like an action group or organized crime
    public OrgClass(string whichSideAreYouOn, string deptName, string whatTypeofJob, string parent, 
        int orgSize, int econIdeal, int orgIdeal, int poliIdeal, int startCash, int skilledPortion, 
        float milLevel, float uniPercent)
    {
        affiliation = whichSideAreYouOn;
        orgName = deptName;
        parentOrg = parent;
        industry = whatTypeofJob;
        membershipNumber = orgSize;
        economicIdeal = econIdeal;
        organizationIdeal = orgIdeal;
        politicalIdeal = poliIdeal;
        orgCash = startCash;
        percentSkilled = skilledPortion;
        militancyLevel = milLevel;
        unityPercent = uniPercent;

        CreateCharacters();
    }

    //For super orgs that contain other orgs
    public OrgClass(List<OrgClass> childOrgs, string superName, string whichSideAreYouOn)
    {
        affiliation = whichSideAreYouOn;
        orgName = superName;
        industry = "Parent Organization";
        parentOrg = "Top Level";

        subOrgs = childOrgs;

        CalculateParentValues();
    }

    public void CalculateParentValues()
    {
        int memberTotal = 0;
        int econTotal = 0;
        int orgTotal = 0;
        int poliTotal = 0;
        int cashTotal = 0;
        int skilledTotal = 0;
        float milTotal = 0;
        int lowestEcon = 100;
        int highestEcon = 0;
        int lowestOrg = 100;
        int highestOrg = 0;
        int lowestPoli = 100;
        int highestPoli = 0;
        float lowestMil = 100;
        float highestMil = 0;

        for (int x = 0; x < subOrgs.Count; x++)
        {
            memberTotal += subOrgs[x].membershipNumber;
            cashTotal += subOrgs[x].orgCash;
            skilledTotal += subOrgs[x].percentSkilled;

            econTotal += subOrgs[x].economicIdeal;
            if (subOrgs[x].economicIdeal < lowestEcon)
            {
                lowestEcon = subOrgs[x].economicIdeal;
            }
            else if (subOrgs[x].economicIdeal > highestEcon)
            {
                highestEcon = subOrgs[x].economicIdeal;
            }

            orgTotal += subOrgs[x].organizationIdeal;
            if (subOrgs[x].organizationIdeal < lowestOrg)
            {
                lowestOrg = subOrgs[x].organizationIdeal;
            }
            else if (subOrgs[x].organizationIdeal > highestOrg)
            {
                highestOrg = subOrgs[x].organizationIdeal;
            }

            poliTotal += subOrgs[x].politicalIdeal;
            if (subOrgs[x].politicalIdeal < lowestPoli)
            {
                lowestPoli = subOrgs[x].politicalIdeal;
            }
            else if (subOrgs[x].politicalIdeal > highestPoli)
            {
                highestPoli = subOrgs[x].politicalIdeal;
            }

            milTotal += subOrgs[x].militancyLevel;
            if (subOrgs[x].militancyLevel < lowestMil)
            {
                lowestMil = subOrgs[x].militancyLevel;
            }
            else if (subOrgs[x].militancyLevel > highestMil)
            {
                highestMil = subOrgs[x].militancyLevel;
            }
        }
        percentSkilled = skilledTotal / subOrgs.Count;
        economicIdeal = econTotal / subOrgs.Count;
        organizationIdeal = orgTotal / subOrgs.Count;
        politicalIdeal = poliTotal / subOrgs.Count;
        militancyLevel = milTotal / subOrgs.Count;
        unityPercent = 100 - (highestEcon - lowestEcon) - (highestMil - lowestMil) - (highestOrg - lowestOrg) - (highestPoli - lowestPoli);
    }

    public void CalculateOrgValues()
    {
        int econTotal = 0;
        int orgTotal = 0;
        int poliTotal = 0;
        float milTotal = 0;
        int lowestEcon = 100;
        int highestEcon = 0;
        int lowestOrg = 100;
        int highestOrg = 0;
        int lowestPoli = 100;
        int highestPoli = 0;
        float lowestMil = 100;
        float highestMil = 0;

        for (int x = 0; x < charList.Count; x++)
        {
            econTotal += charList[x].economicIdeal;
            if (charList[x].economicIdeal < lowestEcon)
            {
                lowestEcon = charList[x].economicIdeal;
            }
            else if (charList[x].economicIdeal > highestEcon)
            {
                highestEcon = charList[x].economicIdeal;
            }

            orgTotal += charList[x].organizationIdeal;
            if (charList[x].organizationIdeal < lowestOrg)
            {
                lowestOrg = charList[x].organizationIdeal;
            }
            else if (charList[x].organizationIdeal > highestOrg)
            {
                highestOrg = charList[x].organizationIdeal;
            }

            poliTotal += charList[x].politicalIdeal;
            if (charList[x].politicalIdeal < lowestPoli)
            {
                lowestPoli = charList[x].politicalIdeal;
            }
            else if (charList[x].politicalIdeal > highestPoli)
            {
                highestPoli = charList[x].politicalIdeal;
            }

            milTotal += charList[x].militancyLevel;
            if (charList[x].militancyLevel < lowestMil)
            {
                lowestMil = charList[x].militancyLevel;
            }
            else if (charList[x].militancyLevel > highestMil)
            {
                highestMil = charList[x].militancyLevel;
            }
        }
        economicIdeal = econTotal / charList.Count;
        organizationIdeal = orgTotal / charList.Count;
        politicalIdeal = poliTotal / charList.Count;
        militancyLevel = milTotal / charList.Count;
        unityPercent = 100 - (highestEcon - lowestEcon) - (highestMil - lowestMil) - (highestOrg - lowestOrg) - (highestPoli - lowestPoli);
    }

    public void CreateCharacters()
    {
        int leadershipNumber = 0;

        if (membershipNumber <= 50)
        {
            leadershipNumber = membershipNumber / 10;
        }
        else if (membershipNumber <= 550)
        {
            leadershipNumber = ((membershipNumber - 50) / 50) + 5;
        }
        else if (membershipNumber <= 1550)
        {
            leadershipNumber = ((membershipNumber - 550) / 100) + 15;
        }
        else
        {
            leadershipNumber = ((membershipNumber - 1550) / 500) + 25;
        }


        for (int x = 0; x < leadershipNumber; x++)
        {
            CreateOneNewCharacter();
        }
    }

    public void CreateOneNewCharacter()
    {
        int charEcon = Random.Range((economicIdeal - 3), (economicIdeal + 3));
        if (charEcon < 0)
        {
            charEcon = 0;
        }
        if (charEcon > 10)
        {
            charEcon = 10;
        }
        int charOrg = Random.Range((organizationIdeal - 3), (organizationIdeal + 3));
        if (charOrg < 0)
        {
            charOrg = 0;
        }
        if (charOrg > 10)
        {
            charOrg = 10;
        }
        int charPol = Random.Range((politicalIdeal - 3), (politicalIdeal + 3));
        if (charPol < 0)
        {
            charPol = 0;
        }
        if (charPol > 10)
        {
            charPol = 10;
        }
        float charMil = Random.Range((militancyLevel - 3), (militancyLevel + 3));
        if (charMil < 0)
        {
            charMil = 0;
        }
        if (charMil > 10)
        {
            charMil = 10;
        }
        charList.Add(new CharacterClass(affiliation, orgName, charEcon, charOrg, charPol, charMil));

    }

}
