using UnityEngine;

namespace GameOff2024.Game.Data.DataStore
{
    [CreateAssetMenu(fileName = nameof(CardData), menuName = "DataTable/" + nameof(CardData))]
    public sealed class CardData : ScriptableObject
    {
        [SerializeField, Range(1, 13)] private int rank = default;
        [SerializeField] private Sprite sprite = default;

        public CardVO cardVO => new(rank, sprite);
    }
}