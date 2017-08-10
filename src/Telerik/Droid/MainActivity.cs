using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System.Linq;

namespace Telerik.Droid
{
    [Activity(Label = "Telerik", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var list = FindViewById<ListView>(Resource.Id.settingsList);

            var separatedAdapter = new SeparatedListAdapter(this);
            var settingService = new AllSettings();
            var settings = settingService.AllTheSettings;

            separatedAdapter.AddSection("About Me", new SettingsListAdapter(this, settings.Where(s => s.SettingSection == Section.About).ToList()));
            separatedAdapter.AddSection("App Settings", new SettingsListAdapter(this, settings.Where(s => s.SettingSection == Section.App).ToList()));

            //list.Adapter = new SettingsListAdapter(this, settings);
            list.Adapter = separatedAdapter;
        }
    }
}

