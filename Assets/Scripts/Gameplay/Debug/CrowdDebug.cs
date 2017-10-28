using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrowdDebug : MonoBehaviour {

    public Text textComp;

	void Update () {

        var text = "CrowdDebug:\n";
        var rooms = Config.Instance.Rooms;
        foreach (var room in rooms)
        {
            text += room.transform.parent.name+"\n";
            foreach (var crowd in room.Crowds)
            {
                var text2 = "";
                foreach (var bot in crowd.Bots)
                {
                    text2 += bot.name + "\n";

                }
                text += text2 == "" ? "-" : text2;
            }
            text += "\n";
        }
        textComp.text = text;
    }
}
