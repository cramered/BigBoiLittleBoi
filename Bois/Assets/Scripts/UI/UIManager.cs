using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Helper class for UI hearts.
public class UIManager : MonoBehaviour {

    public UIPlayerHealth healthPanel;

    public void SetLifes(int lifes){
        while (healthPanel.currentLifes > lifes) {
            healthPanel.RemoveLife ();
        }
    }
}
