using IG;
using UnityEngine;

namespace Kosmos6
{
    public class ManagerAchivements : SingletonManager<ManagerAchivements>
    {
        void OnEnable() => ManagerScore.Instance.OnNewScore += CheckAchivements;

        void OnDisable() => ManagerScore.Instance.OnNewScore -= CheckAchivements;

        void CheckAchivements(int newScore)
        {
            if (newScore > 9)
            {
                Debug.Log("You are the champion");
            }
        }
    }
}