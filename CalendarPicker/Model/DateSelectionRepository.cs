using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CalendarPicker.Model
{
    public class DateSelectionRepository : IRepository<DateSelection>
    {
        private const string FilePath = "DateSelection";

        public void Dispose()
        {}

        public Task Add(DateSelection entity)
        {
            return File.AppendAllTextAsync(FilePath, Utf8Json.JsonSerializer.ToJsonString(entity));
        }

        public async Task<IEnumerable<DateSelection>> GetAll()
        {
            using var readStream = new StreamReader(FilePath, System.Text.Encoding.Default);
            var line = "";
            var result = new List<DateSelection>();

            while ((line = await readStream.ReadLineAsync()) != null)
                result.Add(Utf8Json.JsonSerializer.Deserialize<DateSelection>(line));

            return result;
        }
    }
}