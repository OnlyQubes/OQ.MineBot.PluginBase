namespace OQ.MineBot.PluginBase.Classes
{
    public class Rotation : IRotation
    {
        public float yaw
        {
            get { return _yaw; }
            set
            {
                if (value > 180) _yaw = value - 360;
                else if (value < -180) _yaw = value + 360;
                else _yaw = value;
            }
        }

        public float _yaw;

        public float pitch { get; set; }

        public Rotation(float yaw, float pitch)
        {
            this.yaw = yaw;
            this.pitch = pitch;
        }

        public void Set(float yaw, float pitch)
        {
            this.yaw = yaw;
            this.pitch = pitch;
        }
    }
}