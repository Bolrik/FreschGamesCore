using UnityEngine;

namespace FreschGames.Core.Managers
{
    /// <summary>
    /// Launch Unity editor and open a scene referencing the object, or select the object in the inspector
    /// Awake -> OnEnable
    /// Enter Play Mode (Editor)
    /// -> OnDisable -> OnEnable
    /// Load a different scene that does not reference this object
    /// -> OnDisable
    /// </summary>


    public abstract partial class Manager : ScriptableObject
    {
        private ManagerHook hook;
        protected ManagerHook Hook
        {
            get
            {
                if (this.hook == null)
                {
                    this.CreateSceneHook();
                }

                return hook;
            }
            set { hook = value; }
        }

        public void CreateSceneHook()
        {
            if (this.hook == null)
            {
                GameObject hookObject = new GameObject($"{this.GetType().Name} Hook");
                this.Hook = hookObject.AddComponent<ManagerHook>();
                this.Hook.Set(this);
            }
        }
    }

//#if UNITY_EDITOR
//    public abstract partial class Manager : ScriptableObject
//    {
//        protected virtual void Awake()
//        {

//        }

//        protected virtual void OnEnable()
//        {
//            if (Application.IsPlaying(this))
//            {
//                this.CreateSceneHook();
//            }
//            else if (UnityEditor.EditorApplication.isPlayingOrWillChangePlaymode)
//            {
//                UnityEditor.EditorApplication.playModeStateChanged += this.EditorApplication_PlayModeStateChanged;

//                return;
//            }
//        }

//        protected virtual void OnDisable()
//        {

//        }

//        protected virtual void OnDestroy()
//        {

//        }

//        private void EditorApplication_PlayModeStateChanged(UnityEditor.PlayModeStateChange stateChange)
//        {
//            if (stateChange == UnityEditor.PlayModeStateChange.EnteredPlayMode)
//            {
//                UnityEditor.EditorApplication.playModeStateChanged -= this.EditorApplication_PlayModeStateChanged;
//                this.CreateSceneHook();
//            }
//        }
//    }
//#endif

//#if !UNITY_EDITOR
//    public abstract partial class Manager : ScriptableObject
//    {
//        protected virtual void Awake()
//        {

//        }

//        protected virtual void OnEnable()
//        {
//            this.CreateSceneHook();
//        }

//        protected virtual void OnDisable()
//        {

//        }

//        protected virtual void OnDestroy()
//        {

//        }
//    }
//#endif
}