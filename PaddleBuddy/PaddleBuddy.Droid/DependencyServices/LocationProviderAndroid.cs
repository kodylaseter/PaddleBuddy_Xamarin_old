using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Locations;
using Android.OS;
using PaddleBuddy.Core.DependencyServices;
using PaddleBuddy.Core.Models.Map;
using PaddleBuddy.Core.Services;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

namespace PaddleBuddy.Droid.DependencyServices
{
    public class LocationProviderAndroid : BaseDependencyServiceAndroid, ILocationProvider
    {
        private readonly Listener _locationListener;
        private readonly LocationManager _locationManager;
        private readonly Criteria _criteria;

        public LocationProviderAndroid()
        {
            _locationListener = new Listener();
            _locationManager = Application.Context.GetSystemService(Context.LocationService) as LocationManager;
            if (_locationManager != null && CheckPermission().Result)
            {
                _criteria = new Criteria
                {
                    Accuracy = Accuracy.Fine,
                    PowerRequirement = Power.NoRequirement
                };
                _locationManager.RequestSingleUpdate(_criteria, _locationListener, Looper.MainLooper);
            }
            else
            {
                MessengerService.Toast(this, "could not create location manager", false);
            }
        }

        public async Task<bool> CheckPermission()
        {
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
            if (status != PermissionStatus.Granted)
            {
                var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
                status = results[Permission.Location];
            }
            if (status == PermissionStatus.Granted)
            {
                return true;
            }
            MessengerService.Toast(this, "Error requesting permission, try again", true);
            return false;
        }

        public Point CurrentLocation
        {
            get
            {
                if (!CheckPermission().Result)
                {
                    return null;
                }
                _locationManager.RequestSingleUpdate(_criteria, _locationListener, Looper.MainLooper);
                if (_locationListener.CurrentLocation == null)
                {
                    MessengerService.Toast(this, "Current location not set!", true);
                    return new Point
                    {
                        Lat = 34.0754,
                        Lng = -84.2941
                    };
                }

                return new Point
                {
                    Lat = _locationListener.CurrentLocation.Latitude,
                    Lng = _locationListener.CurrentLocation.Longitude
                };
            }
        }

        class Listener : Java.Lang.Object, ILocationListener
        {
            public Location CurrentLocation { get; set; }

            public void OnLocationChanged(Location location)
            {
                CurrentLocation = location;
            }

            public void OnProviderDisabled(string provider)
            {
                throw new NotImplementedException();
            }

            public void OnProviderEnabled(string provider)
            {
                throw new NotImplementedException();
            }

            public void OnStatusChanged(string provider, Availability status, Bundle extras)
            {
                throw new NotImplementedException();
            }
        }
    }
}