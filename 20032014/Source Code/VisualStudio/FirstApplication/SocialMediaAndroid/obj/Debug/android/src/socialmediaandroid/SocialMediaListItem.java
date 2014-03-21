package socialmediaandroid;


public class SocialMediaListItem
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("SocialMediaAndroid.SocialMediaListItem, SocialMediaAndroid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", SocialMediaListItem.class, __md_methods);
	}


	public SocialMediaListItem () throws java.lang.Throwable
	{
		super ();
		if (getClass () == SocialMediaListItem.class)
			mono.android.TypeManager.Activate ("SocialMediaAndroid.SocialMediaListItem, SocialMediaAndroid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
