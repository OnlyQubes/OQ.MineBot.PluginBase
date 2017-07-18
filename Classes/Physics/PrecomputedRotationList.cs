using System.Collections.Generic;

namespace OQ.MineBot.PluginBase.Classes.Physics
{
    public class PrecomputedRotationList
    {
        public Queue<IRotation> precomputedRotations { get; set; } = new Queue<IRotation>();

        /// <summary>
        /// Is this path cancelled.
        /// </summary>
        public bool cancelled { get; set; }
        /// <summary>
        /// Is this path completed.
        /// </summary>
        public bool completed { get; set; }

        /// <summary>
        /// Called once the path is cancelled
        /// or completed.
        /// </summary>
        public event StatusChangedDelegate OnStatusChanged;
        public delegate void StatusChangedDelegate(PrecomputedRotationList rotations);

        public PrecomputedRotationList() { }
        public PrecomputedRotationList(Queue<IRotation> precomputedRotations, StatusChangedDelegate OnStatusChanged = null) {
            this.OnStatusChanged += OnStatusChanged;
            this.precomputedRotations = precomputedRotations;
        }

        public bool IsValid() {

            if (cancelled || completed)
                //Already completed.
                return false;

            //Check if the path is completed.
            if (precomputedRotations.Count == 0) {
                //Update state.
                completed = true;
                //Call event.
                OnStatusChanged?.Invoke(this);

                return false;
            }

            //Not yet completed.
            return true;
        }

        public void Cancel() {

            this.cancelled = true;
            this.OnStatusChanged?.Invoke(this);
        }
    }
}