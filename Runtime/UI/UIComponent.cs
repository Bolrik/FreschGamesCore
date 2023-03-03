using UnityEngine.UIElements;

namespace FreschGames.Core.UI
{
    public abstract class UIComponent
    {
        internal abstract void Initialize(UIElement root, VisualElement visualElement);
    }
}
