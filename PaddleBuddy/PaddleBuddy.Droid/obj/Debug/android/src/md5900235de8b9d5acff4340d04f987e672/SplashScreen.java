package md5900235de8b9d5acff4340d04f987e672;


public class SplashScreen
	extends md5c293e307133ee8f46151deed2480c6a8.MvxSplashScreenActivity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("PaddleBuddy.Droid.SplashScreen, PaddleBuddy.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", SplashScreen.class, __md_methods);
	}


	public SplashScreen () throws java.lang.Throwable
	{
		super ();
		if (getClass () == SplashScreen.class)
			mono.android.TypeManager.Activate ("PaddleBuddy.Droid.SplashScreen, PaddleBuddy.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}