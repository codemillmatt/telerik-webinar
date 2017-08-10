using System;
using System.Collections.Generic;
namespace Telerik
{
    public class SettingsItem
    {
        public string Name { get; set; }
        public SettingType TypeOfSetting { get; set; }
        public Section SettingSection { get; set; }
    }

    public enum Section
    {
        About,
        App
    }

    public enum SettingType
    {
        Disclosure,
        Switch,
        Upgrade
    }


    public class AllSettings
    {
        public List<SettingsItem> AllTheSettings { get; set; }

        public AllSettings()
        {
            AllTheSettings = new List<SettingsItem>
            {
                new SettingsItem {
                    Name = "Profile", TypeOfSetting = SettingType.Disclosure, SettingSection= Section.About
                },
                new SettingsItem{
                    Name="Favorite Foods", TypeOfSetting= SettingType.Disclosure, SettingSection=Section.About
                },
                new SettingsItem {
                    Name="Light/Dark Mode", TypeOfSetting = SettingType.Switch, SettingSection=Section.App
                },
                new SettingsItem {
                    Name = "About", TypeOfSetting= SettingType.Disclosure, SettingSection = Section.App
                },
                new SettingsItem {
                    Name = "Upgrade", TypeOfSetting=SettingType.Upgrade, SettingSection = Section.App
                }
            };
        }
    }


}
