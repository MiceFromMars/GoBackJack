namespace GBJ.UILogic
{
    public abstract class WindowController
    {
        protected abstract WindowView View { get; }

        public virtual void Hide(bool animIsPlayed = true)
        {
            View.Hide(animIsPlayed);
        }

        public virtual void Show(bool animIsPlayed = true)
        {
            View.Show(animIsPlayed);
        }
    }
}