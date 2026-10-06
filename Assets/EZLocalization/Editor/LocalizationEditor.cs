using UnityEditor;
using UnityEngine;
using System.Linq;



public class LocalizationTextEditor : EditorWindow
{
    private LocalizationTextDatabase db;
    private Vector2 scroll;
    private string newId = "";

    [MenuItem("Tools/EZLocation/Text Localization Editor")]
    public static void Open()
    {
        GetWindow<LocalizationTextEditor>("Text Localization Editor");
    }

    private void OnEnable()
    {
        db = LocalizationTextFile.Load();
    }

    private void OnGUI()
    {
        if (db == null)
            db = new LocalizationTextDatabase();

        scroll = EditorGUILayout.BeginScrollView(scroll);

        foreach (var entry in db.entries.ToList())
        {
            EditorGUILayout.BeginVertical("box");

            EditorGUILayout.BeginHorizontal();
            entry.id = EditorGUILayout.TextField("ID", entry.id);

            if (GUILayout.Button("X", GUILayout.Width(30)))
            {
                db.entries.Remove(entry);
                break;
            }
            EditorGUILayout.EndHorizontal();

            foreach (var line in entry.lines)
            {
                EditorGUILayout.BeginHorizontal();
                line.language = (SystemLanguage)EditorGUILayout.EnumPopup(line.language);
                line.text = EditorGUILayout.TextField(line.text);

                if (GUILayout.Button("-", GUILayout.Width(25)))
                {
                    entry.lines.Remove(line);
                    break;
                }

                EditorGUILayout.EndHorizontal();
            }

            if (GUILayout.Button("+ Add Language"))
            {
                entry.lines.Add(new LocalizedLine
                {
                    language = SystemLanguage.English,
                    text = ""
                });
            }

            EditorGUILayout.EndVertical();
        }

        EditorGUILayout.Space();

        EditorGUILayout.BeginHorizontal();
        newId = EditorGUILayout.TextField("New ID", newId);

        if (GUILayout.Button("Add Localization"))
        {
            if (!string.IsNullOrEmpty(newId) && !db.entries.Any(e => e.id == newId))
            {
                db.entries.Add(new LocalizationTextEntry
                {
                    id = newId
                });

                newId = "";
            }
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();

        if (GUILayout.Button("Save"))
        {
            LocalizationTextFile.Save(db);
        }

        EditorGUILayout.EndScrollView();
    }
}

public class LocalizationAudioEditor : EditorWindow
{
    private LocalizationAudioDatabase db;
    private Vector2 scroll;
    private string newId = "";

    [MenuItem("Tools/EZLocation/Audio Localization Editor")]
    public static void Open()
    {
        GetWindow<LocalizationAudioEditor>("Audio Localization Editor");
    }

    private void OnEnable()
    {
        db = LocalizationAudioFile.Load();
    }

    private void OnGUI()
    {
        if (db == null)
            db = new LocalizationAudioDatabase();

        scroll = EditorGUILayout.BeginScrollView(scroll);

        foreach (var entry in db.entries.ToList())
        {
            EditorGUILayout.BeginVertical("box");

            EditorGUILayout.BeginHorizontal();
            entry.id = EditorGUILayout.TextField("ID", entry.id);

            if (GUILayout.Button("X", GUILayout.Width(30)))
            {
                db.entries.Remove(entry);
                break;
            }
            EditorGUILayout.EndHorizontal();

            foreach (var line in entry.clips)
            {
                EditorGUILayout.BeginHorizontal();
                line.language = (SystemLanguage)EditorGUILayout.EnumPopup(line.language);
                line.clip_path = EditorGUILayout.TextField(line.clip_path);

                if (GUILayout.Button("-", GUILayout.Width(25)))
                {
                    entry.clips.Remove(line);
                    break;
                }

                EditorGUILayout.EndHorizontal();
            }

            if (GUILayout.Button("+ Add Language"))
            {
                entry.clips.Add(new LocalizedAudio
                {
                    language = SystemLanguage.English,
                    clip_path = ""
                });
            }

            EditorGUILayout.EndVertical();
        }

        EditorGUILayout.Space();

        EditorGUILayout.BeginHorizontal();
        newId = EditorGUILayout.TextField("New ID", newId);

        if (GUILayout.Button("Add Localization"))
        {
            if (!string.IsNullOrEmpty(newId) && !db.entries.Any(e => e.id == newId))
            {
                db.entries.Add(new LocalizationAudioEntry
                {
                    id = newId
                });

                newId = "";
            }
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();

        if (GUILayout.Button("Save"))
        {
            LocalizationAudioFile.Save(db);
        }

        EditorGUILayout.EndScrollView();
    }
}

public class LocalizationImageEditor : EditorWindow
{
    private LocalizationImageDatabase db;
    private Vector2 scroll;
    private string newId = "";

    [MenuItem("Tools/EZLocation/Image Localization Editor")]
    public static void Open()
    {
        GetWindow<LocalizationImageEditor>("Image Localization Editor");
    }

    private void OnEnable()
    {
        db = LocalizationImageFile.Load();
    }

    private void OnGUI()
    {
        if (db == null)
            db = new LocalizationImageDatabase();

        scroll = EditorGUILayout.BeginScrollView(scroll);

        foreach (var entry in db.entries.ToList())
        {
            EditorGUILayout.BeginVertical("box");

            EditorGUILayout.BeginHorizontal();
            entry.id = EditorGUILayout.TextField("ID", entry.id);

            if (GUILayout.Button("X", GUILayout.Width(30)))
            {
                db.entries.Remove(entry);
                break;
            }
            EditorGUILayout.EndHorizontal();

            foreach (var line in entry.imgs)
            {
                EditorGUILayout.BeginHorizontal();
                line.language = (SystemLanguage)EditorGUILayout.EnumPopup(line.language);
                line.sprite_path = EditorGUILayout.TextField(line.sprite_path);

                if (GUILayout.Button("-", GUILayout.Width(25)))
                {
                    entry.imgs.Remove(line);
                    break;
                }

                EditorGUILayout.EndHorizontal();
            }

            if (GUILayout.Button("+ Add Language"))
            {
                entry.imgs.Add(new LocalizedImage
                {
                    language = SystemLanguage.English,
                    sprite_path = ""
                });
            }

            EditorGUILayout.EndVertical();
        }

        EditorGUILayout.Space();

        EditorGUILayout.BeginHorizontal();
        newId = EditorGUILayout.TextField("New ID", newId);

        if (GUILayout.Button("Add Localization"))
        {
            if (!string.IsNullOrEmpty(newId) && !db.entries.Any(e => e.id == newId))
            {
                db.entries.Add(new LocalizationImageEntry
                {
                    id = newId
                });

                newId = "";
            }
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();

        if (GUILayout.Button("Save"))
        {
            LocalizationImageFile.Save(db);
        }

        EditorGUILayout.EndScrollView();
    }
}