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
        [field: SerializeField] public bool IsScenePersistent { get; private set; }

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


        // Called by ManagerSystem.Awake()
        public virtual void SystemAwake() { }

        // Called by ManagerSystem.Start()
        public virtual void SystemStart() { }

        // Called by ManagerSystem.Update()
        public virtual void SystemUpdate() { }

        // Called by ManagerSystem.LateUpdate()
        public virtual void SystemLateUpdate() { }

        // Called by ManagerSystem.OnEnable()
        public virtual void SystemEnable() { }

        // Called by ManagerSystem.OnDisable()
        public virtual void SystemDisable() { }

        // Called as soon as the SceneHook was created
        protected virtual void OnSceneHookCreated() { }

        protected void CreateSceneHook()
        {
            if (this.IsScenePersistent)
            {
                if (this.hook == null)
                {
                    GameObject hookObject = new GameObject($"{this.GetType().Name} Hook");
                    this.Hook = hookObject.AddComponent<ManagerHook>();
                    this.Hook.Set(this);

                    this.OnSceneHookCreated();
                }
            }
        }
    }

#if UNITY_EDITOR
    public abstract partial class Manager : ScriptableObject
    {
        protected virtual void Awake()
        {

        }

        protected virtual void OnEnable()
        {
            if (Application.IsPlaying(this))
            {
                this.CreateSceneHook();
            }
            else if (UnityEditor.EditorApplication.isPlayingOrWillChangePlaymode)
            {
                UnityEditor.EditorApplication.playModeStateChanged += this.EditorApplication_PlayModeStateChanged;

                return;
            }
        }

        protected virtual void OnDisable()
        {

        }

        protected virtual void OnDestroy()
        {

        }

        private void EditorApplication_PlayModeStateChanged(UnityEditor.PlayModeStateChange stateChange)
        {
            if (stateChange == UnityEditor.PlayModeStateChange.EnteredPlayMode)
            {
                UnityEditor.EditorApplication.playModeStateChanged -= this.EditorApplication_PlayModeStateChanged;
                this.CreateSceneHook();
            }
        }
    }
#endif

#if !UNITY_EDITOR
    public abstract partial class Manager : ScriptableObject
    {
        protected virtual void Awake()
        {

        }

        protected virtual void OnEnable()
        {
            this.CreateSceneHook();
        }

        protected virtual void OnDisable()
        {

        }

        protected virtual void OnDestroy()
        {

        }
    }
#endif
}