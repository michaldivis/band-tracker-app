using System.Collections.ObjectModel;

namespace BandTracker.Core.Extensions;
public static class ObservableCollectionExtensions
{
    public static void ReplaceRange<T>(this ObservableCollection<T> collection, IEnumerable<T> items)
    {
        collection.Clear();

        foreach (var item in items)
        {
            collection.Add(item);
        }
    }
}
