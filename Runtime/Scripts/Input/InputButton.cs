using UnityEngine;

namespace FGC.Input
{
    [CreateAssetMenu(fileName = "Input Button", menuName = "Data/Input/new Input Button")]
    public class InputButton : InputValue
    {
        public float DownTime { get; private set; }
        public float UpTime { get; private set; }

        protected override void OnLink(ref InputValueUpdate action)
        {
            action += this.Update;
        }

        void Update()
        {
            if (this.IsPressed)
            {
                this.DownTime += Time.deltaTime;
                this.UpTime = 0;
            }
            else
            {
                this.DownTime = 0;
                this.UpTime += Time.deltaTime;
            }
        }
    }
}