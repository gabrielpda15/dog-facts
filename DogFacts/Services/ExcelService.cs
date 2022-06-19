using ClosedXML.Excel;
using DogFacts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogFacts.Services
{
    public class ExcelService : BaseService
    {
        public ExcelService() : base() { }

        public IEnumerable<T> ReadCells<T>(string file, string range)
        {
            var result = new List<T>();

            using (var wbook = new XLWorkbook(file))
            {
                var ws = wbook.Worksheet(1);
                var values = ws.Range(range).CellsUsed().Select(c => c.GetValue<T>());
                result.AddRange(values);
            }

            return result;
        }

        public void SaveDogFacts(IEnumerable<IEnumerable<string>> factsList, string file)
        {
            using var wbook = new XLWorkbook();

            foreach (var facts in factsList)
            {
                var ws = wbook.AddWorksheet();
                for (int i = 0; i < facts.Count(); i++)
                {
                    ws.Cell(i + 1, 1).Value = facts.ElementAt(i);
                }
            }

            wbook.SaveAs(file);
        }
    }
}
