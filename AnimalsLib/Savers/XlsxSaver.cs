using AnimalsLib.Interfaces;
using OfficeOpenXml;

namespace AnimalsLib.Savers
{
    public class XlsxSaver:ISaver
    {
        public XlsxSaver()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        private ExcelPackage PrepareData(List<IAnimal> animals)
        {
            var package=new ExcelPackage();
            var sheet = package.Workbook.Worksheets.Add("DataSheet");
            var _currentRow = 1;
            foreach (var item in animals)
            {
                Type type = item.GetType();
                for (int i = 0; i < type.GetProperties().Length; i++)
                {                    
                    sheet.Cells[_currentRow,i+1].Value=type.GetProperties()[i].GetValue(item);
                }
                _currentRow++;
            }
            return package;
        }

        public void SaveData(string savePath, List<IAnimal> animals)
        {
            var package=PrepareData(animals);
            package.SaveAs($"{savePath}.xlsx");
        }
    }
}
