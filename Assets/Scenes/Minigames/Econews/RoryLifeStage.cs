using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RoryLifeStage", menuName = "Scriptable Objects/RoryLifeStage")]
public class RoryLifeStage : ScriptableObject
{
    public List<LifeStageData> lifeStages;
}
