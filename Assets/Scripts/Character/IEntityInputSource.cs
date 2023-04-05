namespace Character
{
    public interface IEntityInputSource
    {
        float HorizontalDirection { get; }
        bool Jump { get; }

        void ResetOneTimeAction();
    }
}