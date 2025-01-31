using FreschGames.Core.EventSystem;
using UnityEngine;

namespace FreschGames.Core.TemplateSystem
{
    public static class Template<T> 
        where T : Object
    {
        public static T Instance { get; private set; }

        public static T Instantiate()
        {
            return GameObject.Instantiate(Instance);
        }

        public static void Assign(T instance)
        {
            T oldTemplate = Template<T>.Instance;
            T newTemplate = Template<T>.Instance = instance;

            Event<TemplateChangedEvent<T>>.Invoke(new TemplateChangedEvent<T>(oldTemplate, newTemplate));
        }
    }
}
