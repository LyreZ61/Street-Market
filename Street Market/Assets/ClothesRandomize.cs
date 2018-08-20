using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClothesRandomize : MonoBehaviour {

    public ClothesSystem clothes;

    public Image Haare;
    public Image Kopf;
    public Image Körper;
    public Image ArmLinks;
    public Image ArmRechts;
    public Image HoseLinks;
    public Image HoseRechts;
    public Image SchuheLinks;
    public Image SchuheRechts;

    [HideInInspector]
    public int GeschlechtValue;

    private void Start()
    {
        //Haare
        var ArrayClotheIndex = clothes.MyClothes[GeschlechtValue].Haare;
        var RandomClotheNumber = Random.Range(0, ArrayClotheIndex.Length);
        Haare.sprite = ArrayClotheIndex[RandomClotheNumber];

        //Kopf
        ArrayClotheIndex = clothes.MyClothes[GeschlechtValue].Kopf;
        RandomClotheNumber = Random.Range(0, ArrayClotheIndex.Length);
        Kopf.sprite = ArrayClotheIndex[RandomClotheNumber];

        //Körper
        ArrayClotheIndex = clothes.MyClothes[GeschlechtValue].Körper;
        RandomClotheNumber = Random.Range(0, ArrayClotheIndex.Length);
        Körper.sprite = ArrayClotheIndex[RandomClotheNumber];

        //Arm
        ArrayClotheIndex = clothes.MyClothes[GeschlechtValue].Arm;
        RandomClotheNumber = Random.Range(0, ArrayClotheIndex.Length);
        ArmLinks.sprite = ArrayClotheIndex[RandomClotheNumber];
        ArmRechts.sprite = ArrayClotheIndex[RandomClotheNumber];

        //Hose
        ArrayClotheIndex = clothes.MyClothes[GeschlechtValue].Hose;
        RandomClotheNumber = Random.Range(0, ArrayClotheIndex.Length);
        HoseLinks.sprite = ArrayClotheIndex[RandomClotheNumber];
        HoseRechts.sprite = ArrayClotheIndex[RandomClotheNumber];

        //Schuhe
        ArrayClotheIndex = clothes.MyClothes[GeschlechtValue].Schuhe;
        RandomClotheNumber = Random.Range(0, ArrayClotheIndex.Length);
        SchuheLinks.sprite = ArrayClotheIndex[RandomClotheNumber];
        SchuheRechts.sprite = ArrayClotheIndex[RandomClotheNumber];
    }
}
