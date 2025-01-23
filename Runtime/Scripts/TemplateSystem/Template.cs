using FreschGames.Core.EventSystem;

namespace FreschGames.Core.TemplateSystem
{
    public static class Template<T>
    {
        public static T Instance { get; private set; }

        public static void Assign(T instance)
        {
            T oldTemplate = Template<T>.Instance;
            T newTemplate = Template<T>.Instance = instance;

            Event<TemplateChangedEvent<T>>.Invoke(new TemplateChangedEvent<T>(oldTemplate, newTemplate));
        }
    }
}
