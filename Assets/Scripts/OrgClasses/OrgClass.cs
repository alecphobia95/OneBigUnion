﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrgClass
{
    public string orgName, industry, parentOrg;
    public int membershipNumber, economicIdeal, organizationIdeal, politicalIdeal, orgCash, percentSkilled;
    public float militancyLevel, unityPercent;

    public List<CharacterClass> charList = new List<CharacterClass>();
    public List<OrgClass> subOrgs = new List<OrgClass>();

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
        int charEcon = (int)randomValueInAvgRange(economicIdeal);

        int charOrg = (int)randomValueInAvgRange(organizationIdeal);

        int charPol = (int)randomValueInAvgRange(politicalIdeal);

        float charMil = randomValueInAvgRange(militancyLevel);

        charList.Add(new CharacterClass(orgName, charEcon, charOrg, charPol, charMil));

    }

    private float randomValueInAvgRange(float standard)
    {
        float value = Random.Range((standard - 3), (standard + 3));

        if (value < 0)
        {
            value = 0;
        }
        if (value > 10)
        {
            value = 10;
        }

        return (value);
    }

}
