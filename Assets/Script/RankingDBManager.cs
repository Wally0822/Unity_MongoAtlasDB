using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RankingDBManager : MonoBehaviour
{
    private RankingDataBase rankingDataBase = null;
    private UserTopRanking topTenUserData = null;

    [SerializeField] TMP_InputField userIdInputField = null;

    [SerializeField] TextMeshProUGUI LevelOneUserId = null;
    [SerializeField] TextMeshProUGUI LevelOneScore = null;
    [SerializeField] TextMeshProUGUI idNotFound = null;

    [SerializeField] GameObject idInputPanel = null;
    [SerializeField] GameObject rankingPanel = null;
    [SerializeField] GameObject levelPanel = null;

    //Button
    [SerializeField] Button startButton = null;
    [SerializeField] Button levelOneButton = null;
    [SerializeField] Button levelTwoButton = null;
    [SerializeField] Button levelThreeButton = null;
    [SerializeField] Button levelFourButton = null;

    // Ranking Inst Pos
    [SerializeField] RectTransform levelOnePos = null;
    [SerializeField] RectTransform levelTwoPos = null;
    [SerializeField] RectTransform levelThreePos = null;
    [SerializeField] RectTransform levelFourPos = null;

    private void Awake()
    {
        rankingDataBase = GameObject.FindGameObjectWithTag("RankingDataBase").GetComponent<RankingDataBase>();

        startButton.onClick.AddListener(() => OnInputId());
        levelOneButton.onClick.AddListener(() => OnClickLevelOneButton());
        levelTwoButton.onClick.AddListener(() => OnClickLevelTwoButton());
        levelThreeButton.onClick.AddListener(() => OnClickLevelThreeButton());
        levelFourButton.onClick.AddListener(() => OnClickLevelFourButton());
    }

    private void OnInputId()
    {
        int userId = int.Parse(userIdInputField.text);
        Debug.Log("userID : " + userId);

        //rankingDataBase.DataFindId(userId);
        idInputPanel.gameObject.SetActive(false);
    }

    private void OnClickLevelOneButton()
    {
        PosSetting(true, false, false, false);

        if (levelOnePos.childCount == 0)
        {
            ShowMyData();
            OnClickRankingShoring(1, 1, levelOnePos);
        }
    }

    private void OnClickLevelTwoButton()
    {
        PosSetting(false, true, false, false);
        if (levelTwoPos.childCount == 0)
        {
            ShowMyData();
            OnClickRankingShoring(1, 2, levelTwoPos);
        }
    }

    private void OnClickLevelThreeButton()
    {
        PosSetting(false, false, true, false);

        if (levelThreePos.childCount == 0)
        {
            ShowMyData();
            OnClickRankingShoring(1, 3, levelThreePos);

        }
    }

    private void OnClickLevelFourButton()
    {
        PosSetting(false, false, false, true);

        if (levelFourPos.childCount == 0)
        {
            ShowMyData();
            OnClickRankingShoring(1, 4, levelFourPos);

        }
    }

    private void PosSetting(bool one, bool two, bool three, bool four)
    {
        levelOnePos.gameObject.SetActive(one);
        levelTwoPos.gameObject.SetActive(two);
        levelThreePos.gameObject.SetActive(three);
        levelFourPos.gameObject.SetActive(four);
    }

    private void ShowMyData()
    {
        int userId = int.Parse(userIdInputField.text);
        Debug.Log("## userID : " + userId);

        // 데이터 베이스에서 입력 한 ID 찾기
        var check = rankingDataBase.FindId(userId);
        Debug.Log("## DB 에서 찾았어요 : " + rankingDataBase.FindId(userId));

        if (check != null)
        {
            int checkId = (int)check.GetValue("id");
            //Debug.Log("## checkId : " + checkId);

            if (userId == checkId)
            {
                // 있으면 표시 없으면 표시안함
                LevelOneUserId.text = $"ID : {userId.ToString()}";
            }
            else
            {
                idNotFound.gameObject.SetActive(true);
                Debug.Log("ID Not Found = ");
            }
        }

        int score = rankingDataBase.DetaFindld(userId);
        LevelOneScore.text = $"Score : {score.ToString()}";
    }

    private async void OnClickRankingShoring(int gameGroup, int gameLevel, RectTransform pos)
    {
        var task = rankingDataBase.GetUserData(gameGroup, gameLevel, pos);
        var result = await task;
        int RankingUser = rankingDataBase.checkCount;
        Debug.Log("RankingUser = " + RankingUser);
    }
}
