using UnityEngine;

namespace FreschGames.Core.TemplateSystem
{
    public abstract class TemplateGroup : ScriptableObject
    {
        protected void Assign<T>(T value)
            where T : Object
        {
            Template<T>.Assign(value);
        }

        public abstract void Load();
    }
}
