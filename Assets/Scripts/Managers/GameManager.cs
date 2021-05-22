using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("Gameplay")]
    [SerializeField]
    GameCoordinator gameCoordinator;
    public enum GameState
    {
        Idle, Gameplay, Win, Lose, Wait, Pregame, Postgame, Disabled, Loading
    }
    public GameState CurrentState;

    #region Core Functions
    private void Start()
    {
        UIManager.Instance.RefreshPanel(0);
        ShopManager.Instance.Instantiate();
        gameCoordinator.Reload();
    }
    public void StartGame()
    {
        gameCoordinator.StartGame();

        setGameState();
    }

    public void GameOver()
    {
        gameCoordinator.GameOver();

        setLoseState();
    }
    public void WinGame()
    {
        gameCoordinator.WinGame();

        setWinState();
    }

    public void Reload()
    {
        gameCoordinator.Reload();
        //gameCoordinator.LoadLevel(DataManager.Player.Level);

        //COMMONS.ResetValues();

        setIdleState();

    }



    private void playerProgress()
    {

        //DataManager.Player.Level++;

        //if (DataManager.Player.Experience >= DataManager.GameData.Experiences[DataManager.Player.Level])
        //{
        //    DataManager.Player.Experience -= DataManager.GameData.Experiences[DataManager.Player.Level];
        //    DataManager.Player.Level++;
        //}
        //DataManager.Player.Save();

    }

    public void Refresh()
    {
        //Refresh desired values or views here
    }

    public void GameExit()
    {
        //For offline earning calculation save user earning
        //if (DataManager.Player.ExitTime == "")
        //{
        //    DataManager.Player.Coin += 000;
        //    GamePassive();
        //}
    }

    public void GamePassive()
    {
        //For offline earning calculation
        //DataManager.Player.ExitTime = TimeHelper.GetLocalTimeAsString();
        //DataManager.Player.Save();
    }

    public void GameActive()
    {
        //Offline earning calculations
        //if (DataManager.Player.ExitTime != "")
        //{
        //    float passedTime = (float)TimeHelper.SubstractCurrent(DataManager.Player.ExitTime);
        //    DataManager.Player.ExitTime = "";
        //    if (passedTime < 60) passedTime = 0;
        //    if (passedTime > 21600) passedTime = 21600;
        //    if (passedTime > 0)
        //    {
        //        passedTime = passedTime / 3600f;
        //    }
        //}
    }
    #endregion
    #region States
    protected void setLoseState()
    {
        CurrentState = GameState.Lose;
        UIManager.Instance.OpenPage(3);
    }
    protected void setWinState()
    {
        CurrentState = GameState.Win;
        UIManager.Instance.OpenPage(2);
    }
    protected void setGameState()
    {
        CurrentState = GameState.Gameplay;
        UIManager.Instance.OpenPage(1);

    }

    protected void setIdleState()
    {
        CurrentState = GameState.Idle;
        UIManager.Instance.OpenPage(0);
    }


    protected void setLoading()
    {
        CurrentState = GameState.Loading;
        //ScreenManager.Module.HideAll();
        //ScreenManager.Module.Show(ScreenTag.LoadingScreen);
    }

    protected void setWaitState()
    {
        CurrentState = GameState.Wait;
    }

    protected void setPreGameState()
    {
        CurrentState = GameState.Pregame;
    }



    protected void setDisableState()
    {
        CurrentState = GameState.Disabled;
    }
    #endregion
    #region Updates
    private void Update()
    {
        //Add Those Update due to GameState if there is a necessary
    }

    protected void loadingUpdate()
    {

    }

    protected void idleUpdate()
    {

    }

    protected void waitUpdate()
    {

    }

    protected void gameUpdate()
    {

    }

    protected void preGameUpdate()
    {

    }

    protected void postGameUpdate()
    {

    }

    protected void disableUpdate()
    {

    }

    protected void endUpdate()
    {

    }

    private void cheatUpdate()
    {

    }


    #endregion
}
