namespace Modar_F
{
    public class Scene
    {
        public State state;
        public double length;
        public Easing easing;
        public Scene(State state, double length, Easing easing)
        {
            this.state = state;
            this.length = length;
            this.easing = easing;
        }
    }
}
