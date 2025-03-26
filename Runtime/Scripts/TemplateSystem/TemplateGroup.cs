using FreschGames.Core.BootSystem;
using UnityEngine;

namespace FreschGames.Core.TemplateSystem
{
    public abstract class TemplateGroup : BootStep
    {
        protected void Assign<T>(T value)
            where T : Object
        {
            Template<T>.Assign(value);
        }
    }
}
