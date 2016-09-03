using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public static class GameState {

    public enum GameStates { Play, Spectate };

    public static GameStates gameState = GameStates.Spectate;

    public static GameObject instructionsText;

    public static void toggleSpectate()
    {
        if (gameState.Equals(GameStates.Play))
        {
            gameState = GameStates.Spectate;
            instructionsText.SetActive(true);
        }
        else
        {
            gameState = GameStates.Play;
            instructionsText.SetActive(false);
        }
    }




}
