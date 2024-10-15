namespace Talabat.APIS.Helpers
{
    public class pagination<T>
    {

        public int PageSize { get; set; }
        public int PageIndex { get; set; }

        public int Count { get; set; }

        public IReadOnlyList<T> Data;

        public pagination(int pageSize, int pageIndex, int count, IReadOnlyList<T> data)
        {
            PageSize = pageSize;
            PageIndex = pageIndex;
            Count = count;
            Data = data;
        }
    }
}
