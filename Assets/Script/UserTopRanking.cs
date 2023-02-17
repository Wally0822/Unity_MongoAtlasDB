using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserTopRanking : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI topRankingUserId = null;
    [SerializeField] TextMeshProUGUI topRankingUserScore = null;
    [SerializeField] TextMeshProUGUI topTenRankingText = null;

    //int topTenRanking = 0;

    public void UiSetting(int id, int score, int ranking)
    {
        topRankingUserId.text = id.ToString();

        Debug.Log("topRankingUserId : " + topRankingUserId.text);
        topRankingUserScore.text = score.ToString();
        Debug.Log("topRankingUserScore : " + topRankingUserScore.text);

        topTenRankingText.text = ranking.ToString();
    }
}
