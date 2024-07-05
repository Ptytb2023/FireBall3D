using UnityEngine;

namespace Characters
{
    [CreateAssetMenu(fileName = "CharacterContainer",
        menuName = "ScriptableObject/Characters/CharacterContainer",
        order = 51)]
    public class CharacterContainerSo : ScriptableObject
    {
        [field:SerializeField] private Character CharacterPrefab { get; set; }

        public Character Creat(Transform parent) =>
            Instantiate(CharacterPrefab, parent);
    }
}
