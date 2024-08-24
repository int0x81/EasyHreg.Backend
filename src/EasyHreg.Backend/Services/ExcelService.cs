using ClosedXML.Excel;
using EasyHreg.Backend.Models;

namespace EasyHreg.Backend.Services
{
    public class ExcelService : IDatabaseService
    {
        private readonly static string filePath = "../../Data/Persons.xlsx";

        public Task<IEnumerable<Person>> GetApprovePersons(Mutation mutation)
        {
            var persons = GetPersons().Result;

            return Task.FromResult(persons.Where(p => p.Id != mutation.PersonId));
        }

        public Task<IEnumerable<Person>> GetPersons()
        {
            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheet(1);
                var range = worksheet.RangeUsed();
                var rows = range.RowsUsed();

                List<Person> persons = new List<Person>();

                foreach (var row in rows.Skip(1)) // Skip header row
                {
                    Person person = new Person
                    {
                        Id = int.Parse(row.Cell(1).Value.ToString()),
                        FirstName = row.Cell(2).Value.ToString(),
                        LastName = row.Cell(3).Value.ToString(),
                        Gender = Enum.TryParse<Gender>(row.Cell(4).GetValue<string>(), out var gender) ? gender : Gender.Other,
                        Nationality = row.Cell(5).Value.ToString(),
                        Birthdate = DateTime.ParseExact(row.Cell(6).GetValue<string>(), "dd.MM.yyyy", null),
                        Residence = row.Cell(7).Value.ToString(),
                        OfficialId = row.Cell(8).Value.ToString(),
                        Email = row.Cell(9).Value.ToString(),
                        Role = row.Cell(10).Value.ToString(),
                    };

                    persons.Add(person);
                }

                return Task.FromResult<IEnumerable<Person>>(persons);
            }
        }
    }
}