using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAds : MonoBehaviour
{

    static int count = 0;

    public void ShowAd()
    {


        Advertisement.Initialize("1398498", true);
        Advertisement.Show();

    }

    private void HandleAdResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                count++;
                if (count <= 5)
                {
                    Debug.Log("+100 XP!");
                    if (count == 5)
                    {
                        count = 0;
                        Debug.Log("Ads will be available after next 2 hours");
                        // OnClickDisableObj(this);
                    }
                }
                break;

            case ShowResult.Skipped:
                Debug.Log("Skipped ad");
                break;

            case ShowResult.Failed:
                Debug.Log("Couldn't fetch Ad");
                break;
        }
    }


}
