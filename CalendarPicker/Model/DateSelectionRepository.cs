using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Utf8Json;

namespace CalendarPicker.Model
{
    public class DateSelectionRepository : IRepository<DateSelection>
    {
        private const string FilePath = "DateSelection";

        public void Dispose()
        {}

        public Task Add(DateSelection entity)
        {
            var content = JsonSerializer.ToJsonString(entity) + Environment.NewLine;
            return File.AppendAllTextAsync(FilePath, content);
        }

        public async Task<IEnumerable<DateSelection>> GetAll()
        {
            if (!File.Exists(FilePath))
                return null;

            using var readStream = new StreamReader(FilePath, System.Text.Encoding.Default);
            string line;
            var result = new List<DateSelection>();

            while ((line = await readStream.ReadLineAsync()) != null)
                result.Add(JsonSerializer.Deserialize<DateSelection>(line));

            return result;
        }
    }
}