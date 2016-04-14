using System;
using Android.App;
using Android.Content;
using Android.Locations;
using Android.OS;
using PaddleBuddy.Core.DependencyServices;
using PaddleBuddy.Core.Models.Map;
using PaddleBuddy.Core.Models.Messages;

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
            if (_locationManager != null)
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
                Messenger.Publish(new ToastMessage(this, "could not create location manager", false));
            }
        }

        public Point GetCurrentLocation()
        {
            _locationManager.RequestSingleUpdate(_criteria, _locationListener, Looper.MainLooper);
            if (_locationListener.CurrentLocation == null)
            {
                Messenger.Publish(new ToastMessage(this, "Current location not set!", true));
                return new Point
                {
                    Lat = 0,
                    Lng = 0
                };
            }

            return new Point
            {
                Lat = _locationListener.CurrentLocation.Latitude,
                Lng = _locationListener.CurrentLocation.Longitude
            };
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