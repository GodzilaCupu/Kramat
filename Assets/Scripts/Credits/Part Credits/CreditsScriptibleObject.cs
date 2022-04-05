using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "CreditsContentScriptbleObject",menuName ="ScriptibleObject/CreditsScene/CreditsTextBuilder")]
public class CreditsScriptibleObject : ScriptableObject
{
    public int id;

    //Value Size
    public int _jobdeskSize,_titleSize, _nameSize;

    //Value Color
    public Color _colorJobdesk,_colorTitle, _colorName;
    public string _hexCodeJobdesk => "#" + ColorUtility.ToHtmlStringRGBA(_colorJobdesk);
    public string _hexCodeTitle => "#" + ColorUtility.ToHtmlStringRGBA(_colorTitle);
    public string _hexCodeName => "#" + ColorUtility.ToHtmlStringRGBA(_colorName);


    //Content
    [SerializeField] private string _stringJobdesk;
    public string getJobdesk => "<color=" + _hexCodeJobdesk + ">" + "<size=" + _jobdeskSize.ToString() + ">" + _stringJobdesk + "</size>" + "</color>";
    public string[] _stringTitle;
    public string[] _stringName;

    [TextArea(10, 30)]
    public List<string> _contentText;

    public void ContentBuilder()
    {
        _contentText.Clear();

        for (int i = 0; i < _stringTitle.Length; i++)
        {
            _contentText.Add("<color=" + _hexCodeTitle + ">" +"<size=" + _titleSize.ToString() + ">"+ _stringTitle[i] + "</size>" + "</color>" +
                        "\n" + "<color=" + _hexCodeName + ">" + "<size=" + _nameSize.ToString() + ">" + _stringName[i] + "</size>" + "</color>" + "\n");
        }
    }
}
