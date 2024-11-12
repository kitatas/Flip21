using UnityEngine;

namespace GameOff2024.Game.Data.DataStore
{
    [CreateAssetMenu(fileName = nameof(SuitData), menuName = "DataTable/" + nameof(SuitData))]
    public sealed class SuitData : ScriptableObject
    {
        [SerializeField] private Suit suitType = default;
        [SerializeField] private Sprite suitIcon = default;
        [SerializeField] private Color suitColor = default;

        public Suit suit => suitType;
        public SuitVO suitVO => new(suitIcon, suitColor);
    }
}