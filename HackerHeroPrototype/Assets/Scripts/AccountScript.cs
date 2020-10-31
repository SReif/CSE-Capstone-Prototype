using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AccountScript : MonoBehaviour
{
    //public Account account;
    private int currentPage;
    private float currentProgress;
    private string acntName;
    private string[] pronouns; // Subjective, Objective, Possesive, Possesive Pronoun
    private string genderID;
    private string ethnicity;
    private string hasDisability;
    private int gradeLvl;
    private const float PROGRESS_RATE = 0.16f;
    public GameObject accountPage1;
    public GameObject accountPage2;
    public GameObject accountPage3;




    public RectTransform progressMask;

    [Header("Page 1")]
    public TMP_InputField nameField;



    [Header("Page 2")]
    
    public GameObject pronounFieldObj; // used to show/hide
    public TMP_InputField pronounField;

    public struct Account
    {
        string name;
        string[] pronouns; // Subjective, Objective, Possesive, Possesive Pronoun
        string genderID;
        string ethnicity;
        string hasDisability;
        int gradeLvl;

        public Account(string _name, string[] _pronouns, string _genderID, string _ethnicity, string _hasDisability, int _gradeLvl)
        {
            name = _name;
            pronouns = _pronouns;
            genderID = _genderID;
            ethnicity = _ethnicity;
            hasDisability = _hasDisability;
            gradeLvl = _gradeLvl;
        }
    }

    public void Start()
    {
        accountPage1.SetActive(true);
        accountPage2.SetActive(false);
        accountPage3.SetActive(false);
        currentPage = 1;

        currentProgress = 0.04f; // Temp!!! TODO check progress
        acntName = null; // Temp!
        pronouns = new string[4];

        

        Debug.Log(currentProgress);
    }

    public void ChangePage(int direction)
    {
        currentPage += direction;


        
        Debug.Log(AccountToString()); // Temp!



        switch (currentPage)
        {
            case 1:

                accountPage1.SetActive(true);
                accountPage2.SetActive(false);
                accountPage3.SetActive(false);
                break;
            case 2:
                if (acntName != null)
                {
                    accountPage1.SetActive(false);
                    accountPage2.SetActive(true);
                    accountPage3.SetActive(false);

                }
                else
                {
                    Debug.Log("Name is missing!");
                    // Undo page change
                    currentPage -= direction;
                }
                break;
            case 3:
                accountPage1.SetActive(false);
                accountPage2.SetActive(false);
                accountPage3.SetActive(true);
                if(pronouns[0] == null)
                {
                    UpdatePronouns(0);
                }
                break;
            case 4:
                break;
            default:
                SceneManager.LoadScene(0);
                break;
        }
    }

    public void UpdateName()
    {
        if (acntName == null && nameField.text != "")
        {
            currentProgress += PROGRESS_RATE;
            progressMask.localScale = new Vector3(currentProgress, 1f, 1f);

        }
        if (nameField.text != "")
        {
            acntName = nameField.text;
        }

        
    }

    public void UpdatePronouns(int _selection)
    {
        if (pronouns[0] == null)
        {
            currentProgress += PROGRESS_RATE;
            progressMask.localScale = new Vector3(currentProgress, 1f, 1f);
        }
        
        switch (_selection)
        {
            case 0:
                pronounFieldObj.SetActive(false);
                pronouns[0] = "she";
                pronouns[1] = "her";
                pronouns[2] = "her";
                pronouns[3] = "hers";
                break;
            case 1:
                pronounFieldObj.SetActive(false);
                pronouns[0] = "he";
                pronouns[1] = "him";
                pronouns[2] = "his";
                pronouns[3] = "his";
                break;
            case 2:
                pronounFieldObj.SetActive(false);
                pronouns[0] = "they";
                pronouns[1] = "them";
                pronouns[2] = "their";
                pronouns[3] = "theirs";
                break;
            default:
                pronounFieldObj.SetActive(true);
                
                // TEMP !!! TODO: Add string parser, validator, and update currentProgress
                pronouns[0] = "Xe"; // temp
                pronouns[1] = "Xem"; // temp
                pronouns[2] = "Xyr"; // temp
                pronouns[3] = "Xyrs"; // temp
                break;
        }
        
    }

    public void UpdateGender(int _selection)
    {
        if (genderID == null)
        {
            currentProgress += PROGRESS_RATE;
            progressMask.localScale = new Vector3(currentProgress, 1f, 1f);
        }

        switch (_selection)
        {
            case 0:
               
                genderID = "girl";
                break;
            case 1:
                
                genderID = "boy";
                break;
            case 2:
                genderID = "non-binary";
                break;
            default:
                genderID = "unknown";
                break;
        }
    }

    public void UpdateEthnicity()
    {
        ethnicity = "";
    }

    public void UpdateDisability()
    {
        hasDisability = "";
    }

    public void UpdateGrade()
    {
        gradeLvl = 0;
    }


    //#################### SAVE AND LOAD ACCOUNT FOR SERVER AND CLIENT ####################//

    /*
    public void CreateAccount()
    {
        account = new Account(acntName, pronouns, genderID, ethnicity, hasDisability, gradeLvl);
    }
    
    //create txt file to store account values on the client
    public void SaveAccountClient()
    {

    }

    //fetch account values from txt file stored on the client
    public void LoadAccountClient()
    {
        Account m_Account = new Account();
        account = m_Account;
    }

    //create txt file to store account values on the server
    public void SaveAccountServer()
    {

    }

    //fetch account values from txt file stored on the server
    public void LoadAccountServer()
    {
        Account m_Account = new Account();
        account = m_Account;
    }
    */

    //#####################################################################################//

    // Will migrated into Account struct
    private string AccountToString()
    {
        string accnt = "";
        accnt = currentPage != -1 ? accnt + "currentPage: " + currentPage + "\n" : accnt;  // temp
        accnt = currentProgress != -1 ? accnt + "currentProgress: " + currentProgress + "\n" : accnt;  // temp
        accnt = acntName != null ? accnt + "acntName: " + acntName + "\n" : accnt;
        accnt = pronouns[0] != null ? accnt + "pronouns: " + pronouns[0] + "/" + pronouns[1] + "/" + pronouns[2] + "/" + pronouns[3] + "\n" : accnt;
        accnt = genderID != null ? accnt + "genderID: " + genderID + "\n" : accnt;
        accnt = ethnicity != null ? accnt + "ethnicity: " + ethnicity + "\n" : accnt;
        accnt = hasDisability != null ? accnt + "hasDisability: " + hasDisability + "\n" : accnt;
        accnt = gradeLvl != 0 ? accnt + "gradeLvl: " + gradeLvl + "\n" : accnt;
        return accnt;
    }
}
