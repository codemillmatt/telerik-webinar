using System;
using Android.Views;
using Android.Widget;
using Android.App;
using System.Collections.Generic;

namespace Telerik.Droid
{
    public class SettingsListAdapter : BaseAdapter<SettingsItem>
    {
        List<SettingsItem> items;
        Activity context;

        public SettingsListAdapter(Activity context, List<SettingsItem> items) : base()
        {
            this.context = context;
            this.items = items;

        }

        public override int ViewTypeCount => 3 ;

        public override SettingsItem this[int position] => items[position];

        public override int Count => items.Count;

        public override long GetItemId(int position) => position;

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            var view = convertView;

            if (convertView == null)
            {
                switch (item.TypeOfSetting)
                {
                    case SettingType.Disclosure:
                        view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
                        break;
                    case SettingType.Switch:
                        view = context.LayoutInflater.Inflate(Resource.Layout.SwitchRow, null);
                        break;
                    default:
                        view = context.LayoutInflater.Inflate(Resource.Layout.UpgradeRow, null);
                        break;
                }
            }

            switch (item.TypeOfSetting)
            {
                case SettingType.Disclosure:
                    view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.Name;
                    break;
                case SettingType.Switch:
                    view.FindViewById<TextView>(Resource.Id.switchText).Text = item.Name;
                    break;
                default:
                    view.FindViewById<TextView>(Resource.Id.upgradeText).Text = item.Name;
                    break;
            }

            return view;
        }

        public override int GetItemViewType(int position)
        {
            // 0 = disclosure
            // 1 = switch
            // 2 = action overflow

            return (int)items[position].TypeOfSetting;
        }


    }
}
