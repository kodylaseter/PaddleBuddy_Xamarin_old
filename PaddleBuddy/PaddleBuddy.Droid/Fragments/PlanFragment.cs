using Android.Runtime;
using MvvmCross.Droid.Support.V7.Fragging.Attributes;
using PaddleBuddy.Core.ViewModels;

namespace PaddleBuddy.Droid.Fragments
{
    [MvxFragment(typeof(PlanViewModel), Resource.Id.content_frame, true)]
    [Register("paddlebuddy.droid.fragments.PlanFragment")]
    public class PlanFragment : BaseFragment<PlanViewModel>
    {
        protected override int FragmentId => Resource.Layout.fragment_plan;
    }
}