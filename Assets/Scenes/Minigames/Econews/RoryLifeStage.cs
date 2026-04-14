using System.Collections.Generic;
using UnityEngine;

/*
Rory lifestage database asset in Unity editor to store
and modify lifestages.
List of LifeStageData items
*/

/*Menu and filename visible in Unity editor*/
[CreateAssetMenu(fileName = "RoryLifeStage", menuName = "Scriptable Objects/RoryLifeStage")]
public class RoryLifeStage : ScriptableObject
{
    public List<LifeStageData> lifeStages;
}