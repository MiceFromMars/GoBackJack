using GBJ.UILogic;

public sealed class ComingSoonController : WindowController
{
    protected override WindowView View => _view;

    private readonly ComingSoonView _view;

    public ComingSoonController(ComingSoonView view)
    {
        _view = view;

        _view.OnScreenClicked += ScreenClicked;
    }

    private void ScreenClicked()
    {
        _view.PlayComingSoonTxtAnim();
    }
}
