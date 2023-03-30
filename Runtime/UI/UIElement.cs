using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace FreschGames.Core.UI
{
    public abstract class UIElement : MonoBehaviour
    {
        [field: SerializeField] public UIDocument Document { get; private set; }

        public Action OnUpdate { get; set; }

        public void Register(Action action)
        {
            this.OnUpdate += action;
        }


        protected virtual void Update()
        {
            this.OnUpdate?.Invoke();
        }
    }
}
