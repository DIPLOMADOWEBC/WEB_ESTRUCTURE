
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Infiniteskills.Helpers
{
    public class SelectListFirstElementName
    {
        public const string EMPTY = "";
        public const string NONE = "(NINGUNO)";
        public const string ALL = "(TODOS)";
        public const string SELECT = "(SELECCIONE)";
    }
    public enum SelectListFirstElementType
    {
        Empty = 0,
        None = 1,
        All = 2,
        Select = 3,
        ListItems = 9
    }
    public class WebHelper
    {
        public static List<SelectListItem> ToSelectListItem<T>(IEnumerable<T> enumerable, Func<T, string> getValue, Func<T, string> getText)
        {
            return ToSelectListItem<T>(enumerable, getValue, getText, SelectListFirstElementType.Empty, String.Empty);
        }
        public static List<SelectListItem> ToSelectListItem<T>(IEnumerable<T> enumerable, Func<T, string> getValue, Func<T, string> getText,
           string selectedValue)
        {
            return ToSelectListItem<T>(enumerable, getValue, getText, SelectListFirstElementType.Empty, selectedValue);
        }
        public static List<SelectListItem> ToSelectListItem<T>(SelectListFirstElementType firstElement)
        {
            return ToSelectListItem<T>(null, null, null, firstElement, String.Empty);
        }
        public static List<SelectListItem> ToSelectListItem<T>(IEnumerable<T> enumerable, Func<T, string> getValue, Func<T, string> getText,
           SelectListFirstElementType firstElement, string selectedValue)
        {
            List<SelectListItem> selectedList = new List<SelectListItem>();

            string firtsText = SelectListFirstElementName.EMPTY;
            switch (firstElement)
            {
                case SelectListFirstElementType.Empty:
                    break;
                case SelectListFirstElementType.None:
                    firtsText = SelectListFirstElementName.NONE;
                    break;
                case SelectListFirstElementType.Select:
                    firtsText = SelectListFirstElementName.SELECT;
                    break;
                case SelectListFirstElementType.All:
                    firtsText = SelectListFirstElementName.ALL;
                    break;
            }

            selectedList.Add(new SelectListItem { Text = firtsText, Value = string.Empty, Selected = (selectedValue == "" ? true : false) });

            if (enumerable != null)
            {
                var tempList = enumerable
                  .Select(x => new SelectListItem
                  {
                      Selected = (getValue(x) == selectedValue),
                      Text = getText(x),
                      Value = getValue(x)
                  })
                  .ToList();

                selectedList.AddRange(tempList);
            }

            return selectedList;
        }
        public static Dictionary<string, string> JsonToDictionary(string jsonText)
        {
            Dictionary<string, string> stringDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonText);
            return stringDictionary;
        }
        public static Dictionary<string, string>[] JsonToArrayDictionary(string jsonText)
        {

            Dictionary<string, string>[] dic = JsonConvert.DeserializeObject<Dictionary<string, string>[]>(jsonText);
            return dic;
        }
        public static Dictionary<string, object>[] JsonToObjectArrayDictionary(string jsonText)
        {
            Dictionary<string, object>[] dic = JsonConvert.DeserializeObject<Dictionary<string, object>[]>(jsonText);
            return dic;
        }
        public static List<Dictionary<string, string>> JsonToDictionaryList(string jsonText)
        {
            List<Dictionary<string, string>> list = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(jsonText);
            return list;
        }
        public static string ToJSON(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
