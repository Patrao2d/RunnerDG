using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
    private string playStoreID = "3688491";
    private string appStoreID = "3688490";

    private string interstitialAd = "video";
    private string rewardedVideoAd = "rewardedVideo";
    private string bannerAd = "banner";

    public bool isTargetPlayStore;
    public bool isTestAd;

    private static AdManager _instance;

    public static AdManager instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            _instance = this;
        }

        //If instance already exists and it's not this:
        else if (instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }

        DontDestroyOnLoad(transform.gameObject);
    }

    void Start()
    {
        _instance = this;
        Advertisement.AddListener(this);
        StartAd();
    }

    private void StartAd()
    {
       if (isTargetPlayStore)
        {
            Advertisement.Initialize(playStoreID, isTestAd);
            return;
        }
        Advertisement.Initialize(appStoreID, isTestAd);
    }

    public void PlayInterstitialAd()
    {
        if (!Advertisement.IsReady(interstitialAd))
            return;
        Advertisement.Show(interstitialAd);

    }

    public void PlayRewardAd()
    {
        if (!Advertisement.IsReady(rewardedVideoAd))
            return;
        Advertisement.Show(rewardedVideoAd);
        Player.instance.ActiveShield();
    }

    public void PlayBannerAd()
    {
        if (!Advertisement.IsReady(bannerAd))
            return;

        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show(bannerAd);
    }

    public void HideBannerAd()
    {
        Advertisement.Banner.Hide();
    }

    public void OnUnityAdsReady(string placementId)
    {
        
    }

    public void OnUnityAdsDidError(string message)
    {
        
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        Time.timeScale = 1;
        switch (showResult)
        {
            case ShowResult.Failed:
                if (placementId == rewardedVideoAd)
                {
                    Player.instance.ActiveShield();
                }
                else if (placementId == interstitialAd)
                {
                    GameCanvas.instance.NextLevel();
                }
                break;
            case ShowResult.Finished:
                if (placementId == rewardedVideoAd)
                {
                    Player.instance.ActiveShield();
                }
                else if (placementId == interstitialAd)
                {
                    GameCanvas.instance.NextLevel();
                }
                break;
            case ShowResult.Skipped:
                if (placementId == rewardedVideoAd)
                {
                    Player.instance.ActiveShield();
                }
                else if (placementId == interstitialAd)
                {
                    GameCanvas.instance.NextLevel();
                }
                break;
        }
    }
}
