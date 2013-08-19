AngularPartialsBundles
======================

A library for bundeling angularjs partials/templates and pushing them to the $templateCache

Add an `AngularPartialsTransform` to your templates bundle:

    var angularTemplatesTransform = new AngularPartialsTransform("angularPartialsBundles");
    bundles.Add(new Bundle("~/bundles/partials", angularTemplatesTransform)
        .IncludeDirectory("~/app/partials/", "*.html", true)
        );
