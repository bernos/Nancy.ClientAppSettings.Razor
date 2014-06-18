Razor view helpers for outputting javascript application settings managed on the server via the `Nancy.ClientAppSettings` package.

This package depends on the `Nancy.ClientAppSettings` package. See [here](https://bitbucket.org/bernos/nancy.clientappsettings) for the Nancy.ClientAppSettings docs.

## Installation

With Nuget

	Install-Package Nancy.ClientAppSettings.Razor

## Usage

To render the global `Settings` javascript object, including surrounding `<script>` element use

```csharp
@Html.RenderClientAppSettings()
```

This will output

```html
<script>
	var Settings = {
		"SettingOne" : "ValueOne",
		"SettingTwo" : "ValueTwo"
		//...
	};
</script>
```

By default app settings are output as a global variable named "Settings". You can easily change the name of the javascript variable using the WithVariableName() method in your bootstrapper

```csharp
protected override void ApplicationStartup(Nancy.TinyIoc.TinyIoCContainer container, Nancy.Bootstrapper.IPipelines pipelines)
{
	base.ApplicationStartup(container, pipelines);
        
	ClientAppSettings.Enable(pipelines)
		.WithVariableName("AppSettings")
		.WithAppSettings("MyAppSettingOne", "MyOtherAppSetting" ...);
}
```

To omit the surrounding `<script>` element, simply pass `false` to the `RenderClientAppSettings()` call

```html
@Html.RenderClientAppSettings(false)
```

You can also output a single appsetting from your web.config file by using the `AppSetting` extension method

```html
<script src="https://maps.googleapis.com/maps/api/js?libraries=places&key=@Html.AppSetting("Google:ApiKey")&sensor=false"></script>
```
