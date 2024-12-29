using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    //List of all states (forward, backward, left, right)
    private string[] State1 = { "2_WC_to_Palms", "Disabled", "101_MYSK", "106_WC" };
    private string[] State101 = { "102_BOBA", "1_WC_to_Palms", "Disabled", "Disabled" };
    private string[] State102 = { "103_BLACKSMITH", "101_MYSK", "Disabled", "Disabled" };
    private string[] State103 = { "104_SALOON_1", "102_BOBA", "Disabled", "Disabled" };
    private string[] State104 = { "105_SALOON_2", "103_BLACKSMITH", "Disabled", "Disabled" };
    private string[] State105 = { "110_Outside_Path", "104_SALOON_1", "Disabled", "Disabled" };
    private string[] State110 = { "111_Sushi_Counter", "105_SALOON_2", "Disabled", "Disabled" };
    private string[] State111 = { "Disabled", "110_Outside_Path", "Disabled", "Disabled" };

    private string[] State106 = { "107_ARTS_GALLERY", "1_WC_to_Palms", "Disabled", "Disabled" };
    private string[] State107 = { "108_PHARM", "106_WC", "Disabled", "Disabled" };
    private string[] State108 = { "109_NIRVANA 5", "107_ARTS_GALLERY", "Disabled", "Disabled" };
    private string[] State109 = { "Disabled", "108_PHARM", "Disabled", "Disabled" };


    private string[] State2 = { "3_WC_Palms", "1_WC_to_Palms", "Disabled", "Disabled" };
    private string[] State3 = { "4_WC_to_Palms", "2_WC_to_Palms", "Disabled", "Disabled" };
    private string[] State4 = { "5_WC_to_Palms", "3_WC_Palms", "Disabled", "Disabled" };
    private string[] State5 = { "6_Palms", "4_WC_to_Palms", "31 OUTSIDE_A3", "8_A4_Outside" };
    private string[] State6 = { "7_C2_Entrance", "5_WC_to_Palms", "33_PALMS_TO_D1", "10_PALMS_TO_D2" };


    private string[] State8 = { "10_PALMS_TO_D2", "9_A4_INSIDE", "5_WC_to_Palms", "Disabled" };
    private string[] State9 = { "Disabled", "8_A4_Outside", "Disabled", "Disabled" };

    private string[] State31 = { "33_PALMS_TO_D1", "32 INSIDE A3", "Disabled", "5_WC_to_Palms" };
    private string[] State32 = { "Disabled", "31 OUTSIDE_A3", "Disabled", "Disabled" };


    private string[] State33 = { "34_PALMS_TO_D1", "6_Palms", "31 OUTSIDE_A3", "7_C2_Entrance" };
    private string[] State34 = { "35_OUTSIDE_A2", "33_PALMS_TO_D1", "Disabled", "Disabled" };
    private string[] State35 = { "37_PALMS_TO_D1", "34_PALMS_TO_D1", "36_INSIDE_A2", "Disabled" };
    private string[] State36 = { "Disabled", "35_OUTSIDE_A2", "Disabled", "Disabled" };


    private string[] State37 = { "42 OUTSIDE_D1", "35_OUTSIDE_A2", "38 OUTSIDE_A1", "40 OUTSIDE_C1" };
    private string[] State38 = { "42 OUTSIDE_D1", "37_PALMS_TO_D1", "39 INSIDE_A1", "40 OUTSIDE_C1" };
    private string[] State39 = { "Disabled", "38 OUTSIDE_A1", "Disabled", "Disabled" };

    private string[] State40 = { "42 OUTSIDE_D1", "37_PALMS_TO_D1", "38 OUTSIDE_A1", "41 INSIDE_C1" };
    private string[] State41 = { "Disabled", "40 OUTSIDE_C1", "Disabled", "Disabled" };


    private string[] State42 = { "43_INSIDE_D1", "37_PALMS_TO_D1", "38 OUTSIDE_A1", "40 OUTSIDE_C1" };
    private string[] State43 = { "Disabled", "42 OUTSIDE_D1", "Disabled", "Disabled" };




    private string[] State10 = { "11_A5_OUTSIDE", "6_Palms", "7_C2_Entrance", "8_A4_Outside" };
    private string[] State11 = { "13_PALMS_TO_D2", "10_PALMS_TO_D2", "Disabled", "12_A5_INSIDE" };
    private string[] State12 = { "Disabled", "11_A5_OUTSIDE", "Disabled", "Disabled" };


    private string[] State13 = { "14_PALMS_TO_D2", "11_A5_OUTSIDE", "Disabled", "Disabled" };
    private string[] State14 = { "17_D2", "13_PALMS_TO_D2", "18_OUTSIDE_C3", "15 OUTSIDE_A6" };

    private string[] State18 = { "17_D2", "14_PALMS_TO_D2", "19_INSIDE_C3", "15 OUTSIDE_A6" };
    private string[] State19 = { "Disabled", "18_OUTSIDE_C3", "Disabled", "Disabled" };

    private string[] State15 = { "17_D2", "14_PALMS_TO_D2", "18_OUTSIDE_C3", "16 INSIDE_A6" };
    private string[] State16 = { "Disabled", "15 OUTSIDE_A6", "Disabled", "Disabled" };

    private string[] State17 = { "20_D2", "14_PALMS_TO_D2", "Disabled", "Disabled" };
    private string[] State20 = { "Disabled", "17_D2", "21_D2", "30_D2" };
    private string[] State21 = { "22_D2", "20_D2", "Disabled", "Disabled" };
    private string[] State22 = { "Disabled", "21_D2", "Disabled", "23_D2" };
    private string[] State23 = { "Disabled", "22_D2", "Disabled", "24_D2" };
    private string[] State24 = { "25_D2", "23_D2", "Disabled", "Disabled" };
    private string[] State25 = { "26_D2", "24_D2", "Disabled", "Disabled" };
    private string[] State26 = { "27_D2", "25_D2", "Disabled", "Disabled" };
    private string[] State27 = { "28_D2", "26_D2", "Disabled", "Disabled" };
    private string[] State28 = { "29_D2", "Disabled", "Disabled", "27_D2" };
    private string[] State29 = { "30_D2", "Disabled", "Disabled", "28_D2" };
    private string[] State30 = { "20_D2", "29_D2", "Disabled", "Disabled" };

    private string[] State7 = { "201_Entrance", "6_Palms", "Disabled", "Disabled" };
    private string[] State201 = { "Disabled", "7_C2_Entrance", "202_West_Path", "215_East_Path" };

    private string[] State202 = { "203.1_West Path_Lift", "201_Entrance", "Disabled", "Disabled" };
    private string[] State2031 = { "204_West_Path_2", "202_West_Path", "203.2_Left_Lift", "Disabled" };

    private string[] State2032 = { "301_Left_Lift", "401_Left_Lift", "204_Mail_Room", "203.1_West Path_Lift" };
    private string[] State2042 = { "Disabled", "Disabled", "Disabled", "203.2_Left_Lift" };


    private string[] State401 = { "203.2_Left_Lift", "Disabled", "402_Left_Path", "Disabled" };
    private string[] State402 = { "403_Central_Path", "Disabled", "Disabled", "401_Left_Lift" };
    private string[] State403 = { "405_Right_Path", "402_Left_Path", "404_Swimming_Pool", "Disabled" };
    private string[] State404 = { "Disabled", "403_Central_Path", "Disabled", "Disabled" };
    private string[] State405 = { "Disabled", "403_Central_Path", "Disabled", "406_Right_Lift" };
    private string[] State406 = { "216_Right_Lift", "Disabled", "405_Right_Path", "Disabled" };

    private string[] State2041 = { "205_West_Path_3", "203.1_West Path_Lift", "Disabled", "213_West_Path_11" };
    private string[] State205 = { "206_SHC", "204_West_Path_2", "Disabled", "Disabled" };
    private string[] State206 = { "207_West_Path_5", "205_West_Path_3", "Disabled", "Disabled" };
    private string[] State207 = { "208_West_Path_6", "206_SHC", "Disabled", "Disabled" };
    private string[] State208 = { "209_West_Path_7", "207_West_Path_5", "Disabled", "Disabled" };
    private string[] State209 = { "211_West_Path_9", "208_West_Path_6", "Disabled", "Disabled" };
    private string[] State211 = { "212_West_Path_10", "209_West_Path_8", "Disabled", "Disabled" };
    private string[] State212 = { "213_West_Path_11", "211_West_Path_9", "Disabled", "Disabled" };
    private string[] State213 = { "205_West_Path_3", "Disabled", "212_West_Path_10", "Disabled" };

    private string[] State215 = { "215.5_Right_Lift_Path", "201_Entrance", "Disabled", "Disabled" };
    private string[] State2155 = { "217_East_Path_1", "215_East_Path", "Disabled", "216_Right_Lift" };
    private string[] State216 = { "322_Right_Lift", "406_Right_Lift", "215.5_Right_Lift_Path", "Disabled" };
    private string[] State217 = { "218_Europcar", "215_East_Path", "Disabled", "Disabled" };
    private string[] State218 = { "219_East_Path_2", "234_East_Path_9", "Disabled", "217_East_Path_1" };
    private string[] State219 = { "220_East_Path_3", "218_Europcar", "Disabled", "Disabled" };
    private string[] State220 = { "222_East_Path_5", "219_East_Path_2", "Disabled", "Disabled" };
    private string[] State222 = { "Disabled", "220_East_Path_3", "223_East_Path_6", "Disabled" };
    private string[] State223 = { "224_Registrar", "222_East_Path_5", "Disabled", "Disabled" };
    private string[] State224 = { "225_East_Path_7", "223_East_Path_6", "Disabled", "Disabled" };
    private string[] State225 = { "226_Student_Affairs_Suite", "224_Registrar", "233_East_Path_8", "Disabled" };


    private string[] State226 = { "227_CDC", "225_East_Path_7", "Disabled", "Disabled" };
    private string[] State227 = { "228_CDC_2", "226_Student_Affairs_Suite", "Disabled", "Disabled" };
    private string[] State228 = { "229_CDC_3", "227_CDC", "Disabled", "Disabled" };
    private string[] State229 = { "Disabled", "228_CDC_2", "Disabled", "Disabled" };


    private string[] State233 = { "234_East_Path_9", "226_Student_Affairs_Suite", "Disabled", "Disabled" };
    private string[] State234 = { "218_Europcar", "233_East_Path_8", "Disabled", "Disabled" };


    private string[] State301 = { "501_Left_Lift", "203.2_Left_Lift", "302_Left_Path", "314_Front_CS" };
    private string[] State302 = { "303_Left_Path_2", "Disabled", "301_Left_Lift", "Disabled" };
    private string[] State303 = { "304_Left_Path_3", "302_Left_Path", "Disabled", "Disabled" };
    private string[] State304 = { "305_Left_Path_4", "303_Left_Path_2", "Disabled", "Disabled" };
    private string[] State305 = { "Disabled", "304_Left_Path_3", "306_Left_Path_5", "Disabled" };
    private string[] State306 = { "307_Left_Path_6", "305_Left_Path_4", "Disabled", "Disabled" };
    private string[] State307 = { "308_Spin_Studio", "Disabled", "306_Left_Path_5", "Disabled" };
    private string[] State308 = { "309_Yoga_Studio", "307_Left_Path_6", "Disabled", "Disabled" };
    private string[] State309 = { "310_Blue_Studio", "308_Spin_Studio", "Disabled", "Disabled" };
    private string[] State310 = { "312_Left_Path_7", "309_Yoga_Studio", "311_Inside_Blue_Studio", "Disabled" };
    private string[] State311 = { "Disabled", "310_Blue_Studio", "Disabled", "Disabled" };
    private string[] State312 = { "313_Left_Path_8", "310_Blue_Studio", "Disabled", "Disabled" };
    private string[] State313 = { "Disabled", "312_Left_Path_7", "314_Front_CS", "320_Central_Path_2" };
    private string[] State314 = { "315_Inside_CS_1", "301_Left_Lift", "313_Left_Path_8", "Disabled" };

    private string[] State315 = { "316_Inside_CS_2", "314_Front_CS", "Disabled", "Disabled" };
    private string[] State316 = { "317_Inside_CS_3", "315_Inside_CS_1", "Disabled", "Disabled" };
    private string[] State317 = { "Disabled", "316_Inside_CS_2", "Disabled", "318_Inside_CS_4" };
    private string[] State318 = { "Disabled", "Disabled", "317_Inside_CS_3", "Disabled" };

    private string[] State320 = { "321_Central_Path_3", "313_Left_Path_8", "Disabled", "Disabled" };
    private string[] State321 = { "322_Right_Lift", "320_Central_Path_2", "Disabled", "335_Right_Path_6" };
    private string[] State322 = { "516_Right_Lift", "216_Right_Lift", "321_Central_Path_3", "323_Right_Path" };
    private string[] State323 = { "324_Athletics_Equipment_Centre", "Disabled", "Disabled", "322_Right_Lift" };
    private string[] State324 = { "325_Right_Path_2", "323_Right_Path", "Disabled", "Disabled" };
    private string[] State325 = { "329_Sports_Performance_Centre", "324_Athletics_Equipment_Centre", "326_Performance_Gym_1", "Disabled" };

    private string[] State326 = { "327_Performance_Gym_2", "Disabled", "325_Right_Path_2", "Disabled" };
    private string[] State327 = { "328_Performance_Gym_3", "326_Performance_Gym_1", "Disabled", "Disabled" };
    private string[] State328 = { "Disabled", "327_Performance_Gym_2", "Disabled", "Disabled" };

    private string[] State329 = { "331_Right_Path_3", "325_Right_Path_2", "Disabled", "330_Inside_Sports_Performance_Centre" };
    private string[] State330 = { "Disabled", "329_Sports_Performance_Centre", "Disabled", "Disabled" };

    private string[] State331 = { "Disabled", "329_Sports_Performance_Centre", "Disabled", "332_Right_Path_4" };
    private string[] State332 = { "333_Right_Path_5", "Disabled", "Disabled", "331_Right_Path_3" };
    private string[] State333 = { "335_Right_Path_6", "332_Right_Path_4", "Disabled", "334_Combative_Studio" };
    private string[] State334 = { "Disabled", "333_Right_Path_5", "Disabled", "Disabled" };


    private string[] State335 = { "321_Central_Path_3", "333_Right_Path_5", "Disabled", "336_Squash_Court" };
    private string[] State336 = { "Disabled", "335_Right_Path_6", "Disabled", "Disabled" };


    private string[] State501 = { "601_Left_Lift", "301_Left_Lift", "Disabled", "502_Front_MP" };
    private string[] State502 = { "503_MP_1", "514_Central_Path", "Disabled", "501_Left_Lift" };
    private string[] State503 = { "504_MP_2", "502_Front_MP", "Disabled", "Disabled" };
    private string[] State504 = { "506_MP_3", "503_MP_1", "Disabled", "505_EFNY" };
    private string[] State505 = { "Disabled", "504_MP_2", "Disabled", "Disabled" };
    private string[] State506 = { "507_Dessert_Lab", "504_MP_2", "Disabled", "Disabled" };
    private string[] State507 = { "508_MP_5", "506_MP_3", "Disabled", "Disabled" };
    private string[] State508 = { "Disabled", "507_Dessert_Lab", "509_Grub_Hub", "510_IBN" };
    private string[] State509 = { "Disabled", "508_MP_5", "Disabled", "Disabled" };

    private string[] State510 = { "Disabled", "Disabled", "508_MP_5", "511_MP_7" };
    private string[] State511 = { "Disabled", "510_IBN", "Disabled", "512_Burro_Blanco" };
    private string[] State512 = { "513_Asiatic_&_Co", "511_MP_7", "Disabled", "Disabled" };
    private string[] State513 = { "Disabled", "512_Burro_Blanco", "Disabled", "507_Dessert_Lab" };


    private string[] State514 = { "515_Central_Path", "502_Front_MP", "Disabled", "Disabled" };
    private string[] State515 = { "517_Baraha_1", "514_Central_Path", "Disabled", "Disabled" };
    private string[] State517 = { "518_Baraha_2", "515_Central_Path", "516_Right_Lift", "Disabled" };
    private string[] State516 = { "610_Right_Lift", "322_Right_Lift", "517_Baraha_1", "Disabled" };
    private string[] State518 = { "519_Baraha_3", "517_Baraha_1", "Disabled", "Disabled" };
    private string[] State519 = { "521_Undergraduate_Admissions", "518_Baraha_2", "Disabled", "Disabled" };
    private string[] State521 = { "Disabled", "519_Baraha_3", "Disabled", "Disabled" };


    private string[] State601 = { "Disabled", "501_Left_Lift", "Disabled", "602_Library_Cafe" };
    private string[] State602 = { "Disabled", "603_Left_Path", "Disabled", "601_Left_Lift" };
    private string[] State603 = { "604_Central_Path", "602_Library_Cafe", "Disabled", "Disabled" };
    private string[] State604 = { "608_Right_Path", "603_Left_Path", "605_Library", "Disabled" };

    private string[] State605 = { "606_Library_2", "604_Central_Path", "Disabled", "Disabled" };
    private string[] State606 = { "607_Library_3", "605_Library", "Disabled", "Disabled" };
    private string[] State607 = { "Disabled", "606_Library_2", "Disabled", "Disabled" };

    private string[] State608 = { "609_Right_Path", "604_Central_Path", "Disabled", "Disabled" };
    private string[] State609 = { "Disabled", "608_Right_Path", "610_Right_Lift", "Disabled" };
    private string[] State610 = { "Disabled", "516_Right_Lift", "Disabled", "609_Right_Path" };


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NavigationArrow"))
        {
            string globalState = PlayerPrefs.GetString("globalState", "A");
            string[] currentPossibleDirections;

            //All switch cases
            switch (globalState)
            {
                case "1":
                    currentPossibleDirections = State1;
                    break;
                case "101":
                    currentPossibleDirections = State101;
                    break;
                case "102":
                    currentPossibleDirections = State102;
                    break;
                case "103":
                    currentPossibleDirections = State103;
                    break;
                case "104":
                    currentPossibleDirections = State104;
                    break;
                case "105":
                    currentPossibleDirections = State105;
                    break;
                case "106":
                    currentPossibleDirections = State106;
                    break;
                case "107":
                    currentPossibleDirections = State107;
                    break;
                case "108":
                    currentPossibleDirections = State108;
                    break;
                case "109":
                    currentPossibleDirections = State109;
                    break;
                case "110":
                    currentPossibleDirections = State110;
                    break;
                case "111":
                    currentPossibleDirections = State111;
                    break;
                case "2":
                    currentPossibleDirections = State2;
                    break;
                case "3":
                    currentPossibleDirections = State3;
                    break;
                case "4":
                    currentPossibleDirections = State4;
                    break;
                case "5":
                    currentPossibleDirections = State5;
                    break;
                case "6":
                    currentPossibleDirections = State6;
                    break;
                case "8":
                    currentPossibleDirections = State8;
                    break;
                case "9":
                    currentPossibleDirections = State9;
                    break;
                case "10":
                    currentPossibleDirections = State10;
                    break;
                case "11":
                    currentPossibleDirections = State11;
                    break;
                case "12":
                    currentPossibleDirections = State12;
                    break;
                case "13":
                    currentPossibleDirections = State13;
                    break;
                case "14":
                    currentPossibleDirections = State14;
                    break;
                case "15":
                    currentPossibleDirections = State15;
                    break;
                case "16":
                    currentPossibleDirections = State16;
                    break;
                case "17":
                    currentPossibleDirections = State17;
                    break;
                case "18":
                    currentPossibleDirections = State18;
                    break;
                case "19":
                    currentPossibleDirections = State19;
                    break;
                case "20":
                    currentPossibleDirections = State20;
                    break;
                case "21":
                    currentPossibleDirections = State21;
                    break;
                case "22":
                    currentPossibleDirections = State22;
                    break;
                case "23":
                    currentPossibleDirections = State23;
                    break;
                case "24":
                    currentPossibleDirections = State24;
                    break;
                case "25":
                    currentPossibleDirections = State25;
                    break;
                case "26":
                    currentPossibleDirections = State26;
                    break;
                case "27":
                    currentPossibleDirections = State27;
                    break;
                case "28":
                    currentPossibleDirections = State28;
                    break;
                case "29":
                    currentPossibleDirections = State29;
                    break;
                case "30":
                    currentPossibleDirections = State30;
                    break;
                case "31":
                    currentPossibleDirections = State31;
                    break;
                case "32":
                    currentPossibleDirections = State32;
                    break;
                case "33":
                    currentPossibleDirections = State33;
                    break;
                case "34":
                    currentPossibleDirections = State34;
                    break;
                case "35":
                    currentPossibleDirections = State35;
                    break;
                case "36":
                    currentPossibleDirections = State36;
                    break;
                case "37":
                    currentPossibleDirections = State37;
                    break;
                case "38":
                    currentPossibleDirections = State38;
                    break;
                case "39":
                    currentPossibleDirections = State39;
                    break;
                case "40":
                    currentPossibleDirections = State40;
                    break;
                case "41":
                    currentPossibleDirections = State41;
                    break;
                case "42":
                    currentPossibleDirections = State42;
                    break;
                case "43":
                    currentPossibleDirections = State43;
                    break;

                case "7":
                    currentPossibleDirections = State7;
                    break;
                case "201":
                    currentPossibleDirections = State201;
                    break;
                case "202":
                    currentPossibleDirections = State202;
                    break;
                case "203.1":
                    currentPossibleDirections = State2031;
                    break;
                case "203.2":
                    currentPossibleDirections = State2032;
                    break;
                case "204.1":
                    currentPossibleDirections = State2041;
                    break;
                case "204.2":
                    currentPossibleDirections = State2042;
                    break;
                case "205":
                    currentPossibleDirections = State205;
                    break;
                case "206":
                    currentPossibleDirections = State206;
                    break;
                case "207":
                    currentPossibleDirections = State207;
                    break;
                case "208":
                    currentPossibleDirections = State208;
                    break;
                case "209":
                    currentPossibleDirections = State209;
                    break;
                case "211":
                    currentPossibleDirections = State211;
                    break;
                case "212":
                    currentPossibleDirections = State212;
                    break;
                case "213":
                    currentPossibleDirections = State213;
                    break;
                case "215":
                    currentPossibleDirections = State215;
                    break;
                case "215.5":
                    currentPossibleDirections = State2155;
                    break;
                case "216":
                    currentPossibleDirections = State216;
                    break;
                case "217":
                    currentPossibleDirections = State217;
                    break;
                case "218":
                    currentPossibleDirections = State218;
                    break;
                case "219":
                    currentPossibleDirections = State219;
                    break;
                case "220":
                    currentPossibleDirections = State220;
                    break;
           
                case "222":
                    currentPossibleDirections = State222;
                    break;
                case "223":
                    currentPossibleDirections = State223;
                    break;
                case "224":
                    currentPossibleDirections = State224;
                    break;
                case "225":
                    currentPossibleDirections = State225;
                    break;
                case "226":
                    currentPossibleDirections = State226;
                    break;
                case "227":
                    currentPossibleDirections = State227;
                    break;
                case "228":
                    currentPossibleDirections = State228;
                    break;
                case "229":
                    currentPossibleDirections = State229;
                    break;
               
            
          
                case "233":
                    currentPossibleDirections = State233;
                    break;
                case "234":
                    currentPossibleDirections = State234;
                    break;

                case "301":
                    currentPossibleDirections = State301;
                    break;
                case "302":
                    currentPossibleDirections = State302;
                    break;
                case "303":
                    currentPossibleDirections = State303;
                    break;
                case "304":
                    currentPossibleDirections = State304;
                    break;
                case "305":
                    currentPossibleDirections = State305;
                    break;
                case "306":
                    currentPossibleDirections = State306;
                    break;
                case "307":
                    currentPossibleDirections = State307;
                    break;
                case "308":
                    currentPossibleDirections = State308;
                    break;
                case "309":
                    currentPossibleDirections = State309;
                    break;
                case "310":
                    currentPossibleDirections = State310;
                    break;
                case "311":
                    currentPossibleDirections = State311;
                    break;
                case "312":
                    currentPossibleDirections = State312;
                    break;
                case "313":
                    currentPossibleDirections = State313;
                    break;
                case "314":
                    currentPossibleDirections = State314;
                    break;
                case "315":
                    currentPossibleDirections = State315;
                    break;
                case "316":
                    currentPossibleDirections = State316;
                    break;
                case "317":
                    currentPossibleDirections = State317;
                    break;
                case "318":
                    currentPossibleDirections = State318;
                    break;
                case "320":
                    currentPossibleDirections = State320;
                    break;
                case "321":
                    currentPossibleDirections = State321;
                    break;
                case "322":
                    currentPossibleDirections = State322;
                    break;
                case "323":
                    currentPossibleDirections = State323;
                    break;
                case "324":
                    currentPossibleDirections = State324;
                    break;
                case "325":
                    currentPossibleDirections = State325;
                    break;
                case "326":
                    currentPossibleDirections = State326;
                    break;
                case "327":
                    currentPossibleDirections = State327;
                    break;
                case "328":
                    currentPossibleDirections = State328;
                    break;
                case "329":
                    currentPossibleDirections = State329;
                    break;
                case "330":
                    currentPossibleDirections = State330;
                    break;
                case "331":
                    currentPossibleDirections = State331;
                    break;
                case "332":
                    currentPossibleDirections = State332;
                    break;
                case "333":
                    currentPossibleDirections = State333;
                    break;
                case "334":
                    currentPossibleDirections = State334;
                    break;
                case "335":
                    currentPossibleDirections = State335;
                    break;
                case "336":
                    currentPossibleDirections = State336;
                    break;
                case "401":
                    currentPossibleDirections = State401;
                    break;
                case "402":
                    currentPossibleDirections = State402;
                    break;
                case "403":
                    currentPossibleDirections = State403;
                    break;
                case "404":
                    currentPossibleDirections = State404;
                    break;
                case "405":
                    currentPossibleDirections = State405;
                    break;
                case "406":
                    currentPossibleDirections = State406;
                    break;
                case "501":
                    currentPossibleDirections = State501;
                    break;
                case "502":
                    currentPossibleDirections = State502;
                    break;
                case "503":
                    currentPossibleDirections = State503;
                    break;
                case "504":
                    currentPossibleDirections = State504;
                    break;
                case "505":
                    currentPossibleDirections = State505;
                    break;
                case "506":
                    currentPossibleDirections = State506;
                    break;
                case "507":
                    currentPossibleDirections = State507;
                    break;
                case "508":
                    currentPossibleDirections = State508;
                    break;
                case "509":
                    currentPossibleDirections = State509;
                    break;
                case "510":
                    currentPossibleDirections = State510;
                    break;
                case "511":
                    currentPossibleDirections = State511;
                    break;
                case "512":
                    currentPossibleDirections = State512;
                    break;
                case "513":
                    currentPossibleDirections = State513;
                    break;
                case "514":
                    currentPossibleDirections = State514;
                    break;
                case "515":
                    currentPossibleDirections = State515;
                    break;
                case "516":
                    currentPossibleDirections = State516;
                    break;
                case "517":
                    currentPossibleDirections = State517;
                    break;
                case "518":
                    currentPossibleDirections = State518;
                    break;
                case "519":
                    currentPossibleDirections = State519;
                    break;
         
                case "521":
                    currentPossibleDirections = State521;
                    break;
                case "601":
                    currentPossibleDirections = State601;
                    break;
                case "602":
                    currentPossibleDirections = State602;
                    break;
                case "603":
                    currentPossibleDirections = State603;
                    break;
                case "604":
                    currentPossibleDirections = State604;
                    break;
                case "605":
                    currentPossibleDirections = State605;
                    break;
                case "606":
                    currentPossibleDirections = State606;
                    break;
                case "607":
                    currentPossibleDirections = State607;
                    break;
                case "608":
                    currentPossibleDirections = State608;
                    break;
                case "609":
                    currentPossibleDirections = State609;
                    break;
                case "610":
                    currentPossibleDirections = State610;
                    break;
                default:
                    currentPossibleDirections = State1; // Default to State1 or handle differently
                    break;
            }

            //Handle the 4 arrows
            // Get the name of the GameObject that collided
            string ArrowName = other.gameObject.name;

            // Do something when the object with the "NavigationArrow" tag enters the trigger
            UnityEngine.Debug.Log(ArrowName);
            switch (ArrowName)
            {
                case "ForwardButton":
                    UnityEngine.Debug.Log("The Forward button was pressed.");
                    if (currentPossibleDirections[0] != "Disabled")
                    {
                        SceneManager.LoadScene(currentPossibleDirections[0]);
                    }
                    // Insert additional logic for ForwardButton here
                    break;
                case "BackwardButton":
                    UnityEngine.Debug.Log("The Backward button was pressed.");
                    if (currentPossibleDirections[1] != "Disabled")
                    {
                        SceneManager.LoadScene(currentPossibleDirections[1]);
                    }
                    // Insert additional logic for BackwardButton here
                    break;
                case "LeftButton":
                    UnityEngine.Debug.Log("The Left button was pressed.");
                    if (currentPossibleDirections[2] != "Disabled")
                    {
                        SceneManager.LoadScene(currentPossibleDirections[2]);
                    }
                    // Insert additional logic for LeftButton here
                    break;
                case "RightButton":
                    UnityEngine.Debug.Log("The Right button was pressed.");
                    if (currentPossibleDirections[3] != "Disabled")
                    {
                        SceneManager.LoadScene(currentPossibleDirections[3]);
                    }
                    // Insert additional logic for RightButton here
                    break;
                default:
                    UnityEngine.Debug.Log("Button name not recognized.");
                    break;
            }
        }
    }
}