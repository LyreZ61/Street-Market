using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class TheGameSystem : MonoBehaviour {
  
    public TextMeshPro Gold_Text;
    public Text ss;
    public static int Gold;

    public void GoldVerdient(int Goldplus)
    {
        Gold += Goldplus;
        Gold_Text.text = "Gold :" + Gold.ToString();
    }
}
