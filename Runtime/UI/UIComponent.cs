using UnityEngine.UIElements;

namespace FreschGames.Core.UI
{
    public abstract class UIComponent
    {
        public abstract void Initialize(UIElement root, VisualElement visualElement);
    }
}
