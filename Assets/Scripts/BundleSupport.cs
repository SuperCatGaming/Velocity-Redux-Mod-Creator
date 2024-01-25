using UnityEngine;

public class BundleSupport
{
    private static AssetBundle bundle;

    public static AssetBundle GetBundle() {
        if (bundle == null) {
            AssetBundle.UnloadAllAssetBundles(true);
            bundle = AssetBundle.LoadFromFile("Assets/Resources/modsupport");
        }

        return bundle;
    }
}
