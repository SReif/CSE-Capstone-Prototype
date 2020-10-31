using System.Collections;
using System.Collections.Generic;
//using System.Linq;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.Windows.WebCam;

public class CustomizationUIController : MonoBehaviour
{
    // Materials unto which the webcam content is applied to
    public Material videoMaterial;
    public Material currentMaterial;
    public Material potentialMaterial;

    // Image GameObjects which will contain the material to be displayed
    //public GameObject videoImage;
    //public GameObject currentReferenceImage;
    //public GameObject potentialReferenceImage;

    // buttons that controll the navigation for Avatar Customization
    public GameObject videoButton;
    //public GameObject takePhotoButton;
    public GameObject keepPhotoButton;
    //public GameObject replacePhotoButton;
    
    public GameObject videoPanel;
    public GameObject currentReferencePanel;
    public GameObject potentialReferencePanel;
    public GameObject avatarPanel;

    public GameObject videoInstructionText;

    private WebCamTexture webcamTexture;

    private bool isFirstPhoto;

    // Start is called before the first frame update
    void Start()
    {
        isFirstPhoto = true;
    }

    public void StartVideo()
    {
        webcamTexture = new WebCamTexture();

        videoMaterial.mainTexture = webcamTexture;

        webcamTexture.Play();

        DisplayState(1);
    }

    void StopVideo()
    {
        if (webcamTexture.isPlaying)
            webcamTexture.Stop();
    }

    public void TakePicture()
    {
        //videoImage.SetActive(false);
        //takePhotoButton.SetActive(false);

        if (isFirstPhoto)
        {
            currentMaterial.mainTexture = webcamTexture;
            StopVideo();

            DisplayState(0);

            isFirstPhoto = false;
        }
        else
        {
            potentialMaterial.mainTexture = webcamTexture;
            StopVideo();

            DisplayState(2);
        }
    }

    public void SelectReference(int selection)
    {
        switch (selection)
        {
            case 0: // Keep
                break;
            case 1: // Replace
                currentMaterial.mainTexture = potentialMaterial.mainTexture;
                break;
        }

        DisplayState(0);
    }

    void DisplayState(int state)
    {
        //Hide All
        avatarPanel.SetActive(false);
        videoPanel.SetActive(false);
        currentReferencePanel.SetActive(false);
        potentialReferencePanel.SetActive(false);
        videoButton.SetActive(false);
        keepPhotoButton.SetActive(false);
        videoInstructionText.SetActive(false);

        switch (state)
        {
            case 0: // Start or photo taken mode
                avatarPanel.SetActive(true);
                currentReferencePanel.SetActive(true);
                videoButton.SetActive(true);
                break;
            case 1: // video on mode
                avatarPanel.SetActive(true);
                videoPanel.SetActive(true);
                break;
            case 2: // photo selection mode
                currentReferencePanel.SetActive(true);
                potentialReferencePanel.SetActive(true);
                keepPhotoButton.SetActive(true);
                break;
        }

        /*
        //Hide All
        avatarPanel.SetActive(false);
        videoImage.SetActive(false);
        currentReferenceImage.SetActive(false);
        potentialReferenceImage.SetActive(false);

        videoButton.SetActive(false);
        takePhotoButton.SetActive(false);
        keepPhotoButton.SetActive(false);
        replacePhotoButton.SetActive(false);

        switch (state)
        {
            case 0: // Start or photo taken mode
                avatarPanel.SetActive(true);
                currentReferenceImage.SetActive(true);
                videoButton.SetActive(true);
                break;
            case 1: // video on mode
                avatarPanel.SetActive(true);
                videoImage.SetActive(true);
                takePhotoButton.SetActive(true);
                break;
            case 2: // photo selection mode
                currentReferenceImage.SetActive(true);
                potentialReferenceImage.SetActive(true);
                keepPhotoButton.SetActive(true);
                replacePhotoButton.SetActive(true);
                break;
        }
        */
    }
}
