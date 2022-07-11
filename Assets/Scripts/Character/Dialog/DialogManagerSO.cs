using System.Collections.Generic;
using UnityEngine;

public enum enum_NPCNameTutorial
{
    Agus,
    Anto,
    Budi,
}

public enum enum_NPCNameWetan
{
    Agus,
    KepalaDesa,
    KetuaAdat,
    Cokro,
    Aji,
    Budi,
    Anto
}

public enum enum_NPCNameKulon
{
    Agus
}

public enum enum_NPCNameBosFight
{
    Agus,
    Genderuwo
}

[CreateAssetMenu(fileName = "Manager Dialog", menuName = "ScriptibleObject/Dilog/Manager")]
public class DialogManagerSO : ScriptableObject
{
    public List<DialogLineSO> Line; 

    public AudioClip dialogSound;
    public string dialogName;
    public string dialogText;
    public int maxLine;

    public void TutorialProgres(int dialogID, int progresID)
    {
        switch (dialogID)
        {
            case 1:
                maxLine = Line[0].LineSize;
                dialogName = Line[0].GetNameText(progresID);
                dialogText = Line[0].GetDialogText(progresID);
                dialogSound = Line[0].GetClip(progresID);
                break;

            case 2:
                maxLine = Line[1].LineSize;
                dialogName = Line[1].GetNameText(progresID);
                dialogText = Line[1].GetDialogText(progresID);
                dialogSound = Line[1].GetClip(progresID);
                break;

            case 3:
                maxLine = Line[2].LineSize;
                dialogName = Line[2].GetNameText(progresID);
                dialogText = Line[2].GetDialogText(progresID);
                dialogSound = Line[2].GetClip(progresID);
                break;
        }
    }

    public void WetanProgres(int dialogID, int progresID)
    {
        switch (dialogID)
        {
            case 1:
                maxLine = Line[0].LineSize;
                dialogName = Line[0].GetNameText(progresID);
                dialogText = Line[0].GetDialogText(progresID);
                dialogSound = Line[0].GetClip(progresID);
                break;

            case 2:
                maxLine = Line[1].LineSize;
                dialogName = Line[1].GetNameText(progresID);
                dialogText = Line[1].GetDialogText(progresID);
                dialogSound = Line[1].GetClip(progresID);
                break;

            case 3:
                maxLine = Line[2].LineSize;
                dialogName = Line[2].GetNameText(progresID);
                dialogText = Line[2].GetDialogText(progresID);
                dialogSound = Line[2].GetClip(progresID);
                break;

            case 4:
                maxLine = Line[3].LineSize;
                dialogName = Line[3].GetNameText(progresID);
                dialogText = Line[3].GetDialogText(progresID);
                dialogSound = Line[3].GetClip(progresID);
                break;

            case 5:
                maxLine = Line[4].LineSize;
                dialogName = Line[4].GetNameText(progresID);
                dialogText = Line[4].GetDialogText(progresID);
                dialogSound = Line[4].GetClip(progresID);
                break;

            case 6:
                maxLine = Line[5].LineSize;
                dialogName = Line[5].GetNameText(progresID);
                dialogText = Line[5].GetDialogText(progresID);
                dialogSound = Line[5].GetClip(progresID);
                break;

            case 7:
                maxLine = Line[6].LineSize;
                dialogName = Line[6].GetNameText(progresID);
                dialogText = Line[6].GetDialogText(progresID);
                dialogSound = Line[6].GetClip(progresID);
                break;

            case 8:
                maxLine = Line[7].LineSize;
                dialogName = Line[7].GetNameText(progresID);
                dialogText = Line[7].GetDialogText(progresID);
                dialogSound = Line[7].GetClip(progresID);
                break;

            default:
                maxLine = Line[8].LineSize;
                dialogName = Line[8].GetNameText(progresID);
                dialogText = Line[8].GetDialogText(progresID);
                dialogSound = Line[8].GetClip(progresID);
                break;
        }
    }

    public void KulonProgres(int dialogID, int progresID)
    {
        switch (dialogID)
        {
            case 1:
                maxLine = Line[0].LineSize;
                dialogName = Line[0].GetNameText(progresID);
                dialogText = Line[0].GetDialogText(progresID);
                dialogSound = Line[0].GetClip(progresID);
                break;

            case 2:
                maxLine = Line[1].LineSize;
                dialogName = Line[1].GetNameText(progresID);
                dialogText = Line[1].GetDialogText(progresID);
                dialogSound = Line[1].GetClip(progresID);
                break;

            case 3:
                maxLine = Line[2].LineSize;
                dialogName = Line[2].GetNameText(progresID);
                dialogText = Line[2].GetDialogText(progresID);
                dialogSound = Line[2].GetClip(progresID);
                break;
        }
    }

    public void BosFightProgres(int dialogID, int progresID)
    {
        switch (dialogID)
        {
            case 1:
                maxLine = Line[0].LineSize;
                dialogName = Line[0].GetNameText(progresID);
                dialogText = Line[0].GetDialogText(progresID);
                dialogSound = Line[0].GetClip(progresID);
                break;

            case 2:
                maxLine = Line[1].LineSize;
                dialogName = Line[1].GetNameText(progresID);
                dialogText = Line[1].GetDialogText(progresID);
                dialogSound = Line[1].GetClip(progresID);
                break;
        }
    }

    /*    public void CheckDialogueSound(int dialogID,int progresID)
        {
            switch (dialogScene)
            {
                case enum_ScenesName.Tutorial:
                    TutorialSound(dialogID, progresID);
                    break;

                case enum_ScenesName.DesaWetan:
                    WetanSound(dialogID, progresID);
                    break;

                case enum_ScenesName.DesaKulon:
                    //KulonSound(dialogID, progresID);
                    break;

                case enum_ScenesName.BosFight:
                    //BosFightSound(dialogID, progresID);
                    break;
            }
        }

        public void DialougueText(int dialogID,int progresID)
        {
            switch (dialogScene)
            {
                case enum_ScenesName.Tutorial:
                    TutorialDialouge(dialogID, progresID);
                    break;

                case enum_ScenesName.DesaWetan:
                    WetanDialouge(dialogID, progresID);
                    break;

                case enum_ScenesName.DesaKulon:
                    KulonDialouge(dialogID, progresID);
                    break;

                case enum_ScenesName.BosFight:
                    BosFightDialouge(dialogID, progresID);
                    break;
            }
        }

        private void BosFightDialouge(int dilogID,int progresID)
        {
            switch (dilogID)
            {
                case ((int)enum_GenderuwoState.Genderuwo1):
                    maxLine = 13;
                    switch(progresID)
                    {
                        case 0:
                            dialogName = dataDialog[((int)enum_NPCNameBosFight.Genderuwo)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameBosFight.Genderuwo)].DialogWord[0];
                            break;
                        case 1:
                            dialogName = dataDialog[((int)enum_NPCNameBosFight.Agus)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameBosFight.Agus)].DialogWord[0];
                            break;
                        case 2:
                            dialogName = dataDialog[((int)enum_NPCNameBosFight.Genderuwo)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameBosFight.Genderuwo)].DialogWord[1];
                            break;
                        case 3:
                            dialogName = dataDialog[((int)enum_NPCNameBosFight.Genderuwo)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameBosFight.Genderuwo)].DialogWord[1];
                            break;

                        case 4:
                            dialogName = dataDialog[((int)enum_NPCNameBosFight.Genderuwo)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameBosFight.Genderuwo)].DialogWord[2];
                            break;
                        case 5:
                            dialogName = dataDialog[((int)enum_NPCNameBosFight.Genderuwo)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameBosFight.Genderuwo)].DialogWord[3];
                            break;
                        case 6:
                            dialogName = dataDialog[((int)enum_NPCNameBosFight.Genderuwo)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameBosFight.Genderuwo)].DialogWord[4];
                            break;
                        case 7:
                            dialogName = dataDialog[((int)enum_NPCNameBosFight.Genderuwo)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameBosFight.Genderuwo)].DialogWord[5];
                            break;
                        case 8:
                            dialogName = dataDialog[((int)enum_NPCNameBosFight.Genderuwo)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameBosFight.Genderuwo)].DialogWord[6];
                            break;
                        case 9:
                            dialogName = dataDialog[((int)enum_NPCNameBosFight.Agus)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameBosFight.Agus)].DialogWord[2];
                            break;
                        case 10:
                            dialogName = dataDialog[((int)enum_NPCNameBosFight.Genderuwo)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameBosFight.Genderuwo)].DialogWord[7];
                            break;
                        case 11:
                            dialogName = dataDialog[((int)enum_NPCNameBosFight.Agus)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameBosFight.Agus)].DialogWord[3];
                            break;
                    }
                    break;

                case ((int)enum_GenderuwoState.Genderuwo2):
                    maxLine = 2;
                    switch (progresID)
                    {
                        case 0:
                            dialogName = dataDialog[((int)enum_NPCNameBosFight.Genderuwo)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameBosFight.Genderuwo)].DialogWord[8];
                            break;
                    }
                    break;
            }
        }

        private void KulonDialouge(int dialogID, int progresID)
        {
            switch (dialogID)
            {
                case (1):
                    maxLine = 2;
                    switch (progresID)
                    {
                        case 0:
                            dialogName = dataDialog[((int)enum_NPCNameKulon.Agus)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameKulon.Agus)].DialogWord[0];
                            break;
                    }
                    break;

                case (2):
                    maxLine = 2;
                    switch (progresID)
                    {
                        case 0:
                            dialogName = dataDialog[((int)enum_NPCNameKulon.Agus)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameKulon.Agus)].DialogWord[1];
                            break;
                    }
                    break;

                case (3):
                    maxLine = 2;
                    switch (progresID)
                    {
                        case 0:
                            dialogName = dataDialog[((int)enum_NPCNameKulon.Agus)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameKulon.Agus)].DialogWord[2];
                            break;
                    }
                    break;
            }
        }

        private void TutorialDialouge(int dialogID, int progresID)
        {
            switch (dialogID)
            {
                case ((int)enum_TutorialState.DialogPapan1):
                    maxLine = 5;
                    switch (progresID)
                    {
                        case 0:
                            dialogName = dataDialog[((int)enum_NPCNameTutorial.Anto)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameTutorial.Anto)].DialogWord[0];
                            break;

                        case 1:
                            dialogName = dataDialog[((int)enum_NPCNameTutorial.Budi)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameTutorial.Budi)].DialogWord[0];
                            break;

                        case 2:
                            dialogName = dataDialog[((int)enum_NPCNameTutorial.Agus)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameTutorial.Agus)].DialogWord[0];
                            break;

                        case 3:
                            dialogName = dataDialog[((int)enum_NPCNameTutorial.Anto)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameTutorial.Anto)].DialogWord[1];
                            break;
                    }
                    break;

                case ((int)enum_TutorialState.DialogPapan2):
                    maxLine = 3;
                    switch (progresID)
                    {
                        case 0:
                            dialogName = dataDialog[((int)enum_NPCNameTutorial.Anto)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameTutorial.Anto)].DialogWord[2];
                            break;

                        case 1:
                            dialogName = dataDialog[((int)enum_NPCNameTutorial.Agus)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameTutorial.Agus)].DialogWord[1];
                            break;
                    }
                    break;

                case ((int)enum_TutorialState.DialogGamelan):
                    maxLine = 4;
                    switch (progresID)
                    {
                        case 0:
                            dialogName = dataDialog[((int)enum_NPCNameTutorial.Agus)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameTutorial.Agus)].DialogWord[2];
                            break;

                        case 1:
                            dialogName = dataDialog[((int)enum_NPCNameTutorial.Budi)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameTutorial.Budi)].DialogWord[1];
                            break;

                        case 2:
                            dialogName = dataDialog[((int)enum_NPCNameTutorial.Agus)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameTutorial.Agus)].DialogWord[3];
                            break;
                    }
                    break;
            }
        }

        private void TutorialSound(int dialogID, int progresID)
        {
            switch (dialogID)
            {
                case ((int)enum_TutorialState.DialogPapan1):
                    maxLine = 5;
                    switch (progresID)
                    {
                        case 0:
                            dialogSound = dataDialog[((int)enum_NPCNameTutorial.Anto)].DialogSFX[0];
                            break;

                        case 1:
                            dialogSound = dataDialog[((int)enum_NPCNameTutorial.Budi)].DialogSFX[0];
                            break;

                        case 2:
                            dialogSound = dataDialog[((int)enum_NPCNameTutorial.Agus)].DialogSFX[0];
                            break;

                        case 3:
                            dialogSound = dataDialog[((int)enum_NPCNameTutorial.Anto)].DialogSFX[1];
                            break;
                    }
                    break;

                case ((int)enum_TutorialState.DialogPapan2):
                    maxLine = 3;
                    switch (progresID)
                    {
                        case 0:
                            dialogSound = dataDialog[((int)enum_NPCNameTutorial.Anto)].DialogSFX[2];
                            break;

                        case 1:
                            dialogSound = dataDialog[((int)enum_NPCNameTutorial.Agus)].DialogSFX[1];
                            break;
                    }
                    break;

                case ((int)enum_TutorialState.DialogGamelan):
                    maxLine = 4;
                    switch (progresID)
                    {
                        case 0:
                            dialogSound = dataDialog[((int)enum_NPCNameTutorial.Agus)].DialogSFX[2];
                            break;

                        case 1:
                            dialogSound = dataDialog[((int)enum_NPCNameTutorial.Budi)].DialogSFX[1];
                            break;

                        case 2:
                            dialogSound = dataDialog[((int)enum_NPCNameTutorial.Agus)].DialogSFX[3];
                            break;
                    }
                    break;
            }

        }

        private void WetanDialouge(int dialogID, int progresID)
        {
            switch (dialogID)
            {
                case ((int)enum_WetanDialoge.KepalaDesa1):
                    maxLine = 7;
                    switch (progresID)
                    {
                        case 0:
                            dialogName = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogWord[0];
                            break;

                        case 1:
                            dialogName = dataDialog[((int)enum_NPCNameWetan.KepalaDesa)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameWetan.KepalaDesa)].DialogWord[0];
                            break;

                        case 2:
                            dialogName = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogWord[1];
                            break;

                        case 3:
                            dialogName = dataDialog[((int)enum_NPCNameWetan.KepalaDesa)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameWetan.KepalaDesa)].DialogWord[1];
                            break;

                        case 4:
                            dialogName = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogWord[2];
                            break;

                        case 5:
                            dialogName = dataDialog[((int)enum_NPCNameWetan.KepalaDesa)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameWetan.KepalaDesa)].DialogWord[2];
                            break;

                        case 6:
                            dialogName = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogWord[3];
                            break;
                    }
                    break;

                case ((int)enum_WetanDialoge.KepalaDesa2):
                    maxLine = 3;
                    switch (progresID)
                    {
                        case 0:
                            dialogName = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogWord[4];
                            break;

                        case 1:
                            dialogName = dataDialog[((int)enum_NPCNameWetan.KepalaDesa)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameWetan.KepalaDesa)].DialogWord[3];
                            break;

                        case 2:
                            dialogName = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogWord[5];
                            break;
                    }
                    break;

                case ((int)enum_WetanDialoge.KepalaDesa3):
                    maxLine = 3;
                    switch (progresID)
                    {
                        case 0:
                            dialogName = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogWord[6];
                            break;

                        case 1:
                            dialogName = dataDialog[((int)enum_NPCNameWetan.KepalaDesa)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameWetan.KepalaDesa)].DialogWord[4];
                            break;

                        case 2:
                            dialogName = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogWord[7];
                            break;
                    }
                    break;

                case ((int)enum_WetanDialoge.KetuaAdat1):
                    maxLine = 5;
                    switch (progresID)
                    {
                        case 0:
                            dialogName = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogWord[8];
                            break;

                        case 1:
                            dialogName = dataDialog[((int)enum_NPCNameWetan.KetuaAdat)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameWetan.KetuaAdat)].DialogWord[0];
                            break;

                        case 2:
                            dialogName = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogWord[9];
                            break;

                        case 3:
                            dialogName = dataDialog[((int)enum_NPCNameWetan.KetuaAdat)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameWetan.KetuaAdat)].DialogWord[1];
                            break;

                        case 4:
                            dialogName = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogWord[10];
                            break;
                    }
                    break;

                case ((int)enum_WetanDialoge.Cokro):
                    maxLine = 2;
                    switch (progresID)
                    {
                        case 0:
                            dialogName = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogWord[11];
                            break;

                        case 1:
                            dialogName = dataDialog[((int)enum_NPCNameWetan.Cokro)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameWetan.Cokro)].DialogWord[0];
                            break;
                    }
                    break;

                case ((int)enum_WetanDialoge.Aji):
                    maxLine = 3;
                    switch (progresID)
                    {
                        case 0:
                            dialogName = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogWord[12];
                            break;

                        case 1:
                            dialogName = dataDialog[((int)enum_NPCNameWetan.Aji)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameWetan.Aji)].DialogWord[0];
                            break;

                        case 2:
                            dialogName = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogWord[13];
                            break;
                    }
                    break;

                case ((int)enum_WetanDialoge.KetuaAdat2):
                    maxLine = 5;
                    switch (progresID)
                    {
                        case 0:
                            dialogName = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogWord[14];
                            break;

                        case 1:
                            dialogName = dataDialog[((int)enum_NPCNameWetan.KetuaAdat)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameWetan.KetuaAdat)].DialogWord[2];
                            break;

                        case 2:
                            dialogName = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogWord[15];
                            break;

                        case 3:
                            dialogName = dataDialog[((int)enum_NPCNameWetan.KetuaAdat)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameWetan.KetuaAdat)].DialogWord[3];
                            break;

                        case 4:
                            dialogName = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogWord[16];
                            break;
                    }
                    break;

                case ((int)enum_WetanDialoge.KetuaAdat3):
                    maxLine = 6;
                    switch (progresID)
                    {
                        case 0:
                            dialogName = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogWord[17];
                            break;

                        case 1:
                            dialogName = dataDialog[((int)enum_NPCNameWetan.KetuaAdat)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameWetan.KetuaAdat)].DialogWord[4];
                            break;

                        case 2:
                            dialogName = dataDialog[((int)enum_NPCNameWetan.KetuaAdat)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameWetan.KetuaAdat)].DialogWord[5];
                            break;

                        case 3:
                            dialogName = dataDialog[((int)enum_NPCNameWetan.KetuaAdat)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameWetan.KetuaAdat)].DialogWord[6];
                            break;

                        case 4:
                            dialogName = dataDialog[((int)enum_NPCNameWetan.KetuaAdat)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameWetan.KetuaAdat)].DialogWord[7];
                            break;

                        case 5:
                            dialogName = dataDialog[((int)enum_NPCNameWetan.KetuaAdat)].DialogName;
                            dialogText = dataDialog[((int)enum_NPCNameWetan.KetuaAdat)].DialogWord[8];
                            break;
                    }
                    break;
            }
        }

        private void WetanSound(int dialogID, int progresID)
        {
            switch (dialogID)
            {
                case ((int)enum_WetanDialoge.KepalaDesa1):
                    maxLine = 7;
                    switch (progresID)
                    {
                        case 0:
                            dialogSound = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogSFX[0];
                            break;

                        case 1:
                            dialogSound = dataDialog[((int)enum_NPCNameWetan.KepalaDesa)].DialogSFX[0];
                            break;

                        case 2:
                            dialogSound = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogSFX[1];
                            break;

                        case 3:
                            dialogSound = dataDialog[((int)enum_NPCNameWetan.KepalaDesa)].DialogSFX[1];
                            break;

                        case 4:
                            dialogSound = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogSFX[2];
                            break;

                        case 5:
                            dialogSound = dataDialog[((int)enum_NPCNameWetan.KepalaDesa)].DialogSFX[2];
                            break;

                        case 6:
                            dialogSound = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogSFX[3];
                            break;
                    }
                    break;

                case ((int)enum_WetanDialoge.KepalaDesa2):
                    maxLine = 3;
                    switch (progresID)
                    {
                        case 0:
                            dialogSound = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogSFX[4];
                            break;

                        case 1:
                            dialogSound = dataDialog[((int)enum_NPCNameWetan.KepalaDesa)].DialogSFX[3];
                            break;

                        case 2:
                            dialogSound = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogSFX[5];
                            break;
                    }
                    break;

                case ((int)enum_WetanDialoge.KepalaDesa3):
                    maxLine = 3;
                    switch (progresID)
                    {
                        case 0:
                            dialogSound = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogSFX[6];
                            break;

                        case 1:
                            dialogSound = dataDialog[((int)enum_NPCNameWetan.KepalaDesa)].DialogSFX[4];
                            break;

                        case 2:
                            dialogSound = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogSFX[7];
                            break;
                    }
                    break;

                case ((int)enum_WetanDialoge.KetuaAdat1):
                    maxLine = 5;
                    switch (progresID)
                    {
                        case 0:
                            dialogSound = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogSFX[8];
                            break;

                        case 1:
                            dialogSound = dataDialog[((int)enum_NPCNameWetan.KetuaAdat)].DialogSFX[0];
                            break;

                        case 2:
                            dialogSound = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogSFX[9];
                            break;

                        case 3:
                            dialogSound = dataDialog[((int)enum_NPCNameWetan.KetuaAdat)].DialogSFX[1];
                            break;

                        case 4:
                            dialogSound = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogSFX[10];
                            break;
                    }
                    break;

                case ((int)enum_WetanDialoge.Cokro):
                    maxLine = 2;
                    switch (progresID)
                    {
                        case 0:
                            dialogSound = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogSFX[11];
                            break;

                        case 1:
                            dialogSound = dataDialog[((int)enum_NPCNameWetan.Cokro)].DialogSFX[0];
                            break;
                    }
                    break;

                case ((int)enum_WetanDialoge.Aji):
                    maxLine = 3;
                    switch (progresID)
                    {
                        case 0:
                            dialogSound = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogSFX[12];
                            break;

                        case 1:
                            dialogSound = dataDialog[((int)enum_NPCNameWetan.Aji)].DialogSFX[0];
                            break;

                        case 2:
                            dialogSound = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogSFX[13];
                            break;
                    }
                    break;

                case ((int)enum_WetanDialoge.KetuaAdat2):
                    maxLine = 5;
                    switch (progresID)
                    {
                        case 0:
                            dialogSound = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogSFX[14];
                            break;

                        case 1:
                            dialogSound = dataDialog[((int)enum_NPCNameWetan.KetuaAdat)].DialogSFX[2];
                            break;

                        case 2:
                            dialogSound = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogSFX[15];
                            break;

                        case 3:
                            dialogSound = dataDialog[((int)enum_NPCNameWetan.KetuaAdat)].DialogSFX[3];
                            break;

                        case 4:
                            dialogSound = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogSFX[16];
                            break;
                    }
                    break;

                case ((int)enum_WetanDialoge.KetuaAdat3):
                    maxLine = 6;
                    switch (progresID)
                    {
                        case 0:
                            dialogSound = dataDialog[((int)enum_NPCNameWetan.Agus)].DialogSFX[17];
                            break;

                        case 1:
                            dialogSound = dataDialog[((int)enum_NPCNameWetan.KetuaAdat)].DialogSFX[4];
                            break;

                        case 2:
                            dialogSound = dataDialog[((int)enum_NPCNameWetan.KetuaAdat)].DialogSFX[5];
                            break;

                        case 3:
                            dialogSound = dataDialog[((int)enum_NPCNameWetan.KetuaAdat)].DialogSFX[6];
                            break;

                        case 4:
                            dialogSound = dataDialog[((int)enum_NPCNameWetan.KetuaAdat)].DialogSFX[7];
                            break;

                        case 5:
                            dialogSound = dataDialog[((int)enum_NPCNameWetan.KetuaAdat)].DialogSFX[8];
                            break;
                    }
                    break;
            }
        }*/
}
