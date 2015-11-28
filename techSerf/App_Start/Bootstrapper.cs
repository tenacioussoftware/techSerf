namespace techSerfWeb
{
    using Nancy;
    using Nancy.Conventions;

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        // The bootstrapper enables you to reconfigure the composition of the framework,
        // by overriding the various methods and properties.
        // For more information https://github.com/NancyFx/Nancy/wiki/Bootstrapper
        protected override void ApplicationStartup(Nancy.TinyIoc.TinyIoCContainer container, Nancy.Bootstrapper.IPipelines pipelines)
        {
            Conventions.ViewLocationConventions.Clear();
            Conventions.ViewLocationConventions.Add((viewName, model, context) =>
            {
                string viewLocation = string.Concat("Views/", viewName);

                if (context.ModuleName != null && context.ModuleName.Equals("Admin"))
                {
                    viewLocation = string.Concat("Areas/Admin/Views/", viewName);
                }

                return viewLocation;
            });

            base.ApplicationStartup(container, pipelines);

            //Nancy.ViewEngines.Razor.RazorViewEngine
            var engine = container.Resolve<Nancy.ViewEngines.Razor.RazorViewEngine>();

        }

        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/Scripts", "Scripts"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/admin/Content", "/Areas/Admin/Content"));
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("/admin/Scripts", "/Areas/Admin/Scripts"));
            base.ConfigureConventions(nancyConventions);
        }
    }
}