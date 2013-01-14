namespace Codestellation.Mailer.Core.Templating.Razor
{
    public abstract class RazorMailTemplate<TModel> : RazorMailTemplateBase
    {
        public TModel Model { get; private set; }

        public override void SetModel(object model)
        {
            Model = (TModel) model;
        }
    }
}