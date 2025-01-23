using FreschGames.Core.EventSystem;

namespace FreschGames.Core.TemplateSystem
{
    public class TemplateChangedEvent<T> : IEvent
    {
        public T OldTemplate { get; private set; }
        public T NewTemplate { get; private set; }


        public TemplateChangedEvent(T oldTemplate, T newTemplate)
        {
            this.OldTemplate = oldTemplate;
            this.NewTemplate = newTemplate;
        }
    }
}
