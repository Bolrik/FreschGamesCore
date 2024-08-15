using System;

namespace FreschGames.Core.EventSystem
{
    public class ActionEvent<T> : IActionEvent<T> where T : IEvent
    {
        Action<T> OnEvent { get; set; } = _ => { };
        Action OnCall { get; set; } = () => { };

        Action<T> IActionEvent<T>.OnEvent
        {
            get => this.OnEvent;
            set => this.OnEvent = value;
        }
        Action IActionEvent<T>.OnCall
        {
            get => this.OnCall;
            set => this.OnCall = value;
        }

        public ActionEvent(Action<T> onEvent) => this.OnEvent = onEvent;
        public ActionEvent(Action onCall) => this.OnCall = onCall;
    }
}
