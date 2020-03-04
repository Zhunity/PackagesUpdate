using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPackage : Property
{
	Property displayName;
	IPackageVersion installedVersion;
	IPackageVersion latestVersion;

	// the recommended version to install or update to
	IPackageVersion recommendedVersion;


	// the primary version is most important version that we want to show to the user
	// it will be the default that will be displayed if no versions are selected
	IPackageVersion primaryVersion;

	public IPackage(Class belongMember, string name) : base(belongMember, name)
	{
		displayName = new Property(this, "displayName");
		installedVersion = new IPackageVersion(this, "installedVersion");
		latestVersion = new IPackageVersion(this, "latestVersion");
		recommendedVersion = new IPackageVersion(this, "recommendedVersion");
		primaryVersion = new IPackageVersion(this, "primaryVersion");
	}

	protected override void OnSetBelong()
	{
		Debug.Log("");
		Debug.Log("----------------------------" + displayName.GetValue() + " begin--------------------------------");
		Debug.Log("installedVersion:\t" + installedVersion.versionId.GetValue() + "\n" + displayName.GetValue());
		Debug.Log("latestVersion:\t" + latestVersion.versionId.GetValue() + "\n" + displayName.GetValue());
		Debug.Log("recommendedVersion:\t" + recommendedVersion.versionId.GetValue() + "\n" + displayName.GetValue());
		Debug.Log("primaryVersion:\t" + primaryVersion.versionId.GetValue() + "\n" + displayName.GetValue());
		Debug.Log("----------------------------" + displayName.GetValue() + " end--------------------------------");
		Debug.Log("");
	}
}
