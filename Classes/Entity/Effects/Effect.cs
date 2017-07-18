using System;

namespace OQ.MineBot.PluginBase.Classes.Entity
{
    public class Effect
    {
        /// <summary>
        /// Id of the effect.
        /// </summary>
        public Effects Id { get; private set; }

        /// <summary>
        /// Level of the effect.
        /// (+1 for the display)
        /// </summary>
        public byte Level { get; private set; }

        /// <summary>
        /// Duration in second.
        /// </summary>
        public int Duration { get; private set; }
        /// <summary>
        /// Time that the potion ends.
        /// </summary>
        public DateTime Ends { get; }

        /// <summary>
        /// Should the particles be invisible?
        /// </summary>
        public bool HideParticles { get; set; }

        /// <summary>
        /// Is this effect expired?
        /// </summary>
        public bool Expired
        {
            get
            {
                if (_expired) return true;
                return Ends.Subtract(DateTime.Now).TotalMilliseconds < 0;
            }
            set { _expired = value; }
        }
        private bool _expired;

        public Effect(Effects Id, byte Level, int Duration, bool HideParticles) {
            this.Id = Id;
            this.Level = Level;
            this.Duration = Duration;
            this.HideParticles = HideParticles;
            this.Ends = DateTime.Now.AddSeconds(Duration);
        }
    }
}