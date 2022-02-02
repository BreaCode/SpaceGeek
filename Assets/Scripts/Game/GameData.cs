
using UnityEngine;

namespace GeekSpace
{
    [CreateAssetMenu(fileName ="GameData",menuName ="Game" )]
    internal class GameData : ScriptableObject
    {
        [SerializeField] GameType _GameType;
    }
}
