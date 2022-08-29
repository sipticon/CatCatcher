using UnityEngine;
using UnityEngine.Advertisements;
 
public class BannerAds : MonoBehaviour
{

    [SerializeField] BannerPosition _bannerPosition = BannerPosition.BOTTOM_CENTER;
    private string _androidAdUnitId = "Banner_Android";
    private string _iOSAdUnitId = "Banner_iOS";
    private string _adUnitId = null; // This will remain null for unsupported platforms.
 
    void Start()
    {
#if UNITY_IOS
        _adUnitId = _iOSAdUnitId;
#elif UNITY_ANDROID
        _adUnitId = _androidAdUnitId;
#endif
        Advertisement.Banner.SetPosition(_bannerPosition);
            LoadBanner();
    }
    
    public void LoadBanner()
    {
        BannerLoadOptions options = new BannerLoadOptions
        {
            loadCallback = OnBannerLoaded,
            errorCallback = OnBannerError
        };
        
        Advertisement.Banner.Load(_adUnitId, options);
    }
    
    void OnBannerLoaded()
    {
        //Debug.Log("Banner loaded");
        ShowBannerAd();
    }
    
    void OnBannerError(string message)
    {
        //Debug.Log($"Banner Error: {message}");
    }
    
    void ShowBannerAd()
    {
        BannerOptions options = new BannerOptions
        {
            clickCallback = OnBannerClicked,
            hideCallback = OnBannerHidden,
            showCallback = OnBannerShown
        };
        
        Advertisement.Banner.Show(_adUnitId, options);
    }
    
    void OnBannerClicked() { }
    void OnBannerShown() { }
    void OnBannerHidden() { }
    
}