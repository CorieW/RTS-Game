using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesBarUI : MonoBehaviour
{
    public ClientHandler clientHandler;

    public Text foodCountText;
    public Text woodCountText;
    public Text stoneCountText;
    public Text goldCountText;


    // Update is called once per frame
    void Update()
    {
        foodCountText.text = clientHandler.player.resources.GetResourceQuantity(Resource.Food).ToString();
        woodCountText.text = clientHandler.player.resources.GetResourceQuantity(Resource.Wood).ToString();
        stoneCountText.text = clientHandler.player.resources.GetResourceQuantity(Resource.Stone).ToString();
        goldCountText.text = clientHandler.player.resources.GetResourceQuantity(Resource.Gold).ToString();
    }
}
