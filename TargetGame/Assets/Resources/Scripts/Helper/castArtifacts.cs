using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class CastArtifacts
 {
    public static ArtifactTypes CastATortifact<T>(this T input)
    {
        string inputstring="";
        try
        {
             inputstring = input.ToString();
        }
        catch (Exception e)
        {
            Debug.Log(e);
            Debug.Log("Input is not a defined Enum");
        }
        if (inputstring.Length != 0)
        {
            try
            {
                ArtifactTypes returnvalue;
                ArtifactTypes artifact = (ArtifactTypes)Enum.Parse(typeof(ArtifactTypes), inputstring);
                if (Enum.IsDefined(typeof(ArtifactTypes), artifact))
                {
                    returnvalue = artifact;
                    return returnvalue;
                }

            }
            catch(ArgumentException)
            {
                Debug.Log(input + "is not an Artifact Type");
            }
        }
        return ArtifactTypes.NULL;
    }

}
