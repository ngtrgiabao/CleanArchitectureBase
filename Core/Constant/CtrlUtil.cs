namespace Core.Constant
{
    public class CtrlUtil
    { 

        public static object ApplyPaging<T, TKey>(int cursor, int pageSize, List<T> items)
         where T : class
        {
            cursor = (cursor - 1) * pageSize;
            //var query = schema.AsQueryable();
            //var items = await query.ToListAsync();  

            var filteredItems = items.Where(item => GetItemId(item) > cursor);

            var pageItems = filteredItems.Take(pageSize).ToList();
            var hasNextPage = filteredItems.Skip(pageSize).Any();

            return new
            {
                Items = pageItems,
                HasNextPage = hasNextPage
            };
        }


        public static List<T> ApplySorting<T, TKey>(ref List<T> items, string sortName, string ascending = "asc")
        where T : class
        {
            items = ascending == "asc"
                    ? items.OrderBy(item => GetSortValue(item, sortName)).ToList()
                    : items.OrderByDescending(item => GetSortValue(item, sortName)).ToList();
            return items;

        }

        public static int GetItemId<T>(T item)
        {
            var itemIdProperty = typeof(T).GetProperty("Id");
            return (int)itemIdProperty.GetValue(item);
        }

        public static object GetSortValue<T>(T item, string sortName)
        {
            var property = typeof(T).GetProperty(sortName);
            if (property != null)
            {
                return property.GetValue(item);
            }
            return "";

        }
    }
}

