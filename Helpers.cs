using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonHelper
{
    public static T[] getJsonArray<T>(string json)
    {
        string newJson = "{ \"array\": " + json + "}";
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);
        return wrapper.array;
    }

    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] array;
    }
}

[System.Serializable]
public class Guid
{
    public string rendered { get; set; }
}

[System.Serializable]
public class Title
{
    public string rendered { get; set; }
}

[System.Serializable]
public class Content
{
    public string rendered { get; set; }
    public bool @protected { get; set; }
}

[System.Serializable]
public class Excerpt
{
    public string rendered { get; set; }
    public bool @protected { get; set; }
}

[System.Serializable]
public class Meta
{
    public string outcome { get; set; }
    public string status { get; set; }
    public int crunchbase_tag { get; set; }
    public string amp_status { get; set; }
    public List<object> relegenceEntities { get; set; }
    public List<object> relegenceSubjects { get; set; }
}

[System.Serializable]
public class RapidData
{
    public string pt { get; set; }
    public string pct { get; set; }
}

[System.Serializable]
public class Tag
{
    public int term_id { get; set; }
    public string name { get; set; }
    public string slug { get; set; }
    public int term_group { get; set; }
    public int term_taxonomy_id { get; set; }
    public string taxonomy { get; set; }
    public string description { get; set; }
    public int parent { get; set; }
    public int count { get; set; }
    public string filter { get; set; }
}

[System.Serializable]
public class TcUnifiedTagging
{
    public Tag tag { get; set; }
    public List<object> cb_tags { get; set; }
}

[System.Serializable]
public class RootObject
{
    public int id { get; set; }
    public DateTime date { get; set; }
    public DateTime date_gmt { get; set; }
    public Guid guid { get; set; }
    public DateTime modified { get; set; }
    public DateTime modified_gmt { get; set; }
    public string slug { get; set; }
    public string status { get; set; }
    public string type { get; set; }
    public string link { get; set; }
    public Title title { get; set; }
    public Content content { get; set; }
    public Excerpt excerpt { get; set; }
    public int author { get; set; }
    public int featured_media { get; set; }
    public string comment_status { get; set; }
    public string ping_status { get; set; }
    public bool sticky { get; set; }
    public string template { get; set; }
    public string format { get; set; }
    public Meta meta { get; set; }
    public List<int> categories { get; set; }
    public List<int> tags { get; set; }
    public List<int> crunchbase_tag { get; set; }
    public List<object> tc_stories_tax { get; set; }
    public List<object> tc_event { get; set; }
    public string shortlink { get; set; }
    public RapidData rapidData { get; set; }
    public bool featured { get; set; }
    public string subtitle { get; set; }
    public bool fundingRound { get; set; }
    public string seoTitle { get; set; }
    public string seoDescription { get; set; }
    public List<TcUnifiedTagging> tc_unified_tagging { get; set; }
    public object associatedEvent { get; set; }
    public object @event { get; set; }
    public List<int> authors { get; set; }
    public bool hideFeaturedImage { get; set; }
}