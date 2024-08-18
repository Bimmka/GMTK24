using UnityEngine;

namespace Code.Gameplay.Features.Infections.Configs
{
    [CreateAssetMenu(menuName = "StaticData/Infections/Create Infection Config", fileName = "InfectionConfig")]
    public class InfectionConfig :  ScriptableObject
    {
        public InfectionSetup InfectionSetup;
    }
}