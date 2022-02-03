
using UnityEngine;

namespace GeekSpace
{
    [CreateAssetMenu(fileName ="GameData",menuName ="Game" )]
    internal class GameData : ScriptableObject
    {
        [SerializeField]internal GameType _GameType;
    }
}
