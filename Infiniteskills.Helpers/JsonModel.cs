
namespace Infiniteskills.Helpers
{
    public class JsonSimpleData
    {
        public string Data { get; set; }
    }
    public class EditAction
    {
        public string editAction { get; set; }
        public int Id { get; set; }
    }
    public class JsonHeader
    {
        public string Header { get; set; }
        public string Row { get; set; }
        public string Detail { get; set; }
        public string EditAction { get; set; }
    }
    public class JsonGridRow
    {
        public string Header { get; set; }
        public string EditValues { get; set; }
        public string Row { get; set; }
        public string RowList { get; set; }
    }
    public class JsonGridRowMultiDetail : JsonGridRow
    {
        public string Detail1 { get; set; }
        public string Detail2 { get; set; }
    }
}
