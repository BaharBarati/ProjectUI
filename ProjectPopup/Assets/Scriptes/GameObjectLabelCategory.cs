using UnityEngine;
using UnityEngine.U2D.Animation;

namespace GameObjectLabelCategory
{
    public class GameObjectLabelCategory : MonoBehaviour
    {
        [SerializeField] private SpriteResolver spriteResolver;
        [SerializeField] private string category;
        [SerializeField] private string label;
        private void OnValidate()
        {
            Apply();
        }

        public void Apply()
        {
            if (spriteResolver == null)
                spriteResolver = GetComponent<SpriteResolver>();

            if (spriteResolver != null)
                spriteResolver.SetCategoryAndLabel(category, label);
        }
    }
}

