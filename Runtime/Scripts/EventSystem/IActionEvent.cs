using System;

namespace FreschGames.Core.EventSystem
{
    public interface IActionEvent<T>
    {
        public Action<T> OnEvent { get; set; }
        public Action OnCall { get; set; }
    }
}
